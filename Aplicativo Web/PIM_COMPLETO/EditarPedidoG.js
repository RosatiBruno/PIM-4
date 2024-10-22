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

class GoBackHandler {
    constructor() {
        this.initEventListener();
    }

    initEventListener() {
        window.goBack = () => {
            window.history.back();
        };
    }
}

document.addEventListener('DOMContentLoaded', () => {
    // Gerenciar o botão de salvar
    new ConfirmationButtonHandler(
        '#save-button',
        "Você realmente quer salvar os dados?",
        'ListaPedidosG.html',
        'EditarPedidoG.html'
    );

    // Gerenciar a função de voltar
    new GoBackHandler();

    // Gerenciar o botão de inativar/excluir
    new ConfirmationButtonHandler(
        '.inativar-button',
        "Você tem certeza que deseja excluir o pedido?",
        'ListaPedidosG.html',
        null // Sem ação de cancelamento
    );

    // Gerenciar o botão home
    new ButtonHandler('#homeButton', () => {
        window.location.href = 'inicialGerente.html'; // Altere o caminho conforme necessário
    });
});
