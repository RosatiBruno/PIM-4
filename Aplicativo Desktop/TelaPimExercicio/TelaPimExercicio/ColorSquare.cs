using System.Drawing;
using System.Windows.Forms;

namespace TelaPimExercicio
{
    public class ColorSquare
    {
        public Panel Panel { get; private set; }

        public ColorSquare(Form form)
        {
            // Tamanho do "quadrado"
            int horizontal = 300;
            int vertical = 250;

            Panel = new Panel
            {
                Size = new Size(vertical, horizontal),
                Location = new Point((form.ClientSize.Width - vertical) / 2, (form.ClientSize.Height - horizontal + 20) / 2), // Centralizado
                BackColor = ColorTranslator.FromHtml("#D9D9D9")
            };
        }
    }
}