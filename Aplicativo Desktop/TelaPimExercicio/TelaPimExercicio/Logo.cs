using System.Drawing;
using System.Windows.Forms;

namespace TelaPimExercicio
{
    public class Logo
    {
        public PictureBox Picture { get; private set; }

        public Logo(Form form)
        {
            Picture = new PictureBox
            {
                Size = new Size(85, 85),
                Location = new Point((form.ClientSize.Width - 85) / 2, 16),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Image.FromFile("C:\\Users\\Marcia\\Desktop\\PIM-4\\Aplicativo Desktop\\TelaPimExercicio\\logoFinal.png") // Verifique o caminho
            };
        }
    }
}
