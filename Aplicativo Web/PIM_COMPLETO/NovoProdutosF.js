// Classe para gerenciar os botões de navegação
class NavigationButton {
    // Construtor da classe que recebe o seletor do botão e a URL de destino
    constructor(buttonSelector, targetUrl) {
        this.button = document.querySelector(buttonSelector); // Seleciona o botão usando o seletor fornecido
        this.targetUrl = targetUrl; // Armazena a URL para redirecionamento
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    // Método para inicializar os ouvintes de eventos
    initEventListeners() {
        if (this.button) { // Verifica se o botão existe
            this.button.addEventListener('click', () => this.redirecionar()); // Adiciona um ouvinte de clique que chama a função redirecionar
        }
    }

    // Método para redirecionar para a URL de destino
    redirecionar() {
        window.location.href = this.targetUrl; // Altera a localização da janela para a URL especificada
    }
}

// Função para coletar os dados e adicionar o produto
function adicionarProduto() {
    // Coleta dos valores dos campos do formulário
    const nomeProduto = document.getElementById('nome-produto').value; // Obtém o valor do campo nome do produto
    const idPedido = document.getElementById('id-pedido').value; // Obtém o valor do campo ID do pedido
    const quantidade = document.getElementById('quantidade').value; // Obtém o valor do campo quantidade
    const valor = document.getElementById('valor').value; // Obtém o valor do campo valor
    const empresaResponsavel = document.getElementById('empresa-responsavel').value; // Obtém o valor do campo empresa responsável

    // Verifica se os campos obrigatórios foram preenchidos
    if (!nomeProduto || !idPedido || !quantidade || !valor || !empresaResponsavel) {
        alert('Por favor, preencha todos os campos obrigatórios.'); // Exibe um alerta se algum campo estiver vazio
        return; // Sai da função se houver campos vazios
    }

    // Cria um objeto produto com os dados coletados
    const produto = {
        nome: nomeProduto, // Atribui o nome do produto
        idPedido, // Atribui o ID do pedido
        quantidade, // Atribui a quantidade
        valor, // Atribui o valor
        empresaResponsavel // Atribui a empresa responsável
    };

    // Recupera os produtos existentes do localStorage
    let produtos = JSON.parse(localStorage.getItem('produtos')) || []; // Obtém os produtos ou inicializa como um array vazio se não houver produtos

    // Adiciona o novo produto à lista de produtos
    produtos.push(produto); // Adiciona o objeto produto ao array de produtos

    // Armazena a lista de produtos atualizada no localStorage
    localStorage.setItem('produtos', JSON.stringify(produtos)); // Converte o array de produtos em JSON e armazena no localStorage

    // Exibe uma mensagem de sucesso
    alert('Produto adicionado com sucesso!'); // Alerta de sucesso

    // Redireciona para a página de listagem de produtos
    window.location.href = 'Produtosf.html'; // Altera a localização da janela para a página de listagem de produtos
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Gerenciar o botão de voltar para a página de produtos
    new NavigationButton('.back-button', 'Produtosf.html'); // Cria uma nova instância do botão de navegação para voltar

    // Gerenciar o botão de home para redirecionar à página inicial
    new NavigationButton('#homeButton', 'inicialF.html'); // Cria uma nova instância do botão de navegação para a página inicial

    // Adiciona um ouvinte de evento de clique ao botão de adicionar produto
    const addButton = document.querySelector('.add-button'); // Seleciona o botão de adicionar produto
    if (addButton) { // Verifica se o botão existe
        addButton.addEventListener('click', (event) => {
            event.preventDefault(); // Evita o comportamento padrão de envio do formulário
            adicionarProduto(); // Chama a função para adicionar o produto
        });
    }
});
