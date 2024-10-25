// Classe para gerenciar os botões de navegação
class NavigationButton {
    // Construtor da classe, recebe o seletor do botão e a URL de destino
    constructor(buttonSelector, targetUrl) {
        // Seleciona o botão no DOM usando o seletor fornecido
        this.button = document.querySelector(buttonSelector);
        this.targetUrl = targetUrl; // Armazena a URL de destino para redirecionamento
        this.initEventListeners(); // Inicializa os ouvintes de eventos para o botão
    }

    // Inicializa os ouvintes de eventos para o botão
    initEventListeners() {
        // Verifica se o botão existe no DOM
        if (this.button) {
            // Adiciona um evento de clique ao botão
            this.button.addEventListener('click', (event) => {
                event.preventDefault(); // Previne o comportamento padrão do link (não segue o href)
                this.redirecionar(); // Chama o método para redirecionar para a URL de destino
            });
        }
    }

    // Método para redirecionar para a URL de destino
    redirecionar() {
        window.location.href = this.targetUrl; // Redireciona o navegador para a URL especificada
    }
}

// Função para coletar os dados e adicionar uma nova produção
function cadastrarProducao() {
    // Coleta dos valores dos campos do formulário
    const idProducao = document.getElementById('idProducao').value; // Obtém o valor do campo de ID da produção
    const dataProducao = document.getElementById('dataProducao').value; // Obtém o valor da data da produção
    const quantidade = document.getElementById('quantidade').value; // Obtém o valor da quantidade
    const produto = document.getElementById('produto').value; // Obtém o valor do produto
    const responsavel = document.getElementById('responsavel').value; // Obtém o valor do responsável

    // Verifica se os campos obrigatórios foram preenchidos
    if (!idProducao || !dataProducao || !quantidade || !produto || !responsavel) {
        alert('Por favor, preencha todos os campos obrigatórios.'); // Exibe um alerta se algum campo estiver vazio
        return; // Interrompe a execução da função
    }

    // Cria um objeto produção com os dados coletados
    const producao = {
        idProducao,
        dataProducao,
        quantidade,
        produto,
        responsavel
    };

    // Recupera as produções existentes do localStorage
    let producoes = JSON.parse(localStorage.getItem('producoes')) || []; // Tenta obter as produções do localStorage, ou inicializa como array vazio

    // Adiciona a nova produção à lista de produções
    producoes.push(producao); // Adiciona o objeto de produção ao array de produções

    // Armazena a lista de produções atualizada no localStorage
    localStorage.setItem('producoes', JSON.stringify(producoes)); // Converte o array de produções para JSON e armazena no localStorage

    // Exibe uma mensagem de sucesso
    alert('Produção cadastrada com sucesso!'); // Informa o usuário que a produção foi cadastrada

    // Redireciona para a página de listagem de produções (ou qualquer outra que você desejar)
    window.location.href = 'ProducaoG.html'; // Redireciona para a página onde as produções são listadas
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Gerenciar o botão de voltar
    new NavigationButton('.back-button a', 'ProducaoG.html'); // Inicializa o botão de voltar para a página de produtos

    // Gerenciar o ícone de home
    new NavigationButton('.home-icon a', 'inicialGerente.html'); // Inicializa o ícone de home para redirecionar para a página inicial

    // Adiciona um ouvinte de evento ao botão de cadastrar produção
    const submitButton = document.querySelector('.submit-button'); // Seleciona o botão de submissão do formulário
    if (submitButton) {
        // Adiciona um evento de clique ao botão
        submitButton.addEventListener('click', (event) => {
            event.preventDefault(); // Evita o comportamento padrão de envio do formulário
            cadastrarProducao(); // Chama a função para cadastrar nova produção
        });
    }
});
