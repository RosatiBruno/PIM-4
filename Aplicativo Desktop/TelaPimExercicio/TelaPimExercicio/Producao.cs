using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelaPimExercicio
{
    public class Producao
    {
        //Dados coletados ao cadastrar um fornecedor
        //public string ID { get; set; }   //Para atribuir o ID que foi digitado
        public int ID { get; set; }        //Para atribuir o ID sequencial automaticamente
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public string Data { get; set; }
        public string ResponsavelProducao { get; set; }
    }

    public static class RepositorioProducao
    {
        //Lista de pedidos ativos
        public static List<Producao> ListaProducao = new List<Producao>();

        //Lista de pedidos excluidos
        public static List<Producao> ListaProducaoExcluidos { get; set; } = new List<Producao>();

        private static int proximoID = 1; //Contador de ID começa em 1

        //Gera o próximo ID automaticamente
        public static int GerarNovoID()
        {
            return proximoID++;
        }
    }
    public static class RepositorioProducao2
    {
        private static int proximoID = 1; //Contador de ID começa em 1

        //Gera o próximo ID automaticamente
        public static int GerarNovoID()
        {
            return proximoID++;
        }
    }

}
