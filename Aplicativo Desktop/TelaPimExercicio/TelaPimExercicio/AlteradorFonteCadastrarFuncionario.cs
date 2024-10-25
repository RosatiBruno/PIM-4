using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelaPimExercicio
{
    internal class AlteradorFonteCadastrarFuncionario : AlteradorFonteMenu
    {
        // Construtor que chama o construtor da classe base
        public AlteradorFonteCadastrarFuncionario(Form form) : base(form)
        {
        }

        // Altera o tamanho da fonte dos botões específicos da página de Cadastrar Funcionário
        public void AlterarFonteCadastrarFuncionario(Button btnLogout, Button btnRetornar)
        {
            float tamanhoFonte = 10; // Variável que define o tamanho da fonte

            btnLogout.Font = new Font(btnLogout.Font.FontFamily, tamanhoFonte);
            btnRetornar.Font = new Font(btnRetornar.Font.FontFamily, tamanhoFonte);
        }
    }
}