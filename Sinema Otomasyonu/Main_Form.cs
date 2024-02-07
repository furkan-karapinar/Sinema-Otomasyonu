using Microsoft.VisualBasic;
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
    public partial class Main_Form : Form
    {
        Database_Control database_control = new Database_Control();
        public int parent_price = 0;
        public int student_price = 0;
        public int child_price = 0;
        int selected_price;
        public Main_Form()
        {
            InitializeComponent();
        }

        private void create_database()
        {
            // Satış kaydı için veritabanı tablosu oluşturulur. Hata durumunda bildirilir.
            try
            {
                database_control.Create_Database("cinema_sales_database", "full_name VARCHAR(50) , film_name VARCHAR(25) , room_name VARCHAR(25) , ticket_date VARCHAR(50) , time VARCHAR(25) , chair_no INTEGER , cash INTEGER");

            } catch { MessageBox.Show("Veritabanı Oluşturma Hatası"); }


        }

        private void get_data()
        {
            // Try içindekiler yapılır. Hata durumunda belirtir.
            try
            {
                // Ana ekrandaki girdilere seçenekler girilir.
                database_control.Get_Data_From_Database_For_Combobox("cinema_film_database", comboBox1);
                database_control.Get_Data_From_Database_For_Combobox("cinema_room_database", comboBox2);
                database_control.Get_Data_From_Database_For_Combobox("cinema_time_database", comboBox3);

                // Veritabanından ücret bilgisini alır ve gerekli değişkenlere kaydeder.
                parent_price = Convert.ToInt32(database_control.Get_Data_From_ConfigDatabase("parent_price"));
                student_price = Convert.ToInt32(database_control.Get_Data_From_ConfigDatabase("student_price"));
                child_price = Convert.ToInt32(database_control.Get_Data_From_ConfigDatabase("child_price"));

                // Ana ekrandaki gerekli bilgiler girildikten sonra boş/dolu koltuk durumunu belirtir.
                panel1.Controls.Clear();
                panel1.Controls.Add(database_control.Get_Data_From_Database_For_Chair_Info(dateTimePicker1.Text,comboBox2.Text,comboBox3.Text));
            }
            catch { MessageBox.Show("Veri Alımı Hatası"); }
        }

        private void salonListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Yeni bir salon listesi formu oluşturur ve gösterir.
            Room_List room_List = new Room_List();
            room_List.Show();
        }

        private void seansListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Yeni bir seans listesi formu oluşturur ve gösterir.
            time_list tm_List = new time_list();
            tm_List.Show();
        }

        private void filmListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Yeni bir film listesi formu oluşturur ve gösterir.
            film_list flm_List = new film_list();
            flm_List.Show();
        }

        private void satışListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Yeni bir satış listesi formu oluşturur ve gösterir.
            sales_list sales_List = new sales_list();
            sales_List.Show();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Programı sonlandırır.
            Application.Exit();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            // Gerekli veritablosu yoksa oluşturur ve veritablosundan gerekli verileri alır. Varsa sadece gerekli verileri alır.
            create_database();
            get_data();
        }

        private void cash()
        {
            try
            {
                // Ana ekrandaki koltuk göstergesi bilgisini yeniler.
                panel1.Controls.Clear();
                panel1.Controls.Add(database_control.Get_Data_From_Database_For_Chair_Info(dateTimePicker1.Text, comboBox2.Text, comboBox3.Text));

                // Ana ekrandaki girdilere göre bilet ücretini belirler ve kullanıcıya gösterir.
                if (comboBox1.Text.Length != 0 & comboBox2.Text.Length != 0 & comboBox3.Text.Length != 0)
                {
                    if (radioButton3.Checked)
                    {
                        // Yetişkin ücreti
                        label9.Text = parent_price + " TL";
                        selected_price = parent_price;
                    }
                    else if (radioButton4.Checked)
                    {
                        // Öğrenci ücreti
                        label9.Text = student_price + " TL";
                        selected_price = student_price;
                    }
                    else if (radioButton5.Checked)
                    {
                        // Çocuk ücreti
                        label9.Text = child_price + " TL";
                        selected_price = child_price;
                    }

                }
            } catch { }

            
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            cash();  // Ana ekrandaki koltuk göstergesi bilgisini yeniler ve gerekli girdiler girildiğinde ücreti belirler ve gösterir.
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cash(); // Ana ekrandaki koltuk göstergesi bilgisini yeniler ve gerekli girdiler girildiğinde ücreti belirler ve gösterir.
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cash(); // Ana ekrandaki koltuk göstergesi bilgisini yeniler ve gerekli girdiler girildiğinde ücreti belirler ve gösterir.
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cash(); // Ana ekrandaki koltuk göstergesi bilgisini yeniler ve gerekli girdiler girildiğinde ücreti belirler ve gösterir.
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cash(); // Ana ekrandaki koltuk göstergesi bilgisini yeniler ve gerekli girdiler girildiğinde ücreti belirler ve gösterir.
        }

      

        private void anaEkranıGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            get_data(); // Ana ekrandaki öğeler güncellenir.
        }

        private void clear_ui()
        {
            // Ana ekrandaki girdiler temizlenir.
            comboBox1.Text = string.Empty;
            comboBox2.Text = string.Empty;
            comboBox3.Text = string.Empty;
            numericUpDown1.Value = 1;
            textBox1.Text = string.Empty;
            radioButton1.Checked = true;
            cash();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ana ekrandaki gerekli girdiler girildiğinde ve kaydedilmek istendiğinde sırasıyla aşağıdaki olaylar meydana gelir;
            // Eğer bilet satışı ise ilk önce istenilen koltuk dolu mu bakılır. Dolu ise kullanıcıya bildirilir.
            // Eğer bilet satışında istenilen koltuk dolu değilse kayıt tamamlanır.
            // Eğer bilet iptali ise gerekli bilgiler girilmiş ise bileti iptal eder ve dolu koltuğu boş gösterir.
            // Ardından ana ekranı günceller.
            // Hata oluşursa da kullanıcıya bildirilir.

             try
            {
                // Bilet satışı ise
                if (radioButton1.Checked)
                {
                    // Koltuk kontrolü
                    if (database_control.Check_Chair(dateTimePicker1.Text, comboBox2.Text, Convert.ToInt32(numericUpDown1.Value)) != 0)
                    {
                        // Dolu ise
                        MessageBox.Show("Koltuk Zaten Alınmış");
                    }
                    else
                    {
                        // Dolu değilse kayıt oluşturulur
                        String values = "'" + textBox1.Text + "' , '" + comboBox1.Text + "' , '" + comboBox2.Text + "' , '" + dateTimePicker1.Text + "' , '" + comboBox3.Text + "' , " + Convert.ToString(numericUpDown1.Value) + " , " + selected_price;
                        database_control.Insert_Data("cinema_sales_database", "full_name , film_name , room_name , ticket_date , time , chair_no , cash", values);

                    }

                }
                // Bilet iptali ise gerekli bilgiler doğrultusunda kaydı siler
                else if (radioButton2.Checked)
                {
                    database_control.Delete_Data_For_Ticket("cinema_sales_database", textBox1.Text, dateTimePicker1.Text, comboBox2.Text, comboBox3.Text, Convert.ToInt32(numericUpDown1.Value));
                }





                // Gerekli bilgiler alınır ve opsiyonları günceller.
                get_data();

            } catch { MessageBox.Show("Kayıt Kaydedilirken Hata Oluştu."); }


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            cash(); // Ana ekrandaki koltuk göstergesi bilgisini yeniler ve gerekli girdiler girildiğinde ücreti belirler ve gösterir.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear_ui(); // Ana ekrandaki girdiler temizlenir.
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            cash(); // Ana ekrandaki koltuk göstergesi bilgisini yeniler ve gerekli girdiler girildiğinde ücreti belirler ve gösterir.
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            cash(); // Ana ekrandaki koltuk göstergesi bilgisini yeniler ve gerekli girdiler girildiğinde ücreti belirler ve gösterir.
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            cash(); // Ana ekrandaki koltuk göstergesi bilgisini yeniler ve gerekli girdiler girildiğinde ücreti belirler ve gösterir.
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
