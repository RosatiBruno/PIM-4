class ButtonHandler {
    constructor(buttonSelector, action) {
        this.button = document.getElementById(buttonSelector);
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

class ExclusionHandler {
    constructor() {
        this.initExclusionEvent();
    }

    initExclusionEvent() {
        window.confirmarExclusao = (event) => {
            const response = confirm("Você tem certeza que deseja excluir o funcionário?");
            if (response) {
                window.location.href = 'Produtos.html'; // Redireciona para a lista de funcionários
            }
        };
    }
}

document.addEventListener('DOMContentLoaded', () => {
    // Gerenciar o botão de salvar
    new ConfirmationButtonHandler(
        'save-button',
        "Você realmente quer salvar os dados?",
        'Produtosf.html',
        'EditarProdutosF6.html'
    );

    // Gerenciar a exclusão
    new ExclusionHandler();

    // Gerenciar o botão home
    new ButtonHandler('homeButton', () => {
        window.location.href = 'inicialF.html'; // Altere o caminho conforme necessário
    });
});
