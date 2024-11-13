// Classe para gerenciar os botões de navegação
class NavigationButton {
    // Construtor que recebe o seletor do botão e a URL de destino para redirecionamento
    constructor(buttonSelector, targetUrl) {
        this.button = document.querySelector(buttonSelector); // Seleciona o botão com base no seletor fornecido
        this.targetUrl = targetUrl; // Define a URL de destino
        this.initEventListeners(); // Inicializa os eventos do botão
    }

    // Método para adicionar o evento de clique ao botão
    initEventListeners() {
        // Verifica se o botão existe na página
        if (this.button) {
            // Adiciona um evento de clique ao botão que chama o método de redirecionamento
            this.button.addEventListener('click', () => this.redirecionar());
        }
    }

    // Método para redirecionar o usuário para a URL de destino
    redirecionar() {
        window.location.href = this.targetUrl; // Redireciona para o endereço especificado
    }
}

// Classe para gerenciar produtos
class ProductManager {
    // Construtor que inicializa a lista de produtos e configura eventos
    constructor() {
        // Obtém os produtos do localStorage, ou usa uma lista vazia se não houver produtos salvos
        this.produtos = JSON.parse(localStorage.getItem('produtos')) || [];
        this.initEventListeners(); // Inicializa os eventos dos botões de produtos
    }

    // Método para configurar eventos
    initEventListeners() {
        const addButton = document.querySelector('.add-button'); // Seleciona o botão de adicionar produto
        // Verifica se o botão de adicionar existe na página
        if (addButton) {
            // Adiciona um evento de clique ao botão de adicionar
            addButton.addEventListener('click', (event) => {
                event.preventDefault(); // Evita o comportamento padrão do formulário
                this.adicionarProduto(); // Chama o método de adicionar produto
            });
        }
    }

    // Método para adicionar um novo produto
    adicionarProduto() {
        // Obtém os valores dos campos de entrada do formulário
        const nomeProduto = document.getElementById('nome-produto').value;
        const idProduto = document.getElementById('id-produto').value;
        const quantidade = document.getElementById('quantidade').value;
        const valor = document.getElementById('valor').value;
        const empresaResponsavel = document.getElementById('empresa-responsavel').value;

        // Verifica se todos os campos obrigatórios estão preenchidos
        if (!nomeProduto || !idProduto || !quantidade || !valor || !empresaResponsavel) {
            alert('Por favor, preencha todos os campos obrigatórios.'); // Alerta o usuário se algum campo estiver vazio
            return; // Encerra a função se algum campo estiver vazio
        }

        // Verifica se o ID do produto já está cadastrado
        const idExistente = this.produtos.some(produto => produto.id === idProduto);
        if (idExistente) {
            alert('ID do produto já cadastrado. Por favor, insira um ID único.'); // Alerta o usuário se o ID já existir
            return; // Encerra a função para evitar duplicação de IDs
        }

        // Cria um novo objeto de produto com os valores dos campos
        const produto = {
            nome: nomeProduto,
            id: idProduto,
            quantidade,
            valor,
            empresaResponsavel
        };

        // Adiciona o novo produto à lista de produtos
        this.produtos.push(produto);
        // Salva a lista atualizada de produtos no localStorage
        localStorage.setItem('produtos', JSON.stringify(this.produtos));

        alert('Produto adicionado com sucesso!'); // Exibe uma mensagem de sucesso
        window.location.href = 'Produtos.html'; // Redireciona para a página de produtos
    }
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Cria uma instância de NavigationButton para o botão de voltar, redirecionando para 'ProdutosG.html'
    new NavigationButton('.back-button', 'ProdutosG.html');
    // Cria uma instância de NavigationButton para o botão de home, redirecionando para 'inicialGerente.html'
    new NavigationButton('#homeButton', 'inicialGerente.html');
    // Cria uma instância de ProductManager para gerenciar produtos
    new ProductManager();
});
