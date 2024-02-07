using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sinema_Otomasyonu
{
    public partial class Room_List : Form
    {
        Database_Control Database_Control = new Database_Control();


        public Room_List()
        {
            InitializeComponent();
        }

        private void get_data()
        {
            // Veritablosundan veriler alınır.
            Database_Control.Get_Data_From_Database("cinema_room_database", dataGridView1);
        }

        private void create_database()
        {
            // Veritablosu yoksa oluşturulur.
            Database_Control.Create_Database("cinema_room_database", "id INTEGER PRIMARY KEY , room_name VARCHAR(25)");
        }

        private void delete_data_btn_Click(object sender, EventArgs e)
        {
            // Veritablosundan istenilen veri silinir ve veriler tekrar alınır.
            Database_Control.Delete_Data("cinema_room_database", "room_name", textBox1.Text);
            get_data();
        }
           

        private void insert_data_btn_Click(object sender, EventArgs e)
        {
            // Veritablosuna veri işlenir ve veriler tekrar alınır.
            Database_Control.Insert_Data("cinema_room_database","room_name",textBox1.Text,dataGridView1);
            get_data();
        }

        private void Room_List_Load(object sender, EventArgs e)
        {
            // Salon Listesi formu açıldığında yoksa veritabanını oluşturmayı dener ve veritablosundan veriler alır.
            // Eğer varsa sadece verileri alır.
            create_database();
            get_data();
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["room_name"].HeaderText = "Salon Adı";
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Veritablosundan bir veri seçildiğinde textbox1 e yazar
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["room_name"].FormattedValue.ToString();
                
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Veritablosundan bir veri seçildiğinde textbox1 e yazar
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["room_name"].FormattedValue.ToString();

            }
        }

       
    }
}
