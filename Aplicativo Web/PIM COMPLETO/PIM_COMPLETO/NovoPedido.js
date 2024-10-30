// Classe para gerenciar o botão de voltar
class BackButton {
    constructor(buttonSelector, targetUrl) {
        this.backButton = document.querySelector(buttonSelector);
        this.targetUrl = targetUrl;
        this.initEventListeners();
    }

    initEventListeners() {
        if (this.backButton) {
            this.backButton.addEventListener('click', () => this.redirecionar());
        }
    }

    redirecionar() {
        window.location.href = this.targetUrl;
    }
}

// Classe para gerenciar o botão "Home"
class HomeButton {
    constructor(buttonSelector, targetUrl) {
        this.homeButton = document.querySelector(buttonSelector);
        this.targetUrl = targetUrl;
        this.initEventListeners();
    }

    initEventListeners() {
        if (this.homeButton) {
            this.homeButton.addEventListener('click', () => this.redirecionar());
        }
    }

    redirecionar() {
        window.location.href = this.targetUrl;
    }
}

// Função para adicionar ou atualizar um pedido
function adicionarOuAtualizarPedido(isUpdating = false, pedidoId = null) {
    const nomeProduto = document.getElementById('nome-produto').value;
    const idPedido = document.getElementById('id-pedido').value;
    const quantidade = document.getElementById('quantidade').value;
    const valor = document.getElementById('valor').value;
    const empresaResponsavel = document.getElementById('empresa-responsavel').value;

    if (!nomeProduto || !idPedido || !quantidade || !valor || !empresaResponsavel) {
        alert('Por favor, preencha todos os campos.');
        return;
    }

    const pedido = {
        idPedido,
        nomeProduto,
        quantidade,
        valor,
        empresaResponsavel
    };

    let pedidos = JSON.parse(localStorage.getItem('pedidos')) || [];

    // Verifica se o pedido já existe e impede duplicação de ID ao adicionar um novo pedido
    if (!isUpdating) {
        const idExistente = pedidos.some(p => p.idPedido === idPedido);
        if (idExistente) {
            alert('Um pedido com esse ID já existe. Por favor, use um ID diferente.');
            return;
        }
        pedidos.push(pedido);
        alert('Pedido cadastrado com sucesso!');
    } else if (pedidoId !== null) {
        // Atualiza o pedido existente se estiver no modo de atualização
        const index = pedidos.findIndex(p => p.idPedido === pedidoId);
        if (index !== -1) {
            pedidos[index] = pedido;
            alert('Pedido atualizado com sucesso!');
        }
    }

    localStorage.setItem('pedidos', JSON.stringify(pedidos));
    window.location.href = 'Vendas.html';
}

// Função para exibir os produtos cadastrados na tela
function exibirProdutosCadastrados() {
    const produtos = JSON.parse(localStorage.getItem('pedidos')) || [];
    const listaProdutos = document.getElementById('pedidos-lista');
    listaProdutos.innerHTML = '';

    if (produtos.length === 0) {
        listaProdutos.innerHTML = '<p>Nenhum produto cadastrado.</p>';
        return;
    }

    produtos.forEach(produto => {
        const produtoItem = document.createElement('div');
        produtoItem.innerHTML = `
            <p>ID do Pedido: ${produto.idPedido}</p>
            <p>Nome do Produto: ${produto.nomeProduto}</p>
            <p>Quantidade: ${produto.quantidade}</p>
            <p>Valor: ${produto.valor}</p>
            <p>Empresa Responsável: ${produto.empresaResponsavel}</p>
            <button onclick="abrirModalParaEdicao('${produto.idPedido}')">Editar</button>
            <hr>
        `;
        listaProdutos.appendChild(produtoItem);
    });
}

// Função para abrir o modal e permitir a edição dos dados do pedido
function abrirModalParaEdicao(idPedido) {
    const pedidos = JSON.parse(localStorage.getItem('pedidos')) || [];
    const pedido = pedidos.find(p => p.idPedido === idPedido);

    if (pedido) {
        const modal = document.getElementById('modal');
        const modalDetails = document.getElementById('modal-details');

        modalDetails.innerHTML = `
            <label for="nome">Nome:</label>
            <input type="text" id="nome" value="${pedido.nomeProduto || ''}"><br>
            <label for="id-pedido">ID do Pedido:</label>
            <input type="text" id="id-pedido" value="${pedido.idPedido}" disabled><br>
            <label for="quantidade">Quantidade:</label>
            <input type="number" id="quantidade" value="${pedido.quantidade || ''}"><br>
            <label for="valor">Valor:</label>
            <input type="text" id="valor" value="${pedido.valor || ''}"><br>
            <label for="empresa-responsavel">Empresa Responsável:</label>
            <input type="text" id="empresa-responsavel" value="${pedido.empresaResponsavel || ''}"><br>
            <button id="salvar-alteracoes">Salvar</button>
        `;
        modal.style.display = "block";

        document.getElementById('salvar-alteracoes').addEventListener('click', () => salvarAlteracoes(pedido.idPedido));
    }
}

// Função para salvar as alterações no localStorage
function salvarAlteracoes(idPedido) {
    let pedidos = JSON.parse(localStorage.getItem('pedidos')) || [];

    pedidos = pedidos.map(pedido => {
        if (pedido.idPedido === idPedido) {
            pedido.nomeProduto = document.getElementById('nome').value;
            pedido.quantidade = parseInt(document.getElementById('quantidade').value, 10); // Garantir a conversão correta
            pedido.valor = document.getElementById('valor').value;
            pedido.empresaResponsavel = document.getElementById('empresa-responsavel').value;
        }
        return pedido;
    });

    localStorage.setItem('pedidos', JSON.stringify(pedidos));

    fecharModal(); // Certifique-se de que esta função existe e fecha o modal
    alert('Alterações salvas com sucesso!');
    exibirProdutosCadastrados();
}

// Função para fechar o modal
function fecharModal() {
    const modal = document.getElementById('modal');
    modal.style.display = 'none';
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    new BackButton('.back-button', 'ListaPedidos.html');
    new HomeButton('.home-icon', 'inicial.html');

    const addButton = document.querySelector('.add-button');
    if (addButton) {
        addButton.addEventListener('click', (event) => {
            event.preventDefault();
            adicionarOuAtualizarPedido();
        });
    }

    exibirProdutosCadastrados();
});
