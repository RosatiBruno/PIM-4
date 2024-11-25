import pyodbc  # Biblioteca para conexão com o banco de dados SQL Server

# Classe para gerenciar operações relacionadas aos pedidos
class PedidoManager:
    def _init(self):  # Corrigido de _init para _init_
        # Inicializa a conexão com o banco de dados e cria um cursor para executar comandos SQL
        self.connection = pyodbc.connect(
            #"Driver={SQL Server};"  # Especifica o driver do SQL Server
        "Server=DESKTOP-PNTRNKL\\SQLSERVER2022;"  # Nome ou endereço do servidor de banco de dados
        "Database=PIM;"  # Nome do banco de dados
        "UID=Teste;"  # Usuário do banco de dados
        "PWD=1234;"  # Senha do banco de dados
        )
        self.cursor = self.connection.cursor()  # Objeto cursor para executar comandos SQL

    # Método para listar todos os pedidos
    def listar_pedidos(self):
        # Executa a consulta para obter todos os pedidos da tabela Pedidos
        self.cursor.execute("SELECT * FROM Pedidos")
        return self.cursor.fetchall()  # Retorna todas as linhas da consulta como uma lista

    # Método para adicionar um novo pedido
    def adicionar_pedido(self, idPedido, nomeProduto, quantidade, valor, empresaResponsavel):
        # Executa o comando SQL para inserir um novo pedido na tabela
        self.cursor.execute(
            """
            INSERT INTO Pedidos (idPedido, nomeProduto, quantidade, valor, empresaResponsavel)
            VALUES (?, ?, ?, ?, ?)
            """,
            idPedido, nomeProduto, quantidade, valor, empresaResponsavel  # Parâmetros para a consulta
        )
        self.connection.commit()  # Confirma a transação no banco de dados

    # Método para editar um pedido existente
    def editar_pedido(self, idPedido, nomeProduto, quantidade, valor, empresaResponsavel):
        # Executa o comando SQL para atualizar os dados de um pedido específico
        self.cursor.execute(
            """
            UPDATE Pedidos
            SET nomeProduto = ?, quantidade = ?, valor = ?, empresaResponsavel = ?
            WHERE idPedido = ?
            """,
            nomeProduto, quantidade, valor, empresaResponsavel, idPedido  # Parâmetros para a consulta
        )
        self.connection.commit()  # Confirma a transação no banco de dados

    # Método para excluir um pedido pelo ID
    def excluir_pedido(self, idPedido):
        # Executa o comando SQL para deletar um pedido específico
        self.cursor.execute("DELETE FROM Pedidos WHERE idPedido = ?", idPedido)
        self.connection.commit()  # Confirma a transação no banco de dados

    # Método para fechar a conexão com o banco de dados
    def fechar_conexao(self):
        self.connection.close()  # Fecha a conexão com o banco de dados

# Exemplo de uso da classe PedidoManager
if __name__ == "_main":  # Corrigido de _name para _name_
    manager = PedidoManager()  # Instancia a classe

    # Adicionando um novo pedido
    manager.adicionar_pedido(1, "Produto A", 10, 50.0, "Empresa X")

    # Listando pedidos e exibindo no console
    pedidos = manager.listar_pedidos()
    for pedido in pedidos:
        print(pedido)  # Exibe cada pedido retornado

    # Editando um pedido existente
    manager.editar_pedido(1, "Produto A - Editado", 15, 60.0, "Empresa Y")

    # Excluindo um pedido pelo ID
    manager.excluir_pedido(1)

    # Fechando a conexão com o banco de dados
    manager.fechar_conexao()