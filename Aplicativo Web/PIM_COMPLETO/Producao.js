// Classe para gerenciar os botões de navegação
class NavigationButton {
    // O construtor recebe o seletor do botão e a URL para onde o botão deve redirecionar
    constructor(buttonSelector, targetUrl) {
        this.button = document.querySelector(buttonSelector);  // Seleciona o botão com base no seletor
        this.targetUrl = targetUrl;  // Define a URL de redirecionamento
        this.initEventListeners();  // Inicializa os eventos
    }

    // Adiciona um evento de clique ao botão
    initEventListeners() {
        if (this.button) {  // Verifica se o botão existe na página
            this.button.addEventListener('click', () => this.redirecionar());  // Chama a função redirecionar quando o botão é clicado
        }
    }

    // Função para redirecionar o usuário para a URL alvo
    redirecionar() {
        window.location.href = this.targetUrl;  // Redireciona o usuário para a URL definida
    }
}

// Função para carregar as produções cadastradas e exibi-las na lista
function carregarProducoes() {
    const listaProducoes = document.querySelector('.production-list');  // Seleciona o elemento onde as produções serão listadas

    // Recupera as produções do localStorage e converte de JSON para um array de objetos
    let producoes = JSON.parse(localStorage.getItem('producoes')) || [];

    // Limpa a lista atual para evitar duplicações
    listaProducoes.innerHTML = '';

    // Adiciona cada produção cadastrada à lista
    producoes.forEach((producao, index) => {
        const div = document.createElement('div');  // Cria um novo div para cada item de produção
        div.classList.add('production-item');  // Adiciona a classe CSS para o item de produção
        div.setAttribute('data-id', index);  // Adiciona um atributo 'data-id' para identificar a produção pelo índice
        div.innerHTML = `
            <span>PRODUÇÃO ${index + 1}: ${producao.nomeProduto}</span>
            <button class="delete-production-btn" data-id="${index}">Excluir</button>
        `;  // Define o conteúdo da div, incluindo um botão de excluir
        listaProducoes.appendChild(div);  // Adiciona o div à lista de produções

        // Adiciona um evento de clique para exibir os detalhes da produção
        div.addEventListener('click', () => exibirDetalhesProducao(index));
    });

    // Adiciona a funcionalidade de exclusão aos botões de excluir produção
    const deleteButtons = document.querySelectorAll('.delete-production-btn');  // Seleciona todos os botões de excluir
    deleteButtons.forEach(button => {
        button.addEventListener('click', (event) => {
            event.stopPropagation();  // Previne que o modal de detalhes seja aberto ao excluir
            const producaoId = event.target.getAttribute('data-id');  // Pega o ID da produção a ser excluída
            excluirProducao(producaoId);  // Chama a função para excluir a produção
        });
    });
}

// Função para exibir os detalhes de uma produção em um modal
function exibirDetalhesProducao(index) {
    const modal = document.getElementById('productionModal');  // Seleciona o modal de detalhes da produção
    const closeModal = document.getElementById('closeModal');  // Seleciona o botão de fechar o modal
    const productionDetails = document.getElementById('production-details');  // Seleciona o elemento onde os detalhes da produção serão exibidos

    // Recupera as produções do localStorage
    let producoes = JSON.parse(localStorage.getItem('producoes')) || [];
    const producao = producoes[index];  // Obtém a produção correspondente ao índice

    // Preenche o modal com os detalhes da produção
    productionDetails.innerHTML = `
        <strong>Produto:</strong> ${producao.produto}<br>
        <strong>Quantidade:</strong> ${producao.quantidade}<br>
        <strong>Data de Produção:</strong> ${producao.dataProducao}<br>
        <strong>Responsável:</strong> ${producao.responsavel}<br>
        <strong>Id Produção:</STRONG> ${producao.idProducao}<br>
    `;

    // Exibe o modal
    modal.style.display = 'block';

    // Fecha o modal quando o usuário clica no botão "X"
    closeModal.onclick = function() {
        modal.style.display = 'none';
    }

    // Fecha o modal quando o usuário clica fora da janela do modal
    window.onclick = function(event) {
        if (event.target == modal) {
            modal.style.display = 'none';
        }
    }
}

// Função para excluir uma produção pelo ID
function excluirProducao(id) {
    if (confirm('Tem certeza que deseja excluir esta produção?')) {  // Exibe uma mensagem de confirmação
        // Recupera as produções do localStorage
        let producoes = JSON.parse(localStorage.getItem('producoes')) || [];

        // Remove a produção da lista pelo índice
        producoes.splice(id, 1);

        // Atualiza o localStorage com a lista de produções atualizada
        localStorage.setItem('producoes', JSON.stringify(producoes));

        // Recarrega a lista de produções após a exclusão
        carregarProducoes();
    }
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Carrega as produções cadastradas quando a página é carregada
    carregarProducoes();

    // Gerencia o botão de voltar para a página inicial
    new NavigationButton('#backButton', 'inicial.html');  // Cria uma instância de NavigationButton para o botão de voltar

    // Gerencia o botão de nova produção
    const newProductionButton = document.querySelector('.new-production-btn');  // Seleciona o botão de nova produção
    if (newProductionButton) {
        newProductionButton.addEventListener('click', () => {
            window.location.href = 'NovaProducao.html';  // Redireciona para a página de nova produção quando o botão é clicado
        });
    }
});
