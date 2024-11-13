// Classe para gerenciar os botões de navegação
class NavigationButton {
    // O construtor recebe um seletor de botão e a URL de destino para redirecionamento
    constructor(buttonSelector, targetUrl) {
        this.button = document.querySelector(buttonSelector); // Seleciona o botão usando o seletor fornecido
        this.targetUrl = targetUrl; // Define a URL para onde o botão redirecionará
        this.initEventListeners(); // Inicializa o evento de clique do botão
    }

    // Método para inicializar os ouvintes de evento
    initEventListeners() {
        // Se o botão foi encontrado, adiciona um evento de clique que chama o método redirecionar
        if (this.button) {
            this.button.addEventListener('click', () => this.redirecionar());
        }
    }

    // Método que realiza o redirecionamento para a URL de destino
    redirecionar() {
        window.location.href = this.targetUrl; // Redireciona para a URL especificada
    }
}

// Classe para gerenciar produções
class ProductionManager {
    // Construtor que inicializa a lista de produções e carrega os dados
    constructor() {
        this.listaProducoes = document.querySelector('.production-list'); // Seleciona o elemento que exibe a lista de produções
        this.carregarProducoes(); // Carrega as produções salvas
    }

    // Método para carregar e exibir as produções armazenadas no localStorage
    carregarProducoes() {
        let producoes = JSON.parse(localStorage.getItem('producoes')) || []; // Recupera produções do localStorage ou inicia com uma lista vazia
        this.listaProducoes.innerHTML = ''; // Limpa a lista de produções na interface

        // Itera sobre cada produção para criar e adicionar um item de produção na lista
        producoes.forEach((producao, index) => {
            const div = document.createElement('div'); // Cria um novo elemento de produção
            div.classList.add('production-item'); // Adiciona uma classe para o estilo do item de produção
            div.setAttribute('data-id', index); // Define um atributo de ID de produção
            div.innerHTML = `
                <span>PRODUÇÃO ${index + 1}: ${producao.nomeProduto || ''}</span>
                <button class="delete-production-btn" data-id="${index}">Excluir</button>
            `; // Define o HTML do item de produção com botão de exclusão
            this.listaProducoes.appendChild(div); // Adiciona o item de produção na lista

            // Adiciona evento para exibir os detalhes ao clicar no item de produção
            div.addEventListener('click', () => this.exibirDetalhesProducao(index));
        });

        // Seleciona todos os botões de exclusão e adiciona um evento de clique para excluir a produção
        const deleteButtons = this.listaProducoes.querySelectorAll('.delete-production-btn');
        deleteButtons.forEach(button => {
            button.addEventListener('click', (event) => {
                event.stopPropagation(); // Evita que o clique no botão propague para o item de produção
                const producaoId = event.target.getAttribute('data-id'); // Obtém o ID da produção a ser excluída
                this.excluirProducao(producaoId); // Chama o método de exclusão
            });
        });
    }

    // Método para exibir detalhes de uma produção em um modal
    exibirDetalhesProducao(index) {
        const modal = document.getElementById('productionModal'); // Seleciona o modal de produção
        const closeModal = document.getElementById('closeModal'); // Seleciona o botão de fechar do modal
        const productionDetails = document.getElementById('production-details'); // Seleciona o elemento de detalhes da produção

        let producoes = JSON.parse(localStorage.getItem('producoes')) || []; // Recupera as produções do localStorage
        const producao = producoes[index]; // Obtém a produção específica pelo índice

        // Define o HTML dos detalhes da produção com campos editáveis
        productionDetails.innerHTML = `
            <label><strong>Produto:</strong></label>
            <input type="text" id="editProduto" value="${producao.produto || ''}"><br>
            <label><strong>Quantidade:</strong></label>
            <input type="text" id="editQuantidade" value="${producao.quantidade || ''}"><br>
            <label><strong>Data de Produção:</strong></label>
            <input type="date" id="editDataProducao" value="${producao.dataProducao || ''}"><br>
            <label><strong>Responsável:</strong></label>
            <input type="text" id="editResponsavel" value="${producao.responsavel || ''}"><br>
            <label><strong>Id Produção:</strong></label>
            <input type="text" id="editIdProducao" value="${producao.idProducao || ''}" disabled><br>
            <button id="saveProduction">Salvar</button>
        `;

        modal.style.display = 'block'; // Exibe o modal

        closeModal.onclick = () => { // Evento para fechar o modal ao clicar no botão de fechar
            modal.style.display = 'none';
        };

        // Fecha o modal se o usuário clicar fora dele
        window.onclick = (event) => {
            if (event.target === modal) {
                modal.style.display = 'none';
            }
        };

        // Adiciona evento ao botão salvar, chamando o método para salvar as alterações
        document.getElementById('saveProduction').onclick = () => {
            this.salvarAlteracoes(index);
        };
    }

    // Método para salvar alterações feitas em uma produção
    salvarAlteracoes(index) {
        let producoes = JSON.parse(localStorage.getItem('producoes')) || []; // Recupera as produções do localStorage
        const editProduto = document.getElementById('editProduto').value; // Obtém o valor editado do produto
        const editQuantidade = document.getElementById('editQuantidade').value; // Obtém o valor editado da quantidade
        const editDataProducao = document.getElementById('editDataProducao').value; // Obtém a data de produção editada
        const editResponsavel = document.getElementById('editResponsavel').value; // Obtém o responsável editado

        // Atualiza os dados da produção específica com os novos valores
        producoes[index].produto = editProduto;
        producoes[index].quantidade = editQuantidade;
        producoes[index].dataProducao = editDataProducao;
        producoes[index].responsavel = editResponsavel;

        localStorage.setItem('producoes', JSON.stringify(producoes)); // Salva as produções atualizadas no localStorage
        this.carregarProducoes(); // Recarrega a lista de produções
        window.location.href = 'Producao.html'; // Redireciona para a página de produções
    }

    // Método para excluir uma produção com confirmação
    excluirProducao(id) {
        if (confirm('Tem certeza que deseja excluir esta produção?')) { // Solicita confirmação ao usuário
            let producoes = JSON.parse(localStorage.getItem('producoes')) || []; // Recupera as produções do localStorage
            producoes.splice(id, 1); // Remove a produção pelo ID
            localStorage.setItem('producoes', JSON.stringify(producoes)); // Salva as produções atualizadas no localStorage
            this.carregarProducoes(); // Recarrega a lista de produções
        }
    }
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    const productionManager = new ProductionManager(); // Cria uma instância do gerenciador de produções
    new NavigationButton('#backButton', 'inicialGerente.html'); // Cria um botão de navegação para voltar à página inicial do gerente

    // Seleciona o botão de nova produção e adiciona evento para redirecionar à página de nova produção
    const newProductionButton = document.querySelector('.new-production-btn');
    if (newProductionButton) {
        newProductionButton.addEventListener('click', () => {
            window.location.href = 'NovaProducaoG.html'; // Redireciona para a página de nova produção
        });
    }
});
