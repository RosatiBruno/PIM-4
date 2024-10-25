// Classe para gerenciar o botão de voltar
class BackButton {
    // Construtor da classe que recebe o seletor do botão e a URL para redirecionar
    constructor(buttonSelector, targetUrl) {
        this.backButton = document.querySelector(buttonSelector); // Seleciona o botão de voltar usando o seletor fornecido
        this.targetUrl = targetUrl; // Armazena a URL para redirecionamento ao clicar no botão
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    // Método para inicializar os ouvintes de eventos
    initEventListeners() {
        if (this.backButton) { // Verifica se o botão de voltar existe
            this.backButton.addEventListener('click', () => this.redirecionar()); // Adiciona um ouvinte de clique que chama a função redirecionar
        }
    }

    // Método para redirecionar para a URL especificada
    redirecionar() {
        window.location.href = this.targetUrl; // Altera a localização da janela para a URL de destino
    }
}

// Classe para gerenciar o botão "Home"
class HomeButton {
    // Construtor da classe que recebe o ID do botão e a URL de redirecionamento
    constructor(buttonSelector, targetUrl) {
        this.homeButton = document.getElementById(buttonSelector); // Seleciona o botão de home usando o ID fornecido
        this.targetUrl = targetUrl; // Armazena a URL para redirecionamento ao clicar no botão
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    // Método para inicializar os ouvintes de eventos
    initEventListeners() {
        if (this.homeButton) { // Verifica se o botão de home existe
            this.homeButton.addEventListener('click', () => this.redirecionar()); // Adiciona um ouvinte de clique que chama a função redirecionar
        }
    }

    // Método para redirecionar para a URL especificada
    redirecionar() {
        window.location.href = this.targetUrl; // Altera a localização da janela para a URL de destino
    }
}

// Função para adicionar um novo pedido
function adicionarPedido() {
    // Coleta os valores dos campos do formulário
    const nomeProduto = document.getElementById('nome-produto').value; // Coleta o nome do produto
    const idPedido = document.getElementById('id-pedido').value; // Coleta o ID do pedido
    const quantidade = document.getElementById('quantidade').value; // Coleta a quantidade do pedido
    const valor = document.getElementById('valor').value; // Coleta o valor do pedido
    const empresaResponsavel = document.getElementById('empresa-responsavel').value; // Coleta a empresa responsável

    // Verifica se todos os campos obrigatórios foram preenchidos
    if (!nomeProduto || !idPedido || !quantidade || !valor || !empresaResponsavel) {
        alert('Por favor, preencha todos os campos.'); // Exibe alerta se algum campo obrigatório estiver vazio
        return; // Encerra a função se a validação falhar
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
    let pedidos = JSON.parse(localStorage.getItem('pedidos')) || []; // Tenta obter a lista de pedidos, ou cria um array vazio se não houver

    // Adiciona o novo pedido à lista de pedidos
    pedidos.push(pedido); // Adiciona o objeto pedido ao array de pedidos

    // Atualiza os pedidos no localStorage
    localStorage.setItem('pedidos', JSON.stringify(pedidos)); // Armazena a lista de pedidos atualizada no localStorage

    // Exibe uma mensagem de sucesso
    alert('Pedido cadastrado com sucesso!'); // Alerta ao usuário que o pedido foi adicionado

    // Redireciona para a página de Vendas
    window.location.href = 'Vendas.html'; // Altera a localização da janela para a página de Vendas
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Gerenciar o botão de voltar para a página de lista de pedidos
    new BackButton('.back-button', 'PedidosF.html'); // Cria uma nova instância de BackButton para o botão de voltar

    // Gerenciar o botão de home para redirecionar à página inicial
    new HomeButton('homeButton', 'inicialF.html'); // Cria uma nova instância de HomeButton para o botão de home

    // Adicionar evento ao botão de adicionar pedido
    const addButton = document.querySelector('.add-button'); // Seleciona o botão de adicionar pedido
    if (addButton) { // Verifica se o botão existe
        addButton.addEventListener('click', (event) => {
            event.preventDefault(); // Evita o envio do formulário, permitindo tratamento customizado
            adicionarPedido(); // Chama a função para adicionar o novo pedido
        });
    }
});
