// Classe para gerenciar o redirecionamento de pedidos
class Pedido {
    constructor(pedidoSelector, editUrl) {
        this.pedido = document.querySelector(pedidoSelector);
        this.editUrl = editUrl;
        this.initEventListeners();
    }

    initEventListeners() {
        if (this.pedido) {
            this.pedido.addEventListener('click', () => this.redirecionarParaEdicao());
        }
    }

    redirecionarParaEdicao() {
        window.location.href = this.editUrl;
    }
}

// Classe para gerenciar o redirecionamento de novos pedidos
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

// Função para deletar um pedido pelo ID
function deletarPedido(id) {
    if (confirm(`Tem certeza que deseja excluir o pedido com ID ${id}?`)) {
        let pedidos = JSON.parse(localStorage.getItem('pedidos')) || [];
        pedidos = pedidos.filter(pedido => pedido.idPedido !== id);

        localStorage.setItem('pedidos', JSON.stringify(pedidos));
        alert(`Pedido com ID ${id} excluído com sucesso!`);
        window.location.reload();
    }
}

// Função para abrir o modal e permitir a edição dos dados do pedido
function abrirModalParaEdicao(pedido) {
    const modal = document.getElementById('modal');
    const modalDetails = document.getElementById('modal-details');

    // Preenche o modal com os dados atuais do pedido e adiciona campos editáveis, incluindo Empresa Responsável
    modalDetails.innerHTML = `
        <label for="nome">Nome:</label>
        <input type="text" id="nome" value="${pedido.nome}"><br>
        <label for="quantidade">Quantidade:</label>
        <input type="number" id="quantidade" value="${pedido.quantidade}"><br>
        <label for="valor">Valor:</label>
        <input type="text" id="valor" value="${pedido.valor}"><br>
        <label for="empresa">Empresa Responsável:</label>
        <input type="text" id="empresa" value="${pedido.empresa}"><br>
    `;
    modal.style.display = "block";

    // Adiciona evento de clique ao botão "Salvar" para salvar as edições
    document.getElementById('salvar-alteracoes').addEventListener('click', () => salvarAlteracoes(pedido.idPedido));
}

// Função para salvar as alterações no localStorage e atualizar as páginas
function salvarAlteracoes(idPedido) {
    let pedidos = JSON.parse(localStorage.getItem('pedidos')) || [];

    // Localiza o pedido pelo ID e atualiza seus dados, incluindo Empresa Responsável
    pedidos = pedidos.map(pedido => {
        if (pedido.idPedido === idPedido) {
            pedido.nome = document.getElementById('nome').value;
            pedido.quantidade = document.getElementById('quantidade').value;
            pedido.valor = document.getElementById('valor').value;
            pedido.empresa = document.getElementById('empresa').value;  // Atualiza empresa responsável
        }
        return pedido;
    });

    // Salva os dados atualizados no localStorage
    localStorage.setItem('pedidos', JSON.stringify(pedidos));

    // Fecha o modal e recarrega as páginas relevantes
    fecharModal();
    alert('Alterações salvas com sucesso!');
    atualizarListaPedidos();
    atualizarTelaVendas();
}

// Função para fechar o modal
function fecharModal() {
    const modal = document.getElementById('modal');
    modal.style.display = "none";
}

// Função para atualizar a lista de pedidos na página ListaPedidos.html
function atualizarListaPedidos() {
    const pedidosContainer = document.getElementById('pedidos-lista');
    const pedidos = JSON.parse(localStorage.getItem('pedidos')) || [];
    
    pedidosContainer.innerHTML = ''; // Limpa a lista para re-renderizar
    
    pedidos.forEach(pedido => {
        const pedidoElement = document.createElement('div');
        pedidoElement.textContent = `Pedido: ${pedido.nome}, Quantidade: ${pedido.quantidade}, Valor: ${pedido.valor}, Empresa: ${pedido.empresa}`;
        pedidoElement.addEventListener('click', () => abrirModalParaEdicao(pedido));
        pedidosContainer.appendChild(pedidoElement);
    });
}

// Função para atualizar os dados na página Vendas.html
function atualizarTelaVendas() {
    const vendasContainer = document.getElementById('vendas-lista');
    const pedidos = JSON.parse(localStorage.getItem('pedidos')) || [];

    vendasContainer.innerHTML = ''; // Limpa a lista para re-renderizar

    pedidos.forEach(pedido => {
        const pedidoElement = document.createElement('div');
        pedidoElement.textContent = `Pedido: ${pedido.nome}, Quantidade: ${pedido.quantidade}, Valor: ${pedido.valor}, Empresa: ${pedido.empresa}`;
        pedidoElement.addEventListener('click', () => abrirModalParaEdicao(pedido));
        vendasContainer.appendChild(pedidoElement);
    });
}

// Função para inicializar os pedidos dinamicamente
function inicializarPedidos() {
    const pedidos = JSON.parse(localStorage.getItem('pedidos')) || [];

    pedidos.forEach(pedido => {
        // Adiciona evento de clique para abrir o modal de edição
        document.querySelector(pedido.selector).addEventListener('click', () => abrirModalParaEdicao(pedido));
    });
}

// Inicializa o sistema de gerenciamento de pedidos após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    new NovoPedido('.novo-pedido', 'NovoPedidoF.html');
    new VoltarButton('.back-button', 'inicialF.html');

    const excluirButton = document.querySelector('.delete-button');
    if (excluirButton) {
        excluirButton.addEventListener('click', () => {
            const idPedido = prompt("Digite o ID do pedido que deseja excluir:");
            if (idPedido) {
                deletarPedido(idPedido);
            }
        });
    }

    inicializarPedidos(); // Inicializa os pedidos dinamicamente
    atualizarListaPedidos(); // Atualiza a lista de pedidos na tela de lista de pedidos
    atualizarTelaVendas(); // Atualiza a lista de vendas na tela de vendas
});
