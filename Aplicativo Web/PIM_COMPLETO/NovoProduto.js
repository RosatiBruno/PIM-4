// Classe para gerenciar os botões de navegação
class NavigationButton {
    // Construtor da classe, que recebe o seletor do botão e a URL de destino
    constructor(buttonSelector, targetUrl) {
        this.button = document.querySelector(buttonSelector); // Seleciona o botão com base no seletor fornecido
        this.targetUrl = targetUrl; // Armazena a URL de destino para redirecionamento
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    initEventListeners() {
        // Verifica se o botão foi encontrado
        if (this.button) {
            // Adiciona um ouvinte de evento de clique que chama a função de redirecionamento
            this.button.addEventListener('click', () => this.redirecionar());
        }
    }

    redirecionar() {
        // Redireciona a página atual para a URL de destino
        window.location.href = this.targetUrl;
    }
}

// Função para coletar os dados e adicionar o produto
function adicionarProduto() {
    // Coleta os valores dos campos do formulário com base em seus IDs
    const nomeProduto = document.getElementById('nome-produto').value;
    const idPedido = document.getElementById('id-produto').value;
    const quantidade = document.getElementById('quantidade').value;
    const valor = document.getElementById('valor').value;
    const empresaResponsavel = document.getElementById('empresa-responsavel').value;

    // Verifica se todos os campos obrigatórios foram preenchidos
    if (!nomeProduto || !idPedido || !quantidade || !valor || !empresaResponsavel) {
        alert('Por favor, preencha todos os campos obrigatórios.'); // Exibe um alerta caso faltem campos
        return; // Sai da função se algum campo estiver vazio
    }

    // Cria um objeto produto com os dados coletados
    const produto = {
        nome: nomeProduto,
        idPedido,
        quantidade,
        valor,
        empresaResponsavel
    };

    // Recupera a lista de produtos existentes do localStorage
    let produtos = JSON.parse(localStorage.getItem('produtos')) || []; // Inicializa com um array vazio se não houver produtos

    // Adiciona o novo produto à lista de produtos
    produtos.push(produto);

    // Armazena a lista de produtos atualizada no localStorage
    localStorage.setItem('produtos', JSON.stringify(produtos));

    // Exibe uma mensagem de sucesso ao usuário
    alert('Produto adicionado com sucesso!');

    // Redireciona para a página de listagem de produtos
    window.location.href = 'Produtos.html';
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Gerencia o botão de voltar para a página de produtos
    new NavigationButton('.back-button', 'Produtos.html');

    // Gerencia o botão de home para redirecionar à página inicial
    new NavigationButton('#homeButton', 'inicial.html');

    // Adiciona um ouvinte de evento de clique ao botão de adicionar produto
    const addButton = document.querySelector('.add-button');
    if (addButton) {
        // Adiciona um ouvinte de evento que previne o comportamento padrão do botão de envio
        addButton.addEventListener('click', (event) => {
            event.preventDefault(); // Evita o comportamento padrão de envio do formulário
            adicionarProduto(); // Chama a função para adicionar o produto
        });
    }
});
