// Classe para gerenciar os botões de navegação
class NavigationButton {
    // Construtor da classe que recebe o seletor do botão e a URL de destino
    constructor(buttonSelector, targetUrl) {
        this.button = document.querySelector(buttonSelector); // Seleciona o botão com base no seletor fornecido
        this.targetUrl = targetUrl; // Define a URL de destino para redirecionamento
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    // Adiciona um evento de clique ao botão, caso ele exista
    initEventListeners() {
        if (this.button) {
            this.button.addEventListener('click', () => this.redirecionar()); // Define o evento de redirecionamento ao clicar
        }
    }

    // Função que redireciona para a URL alvo
    redirecionar() {
        window.location.href = this.targetUrl; // Altera a URL para a URL de destino
    }
}

// Classe para gerenciar produções
class ProductionManager {
    // Construtor que seleciona a lista de produções e carrega as produções armazenadas
    constructor() {
        this.listaProducoes = document.querySelector('.production-list'); // Seleciona o elemento da lista de produções
        this.carregarProducoes(); // Carrega as produções salvas
    }

    // Carrega as produções armazenadas e renderiza na tela
    carregarProducoes() {
        let producoes = JSON.parse(localStorage.getItem('producoes')) || []; // Obtém as produções do localStorage ou uma lista vazia
        this.listaProducoes.innerHTML = ''; // Limpa a lista de produções

        producoes.forEach((producao, index) => { // Para cada produção, cria um elemento de exibição
            const div = document.createElement('div'); // Cria um novo elemento div para a produção
            div.classList.add('production-item'); // Adiciona a classe para estilização
            div.setAttribute('data-id', index); // Define o índice da produção como um atributo de dados
            div.innerHTML = `
                <span>PRODUÇÃO ${index + 1}: ${producao.nomeProduto || ''}</span>
                <button class="delete-production-btn" data-id="${index}">Excluir</button>
            `; // Define o conteúdo HTML com nome e botão de exclusão

            this.listaProducoes.appendChild(div); // Adiciona o item à lista de produções

            // Adiciona evento de clique ao item para exibir detalhes da produção
            div.addEventListener('click', () => this.exibirDetalhesProducao(index));
        });

        // Adiciona o evento de exclusão aos botões de cada item
        const deleteButtons = this.listaProducoes.querySelectorAll('.delete-production-btn');
        deleteButtons.forEach(button => {
            button.addEventListener('click', (event) => {
                event.stopPropagation(); // Impede a propagação do evento de clique para evitar conflitos
                const producaoId = event.target.getAttribute('data-id'); // Obtém o ID da produção
                this.excluirProducao(producaoId); // Chama a função de exclusão
            });
        });
    }

    // Exibe os detalhes da produção em um modal
    exibirDetalhesProducao(index) {
        const modal = document.getElementById('productionModal'); // Seleciona o modal
        const closeModal = document.getElementById('closeModal'); // Seleciona o botão de fechar o modal
        const productionDetails = document.getElementById('production-details'); // Seleciona o elemento onde os detalhes serão exibidos

        let producoes = JSON.parse(localStorage.getItem('producoes')) || []; // Obtém as produções do localStorage
        const producao = producoes[index]; // Seleciona a produção correspondente ao índice

        // Preenche o modal com os dados da produção
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

        // Fecha o modal ao clicar no botão de fechar
        closeModal.onclick = () => {
            modal.style.display = 'none';
        };

        // Fecha o modal ao clicar fora dele
        window.onclick = (event) => {
            if (event.target === modal) {
                modal.style.display = 'none';
            }
        };

        // Salva as alterações ao clicar no botão de salvar
        document.getElementById('saveProduction').onclick = () => {
            this.salvarAlteracoes(index); // Chama a função para salvar alterações
        };
    }

    // Salva as alterações feitas na produção e atualiza o localStorage
    salvarAlteracoes(index) {
        let producoes = JSON.parse(localStorage.getItem('producoes')) || []; // Obtém as produções do localStorage
        const editProduto = document.getElementById('editProduto').value; // Obtém o valor do campo editado
        const editQuantidade = document.getElementById('editQuantidade').value;
        const editDataProducao = document.getElementById('editDataProducao').value;
        const editResponsavel = document.getElementById('editResponsavel').value;

        // Atualiza os dados da produção com os novos valores
        producoes[index].produto = editProduto;
        producoes[index].quantidade = editQuantidade;
        producoes[index].dataProducao = editDataProducao;
        producoes[index].responsavel = editResponsavel;

        localStorage.setItem('producoes', JSON.stringify(producoes)); // Salva as produções atualizadas no localStorage
        this.carregarProducoes(); // Recarrega a lista de produções
        window.location.href = 'Producao.html'; // Redireciona para a página de produção
    }

    // Exclui uma produção após confirmação do usuário
    excluirProducao(id) {
        if (confirm('Tem certeza que deseja excluir esta produção?')) { // Pede confirmação para excluir
            let producoes = JSON.parse(localStorage.getItem('producoes')) || []; // Obtém as produções do localStorage
            producoes.splice(id, 1); // Remove a produção pelo índice
            localStorage.setItem('producoes', JSON.stringify(producoes)); // Atualiza o localStorage
            this.carregarProducoes(); // Recarrega a lista de produções
        }
    }
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    const productionManager = new ProductionManager(); // Instancia o gerenciador de produções
    new NavigationButton('#backButton', 'inicial.html'); // Cria o botão de navegação para voltar à página inicial

    // Adiciona evento ao botão de nova produção, se ele existir
    const newProductionButton = document.querySelector('.new-production-btn');
    if (newProductionButton) {
        newProductionButton.addEventListener('click', () => {
            window.location.href = 'NovaProducao.html'; // Redireciona para a página de nova produção
        });
    }
});
