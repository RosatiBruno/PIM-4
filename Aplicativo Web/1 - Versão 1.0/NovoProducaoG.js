// Classe para gerenciar os botões de navegação
class NavigationButton {
    constructor(buttonSelector, targetUrl) {
        this.button = document.querySelector(buttonSelector); // Seleciona o botão usando o seletor fornecido
        this.targetUrl = targetUrl; // Armazena a URL de destino para onde o botão deve redirecionar
        this.initEventListeners(); // Chama a função para inicializar os ouvintes de eventos no botão
    }

    initEventListeners() {
        if (this.button) { // Verifica se o botão foi encontrado no DOM
            this.button.addEventListener('click', () => this.redirecionar()); // Adiciona um evento de clique que chama o método redirecionar
        }
    }

    redirecionar() {
        window.location.href = this.targetUrl; // Redireciona o usuário para a URL de destino ao clicar no botão
    }
}

// Classe para gerenciar a produção
class ProducaoManager {
    constructor() {
        this.init(); // Inicializa a aplicação chamando o método init
    }

    init() {
        // Adiciona ouvintes de eventos ao carregar o DOM
        document.addEventListener('DOMContentLoaded', () => {
            new NavigationButton('.back-button-container', 'ProducaoG.html'); // Cria um botão de navegação para voltar à página de produções
            new NavigationButton('.home-icon', 'inicialGerente.html'); // Cria um botão de navegação para a página inicial do gerente

            const submitButton = document.querySelector('.submit-button'); // Seleciona o botão de envio do formulário
            if (submitButton) { // Verifica se o botão de enviar foi encontrado
                submitButton.addEventListener('click', (event) => {
                    event.preventDefault(); // Impede o comportamento padrão do envio do formulário
                    this.adicionarProducao(); // Chama a função para adicionar a nova produção
                });
            }
        });
    }

    adicionarProducao() {
        // Coleta os valores dos campos do formulário
        const idProducao = document.getElementById('idProducao').value;
        const dataProducao = document.getElementById('dataProducao').value;
        const quantidade = document.getElementById('quantidade').value;
        const produto = document.getElementById('produto').value;
        const responsavel = document.getElementById('responsavel').value;

        // Verifica se todos os campos obrigatórios foram preenchidos
        if (!idProducao || !dataProducao || !quantidade || !produto || !responsavel) {
            alert('Por favor, preencha todos os campos obrigatórios.'); // Exibe um alerta se algum campo estiver vazio
            return; // Interrompe a execução da função se algum campo não foi preenchido
        }

        // Obtém a lista de produções do localStorage ou inicializa um array vazio se não houver produções salvas
        let producoes = JSON.parse(localStorage.getItem('producoes')) || [];

        // Verifica se o ID da produção já existe na lista de produções
        const idExistente = producoes.some(producao => producao.idProducao === idProducao);
        if (idExistente) {
            alert('ID da produção já cadastrado. Por favor, insira um ID único.'); // Exibe um alerta caso o ID já exista
            return; // Interrompe a execução da função
        }

        // Cria um novo objeto produção com os dados coletados do formulário
        const producao = {
            idProducao,
            dataProducao,
            quantidade,
            produto,
            responsavel
        };

        producoes.push(producao); // Adiciona a nova produção à lista de produções
        localStorage.setItem('producoes', JSON.stringify(producoes)); // Salva a lista atualizada de produções no localStorage

        alert('Produção cadastrada com sucesso!'); // Exibe um alerta de sucesso informando que a produção foi cadastrada
        window.location.href = 'ProducaoG.html'; // Redireciona o usuário para a página de produções
    }
}

// Inicializa o gerenciador de produção quando o script é carregado
new ProducaoManager(); // Cria uma nova instância de ProducaoManager, iniciando o sistema de gerenciamento de produções
