// Classe para gerenciar a busca de produtos
class ProdutoSearch {
    // Construtor que recebe os seletores da barra de busca e da lista de produtos
    constructor(searchBarSelector, productListSelector) {
        this.searchBar = document.querySelector(searchBarSelector); // Seleciona o elemento da barra de busca
        this.productList = document.querySelector(productListSelector); // Seleciona o elemento da lista de produtos
        this.initEventListeners(); // Inicializa os eventos de busca
    }

    initEventListeners() {
        // Adiciona evento ao botão de busca para iniciar a pesquisa quando clicado
        document.querySelector('.search-bar button').addEventListener('click', () => this.buscarProduto());

        // Adiciona evento para executar a busca ao pressionar "Enter" na barra de busca
        this.searchBar.addEventListener('keyup', (event) => {
            if (event.key === 'Enter') {
                this.buscarProduto(); // Inicia a pesquisa se a tecla "Enter" for pressionada
            }
        });
    }

    buscarProduto() {
        // Converte o valor da barra de busca para maiúsculas para facilitar a busca
        const filter = this.searchBar.value.toUpperCase();
        // Seleciona todos os itens da lista de produtos
        const productItems = this.productList.querySelectorAll('li');

        // Itera sobre cada item da lista de produtos
        productItems.forEach(item => {
            const txtValue = item.textContent || item.innerText; // Obtém o texto do item
            // Exibe o item se o texto incluir o filtro, caso contrário, oculta
            item.style.display = txtValue.toUpperCase().includes(filter) ? '' : 'none';
        });
    }
}

// Função para carregar produtos do localStorage e exibi-los na lista de produtos
function carregarProdutos() {
    const produtos = JSON.parse(localStorage.getItem('produtos')) || []; // Recupera a lista de produtos ou cria uma lista vazia se não houver produtos
    const produtosContainer = document.querySelector('.product-list'); // Seleciona o contêiner da lista de produtos

    produtosContainer.innerHTML = ''; // Limpa a lista de produtos existente

    // Exibe uma mensagem se não houver produtos cadastrados
    if (produtos.length === 0) {
        produtosContainer.innerHTML = '<p>Nenhum produto cadastrado.</p>';
        return;
    }

    // Itera sobre cada produto e o adiciona na lista de produtos
    produtos.forEach((produto, index) => {
        const produtoItem = document.createElement('li'); // Cria um item da lista para o produto
        produtoItem.classList.add('produto-item'); // Adiciona uma classe para estilização
        produtoItem.textContent = produto.nome; // Define o nome do produto no item da lista
        // Adiciona evento de clique no item para abrir o modal de detalhes
        produtoItem.addEventListener('click', () => {
            openModal(produto, index); // Passa o produto e seu índice para o modal
        });
        produtosContainer.appendChild(produtoItem); // Adiciona o item à lista de produtos
    });
}

// Função para abrir o modal com os detalhes do produto e permitir a edição
function openModal(produto, index) {
    const modal = document.getElementById("modal"); // Seleciona o modal
    const modalDetails = document.getElementById("modal-details"); // Seleciona o contêiner dos detalhes do modal

    // Atualiza os campos do modal com os dados do produto
    modalDetails.innerHTML = `
        <label>Nome: <input type="text" id="edit-nome" value="${produto.nome}"></label><br>
        <label>ID: <input type="text" id="edit-id" value="${produto.id}" disabled></label><br>
        <label>Quantidade: <input type="number" id="edit-quantidade" value="${produto.quantidade}"></label><br>
        <label>Valor: <input type="number" id="edit-valor" value="${produto.valor}" step="0.01"></label><br>
        <button id="save-btn">Salvar</button>
    `;
    modal.style.display = "block"; // Exibe o modal

    // Função para salvar as alterações ao clicar no botão "Salvar"
    document.getElementById("save-btn").onclick = () => salvarEdicaoProduto(index);
}

// Função para salvar as alterações feitas no produto
function salvarEdicaoProduto(index) {
    let produtos = JSON.parse(localStorage.getItem('produtos')) || []; // Recupera a lista de produtos do localStorage

    // Atualiza os dados do produto com os valores editados no modal
    produtos[index].nome = document.getElementById('edit-nome').value;
    produtos[index].id = document.getElementById('edit-id').value;
    produtos[index].quantidade = document.getElementById('edit-quantidade').value;
    produtos[index].valor = document.getElementById('edit-valor').value;

    // Salva os dados atualizados no localStorage
    localStorage.setItem('produtos', JSON.stringify(produtos));

    // Recarrega a lista de produtos para refletir as mudanças na interface
    carregarProdutos();

    // Fecha o modal após salvar
    fecharModal();

    // Exibe uma mensagem de confirmação de atualização
    alert('Produto atualizado com sucesso!');
}

// Função para fechar o modal
function fecharModal() {
    const modal = document.getElementById("modal"); // Seleciona o modal
    modal.style.display = "none"; // Oculta o modal
}

// Função para excluir um produto pelo ID
function excluirProduto() {
    const produtoId = prompt("Digite o ID do produto que deseja excluir:"); // Solicita o ID do produto para exclusão
    if (!produtoId) return; // Se nenhum ID for fornecido, interrompe a função

    const confirmacao = confirm(`Tem certeza que deseja excluir o produto com ID ${produtoId}?`); // Confirma a exclusão
    if (confirmacao) {
        let produtos = JSON.parse(localStorage.getItem('produtos')) || []; // Carrega a lista de produtos do localStorage
        const indexToRemove = produtos.findIndex(produto => produto.id === produtoId); // Busca o índice do produto a ser removido
        
        if (indexToRemove !== -1) {
            produtos.splice(indexToRemove, 1); // Remove o produto do array
            localStorage.setItem('produtos', JSON.stringify(produtos)); // Atualiza o localStorage com a nova lista
            carregarProdutos(); // Recarrega a lista de produtos na interface
            alert('Produto excluído com sucesso!');
        } else {
            alert('Produto não encontrado!'); // Informa se o produto não foi encontrado
        }
    }
}

// Função para redirecionar para a tela inicial
function voltarTelaAnterior() {
    window.location.href = 'inicial.html'; // Redireciona para a página inicial
}

// Inicializa o sistema de gerenciamento de produtos após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    const newProductButton = document.querySelector('.new-product-button'); // Seleciona o botão para novo produto
    if (newProductButton) {
        newProductButton.addEventListener('click', () => {
            window.location.href = 'NovoProduto.html'; // Redireciona para a página de novo produto
        });
    }

    const deleteButton = document.querySelector('.delete-button'); // Seleciona o botão de exclusão de produto
    if (deleteButton) {
        deleteButton.addEventListener('click', excluirProduto); // Adiciona o evento de exclusão ao botão
    }

    const backButton = document.querySelector('.back-button'); // Seleciona o botão de voltar
    if (backButton) {
        backButton.addEventListener('click', voltarTelaAnterior); // Adiciona o evento de redirecionamento ao botão de voltar
    }

    const closeButton = document.querySelector(".close-button"); // Seleciona o botão de fechar modal
    if (closeButton) {
        closeButton.addEventListener('click', fecharModal); // Adiciona o evento de fechamento ao botão de fechar
    }

    // Fecha o modal se o usuário clicar fora do conteúdo do modal
    const modal = document.getElementById("modal");
    window.onclick = function(event) {
        if (event.target === modal) {
            fecharModal(); // Fecha o modal se o clique for fora do conteúdo
        }
    };

    carregarProdutos(); // Carrega e exibe a lista de produtos ao iniciar
});
