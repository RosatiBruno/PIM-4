from flask import Flask, request, jsonify, render_template
import pyodbc

# Inicialização do aplicativo Flask
app = Flask(__name__)

# Configuração da conexão com o banco de dados SQL Server
conn_str = (
    #"Driver={SQL Server};"  # Especifica o driver do SQL Server
        'DRIVER={ODBC Driver 17 for SQL Server};'
        "Server=DESKTOP-PNTRNKL\SQLSERVER2022;"  # Nome ou endereço do servidor de banco de dados
        "Database=PIM;"  # Nome do banco de dados
        "UID=Teste;"  # Usuário do banco de dados
        "PWD=1234;"  # Senha do banco de dados
)

# Estabelecendo conexão com o banco de dados
conn = pyodbc.connect(conn_str)
cursor = conn.cursor()

# Rota principal: renderiza a página inicial (index.html)
@app.route('/')
def index():
    return render_template('index.html')

# Rota para listar todas as produções
@app.route('/producoes', methods=['GET'])
def get_producoes():
    # Consulta para buscar todas as produções
    cursor.execute('SELECT * FROM Producoes')
    producoes = cursor.fetchall()
    
    # Formata os resultados como uma lista de dicionários
    producoes_list = [
        {
            'id': row[0], 
            'produto': row[1], 
            'quantidade': row[2], 
            'dataProducao': row[3], 
            'responsavel': row[4]
        } 
        for row in producoes
    ]
    
    # Retorna os dados em formato JSON
    return jsonify(producoes_list)

# Rota para adicionar uma nova produção
@app.route('/producoes', methods=['POST'])
def add_producao():
    # Obtém os dados enviados na requisição
    data = request.json
    
    # Insere os dados no banco de dados
    cursor.execute(
        'INSERT INTO Producoes (produto, quantidade, dataProducao, responsavel) VALUES (?, ?, ?, ?)',
        data['produto'], data['quantidade'], data['dataProducao'], data['responsavel']
    )
    
    # Confirma a transação no banco de dados
    conn.commit()
    
    # Retorna uma mensagem de sucesso
    return jsonify({'message': 'Produção adicionada com sucesso!'}), 201

# Rota para atualizar uma produção existente
@app.route('/producoes/<int:id>', methods=['PUT'])
def update_producao(id):
    # Obtém os dados enviados na requisição
    data = request.json
    
    # Atualiza os dados da produção correspondente no banco de dados
    cursor.execute(
        'UPDATE Producoes SET produto = ?, quantidade = ?, dataProducao = ?, responsavel = ? WHERE id = ?',
        data['produto'], data['quantidade'], data['dataProducao'], data['responsavel'], id
    )
    
    # Confirma a transação no banco de dados
    conn.commit()
    
    # Retorna uma mensagem de sucesso
    return jsonify({'message': 'Produção atualizada com sucesso!'})

# Rota para excluir uma produção pelo ID
@app.route('/producoes/<int:id>', methods=['DELETE'])
def delete_producao(id):
    # Remove a produção correspondente no banco de dados
    cursor.execute('DELETE FROM Producoes WHERE id = ?', id)
    
    # Confirma a transação no banco de dados
    conn.commit()
    
    # Retorna uma mensagem de sucesso
    return jsonify({'message': 'Produção excluída com sucesso!'})

# Verifica se o script está sendo executado diretamente
if __name__ == 'main':
    # Executa o servidor Flask no modo de depuração
    app.run(debug=True)