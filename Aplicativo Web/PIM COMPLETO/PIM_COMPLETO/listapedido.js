// Classe para gerenciar pedidos
class Pedido {
    constructor(pedidoSelector, editUrl) {
        this.pedidoElement = document.querySelector(pedidoSelector);
        this.editUrl = editUrl;
        this.initEventListeners();
    }

    initEventListeners() {
        if (this.pedidoElement) {
            this.pedidoElement.addEventListener('click', () => this.redirecionarParaEdicao());
        }
    }

    redirecionarParaEdicao() {
        // Adiciona a lógica para abrir o modal em vez de redirecionar
        const pedidoId = this.pedidoElement.dataset.id; // Supondo que o ID do pedido está em um data attribute
        const pedidos = JSON.parse(localStorage.getItem('pedidos')) || [];
        const pedido = pedidos.find(p => p.idPedido === pedidoId);

        if (pedido) {
            abrirModalParaEdicao(pedido);
        }
    }
}

// Classe para gerenciar novos pedidos
class NovoPedido {
    constructor(buttonSelector, newUrl) {
        this.novoPedidoButton = document.querySelector(buttonSelector);
        this.newUrl = newUrl;
        this.initEventListeners();
    }

    initEventListeners() {
        if (this.novoPedidoButton) {
            this.novoPedidoButton.addEventListener('click', () => this.redirecionarParaNovoPedido());
        }
    }

    redirecionarParaNovoPedido() {
        window.location.href = this.newUrl;
    }
}

// Classe para gerenciar o botão de voltar
class VoltarButton {
    constructor(buttonSelector, backUrl) {
        this.voltarButton = document.querySelector(buttonSelector);
        this.backUrl = backUrl;
        this.initEventListeners();
    }

    initEventListeners() {
        if (this.voltarButton) {
            this.voltarButton.addEventListener('click', () => this.voltarTelaAnterior());
        }
    }

    voltarTelaAnterior() {
        window.location.href = this.backUrl;
    }
}

// Função para abrir o modal e permitir a edição dos dados do pedido
function abrirModalParaEdicao(pedido) {
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

// Função para salvar as alterações no localStorage
function salvarAlteracoes(idPedido) {
    let pedidos = JSON.parse(localStorage.getItem('pedidos')) || [];

    pedidos = pedidos.map(pedido => {
        if (pedido.idPedido === idPedido) {
            pedido.nomeProduto = document.getElementById('nome').value;
            pedido.quantidade = parseInt(document.getElementById('quantidade').value, 10);
            pedido.valor = document.getElementById('valor').value;
            pedido.empresaResponsavel = document.getElementById('empresa-responsavel').value;
        }
        return pedido;
    });

    localStorage.setItem('pedidos', JSON.stringify(pedidos));

    fecharModal();
    alert('Alterações salvas com sucesso!');
    atualizarListaPedidos();
}

// Função para atualizar a lista de pedidos na página ListaPedidos.html
function atualizarListaPedidos() {
    const pedidosContainer = document.getElementById('pedidos-lista');
    const pedidos = JSON.parse(localStorage.getItem('pedidos')) || [];
    
    pedidosContainer.innerHTML = '';
    
    pedidos.forEach(pedido => {
        const pedidoElement = document.createElement('div');
        pedidoElement.textContent = `ID: ${pedido.idPedido}, Nome: ${pedido.nomeProduto}, Quantidade: ${pedido.quantidade || 'N/A'}, Valor: ${pedido.valor}, Empresa: ${pedido.empresaResponsavel || 'N/A'}`;
        pedidoElement.dataset.id = pedido.idPedido; // Armazenando o ID como um atributo data
        pedidoElement.addEventListener('click', () => abrirModalParaEdicao(pedido));
        pedidosContainer.appendChild(pedidoElement);
    });
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

    if (isUpdating && pedidoId !== null) {
        const index = pedidos.findIndex(p => p.idPedido === pedidoId);
        if (index !== -1) {
            pedidos[index] = pedido;
            alert('Pedido atualizado com sucesso!');
        }
    } else {
        const exists = pedidos.find(p => p.idPedido === idPedido);
        if (exists) {
            alert('Um pedido com esse ID já existe. Por favor, use um ID diferente.');
            return;
        }
        pedidos.push(pedido);
        alert('Pedido cadastrado com sucesso!');
    }

    localStorage.setItem('pedidos', JSON.stringify(pedidos));
    window.location.href = 'Vendas.html';
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    new VoltarButton('.back-button', 'ListaPedidos.html');
    new HomeButton('.home-button', 'inicial.html');

    const addButton = document.querySelector('.add-button');
    if (addButton) {
        addButton.addEventListener('click', (event) => {
            event.preventDefault();
            adicionarOuAtualizarPedido();
        });
    }

    atualizarListaPedidos(); // Chama a função para mostrar a lista de pedidos ao carregar a página
});
