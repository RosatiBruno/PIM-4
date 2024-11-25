const express = require('express');
const sqlite3 = require('sqlite3').verbose();
const bodyParser = require('body-parser');
const cors = require('cors');

// Configuração do aplicativo Express
const app = express();
const PORT = 3000;

// Middleware
app.use(bodyParser.json());
app.use(cors());

// Conexão com o banco de dados SQLite
const db = new sqlite3.Database('bd_teste.db', (err) => {
    if (err) {
        console.error('Erro ao conectar ao banco de dados:', err.message);
    } else {
        console.log('Conectado ao banco de dados SQLite.');
        criarTabela();
    }
});

// Função para criar a tabela de fornecedores, caso ainda não exista
function criarTabela() {
    const query = `
        CREATE TABLE IF NOT EXISTS fornecedores (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            nome TEXT,
            cep TEXT,
            telefone TEXT,
            cnpj TEXT UNIQUE,
            endereco TEXT,
            email TEXT,
            situacao TEXT,
            complemento TEXT,
            representante TEXT,
            codigo TEXT,
            cidade TEXT,
            estado TEXT,
            materiaPrima TEXT,
            razaoSocial TEXT
        )
    `;
    db.run(query, (err) => {
        if (err) {
            console.error('Erro ao criar tabela:', err.message);
        } else {
            console.log('Tabela de fornecedores pronta.');
        }
    });
}

// Rota para listar todos os fornecedores
app.get('/fornecedores', (req, res) => {
    const query = SELECT * FROM fornecedores WHERE situacao = 'Ativo';
    db.all(query, [], (err, rows) => {
        if (err) {
            res.status(500).json({ error: err.message });
        } else {
            res.json(rows);
        }
    });
});

// Rota para adicionar um novo fornecedor
app.post('/fornecedores', (req, res) => {
    const fornecedor = req.body;
    const query = `
        INSERT INTO fornecedores (nome, cep, telefone, cnpj, endereco, email, situacao, complemento, representante, codigo, cidade, estado, materiaPrima, razaoSocial)
        VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
    `;
    const valores = [
        fornecedor.nome,
        fornecedor.cep,
        fornecedor.telefone,
        fornecedor.cnpj,
        fornecedor.endereco,
        fornecedor.email,
        fornecedor.situacao || 'Ativo',
        fornecedor.complemento,
        fornecedor.representante,
        fornecedor.codigo,
        fornecedor.cidade,
        fornecedor.estado,
        fornecedor.materiaPrima,
        fornecedor.razaoSocial,
    ];

    db.run(query, valores, function (err) {
        if (err) {
            res.status(500).json({ error: err.message });
        } else {
            res.status(201).json({ message: 'Fornecedor adicionado com sucesso!', id: this.lastID });
        }
    });
});

// Rota para inativar um fornecedor pelo CNPJ
app.patch('/fornecedores/inativar/:cnpj', (req, res) => {
    const cnpj = req.params.cnpj;
    const query = UPDATE fornecedores SET situacao = 'Inativo' WHERE cnpj = ?;

    db.run(query, [cnpj], function (err) {
        if (err) {
            res.status(500).json({ error: err.message });
        } else if (this.changes === 0) {
            res.status(404).json({ message: 'Fornecedor não encontrado.' });
        } else {
            res.json({ message: 'Fornecedor inativado com sucesso!' });
        }
    });
});

// Inicialização do servidor
app.listen(PORT, () => {
    console.log(Servidor rodando em http://localhost:${PORT});
});