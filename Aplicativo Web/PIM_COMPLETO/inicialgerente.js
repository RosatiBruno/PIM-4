// Classe para gerenciar o menu lateral
class SideMenu {
    // Construtor da classe, recebe o seletor da imagem do perfil
    constructor(profileImageSelector) {
        // Seleciona a imagem do perfil do DOM
        this.profileImage = document.querySelector(profileImageSelector);
        this.menuAtivo = false; // Estado do menu (se está ativo ou não)
        this.initEventListeners(); // Inicializa os ouvintes de eventos
    }

    // Inicializa os ouvintes de eventos
    initEventListeners() {
        // Adiciona um evento de clique à imagem do perfil para alternar o menu
        this.profileImage.addEventListener('click', (event) => this.alternarMenu(event));
    }

    // Método para criar o menu lateral
    criarMenuLateral() {
        // Cria o elemento do menu
        const sideMenu = document.createElement('div');
        sideMenu.id = 'side-menu'; // Define um ID para o menu
        sideMenu.classList.add('side-menu'); // Adiciona uma classe ao menu

        // Estiliza o menu
        sideMenu.style.left = '0'; // Define a posição à esquerda da tela
        sideMenu.style.top = '0';  // A partir do topo
        sideMenu.style.position = 'fixed'; // Fixa o menu na posição
        sideMenu.style.width = '250px'; // Define a largura do menu
        sideMenu.style.height = '100%'; // Faz com que o menu ocupe toda a altura da página
        sideMenu.style.backgroundColor = '#333'; // Define a cor de fundo
        sideMenu.style.color = '#fff'; // Cor do texto
        sideMenu.style.display = 'flex'; // Layout flexível
        sideMenu.style.flexDirection = 'column'; // Coloca as opções na vertical
        sideMenu.style.padding = '20px'; // Espaçamento interno

        // Cria a opção "Sair do Sistema"
        const exitOption = document.createElement('div');
        exitOption.classList.add('menu-option'); // Adiciona classe de estilo
        exitOption.textContent = 'Sair do Sistema'; // Define o texto da opção
        exitOption.style.marginBottom = '10px'; // Espaçamento entre as opções
        exitOption.style.cursor = 'pointer'; // Indica que é clicável
        exitOption.addEventListener('click', () => this.sairDoSistema()); // Adiciona evento de clique

        // Cria a opção "Suporte"
        const supportOption = document.createElement('div');
        supportOption.classList.add('menu-option'); // Adiciona classe de estilo
        supportOption.textContent = 'Suporte'; // Define o texto da opção
        supportOption.style.cursor = 'pointer'; // Indica que é clicável

        // Adiciona as opções ao menu
        sideMenu.appendChild(exitOption); // Adiciona a opção "Sair do Sistema"
        sideMenu.appendChild(supportOption); // Adiciona a opção "Suporte"

        // Adiciona o menu ao corpo do documento
        document.body.appendChild(sideMenu);

        // Evento para fechar o menu ao clicar fora dele
        document.addEventListener('click', (event) => {
            // Verifica se o clique não foi no menu ou na imagem do perfil
            if (!sideMenu.contains(event.target) && event.target !== this.profileImage) {
                this.fecharMenu(); // Fecha o menu
            }
        });
    }

    // Método para abrir o menu
    abrirMenu() {
        const sideMenu = document.getElementById('side-menu'); // Seleciona o menu pelo ID
        if (sideMenu) {
            sideMenu.classList.add('active'); // Adiciona classe 'active' para mostrar o menu
        }
        this.menuAtivo = true; // Atualiza o estado do menu para ativo
    }

    // Método para fechar o menu
    fecharMenu() {
        const sideMenu = document.getElementById('side-menu'); // Seleciona o menu pelo ID
        if (sideMenu) {
            sideMenu.classList.remove('active'); // Remove a classe 'active' para esconder o menu
            sideMenu.remove(); // Remove o menu da página ao fechar
        }
        this.menuAtivo = false; // Atualiza o estado do menu para inativo
    }

    // Método para alternar o menu
    alternarMenu(event) {
        event.stopPropagation(); // Evita que o clique propague para o documento
        if (!this.menuAtivo) { // Se o menu não estiver ativo
            if (!document.getElementById('side-menu')) { // Se o menu ainda não existir
                this.criarMenuLateral(); // Cria o menu lateral
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
            window.location.href = 'login.html'; // Redireciona para a página de login
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

    // Inicializa os ouvintes de eventos
    initEventListeners() {
        // Para cada ícone na configuração
        this.iconConfig.forEach(icon => {
            const element = document.querySelector(`img[src="${icon.src}"]`); // Seleciona o elemento da imagem pelo src
            if (element) {
                element.addEventListener('click', () => {
                    window.location.href = icon.url; // Redireciona para a URL correspondente ao ícone
                });
            }
        });
    }
}

// Inicializa o sistema após o carregamento do DOM
document.addEventListener('DOMContentLoaded', () => {
    // Inicializa o menu lateral com o seletor da imagem do perfil
    new SideMenu('.profile img');

    // Configuração de ícones de navegação
    const icons = [
        { src: 'pedidos-icon.png', url: 'ListaPedidosG.html' }, // Ícone de pedidos
        { src: 'fornecedores-icon.png', url: 'FornecedoresG.html' }, // Ícone de fornecedores
        { src: 'vendas-icon.png', url: 'Vendas.html' }, // Ícone de vendas
        { src: 'registro.png', url: 'DadosFuncionariosG.html' }, // Ícone de funcionários
        { src: 'producao-icon.png', url: 'ProducaoG.html' }, // Ícone de produção
        { src: 'produtos-icon.png', url: 'ProdutosG.html' } // Ícone de produtos
    ];

    // Inicializa os ícones de navegação com a configuração definida
    new NavigationIcons(icons);
});
