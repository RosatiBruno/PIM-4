// Classe para gerenciar pedidos
class PedidoManager {
    // Construtor que recebe o ID da tabela onde os pedidos serão exibidos
    constructor(tabelaId) {
        this.tabelaVendas = document.getElementById(tabelaId); // Seleciona a tabela pelo ID fornecido e a armazena em uma propriedade
    }

    // Método para carregar os pedidos armazenados no localStorage e exibi-los na tabela
    carregarPedidos() {
        // Recupera os pedidos armazenados no localStorage e converte de JSON para um array de objetos; caso não haja pedidos, cria um array vazio
        const pedidos = JSON.parse(localStorage.getItem('pedidos')) || [];

        // Verifica se não há pedidos; se não houver, exibe uma mensagem informando que não há pedidos cadastrados
        if (pedidos.length === 0) {
            this.exibirMensagemSemPedidos(); // Chama o método para exibir a mensagem de "Nenhum pedido cadastrado"
            return; // Encerra o método para evitar processar o restante do código
        }

        // Itera sobre cada pedido no array de pedidos
        pedidos.forEach((pedido) => {
            this.adicionarPedidoNaTabela(pedido); // Adiciona cada pedido na tabela chamando o método específico
        });
    }

    // Método para exibir uma mensagem informando que não há pedidos cadastrados
    exibirMensagemSemPedidos() {
        const linhaVazia = document.createElement('tr'); // Cria uma nova linha para a tabela
        // Define o conteúdo da linha com a mensagem e define o atributo colspan para que a mensagem ocupe todas as colunas
        linhaVazia.innerHTML = '<td colspan="7">Nenhum pedido cadastrado.</td>';
        this.tabelaVendas.appendChild(linhaVazia); // Adiciona a linha à tabela
    }

    // Método para adicionar um pedido na tabela
    adicionarPedidoNaTabela(pedido) {
        const novaLinha = document.createElement('tr'); // Cria uma nova linha para o pedido
        const total = (pedido.quantidade * pedido.valor).toFixed(2); // Calcula o valor total (quantidade * valor unitário) e formata para duas casas decimais

        // Define o conteúdo HTML da nova linha com os dados do pedido
        novaLinha.innerHTML = `
            <td>${pedido.idPedido}</td>
            <td>${new Date().toLocaleDateString()}</td> <!-- Insere a data atual formatada -->
            <td>${pedido.nomeProduto}</td>
            <td>${pedido.quantidade}</td>
            <td>R$ ${pedido.valor}</td>
            <td>R$ ${total}</td>
            <td>${pedido.empresaResponsavel}</td>
        `;
        this.tabelaVendas.appendChild(novaLinha); // Adiciona a nova linha à tabela de vendas
    }
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Cria uma instância de PedidoManager, passando o ID da tabela onde os pedidos serão exibidos
    const pedidoManager = new PedidoManager('vendas-table');
    pedidoManager.carregarPedidos(); // Chama o método para carregar e exibir os pedidos na tabela
});
