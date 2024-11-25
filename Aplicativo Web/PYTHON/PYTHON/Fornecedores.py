import pyodbc  # Biblioteca para conexão com o banco de dados SQL Server
from flask import Flask, request, jsonify  # Flask para criação da API e manipulação de requisições

# Inicialização do aplicativo Flask
app = Flask(__name__)

# Função para configurar e obter a conexão com o banco de dados SQL Server
def get_db_connection():
    conn = pyodbc.connect(
        #"Driver={SQL Server};"  # Especifica o driver do SQL Server
        "Server=DESKTOP-PNTRNKL\\SQLSERVER2022;"  # Nome ou endereço do servidor de banco de dados
        "Database=PIM;"  # Nome do banco de dados
        "UID=Teste;"  # Usuário do banco de dados
        "PWD=1234;"  # Senha do banco de dados
    )
    return conn  # Retorna a conexão estabelecida

# Rota para listar todos os fornecedores
@app.route('/fornecedores', methods=['GET'])
def listar_fornecedores():
    # Conecta ao banco de dados
    conn = get_db_connection()
    cursor = conn.cursor()
    
    # Executa uma consulta SQL para obter todos os fornecedores
    cursor.execute("SELECT * FROM Fornecedores")
    
    # Converte os resultados da consulta em uma lista de dicionários
    fornecedores = [
        dict(
            id=row[0],
            nome=row[1],
            cep=row[2],
            telefone=row[3],
            cnpj=row[4],
            endereco=row[5],
            email=row[6],
            situacao=row[7],
            complemento=row[8],
            representante=row[9],
            codigo=row[10],
            cidade=row[11],
            estado=row[12],
            materiaPrima=row[13],
            razaoSocial=row[14]
        )
        for row in cursor.fetchall()  # Obtém todas as linhas da consulta
    ]
    
    # Fecha a conexão com o banco de dados
    conn.close()
    
    # Retorna os fornecedores em formato JSON
    return jsonify(fornecedores)

# Rota para atualizar um fornecedor específico pelo ID
@app.route('/fornecedores/<int:id>', methods=['PUT'])
def atualizar_fornecedor(id):
    # Obtém os dados enviados no corpo da requisição (JSON)
    data = request.json
    
    # Conecta ao banco de dados
    conn = get_db_connection()
    cursor = conn.cursor()
    
    # Executa o comando SQL para atualizar os dados do fornecedor
    cursor.execute("""
        UPDATE Fornecedores SET 
        nome=?, cep=?, telefone=?, cnpj=?, endereco=?, email=?, situacao=?, 
        complemento=?, representante=?, codigo=?, cidade=?, estado=?, 
        materiaPrima=?, razaoSocial=? 
        WHERE id=?
    """, (
        data['nome'], data['cep'], data['telefone'], data['cnpj'], data['endereco'],
        data['email'], data['situacao'], data['complemento'], data['representante'],
        data['codigo'], data['cidade'], data['estado'], data['materiaPrima'], 
        data['razaoSocial'], id
    ))
    
    # Confirma as alterações no banco de dados
    conn.commit()
    
    # Fecha a conexão com o banco de dados
    conn.close()
    
    # Retorna uma mensagem de sucesso
    return jsonify({"message": "Fornecedor atualizado com sucesso!"})

# Rota para deletar um fornecedor específico pelo ID
@app.route('/fornecedores/<int:id>', methods=['DELETE'])
def deletar_fornecedor(id):
    # Conecta ao banco de dados
    conn = get_db_connection()
    cursor = conn.cursor()
    
    # Executa o comando SQL para deletar o fornecedor pelo ID
    cursor.execute("DELETE FROM Fornecedores WHERE id=?", id)
    
    # Confirma a exclusão no banco de dados
    conn.commit()
    
    # Fecha a conexão com o banco de dados
    conn.close()
    
    # Retorna uma mensagem de sucesso
    return jsonify({"message": "Fornecedor deletado com sucesso!"})

# Inicia o servidor Flask apenas se o script for executado diretamente
if __name__== '_main_':
    app.run(debug=True)  # Executa o servidor em modo debug (útil para desenvolvimento)