using System.Drawing;
using System.Windows.Forms;

namespace TelaPimExercicio
{
    public class ColorBackground
    {
        public Panel Panel { get; private set; }

        public ColorBackground(Form form)
        {
            Panel = new Panel
            {
                Size = new Size(form.ClientSize.Width, form.ClientSize.Height),
                Location = new Point(0, 0),
                BackColor = ColorTranslator.FromHtml("#71876F")
            };
        }
    }
}
