class ButtonHandler {
    constructor(buttonSelector, action) {
        this.button = document.querySelector(buttonSelector);
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

class BackButtonHandler extends ButtonHandler {
    constructor() {
        super('.back-button', () => {
            window.location.href = 'Producaof.html'; // Redireciona para a tela de Produção
        });
    }
}

class HomeButtonHandler extends ButtonHandler {
    constructor() {
        super('#homeButton', () => {
            window.location.href = 'inicialF.html'; // Caminho da página inicial
        });
    }
}

class SaveButtonHandler extends ButtonHandler {
    constructor() {
        super('#save-button', (event) => {
            event.preventDefault(); // Impede o envio do formulário
            const confirmation = confirm("Você realmente deseja salvar os dados?");
            window.location.href = confirmation ? 'Producaof.html' : 'EditarProducaoF3.html';
        });
    }
}

class InactivationHandler {
    constructor() {
        this.initInactivationEvent();
    }

    initInactivationEvent() {
        window.confirmarInativacao = (event) => {
            event.preventDefault(); // Impede o envio do formulário
            const confirmation = confirm("Você realmente deseja inativar este registro?");
            window.location.href = confirmation ? 'Producaof.html' : 'EditarProducaoF3.html';
        };
    }
}

document.addEventListener('DOMContentLoaded', () => {
    // Gerenciar o botão de voltar
    new BackButtonHandler();

    // Gerenciar o botão home
    new HomeButtonHandler();

    // Gerenciar o botão de salvar
    new SaveButtonHandler();

    // Gerenciar a confirmação de inativação
    new InactivationHandler();
});
