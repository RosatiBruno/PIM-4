// Função para carregar os pedidos armazenados no localStorage e exibi-los na tabela
function carregarPedidos() {
    // Seleciona o elemento da tabela onde os pedidos serão exibidos
    const tabelaVendas = document.getElementById('vendas-table');
    
    // Obtém os pedidos do localStorage e converte de JSON para array. Se não houver pedidos, define um array vazio.
    const pedidos = JSON.parse(localStorage.getItem('pedidos')) || [];

    // Se não houver pedidos armazenados, cria uma linha na tabela informando que não há pedidos cadastrados
    if (pedidos.length === 0) {
        const linhaVazia = document.createElement('tr'); // Cria uma nova linha (tr) na tabela
        // Define o conteúdo da linha com uma célula que ocupa todas as colunas, mostrando a mensagem
        linhaVazia.innerHTML = '<td colspan="7">Nenhum pedido cadastrado.</td>';
        tabelaVendas.appendChild(linhaVazia); // Adiciona a linha à tabela
        return; // Finaliza a função, já que não há pedidos a exibir
    }

    // Caso haja pedidos, exibe cada um na tabela
    pedidos.forEach((pedido) => {
        const novaLinha = document.createElement('tr'); // Cria uma nova linha para cada pedido
        // Calcula o total multiplicando a quantidade pelo valor do produto e limita o valor a 2 casas decimais
        const total = (pedido.quantidade * pedido.valor).toFixed(2); 

        // Define o conteúdo da linha, preenchendo cada célula com as informações do pedido
        novaLinha.innerHTML = `
            <td>${pedido.idPedido}</td>                <!-- Exibe o ID do pedido -->
            <td>${new Date().toLocaleDateString()}</td> <!-- Exibe a data atual (pode ser adaptada) -->
            <td>${pedido.nomeProduto}</td>              <!-- Exibe o nome do produto -->
            <td>${pedido.quantidade}</td>               <!-- Exibe a quantidade de produtos -->
            <td>R$ ${pedido.valor}</td>                 <!-- Exibe o valor unitário do produto -->
            <td>R$ ${total}</td>                        <!-- Exibe o total calculado (quantidade * valor) -->
            <td>${pedido.empresaResponsavel}</td>       <!-- Exibe o nome da empresa responsável pelo pedido -->
        `;
        // Adiciona a nova linha à tabela
        tabelaVendas.appendChild(novaLinha);
    });
}

// Chama a função para carregar os pedidos quando a página for carregada (evento 'DOMContentLoaded')
document.addEventListener('DOMContentLoaded', carregarPedidos);
