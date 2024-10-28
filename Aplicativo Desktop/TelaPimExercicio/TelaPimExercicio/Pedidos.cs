using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelaPimExercicio
{
    public class Pedidos
    {
        //Dados coletados ao cadastrar um fornecedor
        //public string ID { get; set; }   //Para atribuir o ID que foi digitado
        public int ID { get; set; }        //Para atribuir o ID sequencial automaticamente
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public string EmpresaCompra {  get; set; }
    }

    public static class RepositorioPedidos
    {
        //Lista de fornecedores ativos
        public static List<Pedidos> ListaPedidos = new List<Pedidos>();

        //Lista de fornecedores inativos
        //public static List<Pedidos> ListaPedidosInativos { get; set; } = new List<Pedidos>();

        private static int proximoID = 1; //Contador de ID começa em 1

        //Gera o próximo ID automaticamente
        public static int GerarNovoID()
        {
            return proximoID++;
        }
    }



}
