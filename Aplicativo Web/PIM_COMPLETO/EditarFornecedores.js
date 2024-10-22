class ButtonHandler {
    constructor(buttonSelector, action) {
        this.button = document.querySelector(buttonSelector);
        this.action = action;
        this.initEventListener();
    }

    initEventListener() {
        if (this.button) {
            this.button.addEventListener('click', () => this.action());
        }
    }
}

class ConfirmationButtonHandler extends ButtonHandler {
    constructor(buttonSelector, confirmMessage, onConfirm, onCancel) {
        super(buttonSelector, () => this.handleClick(confirmMessage, onConfirm, onCancel));
    }

    handleClick(confirmMessage, onConfirm, onCancel) {
        const confirmation = confirm(confirmMessage);
        if (confirmation) {
            onConfirm();
        } else {
            onCancel();
        }
    }
}

document.addEventListener('DOMContentLoaded', () => {
    // Função para desativar fornecedor
    const inativarFornecedor = () => {
        // Exemplo: adicione uma classe "inativo" ao fornecedor que foi inativado
        const fornecedorElement = document.querySelector('.fornecedor'); // selecione o fornecedor apropriado
        if (fornecedorElement) {
            fornecedorElement.classList.add('inativo');
            fornecedorElement.style.pointerEvents = 'none'; // desativa cliques
            fornecedorElement.style.opacity = '0.5'; // deixa o fornecedor visualmente diferente
            alert('Fornecedor inativado com sucesso!');
        }

        // Redireciona para a página de fornecedores
        window.location.href = 'Fornecedores.html';
    };

    // Gerenciar o botão de salvar
    new ConfirmationButtonHandler(
        '#save-button',
        "Você realmente quer salvar os dados?",
        () => window.location.href = 'Fornecedores.html',
        () => window.location.href = 'EditarFornecedores.html'
    );

    // Gerenciar o botão de voltar
    new ButtonHandler('.back-button', () => {
        window.location.href = 'Fornecedores.html';
    });

    // Gerenciar o botão de inativar
    new ConfirmationButtonHandler(
        '.inativar-button',
        "Você tem certeza que deseja inativar o Fornecedor?",
        inativarFornecedor,
        () => window.location.href = 'EditarFornecedores.html'
    );

    // Gerenciar o ícone de home
    new ButtonHandler('.home-icon', () => {
        window.location.href = 'inicial.html';
    });
});
