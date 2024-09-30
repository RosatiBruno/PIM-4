using System;
using System.Windows.Forms;

namespace TelaPimExercicio
{
    public class Logout
    {
        private Form currentForm;

        public Logout(Form form)
        {
            currentForm = form;
        }

        public void ShowLogoutDialog()
        {
            DialogResult resultado = MessageBox.Show("Deseja realizar o Logout?", "Confirmação de Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Form1 form1 = new Form1();
                form1.FormClosed += (s, args) => currentForm.Close();
                form1.Show();
                currentForm.Hide();
            }
        }
    }
}
