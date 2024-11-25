// Classe para gerenciar os botões de navegação
class NavigationButton {
    constructor(buttonSelector, targetUrl) { 
        this.button = document.querySelector(buttonSelector); // Seleciona o botão na página usando o seletor fornecido.
        this.targetUrl = targetUrl; // Define a URL para onde o botão deve redirecionar.
        this.initEventListeners(); // Inicializa os ouvintes de eventos.
    }

    initEventListeners() { 
        if (this.button) { // Verifica se o botão existe.
            this.button.addEventListener('click', () => this.redirecionar()); // Adiciona um evento de clique que chama o método redirecionar.
        }
    }

    redirecionar() { 
        window.location.href = this.targetUrl; // Redireciona para a URL especificada.
    }
}

// Classe para gerenciar produções
class ProductionManager {
    constructor() {
        this.listaProducoes = document.querySelector('.production-list'); // Seleciona o contêiner da lista de produções.
        this.carregarProducoes(); // Carrega as produções do armazenamento local e exibe na página.
    }

    carregarProducoes() {
        let producoes = JSON.parse(localStorage.getItem('producoes')) || []; // Recupera produções do localStorage ou inicializa com uma lista vazia.
        this.listaProducoes.innerHTML = ''; // Limpa a lista de produções.

        producoes.forEach((producao, index) => { 
            const div = document.createElement('div'); // Cria um novo elemento div para cada produção.
            div.classList.add('production-item'); // Adiciona a classe de estilo 'production-item'.
            div.setAttribute('data-id', index); // Define um atributo data-id com o índice da produção.
            div.innerHTML = `
                <span>PRODUÇÃO ${index + 1}: ${producao.nomeProduto || ''}</span> 
            `; // Define o conteúdo HTML da div, exibindo o nome da produção.
            this.listaProducoes.appendChild(div); // Adiciona a div à lista de produções.

            div.addEventListener('click', () => this.exibirDetalhesProducao(index)); // Adiciona um evento de clique para exibir detalhes da produção.
        });

        const deleteButtons = this.listaProducoes.querySelectorAll('.delete-production-btn'); // Seleciona todos os botões de exclusão.
        deleteButtons.forEach(button => {
            button.addEventListener('click', (event) => {
                event.stopPropagation(); // Impede o evento de clique de se propagar para o item da produção.
                const producaoId = event.target.getAttribute('data-id'); // Obtém o ID da produção.
                this.excluirProducao(producaoId); // Chama o método para excluir a produção.
            });
        });
    }

    exibirDetalhesProducao(index) { 
        const modal = document.getElementById('productionModal'); // Seleciona o modal para exibir os detalhes da produção.
        const closeModal = document.getElementById('closeModal'); // Seleciona o botão de fechar do modal.
        const productionDetails = document.getElementById('production-details'); // Seleciona o contêiner dos detalhes da produção.

        let producoes = JSON.parse(localStorage.getItem('producoes')) || []; // Recupera a lista de produções.
        const producao = producoes[index]; // Seleciona a produção correspondente ao índice.

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
        `; // Exibe os detalhes da produção nos campos de edição.

        modal.style.display = 'block'; // Exibe o modal na tela.

        closeModal.onclick = () => {
            modal.style.display = 'none'; // Fecha o modal ao clicar no botão de fechar.
        };

        window.onclick = (event) => {
            if (event.target === modal) { // Verifica se o clique foi fora do modal.
                modal.style.display = 'none'; // Fecha o modal se o clique for fora dele.
            }
        };

        document.getElementById('saveProduction').onclick = () => { 
            this.salvarAlteracoes(index); // Salva as alterações feitas na produção.
        };
    }
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    const productionManager = new ProductionManager(); // Instancia a classe ProductionManager para gerenciar produções.
    new NavigationButton('#backButton', 'inicialF.html'); // Cria um botão de navegação para redirecionar para 'inicialF.html'.

    const newProductionButton = document.querySelector('.new-production-btn'); // Seleciona o botão para nova produção.
    if (newProductionButton) {
        newProductionButton.addEventListener('click', () => { 
            window.location.href = 'NovoProducaoF.html'; // Redireciona para a página de cadastro de nova produção.
        });
    }
});
