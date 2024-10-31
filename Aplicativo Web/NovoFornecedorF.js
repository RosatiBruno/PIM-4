// Classe para gerenciar o botão de voltar
class BackButton {
    constructor(buttonSelector, targetUrl) {
        this.backButton = document.querySelector(buttonSelector);
        this.targetUrl = targetUrl;
        this.initEventListeners();
    }

    initEventListeners() {
        this.backButton.addEventListener('click', () => this.redirecionar());
    }

    redirecionar() {
        window.location.href = this.targetUrl;
    }
}

// Classe para gerenciar o botão "Home"
class HomeButton {
    constructor(buttonSelector, targetUrl) {
        this.homeButton = document.getElementById(buttonSelector);
        this.targetUrl = targetUrl;
        this.initEventListeners();
    }

    initEventListeners() {
        if (this.homeButton) {
            this.homeButton.addEventListener('click', () => this.redirecionar());
        }
    }

    redirecionar() {
        window.location.href = this.targetUrl;
    }
}

// Função para adicionar fornecedor ao localStorage
function cadastrarFornecedor(fornecedor) {
    const fornecedores = JSON.parse(localStorage.getItem('fornecedores')) || [];
    fornecedores.push(fornecedor);
    localStorage.setItem('fornecedores', JSON.stringify(fornecedores));
}

// Função para verificar se o código do fornecedor já existe
function codigoFornecedorExistente(codigo) {
    const fornecedores = JSON.parse(localStorage.getItem('fornecedores')) || [];
    return fornecedores.some(fornecedor => fornecedor.codigo === codigo);
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    const submitButton = document.querySelector('.submit-button');

    const formElements = {
        nome: document.getElementById('nome'),
        cep: document.getElementById('cep'),
        telefone: document.getElementById('telefone'),
        cnpj: document.getElementById('cnpj'),
        endereco: document.getElementById('endereco'),
        email: document.getElementById('email'),
        situacao: document.getElementById('situacao'),
        complemento: document.getElementById('complemento'),
        representante: document.getElementById('representante'),
        codigo: document.getElementById('codigo'),
        cidade: document.getElementById('cidade'),
        materiaPrima: document.getElementById('materia-prima'),
        razaoSocial: document.getElementById('razao-social'),
        estado: document.getElementById('estado'),
    };

    // Evento de clique no botão de cadastrar
    submitButton.addEventListener('click', (e) => {
        e.preventDefault(); // Impede o envio do formulário padrão

        // Verifica se todos os campos estão preenchidos
        const allFieldsFilled = Object.values(formElements).every(input => input.value.trim() !== '');

        if (!allFieldsFilled) {
            alert('Por favor, preencha todos os campos antes de cadastrar.');
            return; // Interrompe o cadastro se algum campo estiver vazio
        }

        // Verifica se o código já existe
        const codigo = formElements.codigo.value;
        if (codigoFornecedorExistente(codigo)) {
            alert('Este código de fornecedor já existe. Por favor, insira um código diferente.');
            return; // Interrompe o cadastro se o código já existir
        }

        // Coleta os dados do formulário e cria um objeto fornecedor
        const fornecedor = {
            nome: formElements.nome.value,
            cep: formElements.cep.value,
            telefone: formElements.telefone.value,
            cnpj: formElements.cnpj.value,
            endereco: formElements.endereco.value,
            email: formElements.email.value,
            situacao: formElements.situacao.value,
            complemento: formElements.complemento.value,
            representante: formElements.representante.value,
            codigo: formElements.codigo.value,
            cidade: formElements.cidade.value,
            materiaPrima: formElements.materiaPrima.value,
            razaoSocial: formElements.razaoSocial.value,
            estado: formElements.estado.value
        };

        // Cadastrar fornecedor no localStorage
        cadastrarFornecedor(fornecedor);

        // Redireciona para a página de fornecedores após o cadastro
        window.location.href = 'FornecedoresF.html';
    });

    // Gerenciar o botão de voltar, que redireciona para a página de fornecedores
    new BackButton('.back-button', 'FornecedoresF.html');

    // Gerenciar o botão de home, que redireciona para a página inicial
    new HomeButton('homeButton', 'inicialF.html');
});
