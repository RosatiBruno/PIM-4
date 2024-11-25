const express = require('express');
const sqlite3 = require('sqlite3').verbose();
const bodyParser = require('body-parser');
const path = require('path');

const app = express();
const db = new sqlite3.Database('bd_teste.db');

// Configuração do middleware
app.use(bodyParser.json());
app.use(express.static(path.join(__dirname, 'public'))); // Servir arquivos estáticos (HTML, CSS, JS)

// Criação da tabela de funcionários se não existir
db.serialize(() => {
    db.run(`
        CREATE TABLE IF NOT EXISTS funcionarios (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            nome TEXT NOT NULL,
            id_funcionario TEXT UNIQUE NOT NULL,
            email TEXT NOT NULL,
            senha TEXT NOT NULL
        )
    `, (err) => {
        if (err) {
            console.error('Erro ao criar tabela:', err.message);
        }
    });
});

// Rota para adicionar funcionário
app.post('/adicionar', (req, res) => {
    const { nome, id_funcionario, email, senha } = req.body;

    if (!nome || !id_funcionario || !email || !senha) {
        return res.status(400).json({ error: 'Todos os campos são obrigatórios.' });
    }

    const query = INSERT INTO funcionarios (nome, id_funcionario, email, senha) VALUES (?, ?, ?, ?);
    db.run(query, [nome, id_funcionario, email, senha], function (err) {
        if (err) {
            return res.status(500).json({ error: err.message });
        }
        res.status(201).json({ id: this.lastID });
    });
});

// Rota para editar funcionário
app.put('/editar/:id', (req, res) => {
    const { id } = req.params;
    const { nome, id_funcionario, email, senha } = req.body;

    const query = UPDATE funcionarios SET nome = ?, id_funcionario = ?, email = ?, senha = ? WHERE id = ?;
    db.run(query, [nome, id_funcionario, email, senha, id], function (err) {
        if (err) {
            return res.status(500).json({ error: err.message });
        }
        res.status(200).json({ changes: this.changes });
    });
});

// Rota para deletar funcionário
app.delete('/deletar/:id', (req, res) => {
    const { id } = req.params;

    const query = DELETE FROM funcionarios WHERE id = ?;
    db.run(query, id, function (err) {
        if (err) {
            return res.status(500).json({ error: err.message });
        }
        res.status(200).json({ changes: this.changes });
    });
});

// Rota para consultar funcionários
app.get('/consultar', (req, res) => {
    db.all(SELECT * FROM funcionarios, [], (err, rows) => {
        if (err) {
            return res.status(500).json({ error: err.message });
        }
        res.json(rows);
    });
});

// Inicializa o servidor
const PORT = process.env.PORT || 3000;
app.listen(PORT, () => {
    console.log(Servidor rodando em http://localhost:${PORT});
});