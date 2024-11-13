// Classe principal para gerenciar pedidos
class PedidoManager {
    constructor() {
        this.pedidos = JSON.parse(localStorage.getItem('pedidos')) || []; // Obtém a lista de pedidos do localStorage
    }

    abrirModalParaEdicao(pedido) {
        const modal = document.getElementById('modal'); // Seleciona o modal pelo ID
        const modalDetails = document.getElementById('modal-details'); // Seleciona a parte do modal onde os detalhes serão mostrados

        // Preenche o modal com campos de edição, usando os dados do pedido
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
        modal.style.display = "block"; // Torna o modal visível

        // Adiciona um ouvinte de clique no botão de salvar alterações
        document.getElementById('salvar-alteracoes').addEventListener('click', () => this.salvarAlteracoes(pedido.idPedido));
    }

    salvarAlteracoes(idPedido) {
        // Mapeia os pedidos para atualizar os dados do pedido específico
        this.pedidos = this.pedidos.map(pedido => {
            if (pedido.idPedido === idPedido) {
                // Atualiza os campos do pedido com os novos valores
                pedido.nomeProduto = document.getElementById('nome').value;
                pedido.quantidade = parseInt(document.getElementById('quantidade').value, 10);
                pedido.valor = document.getElementById('valor').value;
                pedido.empresaResponsavel = document.getElementById('empresa-responsavel').value;
            }
            return pedido; // Retorna o pedido (atualizado ou não)
        });

        localStorage.setItem('pedidos', JSON.stringify(this.pedidos)); // Salva a lista de pedidos atualizada no localStorage

        this.fecharModal(); // Fecha o modal
        alert('Alterações salvas com sucesso!'); // Exibe uma mensagem de confirmação
        this.atualizarListaPedidos(); // Atualiza a lista de pedidos na página
    }

    atualizarListaPedidos() {
        const pedidosContainer = document.getElementById('pedidos-lista'); // Seleciona o contêiner onde os pedidos serão listados
        pedidosContainer.innerHTML = ''; // Limpa o contêiner antes de repopular

        // Itera sobre cada pedido e cria um elemento para exibi-lo
        this.pedidos.forEach(pedido => {
            const pedidoElement = document.createElement('div'); // Cria um novo elemento div para cada pedido
            pedidoElement.textContent = `ID: ${pedido.idPedido}, Nome: ${pedido.nomeProduto}, Quantidade: ${pedido.quantidade || 'N/A'}, Valor: ${pedido.valor}, Empresa: ${pedido.empresaResponsavel || 'N/A'}`; // Preenche o texto do elemento com detalhes do pedido
            pedidoElement.dataset.id = pedido.idPedido; // Armazena o ID do pedido como um atributo data
            pedidoElement.addEventListener('click', () => this.abrirModalParaEdicao(pedido)); // Adiciona um ouvinte de clique para abrir o modal de edição do pedido
            pedidosContainer.appendChild(pedidoElement); // Adiciona o elemento do pedido ao contêiner
        });
    }

    fecharModal() {
        const modal = document.getElementById('modal'); // Seleciona o modal pelo ID
        modal.style.display = "none"; // Oculta o modal
    }
}

// Classe para gerenciar pedidos
class Pedido {
    constructor(pedidoSelector, editUrl, pedidoManager) {
        this.pedidoElement = document.querySelector(pedidoSelector); // Seleciona o elemento do pedido na página baseado no seletor fornecido
        this.editUrl = editUrl; // Armazena a URL de edição do pedido
        this.pedidoManager = pedidoManager; // Armazena a instância do PedidoManager
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    initEventListeners() {
        if (this.pedidoElement) { // Verifica se o elemento do pedido existe
            this.pedidoElement.addEventListener('click', () => this.redirecionarParaEdicao()); // Adiciona um ouvinte de clique que chama a função de redirecionamento para edição
        }
    }

    redirecionarParaEdicao() {
        const pedidoId = this.pedidoElement.dataset.id; // Obtém o ID do pedido a partir de um atributo data do elemento
        const pedido = this.pedidoManager.pedidos.find(p => p.idPedido === pedidoId); // Encontra o pedido correspondente ao ID

        if (pedido) {
            this.pedidoManager.abrirModalParaEdicao(pedido); // Abre o modal para edição se o pedido for encontrado
        }
    }
}

// Classe para gerenciar novos pedidos
class NovoPedido {
    constructor(buttonSelector, newUrl, pedidoManager) {
        this.novoPedidoButton = document.querySelector(buttonSelector); // Seleciona o botão para novo pedido
        this.newUrl = newUrl; // Armazena a URL para a nova página de pedido
        this.pedidoManager = pedidoManager; // Armazena a instância do PedidoManager
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    initEventListeners() {
        if (this.novoPedidoButton) { // Verifica se o botão existe
            this.novoPedidoButton.addEventListener('click', () => this.redirecionarParaNovoPedido()); // Adiciona um ouvinte de clique para redirecionar para a nova página de pedido
        }
    }

    redirecionarParaNovoPedido() {
        window.location.href = this.newUrl; // Redireciona o navegador para a nova URL
    }
}

// Classe para gerenciar o botão de voltar
class VoltarButton {
    constructor(buttonSelector, backUrl) {
        this.voltarButton = document.querySelector(buttonSelector); // Seleciona o botão de voltar
        this.backUrl = backUrl; // Armazena a URL de onde voltar
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    initEventListeners() {
        if (this.voltarButton) { // Verifica se o botão existe
            this.voltarButton.addEventListener('click', () => this.voltarTelaAnterior()); // Adiciona um ouvinte de clique para voltar à tela anterior
        }
    }

    voltarTelaAnterior() {
        window.location.href = this.backUrl; // Redireciona o navegador para a URL anterior
    }
}

// Classe para gerenciar o botão "Home"
class HomeButton {
    constructor(buttonSelector, targetUrl) {
        this.homeButton = document.querySelector(buttonSelector); // Seleciona o botão "Home"
        this.targetUrl = targetUrl; // Armazena a URL para redirecionar ao clicar
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    initEventListeners() {
        if (this.homeButton) { // Verifica se o botão existe
            this.homeButton.addEventListener('click', () => this.redirecionar()); // Adiciona um ouvinte de clique para redirecionar
        }
    }

    redirecionar() {
        window.location.href = this.targetUrl; // Redireciona para a URL do botão "Home"
    }
}

// Inicialização das classes
const pedidoManager = new PedidoManager();
const pedidos = document.querySelectorAll('.pedido'); // Seleciona todos os elementos que representam pedidos
pedidos.forEach(pedidoElement => new Pedido(pedidoElement, 'editUrl', pedidoManager)); // Instancia a classe Pedido para cada elemento
const novoPedidoButton = new NovoPedido('#novo-pedido-button', 'nova-pagina.html', pedidoManager); // Instancia a classe NovoPedido
const voltarButton = new VoltarButton('#voltar-button', 'pagina_anterior.html'); // Instancia a classe VoltarButton
const homeButton = new HomeButton('#home-button', 'home.html'); // Instancia a classe HomeButton

// Atualiza a lista de pedidos ao carregar a página
pedidoManager.atualizarListaPedidos();
