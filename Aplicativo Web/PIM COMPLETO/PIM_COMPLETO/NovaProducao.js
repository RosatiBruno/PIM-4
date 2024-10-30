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

// Função para coletar os dados do formulário e adicionar uma nova produção
function adicionarProducao() {
    const idProducao = document.getElementById('idProducao').value;
    const dataProducao = document.getElementById('dataProducao').value;
    const quantidade = document.getElementById('quantidade').value;
    const produto = document.getElementById('produto').value;
    const responsavel = document.getElementById('responsavel').value;

    if (!idProducao || !dataProducao || !quantidade || !produto || !responsavel) {
        alert('Por favor, preencha todos os campos obrigatórios.');
        return;
    }

    let producoes = JSON.parse(localStorage.getItem('producoes')) || [];

    // Verifica se o ID da produção já existe na lista de produções
    const idExistente = producoes.some(producao => producao.idProducao === idProducao);
    if (idExistente) {
        alert('ID da produção já cadastrado. Por favor, insira um ID único.');
        return;
    }

    const producao = {
        idProducao,
        dataProducao,
        quantidade,
        produto,
        responsavel
    };

    producoes.push(producao);
    localStorage.setItem('producoes', JSON.stringify(producoes));
    alert('Produção cadastrada com sucesso!');
    window.location.href = 'Producao.html';
}

document.addEventListener('DOMContentLoaded', () => {
    new NavigationButton('.back-button-container', 'Producao.html');
    new NavigationButton('.home-icon', 'inicial.html');

    const submitButton = document.querySelector('.submit-button');
    if (submitButton) {
        submitButton.addEventListener('click', (event) => {
            event.preventDefault();
            adicionarProducao();
        });
    }
});
