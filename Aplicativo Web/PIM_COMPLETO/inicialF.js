// Classe para gerenciar o menu lateral
class SideMenu {
    // Construtor da classe, recebe o seletor da imagem de perfil
    constructor(profileImageSelector) {
        this.profileImage = document.querySelector(profileImageSelector); // Seleciona a imagem de perfil
        this.menuAtivo = false; // Define o estado do menu como inativo inicialmente
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    // Inicializa os ouvintes de eventos
    initEventListeners() {
        // Adiciona um evento de clique à imagem de perfil que alterna o menu
        this.profileImage.addEventListener('click', (event) => this.alternarMenu(event));
    }

    // Cria o menu lateral e suas opções
    criarMenuLateral() {
        // Cria o elemento do menu
        const sideMenu = document.createElement('div');
        sideMenu.id = 'side-menu'; // Define o ID do menu
        sideMenu.classList.add('side-menu'); // Adiciona a classe CSS para estilização

        // Posiciona o menu no lado esquerdo
        sideMenu.style.left = '0'; // Define a posição à esquerda
        sideMenu.style.top = '0';  // Certifica-se de que o menu esteja no topo da página
        sideMenu.style.height = '100%'; // Faz com que o menu tenha altura total da página

        // Cria a opção "Sair do Sistema"
        const exitOption = document.createElement('div');
        exitOption.classList.add('menu-option'); // Adiciona a classe para estilização
        exitOption.textContent = 'Sair do Sistema'; // Define o texto da opção
        exitOption.addEventListener('click', () => this.sairDoSistema()); // Adiciona o evento de clique para sair

        // Cria a opção "Suporte"
        const supportOption = document.createElement('div');
        supportOption.classList.add('menu-option'); // Adiciona a classe para estilização
        supportOption.textContent = 'Suporte'; // Define o texto da opção

        // Adiciona as opções ao menu
        sideMenu.appendChild(exitOption); // Adiciona a opção de sair
        sideMenu.appendChild(supportOption); // Adiciona a opção de suporte

        // Adiciona o menu ao corpo do documento
        document.body.appendChild(sideMenu); // Insere o menu na página

        // Evento para fechar o menu ao clicar fora dele
        document.addEventListener('click', (event) => {
            // Verifica se o clique foi fora do menu e da imagem de perfil
            if (!sideMenu.contains(event.target) && event.target !== this.profileImage) {
                this.fecharMenu(); // Fecha o menu se a condição for verdadeira
            }
        });
    }

    // Abre o menu lateral
    abrirMenu() {
        const sideMenu = document.getElementById('side-menu'); // Seleciona o menu lateral
        if (sideMenu) {
            sideMenu.classList.add('active'); // Adiciona a classe que ativa o menu
        }
        this.menuAtivo = true; // Define o estado do menu como ativo
    }

    // Fecha o menu lateral
    fecharMenu() {
        const sideMenu = document.getElementById('side-menu'); // Seleciona o menu lateral
        if (sideMenu) {
            sideMenu.classList.remove('active'); // Remove a classe que ativa o menu
        }
        this.menuAtivo = false; // Define o estado do menu como inativo
    }

    // Alterna entre abrir e fechar o menu ao clicar na imagem de perfil
    alternarMenu(event) {
        event.stopPropagation(); // Impede que o clique propague para o documento
        if (!this.menuAtivo) {
            // Se o menu não está ativo, cria e abre o menu
            if (!document.getElementById('side-menu')) {
                this.criarMenuLateral(); // Cria o menu se ele não existir
            }
            this.abrirMenu(); // Abre o menu
        } else {
            this.fecharMenu(); // Caso contrário, fecha o menu
        }
    }

    // Método para sair do sistema
    sairDoSistema() {
        const confirmar = confirm('Você realmente deseja sair do sistema?'); // Pergunta de confirmação
        if (confirmar) {
            window.location.href = 'login.html'; // Redireciona para a página de login se confirmado
        }
    }
}

// Classe para gerenciar os ícones de navegação
class NavigationIcons {
    // Construtor da classe, recebe a configuração dos ícones
    constructor(iconConfig) {
        this.iconConfig = iconConfig; // Armazena a configuração dos ícones
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    // Inicializa os ouvintes de eventos para os ícones
    initEventListeners() {
        this.iconConfig.forEach(icon => {
            const element = document.querySelector(`img[src="${icon.src}"]`); // Seleciona a imagem do ícone
            if (element) {
                // Adiciona evento de clique para redirecionar ao URL correspondente
                element.addEventListener('click', () => {
                    window.location.href = icon.url; // Redireciona para a URL configurada
                });
            }
        });
    }
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Inicializa o menu lateral passando o seletor da imagem de perfil
    new SideMenu('.profile img');

    // Configuração de ícones de navegação
    const icons = [
        { src: 'pedidos-icon.png', url: 'PedidosF.html' }, // Ícone de pedidos
        { src: 'fornecedores-icon.png', url: 'FornecedoresF.html' }, // Ícone de fornecedores
        { src: 'producao-icon.png', url: 'Producaof.html' }, // Ícone de produção
        { src: 'produtos-icon.png', url: 'Produtosf.html' }, // Ícone de produtos
        { src: 'vendas-icon.png', url: 'Vendas.html' } // Ícone de vendas
    ];

    // Inicializa os ícones de navegação passando a configuração
    new NavigationIcons(icons);
});
