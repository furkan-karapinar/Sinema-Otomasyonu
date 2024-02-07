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
    public partial class film_list : Form
    {
        Database_Control Database_Control = new Database_Control();
        public film_list()
        {
            InitializeComponent();
        }

        private void get_data()
        {
            // Veritablosundan veriler alınır.
            Database_Control.Get_Data_From_Database("cinema_film_database", dataGridView1);
        }

        private void create_database()
        {
            // Veritablosu yoksa oluşturulur.
            Database_Control.Create_Database("cinema_film_database", "id INTEGER PRIMARY KEY , film_name VARCHAR(25)");
        }

        private void delete_data_btn_Click(object sender, EventArgs e)
        {
            // Veritablosundan istenilen veri silinir ve veriler tekrar alınır.
            Database_Control.Delete_Data("cinema_film_database", "film_name", textBox1.Text);
            get_data();
        }


        private void insert_data_btn_Click(object sender, EventArgs e)
        {
            // Veritablosuna veri işlenir ve veriler tekrar alınır.
            Database_Control.Insert_Data("cinema_film_database", "film_name", textBox1.Text, dataGridView1);
            get_data();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Veritablosundan bir veri seçildiğinde textbox1 e yazar
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["film_name"].FormattedValue.ToString();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Veritablosundan bir veri seçildiğinde textbox1 e yazar
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["film_name"].FormattedValue.ToString();

            }
        }

        private void film_list_Load(object sender, EventArgs e)
        {
            // Film Listesi formu açıldığında yoksa veritabanını oluşturmayı dener ve veritablosundan veriler alır.
            // Eğer varsa sadece verileri alır.
            create_database();
            get_data();
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["film_name"].HeaderText = "Film Adı";
        }
    }
}
