// Classe para gerenciar os botões de navegação
class NavigationButton {
    // Construtor da classe que recebe um seletor de botão e uma URL de destino
    constructor(buttonSelector, targetUrl) {
        this.button = document.querySelector(buttonSelector); // Seleciona o botão usando o seletor fornecido
        this.targetUrl = targetUrl; // Armazena a URL de destino
        this.initEventListeners(); // Inicializa os ouvintes de eventos para o botão
    }

    // Método para inicializar os ouvintes de eventos
    initEventListeners() {
        if (this.button) {
            // Adiciona um evento de clique ao botão que chama o método redirecionar
            this.button.addEventListener('click', () => this.redirecionar());
        }
    }

    // Método para redirecionar para a URL de destino
    redirecionar() {
        window.location.href = this.targetUrl; // Altera a localização da janela para a URL de destino
    }
}

// Função para coletar os dados e adicionar a nova produção
function adicionarProducao() {
    // Coleta dos valores dos campos do formulário
    const idProducao = document.getElementById('idProducao').value; // Obtém o valor do campo ID da produção
    const dataProducao = document.getElementById('dataProducao').value; // Obtém a data da produção
    const quantidade = document.getElementById('quantidade').value; // Obtém a quantidade da produção
    const produto = document.getElementById('produto').value; // Obtém o produto relacionado à produção
    const responsavel = document.getElementById('responsavel').value; // Obtém o nome do responsável pela produção

    // Verifica se todos os campos obrigatórios foram preenchidos
    if (!idProducao || !dataProducao || !quantidade || !produto || !responsavel) {
        alert('Por favor, preencha todos os campos obrigatórios.'); // Alerta ao usuário para preencher os campos
        return; // Sai da função se algum campo estiver vazio
    }

    // Cria um objeto produção com os dados coletados
    const producao = {
        idProducao,
        dataProducao,
        quantidade,
        produto,
        responsavel
    };

    // Recupera as produções existentes do localStorage ou inicializa um array vazio
    let producoes = JSON.parse(localStorage.getItem('producoes')) || [];

    // Adiciona a nova produção à lista de produções
    producoes.push(producao);

    // Armazena a lista de produções atualizada no localStorage
    localStorage.setItem('producoes', JSON.stringify(producoes));

    // Exibe uma mensagem de sucesso ao usuário
    alert('Produção cadastrada com sucesso!');

    // Redireciona para a página de listagem de produções
    window.location.href = 'Producaof.html';
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Gerencia o botão de voltar para a página de listagem de produções
    new NavigationButton('.back-button a', 'Producaof.html'); // Cria uma nova instância de NavigationButton para o botão de voltar

    // Gerencia o ícone de home para redirecionar à página inicial
    new NavigationButton('.home-icon a', 'inicialF.html'); // Cria uma nova instância de NavigationButton para o ícone de home

    // Adiciona um ouvinte de evento de clique ao botão de salvar produção
    const submitButton = document.querySelector('.submit-button'); // Seleciona o botão de salvar
    if (submitButton) {
        // Adiciona um evento de clique que chama a função para adicionar a nova produção
        submitButton.addEventListener('click', (event) => {
            event.preventDefault(); // Evita o comportamento padrão de envio do formulário
            adicionarProducao(); // Chama a função para adicionar a nova produção
        });
    }
});
