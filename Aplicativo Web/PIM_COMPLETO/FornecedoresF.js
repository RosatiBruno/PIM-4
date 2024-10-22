// Classe para gerenciar a busca de fornecedores
class FornecedorSearch {
    constructor(searchBarSelector, supplierListSelector) {
        this.searchBar = document.querySelector(searchBarSelector);
        this.supplierList = document.querySelector(supplierListSelector);
        this.initEventListeners();
    }

    initEventListeners() {
        document.querySelector('.search-bar button').addEventListener('click', () => this.buscarFornecedor());

        this.searchBar.addEventListener('keyup', (event) => {
            if (event.key === 'Enter') {
                this.buscarFornecedor();
            }
        });
    }

    buscarFornecedor() {
        const filter = this.searchBar.value.toUpperCase();
        const supplierItems = this.supplierList.querySelectorAll('.fornecedor-item');

        supplierItems.forEach(item => {
            const txtValue = item.textContent || item.innerText;
            item.style.display = txtValue.toUpperCase().includes(filter) ? '' : 'none';
        });
    }
}

// Classe para gerenciar os redirecionamentos de navegação
class Navigation {
    constructor(buttonSelector, redirectUrl) {
        this.button = document.querySelector(buttonSelector);
        this.redirectUrl = redirectUrl;
        this.initEventListeners();
    }

    initEventListeners() {
        this.button.addEventListener('click', () => this.redirecionar());
    }

    redirecionar() {
        window.location.href = this.redirectUrl;
    }
}

// Classe para gerenciamento de botões com redirecionamento e evento de voltar
class BackButton {
    constructor(buttonSelector, backUrl) {
        this.button = document.querySelector(buttonSelector);
        this.backUrl = backUrl;
        this.initEventListeners();
    }

    initEventListeners() {
        this.button.addEventListener('click', () => this.voltarTelaAnterior());
    }

    voltarTelaAnterior() {
        window.location.href = this.backUrl;
    }
}

// Função para carregar fornecedores do localStorage e exibi-los
function carregarFornecedores() {
    const fornecedores = JSON.parse(localStorage.getItem('fornecedores')) || [];
    const fornecedoresContainer = document.querySelector('.supplier-list');

    fornecedoresContainer.innerHTML = '';

    if (fornecedores.length === 0) {
        fornecedoresContainer.innerHTML = '<p>Nenhum fornecedor cadastrado.</p>';
        return;
    }

    fornecedores.forEach((fornecedor, index) => {
        const fornecedorItem = document.createElement('div');
        fornecedorItem.classList.add('fornecedor-item');
        fornecedorItem.id = `empresa${index + 1}`;
        fornecedorItem.innerHTML = `
            <div class="fornecedor-card">
                <h3>Fornecedor ${index + 1}</h3>
                <p><strong>Nome:</strong> ${fornecedor.nome}</p>
                <p><strong>Telefone:</strong> ${fornecedor.telefone}</p>
                <p><strong>CNPJ/CPF:</strong> ${fornecedor.cnpj}</p>
                <p><strong>Endereço:</strong> ${fornecedor.endereco}</p>
                <p><strong>Email:</strong> ${fornecedor.email}</p>
                <hr>
            </div>
        `;
        fornecedoresContainer.appendChild(fornecedorItem);
    });
}

// Classe para inativar fornecedor
class InativarFornecedor {
    constructor(buttonSelector, supplierListSelector) {
        this.button = document.querySelector(buttonSelector);
        this.supplierList = document.querySelector(supplierListSelector);
        this.initEventListeners();
    }

    initEventListeners() {
        this.button.addEventListener('click', () => this.inativarFornecedor());
    }

    inativarFornecedor() {
        const fornecedorId = prompt("Informe o ID do fornecedor que deseja inativar:");
        if (fornecedorId) {
            const fornecedorElement = document.querySelector(`#empresa${fornecedorId}`);
            if (fornecedorElement) {
                const confirmacao = confirm("Tem certeza que deseja inativar este fornecedor?");
                if (confirmacao) {
                    let fornecedores = JSON.parse(localStorage.getItem('fornecedores')) || [];
                    const fornecedorInativado = fornecedores.splice(fornecedorId - 1, 1)[0];
                    localStorage.setItem('fornecedores', JSON.stringify(fornecedores));

                    let fornecedoresInativos = JSON.parse(localStorage.getItem('fornecedoresInativos')) || [];
                    fornecedoresInativos.push(fornecedorInativado);
                    localStorage.setItem('fornecedoresInativos', JSON.stringify(fornecedoresInativos));

                    fornecedorElement.remove();
                    alert("Fornecedor inativado com sucesso!");
                }
            } else {
                alert("Fornecedor não encontrado.");
            }
        }
    }
}

// Função para carregar fornecedores inativos na página ListaFornecedorInativo.html
function carregarFornecedoresInativos() {
    const fornecedoresInativos = JSON.parse(localStorage.getItem('fornecedoresInativos')) || [];
    const inativosContainer = document.querySelector('.inativos-list');

    inativosContainer.innerHTML = '';

    if (fornecedoresInativos.length === 0) {
        inativosContainer.innerHTML = '<p>Nenhum fornecedor inativado.</p>';
        return;
    }

    fornecedoresInativos.forEach((fornecedor, index) => {
        const fornecedorItem = document.createElement('div');
        fornecedorItem.classList.add('fornecedor-item');
        fornecedorItem.innerHTML = `
            <div class="fornecedor-card">
                <h3>Fornecedor Inativo ${index + 1}</h3>
                <p><strong>Nome:</strong> ${fornecedor.nome}</p>
                <p><strong>Telefone:</strong> ${fornecedor.telefone}</p>
                <p><strong>CNPJ/CPF:</strong> ${fornecedor.cnpj}</p>
                <p><strong>Endereço:</strong> ${fornecedor.endereco}</p>
                <p><strong>Email:</strong> ${fornecedor.email}</p>
                <hr>
            </div>
        `;
        inativosContainer.appendChild(fornecedorItem);
    });
}

// Inicializa o sistema de gerenciamento de fornecedores após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    new FornecedorSearch('.search-bar input', '.supplier-list');
    new Navigation('.buttons button:nth-child(2)', 'NovoFornecedorF.html');
    new BackButton('.back-button', 'inicialF.html');
    carregarFornecedores();
    new InativarFornecedor('.inactivate-button', '.supplier-list');
    new BackButton('.buttons button:nth-child(1)', 'inicialF.html');
    new Navigation('.inactivated-suppliers-button', 'ListaFornecedorInativo.html');
});
