// Classe para gerenciar os botões de navegação
class NavigationButton {
    // Construtor da classe que recebe o seletor do botão e a URL de destino
    constructor(buttonSelector, targetUrl) {
        // Seleciona o botão no DOM com base no seletor fornecido
        this.button = document.querySelector(buttonSelector);
        // Define a URL de destino para redirecionamento
        this.targetUrl = targetUrl;
        // Inicializa os ouvintes de eventos
        this.initEventListeners();
    }

    // Método para adicionar ouvintes de eventos aos botões
    initEventListeners() {
        // Verifica se o botão foi encontrado no DOM
        if (this.button) {
            // Adiciona um evento de clique ao botão que chama o método 'redirecionar'
            this.button.addEventListener('click', () => this.redirecionar());
        }
    }

    // Método que realiza o redirecionamento para a URL especificada
    redirecionar() {
        window.location.href = this.targetUrl;
    }
}

// Classe para gerenciar o sistema de cadastro de fornecedores
class FornecedorManager {
    // Construtor da classe para inicializar os elementos do formulário e o botão de envio
    constructor() {
        // Seleciona cada campo do formulário e o associa às propriedades do objeto 'formElements'
        this.formElements = {
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
        // Seleciona o botão de envio do formulário
        this.submitButton = document.querySelector('.submit-button');
        // Inicializa os ouvintes de eventos para o formulário
        this.initEventListeners();
    }

    // Método para adicionar ouvintes de eventos ao botão de envio
    initEventListeners() {
        // Adiciona um evento de clique ao botão de envio que chama o método 'handleSubmit'
        this.submitButton.addEventListener('click', (e) => this.handleSubmit(e));
    }

    // Método que processa o envio do formulário
    handleSubmit(e) {
        // Impede o comportamento padrão de recarregar a página ao enviar o formulário
        e.preventDefault();

        // Verifica se todos os campos do formulário estão preenchidos
        if (!this.allFieldsFilled()) {
            alert('Por favor, preencha todos os campos antes de cadastrar.');
            return;
        }

        // Obtém o valor do campo 'codigo' do formulário
        const codigo = this.formElements.codigo.value;
        // Verifica se o código já existe no armazenamento local
        if (this.codigoFornecedorExistente(codigo)) {
            alert('Este código de fornecedor já existe. Por favor, insira um código diferente.');
            return;
        }

        // Exibe uma caixa de confirmação para o usuário antes de cadastrar
        const confirmCadastro = confirm('Você realmente deseja cadastrar este fornecedor?');
        // Se o usuário cancelar, a função é encerrada
        if (!confirmCadastro) {
            return;
        }

        // Coleta os dados do formulário em um objeto
        const fornecedor = this.collectFormData();
        // Adiciona o novo fornecedor ao armazenamento local
        this.cadastrarFornecedor(fornecedor);
        // Redireciona o usuário para a página 'Fornecedores.html'
        window.location.href = 'FornecedoresG.html';
    }

    // Método que verifica se todos os campos do formulário estão preenchidos
    allFieldsFilled() {
        // Retorna 'true' se todos os campos tiverem um valor (não estiverem vazios)
        return Object.values(this.formElements).every(input => input.value.trim() !== '');
    }

    // Método que verifica se o código do fornecedor já existe no armazenamento local
    codigoFornecedorExistente(codigo) {
        // Carrega a lista de fornecedores do armazenamento local, ou um array vazio se não houver
        const fornecedores = JSON.parse(localStorage.getItem('fornecedores')) || [];
        // Retorna 'true' se o código do fornecedor já existir
        return fornecedores.some(fornecedor => fornecedor.codigo === codigo);
    }

    // Método que coleta os dados do formulário e retorna como um objeto
    collectFormData() {
        return {
            nome: this.formElements.nome.value,
            cep: this.formElements.cep.value,
            telefone: this.formElements.telefone.value,
            cnpj: this.formElements.cnpj.value,
            endereco: this.formElements.endereco.value,
            email: this.formElements.email.value,
            situacao: this.formElements.situacao.value,
            complemento: this.formElements.complemento.value,
            representante: this.formElements.representante.value,
            codigo: this.formElements.codigo.value,
            cidade: this.formElements.cidade.value,
            materiaPrima: this.formElements.materiaPrima.value,
            razaoSocial: this.formElements.razaoSocial.value,
            estado: this.formElements.estado.value
        };
    }

    // Método que adiciona o fornecedor ao armazenamento local
    cadastrarFornecedor(fornecedor) {
        // Carrega a lista de fornecedores do armazenamento local
        const fornecedores = JSON.parse(localStorage.getItem('fornecedores')) || [];
        // Adiciona o novo fornecedor à lista
        fornecedores.push(fornecedor);
        // Salva a lista atualizada de fornecedores no armazenamento local
        localStorage.setItem('fornecedores', JSON.stringify(fornecedores));
    }
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Cria uma instância da classe 'FornecedorManager' para gerenciar o cadastro de fornecedores
    new FornecedorManager();
    // Cria uma instância da classe 'NavigationButton' para o botão de voltar
    new NavigationButton('.back-button', 'FornecedoresG.html');
    // Cria uma instância da classe 'NavigationButton' para o botão "Home"
    new NavigationButton('#homeButton', 'inicialGerente.html');
});
