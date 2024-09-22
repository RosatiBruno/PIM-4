using System.Drawing;
using System.Windows.Forms;

namespace TelaPimExercicio
{
    public class ColorBar
    {
        public Panel Panel { get; private set; }

        public ColorBar(Form form)
        {
            Panel = new Panel
            {
                //Barra verde claro HORIZONTAL
                Size = new Size(form.ClientSize.Width, 80),
                Location = new Point(0, 0),
                BackColor = ColorTranslator.FromHtml("#BDDCAD")
            };
        }
    }
}
