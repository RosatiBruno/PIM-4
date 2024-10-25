// Função para adicionar um fornecedor ao localStorage
function adicionarFornecedor() {
    // Obtém os valores dos campos de entrada
    const nome = document.getElementById('nome').value; // Captura o valor do campo de nome
    const cep = document.getElementById('cep').value; // Captura o valor do campo de CEP
    const telefone = document.getElementById('telefone').value; // Captura o valor do campo de telefone
    const cnpj = document.getElementById('cnpj').value; // Captura o valor do campo de CNPJ
    const endereco = document.getElementById('endereco').value; // Captura o valor do campo de endereço
    const email = document.getElementById('email').value; // Captura o valor do campo de email
    const situacao = document.getElementById('situacao').value; // Captura o valor do campo de situação
    const complemento = document.getElementById('complemento').value; // Captura o valor do campo de complemento
    const representante = document.getElementById('representante').value; // Captura o valor do campo de representante
    const codigo = document.getElementById('codigo').value; // Captura o valor do campo de código
    const cidade = document.getElementById('cidade').value; // Captura o valor do campo de cidade
    const materiaPrima = document.getElementById('materia-prima').value; // Captura o valor do campo de matéria-prima
    const razaoSocial = document.getElementById('razao-social').value; // Captura o valor do campo de razão social
    const estado = document.getElementById('estado').value; // Captura o valor do campo de estado

    // Cria um objeto fornecedor com os dados coletados
    const fornecedor = {
        nome,
        cep,
        telefone,
        cnpj,
        endereco,
        email,
        situacao,
        complemento,
        representante,
        codigo,
        cidade,
        materiaPrima,
        razaoSocial,
        estado
    };

    // Recupera a lista de fornecedores existente do localStorage ou inicia um novo array vazio
    const fornecedores = JSON.parse(localStorage.getItem('fornecedores')) || [];

    // Adiciona o novo fornecedor à lista existente
    fornecedores.push(fornecedor);

    // Salva a lista atualizada de fornecedores no localStorage como uma string JSON
    localStorage.setItem('fornecedores', JSON.stringify(fornecedores));

    // Redireciona para a página de fornecedores após o cadastro
    window.location.href = 'FornecedoresF.html';
}

// Função para redirecionar para a tela inicial
function voltarTelaAnterior() {
    window.location.href = 'inicialF.html'; // Redireciona para a página inicial
}

// Inicializa os eventos após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Evento para o botão de cadastrar fornecedor
    document.querySelector('.submit-button').addEventListener('click', adicionarFornecedor); // Chama a função de adicionar fornecedor ao clicar

    // Evento para o botão de voltar à tela anterior
    document.querySelector('.back-button').addEventListener('click', voltarTelaAnterior); // Chama a função de voltar ao clicar

    // Evento para o botão home
    document.getElementById('homeButton').addEventListener('click', () => {
        window.location.href = 'inicialF.html'; // Redireciona para a página inicial ao clicar
    });
});
