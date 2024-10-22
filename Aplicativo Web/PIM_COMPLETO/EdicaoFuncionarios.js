class ButtonHandler {
    constructor(buttonId, action) {
        this.button = document.getElementById(buttonId);
        this.action = action;
        this.initEventListener();
    }

    initEventListener() {
        if (this.button) {
            this.button.addEventListener('click', (event) => {
                if (this.action) {
                    this.action(event);
                }
            });
        }
    }
}

class HomeButtonHandler extends ButtonHandler {
    constructor(buttonId) {
        super(buttonId, () => {
            window.location.href = 'inicial.html'; // Caminho da página inicial
        });
    }
}

class ConfirmationHandler {
    constructor(buttonSelector, confirmMessage, onConfirmUrl, onCancelUrl) {
        this.button = document.querySelector(buttonSelector);
        this.confirmMessage = confirmMessage;
        this.onConfirmUrl = onConfirmUrl;
        this.onCancelUrl = onCancelUrl;
        this.initEventListener();
    }

    initEventListener() {
        if (this.button) {
            this.button.addEventListener('click', (event) => {
                event.preventDefault(); // Impede o envio do formulário
                const confirmation = confirm(this.confirmMessage);
                window.location.href = confirmation ? this.onConfirmUrl : this.onCancelUrl;
            });
        }
    }
}

class ExclusionHandler {
    constructor() {
        this.initExclusionEvent();
    }

    initExclusionEvent() {
        window.confirmarExclusao = (event) => {
            event.preventDefault(); // Impede o envio do formulário
            const confirmation = confirm("Você realmente deseja deletar este dado?");
            window.location.href = confirmation ? 'DadosFuncionarios.html' : 'EdicaoFuncionarios.html';
        };
    }
}

document.addEventListener('DOMContentLoaded', () => {
    // Gerenciar o botão home
    new HomeButtonHandler('homeButton');

    // Gerenciar o botão de salvar
    new ConfirmationHandler(
        '.save-button',
        "Você realmente deseja salvar os dados?",
        "DadosFuncionarios.html",
        "EdicaoFuncionarios.html"
    );

    // Gerenciar a confirmação de exclusão
    new ExclusionHandler();
});
