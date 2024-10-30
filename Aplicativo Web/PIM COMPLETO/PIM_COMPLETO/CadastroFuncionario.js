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

// Função para coletar os dados e adicionar o funcionário
function adicionarFuncionario() {
    const nome = document.getElementById('nome').value;
    const idFuncionario = document.getElementById('id_funcionario').value;
    const email = document.getElementById('email').value;
    const senha = document.getElementById('senha').value;

    if (!nome || !idFuncionario || !email || !senha) {
        alert('Por favor, preencha todos os campos obrigatórios.');
        return;
    }

    let funcionarios = JSON.parse(localStorage.getItem('funcionarios')) || [];

    // Verifica se o ID do funcionário já existe
    const idExistente = funcionarios.some(funcionario => funcionario.idFuncionario === idFuncionario);
    if (idExistente) {
        alert('ID do funcionário já cadastrado. Por favor, insira um ID único.');
        return;
    }

    const funcionario = {
        nome,
        idFuncionario,
        email,
        senha
    };

    funcionarios.push(funcionario);
    localStorage.setItem('funcionarios', JSON.stringify(funcionarios));

    let credenciais = JSON.parse(localStorage.getItem('credenciais')) || [];
    credenciais.push({ id: idFuncionario, password: senha });
    localStorage.setItem('credenciais', JSON.stringify(credenciais));

    alert('Funcionário cadastrado com sucesso!');
    window.location.href = 'DadosFuncionarios.html';
}

document.addEventListener('DOMContentLoaded', () => {
    new NavigationButton('.back-button', 'DadosFuncionarios.html');
    new NavigationButton('#homeButton', 'inicial.html');

    const saveButton = document.querySelector('.save-button');
    if (saveButton) {
        saveButton.addEventListener('click', (event) => {
            event.preventDefault();
            adicionarFuncionario();
        });
    }
});
