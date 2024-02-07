using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinema_Otomasyonu
{
    public partial class login_form : Form
    {
        public login_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin")
            {
                if (textBox2.Text == "password")
                {
                    MessageBox.Show("Giriş Başarılı!");
                    Main_Form main_Form = new Main_Form();
                    main_Form.Show();
                    this.Hide();
                } else
                {
                    MessageBox.Show("Hatalı Giriş!");
                }
            }
            else
            {
                MessageBox.Show("Hatalı Giriş!");
            }
        }
    }
}
