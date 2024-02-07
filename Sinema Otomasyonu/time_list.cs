using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sinema_Otomasyonu
{
    public partial class time_list : Form
    {
        Database_Control Database_Control = new Database_Control();
        public time_list()
        {
            InitializeComponent();
        }

        private void time_list_Load(object sender, EventArgs e)
        {
            // Seans Listesi formu açıldığında yoksa veritabanını oluşturmayı dener ve veritablosundan veriler alır.
            // Eğer varsa sadece verileri alır.
            create_database();
            get_data();
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["time"].HeaderText = "Seans Saati";


        }

        private void get_data()
        {
            // Veritablosundan veriler alınır.
            Database_Control.Get_Data_From_Database("cinema_time_database", dataGridView1);
        }

        private void create_database()
        {
            // Veritablosu yoksa oluşturulur.
            Database_Control.Create_Database("cinema_time_database", "id INTEGER PRIMARY KEY , time VARCHAR(25)");
        }

        private void delete_data_btn_Click(object sender, EventArgs e)
        {
            // Veritablosundan istenilen veri silinir ve veriler tekrar alınır.
            Database_Control.Delete_Data("cinema_time_database", "time", label4.Text);
            get_data();
        }


        private void insert_data_btn_Click(object sender, EventArgs e)
        {
            // Veritablosuna veri işlenir ve veriler tekrar alınır.
            String time = Convert.ToString(numericUpDown1.Value) + ":" + Convert.ToString(numericUpDown2.Value);
            Database_Control.Insert_Data("cinema_time_database", "time",time, dataGridView1);
            get_data();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tablodan bir veri seçildiğinde label4 e yazar
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                label4.Text = dataGridView1.Rows[e.RowIndex].Cells["time"].FormattedValue.ToString();

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tablodan bir veri seçildiğinde label4 e yazar
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                label4.Text = dataGridView1.Rows[e.RowIndex].Cells["time"].FormattedValue.ToString();

            }
        }
    }
}
