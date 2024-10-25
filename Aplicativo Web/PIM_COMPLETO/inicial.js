// Classe para gerenciar o menu lateral
class SideMenu {
    constructor(profileImageSelector) {
        // Seleciona a imagem de perfil pelo seletor fornecido
        this.profileImage = document.querySelector(profileImageSelector);
        this.menuAtivo = false; // Estado para verificar se o menu está ativo ou não
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    // Adiciona o ouvinte de eventos para alternar o menu ao clicar na imagem de perfil
    initEventListeners() {
        this.profileImage.addEventListener('click', (event) => this.alternarMenu(event));
    }

    // Cria o menu lateral no DOM quando acionado
    criarMenuLateral() {
        const sideMenu = document.createElement('div'); // Cria o elemento do menu
        sideMenu.id = 'side-menu';
        sideMenu.classList.add('side-menu'); // Adiciona a classe CSS ao menu

        // Cria a opção "Sair do Sistema" dentro do menu
        const exitOption = document.createElement('div');
        exitOption.classList.add('menu-option');
        exitOption.textContent = 'Sair do Sistema';
        // Adiciona o comportamento para a opção de sair do sistema
        exitOption.addEventListener('click', () => this.sairDoSistema());

        // Cria a opção "Suporte" no menu
        const supportOption = document.createElement('div');
        supportOption.classList.add('menu-option');
        supportOption.textContent = 'Suporte';

        // Adiciona as opções "Sair do Sistema" e "Suporte" ao menu
        sideMenu.appendChild(exitOption);
        sideMenu.appendChild(supportOption);

        // Adiciona o menu criado ao corpo do documento
        document.body.appendChild(sideMenu);

        // Fecha o menu se o usuário clicar fora dele
        document.addEventListener('click', (event) => {
            if (!sideMenu.contains(event.target) && event.target !== this.profileImage) {
                this.fecharMenu(); // Fecha o menu caso o clique ocorra fora dele
            }
        });
    }

    // Abre o menu lateral ao ativá-lo
    abrirMenu() {
        const sideMenu = document.getElementById('side-menu'); // Seleciona o menu pelo ID
        if (sideMenu) {
            sideMenu.classList.add('active'); // Adiciona a classe CSS que o torna visível
        }
        this.menuAtivo = true; // Atualiza o estado para indicar que o menu está ativo
    }

    // Fecha o menu lateral
    fecharMenu() {
        const sideMenu = document.getElementById('side-menu'); // Seleciona o menu
        if (sideMenu) {
            sideMenu.classList.remove('active'); // Remove a classe CSS que exibe o menu
        }
        this.menuAtivo = false; // Atualiza o estado para indicar que o menu está inativo
    }

    // Alterna entre abrir e fechar o menu ao clicar na imagem de perfil
    alternarMenu(event) {
        event.stopPropagation(); // Impede que o clique seja propagado para outros elementos
        if (!this.menuAtivo) {
            // Se o menu não estiver ativo, cria e abre o menu
            if (!document.getElementById('side-menu')) {
                this.criarMenuLateral(); // Cria o menu caso ele ainda não exista
            }
            this.abrirMenu(); // Abre o menu
        } else {
            // Caso contrário, fecha o menu
            this.fecharMenu();
        }
    }

    // Função para sair do sistema, redirecionando para a página de login após confirmação
    sairDoSistema() {
        const confirmar = confirm('Você realmente deseja sair do sistema?');
        if (confirmar) {
            window.location.href = 'login.html'; // Redireciona para a página de login
        }
    }
}

// Classe para gerenciar os ícones de navegação
class NavigationIcons {
    constructor(iconConfig) {
        this.iconConfig = iconConfig; // Recebe uma configuração de ícones com seus URLs
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    // Adiciona ouvintes de eventos a cada ícone para redirecionar ao clicar
    initEventListeners() {
        this.iconConfig.forEach(icon => {
            // Seleciona o elemento do ícone pelo atributo 'src'
            const element = document.querySelector(`img[src="${icon.src}"]`);
            if (element) {
                // Adiciona um evento de clique para redirecionar para a URL associada ao ícone
                element.addEventListener('click', () => {
                    window.location.href = icon.url;
                });
            }
        });
    }
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Inicializa o menu lateral passando o seletor da imagem de perfil
    new SideMenu('.profile img');

    // Configuração dos ícones de navegação com suas respectivas URLs
    const icons = [
        { src: 'pedidos-icon.png', url: 'ListaPedidos.html' },
        { src: 'fornecedores-icon.png', url: 'Fornecedores.html' },
        { src: 'vendas-icon.png', url: 'Vendas.html' },
        { src: 'registro.png', url: 'DadosFuncionarios.html' },
        { src: 'producao-icon.png', url: 'Producao.html' },
        { src: 'produtos-icon.png', url: 'Produtos.html' }
    ];

    // Inicializa os ícones de navegação com base na configuração
    new NavigationIcons(icons);
});