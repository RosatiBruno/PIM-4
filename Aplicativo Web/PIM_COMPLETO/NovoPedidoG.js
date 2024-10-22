// Classe para gerenciar o botão de voltar
class BackButton {
    // Construtor da classe que recebe o seletor do botão de voltar e a URL de destino
    constructor(buttonSelector, targetUrl) {
        this.backButton = document.querySelector(buttonSelector); // Seleciona o botão de voltar com base no seletor
        this.targetUrl = targetUrl; // Armazena a URL de destino para redirecionamento
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    initEventListeners() {
        // Verifica se o botão de voltar foi encontrado
        if (this.backButton) {
            // Adiciona um ouvinte de evento de clique que chama a função de redirecionamento
            this.backButton.addEventListener('click', () => this.redirecionar());
        }
    }

    redirecionar() {
        // Redireciona a página atual para a URL de destino
        window.location.href = this.targetUrl;
    }
}

// Classe para gerenciar o botão "Home"
class HomeButton {
    // Construtor da classe que recebe o seletor do botão "Home" e a URL de destino
    constructor(buttonSelector, targetUrl) {
        this.homeButton = document.getElementById(buttonSelector); // Seleciona o botão "Home" com base no ID
        this.targetUrl = targetUrl; // Armazena a URL de destino para redirecionamento
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    initEventListeners() {
        // Verifica se o botão "Home" foi encontrado
        if (this.homeButton) {
            // Adiciona um ouvinte de evento de clique que chama a função de redirecionamento
            this.homeButton.addEventListener('click', () => this.redirecionar());
        }
    }

    redirecionar() {
        // Redireciona a página atual para a URL de destino
        window.location.href = this.targetUrl;
    }
}

// Função para adicionar um novo pedido
function adicionarPedido() {
    // Coleta os valores dos campos do formulário
    const nomeProduto = document.getElementById('nome-produto').value; // Obtém o nome do produto
    const idPedido = document.getElementById('id-pedido').value; // Obtém o ID do pedido
    const quantidade = document.getElementById('quantidade').value; // Obtém a quantidade do produto
    const valor = document.getElementById('valor').value; // Obtém o valor do pedido
    const empresaResponsavel = document.getElementById('empresa-responsavel').value; // Obtém a empresa responsável

    // Verifica se todos os campos obrigatórios foram preenchidos
    if (!nomeProduto || !idPedido || !quantidade || !valor || !empresaResponsavel) {
        alert('Por favor, preencha todos os campos.'); // Exibe um alerta se algum campo estiver vazio
        return; // Sai da função se houver campos não preenchidos
    }

    // Cria um objeto pedido com os dados do formulário
    const pedido = {
        nomeProduto,
        idPedido,
        quantidade,
        valor,
        empresaResponsavel
    };

    // Recupera os pedidos já existentes do localStorage
    let pedidos = JSON.parse(localStorage.getItem('pedidos')) || []; // Inicializa com um array vazio se não houver pedidos

    // Adiciona o novo pedido à lista de pedidos
    pedidos.push(pedido);

    // Atualiza os pedidos no localStorage
    localStorage.setItem('pedidos', JSON.stringify(pedidos));

    // Exibe uma mensagem de sucesso
    alert('Pedido cadastrado com sucesso!');

    // Redireciona para a página de Vendas
    window.location.href = 'Vendas.html';
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Gerencia o botão de voltar para a página de lista de pedidos
    new BackButton('.back-button', 'ListaPedidosG.html');

    // Gerencia o botão de home para redirecionar à página inicial
    new HomeButton('homeButton', 'inicialGerente.html');

    // Adiciona um evento ao botão de adicionar pedido
    const addButton = document.querySelector('.add-button'); // Seleciona o botão de adicionar pedido
    if (addButton) {
        // Adiciona um ouvinte de evento que evita o envio do formulário e chama a função de adicionar pedido
        addButton.addEventListener('click', (event) => {
            event.preventDefault(); // Evita o comportamento padrão de envio do formulário
            adicionarPedido(); // Chama a função para adicionar o novo pedido
        });
    }
});
