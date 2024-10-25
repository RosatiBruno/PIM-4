// Classe para gerenciar a busca de produtos
class ProdutoSearch {
    constructor(searchBarSelector, productListSelector) {
        this.searchBar = document.querySelector(searchBarSelector);
        this.productList = document.querySelector(productListSelector);
        this.initEventListeners();
    }

    initEventListeners() {
        document.querySelector('.search-bar button').addEventListener('click', () => this.buscarProduto());

        this.searchBar.addEventListener('keyup', (event) => {
            if (event.key === 'Enter') {
                this.buscarProduto(); // Chama a função de busca se a tecla "Enter" for pressionada
            }
        });
    }

    buscarProduto() {
        const filter = this.searchBar.value.toUpperCase();
        const productItems = this.productList.querySelectorAll('li');

        productItems.forEach(item => {
            const txtValue = item.textContent || item.innerText;
            item.style.display = txtValue.toUpperCase().includes(filter) ? '' : 'none';
        });
    }
}

// Função para carregar produtos do localStorage e exibi-los
function carregarProdutos() {
    const produtos = JSON.parse(localStorage.getItem('produtos')) || [];
    const produtosContainer = document.querySelector('.product-list');

    produtosContainer.innerHTML = '';

    if (produtos.length === 0) {
        produtosContainer.innerHTML = '<p>Nenhum produto cadastrado.</p>';
        return;
    }

    produtos.forEach((produto) => {
        const produtoItem = document.createElement('li');
        produtoItem.classList.add('produto-item');
        produtoItem.textContent = produto.nome; // Mostra o nome do produto na lista
        // Adiciona um evento de clique para abrir o modal
        produtoItem.addEventListener('click', () => {
            openModal(produto); // Passa o objeto produto para o modal
        });
        produtosContainer.appendChild(produtoItem);
    });
}

// Função para abrir o modal com os detalhes do produto
function openModal(produto) {
    const modal = document.getElementById("modal");
    const modalDetails = document.getElementById("modal-details");
    modalDetails.innerHTML = `Detalhes do Produto:<br>Nome: ${produto.nome}<br>ID: ${produto.id-produto}<br> Quantidade: ${produto.quantidade}<br> Valor: ${produto.valor}<br> `; // Atualiza os detalhes do modal
    modal.style.display = "block"; // Exibe o modal
}

// Função para fechar o modal
function fecharModal() {
    const modal = document.getElementById("modal");
    modal.style.display = "none"; // Esconde o modal
}

// Função para excluir produto pelo ID
function excluirProduto() {
    const produtoId = prompt("Digite o ID do produto que deseja excluir:");
    if (!produtoId) return;

    const confirmacao = confirm(`Tem certeza que deseja excluir o produto com ID ${produtoId}?`);
    if (confirmacao) {
        let produtos = JSON.parse(localStorage.getItem('produtos')) || [];
        produtos = produtos.filter((_, index) => index !== parseInt(produtoId) - 1);

        localStorage.setItem('produtos', JSON.stringify(produtos));
        carregarProdutos();

        alert('Produto excluído com sucesso!');
    }
}

// Função para redirecionar para a tela anterior
function voltarTelaAnterior() {
    window.location.href = 'inicialGerente.html'; // Redireciona para a página inicial
}

// Inicializa o sistema de gerenciamento de produtos após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    const newProductButton = document.querySelector('.new-product-button');
    if (newProductButton) {
        newProductButton.addEventListener('click', () => {
            window.location.href = 'NovoProdutoG.html';
        });
    }

    const deleteButton = document.querySelector('.delete-button');
    if (deleteButton) {
        deleteButton.addEventListener('click', excluirProduto);
    }

    // Evento para o botão de voltar
    const backButton = document.querySelector('.back-button');
    if (backButton) {
        backButton.addEventListener('click', voltarTelaAnterior); // Adiciona evento para voltar à tela anterior
    }

    // Evento para fechar o modal
    const closeButton = document.querySelector(".close-button");
    if (closeButton) {
        closeButton.addEventListener('click', fecharModal); // Adiciona evento para fechar o modal
    }

    // Fecha o modal se o usuário clicar fora do conteúdo do modal
    const modal = document.getElementById("modal");
    window.onclick = function(event) {
        if (event.target === modal) {
            fecharModal(); // Esconde o modal
        }
    };

    // Carrega os produtos ao iniciar
    carregarProdutos();
});
