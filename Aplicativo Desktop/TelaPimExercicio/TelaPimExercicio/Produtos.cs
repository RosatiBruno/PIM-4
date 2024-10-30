using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelaPimExercicio
{
    public class Produtos
    {
        //Dados coletados ao cadastrar um fornecedor
        //public string ID { get; set; }   //Para atribuir o ID que foi digitado
        public int ID { get; set; }        //Para atribuir o ID sequencial automaticamente
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public string EmpresaCompra { get; set; }
    }

    public static class RepositorioProdutos
    {
        //Lista de pedidos ativos
        public static List<Produtos> ListaProdutos = new List<Produtos>();

        //Lista de pedidos excluidos
        public static List<Produtos> ListaProdutosExcluidos { get; set; } = new List<Produtos>();

        private static int proximoID = 1; //Contador de ID começa em 1

        //Gera o próximo ID automaticamente
        public static int GerarNovoID()
        {
            return proximoID++;
        }
    }
    public static class RepositorioProdutos2
    {
        private static int proximoID = 1; //Contador de ID começa em 1

        //Gera o próximo ID automaticamente
        public static int GerarNovoID()
        {
            return proximoID++;
        }
    }

}