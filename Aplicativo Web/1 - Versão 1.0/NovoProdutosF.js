// Classe para gerenciar os botões de navegação
class NavigationButton {
    // Construtor da classe, recebe um seletor de botão e a URL de destino
    constructor(buttonSelector, targetUrl) {
        this.button = document.querySelector(buttonSelector); // Seleciona o botão usando o seletor fornecido
        this.targetUrl = targetUrl; // Armazena a URL de destino
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    // Função para inicializar os ouvintes de eventos
    initEventListeners() {
        if (this.button) { // Verifica se o botão foi encontrado
            // Adiciona um evento de clique ao botão que chama a função de redirecionamento
            this.button.addEventListener('click', () => this.redirecionar());
        }
    }

    // Função para redirecionar para a URL de destino
    redirecionar() {
        window.location.href = this.targetUrl; // Altera a localização da janela para a URL de destino
    }
}

// Função para coletar os dados e adicionar o produto
function adicionarProduto() {
    // Obtém os valores dos campos de entrada
    const nomeProduto = document.getElementById('nome-produto').value;
    const idProduto = document.getElementById('id-produto').value;
    const quantidade = document.getElementById('quantidade').value;
    const valor = document.getElementById('valor').value;
    const empresaResponsavel = document.getElementById('empresa-responsavel').value;

    // Verifica se todos os campos obrigatórios estão preenchidos
    if (!nomeProduto || !idProduto || !quantidade || !valor || !empresaResponsavel) {
        alert('Por favor, preencha todos os campos obrigatórios.'); // Exibe um alerta se algum campo estiver vazio
        return; // Sai da função se houver campos vazios
    }

    // Obtém a lista de produtos do localStorage ou cria uma nova lista vazia
    let produtos = JSON.parse(localStorage.getItem('produtos')) || [];

    // Verifica se o ID do produto já existe na lista
    const idExistente = produtos.some(produto => produto.id === idProduto);
    if (idExistente) {
        alert('ID do produto já cadastrado. Por favor, insira um ID único.'); // Alerta se o ID já existir
        return; // Sai da função para evitar duplicação
    }

    // Cria um objeto de produto com os dados coletados
    const produto = {
        nome: nomeProduto,
        id: idProduto,
        quantidade,
        valor,
        empresaResponsavel
    };

    // Adiciona o novo produto à lista de produtos
    produtos.push(produto);
    // Salva a lista atualizada de produtos no localStorage
    localStorage.setItem('produtos', JSON.stringify(produtos));

    alert('Produto adicionado com sucesso!'); // Alerta de sucesso
    window.location.href = 'ProdutosF.html'; // Redireciona para a página de produtos
}

// Ouvinte de evento que aguarda o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Cria instâncias dos botões de navegação para voltar e ir para a página inicial
    new NavigationButton('.back-button', 'ProdutosF.html');
    new NavigationButton('#homeButton', 'inicialF.html');

    // Seleciona o botão de adicionar produto
    const addButton = document.querySelector('.add-button');
    if (addButton) { // Verifica se o botão foi encontrado
        // Adiciona um evento de clique que chama a função de adicionar produto
        addButton.addEventListener('click', (event) => {
            event.preventDefault(); // Previne o comportamento padrão do botão
            adicionarProduto(); // Chama a função para adicionar o produto
        });
    }
});
