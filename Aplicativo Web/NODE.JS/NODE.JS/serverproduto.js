const express = require('express');
const sqlite3 = require('sqlite3').verbose();
const bodyParser = require('body-parser');

const app = express();
const PORT = 3000;

// Configurar middleware
app.use(bodyParser.json());

// Conectar ao banco de dados bd_teste
const db = new sqlite3.Database('./bd_teste.db', (err) => {
    if (err) {
        console.error('Erro ao conectar ao banco de dados:', err.message);
    } else {
        console.log('Conectado ao banco de dados SQLite.');
    }
});

// Criar tabela de produtos (se não existir)
db.run(`
    CREATE TABLE IF NOT EXISTS Produtos (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        nome TEXT NOT NULL,
        quantidade INTEGER NOT NULL,
        valor REAL NOT NULL
    )
`);

// Endpoint para listar todos os produtos
app.get('/produtos', (req, res) => {
    db.all('SELECT * FROM Produtos', [], (err, rows) => {
        if (err) {
            res.status(500).json({ error: err.message });
        } else {
            res.status(200).json(rows);
        }
    });
});

// Endpoint para adicionar um novo produto
app.post('/produtos', (req, res) => {
    const { nome, quantidade, valor } = req.body;
    db.run(
        'INSERT INTO Produtos (nome, quantidade, valor) VALUES (?, ?, ?)',
        [nome, quantidade, valor],
        function (err) {
            if (err) {
                res.status(500).json({ error: err.message });
            } else {
                res.status(201).json({ id: this.lastID });
            }
        }
    );
});

// Endpoint para editar um produto
app.put('/produtos/:id', (req, res) => {
    const { id } = req.params;
    const { nome, quantidade, valor } = req.body;

    db.run(
        'UPDATE Produtos SET nome = ?, quantidade = ?, valor = ? WHERE id = ?',
        [nome, quantidade, valor, id],
        function (err) {
            if (err) {
                res.status(500).json({ error: err.message });
            } else {
                res.status(200).json({ message: 'Produto atualizado com sucesso!' });
            }
        }
    );
});

// Endpoint para excluir um produto
app.delete('/produtos/:id', (req, res) => {
    const { id } = req.params;

    db.run('DELETE FROM Produtos WHERE id = ?', [id], function (err) {
        if (err) {
            res.status(500).json({ error: err.message });
        } else {
            res.status(200).json({ message: 'Produto excluído com sucesso!' });
        }
    });
});

// Iniciar servidor
app.listen(PORT, () => {
    console.log(Servidor rodando em http://localhost:${PORT});
});