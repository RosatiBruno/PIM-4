// Classe para gerenciar o menu lateral
class SideMenu {
    // Construtor da classe SideMenu, que recebe o seletor da imagem de perfil
    constructor(profileImageSelector) {
        // Seleciona a imagem de perfil com o seletor fornecido
        this.profileImage = document.querySelector(profileImageSelector);
        // Inicializa o estado do menu como inativo
        this.menuAtivo = false;
        // Configura os ouvintes de eventos para interações do menu
        this.initEventListeners();
    }

    // Método para configurar os ouvintes de eventos
    initEventListeners() {
        // Adiciona um ouvinte de clique na imagem de perfil para alternar o menu
        this.profileImage.addEventListener('click', (event) => this.alternarMenu(event));
    }

    // Método para criar o menu lateral
    criarMenuLateral() {
        // Cria um elemento div para o menu lateral
        const sideMenu = document.createElement('div');
        // Define o ID do menu lateral
        sideMenu.id = 'side-menu';
        // Adiciona a classe CSS 'side-menu' para o estilo
        sideMenu.classList.add('side-menu');

        // Cria a opção "Sair do Sistema" no menu, com o evento de saída
        const exitOption = this.criarOpcaoMenu('Sair do Sistema', () => this.sairDoSistema());
        // Cria a opção "Suporte" no menu, sem evento de clique
        const supportOption = this.criarOpcaoMenu('Suporte');

        // Adiciona as opções de saída e suporte ao menu lateral
        sideMenu.appendChild(exitOption);
        sideMenu.appendChild(supportOption);

        // Adiciona o menu lateral ao corpo do documento (DOM)
        document.body.appendChild(sideMenu);

        // Configura o fechamento do menu ao clicar fora dele
        this.fecharMenuAoCliqueFora(sideMenu);
    }

    // Método para criar uma opção de menu com texto e um manipulador de clique opcional
    criarOpcaoMenu(text, clickHandler) {
        // Cria um elemento div para a opção do menu
        const option = document.createElement('div');
        // Adiciona a classe CSS 'menu-option' para o estilo
        option.classList.add('menu-option');
        // Define o texto da opção
        option.textContent = text;

        // Se houver um manipulador de clique fornecido, adiciona-o ao evento de clique
        if (clickHandler) {
            option.addEventListener('click', clickHandler);
        }

        // Retorna a opção criada
        return option;
    }

    // Método para fechar o menu quando clicar fora dele
    fecharMenuAoCliqueFora(sideMenu) {
        // Adiciona um ouvinte de clique ao documento para detectar cliques fora do menu
        document.addEventListener('click', (event) => {
            // Verifica se o clique não foi no menu ou na imagem de perfil
            if (!sideMenu.contains(event.target) && event.target !== this.profileImage) {
                // Fecha o menu se o clique foi fora
                this.fecharMenu();
            }
        });
    }

    // Método para abrir o menu lateral
    abrirMenu() {
        // Seleciona o menu lateral pelo ID
        const sideMenu = document.getElementById('side-menu');
        // Se o menu existe, adiciona a classe 'active' para exibi-lo
        if (sideMenu) {
            sideMenu.classList.add('active');
        }
        // Define o estado do menu como ativo
        this.menuAtivo = true;
    }

    // Método para fechar o menu lateral
    fecharMenu() {
        // Seleciona o menu lateral pelo ID
        const sideMenu = document.getElementById('side-menu');
        // Se o menu existe, remove a classe 'active' para ocultá-lo
        if (sideMenu) {
            sideMenu.classList.remove('active');
        }
        // Define o estado do menu como inativo
        this.menuAtivo = false;
    }

    // Método para alternar o estado do menu (abre se estiver fechado e fecha se estiver aberto)
    alternarMenu(event) {
        // Impede a propagação do evento para evitar conflitos com outros cliques
        event.stopPropagation();
        // Verifica se o menu está inativo
        if (!this.menuAtivo) {
            // Se o menu ainda não foi criado, cria-o
            if (!document.getElementById('side-menu')) {
                this.criarMenuLateral();
            }
            // Abre o menu
            this.abrirMenu();
        } else {
            // Se o menu está ativo, fecha-o
            this.fecharMenu();
        }
    }

    // Método para confirmar e realizar a ação de sair do sistema
    sairDoSistema() {
        // Exibe uma mensagem de confirmação
        const confirmar = confirm('Você realmente deseja sair do sistema?');
        // Se o usuário confirmar, redireciona para a página de login
        if (confirmar) {
            window.location.href = 'login.html';
        }
    }
}

// Classe para gerenciar os ícones de navegação
class NavigationIcons {
    // Construtor que recebe a configuração dos ícones
    constructor(iconConfig) {
        // Armazena a configuração dos ícones
        this.iconConfig = iconConfig;
        // Configura os ouvintes de eventos para os ícones
        this.initEventListeners();
    }

    // Método para configurar os ouvintes de eventos dos ícones de navegação
    initEventListeners() {
        // Para cada ícone na configuração, adiciona um ouvinte de clique
        this.iconConfig.forEach(icon => {
            // Seleciona o elemento da imagem do ícone com o caminho de imagem especificado
            const element = document.querySelector(`img[src="${icon.src}"]`);
            // Se o elemento existe no DOM, adiciona um ouvinte de clique
            if (element) {
                element.addEventListener('click', () => {
                    // Redireciona para a URL especificada do ícone quando clicado
                    window.location.href = icon.url;
                });
            }
        });
    }
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Cria uma nova instância do menu lateral, passando o seletor da imagem de perfil
    new SideMenu('.profile img');

    // Define os ícones de navegação com seus caminhos de imagem e URLs de redirecionamento
    const icons = [
        { src: 'pedidos-icon.png', url: 'ListaPedidos.html' },
        { src: 'fornecedores-icon.png', url: 'Fornecedores.html' },
        { src: 'vendas-icon.png', url: 'Vendas.html' },
        { src: 'registro.png', url: 'DadosFuncionarios.html' },
        { src: 'producao-icon.png', url: 'Producao.html' },
        { src: 'produtos-icon.png', url: 'Produtos.html' }
    ];

    // Cria uma nova instância da classe NavigationIcons para gerenciar os ícones de navegação
    new NavigationIcons(icons);
});
