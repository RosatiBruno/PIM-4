// Classe para manipular o formulário de login
class LoginForm {
    // Construtor da classe LoginForm que recebe o seletor do formulário e os callbacks de submissão e esquecimento de senha
    constructor(formSelector, submitCallback, forgotPasswordCallback) {
        // Seleciona o formulário no DOM usando o seletor fornecido
        this.form = document.querySelector(formSelector);
        // Atribui o callback de submissão ao objeto
        this.submitCallback = submitCallback;
        // Atribui o callback de esquecimento de senha ao objeto
        this.forgotPasswordCallback = forgotPasswordCallback;
        // Inicializa os ouvintes de eventos no formulário
        this.initEventListeners();
    }

    // Método para configurar os ouvintes de eventos
    initEventListeners() {
        // Adiciona um ouvinte para o evento de submissão do formulário
        this.form.addEventListener('submit', (event) => this.submitCallback(event));
        // Seleciona o link de esquecimento de senha no DOM
        const forgotPasswordLink = document.getElementById('forgot-password-link');
        // Adiciona um ouvinte para o clique no link de esquecimento de senha
        forgotPasswordLink.addEventListener('click', (event) => this.forgotPasswordCallback(event));
    }

    // Método para obter as credenciais (ID e senha) inseridas no formulário
    getCredentials() {
        // Seleciona o valor do campo de entrada de ID
        const userId = this.form.querySelector('input[name="id"]').value;
        // Seleciona o valor do campo de entrada de senha
        const password = this.form.querySelector('input[name="senha"]').value;
        // Retorna as credenciais como um objeto
        return { userId, password };
    }
}

// Classe responsável pela validação das credenciais
class CredentialsValidator {
    // Construtor que recebe uma lista de credenciais válidas
    constructor(validCredentials) {
        // Armazena as credenciais válidas
        this.validCredentials = validCredentials;
    }

    // Método para validar o ID e senha fornecidos
    validate(userId, password) {
        // Procura nas credenciais válidas uma combinação de ID e senha correspondentes
        const validCredential = this.validCredentials.find(credentials =>
            credentials.id === userId && credentials.password === password
        );

        // Se encontrou uma credencial válida, retorna-a
        if (validCredential) {
            return validCredential;
        }

        // Se não encontrou, verifica se há credenciais salvas localmente no localStorage
        const storedCredentials = JSON.parse(localStorage.getItem('funcionarios')) || [];
        // Procura a combinação de ID e senha nas credenciais armazenadas
        return storedCredentials.find(funcionario =>
            funcionario.idFuncionario === userId && funcionario.senha === password
        );
    }
}

// Classe responsável por gerenciar a navegação e interações de mensagens
class NavigationManager {
    // Método para redirecionar para uma página específica
    redirectToPage(page) {
        // Exibe uma mensagem de sucesso
        alert("Login realizado com sucesso!");
        // Redireciona para a página especificada
        window.location.href = page;
    }

    // Método para exibir uma mensagem de erro
    showErrorMessage(message) {
        // Exibe uma mensagem de alerta com o erro
        alert(message);
    }

    // Método para redirecionar para a página de recuperação de senha
    redirectToForgotPasswordPage() {
        // Redireciona para a página de recuperação de senha
        window.location.href = "Senha.html";
    }

    // Método para solicitar o e-mail do usuário para verificação
    requestEmail() {
        let email;
        // Solicita o e-mail até que o usuário forneça um e-mail válido
        do {
            email = prompt("Digite seu e-mail para receber o código de verificação:");
        } while (!this.isValidEmail(email)); // Valida o e-mail com o método isValidEmail
        // Retorna o e-mail fornecido
        return email;
    }

    // Método para validar o formato do e-mail
    isValidEmail(email) {
        // Expressão regular para verificar o formato de um e-mail válido
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        // Retorna true se o e-mail for válido, false caso contrário
        return emailRegex.test(email);
    }

    // Método para solicitar o código de verificação ao usuário
    requestVerificationCode() {
        // Solicita o código ao usuário
        const code = prompt("Digite o código de verificação recebido por e-mail:");
        // Retorna o código fornecido
        return code;
    }
}

// Classe principal que orquestra o sistema de login
class LoginSystem {
    // Construtor que inicializa as classes e recebe as credenciais válidas
    constructor(validCredentials) {
        // Inicializa o validador de credenciais com as credenciais válidas
        this.validator = new CredentialsValidator(validCredentials);
        // Inicializa o gerenciador de navegação
        this.navigationManager = new NavigationManager();
        // Inicializa o formulário de login com os callbacks para login e esquecimento de senha
        this.loginForm = new LoginForm(
            'form',
            (event) => this.handleLogin(event),
            (event) => this.handleForgotPassword(event)
        );
        // Inicializa o código de verificação gerado como null
        this.generatedCode = null;
    }

    // Método para tratar o evento de login
    handleLogin(event) {
        // Previne o comportamento padrão do formulário
        event.preventDefault();
        // Obtém as credenciais fornecidas pelo usuário
        const { userId, password } = this.loginForm.getCredentials();
        // Valida as credenciais
        const validCredential = this.validator.validate(userId, password);

        // Se as credenciais são válidas
        if (validCredential) {
            // Solicita o e-mail do usuário
            const email = this.navigationManager.requestEmail();
            // Se o e-mail foi fornecido e é válido
            if (email) {
                // Gera um código de verificação e armazena em generatedCode
                this.generatedCode = this.generateVerificationCode();
                // Exibe uma mensagem com o código gerado
                alert(`Código de verificação enviado para ${email}: ${this.generatedCode}`);
                // Inicia o processo de autenticação em duas etapas
                this.handleTwoFactorAuthentication(userId, password);
            }
        } else {
            // Se as credenciais são inválidas, exibe uma mensagem de erro
            this.navigationManager.showErrorMessage("ID ou senha incorretos. Tente novamente.");
        }
    }

    // Método para realizar a autenticação em duas etapas
    handleTwoFactorAuthentication(userId, password) {
        // Solicita ao usuário o código de verificação
        const enteredCode = this.navigationManager.requestVerificationCode();
        // Se o código inserido é igual ao gerado
        if (enteredCode === this.generatedCode) {
            // Redireciona o usuário para a página correspondente ao ID e senha fornecidos
            if (userId === '1234' && password === '1234') {
                this.navigationManager.redirectToPage('inicial.html');
            } else if (userId === '1215' && password === '1215') {
                this.navigationManager.redirectToPage('InicialF.html');
            } else if (userId === '6258' && password === '6258') {
                this.navigationManager.redirectToPage('inicialGerente.html');
            } else {
                this.navigationManager.redirectToPage('inicialF.html');
            }
        } else {
            // Se o código de verificação está incorreto, exibe uma mensagem de erro
            this.navigationManager.showErrorMessage("Código de verificação inválido.");
        }
    }

    // Método para gerar um código de verificação de 6 dígitos
    generateVerificationCode() {
        // Retorna um número aleatório de 6 dígitos como string
        return Math.floor(100000 + Math.random() * 900000).toString();
    }

    // Método para tratar o evento de esquecimento de senha
    handleForgotPassword(event) {
        // Previne o comportamento padrão do link
        event.preventDefault();
        // Redireciona para a página de recuperação de senha
        this.navigationManager.redirectToForgotPasswordPage();
    }
}

// Inicializa o sistema de login após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Define as credenciais válidas para comparação
    const validCredentials = [
        { id: '1234', password: '1234' },
        { id: '1215', password: '1215' },
        { id: '6258', password: '6258' }
    ];

    // Cria uma nova instância do sistema de login com as credenciais válidas
    new LoginSystem(validCredentials);
});
