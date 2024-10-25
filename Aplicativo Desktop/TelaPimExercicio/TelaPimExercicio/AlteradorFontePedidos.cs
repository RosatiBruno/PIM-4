using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelaPimExercicio
{
    internal class AlteradorFontePedidos : AlteradorFonteMenu
    {
        // Construtor que chama o construtor da classe base
        public AlteradorFontePedidos(Form form) : base(form)
        {
        }

        // Altera o tamanho da fonte dos botões específicos da página de Pedidos
        public void AlterarFontePedidos(Button btnLogout2, Button btnRetornar2)
        {
            float tamanhoFonte = 10; // Variável que define o tamanho da fonte

            btnLogout2.Font = new Font(btnLogout2.Font.FontFamily, tamanhoFonte);
            btnRetornar2.Font = new Font(btnRetornar2.Font.FontFamily, tamanhoFonte);
        }
    }
}