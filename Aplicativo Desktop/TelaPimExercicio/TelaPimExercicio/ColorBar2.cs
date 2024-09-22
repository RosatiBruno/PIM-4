using System.Drawing;
using System.Windows.Forms;

namespace TelaPimExercicio
{
    public class ColorBar2
    {
        public Panel Panel { get; private set; }

        public ColorBar2(Form form)
        {
            Panel = new Panel
            {
                Size = new Size(125, form.ClientSize.Height), // Largura 125, altura igual à do formulário
                Location = new Point(0, 0), // Posição no canto superior esquerdo
                BackColor = ColorTranslator.FromHtml("#BDDCAD") // Cor da barra
            };
        }
    }
}
