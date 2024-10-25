// Classe para gerenciar o menu lateral
class SideMenu {
    constructor(profileImageSelector) {
        this.profileImage = document.querySelector(profileImageSelector);
        this.menuAtivo = false;
        this.initEventListeners();
    }

    initEventListeners() {
        this.profileImage.addEventListener('click', (event) => this.alternarMenu(event));
    }

    criarMenuLateral() {
        // Cria o elemento do menu
        const sideMenu = document.createElement('div');
        sideMenu.id = 'side-menu';
        sideMenu.classList.add('side-menu');

        // Adiciona o estilo para posicionar a barra à esquerda
        sideMenu.style.position = 'fixed';
        sideMenu.style.top = '0';
        sideMenu.style.left = '0'; // Barra na esquerda
        sideMenu.style.width = '250px'; // Largura da barra
        sideMenu.style.height = '100%';
        sideMenu.style.backgroundColor = '#333';
        sideMenu.style.color = '#fff';
        sideMenu.style.padding = '20px';
        sideMenu.style.boxShadow = '2px 0 5px rgba(0, 0, 0, 0.5)';
        sideMenu.style.transform = 'translateX(-100%)'; // Inicialmente fora da tela
        sideMenu.style.transition = 'transform 0.3s ease';

        // Cria a opção "Sair do Sistema"
        const exitOption = document.createElement('div');
        exitOption.classList.add('menu-option');
        exitOption.textContent = 'Sair do Sistema';
        exitOption.style.marginBottom = '20px';
        exitOption.addEventListener('click', () => this.sairDoSistema());

        // Cria a opção "Suporte"
        const supportOption = document.createElement('div');
        supportOption.classList.add('menu-option');
        supportOption.textContent = 'Suporte';

        // Adiciona as opções ao menu
        sideMenu.appendChild(exitOption);
        sideMenu.appendChild(supportOption);

        // Adiciona o menu ao corpo do documento
        document.body.appendChild(sideMenu);

        // Evento para fechar o menu ao clicar fora dele
        document.addEventListener('click', (event) => {
            if (!sideMenu.contains(event.target) && event.target !== this.profileImage) {
                this.fecharMenu();
            }
        });
    }

    abrirMenu() {
        const sideMenu = document.getElementById('side-menu');
        if (sideMenu) {
            sideMenu.classList.add('active');
            sideMenu.style.transform = 'translateX(0)'; // Move a barra para dentro da tela
        }
        this.menuAtivo = true;
    }

    fecharMenu() {
        const sideMenu = document.getElementById('side-menu');
        if (sideMenu) {
            sideMenu.classList.remove('active');
            sideMenu.style.transform = 'translateX(-100%)'; // Move a barra para fora da tela
        }
        this.menuAtivo = false;
    }

    alternarMenu(event) {
        event.stopPropagation(); // Evita que o clique propague para o documento
        if (!this.menuAtivo) {
            if (!document.getElementById('side-menu')) {
                this.criarMenuLateral();
            }
            this.abrirMenu();
        } else {
            this.fecharMenu();
        }
    }

    sairDoSistema() {
        const confirmar = confirm('Você realmente deseja sair do sistema?');
        if (confirmar) {
            window.location.href = 'login.html';
        }
    }
}

// Classe para gerenciar os ícones de navegação
class NavigationIcons {
    constructor(iconConfig) {
        this.iconConfig = iconConfig;
        this.initEventListeners();
    }

    initEventListeners() {
        this.iconConfig.forEach(icon => {
            const element = document.querySelector(`img[src="${icon.src}"]`);
            if (element) {
                element.addEventListener('click', () => {
                    window.location.href = icon.url;
                });
            }
        });
    }
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Inicializa o menu lateral
    new SideMenu('.profile img');

    // Configuração de ícones de navegação
    const icons = [
        { src: 'pedidos-icon.png', url: 'PedidosF.html' },
        { src: 'fornecedores-icon.png', url: 'FornecedoresF.html' },
        { src: 'vendas-icon.png', url: 'Vendas.html' },
        { src: 'registro.png', url: 'DadosFuncionariosF.html' },
        { src: 'producao-icon.png', url: 'ProducaoF.html' },
        { src: 'produtos-icon.png', url: 'ProdutosF.html' }
    ];

    // Inicializa os ícones de navegação
    new NavigationIcons(icons);
});
