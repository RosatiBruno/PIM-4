// Classe para gerenciar os botões de navegação
class NavigationButton {
    constructor(buttonSelector, targetUrl) {
        this.button = document.querySelector(buttonSelector);
        this.targetUrl = targetUrl;
        this.initEventListeners();
    }

    initEventListeners() {
        if (this.button) {
            this.button.addEventListener('click', () => this.redirecionar());
        }
    }

    redirecionar() {
        window.location.href = this.targetUrl;
    }
}

// Função para carregar as produções cadastradas e exibi-las na lista
function carregarProducoes() {
    const listaProducoes = document.querySelector('.production-list');
    let producoes = JSON.parse(localStorage.getItem('producoes')) || [];

    listaProducoes.innerHTML = '';

    producoes.forEach((producao, index) => {
        const div = document.createElement('div');
        div.classList.add('production-item');
        div.setAttribute('data-id', index);
        div.innerHTML = `
            <span>PRODUÇÃO ${index + 1}: ${producao.nomeProduto || ''}</span>
        `;
        listaProducoes.appendChild(div);

        div.addEventListener('click', () => exibirDetalhesProducao(index));
    });

    const deleteButtons = document.querySelectorAll('.delete-production-btn');
    deleteButtons.forEach(button => {
        button.addEventListener('click', (event) => {
            event.stopPropagation();
            const producaoId = event.target.getAttribute('data-id');
            excluirProducao(producaoId);
        });
    });
}

// Função para exibir os detalhes de uma produção em um modal e permitir edição
function exibirDetalhesProducao(index) {
    const modal = document.getElementById('productionModal');
    const closeModal = document.getElementById('closeModal');
    const productionDetails = document.getElementById('production-details');

    let producoes = JSON.parse(localStorage.getItem('producoes')) || [];
    const producao = producoes[index];

    // Preenche o modal com campos editáveis para os detalhes da produção
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
        <button id="saveProduction">Salvar</button>  <!-- Botão Salvar adicionado -->
    `;

    modal.style.display = 'block';

    closeModal.onclick = function() {
        modal.style.display = 'none';
    }

    window.onclick = function(event) {
        if (event.target == modal) {
            modal.style.display = 'none';
        }
    }

}

// Função para excluir uma produção pelo ID
function excluirProducao(id) {
    if (confirm('Tem certeza que deseja excluir esta produção?')) {
        let producoes = JSON.parse(localStorage.getItem('producoes')) || [];
        producoes.splice(id, 1);
        localStorage.setItem('producoes', JSON.stringify(producoes));
        carregarProducoes();
    }
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    carregarProducoes();
    new NavigationButton('#backButton', 'inicialF.html');

    const newProductionButton = document.querySelector('.new-production-btn');
    if (newProductionButton) {
        newProductionButton.addEventListener('click', () => {
            window.location.href = 'NovoProducaoF.html';
        });
    }
});
