// Classe para gerenciar os botões de navegação
class NavigationButton {
    constructor(buttonSelector, targetUrl) {
        // Seleciona o botão na página com base no seletor fornecido
        this.button = document.querySelector(buttonSelector);
        // Define a URL de destino para redirecionamento
        this.targetUrl = targetUrl;
        // Inicializa os event listeners
        this.initEventListeners();
    }

    initEventListeners() {
        // Se o botão existir, adiciona um event listener para redirecionar ao clicar
        if (this.button) {
            this.button.addEventListener('click', () => this.redirecionar());
        }
    }

    redirecionar() {
        // Redireciona o usuário para a URL de destino
        window.location.href = this.targetUrl;
    }
}

// Classe principal para gerenciar pedidos
class PedidoManager {
    constructor() {
        // Carrega os pedidos do localStorage ou inicializa como um array vazio
        this.pedidos = JSON.parse(localStorage.getItem('pedidos')) || [];
        // Inicializa o sistema chamando o método init
        this.init();
    }

    init() {
        // Cria botões de navegação para voltar e home
        new NavigationButton('.back-button', 'ListaPedidos.html');
        new NavigationButton('.home-icon', 'inicial.html');
        
        // Seleciona o botão de adicionar pedido
        const addButton = document.querySelector('.add-button');
        if (addButton) {
            // Adiciona um event listener ao botão de adicionar pedido
            addButton.addEventListener('click', (event) => {
                event.preventDefault(); // Previna o comportamento padrão do botão
                this.adicionarOuAtualizarPedido(); // Chama o método para adicionar ou atualizar o pedido
            });
        }

        // Exibe os produtos/pedidos cadastrados na tela
        this.exibirProdutosCadastrados();
    }

    adicionarOuAtualizarPedido(isUpdating = false, pedidoId = null) {
        // Coleta os valores dos campos de entrada do pedido
        const nomeProduto = document.getElementById('nome-produto').value;
        const idPedido = document.getElementById('id-pedido').value;
        const quantidade = document.getElementById('quantidade').value;
        const valor = document.getElementById('valor').value;
        const empresaResponsavel = document.getElementById('empresa-responsavel').value;

        // Verifica se todos os campos foram preenchidos
        if (!nomeProduto || !idPedido || !quantidade || !valor || !empresaResponsavel) {
            alert('Por favor, preencha todos os campos.');
            return;
        }

        // Define a data atual como a data de criação do pedido
        const dataCriacao = new Date().toISOString().split('T')[0]; // Formato YYYY-MM-DD

        // Cria um objeto para representar o pedido
        const pedido = {
            idPedido,
            nomeProduto,
            quantidade,
            valor,
            empresaResponsavel,
            dataCriacao
        };

        // Verifica se o pedido já existe ou se é um novo pedido
        if (!isUpdating) {
            // Verifica se o ID do pedido já existe
            const idExistente = this.pedidos.some(p => p.idPedido === idPedido);
            if (idExistente) {
                alert('Um pedido com esse ID já existe. Por favor, use um ID diferente.');
                return;
            }
            // Adiciona o novo pedido ao array de pedidos
            this.pedidos.push(pedido);
            alert('Pedido cadastrado com sucesso!');
        } else if (pedidoId !== null) {
            // Atualiza o pedido existente com os novos dados, mas mantém a data de criação original
            const index = this.pedidos.findIndex(p => p.idPedido === pedidoId);
            if (index !== -1) {
                this.pedidos[index] = { ...pedido, dataCriacao: this.pedidos[index].dataCriacao };
                alert('Pedido atualizado com sucesso!');
            }
        }

        // Salva o array de pedidos atualizado no localStorage
        localStorage.setItem('pedidos', JSON.stringify(this.pedidos));
        // Redireciona para a página de vendas
        window.location.href = 'Vendas.html';
    }

    exibirProdutosCadastrados() {
        // Seleciona o elemento onde os pedidos serão exibidos
        const listaProdutos = document.getElementById('pedidos-lista');
        listaProdutos.innerHTML = '';

        // Se não houver pedidos cadastrados, exibe uma mensagem
        if (this.pedidos.length === 0) {
            listaProdutos.innerHTML = '<p>Nenhum produto cadastrado.</p>';
            return;
        }

        // Para cada pedido, cria um elemento HTML para exibir seus detalhes
        this.pedidos.forEach(produto => {
            const produtoItem = document.createElement('div');
            produtoItem.innerHTML = `
                <p>ID do Pedido: ${produto.idPedido}</p>
                <p>Nome do Produto: ${produto.nomeProduto}</p>
                <p>Quantidade: ${produto.quantidade}</p>
                <p>Valor: ${produto.valor}</p>
                <p>Empresa Responsável: ${produto.empresaResponsavel}</p>
                <p>Data de Criação: ${produto.dataCriacao}</p> <!-- Exibe a data de criação do pedido -->
                <button onclick="pedidoManager.abrirModalParaEdicao('${produto.idPedido}')">Editar</button>
                <hr>
            `;
            listaProdutos.appendChild(produtoItem); // Adiciona o item à lista na página
        });
    }

    abrirModalParaEdicao(idPedido) {
        // Encontra o pedido que corresponde ao ID fornecido
        const pedido = this.pedidos.find(p => p.idPedido === idPedido);
        if (pedido) {
            // Preenche os campos do modal com os dados do pedido
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
            modal.style.display = "block"; // Exibe o modal

            // Adiciona um event listener ao botão de salvar no modal
            document.getElementById('salvar-alteracoes').addEventListener('click', () => this.salvarAlteracoes(pedido.idPedido));
        }
    }

    salvarAlteracoes(idPedido) {
        // Atualiza os dados do pedido no array de pedidos
        this.pedidos = this.pedidos.map(pedido => {
            if (pedido.idPedido === idPedido) {
                pedido.nomeProduto = document.getElementById('nome').value;
                pedido.quantidade = parseInt(document.getElementById('quantidade').value, 10);
                pedido.valor = document.getElementById('valor').value;
                pedido.empresaResponsavel = document.getElementById('empresa-responsavel').value;
            }
            return pedido;
        });

        // Salva o array de pedidos atualizado no localStorage
        localStorage.setItem('pedidos', JSON.stringify(this.pedidos));
        // Fecha o modal e exibe uma mensagem de sucesso
        this.fecharModal();
        alert('Alterações salvas com sucesso!');
        // Atualiza a lista de pedidos exibida
        this.exibirProdutosCadastrados();
    }

    fecharModal() {
        // Fecha o modal escondendo-o da tela
        const modal = document.getElementById('modal');
        modal.style.display = 'none';
    }
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Cria uma instância global de PedidoManager para gerenciar pedidos
    window.pedidoManager = new PedidoManager();
});
