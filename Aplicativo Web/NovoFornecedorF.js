// Classe para gerenciar os botões de navegação
class NavigationButton {
    // O construtor recebe um seletor de botão e uma URL de destino
    constructor(buttonSelector, targetUrl) {
        this.button = document.querySelector(buttonSelector); // Seleciona o botão baseado no seletor
        this.targetUrl = targetUrl; // Armazena a URL de destino
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    // Método para inicializar os ouvintes de eventos
    initEventListeners() {
        if (this.button) { // Verifica se o botão foi encontrado
            // Adiciona um ouvinte de evento de clique que chama o método redirecionar
            this.button.addEventListener('click', () => this.redirecionar());
        }
    }

    // Método para redirecionar para a URL de destino
    redirecionar() {
        window.location.href = this.targetUrl; // Altera a localização da janela para a URL de destino
    }
}

// Classe para gerenciar o sistema de cadastro de fornecedores
class FornecedorManager {
    // O construtor inicializa os elementos do formulário e o botão de envio
    constructor() {
        // Cria um objeto com referências aos elementos do formulário
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
        this.submitButton = document.querySelector('.submit-button'); // Seleciona o botão de envio
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    // Método para inicializar os ouvintes de eventos
    initEventListeners() {
        // Adiciona um ouvinte de evento de clique que chama o método handleSubmit
        this.submitButton.addEventListener('click', (e) => this.handleSubmit(e));
    }

    // Método para lidar com o envio do formulário
    handleSubmit(e) {
        e.preventDefault(); // Previne o comportamento padrão do formulário

        // Verifica se todos os campos estão preenchidos
        if (!this.allFieldsFilled()) {
            alert('Por favor, preencha todos os campos antes de cadastrar.'); // Exibe um alerta se algum campo estiver vazio
            return; // Sai da função se algum campo estiver vazio
        }

        const codigo = this.formElements.codigo.value; // Obtém o código do fornecedor do formulário
        // Verifica se o código do fornecedor já existe
        if (this.codigoFornecedorExistente(codigo)) {
            alert('Este código de fornecedor já existe. Por favor, insira um código diferente.'); // Alerta se o código já estiver em uso
            return; // Sai da função
        }

        // Solicita confirmação para o cadastro do fornecedor
        const confirmCadastro = confirm('Você realmente deseja cadastrar este fornecedor?');
        if (!confirmCadastro) {
            return; // Sai da função se o usuário não confirmar
        }

        const fornecedor = this.collectFormData(); // Coleta os dados do formulário
        this.cadastrarFornecedor(fornecedor); // Chama o método para cadastrar o fornecedor
        window.location.href = 'FornecedoresF.html'; // Redireciona para a página de fornecedores
    }

    // Método para verificar se todos os campos do formulário estão preenchidos
    allFieldsFilled() {
        // Retorna true se todos os campos estiverem preenchidos, caso contrário retorna false
        return Object.values(this.formElements).every(input => input.value.trim() !== '');
    }

    // Método para verificar se um código de fornecedor já existe
    codigoFornecedorExistente(codigo) {
        const fornecedores = JSON.parse(localStorage.getItem('fornecedores')) || []; // Obtém a lista de fornecedores do localStorage
        // Retorna true se algum fornecedor já tiver o mesmo código, caso contrário retorna false
        return fornecedores.some(fornecedor => fornecedor.codigo === codigo);
    }

    // Método para coletar os dados do formulário e retorná-los como um objeto
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

    // Método para cadastrar um fornecedor no localStorage
    cadastrarFornecedor(fornecedor) {
        const fornecedores = JSON.parse(localStorage.getItem('fornecedores')) || []; // Obtém a lista de fornecedores do localStorage
        fornecedores.push(fornecedor); // Adiciona o novo fornecedor à lista
        localStorage.setItem('fornecedores', JSON.stringify(fornecedores)); // Atualiza o localStorage com a nova lista
    }
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    new FornecedorManager(); // Instancia a classe FornecedorManager para gerenciar o cadastro de fornecedores
    new NavigationButton('.back-button', 'FornecedoresF.html'); // Instancia a classe NavigationButton para o botão de voltar
    new NavigationButton('#homeButton', 'inicialF.html'); // Instancia a classe NavigationButton para o botão "Home"
});
