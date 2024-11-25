const express = require('express');
const sqlite3 = require('sqlite3').verbose();
const bodyParser = require('body-parser');

const app = express();
const port = 3000;

// Middleware para JSON
app.use(bodyParser.json());

// Conexão com o banco de dados SQLite
const db = new sqlite3.Database('./bd_teste.db', (err) => {
    if (err) {
        console.error('Erro ao conectar no SQLite:', err.message);
    } else {
        console.log('Conectado ao banco de dados SQLite.');
        // Cria a tabela, caso não exista
        db.run(`CREATE TABLE IF NOT EXISTS producao (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            produto TEXT NOT NULL,
            quantidade INTEGER NOT NULL,
            data_producao TEXT NOT NULL,
            responsavel TEXT NOT NULL
        )`);
    }
});

// Rota para adicionar uma produção
app.post('/producoes', (req, res) => {
    const { produto, quantidade, data_producao, responsavel } = req.body;
    const sql = `INSERT INTO producao (produto, quantidade, data_producao, responsavel)
                 VALUES (?, ?, ?, ?)`;
    db.run(sql, [produto, quantidade, data_producao, responsavel], function(err) {
        if (err) {
            res.status(500).json({ error: err.message });
        } else {
            res.status(201).json({ id: this.lastID });
        }
    });
});

// Rota para listar produções
app.get('/producoes', (req, res) => {
    const sql = SELECT * FROM producao;
    db.all(sql, [], (err, rows) => {
        if (err) {
            res.status(500).json({ error: err.message });
        } else {
            res.status(200).json(rows);
        }
    });
});

// Rota para atualizar uma produção
app.put('/producoes/:id', (req, res) => {
    const { produto, quantidade, data_producao, responsavel } = req.body;
    const { id } = req.params;
    const sql = UPDATE producao SET produto = ?, quantidade = ?, data_producao = ?, responsavel = ? WHERE id = ?;
    db.run(sql, [produto, quantidade, data_producao, responsavel, id], function(err) {
        if (err) {
            res.status(500).json({ error: err.message });
        } else {
            res.status(200).json({ message: 'Produção atualizada com sucesso!' });
        }
    });
});

// Rota para deletar uma produção
app.delete('/producoes/:id', (req, res) => {
    const { id } = req.params;
    const sql = DELETE FROM producao WHERE id = ?;
    db.run(sql, id, function(err) {
        if (err) {
            res.status(500).json({ error: err.message });
        } else {
            res.status(200).json({ message: 'Produção deletada com sucesso!' });
        }
    });
});

// Inicia o servidor
app.listen(port, () => {
    console.log(Servidor rodando em http://localhost:${port});
});