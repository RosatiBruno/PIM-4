// Classe para gerenciar os botões de navegação
class NavigationButton {
    // Construtor da classe, que recebe o seletor do botão e a URL alvo
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

// Função para coletar os dados do formulário e adicionar uma nova produção
function adicionarProducao() {
    // Coleta os valores inseridos nos campos do formulário
    const idProducao = document.getElementById('idProducao').value;
    const dataProducao = document.getElementById('dataProducao').value;
    const quantidade = document.getElementById('quantidade').value;
    const produto = document.getElementById('produto').value;
    const responsavel = document.getElementById('responsavel').value;

    // Verifica se todos os campos obrigatórios foram preenchidos
    if (!idProducao || !dataProducao || !quantidade || !produto || !responsavel) {
        // Exibe um alerta se algum campo estiver vazio
        alert('Por favor, preencha todos os campos obrigatórios.');
        return; // Impede que a função continue
    }

    // Cria um objeto de produção com os dados coletados
    const producao = {
        idProducao,
        dataProducao,
        quantidade,
        produto,
        responsavel
    };

    // Recupera a lista de produções armazenadas no localStorage ou cria uma lista vazia
    let producoes = JSON.parse(localStorage.getItem('producoes')) || [];

    // Adiciona a nova produção à lista de produções
    producoes.push(producao);

    // Atualiza o localStorage com a lista de produções atualizada
    localStorage.setItem('producoes', JSON.stringify(producoes));

    // Exibe uma mensagem de sucesso
    alert('Produção cadastrada com sucesso!');

    // Redireciona o usuário para a página de listagem de produções
    window.location.href = 'Producao.html';
}

// Aguarda o carregamento completo do DOM para inicializar o sistema
document.addEventListener('DOMContentLoaded', () => {
    // Gerencia o botão de voltar para a página de listagem de produções
    new NavigationButton('.back-button a', 'Producao.html');

    // Gerencia o ícone de home, redirecionando para a página inicial
    new NavigationButton('.home-icon a', 'inicial.html');

    // Seleciona o botão de envio do formulário de nova produção
    const submitButton = document.querySelector('.submit-button');
    // Verifica se o botão de envio está presente
    if (submitButton) {
        // Adiciona um ouvinte de clique ao botão de envio
        submitButton.addEventListener('click', (event) => {
            // Previne o comportamento padrão de envio do formulário
            event.preventDefault();
            // Chama a função para adicionar a nova produção
            adicionarProducao();
        });
    }
});
