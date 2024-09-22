using System.Drawing;
using System.Windows.Forms;

namespace TelaPimExercicio
{
    public class ColorSquare
    {
        public Panel Panel { get; private set; }

        public ColorSquare(Form form)
        {
            Panel = new Panel
            {
                Size = new Size(form.ClientSize.Width, 125),
                Location = new Point(0, 0),
                BackColor = ColorTranslator.FromHtml("#D9D9D9")
            };
        }
    }
}
