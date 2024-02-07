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
    public partial class chair_view : UserControl
    {
        public chair_view()
        {
            InitializeComponent();
        }

    
        public void check_empty_chair(int chair_no)
        {
            try
            {
                switch (chair_no)
            {
                case 1:
                    pictureBox1.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 2:
                    pictureBox2.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 3:
                    pictureBox3.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 4:
                    pictureBox4.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 5:
                    pictureBox5.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 6:
                    pictureBox6.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 7:
                    pictureBox7.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 8:
                    pictureBox8.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;


                case 9:
                    pictureBox9.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 10:
                    pictureBox10.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 11:
                    pictureBox11.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 12:
                    pictureBox12.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 13:
                    pictureBox13.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 14:
                    pictureBox14.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 15:
                    pictureBox15.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 16:
                    pictureBox16.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;


                case 17:
                    pictureBox17.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 18:
                    pictureBox18.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 19:
                    pictureBox19.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 20:
                    pictureBox20.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 21:
                    pictureBox21.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 22:
                    pictureBox22.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 23:
                    pictureBox23.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 24:
                    pictureBox24.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;


                case 25:
                    pictureBox25.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 26:
                    pictureBox26.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 27:
                    pictureBox27.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 28:
                    pictureBox28.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 29:
                    pictureBox29.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 30:
                    pictureBox30.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 31:
                    pictureBox31.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 32:
                    pictureBox32.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;


                case 33:
                    pictureBox33.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 34:
                    pictureBox34.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 35:
                    pictureBox35.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 36:
                    pictureBox36.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 37:
                    pictureBox37.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 38:
                    pictureBox38.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 39:
                    pictureBox39.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 40:
                    pictureBox40.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;


                case 41:
                    pictureBox41.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 42:
                    pictureBox42.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 43:
                    pictureBox43.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 44:
                    pictureBox44.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 45:
                    pictureBox45.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 46:
                    pictureBox46.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 47:
                    pictureBox47.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 48:
                    pictureBox48.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;


                case 49:
                    pictureBox49.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 50:
                    pictureBox50.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 51:
                    pictureBox51.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 52:
                    pictureBox52.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 53:
                    pictureBox53.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 54:
                    pictureBox54.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 55:
                    pictureBox55.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 56:
                    pictureBox56.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;


                case 57:
                    pictureBox57.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 58:
                    pictureBox58.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 59:
                    pictureBox59.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 60:
                    pictureBox60.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 61:
                    pictureBox61.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 62:
                    pictureBox62.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 63:
                    pictureBox63.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
                case 64:
                    pictureBox64.Image = Sinema_Otomasyonu.Properties.Resources.empty_chair;
                    break;
            }
            } catch { MessageBox.Show("Koltuk Verisi Alınırken Hata Oluştu"); }
            
        }
    }
}
