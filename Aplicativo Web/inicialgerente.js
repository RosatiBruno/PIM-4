// Classe para gerenciar o menu lateral
class SideMenu {
    // Construtor da classe que recebe um seletor de imagem de perfil
    constructor(profileImageSelector) {
        // Seleciona o elemento da imagem de perfil com base no seletor fornecido
        this.profileImage = document.querySelector(profileImageSelector);
        // Inicializa o estado do menu como fechado (false)
        this.menuAtivo = false;
        // Chama o método que configura os ouvintes de evento
        this.initEventListeners();
    }

    // Método para configurar os ouvintes de evento
    initEventListeners() {
        // Adiciona um ouvinte de clique na imagem de perfil para alternar o menu lateral
        this.profileImage.addEventListener('click', (event) => this.alternarMenu(event));
    }

    // Método para criar o menu lateral dinamicamente
    criarMenuLateral() {
        // Cria o elemento div para o menu lateral
        const sideMenu = document.createElement('div');
        // Define o ID e a classe do menu lateral
        sideMenu.id = 'side-menu';
        sideMenu.classList.add('side-menu');

        // Cria uma opção de menu "Sair do Sistema" com um evento de clique para sair
        const exitOption = this.criarOpcaoMenu('Sair do Sistema', () => this.sairDoSistema());
        // Cria uma opção de menu "Suporte" sem ação específica
        const supportOption = this.criarOpcaoMenu('Suporte');

        // Adiciona as opções ao menu lateral
        sideMenu.appendChild(exitOption);
        sideMenu.appendChild(supportOption);

        // Adiciona o menu lateral ao corpo do documento
        document.body.appendChild(sideMenu);

        // Chama o método para fechar o menu quando clicar fora dele
        this.fecharMenuAoCliqueFora(sideMenu);
    }

    // Método para criar uma opção de menu com texto e um manipulador de clique opcional
    criarOpcaoMenu(text, clickHandler) {
        // Cria o elemento div para a opção do menu
        const option = document.createElement('div');
        // Define a classe e o texto da opção
        option.classList.add('menu-option');
        option.textContent = text;

        // Adiciona o evento de clique, se fornecido
        if (clickHandler) {
            option.addEventListener('click', clickHandler);
        }

        return option; // Retorna o elemento de opção criado
    }

    // Método para fechar o menu ao clicar fora dele
    fecharMenuAoCliqueFora(sideMenu) {
        document.addEventListener('click', (event) => {
            // Verifica se o clique foi fora do menu e da imagem de perfil
            if (!sideMenu.contains(event.target) && event.target !== this.profileImage) {
                this.fecharMenu(); // Fecha o menu
            }
        });
    }

    // Método para abrir o menu lateral
    abrirMenu() {
        // Seleciona o menu lateral pelo ID
        const sideMenu = document.getElementById('side-menu');
        if (sideMenu) {
            // Adiciona a classe 'active' para exibir o menu
            sideMenu.classList.add('active');
        }
        this.menuAtivo = true; // Define o estado do menu como ativo
    }

    // Método para fechar o menu lateral
    fecharMenu() {
        const sideMenu = document.getElementById('side-menu');
        if (sideMenu) {
            // Remove a classe 'active' para ocultar o menu
            sideMenu.classList.remove('active');
        }
        this.menuAtivo = false; // Define o estado do menu como inativo
    }

    // Método para alternar o estado do menu lateral
    alternarMenu(event) {
        event.stopPropagation(); // Evita a propagação do evento para outros elementos
        if (!this.menuAtivo) {
            // Se o menu não existe, cria o menu lateral
            if (!document.getElementById('side-menu')) {
                this.criarMenuLateral();
            }
            this.abrirMenu(); // Abre o menu
        } else {
            this.fecharMenu(); // Fecha o menu se já estiver ativo
        }
    }

    // Método para confirmar e redirecionar ao sair do sistema
    sairDoSistema() {
        const confirmar = confirm('Você realmente deseja sair do sistema?');
        if (confirmar) {
            // Redireciona para a página de login se confirmado
            window.location.href = 'login.html';
        }
    }
}

// Classe para gerenciar os ícones de navegação
class NavigationIcons {
    // Construtor que recebe uma configuração de ícones com URL
    constructor(iconConfig) {
        this.iconConfig = iconConfig;
        // Chama o método para configurar os ouvintes de evento nos ícones
        this.initEventListeners();
    }

    // Método para configurar os ouvintes de clique nos ícones de navegação
    initEventListeners() {
        // Para cada ícone na configuração, adiciona um evento de clique
        this.iconConfig.forEach(icon => {
            // Seleciona o elemento de imagem com o caminho especificado no ícone
            const element = document.querySelector(`img[src="${icon.src}"]`);
            if (element) {
                // Adiciona um evento de clique que redireciona para a URL especificada
                element.addEventListener('click', () => {
                    window.location.href = icon.url;
                });
            }
        });
    }
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Cria uma instância de SideMenu, passando o seletor da imagem de perfil
    new SideMenu('.profile img');

    // Define a configuração dos ícones de navegação com suas URLs correspondentes
    const icons = [
        { src: 'pedidos-icon.png', url: 'ListaPedidosG.html' },
        { src: 'fornecedores-icon.png', url: 'FornecedoresG.html' },
        { src: 'vendas-icon.png', url: 'Vendas.html' },
        { src: 'registro.png', url: 'DadosFuncionariosG.html' },
        { src: 'producao-icon.png', url: 'ProducaoG.html' },
        { src: 'produtos-icon.png', url: 'ProdutosG.html' }
    ];

    // Cria uma instância de NavigationIcons, passando a configuração dos ícones
    new NavigationIcons(icons);
});
