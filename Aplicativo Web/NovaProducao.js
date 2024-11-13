// Classe para gerenciar os botões de navegação
class NavigationButton {
    // Construtor que recebe o seletor do botão e a URL de destino
    constructor(buttonSelector, targetUrl) {
        this.button = document.querySelector(buttonSelector); // Seleciona o botão na página usando o seletor fornecido
        this.targetUrl = targetUrl; // Define a URL de destino para onde o botão deve redirecionar
        this.initEventListeners(); // Chama o método para inicializar o evento de clique no botão
    }

    // Método para inicializar o evento de clique
    initEventListeners() {
        if (this.button) { // Verifica se o botão existe
            // Adiciona um evento de clique no botão que chama o método de redirecionamento
            this.button.addEventListener('click', () => this.redirecionar());
        }
    }

    // Método para redirecionar o usuário para a URL de destino
    redirecionar() {
        window.location.href = this.targetUrl; // Redireciona o usuário para a URL especificada
    }
}

// Classe para gerenciar as produções
class ProducaoManager {
    // Construtor que inicializa o gerenciador de produções
    constructor() {
        this.init(); // Chama o método de inicialização
    }

    // Método de inicialização para configurar o evento de envio de produção
    init() {
        // Seleciona o botão de envio de produção na página
        const submitButton = document.querySelector('.submit-button');
        if (submitButton) { // Verifica se o botão existe
            // Adiciona um evento de clique no botão de envio, prevenindo o comportamento padrão e chamando o método para adicionar produção
            submitButton.addEventListener('click', (event) => {
                event.preventDefault();
                this.adicionarProducao();
            });
        }
    }

    // Método para adicionar uma nova produção
    adicionarProducao() {
        // Coleta os valores dos campos de entrada da página
        const idProducao = document.getElementById('idProducao').value;
        const dataProducao = document.getElementById('dataProducao').value;
        const quantidade = document.getElementById('quantidade').value;
        const produto = document.getElementById('produto').value;
        const responsavel = document.getElementById('responsavel').value;

        // Verifica se todos os campos obrigatórios estão preenchidos
        if (!idProducao || !dataProducao || !quantidade || !produto || !responsavel) {
            alert('Por favor, preencha todos os campos obrigatórios.'); // Exibe um alerta caso algum campo esteja vazio
            return; // Interrompe a execução do método se algum campo estiver vazio
        }

        // Carrega a lista de produções armazenadas no localStorage, ou inicializa uma lista vazia
        let producoes = JSON.parse(localStorage.getItem('producoes')) || [];

        // Verifica se o ID da produção já existe na lista de produções
        const idExistente = producoes.some(producao => producao.idProducao === idProducao);
        if (idExistente) {
            alert('ID da produção já cadastrado. Por favor, insira um ID único.'); // Alerta caso o ID já exista
            return; // Interrompe a execução do método se o ID já estiver cadastrado
        }

        // Cria um objeto de produção com os dados fornecidos
        const producao = {
            idProducao,
            dataProducao,
            quantidade,
            produto,
            responsavel
        };

        // Adiciona a nova produção à lista de produções
        producoes.push(producao);
        // Armazena a lista atualizada de produções no localStorage
        localStorage.setItem('producoes', JSON.stringify(producoes));
        alert('Produção cadastrada com sucesso!'); // Exibe um alerta de sucesso
        window.location.href = 'Producao.html'; // Redireciona para a página de produção
    }
}

// Inicializa a aplicação quando o DOM estiver completamente carregado
document.addEventListener('DOMContentLoaded', () => {
    // Cria uma instância de NavigationButton para o botão de voltar, configurando o redirecionamento para 'Producao.html'
    new NavigationButton('.back-button-container', 'Producao.html');
    // Cria uma instância de NavigationButton para o ícone de home, configurando o redirecionamento para 'inicial.html'
    new NavigationButton('.home-icon', 'inicial.html');
    // Cria uma instância de ProducaoManager para gerenciar o cadastro de novas produções
    new ProducaoManager();
});
