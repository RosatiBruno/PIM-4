// Classe para gerenciar os botões de navegação
class NavigationButton {
    constructor(buttonSelector, targetUrl) {
        this.button = document.querySelector(buttonSelector); // Seleciona o botão com o seletor fornecido
        this.targetUrl = targetUrl; // Armazena a URL de destino para onde o botão redirecionará
        this.initEventListeners(); // Inicializa os ouvintes de evento
    }

    // Método para configurar os ouvintes de eventos para o botão
    initEventListeners() {
        if (this.button) { // Verifica se o botão existe
            this.button.addEventListener('click', () => this.redirecionar()); // Adiciona um evento de clique que chama o método redirecionar
        }
    }

    // Método para redirecionar o navegador para a URL de destino
    redirecionar() {
        window.location.href = this.targetUrl; // Muda a localização do navegador para a URL armazenada
    }
}

// Função para carregar os funcionários cadastrados e exibi-los na lista
function carregarFuncionarios() {
    const listaFuncionarios = document.querySelector('.employee-list'); // Seleciona o elemento da lista de funcionários
    let funcionarios = JSON.parse(localStorage.getItem('funcionarios')) || []; // Recupera a lista de funcionários do localStorage

    listaFuncionarios.innerHTML = ''; // Limpa a lista de funcionários existente

    // Itera sobre cada funcionário e cria um item de lista para cada um
    funcionarios.forEach((funcionario, index) => {
        const li = document.createElement('li'); // Cria um novo elemento de lista
        li.textContent = funcionario.nome; // Define o texto do item de lista como o nome do funcionário
        li.id = `funcionario-${index}`; // Define um ID único para o item de lista
        li.addEventListener('click', () => exibirDetalhesFuncionario(index)); // Adiciona um evento de clique que chama a função para exibir detalhes do funcionário
        listaFuncionarios.appendChild(li); // Adiciona o item de lista à lista de funcionários
    });
}

// Função para exibir detalhes do funcionário em um modal e permitir a edição
function exibirDetalhesFuncionario(index) {
    const modal = document.getElementById('employeeModal'); // Seleciona o modal para exibir detalhes do funcionário
    const span = document.getElementsByClassName('close')[0]; // Seleciona o botão de fechar do modal
    const employeeDetails = document.getElementById('employee-details'); // Seleciona a área onde os detalhes do funcionário serão exibidos

    let funcionarios = JSON.parse(localStorage.getItem('funcionarios')) || []; // Recupera a lista de funcionários do localStorage
    const funcionario = funcionarios[index]; // Obtém o funcionário correspondente ao índice fornecido

    // Preenche o modal com campos editáveis
    employeeDetails.innerHTML = `
        <label><strong>ID:</strong></label>
        <input type="text" id="editIdFuncionario" value="${funcionario.idFuncionario}" disabled><br> <!-- ID do funcionário, não editável -->
        <label><strong>Nome:</strong></label>
        <input type="text" id="editNome" value="${funcionario.nome}"><br> <!-- Campo para editar o nome do funcionário -->
        <label><strong>Email:</strong></label>
        <input type="text" id="editEmail" value="${funcionario.email}"><br> <!-- Campo para editar o email do funcionário -->
        <button id="saveFuncionario">Salvar</button> <!-- Botão Salvar adicionado -->
    `;

    modal.style.display = 'block'; // Exibe o modal

    // Função para fechar o modal quando o botão de fechar é clicado
    span.onclick = function() {
        modal.style.display = 'none'; // Oculta o modal
    }

    // Fecha o modal se o usuário clicar fora do modal
    window.onclick = function(event) {
        if (event.target == modal) {
            modal.style.display = 'none'; // Oculta o modal
        }
    }

    // Função para salvar as alterações
    document.getElementById('saveFuncionario').onclick = function() {
        const editNome = document.getElementById('editNome').value; // Obtém o novo nome do funcionário
        const editEmail = document.getElementById('editEmail').value; // Obtém o novo email do funcionário

        // Atualiza os dados do funcionário com os valores editados
        funcionarios[index].nome = editNome; // Atualiza o nome do funcionário
        funcionarios[index].email = editEmail; // Atualiza o email do funcionário

        // Salva as alterações no localStorage
        localStorage.setItem('funcionarios', JSON.stringify(funcionarios)); // Armazena a lista atualizada de funcionários no localStorage

        modal.style.display = 'none'; // Fecha o modal

        carregarFuncionarios(); // Recarrega a lista de funcionários para refletir as alterações

        // Redireciona para a tela de funcionários após salvar
        window.location.href = 'DadosFuncionarios.html'; // Muda a localização do navegador para a página de dados dos funcionários
    }
}

// Função para excluir funcionário pelo ID e remover as credenciais
function excluirFuncionario() {
    const funcionarioId = prompt("Digite o ID do funcionário que deseja excluir:"); // Solicita o ID do funcionário a ser excluído
    if (!funcionarioId) return; // Se não houver ID, sai da função

    let funcionarios = JSON.parse(localStorage.getItem('funcionarios')) || []; // Recupera a lista de funcionários do localStorage
    let credenciais = JSON.parse(localStorage.getItem('credenciais')) || []; // Recupera as credenciais do localStorage

    // Busca o funcionário pelo ID
    const funcionarioEncontrado = funcionarios.find(funcionario => funcionario.idFuncionario === funcionarioId);

    // Verifica se o funcionário foi encontrado
    if (!funcionarioEncontrado) {
        alert(`ID ${funcionarioId} não encontrado. Por favor, insira um ID válido.`); // Alerta o usuário se o ID não for encontrado
        return; // Sai da função
    }

    // Confirmação de exclusão
    const confirmacao = confirm(`Tem certeza que deseja excluir o funcionário com ID ${funcionarioId}?`);
    if (confirmacao) { // Se o usuário confirmar
        // Remove o funcionário da lista
        funcionarios = funcionarios.filter(funcionario => funcionario.idFuncionario !== funcionarioId); // Filtra a lista de funcionários para remover o funcionário excluído
        localStorage.setItem('funcionarios', JSON.stringify(funcionarios)); // Atualiza o localStorage com a lista filtrada
        credenciais = credenciais.filter(credencial => credencial.id !== funcionarioId); // Filtra as credenciais para remover as do funcionário excluído
        localStorage.setItem('credenciais', JSON.stringify(credenciais)); // Atualiza o localStorage com as credenciais filtradas
        carregarFuncionarios(); // Recarrega a lista de funcionários
        alert('Funcionário e suas credenciais excluídos com sucesso!'); // Alerta de sucesso
    }
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    carregarFuncionarios(); // Carrega a lista de funcionários quando o DOM estiver completamente carregado
    new NavigationButton('.back-button', 'inicial.html'); // Cria um novo botão de navegação para voltar à página inicial

    const newRegisterButton = document.querySelector('.new-register'); // Seleciona o botão de novo registro
    if (newRegisterButton) { // Verifica se o botão existe
        newRegisterButton.addEventListener('click', () => {
            window.location.href = 'CadastroFuncionario.html'; // Redireciona para a página de cadastro de funcionários
        });
    }

    const deleteButton = document.querySelector('.delete-button'); // Seleciona o botão de exclusão
    if (deleteButton) { // Verifica se o botão existe
        deleteButton.addEventListener('click', excluirFuncionario); // Adiciona um evento de clique que chama a função de exclusão de funcionário
    }
});
