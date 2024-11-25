const express = require('express');
const sqlite3 = require('sqlite3').verbose();
const cors = require('cors');

const app = express();
const port = 3000;

// Middleware para processar JSON e permitir CORS
app.use(express.json());
app.use(cors());

// Conexão com o banco de dados SQLite
const db = new sqlite3.Database('./bd_teste.db', (err) => {
    if (err) {
        console.error('Erro ao conectar ao banco de dados:', err.message);
    } else {
        console.log('Conectado ao banco de dados bd_teste.');
    }
});

// Criação da tabela "pedidos" (se ainda não existir)
db.run(`
    CREATE TABLE IF NOT EXISTS pedidos (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        nomeProduto TEXT NOT NULL,
        quantidade INTEGER NOT NULL,
        valor REAL NOT NULL,
        empresaResponsavel TEXT NOT NULL
    )
`);

// Rota para listar todos os pedidos
app.get('/pedidos', (req, res) => {
    db.all('SELECT * FROM pedidos', [], (err, rows) => {
        if (err) {
            res.status(500).json({ error: err.message });
        } else {
            res.json(rows);
        }
    });
});

// Rota para adicionar um novo pedido
app.post('/pedidos', (req, res) => {
    const { nomeProduto, quantidade, valor, empresaResponsavel } = req.body;
    db.run(
        'INSERT INTO pedidos (nomeProduto, quantidade, valor, empresaResponsavel) VALUES (?, ?, ?, ?)',
        [nomeProduto, quantidade, valor, empresaResponsavel],
        function (err) {
            if (err) {
                res.status(500).json({ error: err.message });
            } else {
                res.json({ id: this.lastID });
            }
        }
    );
});

// Rota para editar um pedido pelo ID
app.put('/pedidos/:id', (req, res) => {
    const { nomeProduto, quantidade, valor, empresaResponsavel } = req.body;
    const { id } = req.params;
    db.run(
        'UPDATE pedidos SET nomeProduto = ?, quantidade = ?, valor = ?, empresaResponsavel = ? WHERE id = ?',
        [nomeProduto, quantidade, valor, empresaResponsavel, id],
        function (err) {
            if (err) {
                res.status(500).json({ error: err.message });
            } else {
                res.json({ changes: this.changes });
            }
        }
    );
});

// Rota para excluir um pedido pelo ID
app.delete('/pedidos/:id', (req, res) => {
    const { id } = req.params;
    db.run('DELETE FROM pedidos WHERE id = ?', [id], function (err) {
        if (err) {
            res.status(500).json({ error: err.message });
        } else {
            res.json({ changes: this.changes });
        }
    });
});

// Inicializa o servidor na porta especificada
app.listen(port, () => {
    console.log(Servidor rodando em http://localhost:${port});
});