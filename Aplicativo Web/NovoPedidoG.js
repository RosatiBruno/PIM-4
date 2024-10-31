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
            <button onclick="preencherFormularioParaEdicao('${produto.idPedido}')">Editar</button>
            <hr>
        `;
        listaProdutos.appendChild(produtoItem);
    });
}

// Função para preencher o formulário com dados de um pedido para edição
function preencherFormularioParaEdicao(idPedido) {
    const pedidos = JSON.parse(localStorage.getItem('pedidos')) || [];
    const pedido = pedidos.find(p => p.idPedido === idPedido);

    if (pedido) {
        document.getElementById('nome-produto').value = pedido.nomeProduto;
        document.getElementById('id-pedido').value = pedido.idPedido;
        document.getElementById('quantidade').value = pedido.quantidade;
        document.getElementById('valor').value = pedido.valor;
        document.getElementById('empresa-responsavel').value = pedido.empresaResponsavel;

        const addButton = document.querySelector('.add-button');
        addButton.innerText = 'Atualizar Pedido';
        addButton.onclick = (event) => {
            event.preventDefault();
            adicionarOuAtualizarPedido(true, idPedido);
        };
    }
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    new BackButton('.back-button', 'ListaPedidosG.html');
    new HomeButton('.home-icon', 'inicialGerente.html');

    const addButton = document.querySelector('.add-button');
    if (addButton) {
        addButton.addEventListener('click', (event) => {
            event.preventDefault();
            adicionarOuAtualizarPedido();
        });
    }

    exibirProdutosCadastrados();
});
