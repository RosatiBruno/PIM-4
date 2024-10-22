// Função para adicionar um fornecedor ao localStorage
function adicionarFornecedor() {
    // Obtém os valores dos campos de entrada usando o ID dos elementos
    const nome = document.getElementById('nome').value; // Obtém o nome do fornecedor
    const cep = document.getElementById('cep').value; // Obtém o CEP do fornecedor
    const telefone = document.getElementById('telefone').value; // Obtém o telefone do fornecedor
    const cnpj = document.getElementById('cnpj').value; // Obtém o CNPJ do fornecedor
    const endereco = document.getElementById('endereco').value; // Obtém o endereço do fornecedor
    const email = document.getElementById('email').value; // Obtém o e-mail do fornecedor
    const situacao = document.getElementById('situacao').value; // Obtém a situação do fornecedor
    const complemento = document.getElementById('complemento').value; // Obtém o complemento do endereço
    const representante = document.getElementById('representante').value; // Obtém o representante do fornecedor
    const codigo = document.getElementById('codigo').value; // Obtém o código do fornecedor
    const cidade = document.getElementById('cidade').value; // Obtém a cidade do fornecedor
    const materiaPrima = document.getElementById('materia-prima').value; // Obtém a matéria-prima do fornecedor
    const razaoSocial = document.getElementById('razao-social').value; // Obtém a razão social do fornecedor
    const estado = document.getElementById('estado').value; // Obtém o estado do fornecedor

    // Cria um objeto fornecedor com os valores obtidos
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

    // Recupera a lista de fornecedores existente no localStorage ou inicia um novo array vazio se não houver fornecedores
    const fornecedores = JSON.parse(localStorage.getItem('fornecedores')) || [];

    // Adiciona o novo fornecedor à lista existente
    fornecedores.push(fornecedor);

    // Salva a lista atualizada de fornecedores no localStorage
    localStorage.setItem('fornecedores', JSON.stringify(fornecedores));

    // Redireciona para a página de fornecedores após a adição do novo fornecedor
    window.location.href = 'FornecedoresG.html';
}

// Função para redirecionar para a tela inicial
function voltarTelaAnterior() {
    window.location.href = 'FornecedoresG.html'; // Redireciona para a tela inicial do gerente
}

// Inicializa os eventos após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Evento para o botão de cadastrar: ao clicar, chama a função adicionarFornecedor
    document.querySelector('.submit-button').addEventListener('click', adicionarFornecedor);

    // Evento para o botão de voltar: ao clicar, chama a função voltarTelaAnterior
    document.querySelector('.back-button').addEventListener('click', voltarTelaAnterior);

    // Evento para o botão home: ao clicar, redireciona para a tela inicial do gerente
    document.getElementById('homeButton').addEventListener('click', () => {
        window.location.href = 'inicialGerente.html'; // Certifique-se de que a URL está correta
    });
});
