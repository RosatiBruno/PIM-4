// Classe para gerenciar o botão de voltar
class BackButton {
    constructor(buttonSelector, targetUrl) {
        this.backButton = document.querySelector(buttonSelector); // Seleciona o botão de voltar usando o seletor fornecido
        this.targetUrl = targetUrl; // Armazena a URL para redirecionamento
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    // Inicializa os ouvintes de eventos para o botão
    initEventListeners() {
        if (this.backButton) { // Verifica se o botão existe
            this.backButton.addEventListener('click', () => this.redirecionar()); // Adiciona evento de clique que chama a função de redirecionamento
        }
    }

    // Função para redirecionar para a URL especificada
    redirecionar() {
        window.location.href = this.targetUrl; // Altera a localização da janela para a URL de destino
    }
}

// Classe para gerenciar o botão "Home"
class HomeButton {
    constructor(buttonSelector, targetUrl) {
        this.homeButton = document.querySelector(buttonSelector); // Seleciona o botão "Home" usando o seletor fornecido
        this.targetUrl = targetUrl; // Armazena a URL para redirecionamento
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    // Inicializa os ouvintes de eventos para o botão
    initEventListeners() {
        if (this.homeButton) { // Verifica se o botão existe
            this.homeButton.addEventListener('click', () => this.redirecionar()); // Adiciona evento de clique que chama a função de redirecionamento
        }
    }

    // Função para redirecionar para a URL especificada
    redirecionar() {
        window.location.href = this.targetUrl; // Altera a localização da janela para a URL de destino
    }
}

// Função para adicionar ou atualizar um pedido
function adicionarOuAtualizarPedido(isUpdating = false, pedidoId = null) {
    // Obtém os valores dos campos de entrada
    const nomeProduto = document.getElementById('nome-produto').value;
    const idPedido = document.getElementById('id-pedido').value;
    const quantidade = document.getElementById('quantidade').value;
    const valor = document.getElementById('valor').value;
    const empresaResponsavel = document.getElementById('empresa-responsavel').value;

    // Verifica se todos os campos foram preenchidos
    if (!nomeProduto || !idPedido || !quantidade || !valor || !empresaResponsavel) {
        alert('Por favor, preencha todos os campos.'); // Alerta se campos estiverem vazios
        return; // Interrompe a função
    }

    // Cria um objeto pedido com os dados coletados
    const pedido = {
        idPedido,
        nomeProduto,
        quantidade,
        valor,
        empresaResponsavel
    };

    // Obtém a lista de pedidos do localStorage
    let pedidos = JSON.parse(localStorage.getItem('pedidos')) || [];

    // Verifica se o pedido já existe e impede duplicação de ID ao adicionar um novo pedido
    if (!isUpdating) { // Se não estiver no modo de atualização
        const idExistente = pedidos.some(p => p.idPedido === idPedido); // Verifica se já existe um pedido com o mesmo ID
        if (idExistente) { // Se o ID já existir
            alert('Um pedido com esse ID já existe. Por favor, use um ID diferente.'); // Alerta para o usuário
            return; // Interrompe a função
        }
        pedidos.push(pedido); // Adiciona o novo pedido à lista
        alert('Pedido cadastrado com sucesso!'); // Confirmação de sucesso
    } else if (pedidoId !== null) { // Se estiver no modo de atualização
        // Atualiza o pedido existente se estiver no modo de atualização
        const index = pedidos.findIndex(p => p.idPedido === pedidoId); // Busca o índice do pedido com o ID correspondente
        if (index !== -1) { // Se o pedido foi encontrado
            pedidos[index] = pedido; // Atualiza o pedido existente
            alert('Pedido atualizado com sucesso!'); // Confirmação de sucesso
        }
    }

    localStorage.setItem('pedidos', JSON.stringify(pedidos)); // Salva a lista de pedidos atualizada no localStorage
    window.location.href = 'Vendas.html'; // Redireciona para a página de vendas
}

// Função para exibir os produtos cadastrados na tela
function exibirProdutosCadastrados() {
    const produtos = JSON.parse(localStorage.getItem('pedidos')) || []; // Obtém a lista de pedidos do localStorage
    const listaProdutos = document.getElementById('pedidos-lista'); // Seleciona o contêiner da lista de pedidos
    listaProdutos.innerHTML = ''; // Limpa a lista antes de adicionar novos elementos

    if (produtos.length === 0) { // Se não houver produtos
        listaProdutos.innerHTML = '<p>Nenhum produto cadastrado.</p>'; // Mensagem informando que não há produtos
        return; // Interrompe a função
    }

    // Para cada produto na lista, cria um elemento HTML para exibi-lo
    produtos.forEach(produto => {
        const produtoItem = document.createElement('div'); // Cria um novo elemento div para o produto
        produtoItem.innerHTML = `
            <p>ID do Pedido: ${produto.idPedido}</p>
            <p>Nome do Produto: ${produto.nomeProduto}</p>
            <p>Quantidade: ${produto.quantidade}</p>
            <p>Valor: ${produto.valor}</p>
            <p>Empresa Responsável: ${produto.empresaResponsavel}</p>
            <button onclick="preencherFormularioParaEdicao('${produto.idPedido}')">Editar</button>
            <hr>
        `; // Define o conteúdo HTML do elemento

        listaProdutos.appendChild(produtoItem); // Adiciona o item à lista de produtos
    });
}

// Função para preencher o formulário com dados de um pedido para edição
function preencherFormularioParaEdicao(idPedido) {
    const pedidos = JSON.parse(localStorage.getItem('pedidos')) || []; // Obtém a lista de pedidos do localStorage
    const pedido = pedidos.find(p => p.idPedido === idPedido); // Encontra o pedido com o ID correspondente

    if (pedido) { // Se o pedido foi encontrado
        // Preenche os campos do formulário com os dados do pedido
        document.getElementById('nome-produto').value = pedido.nomeProduto;
        document.getElementById('id-pedido').value = pedido.idPedido;
        document.getElementById('quantidade').value = pedido.quantidade;
        document.getElementById('valor').value = pedido.valor;
        document.getElementById('empresa-responsavel').value = pedido.empresaResponsavel;

        const addButton = document.querySelector('.add-button'); // Seleciona o botão de adicionar
        addButton.innerText = 'Atualizar Pedido'; // Altera o texto do botão para 'Atualizar Pedido'
        // Define a ação do botão de adicionar para chamar a função de atualizar com o ID do pedido
        addButton.onclick = (event) => {
            event.preventDefault(); // Previna o comportamento padrão do botão
            adicionarOuAtualizarPedido(true, idPedido); // Chama a função de adicionar ou atualizar pedido
        };
    }
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    new BackButton('.back-button', 'PedidosF.html'); // Cria uma nova instância do botão de voltar
    new HomeButton('.home-icon', 'inicialF.html'); // Cria uma nova instância do botão "Home"

    const addButton = document.querySelector('.add-button'); // Seleciona o botão de adicionar
    if (addButton) { // Verifica se o botão existe
        addButton.addEventListener('click', (event) => {
            event.preventDefault(); // Previna o comportamento padrão do botão
            adicionarOuAtualizarPedido(); // Chama a função de adicionar pedido
        });
    }

    exibirProdutosCadastrados(); // Chama a função para exibir os produtos cadastrados
});
