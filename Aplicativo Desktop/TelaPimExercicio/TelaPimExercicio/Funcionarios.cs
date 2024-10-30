using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelaPimExercicio
{
    public class Funcionarios
    {
        //Dados coletados ao cadastrar um fornecedor
        //public string ID { get; set; }   //Para atribuir o ID que foi digitado
        public int ID { get; set; }        //Para atribuir o ID sequencial automaticamente
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }

    public static class RepositorioFuncionarios
    {
        //Lista de pedidos ativos
        public static List<Funcionarios> ListaFuncionarios = new List<Funcionarios>();

        //Lista de pedidos excluidos
        public static List<Funcionarios> ListaFuncionariosExcluidos { get; set; } = new List<Funcionarios>();

        private static int proximoID = 1; //Contador de ID começa em 1

        //Gera o próximo ID automaticamente
        public static int GerarNovoID()
        {
            return proximoID++;
        }



        static RepositorioFuncionarios()
        {
            // Adicionando perfis padrões
            ListaFuncionarios.Add(new Funcionarios { ID = GerarNovoID(), Nome = "func", Email = "func@example.com", Senha = "1234" });
            ListaFuncionarios.Add(new Funcionarios { ID = GerarNovoID(), Nome = "gerente", Email = "gerente@example.com", Senha = "1234" });
            ListaFuncionarios.Add(new Funcionarios { ID = GerarNovoID(), Nome = "ti", Email = "ti@example.com", Senha = "1234" });
        }
        public static bool AutenticarFuncionario(string tempId, string tempSenha)
        {
            return ListaFuncionarios.Any(func => func.Nome == tempId && func.Senha == tempSenha);
        }
    }
   





    public static class RepositorioFuncionarios2
    {
        private static int proximoID = 4; //Contador de ID começa em 1

        //Gera o próximo ID automaticamente
        public static int GerarNovoID()
        {
            return proximoID++;
        }
    }
}