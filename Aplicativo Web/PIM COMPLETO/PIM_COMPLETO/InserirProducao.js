// Classe para gerenciar os botões de navegação
class NavigationButton {
    constructor(buttonSelector, targetUrl) {
        this.button = document.querySelector(buttonSelector);
        this.targetUrl = targetUrl;
        this.initEventListeners();
    }

    initEventListeners() {
        if (this.button) {
            this.button.addEventListener('click', () => this.redirecionar());
        }
    }

    redirecionar() {
        window.location.href = this.targetUrl;
    }
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Gerenciar o botão de voltar para redirecionar à página de produção
    new NavigationButton('.back-btn', 'Producao.html');

    // Gerenciar o botão de home para redirecionar à página inicial
    new NavigationButton('#homeButton', 'inicial.html');
});
