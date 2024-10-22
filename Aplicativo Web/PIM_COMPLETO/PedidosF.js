// Classe para gerenciar o redirecionamento de pedidos
class Pedido {
    // Construtor da classe, que recebe o seletor do pedido e a URL de edição
    constructor(pedidoSelector, editUrl) {
        this.pedido = document.querySelector(pedidoSelector); // Seleciona o pedido com base no seletor fornecido
        this.editUrl = editUrl; // Armazena a URL de edição para redirecionamento
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    initEventListeners() {
        // Verifica se o pedido foi encontrado
        if (this.pedido) {
            // Adiciona um ouvinte de evento de clique que chama a função de redirecionamento para edição
            this.pedido.addEventListener('click', () => this.redirecionarParaEdicao());
        }
    }

    redirecionarParaEdicao() {
        // Redireciona a página atual para a URL de edição do pedido
        window.location.href = this.editUrl;
    }
}

// Classe para gerenciar o redirecionamento de novos pedidos
class NovoPedido {
    // Construtor da classe, que recebe o seletor do botão e a URL de criação de novo pedido
    constructor(buttonSelector, newUrl) {
        this.novoPedidoButton = document.querySelector(buttonSelector); // Seleciona o botão de novo pedido
        this.newUrl = newUrl; // Armazena a URL de criação de novo pedido
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    initEventListeners() {
        // Verifica se o botão de novo pedido foi encontrado
        if (this.novoPedidoButton) {
            // Adiciona um ouvinte de evento de clique que chama a função de redirecionamento para novo pedido
            this.novoPedidoButton.addEventListener('click', () => this.redirecionarParaNovoPedido());
        }
    }

    redirecionarParaNovoPedido() {
        // Redireciona a página atual para a URL de criação de novo pedido
        window.location.href = this.newUrl;
    }
}

// Classe para gerenciar o botão de voltar
class VoltarButton {
    // Construtor da classe, que recebe o seletor do botão de voltar e a URL da página anterior
    constructor(buttonSelector, backUrl) {
        this.voltarButton = document.querySelector(buttonSelector); // Seleciona o botão de voltar
        this.backUrl = backUrl; // Armazena a URL da página anterior
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    initEventListeners() {
        // Verifica se o botão de voltar foi encontrado
        if (this.voltarButton) {
            // Adiciona um ouvinte de evento de clique que chama a função de voltar
            this.voltarButton.addEventListener('click', () => this.voltarTelaAnterior());
        }
    }

    voltarTelaAnterior() {
        // Redireciona a página atual para a URL da página anterior
        window.location.href = this.backUrl;
    }
}

// Função para deletar um pedido pelo ID
function deletarPedido(id) {
    // Pergunta ao usuário se ele tem certeza da exclusão do pedido
    if (confirm(`Tem certeza que deseja excluir o pedido com ID ${id}?`)) {
        // Recupera os pedidos do localStorage
        let pedidos = JSON.parse(localStorage.getItem('pedidos')) || []; // Inicializa com um array vazio se não houver pedidos

        // Filtra os pedidos para remover o que tem o ID correspondente
        pedidos = pedidos.filter(pedido => pedido.idPedido !== id);

        // Atualiza o localStorage com a lista de pedidos filtrada
        localStorage.setItem('pedidos', JSON.stringify(pedidos));

        // Exibe uma mensagem de sucesso ao usuário
        alert(`Pedido com ID ${id} excluído com sucesso!`);

        // Atualiza a página para refletir a exclusão
        window.location.reload();
    }
}

// Função para inicializar os pedidos dinamicamente
function inicializarPedidos() {

    // Para cada pedido na lista, cria uma nova instância da classe Pedido
    pedidos.forEach(pedido => new Pedido(pedido.selector, pedido.url));
}

// Inicializa o sistema de gerenciamento de pedidos após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {

    // Gerenciar o redirecionamento ao clicar em "Novo Pedido"
    new NovoPedido('.novo-pedido', 'NovoPedidoF.html');

    // Gerenciar o botão de voltar
    new VoltarButton('.back-button', 'inicialF.html');

    // Gerenciar o botão de excluir pedido
    const excluirButton = document.querySelector('.delete-button'); // Seleciona o botão de excluir
    if (excluirButton) {
        // Adiciona um ouvinte de evento que pergunta ao usuário qual pedido excluir
        excluirButton.addEventListener('click', () => {
            // Obtém o ID do pedido que deve ser excluído
            const idPedido = prompt("Digite o ID do pedido que deseja excluir:");
            if (idPedido) {
                deletarPedido(idPedido); // Chama a função para deletar o pedido
            }
        });
    }
});
