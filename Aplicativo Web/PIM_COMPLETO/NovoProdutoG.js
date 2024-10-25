// Classe para gerenciar a adição de produtos
class ProdutoManager {
    // Construtor da classe que recebe o seletor do formulário
    constructor(formSelector) {
        this.form = document.querySelector(formSelector); // Seleciona o formulário no DOM
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    // Inicializa os ouvintes de eventos para o formulário
    initEventListeners() {
        // Adiciona evento para o botão "ADICIONAR"
        this.form.addEventListener('submit', (event) => this.adicionarProduto(event)); // Chama a função adicionarProduto ao submeter o formulário
    }

    // Função para adicionar um produto ao localStorage
    adicionarProduto(event) {
        event.preventDefault(); // Previne o comportamento padrão do formulário (não recarrega a página)

        // Captura os valores do formulário
        const nome = document.querySelector('#nome-produto').value; // Obtém o nome do produto
        const idPedido = document.querySelector('#id-pedido').value; // Obtém o ID do pedido
        const quantidade = document.querySelector('#quantidade').value; // Obtém a quantidade do produto
        const valor = document.querySelector('#valor').value; // Obtém o valor do produto
        const empresaResponsavel = document.querySelector('#empresa-responsavel').value; // Obtém a empresa responsável pelo produto

        // Valida se os campos obrigatórios foram preenchidos
        if (!nome || !idPedido || !quantidade || !valor || !empresaResponsavel) {
            alert('Por favor, preencha todos os campos.'); // Exibe alerta se algum campo obrigatório estiver vazio
            return; // Interrompe a execução da função
        }

        // Cria o objeto produto
        const novoProduto = {
            nome,
            idPedido,
            quantidade,
            valor,
            empresaResponsavel
        };

        // Recupera os produtos do localStorage, ou cria uma lista vazia se não houver produtos
        const produtos = JSON.parse(localStorage.getItem('produtos')) || []; // Converte a string do localStorage em um array

        // Adiciona o novo produto à lista
        produtos.push(novoProduto); // Adiciona o novo produto ao array

        // Atualiza o localStorage com a nova lista de produtos
        localStorage.setItem('produtos', JSON.stringify(produtos)); // Salva a nova lista de produtos como string no localStorage

        // Exibe uma mensagem de sucesso e limpa o formulário
        alert('Produto adicionado com sucesso!'); // Informa que o produto foi adicionado
        this.form.reset(); // Limpa o formulário para permitir uma nova entrada
    }
}

// Classe para gerenciar o botão de voltar
class BackButton {
    // Construtor da classe que recebe o seletor do botão e a URL de retorno
    constructor(buttonSelector, backUrl) {
        this.button = document.querySelector(buttonSelector); // Seleciona o botão no DOM
        this.backUrl = backUrl; // Armazena a URL para a qual o botão deve redirecionar
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    // Inicializa os ouvintes de eventos para o botão
    initEventListeners() {
        this.button.addEventListener('click', () => this.voltar()); // Adiciona um evento de clique ao botão
    }

    // Método para retornar à tela anterior
    voltar() {
        window.location.href = this.backUrl; // Redireciona para a URL especificada
    }
}

// Classe para gerenciar o ícone de home
class HomeButton {
    // Construtor da classe que recebe o seletor do botão e a URL da página inicial
    constructor(buttonSelector, homeUrl) {
        this.button = document.querySelector(buttonSelector); // Seleciona o botão no DOM
        this.homeUrl = homeUrl; // Armazena a URL da página inicial
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    // Inicializa os ouvintes de eventos para o botão
    initEventListeners() {
        this.button.addEventListener('click', () => this.irParaHome()); // Adiciona um evento de clique ao botão
    }

    // Método para redirecionar para a página inicial
    irParaHome() {
        window.location.href = this.homeUrl; // Redireciona para a página inicial
    }
}

// Inicializa o sistema de gerenciamento de produtos após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Inicializa o gerenciador de produtos (formulário)
    new ProdutoManager('form'); // Cria uma nova instância da classe ProdutoManager para gerenciar o formulário

    // Inicializa o botão de voltar para a página inicial do gerente
    new BackButton('.back-button', 'ProdutosG.html'); // Cria uma nova instância da classe BackButton

    // Inicializa o ícone de home para redirecionar para a tela inicial
    new HomeButton('#homeButton', 'inicialGerente.html'); // Cria uma nova instância da classe HomeButton
});
