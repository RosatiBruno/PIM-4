// Classe para gerenciar os botões de navegação
class NavigationButton {
    // Construtor que recebe o seletor do botão e a URL de destino
    constructor(buttonSelector, targetUrl) {
        this.button = document.querySelector(buttonSelector); // Seleciona o botão com base no seletor fornecido
        this.targetUrl = targetUrl; // Define a URL de destino
        this.initEventListeners(); // Inicializa os eventos para o botão
    }

    // Método para inicializar os eventos do botão
    initEventListeners() {
        if (this.button) { // Verifica se o botão foi encontrado
            // Adiciona um evento de clique para redirecionar ao destino
            this.button.addEventListener('click', () => this.redirecionar());
        }
    }

    // Método que redireciona para a URL de destino
    redirecionar() {
        window.location.href = this.targetUrl; // Redireciona a página para a URL especificada
    }
}

// Classe para gerenciar produtos
class ProductManager {
    // Construtor que inicializa os produtos a partir do localStorage e define os eventos
    constructor() {
        this.produtos = JSON.parse(localStorage.getItem('produtos')) || []; // Carrega os produtos do localStorage ou cria um array vazio se não houver produtos salvos
        this.initEventListeners(); // Inicializa os eventos
    }

    // Método para inicializar os eventos de adicionar produto
    initEventListeners() {
        const addButton = document.querySelector('.add-button'); // Seleciona o botão de adicionar produto
        if (addButton) { // Verifica se o botão foi encontrado
            // Adiciona um evento de clique que previne o comportamento padrão e chama o método de adicionar produto
            addButton.addEventListener('click', (event) => {
                event.preventDefault();
                this.adicionarProduto();
            });
        }
    }

    // Método para adicionar um novo produto
    adicionarProduto() {
        const nomeProduto = document.getElementById('nome-produto').value; // Obtém o valor do campo de nome do produto
        const idProduto = document.getElementById('id-produto').value; // Obtém o valor do campo de ID do produto
        const quantidade = document.getElementById('quantidade').value; // Obtém o valor do campo de quantidade
        const valor = document.getElementById('valor').value; // Obtém o valor do campo de valor
        const empresaResponsavel = document.getElementById('empresa-responsavel').value; // Obtém o valor do campo de empresa responsável

        // Verifica se todos os campos obrigatórios estão preenchidos
        if (!nomeProduto || !idProduto || !quantidade || !valor || !empresaResponsavel) {
            alert('Por favor, preencha todos os campos obrigatórios.');
            return;
        }

        // Verifica se o ID do produto já existe entre os produtos
        const idExistente = this.produtos.some(produto => produto.id === idProduto);
        if (idExistente) {
            alert('ID do produto já cadastrado. Por favor, insira um ID único.');
            return;
        }

        // Cria um objeto de produto com os dados informados
        const produto = {
            nome: nomeProduto,
            id: idProduto,
            quantidade,
            valor,
            empresaResponsavel
        };

        this.produtos.push(produto); // Adiciona o produto ao array de produtos
        localStorage.setItem('produtos', JSON.stringify(this.produtos)); // Salva o array atualizado no localStorage

        alert('Produto adicionado com sucesso!');
        window.location.href = 'Produtos.html'; // Redireciona para a página de produtos
    }
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Cria botões de navegação e define suas URLs de destino
    new NavigationButton('.back-button', 'Produtos.html'); // Botão de voltar para a página de produtos
    new NavigationButton('#homeButton', 'inicial.html'); // Botão de home para a página inicial
    new ProductManager(); // Cria uma instância do gerenciador de produtos
});
