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

// Função para coletar os dados e adicionar o produto
function adicionarProduto() {
    const nomeProduto = document.getElementById('nome-produto').value;
    const idProduto = document.getElementById('id-produto').value;
    const quantidade = document.getElementById('quantidade').value;
    const valor = document.getElementById('valor').value;
    const empresaResponsavel = document.getElementById('empresa-responsavel').value;

    if (!nomeProduto || !idProduto || !quantidade || !valor || !empresaResponsavel) {
        alert('Por favor, preencha todos os campos obrigatórios.');
        return;
    }

    let produtos = JSON.parse(localStorage.getItem('produtos')) || [];

    // Verifica se o ID do produto já existe
    const idExistente = produtos.some(produto => produto.id === idProduto);
    if (idExistente) {
        alert('ID do produto já cadastrado. Por favor, insira um ID único.');
        return;
    }

    const produto = {
        nome: nomeProduto,
        id: idProduto,
        quantidade,
        valor,
        empresaResponsavel
    };

    produtos.push(produto);
    localStorage.setItem('produtos', JSON.stringify(produtos));

    alert('Produto adicionado com sucesso!');
    window.location.href = 'ProdutosF.html';
}

document.addEventListener('DOMContentLoaded', () => {
    new NavigationButton('.back-button', 'ProdutosF.html');
    new NavigationButton('#homeButton', 'inicialF.html');

    const addButton = document.querySelector('.add-button');
    if (addButton) {
        addButton.addEventListener('click', (event) => {
            event.preventDefault();
            adicionarProduto();
        });
    }
});
