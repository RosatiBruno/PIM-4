// Classe para gerenciar os botões de navegação
class NavigationButton {
    // Construtor que recebe um seletor do botão e a URL de destino
    constructor(buttonSelector, targetUrl) {
        this.button = document.querySelector(buttonSelector); // Seleciona o botão pelo seletor
        this.targetUrl = targetUrl; // Define a URL de destino para o redirecionamento
        this.initEventListeners(); // Inicializa os event listeners do botão
    }

    // Método para adicionar um listener de evento de clique ao botão
    initEventListeners() {
        if (this.button) { // Verifica se o botão foi encontrado
            this.button.addEventListener('click', () => this.redirecionar()); // Adiciona evento de clique que chama o método redirecionar
        }
    }

    // Método para redirecionar para a URL de destino
    redirecionar() {
        window.location.href = this.targetUrl; // Redireciona o navegador para a URL definida
    }
}

// Classe principal para gerenciar pedidos
class PedidoManager {
    // Construtor da classe
    constructor() {
        this.pedidos = JSON.parse(localStorage.getItem('pedidos')) || []; // Carrega os pedidos do localStorage ou inicia com um array vazio
        this.init(); // Inicializa os eventos e funcionalidades
    }

    // Método de inicialização dos eventos e configurações iniciais
    init() {
        // Cria botões de navegação para retornar à lista de pedidos e à página inicial
        new NavigationButton('.back-button', 'ListaPedidosG.html');
        new NavigationButton('.home-icon', 'inicialGerente.html');
        
        // Adiciona evento ao botão de adicionar pedido
        const addButton = document.querySelector('.add-button');
        if (addButton) {
            addButton.addEventListener('click', (event) => {
                event.preventDefault(); // Impede o comportamento padrão do botão
                this.adicionarOuAtualizarPedido(); // Chama o método para adicionar ou atualizar o pedido
            });
        }

        this.exibirProdutosCadastrados(); // Exibe a lista de pedidos cadastrados na página
    }

    // Método para adicionar ou atualizar um pedido
    adicionarOuAtualizarPedido(isUpdating = false, pedidoId = null) {
        // Obtém os valores dos campos de entrada
        const nomeProduto = document.getElementById('nome-produto').value;
        const idPedido = document.getElementById('id-pedido').value;
        const quantidade = document.getElementById('quantidade').value;
        const valor = document.getElementById('valor').value;
        const empresaResponsavel = document.getElementById('empresa-responsavel').value;

        // Valida se todos os campos estão preenchidos
        if (!nomeProduto || !idPedido || !quantidade || !valor || !empresaResponsavel) {
            alert('Por favor, preencha todos os campos.');
            return;
        }

        // Cria um objeto de pedido com os valores coletados
        const pedido = {
            idPedido,
            nomeProduto,
            quantidade,
            valor,
            empresaResponsavel
        };

        // Verifica se o pedido está sendo adicionado ou atualizado
        if (!isUpdating) {
            // Verifica se o ID do pedido já existe
            const idExistente = this.pedidos.some(p => p.idPedido === idPedido);
            if (idExistente) {
                alert('Um pedido com esse ID já existe. Por favor, use um ID diferente.');
                return;
            }
            this.pedidos.push(pedido); // Adiciona o novo pedido ao array de pedidos
            alert('Pedido cadastrado com sucesso!');
        } else if (pedidoId !== null) {
            // Atualiza o pedido existente no array de pedidos
            const index = this.pedidos.findIndex(p => p.idPedido === pedidoId);
            if (index !== -1) {
                this.pedidos[index] = pedido; // Atualiza o pedido no índice encontrado
                alert('Pedido atualizado com sucesso!');
            }
        }

        // Salva os pedidos atualizados no localStorage
        localStorage.setItem('pedidos', JSON.stringify(this.pedidos));
        window.location.href = 'Vendas.html'; // Redireciona para a página de vendas
    }

    // Método para exibir a lista de produtos cadastrados
    exibirProdutosCadastrados() {
        const listaProdutos = document.getElementById('pedidos-lista'); // Seleciona o elemento da lista de pedidos
        listaProdutos.innerHTML = ''; // Limpa o conteúdo da lista

        // Exibe uma mensagem caso não haja produtos cadastrados
        if (this.pedidos.length === 0) {
            listaProdutos.innerHTML = '<p>Nenhum produto cadastrado.</p>';
            return;
        }

        // Para cada pedido, cria um elemento HTML e adiciona à lista
        this.pedidos.forEach(produto => {
            const produtoItem = document.createElement('div'); // Cria um elemento de div para cada produto
            produtoItem.innerHTML = `
                <p>ID do Pedido: ${produto.idPedido}</p>
                <p>Nome do Produto: ${produto.nomeProduto}</p>
                <p>Quantidade: ${produto.quantidade}</p>
                <p>Valor: ${produto.valor}</p>
                <p>Empresa Responsável: ${produto.empresaResponsavel}</p>
                <button onclick="pedidoManager.abrirModalParaEdicao('${produto.idPedido}')">Editar</button>
                <hr>
            `;
            listaProdutos.appendChild(produtoItem); // Adiciona o item do produto à lista de produtos
        });
    }

    // Método para abrir o modal de edição com os dados do pedido
    abrirModalParaEdicao(idPedido) {
        const pedido = this.pedidos.find(p => p.idPedido === idPedido); // Encontra o pedido pelo ID
        if (pedido) {
            const modal = document.getElementById('modal'); // Seleciona o modal
            const modalDetails = document.getElementById('modal-details'); // Seleciona a área de detalhes do modal

            // Popula o modal com os dados do pedido para edição
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
            modal.style.display = "block"; // Exibe o modal

            // Adiciona o evento de salvar ao botão de salvar alterações
            document.getElementById('salvar-alteracoes').addEventListener('click', () => this.salvarAlteracoes(pedido.idPedido));
        }
    }

    // Método para salvar as alterações feitas no pedido
    salvarAlteracoes(idPedido) {
        this.pedidos = this.pedidos.map(pedido => {
            if (pedido.idPedido === idPedido) {
                pedido.nomeProduto = document.getElementById('nome').value;
                pedido.quantidade = parseInt(document.getElementById('quantidade').value, 10);
                pedido.valor = document.getElementById('valor').value;
                pedido.empresaResponsavel = document.getElementById('empresa-responsavel').value;
            }
            return pedido; // Retorna o pedido atualizado
        });

        localStorage.setItem('pedidos', JSON.stringify(this.pedidos)); // Salva a lista atualizada no localStorage
        this.fecharModal(); // Fecha o modal
        alert('Alterações salvas com sucesso!');
        this.exibirProdutosCadastrados(); // Atualiza a lista de produtos exibidos
    }

    // Método para fechar o modal de edição
    fecharModal() {
        const modal = document.getElementById('modal'); // Seleciona o modal
        modal.style.display = 'none'; // Oculta o modal
    }
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    window.pedidoManager = new PedidoManager(); // Cria uma instância do gerenciador de pedidos
});
