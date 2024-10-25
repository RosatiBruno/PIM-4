using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelaPimExercicio
{
    internal class AlteradorFonteFornecedores : AlteradorFonteMenu
    {
        //Construtor que chama o construtor da classe base
        public AlteradorFonteFornecedores(Form form) : base(form)
        {
        }

        //Altera o tamanho da fonte dos botões específicos da página de Fornecedores
        public void AlterarFonteFornecedores(Button btnLogout, Button btnRetornar)
        {
            float tamanhoFonte = 10; //Variável que define o tamanho da fonte

            btnLogout.Font = new Font(btnLogout.Font.FontFamily, tamanhoFonte);
            btnRetornar.Font = new Font(btnRetornar.Font.FontFamily, tamanhoFonte);
        }
    }
}