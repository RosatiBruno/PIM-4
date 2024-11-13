// Classe para gerenciar os botões de navegação
class NavigationButton {
    // Construtor que inicializa o botão e a URL de destino
    constructor(buttonSelector, targetUrl) {
        this.button = document.querySelector(buttonSelector); // Seleciona o botão com base no seletor fornecido
        this.targetUrl = targetUrl; // Armazena a URL de destino
        this.initEventListeners(); // Chama o método para adicionar ouvintes de eventos
    }

    // Método para inicializar os ouvintes de eventos
    initEventListeners() {
        if (this.button) { // Verifica se o botão foi encontrado
            // Adiciona um ouvinte de evento de clique ao botão
            this.button.addEventListener('click', () => this.redirecionar()); // Redireciona ao clicar no botão
        }
    }

    // Método que redireciona para a URL de destino
    redirecionar() {
        window.location.href = this.targetUrl; // Muda a localização da janela para a URL de destino
    }
}

// Classe para gerenciar produções
class ProducaoManager {
    // Construtor que inicializa o gerenciador de produções
    constructor() {
        this.init(); // Chama o método de inicialização
    }

    // Método de inicialização
    init() {
        const submitButton = document.querySelector('.submit-button'); // Seleciona o botão de submissão
        if (submitButton) { // Verifica se o botão de submissão foi encontrado
            // Adiciona um ouvinte de evento de clique ao botão
            submitButton.addEventListener('click', (event) => {
                event.preventDefault(); // Prevê o comportamento padrão do formulário (não recarrega a página)
                this.adicionarProducao(); // Chama o método para adicionar produção
            });
        }
    }

    // Método para adicionar uma nova produção
    adicionarProducao() {
        // Obtém os valores dos campos de entrada pelo seu ID
        const idProducao = document.getElementById('idProducao').value; 
        const dataProducao = document.getElementById('dataProducao').value; 
        const quantidade = document.getElementById('quantidade').value; 
        const produto = document.getElementById('produto').value; 
        const responsavel = document.getElementById('responsavel').value; 

        // Verifica se todos os campos obrigatórios foram preenchidos
        if (!idProducao || !dataProducao || !quantidade || !produto || !responsavel) {
            alert('Por favor, preencha todos os campos obrigatórios.'); // Exibe alerta se algum campo estiver vazio
            return; // Sai do método se a validação falhar
        }

        // Recupera as produções existentes do localStorage ou inicializa um array vazio
        let producoes = JSON.parse(localStorage.getItem('producoes')) || []; 

        // Verifica se o ID da produção já existe na lista de produções
        const idExistente = producoes.some(producao => producao.idProducao === idProducao);
        if (idExistente) {
            alert('ID da produção já cadastrado. Por favor, insira um ID único.'); // Exibe alerta se o ID já existir
            return; // Sai do método se o ID for duplicado
        }

        // Cria um objeto com os dados da nova produção
        const producao = {
            idProducao,
            dataProducao,
            quantidade,
            produto,
            responsavel
        };

        producoes.push(producao); // Adiciona a nova produção ao array
        localStorage.setItem('producoes', JSON.stringify(producoes)); // Armazena o array atualizado no localStorage
        alert('Produção cadastrada com sucesso!'); // Exibe um alerta de sucesso
        window.location.href = 'ProducaoF.html'; // Redireciona para a página de produções
    }
}

// Inicializa a aplicação quando o DOM estiver carregado
document.addEventListener('DOMContentLoaded', () => {
    new NavigationButton('.back-button-container', 'ProducaoF.html'); // Cria um botão de navegação para voltar
    new NavigationButton('.home-icon', 'inicialF.html'); // Cria um botão de navegação para ir para a página inicial
    new ProducaoManager();  // Inicializa o gerenciador de produções
});
