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

// Função para coletar os dados e adicionar o funcionário
function adicionarFuncionario() {
    // Coleta dos valores dos campos do formulário
    const nome = document.getElementById('nome').value; // Nome do funcionário
    const idFuncionario = document.getElementById('id_funcionario').value; // ID do funcionário
    const email = document.getElementById('email').value; // Email do funcionário
    const senha = document.getElementById('senha').value; // Senha do funcionário

    // Verifica se os campos obrigatórios foram preenchidos
    if (!nome || !idFuncionario || !email || !senha) {
        alert('Por favor, preencha todos os campos obrigatórios.'); // Alerta se algum campo estiver vazio
        return; // Sai da função se houver campos não preenchidos
    }

    // Cria um objeto funcionário com os dados coletados
    const funcionario = {
        nome,
        idFuncionario,
        email,
        senha
    };

    // Recupera os funcionários existentes do localStorage ou inicializa uma lista vazia
    let funcionarios = JSON.parse(localStorage.getItem('funcionarios')) || [];

    // Adiciona o novo funcionário à lista de funcionários
    funcionarios.push(funcionario);

    // Armazena a lista de funcionários atualizada no localStorage
    localStorage.setItem('funcionarios', JSON.stringify(funcionarios));

    // Armazena também as credenciais para login
    let credenciais = JSON.parse(localStorage.getItem('credenciais')) || []; // Recupera credenciais
    credenciais.push({ id: idFuncionario, password: senha }); // Adiciona as novas credenciais
    localStorage.setItem('credenciais', JSON.stringify(credenciais)); // Armazena credenciais atualizadas

    // Exibe uma mensagem de sucesso
    alert('Funcionário cadastrado com sucesso!');

    // Redireciona para a página de listagem de funcionários
    window.location.href = 'DadosFuncionarios.html';
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Gerenciar o botão de voltar para a página de listagem de funcionários
    new NavigationButton('.back-button', 'DadosFuncionarios.html');

    // Gerenciar o botão de home para redirecionar à página inicial
    new NavigationButton('#homeButton', 'inicial.html');

    // Adiciona um ouvinte de evento de clique ao botão de salvar funcionário
    const saveButton = document.querySelector('.save-button');
    if (saveButton) {
        saveButton.addEventListener('click', (event) => {
            event.preventDefault(); // Evita o comportamento padrão de envio do formulário
            adicionarFuncionario(); // Chama a função para adicionar o funcionário
        });
    }
});
