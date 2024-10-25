// Classe para manipular o formulário de login
class LoginForm {
    constructor(formSelector, submitCallback, forgotPasswordCallback) {
        // Seleciona o formulário com o seletor fornecido e atribui as funções de callback
        this.form = document.querySelector(formSelector);
        this.submitCallback = submitCallback;
        this.forgotPasswordCallback = forgotPasswordCallback;
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    // Inicializa os eventos de submissão do formulário e clique no link de "Esqueci minha senha"
    initEventListeners() {
        // Evento de submissão do formulário que chama o callback de login
        this.form.addEventListener('submit', (event) => this.submitCallback(event));

        // Adiciona evento ao link de "Esqueci minha senha"
        const forgotPasswordLink = document.getElementById('forgot-password-link');
        forgotPasswordLink.addEventListener('click', (event) => this.forgotPasswordCallback(event));
    }

    // Coleta as credenciais inseridas no formulário de login
    getCredentials() {
        const userId = this.form.querySelector('input[name="id"]').value; // Pega o valor do campo ID
        const password = this.form.querySelector('input[name="senha"]').value; // Pega o valor do campo senha
        return { userId, password }; // Retorna um objeto com ID e senha
    }
}

// Classe responsável pela validação das credenciais
class CredentialsValidator {
    constructor(validCredentials) {
        // Inicializa as credenciais válidas predefinidas
        this.validCredentials = validCredentials;
    }

    // Valida as credenciais inseridas comparando com as predefinidas ou armazenadas
    validate(userId, password) {
        // Verifica se as credenciais inseridas correspondem às credenciais fixas
        const validCredential = this.validCredentials.find(credentials => 
            credentials.id === userId && credentials.password === password
        );

        if (validCredential) {
            return validCredential; // Retorna credenciais válidas se encontradas
        }

        // Se não encontrar, verifica se há credenciais no localStorage
        const storedCredentials = JSON.parse(localStorage.getItem('funcionarios')) || [];
        return storedCredentials.find(funcionario => 
            funcionario.idFuncionario === userId && funcionario.senha === password
        );
    }
}

// Classe responsável por gerenciar a navegação
class NavigationManager {
    // Redireciona para a página desejada após login bem-sucedido
    redirectToPage(page) {
        alert("Login realizado com sucesso!"); // Exibe uma mensagem de sucesso
        window.location.href = page; // Redireciona para a página passada como argumento
    }

    // Exibe uma mensagem de erro
    showErrorMessage(message) {
        alert(message); // Mostra um alerta com a mensagem de erro
    }

    // Redireciona para a página de "Esqueci minha senha"
    redirectToForgotPasswordPage() {
        window.location.href = "Senha.html"; // Redireciona para a página de recuperação de senha
    }

    // Solicita o e-mail do usuário para envio de código de verificação
    requestEmail() {
        let email;
        do {
            email = prompt("Digite seu e-mail para receber o código de verificação:");
        } while (!this.isValidEmail(email)); // Continua solicitando até que o e-mail seja válido
        return email; // Retorna o e-mail válido
    }

    // Verifica se o e-mail é válido usando expressão regular
    isValidEmail(email) {
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/; // Expressão regular para validar e-mail
        return emailRegex.test(email); // Retorna true se o e-mail for válido
    }

    // Solicita o código de verificação que foi enviado por e-mail
    requestVerificationCode() {
        const code = prompt("Digite o código de verificação recebido por e-mail:");
        return code; // Retorna o código inserido pelo usuário
    }
}

// Classe principal para orquestrar o sistema de login
class LoginSystem {
    constructor(validCredentials) {
        // Inicializa o validador de credenciais e o gerenciador de navegação
        this.validator = new CredentialsValidator(validCredentials);
        this.navigationManager = new NavigationManager();
        // Inicializa o formulário de login com os callbacks de login e de "Esqueci minha senha"
        this.loginForm = new LoginForm(
            'form',
            (event) => this.handleLogin(event), // Callback para lidar com o login
            (event) => this.handleForgotPassword(event) // Callback para "Esqueci minha senha"
        );
        this.generatedCode = null; // Armazena o código de verificação gerado
    }

    // Manipula o evento de login
    handleLogin(event) {
        event.preventDefault(); // Impede o comportamento padrão de submissão do formulário
        const { userId, password } = this.loginForm.getCredentials(); // Obtém as credenciais inseridas
        const validCredential = this.validator.validate(userId, password); // Valida as credenciais

        if (validCredential) {
            const email = this.navigationManager.requestEmail(); // Solicita o e-mail para verificação
            if (email) {
                // Gera e envia (simulado) um código de verificação por e-mail
                this.generatedCode = this.generateVerificationCode();
                alert(`Código de verificação enviado para ${email}: ${this.generatedCode}`); // Simula envio do código
                this.handleTwoFactorAuthentication(userId, password); // Inicia a autenticação em duas etapas
            }
        } else {
            this.navigationManager.showErrorMessage("ID ou senha incorretos. Tente novamente."); // Exibe mensagem de erro
        }
    }

    // Manipula a autenticação em duas etapas
    handleTwoFactorAuthentication(userId, password) {
        const enteredCode = this.navigationManager.requestVerificationCode(); // Solicita o código de verificação
        if (enteredCode === this.generatedCode) {
            // Redireciona para a página correta baseado nas credenciais
            if (userId === '1234' && password === '1234') {
                this.navigationManager.redirectToPage('inicial.html');
            } else if (userId === '1215' && password === '1215') {
                this.navigationManager.redirectToPage('InicialF.html');
            } else if (userId === '6258' && password === '6258') {
                this.navigationManager.redirectToPage('inicialGerente.html');
            } else {
                // Redireciona para a página de funcionários se for um funcionário cadastrado
                this.navigationManager.redirectToPage('inicialFuncionario.html');
            }
        } else {
            this.navigationManager.showErrorMessage("Código de verificação inválido."); // Exibe erro se o código estiver incorreto
        }
    }

    // Gera um código de verificação aleatório de 6 dígitos
    generateVerificationCode() {
        return Math.floor(100000 + Math.random() * 900000).toString(); // Retorna um número aleatório de 6 dígitos
    }

    // Manipula o evento de "Esqueci minha senha"
    handleForgotPassword(event) {
        event.preventDefault(); // Impede o comportamento padrão
        this.navigationManager.redirectToForgotPasswordPage(); // Redireciona para a página de recuperação de senha
    }
}

// Inicializa o sistema de login após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Credenciais fixas para fins de exemplo
    const validCredentials = [
        { id: '1234', password: '1234' },   // Credenciais para inicial.html
        { id: '1215', password: '1215' },   // Credenciais para InicialFuncionario.html
        { id: '6258', password: '6258' }    // Credenciais para inicialGerente.html
    ];

    // Inicializa o sistema de login com as credenciais predefinidas
    new LoginSystem(validCredentials);
});
