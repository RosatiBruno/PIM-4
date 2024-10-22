// Classe para gerenciar o botão de voltar
class BackButton {
    constructor(buttonSelector, targetUrl) {
        // Seleciona o botão usando o seletor fornecido
        this.backButton = document.querySelector(buttonSelector);
        // Armazena a URL de destino para a redirecionamento
        this.targetUrl = targetUrl;
        // Inicializa os ouvintes de eventos
        this.initEventListeners();
    }

    initEventListeners() {
        // Adiciona um ouvinte de evento de clique ao botão de voltar
        this.backButton.addEventListener('click', () => this.redirecionar());
    }

    redirecionar() {
        // Redireciona para a URL de destino quando o botão é clicado
        window.location.href = this.targetUrl;
    }
}

// Classe para gerenciar o botão "Home"
class HomeButton {
    constructor(buttonSelector, targetUrl) {
        // Seleciona o botão de home pelo ID fornecido
        this.homeButton = document.getElementById(buttonSelector);
        // Armazena a URL de destino para o redirecionamento
        this.targetUrl = targetUrl;
        // Inicializa os ouvintes de eventos
        this.initEventListeners();
    }

    initEventListeners() {
        // Verifica se o botão de home existe antes de adicionar o ouvinte de evento
        if (this.homeButton) {
            // Adiciona um ouvinte de evento de clique ao botão de home
            this.homeButton.addEventListener('click', () => this.redirecionar());
        }
    }

    redirecionar() {
        // Redireciona para a URL de destino quando o botão é clicado
        window.location.href = this.targetUrl;
    }
}

// Função para adicionar fornecedor ao localStorage
function cadastrarFornecedor(fornecedor) {
    // Obtém a lista de fornecedores do localStorage ou inicializa uma nova lista se não existir
    const fornecedores = JSON.parse(localStorage.getItem('fornecedores')) || [];
    // Adiciona o novo fornecedor à lista
    fornecedores.push(fornecedor);
    // Salva a lista atualizada de fornecedores no localStorage
    localStorage.setItem('fornecedores', JSON.stringify(fornecedores));
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Seleciona o botão de submissão do formulário
    const submitButton = document.querySelector('.submit-button');

    // Cria um objeto para armazenar os elementos do formulário
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
        
        // Coletar os dados do formulário e cria um objeto fornecedor
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
        window.location.href = 'Fornecedores.html';
    });

    // Gerenciar o botão de voltar, que redireciona para a página de fornecedores
    new BackButton('.back-button', 'Fornecedores.html');

    // Gerenciar o botão de home, que redireciona para a página inicial
    new HomeButton('homeButton', 'inicial.html');
});
