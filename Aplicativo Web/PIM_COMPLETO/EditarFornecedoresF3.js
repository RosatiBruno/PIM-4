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
    constructor(buttonSelector, confirmMessage, onConfirmUrl, onCancelUrl) {
        super(buttonSelector, () => this.handleClick(confirmMessage, onConfirmUrl, onCancelUrl));
    }

    handleClick(confirmMessage, onConfirmUrl, onCancelUrl) {
        const confirmation = confirm(confirmMessage);
        window.location.href = confirmation ? onConfirmUrl : onCancelUrl;
    }
}

document.addEventListener('DOMContentLoaded', () => {
    // Gerenciar o botão de salvar
    new ConfirmationButtonHandler(
        '#save-button',
        "Você realmente quer salvar os dados?",
        'Fornecedores.html',
        'EditarFornecedoresF3.html'
    );

    // Gerenciar o botão de voltar
    new ButtonHandler('.back-button', () => {
        window.location.href = 'FornecedoresF.html';
    });

    // Gerenciar o ícone de home
    new ButtonHandler('.home-icon', () => {
        window.location.href = 'inicialF.html';
    });
});