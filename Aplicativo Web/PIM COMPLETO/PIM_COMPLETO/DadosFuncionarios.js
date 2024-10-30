// Classe para gerenciar os botões de navegação
class NavigationButton {
    constructor(buttonSelector, targetUrl) {
        this.button = document.querySelector(buttonSelector);
        this.targetUrl = targetUrl;
        this.initEventListeners();
    }

    initEventListeners() {
        if (this.button) {
            this.button.addEventListener('click', () => this.redirecionar());
        }
    }

    redirecionar() {
        window.location.href = this.targetUrl;
    }
}

// Função para carregar os funcionários cadastrados e exibi-los na lista
function carregarFuncionarios() {
    const listaFuncionarios = document.querySelector('.employee-list');
    let funcionarios = JSON.parse(localStorage.getItem('funcionarios')) || [];

    listaFuncionarios.innerHTML = '';

    funcionarios.forEach((funcionario, index) => {
        const li = document.createElement('li');
        li.textContent = funcionario.nome;
        li.id = `funcionario-${index}`;
        li.addEventListener('click', () => exibirDetalhesFuncionario(index));
        listaFuncionarios.appendChild(li);
    });
}

// Função para exibir detalhes do funcionário em um modal e permitir a edição
function exibirDetalhesFuncionario(index) {
    const modal = document.getElementById('employeeModal');
    const span = document.getElementsByClassName('close')[0];
    const employeeDetails = document.getElementById('employee-details');

    let funcionarios = JSON.parse(localStorage.getItem('funcionarios')) || [];
    const funcionario = funcionarios[index];

    // Preenche o modal com campos editáveis
    employeeDetails.innerHTML = `
        <label><strong>ID:</strong></label>
        <input type="text" id="editIdFuncionario" value="${funcionario.idFuncionario}" disabled><br>
        <label><strong>Nome:</strong></label>
        <input type="text" id="editNome" value="${funcionario.nome}"><br>
        <label><strong>Email:</strong></label>
        <input type="text" id="editEmail" value="${funcionario.email}"><br>
        <button id="saveFuncionario">Salvar</button> <!-- Botão Salvar adicionado -->
    `;

    modal.style.display = 'block';

    span.onclick = function() {
        modal.style.display = 'none';
    }

    window.onclick = function(event) {
        if (event.target == modal) {
            modal.style.display = 'none';
        }
    }

    // Função para salvar as alterações
    document.getElementById('saveFuncionario').onclick = function() {
        const editNome = document.getElementById('editNome').value;
        const editEmail = document.getElementById('editEmail').value;

        // Atualiza os dados do funcionário com os valores editados
        funcionarios[index].nome = editNome;
        funcionarios[index].email = editEmail;

        // Salva as alterações no localStorage
        localStorage.setItem('funcionarios', JSON.stringify(funcionarios));

        // Fecha o modal
        modal.style.display = 'none';

        // Recarrega a lista de funcionários para refletir as alterações
        carregarFuncionarios();

        // Redireciona para a tela de funcionários após salvar
        window.location.href = 'DadosFuncionarios.html';
    }
}

// Função para excluir funcionário pelo ID e remover as credenciais
function excluirFuncionario() {
    const funcionarioId = prompt("Digite o ID do funcionário que deseja excluir:");
    if (!funcionarioId) return;

    let funcionarios = JSON.parse(localStorage.getItem('funcionarios')) || [];
    let credenciais = JSON.parse(localStorage.getItem('credenciais')) || [];

    const funcionarioEncontrado = funcionarios.find(funcionario => funcionario.idFuncionario === funcionarioId);

    if (!funcionarioEncontrado) {
        alert(`ID ${funcionarioId} não encontrado. Por favor, insira um ID válido.`);
        return;
    }

    const confirmacao = confirm(`Tem certeza que deseja excluir o funcionário com ID ${funcionarioId}?`);
    if (confirmacao) {
        funcionarios = funcionarios.filter(funcionario => funcionario.idFuncionario !== funcionarioId);
        localStorage.setItem('funcionarios', JSON.stringify(funcionarios));
        credenciais = credenciais.filter(credencial => credencial.id !== funcionarioId);
        localStorage.setItem('credenciais', JSON.stringify(credenciais));
        carregarFuncionarios();
        alert('Funcionário e suas credenciais excluídos com sucesso!');
    }
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    carregarFuncionarios();
    new NavigationButton('.back-button', 'inicial.html');

    const newRegisterButton = document.querySelector('.new-register');
    if (newRegisterButton) {
        newRegisterButton.addEventListener('click', () => {
            window.location.href = 'CadastroFuncionario.html';
        });
    }

    const deleteButton = document.querySelector('.delete-button');
    if (deleteButton) {
        deleteButton.addEventListener('click', excluirFuncionario);
    }
});
