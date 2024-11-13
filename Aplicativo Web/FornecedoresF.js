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

        // Adiciona evento de clique em cada item da lista de fornecedores
        this.supplierList.addEventListener('click', (event) => {
            if (event.target.closest('.fornecedor-item')) {
                this.exibirDetalhesFornecedor(event.target.closest('.fornecedor-item'));
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

    exibirDetalhesFornecedor(item) {
        const index = Array.from(this.supplierList.children).indexOf(item);
        const fornecedores = JSON.parse(localStorage.getItem('fornecedores')) || [];
        const fornecedor = fornecedores[index];

        // Preenche o formulário com os dados do fornecedor
        document.getElementById('editNome').value = fornecedor.nome;
        document.getElementById('editCep').value = fornecedor.cep;
        document.getElementById('editTelefone').value = fornecedor.telefone;
        document.getElementById('editCNPJ').value = fornecedor.cnpj;
        document.getElementById('editEndereco').value = fornecedor.endereco;
        document.getElementById('editEmail').value = fornecedor.email;
        document.getElementById('editSituacao').value = fornecedor.situacao;
        document.getElementById('editComplemento').value = fornecedor.complemento;
        document.getElementById('editRepresentante').value = fornecedor.representante;
        document.getElementById('editCodigo').value = fornecedor.codigo;
        document.getElementById('editCidade').value = fornecedor.cidade;
        document.getElementById('editEstado').value = fornecedor.estado;
        document.getElementById('editMateriaPrima').value = fornecedor.materiaPrima;
        document.getElementById('editRazaoSocial').value = fornecedor.razaoSocial;

        document.getElementById('salvarAlteracoes').onclick = () => this.salvarAlteracoes(index);
        this.openModal();
    }

    salvarAlteracoes(index) {
        const fornecedores = JSON.parse(localStorage.getItem('fornecedores')) || [];
        fornecedores[index] = {
            nome: document.getElementById('editNome').value,
            cep: document.getElementById('editCep').value,
            telefone: document.getElementById('editTelefone').value,
            cnpj: document.getElementById('editCNPJ').value,
            endereco: document.getElementById('editEndereco').value,
            email: document.getElementById('editEmail').value,
            situacao: document.getElementById('editSituacao').value,
            complemento: document.getElementById('editComplemento').value,
            representante: document.getElementById('editRepresentante').value,
            codigo: document.getElementById('editCodigo').value,
            cidade: document.getElementById('editCidade').value,
            estado: document.getElementById('editEstado').value,
            materiaPrima: document.getElementById('editMateriaPrima').value,
            razaoSocial: document.getElementById('editRazaoSocial').value
        };

        localStorage.setItem('fornecedores', JSON.stringify(fornecedores));
        alert("Dados do fornecedor atualizados com sucesso!");
        this.closeModal();
        carregarFornecedores(); // Recarrega a lista para refletir as atualizações
    }

    openModal() {
        const modal = document.getElementById('fornecedorModal');
        modal.style.display = 'block';

        const closeButton = document.querySelector('.close-button');
        closeButton.onclick = () => this.closeModal();

        window.onclick = (event) => {
            if (event.target === modal) {
                this.closeModal();
            }
        };
    }

    closeModal() {
        const modal = document.getElementById('fornecedorModal');
        modal.style.display = 'none';
    }
}

// Classe para gerenciar redirecionamentos de navegação
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
            <p><strong>CEP:</strong> ${fornecedor.cep}</p>
            <p><strong>Telefone:</strong> ${fornecedor.telefone}</p>
            <p><strong>CNPJ/CPF:</strong> ${fornecedor.cnpj}</p>
            <p><strong>Endereço:</strong> ${fornecedor.endereco}</p>
            <p><strong>Email:</strong> ${fornecedor.email}</p>
            <p><strong>Situação:</strong> ${fornecedor.situacao}</p>
            <p><strong>Complemento:</strong> ${fornecedor.complemento}</p>
            <p><strong>Representante:</strong> ${fornecedor.representante}</p>
            <p><strong>Código:</strong> ${fornecedor.codigo}</p>
            <p><strong>Cidade:</strong> ${fornecedor.cidade}</p>
            <p><strong>Estado:</strong> ${fornecedor.estado}</p>
            <p><strong>Matéria-prima:</strong> ${fornecedor.materiaPrima}</p>
            <p><strong>Razão Social:</strong> ${fornecedor.razaoSocial}</p>
            <hr>
        </div>
    `;
        fornecedoresContainer.appendChild(fornecedorItem);
    });
}

// Inicializa o sistema de gerenciamento de fornecedores após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    new FornecedorSearch('.search-bar input', '.supplier-list');
    new Navigation('.buttons button:nth-child(2)', 'NovoFornecedorF.html');
    new BackButton('.back-button', 'inicialF.html');
    carregarFornecedores();
    new InativarFornecedor('.inactivate-button', '.supplier-list');
});
