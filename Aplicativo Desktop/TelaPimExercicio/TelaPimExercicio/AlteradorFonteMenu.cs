using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelaPimExercicio
{
    internal class AlteradorFonteMenu
    {
        private readonly Form parentForm;

        public AlteradorFonteMenu(Form form)
        {
            this.parentForm = form;
        }

        //Altera o tamanho da fonte dos botões do menu
        public void AlterarFonteMenu(Button btnFornecedores, Button btnPedidos, Button btnProdutos, Button btnCadastrarFunc, Button btnVendas, Button btnProducao, Button btnLogout)
        {
            float tamanhoFonte = 10; //Variavel que define o tamanho da fonte           
            btnFornecedores.Font = new Font(btnFornecedores.Font.FontFamily, tamanhoFonte);
            btnPedidos.Font = new Font(btnPedidos.Font.FontFamily, tamanhoFonte);
            btnProdutos.Font = new Font(btnProdutos.Font.FontFamily, tamanhoFonte);
            btnCadastrarFunc.Font = new Font(btnCadastrarFunc.Font.FontFamily, tamanhoFonte);
            btnVendas.Font = new Font(btnVendas.Font.FontFamily, tamanhoFonte);
            btnProducao.Font = new Font(btnProducao.Font.FontFamily, tamanhoFonte);
            btnLogout.Font = new Font(btnLogout.Font.FontFamily, tamanhoFonte);
        }
    }
}