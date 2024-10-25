// Classe para gerenciar os botões de navegação
class NavigationButton {
    // Construtor da classe, que recebe o seletor do botão e a URL de destino
    constructor(buttonSelector, targetUrl) {
        // Seleciona o botão usando o seletor fornecido
        this.button = document.querySelector(buttonSelector);
        // Define a URL de destino
        this.targetUrl = targetUrl;
        // Inicializa os ouvintes de evento para o botão
        this.initEventListeners();
    }

    // Função para adicionar o evento de clique ao botão
    initEventListeners() {
        // Verifica se o botão existe
        if (this.button) {
            // Adiciona o ouvinte de evento 'click' que chama a função 'redirecionar'
            this.button.addEventListener('click', () => this.redirecionar());
        }
    }

    // Função que redireciona o usuário para a URL alvo
    redirecionar() {
        // Altera o local (URL) da página atual para a URL alvo
        window.location.href = this.targetUrl;
    }
}

// Função para carregar os funcionários cadastrados e exibi-los na lista
function carregarFuncionarios() {
    // Seleciona a lista onde os funcionários serão exibidos
    const listaFuncionarios = document.querySelector('.employee-list');

    // Recupera os funcionários do localStorage ou inicializa uma lista vazia
    let funcionarios = JSON.parse(localStorage.getItem('funcionarios')) || [];

    // Limpa a lista atual para evitar duplicações
    listaFuncionarios.innerHTML = '';

    // Adiciona os funcionários cadastrados à lista
    funcionarios.forEach((funcionario, index) => {
        const li = document.createElement('li'); // Cria um novo elemento de lista
        li.textContent = funcionario.nome; // Define o texto do item como o nome do funcionário
        li.id = `funcionario-${index}`; // Atribui um ID único ao item
        // Adiciona um evento de clique para exibir detalhes do funcionário
        li.addEventListener('click', () => exibirDetalhesFuncionario(index));
        // Adiciona o item à lista
        listaFuncionarios.appendChild(li);
    });
}

// Função para exibir detalhes do funcionário em um modal
function exibirDetalhesFuncionario(index) {
    const modal = document.getElementById('employeeModal'); // Seleciona o modal
    const span = document.getElementsByClassName('close')[0]; // Seleciona o botão de fechar do modal
    const employeeDetails = document.getElementById('employee-details'); // Seleciona o local para exibir os detalhes

    // Recupera os funcionários do localStorage
    let funcionarios = JSON.parse(localStorage.getItem('funcionarios')) || [];
    const funcionario = funcionarios[index]; // Obtém o funcionário correspondente ao índice

    // Preenche os detalhes do modal com os dados do funcionário
    employeeDetails.innerHTML = `
        <strong>ID:</strong> ${funcionario.idFuncionario}<br>
        <strong>Nome:</strong> ${funcionario.nome}<br>
        <strong>Email:</strong> ${funcionario.email}<br>
    `;

    // Exibe o modal
    modal.style.display = 'block';

    // Fecha o modal quando o usuário clica no "X"
    span.onclick = function() {
        modal.style.display = 'none';
    }

    // Fecha o modal quando o usuário clica fora da janela
    window.onclick = function(event) {
        if (event.target == modal) {
            modal.style.display = 'none';
        }
    }
}

// Função para excluir funcionário pelo ID e remover as credenciais
function excluirFuncionario() {
    const funcionarioId = prompt("Digite o ID do funcionário que deseja excluir:");
    if (!funcionarioId) return; // Se o ID não for fornecido, não faz nada

    // Recupera os funcionários e as credenciais do localStorage
    let funcionarios = JSON.parse(localStorage.getItem('funcionarios')) || [];
    let credenciais = JSON.parse(localStorage.getItem('credenciais')) || [];

    // Verifica se o ID fornecido existe
    const funcionarioEncontrado = funcionarios.find(funcionario => funcionario.idFuncionario === funcionarioId);

    if (!funcionarioEncontrado) {
        // Exibe um alerta se o ID não for encontrado
        alert(`ID ${funcionarioId} não encontrado. Por favor, insira um ID válido.`);
        return;
    }

    // Pergunta ao usuário se tem certeza da exclusão
    const confirmacao = confirm(`Tem certeza que deseja excluir o funcionário com ID ${funcionarioId}?`);
    if (confirmacao) {
        // Filtra a lista removendo o funcionário com o ID correspondente
        funcionarios = funcionarios.filter(funcionario => funcionario.idFuncionario !== funcionarioId);

        // Atualiza o localStorage com a lista modificada de funcionários
        localStorage.setItem('funcionarios', JSON.stringify(funcionarios));

        // Remove as credenciais associadas ao funcionário excluído
        credenciais = credenciais.filter(credencial => credencial.id !== funcionarioId);
        localStorage.setItem('credenciais', JSON.stringify(credenciais));

        // Recarrega a lista de funcionários na tela
        carregarFuncionarios();

        // Exibe mensagem de sucesso
        alert('Funcionário e suas credenciais excluídos com sucesso!');
    }
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Carrega os funcionários cadastrados
    carregarFuncionarios();

    // Gerencia o botão de voltar para a página anterior
    new NavigationButton('.back-button', 'inicial.html');

    // Gerencia o botão de novo cadastro
    const newRegisterButton = document.querySelector('.new-register');
    if (newRegisterButton) {
        newRegisterButton.addEventListener('click', () => {
            // Redireciona para a página de cadastro de funcionário
            window.location.href = 'CadastroFuncionario.html';
        });
    }

    // Gerencia o botão de excluir funcionário
    const deleteButton = document.querySelector('.delete-button');
    if (deleteButton) {
        // Adiciona um ouvinte de evento para o botão de excluir
        deleteButton.addEventListener('click', excluirFuncionario);
    }
});
