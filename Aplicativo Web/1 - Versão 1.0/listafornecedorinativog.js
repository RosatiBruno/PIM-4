// Função para carregar fornecedores inativos do localStorage e exibi-los
function carregarFornecedoresInativos() {
    // Recupera a lista de fornecedores inativos do localStorage, ou inicia um array vazio se não houver
    const fornecedoresInativos = JSON.parse(localStorage.getItem('fornecedoresInativos')) || [];
    
    // Seleciona o contêiner onde os fornecedores inativos serão exibidos
    const fornecedoresContainer = document.querySelector('.supplier-list-inactive');

    // Limpa a lista antes de adicionar os fornecedores inativos
    fornecedoresContainer.innerHTML = ''; 

    // Verifica se a lista de fornecedores inativos está vazia
    if (fornecedoresInativos.length === 0) {
        // Se não houver fornecedores inativos, exibe uma mensagem informativa
        fornecedoresContainer.innerHTML = '<p>Nenhum fornecedor inativado.</p>';
        return; // Sai da função se não houver fornecedores inativos
    }

    // Itera sobre cada fornecedor inativo e cria elementos para exibi-los
    fornecedoresInativos.forEach((fornecedor, index) => {
        const fornecedorItem = document.createElement('div'); // Cria um novo elemento div para o fornecedor
        fornecedorItem.classList.add('fornecedor-item-inativo'); // Adiciona uma classe ao elemento
        fornecedorItem.id = `inativo${index + 1}`; // Define um ID único para o elemento

        // Define o conteúdo HTML do elemento com as informações do fornecedor
        fornecedorItem.innerHTML = `
            <div class="fornecedor-card">
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

        // Adiciona o item do fornecedor inativo ao contêiner
        fornecedoresContainer.appendChild(fornecedorItem);
    });
}

// Função para reativar um fornecedor
function reativarFornecedor() {
    // Solicita ao usuário o ID do fornecedor que deseja reativar
    const fornecedorId = prompt("Informe o ID do fornecedor que deseja reativar:");
    
    if (fornecedorId) { // Verifica se um ID foi informado
        // Seleciona o elemento do fornecedor inativo correspondente ao ID fornecido
        const fornecedorInativoElement = document.querySelector(`#inativo${fornecedorId}`);
        
        if (fornecedorInativoElement) { // Verifica se o elemento existe
            // Confirma com o usuário se deseja realmente reativar o fornecedor
            const confirmacao = confirm("Tem certeza que deseja reativar este fornecedor?");
            
            if (confirmacao) {
                // Remove o fornecedor da lista de inativos
                let fornecedoresInativos = JSON.parse(localStorage.getItem('fornecedoresInativos')) || [];
                const fornecedorReativado = fornecedoresInativos.splice(fornecedorId - 1, 1)[0]; // Remove e obtém o fornecedor inativo
                
                // Atualiza o localStorage removendo o fornecedor inativo
                localStorage.setItem('fornecedoresInativos', JSON.stringify(fornecedoresInativos));

                // Adiciona o fornecedor de volta à lista de fornecedores ativos
                let fornecedores = JSON.parse(localStorage.getItem('fornecedores')) || [];
                fornecedores.push(fornecedorReativado); // Adiciona o fornecedor reativado à lista de ativos
                
                // Atualiza o localStorage com a lista de fornecedores ativos
                localStorage.setItem('fornecedores', JSON.stringify(fornecedores));

                alert("Fornecedor reativado com sucesso!"); // Exibe mensagem de sucesso
                carregarFornecedoresInativos(); // Atualiza a lista de inativos após a reativação
            }
        } else {
            alert("Fornecedor inativo não encontrado."); // Mensagem de erro se o fornecedor não for encontrado
        }
    }
}

// Inicializa eventos após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Carrega e exibe os fornecedores inativos ao iniciar a página
    carregarFornecedoresInativos();

    // Adiciona evento ao botão de reativar fornecedor: chama a função reativarFornecedor ao clicar
    document.querySelector('.reactivate-button').addEventListener('click', reativarFornecedor);

    // Evento para o botão de voltar: redireciona para a página de fornecedores
    document.querySelector('.back-button').addEventListener('click', () => {
        window.location.href = 'FornecedoresG.html'; // Redireciona para a página de fornecedores
    });
});
