from flask import Flask, request, jsonify  # Importa o Flask para criar a API e bibliotecas para lidar com requisições e respostas
import pyodbc  # Importa a biblioteca para conexão com o banco de dados SQL Server

# Criação da aplicação Flask
app = Flask(__name__)  # Corrigido _name para _name_

# String de conexão com o banco de dados SQL Server
connection_string = (
    #"Driver={SQL Server};"  # Especifica o driver do SQL Server
        "Server=DESKTOP-PNTRNKL\\SQLSERVER2022;"  # Nome ou endereço do servidor de banco de dados
        "Database=PIM;"  # Nome do banco de dados
        "UID=Teste;"  # Usuário do banco de dados
        "PWD=1234;"  # Senha do banco de dados
)

# Rota para listar todos os produtos
@app.route('/produtos', methods=['GET'])
def listar_produtos():
    # Conecta ao banco de dados
    conn = pyodbc.connect(connection_string)
    cursor = conn.cursor()
    
    # Executa a consulta para selecionar todos os produtos
    cursor.execute("SELECT * FROM Produtos")
    
    # Cria uma lista de produtos com os dados retornados
    produtos = [
        {"id": row[0], "nome": row[1], "quantidade": row[2], "valor": float(row[3])}
        for row in cursor.fetchall()
    ]
    
    # Fecha a conexão com o banco de dados
    conn.close()
    
    # Retorna a lista de produtos no formato JSON
    return jsonify(produtos)

# Rota para adicionar um novo produto
@app.route('/produtos', methods=['POST'])
def adicionar_produto():
    # Obtém os dados enviados na requisição
    data = request.json
    
    # Conecta ao banco de dados
    conn = pyodbc.connect(connection_string)
    cursor = conn.cursor()
    
    # Executa o comando SQL para inserir um novo produto
    cursor.execute(
        "INSERT INTO Produtos (nome, quantidade, valor) VALUES (?, ?, ?)",
        (data['nome'], data['quantidade'], data['valor'])  # Substitui os placeholders pelos valores enviados
    )
    
    # Confirma a transação no banco de dados
    conn.commit()
    conn.close()
    
    # Retorna uma mensagem de sucesso e o código HTTP 201 (Criado)
    return jsonify({"message": "Produto adicionado com sucesso!"}), 201

# Rota para editar um produto existente
@app.route('/produtos/<int:id>', methods=['PUT'])
def editar_produto(id):
    # Obtém os dados enviados na requisição
    data = request.json
    
    # Conecta ao banco de dados
    conn = pyodbc.connect(connection_string)
    cursor = conn.cursor()
    
    # Executa o comando SQL para atualizar os dados do produto
    cursor.execute(
        "UPDATE Produtos SET nome = ?, quantidade = ?, valor = ? WHERE id = ?",
        (data['nome'], data['quantidade'], data['valor'], id)  # Atualiza o produto com base no ID
    )
    
    # Confirma a transação no banco de dados
    conn.commit()
    conn.close()
    
    # Retorna uma mensagem de sucesso
    return jsonify({"message": "Produto atualizado com sucesso!"})

# Rota para excluir um produto existente
@app.route('/produtos/<int:id>', methods=['DELETE'])
def excluir_produto(id):
    # Conecta ao banco de dados
    conn = pyodbc.connect(connection_string)
    cursor = conn.cursor()
    
    # Executa o comando SQL para deletar o produto com base no ID
    cursor.execute("DELETE FROM Produtos WHERE id = ?", (id,))
    
    # Confirma a transação no banco de dados
    conn.commit()
    conn.close()
    
    # Retorna uma mensagem de sucesso
    return jsonify({"message": "Produto excluído com sucesso!"})

# Ponto de entrada da aplicação
if __name__ == '_main':  # Corrigido _name para _name_
    # Executa a aplicação Flask em modo debug
    app.run(debug=True)