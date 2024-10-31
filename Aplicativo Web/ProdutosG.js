// Classe para gerenciar a busca de produtos
class ProdutoSearch {
    constructor(searchBarSelector, productListSelector) {
        this.searchBar = document.querySelector(searchBarSelector);
        this.productList = document.querySelector(productListSelector);
        this.initEventListeners();
    }

    initEventListeners() {
        // Adiciona evento ao botão de busca
        document.querySelector('.search-bar button').addEventListener('click', () => this.buscarProduto());

        // Adiciona evento ao pressionar a tecla "Enter" na barra de busca
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

    produtos.forEach((produto, index) => {
        const produtoItem = document.createElement('li');
        produtoItem.classList.add('produto-item');
        produtoItem.textContent = produto.nome; // Mostra o nome do produto na lista
        // Adiciona um evento de clique para abrir o modal
        produtoItem.addEventListener('click', () => {
            openModal(produto, index); // Passa o produto e seu índice para o modal
        });
        produtosContainer.appendChild(produtoItem);
    });
}

// Função para abrir o modal com os detalhes do produto e permitir edição
function openModal(produto, index) {
    const modal = document.getElementById("modal");
    const modalDetails = document.getElementById("modal-details");

    // Atualiza os campos do modal com os dados do produto
    modalDetails.innerHTML = `
        <label>Nome: <input type="text" id="edit-nome" value="${produto.nome} "></label><br>
        <label>ID: <input type="text" id="edit-id" value="${produto.id} " disabled></label><br>
        <label>Quantidade: <input type="number" id="edit-quantidade" value="${produto.quantidade}"></label><br>
        <label>Valor: <input type="number" id="edit-valor" value="${produto.valor}" step="0.01"></label><br>
        <button id="save-btn">Salvar</button>
    `;
    modal.style.display = "block"; // Exibe o modal

    // Função para salvar as alterações
    document.getElementById("save-btn").onclick = () => salvarEdicaoProduto(index);
}

// Função para salvar as alterações feitas no produto
function salvarEdicaoProduto(index) {
    let produtos = JSON.parse(localStorage.getItem('produtos')) || [];

    // Atualiza os dados do produto com os valores editados
    produtos[index].nome = document.getElementById('edit-nome').value;
    produtos[index].quantidade = document.getElementById('edit-quantidade').value;
    produtos[index].valor = document.getElementById('edit-valor').value;

    // Salva os dados atualizados no localStorage
    localStorage.setItem('produtos', JSON.stringify(produtos));

    // Recarrega a lista de produtos para refletir as mudanças
    carregarProdutos();

    // Fecha o modal após salvar
    fecharModal();

    alert('Produto atualizado com sucesso!');
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
        const indexToRemove = produtos.findIndex(produto => produto.id === produtoId);
        
        if (indexToRemove !== -1) {
            produtos.splice(indexToRemove, 1);
            localStorage.setItem('produtos', JSON.stringify(produtos));
            carregarProdutos();
            alert('Produto excluído com sucesso!');
        } else {
            alert('Produto não encontrado!');
        }
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
        backButton.addEventListener('click', voltarTelaAnterior);
    }

    // Evento para fechar o modal
    const closeButton = document.querySelector(".close-button");
    if (closeButton) {
        closeButton.addEventListener('click', fecharModal);
    }

    // Fecha o modal se o usuário clicar fora do conteúdo do modal
    const modal = document.getElementById("modal");
    window.onclick = function(event) {
        if (event.target === modal) {
            fecharModal();
        }
    };

    // Carrega os produtos ao iniciar
    carregarProdutos();
});
