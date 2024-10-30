using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelaPimExercicio
{
    public class Fornecedor
    {
        //Dados coletados ao cadastrar um fornecedor
        //public string ID { get; set; }   //Para atribuir o ID que foi digitado
        public int ID { get; set; }        //Para atribuir o ID sequencial automaticamente
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Representante { get; set; }
        public string RazaoSocial { get; set; }
        public string MateriaPrima { get; set; }
        public string SituacaoFornecedor { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
    }

    public static class RepositorioFornecedores
    {
        //Lista de fornecedores ativos
        public static List<Fornecedor> ListaFornecedores = new List<Fornecedor>();

        //Lista de fornecedores inativos
        public static List<Fornecedor> ListaFornecedoresInativos { get; set; } = new List<Fornecedor>();

        private static int proximoID = 1; //Contador de ID começa em 1

        //Gera o próximo ID automaticamente
        public static int GerarNovoID()
        {
            return proximoID++;
        }
    }
    public static class RepositorioFornecedores2
    {
        private static int proximoID = 1; //Contador de ID começa em 1

        //Gera o próximo ID automaticamente
        public static int GerarNovoID()
        {
            return proximoID++;
        }
    }
}