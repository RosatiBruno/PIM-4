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
                //Barra verde claro VERTICAL
                Size = new Size(125, form.ClientSize.Height),
                Location = new Point(0, 0),
                BackColor = ColorTranslator.FromHtml("#BDDCAD")
            };
        }
    }
}
