from flask import Flask, request, jsonify  # Importa o Flask para criar a API e bibliotecas para lidar com requisições e respostas
from flask_cors import CORS  # Importa o CORS para permitir requisições de diferentes origens
import pyodbc  # Importa a biblioteca para conexão com o banco de dados SQL Server

# Inicialização da aplicação Flask
app = Flask(__name__)  # Corrigido _name para _name_

# Habilita CORS na aplicação para permitir requisições de outras origens
CORS(app)

# Configuração da conexão com o banco de dados SQL Server
server = 'DESKTOP-PNTRNKL\\SQLSERVER2022;'  # Substitua pelo nome do servidor
database = 'PIM'  # Substitua pelo nome do banco de dados
username = 'UID=Teste'  # Substitua pelo nome do usuário
password = '1234'  # Substitua pela senha do usuário

# Estabelece a conexão com o banco de dados
cnxn = pyodbc.connect(
    'DRIVER={ODBC Driver 17 for SQL Server};'
    'SERVER=' + server + ';'
    'DATABASE=' + database + ';'
    'UID=' + username + ';'
    'PWD=' + password
)

# Rota para listar todos os funcionários
@app.route('/funcionarios', methods=['GET'])
def get_funcionarios():
    # Cria um cursor para executar consultas no banco de dados
    cursor = cnxn.cursor()
    
    # Executa a consulta para selecionar todos os funcionários
    cursor.execute("SELECT idFuncionario, nome, email FROM Funcionarios")
    rows = cursor.fetchall()
    
    # Converte os resultados em uma lista de dicionários
    funcionarios = [{"idFuncionario": row[0], "nome": row[1], "email": row[2]} for row in rows]
    
    # Retorna a lista de funcionários no formato JSON
    return jsonify(funcionarios)

# Rota para obter um funcionário específico pelo ID
@app.route('/funcionarios/<int:id>', methods=['GET'])
def get_funcionario(id):
    # Cria um cursor para executar consultas no banco de dados
    cursor = cnxn.cursor()
    
    # Executa a consulta para selecionar o funcionário pelo ID
    cursor.execute("SELECT idFuncionario, nome, email FROM Funcionarios WHERE idFuncionario = ?", id)
    row = cursor.fetchone()
    
    # Verifica se o funcionário foi encontrado
    if row:
        # Converte o resultado em um dicionário
        funcionario = {"idFuncionario": row[0], "nome": row[1], "email": row[2]}
        return jsonify(funcionario)
    else:
        # Retorna uma mensagem de erro com o código HTTP 404
        return jsonify({"error": "Funcionario not found"}), 404

# Rota para adicionar um novo funcionário
@app.route('/funcionarios', methods=['POST'])
def add_funcionario():
    # Obtém os dados enviados na requisição
    data = request.json
    
    # Cria um cursor para executar consultas no banco de dados
    cursor = cnxn.cursor()
    
    # Insere os dados do novo funcionário no banco de dados
    cursor.execute("INSERT INTO Funcionarios (nome, email) VALUES (?, ?)", data['nome'], data['email'])
    cnxn.commit()  # Confirma a transação no banco de dados
    
    # Retorna uma mensagem de sucesso e o código HTTP 201 (Criado)
    return jsonify({"message": "Funcionario added successfully"}), 201

# Rota para atualizar os dados de um funcionário existente
@app.route('/funcionarios/<int:id>', methods=['PUT'])
def update_funcionario(id):
    # Obtém os dados enviados na requisição
    data = request.json
    
    # Cria um cursor para executar consultas no banco de dados
    cursor = cnxn.cursor()
    
    # Atualiza os dados do funcionário no banco de dados
    cursor.execute("UPDATE Funcionarios SET nome = ?, email = ? WHERE idFuncionario = ?", data['nome'], data['email'], id)
    cnxn.commit()  # Confirma a transação no banco de dados
    
    # Retorna uma mensagem de sucesso
    return jsonify({"message": "Funcionario updated successfully"})

# Rota para excluir um funcionário pelo ID
@app.route('/funcionarios/<int:id>', methods=['DELETE'])
def delete_funcionario(id):
    # Cria um cursor para executar consultas no banco de dados
    cursor = cnxn.cursor()
    
    # Exclui o funcionário pelo ID
    cursor.execute("DELETE FROM Funcionarios WHERE idFuncionario = ?", id)
    cnxn.commit()  # Confirma a transação no banco de dados
    
    # Retorna uma mensagem de sucesso
    return jsonify({"message": "Funcionario deleted successfully"})

# Ponto de entrada da aplicação
if __name__ == '_main':  # Corrigido _name para _name_
    # Executa a aplicação Flask em modo debug
    app.run(debug=True)