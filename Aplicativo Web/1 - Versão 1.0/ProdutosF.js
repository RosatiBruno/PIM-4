// Classe para gerenciar a busca de produtos
class ProdutoSearch {
    constructor(searchBarSelector, productListSelector) {
        // Seleciona a barra de busca e a lista de produtos usando os seletores fornecidos
        this.searchBar = document.querySelector(searchBarSelector);
        this.productList = document.querySelector(productListSelector);
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    initEventListeners() {
        // Adiciona evento ao botão de busca para chamar a função de busca quando clicado
        document.querySelector('.search-bar button').addEventListener('click', () => this.buscarProduto());

        // Adiciona evento ao pressionar a tecla "Enter" na barra de busca
        this.searchBar.addEventListener('keyup', (event) => {
            if (event.key === 'Enter') {
                this.buscarProduto(); // Chama a função de busca se a tecla "Enter" for pressionada
            }
        });
    }

    buscarProduto() {
        // Converte o texto da barra de busca para maiúsculas para facilitar a comparação
        const filter = this.searchBar.value.toUpperCase();
        // Seleciona todos os itens da lista de produtos
        const productItems = this.productList.querySelectorAll('li');

        // Itera sobre cada item da lista de produtos
        productItems.forEach(item => {
            const txtValue = item.textContent || item.innerText; // Obtém o texto do item
            // Define a exibição do item com base na inclusão do filtro no texto
            item.style.display = txtValue.toUpperCase().includes(filter) ? '' : 'none';
        });
    }
}

// Função para carregar produtos do localStorage e exibi-los
function carregarProdutos() {
    // Obtém a lista de produtos do localStorage ou inicia com um array vazio
    const produtos = JSON.parse(localStorage.getItem('produtos')) || [];
    const produtosContainer = document.querySelector('.product-list');

    // Limpa o conteúdo do contêiner de produtos
    produtosContainer.innerHTML = '';

    // Verifica se não há produtos cadastrados
    if (produtos.length === 0) {
        produtosContainer.innerHTML = '<p>Nenhum produto cadastrado.</p>'; // Exibe mensagem de aviso
        return; // Sai da função
    }

    // Itera sobre cada produto e cria um item de lista
    produtos.forEach((produto, index) => {
        const produtoItem = document.createElement('li'); // Cria um novo elemento de lista
        produtoItem.classList.add('produto-item'); // Adiciona classe ao item
        produtoItem.textContent = produto.nome; // Mostra o nome do produto na lista
        // Adiciona um evento de clique para abrir o modal ao clicar no item
        produtoItem.addEventListener('click', () => {
            openModal(produto, index); // Passa o produto e seu índice para o modal
        });
        produtosContainer.appendChild(produtoItem); // Adiciona o item à lista de produtos
    });
}

// Função para abrir o modal com os detalhes do produto e permitir edição
function openModal(produto, index) {
    const modal = document.getElementById("modal"); // Seleciona o modal
    const modalDetails = document.getElementById("modal-details"); // Seleciona a área de detalhes do modal

    // Atualiza os campos do modal com os dados do produto
    modalDetails.innerHTML = `
        <label>Nome: <input type="text" id="edit-nome" value="${produto.nome}"></label><br>
        <label>ID: <input type="text" id="edit-id" value="${produto.id}" disabled></label><br>
        <label>Quantidade: <input type="number" id="edit-quantidade" value="${produto.quantidade}"></label><br>
        <label>Valor: <input type="number" id="edit-valor" value="${produto.valor}" step="0.01"></label><br>
    `;
    modal.style.display = "block"; // Exibe o modal

    // Função para salvar as alterações quando o botão de salvar é clicado
    document.getElementById("save-btn").onclick = () => salvarEdicaoProduto(index);
}

// Função para salvar as alterações feitas no produto
function salvarEdicaoProduto(index) {
    let produtos = JSON.parse(localStorage.getItem('produtos')) || []; // Obtém a lista de produtos

    // Atualiza os dados do produto com os valores editados
    produtos[index].nome = document.getElementById('edit-nome').value;
    produtos[index].id = document.getElementById('edit-id').value; // Atualiza o ID do produto
    produtos[index].quantidade = document.getElementById('edit-quantidade').value;
    produtos[index].valor = document.getElementById('edit-valor').value;

    // Salva os dados atualizados no localStorage
    localStorage.setItem('produtos', JSON.stringify(produtos));

    // Recarrega a lista de produtos para refletir as mudanças
    carregarProdutos();

    // Fecha o modal após salvar
    fecharModal();

    alert('Produto atualizado com sucesso!'); // Exibe mensagem de sucesso
}

// Função para fechar o modal
function fecharModal() {
    const modal = document.getElementById("modal");
    modal.style.display = "none"; // Esconde o modal
}

// Função para excluir produto pelo ID
function excluirProduto() {
    const produtoId = prompt("Digite o ID do produto que deseja excluir:"); // Pede o ID do produto ao usuário
    if (!produtoId) return; // Se não foi informado, sai da função

    const confirmacao = confirm(`Tem certeza que deseja excluir o produto com ID ${produtoId}?`); // Confirma a exclusão
    if (confirmacao) {
        let produtos = JSON.parse(localStorage.getItem('produtos')) || []; // Obtém a lista de produtos
        const indexToRemove = produtos.findIndex(produto => produto.id === produtoId); // Encontra o índice do produto a ser removido
        
        if (indexToRemove !== -1) {
            produtos.splice(indexToRemove, 1); // Remove o produto do array
            localStorage.setItem('produtos', JSON.stringify(produtos)); // Atualiza o localStorage
            carregarProdutos(); // Recarrega a lista de produtos
            alert('Produto excluído com sucesso!'); // Mensagem de sucesso
        } else {
            alert('Produto não encontrado!'); // Mensagem de erro se não encontrar o produto
        }
    }
}

// Função para redirecionar para a tela anterior
function voltarTelaAnterior() {
    window.location.href = 'inicialF.html'; // Redireciona para a página inicial
}

// Inicializa o sistema de gerenciamento de produtos após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    const newProductButton = document.querySelector('.new-product-button'); // Seleciona o botão de novo produto
    if (newProductButton) {
        newProductButton.addEventListener('click', () => {
            window.location.href = 'NovoProdutoF.html'; // Redireciona para a página de novo produto
        });
    }

    // Evento para o botão de voltar
    const backButton = document.querySelector('.back-button'); // Seleciona o botão de voltar
    if (backButton) {
        backButton.addEventListener('click', voltarTelaAnterior); // Adiciona o evento de voltar
    }

    // Evento para fechar o modal
    const closeButton = document.querySelector(".close-button"); // Seleciona o botão de fechar modal
    if (closeButton) {
        closeButton.addEventListener('click', fecharModal); // Adiciona o evento de fechar modal
    }

    // Fecha o modal se o usuário clicar fora do conteúdo do modal
    const modal = document.getElementById("modal");
    window.onclick = function(event) {
        if (event.target === modal) {
            fecharModal(); // Fecha o modal se clicar fora
        }
    };

    // Carrega os produtos ao iniciar
    carregarProdutos(); // Chama a função para carregar e exibir produtos
});
