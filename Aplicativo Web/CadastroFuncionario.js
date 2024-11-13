// Classe para gerenciar os botões de navegação
class NavigationButton {
    constructor(buttonSelector, targetUrl) {
        this.button = document.querySelector(buttonSelector); // Seleciona o botão usando o seletor fornecido
        this.targetUrl = targetUrl; // Armazena a URL de destino
        this.initEventListeners(); // Chama a função para inicializar os ouvintes de eventos
    }

    initEventListeners() {
        if (this.button) { // Verifica se o botão foi encontrado
            this.button.addEventListener('click', () => this.redirecionar()); // Adiciona um evento de clique que chama o método redirecionar
        }
    }

    redirecionar() {
        window.location.href = this.targetUrl; // Redireciona para a URL de destino
    }
}

// Classe para gerenciar os funcionários
class EmployeeManager {
    constructor() {
        this.funcionarios = JSON.parse(localStorage.getItem('funcionarios')) || []; // Obtém a lista de funcionários do localStorage
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    initEventListeners() {
        const saveButton = document.querySelector('.save-button'); // Seleciona o botão de salvar
        if (saveButton) { // Verifica se o botão de salvar foi encontrado
            saveButton.addEventListener('click', (event) => {
                event.preventDefault(); // Prevê o comportamento padrão do botão
                this.adicionarFuncionario(); // Chama o método para adicionar o funcionário
            });
        }
    }

    adicionarFuncionario() {
        const nome = document.getElementById('nome').value; // Obtém o valor do campo nome
        const idFuncionario = document.getElementById('id_funcionario').value; // Obtém o valor do campo ID do funcionário
        const email = document.getElementById('email').value; // Obtém o valor do campo email
        const senha = document.getElementById('senha').value; // Obtém o valor do campo senha

        // Verifica se todos os campos obrigatórios estão preenchidos
        if (!nome || !idFuncionario || !email || !senha) {
            alert('Por favor, preencha todos os campos obrigatórios.'); // Exibe um alerta se algum campo estiver vazio
            return; // Interrompe a execução da função
        }

        // Verifica se o ID do funcionário já existe
        const idExistente = this.funcionarios.some(funcionario => funcionario.idFuncionario === idFuncionario);
        if (idExistente) {
            alert('ID do funcionário já cadastrado. Por favor, insira um ID único.'); // Alerta caso o ID já exista
            return; // Interrompe a execução da função
        }

        // Cria um novo objeto funcionário com os dados coletados
        const funcionario = {
            nome,
            idFuncionario,
            email,
            senha
        };

        this.funcionarios.push(funcionario); // Adiciona o novo funcionário à lista
        localStorage.setItem('funcionarios', JSON.stringify(this.funcionarios)); // Salva a lista atualizada no localStorage

        // Obtém as credenciais do localStorage ou inicializa um array vazio se não houver
        let credenciais = JSON.parse(localStorage.getItem('credenciais')) || [];
        credenciais.push({ id: idFuncionario, password: senha }); // Adiciona as credenciais do novo funcionário
        localStorage.setItem('credenciais', JSON.stringify(credenciais)); // Salva as credenciais atualizadas no localStorage

        alert('Funcionário cadastrado com sucesso!'); // Exibe um alerta de sucesso
        window.location.href = 'DadosFuncionarios.html'; // Redireciona para a página de dados dos funcionários
    }
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    new NavigationButton('.back-button', 'DadosFuncionarios.html'); // Cria um novo botão de navegação para voltar à página de dados dos funcionários
    new NavigationButton('#homeButton', 'inicial.html'); // Cria um novo botão de navegação para voltar à página inicial
    new EmployeeManager(); // Cria uma instância do gerenciador de funcionários
});
