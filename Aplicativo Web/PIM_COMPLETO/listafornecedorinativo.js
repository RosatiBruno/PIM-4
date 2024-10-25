// Função para carregar fornecedores inativos do localStorage e exibi-los
function carregarFornecedoresInativos() {
    // Obtém a lista de fornecedores inativos do localStorage, ou inicializa um array vazio se não houver dados
    const fornecedoresInativos = JSON.parse(localStorage.getItem('fornecedoresInativos')) || [];
    // Seleciona o contêiner onde os fornecedores inativos serão exibidos
    const fornecedoresContainer = document.querySelector('.supplier-list-inactive');

    // Limpa o contêiner antes de adicionar novos itens
    fornecedoresContainer.innerHTML = '';

    // Verifica se há fornecedores inativos
    if (fornecedoresInativos.length === 0) {
        // Exibe uma mensagem se não houver fornecedores inativos
        fornecedoresContainer.innerHTML = '<p>Nenhum fornecedor inativado.</p>';
        return; // Sai da função se não houver fornecedores
    }

    // Itera sobre a lista de fornecedores inativos
    fornecedoresInativos.forEach((fornecedor, index) => {
        // Cria um elemento para cada fornecedor inativo
        const fornecedorItem = document.createElement('div');
        fornecedorItem.classList.add('fornecedor-item-inativo'); // Adiciona uma classe ao elemento
        fornecedorItem.id = `inativo${index + 1}`; // Define um ID único para o item inativo
        // Preenche o HTML do item com as informações do fornecedor
        fornecedorItem.innerHTML = `
            <div class="fornecedor-card">
                <h3>Fornecedor ${index + 1}</h3>
                <p><strong>Nome:</strong> ${fornecedor.nome}</p>
                <p><strong>Telefone:</strong> ${fornecedor.telefone}</p>
                <p><strong>CNPJ/CPF:</strong> ${fornecedor.cnpj}</p>
                <p><strong>Endereço:</strong> ${fornecedor.endereco}</p>
                <p><strong>Email:</strong> ${fornecedor.email}</p>
                <p><strong>Cidade:</strong> ${fornecedor.cidade}</p> <!-- Exibe a cidade -->
                <p><strong>Estado:</strong> ${fornecedor.estado}</p> <!-- Exibe o estado -->
                <p><strong>Representante:</strong> ${fornecedor.representante}</p> <!-- Exibe o representante -->
                <p><strong>Matéria-prima:</strong> ${fornecedor.materiaPrima}</p> <!-- Exibe a matéria-prima -->
                <hr>
            </div>
        `;
        // Adiciona o elemento do fornecedor à lista de fornecedores inativos
        fornecedoresContainer.appendChild(fornecedorItem);
    });
}

// Função para reativar um fornecedor
function reativarFornecedor() {
    // Solicita ao usuário o ID do fornecedor que deseja reativar
    const fornecedorId = prompt("Informe o ID do fornecedor que deseja reativar:");
    if (fornecedorId) { // Verifica se o usuário forneceu um ID
        // Seleciona o elemento correspondente ao fornecedor inativo com base no ID fornecido
        const fornecedorInativoElement = document.querySelector(`#inativo${fornecedorId}`);
        if (fornecedorInativoElement) { // Verifica se o fornecedor inativo existe
            // Solicita confirmação do usuário para reativar o fornecedor
            const confirmacao = confirm("Tem certeza que deseja reativar este fornecedor?");
            if (confirmacao) {
                // Remove o fornecedor da lista de inativos
                let fornecedoresInativos = JSON.parse(localStorage.getItem('fornecedoresInativos')) || [];
                const fornecedorReativado = fornecedoresInativos.splice(fornecedorId - 1, 1)[0]; // Remove o fornecedor usando o ID
                // Atualiza o localStorage com a nova lista de fornecedores inativos
                localStorage.setItem('fornecedoresInativos', JSON.stringify(fornecedoresInativos));

                // Adiciona o fornecedor de volta à lista de fornecedores ativos
                let fornecedores = JSON.parse(localStorage.getItem('fornecedores')) || [];
                fornecedores.push(fornecedorReativado); // Adiciona o fornecedor reativado à lista de ativos
                // Atualiza o localStorage com a nova lista de fornecedores ativos
                localStorage.setItem('fornecedores', JSON.stringify(fornecedores));

                // Exibe uma mensagem de sucesso
                alert("Fornecedor reativado com sucesso!");
                carregarFornecedoresInativos(); // Atualiza a lista de fornecedores inativos na tela
            }
        } else {
            // Exibe uma mensagem se o fornecedor inativo não foi encontrado
            alert("Fornecedor inativo não encontrado.");
        }
    }
}

// Evento disparado após o carregamento completo do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Carrega e exibe os fornecedores inativos ao inicializar a página
    carregarFornecedoresInativos();

    // Adiciona evento ao botão de reativar fornecedor, que chama a função reativarFornecedor
    document.querySelector('.reactivate-button').addEventListener('click', reativarFornecedor);

    // Evento para o botão de voltar, que redireciona para a página de fornecedores
    document.querySelector('.back-button').addEventListener('click', () => {
        window.location.href = 'Fornecedores.html'; // Redireciona para a página de fornecedores
    });
});
