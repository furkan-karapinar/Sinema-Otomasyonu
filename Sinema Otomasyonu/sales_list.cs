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
    public partial class sales_list : Form
    {
        Database_Control database_control = new Database_Control();
        public sales_list()
        {
            InitializeComponent();
        }

        private void sales_list_Load(object sender, EventArgs e)
        {
            // Satış Listesi formu açıldığında veritablosundan veriler alır ve veritablosunda aldığı verileri bir tabloda gösterir.
            // Ardından label1 e toplam kazanç değerini yazdırır.
            // Veri alımında hata oluşursa kullanıcıya bildirir ve label1 e varsayılan olarak '0' değerini yazdırır.
            // Hata durumunda kullanıcıya bildirilir.
            try
            {
                database_control.Get_Data_From_Database_For_Sales_List("cinema_sales_database", dataGridView1);
                label1.Text = Convert.ToString(database_control.Get_Data_From_Database_For_Cash_Info());
            } catch { label1.Text = "0"; MessageBox.Show("Satış Verileri Alınırken Hata Oluştu"); }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            // İlk veritablosunda istenilen itemler var mı kontrol edilir. Var ise item değerlerini günceller.
            // Yok ise yeni itemler oluşturur ve değerlerini girer. Hata durumunda kullanıcıya bildirilir.
            try
            {
                // Girilecek değerler
                String value_1 = Convert.ToString(numericUpDown1.Value);
                String value_2 = Convert.ToString(numericUpDown2.Value);
                String value_3 = Convert.ToString(numericUpDown3.Value);

                // Veritablosu item kontrolü
                if (database_control.Control_Item("cinema_config_database","config","parent_price") != 0)
                {
                    // Itemler zaten mevcut olduğundan değerleri güncellenir.
                    database_control.Update_ConfigData("cinema_config_database", "parent_price","value", value_1);
                    database_control.Update_ConfigData("cinema_config_database", "student_price","value", value_2);
                    database_control.Update_ConfigData("cinema_config_database", "child_price","value", value_3);
                }
                else
                {
                    // Itemler mevcut olmadığından dolayı oluşturulur ve değerleri girilir.
                    database_control.Create_Database("cinema_config_database", "config VARCHAR , value VARCHAR");
                    database_control.Insert_Data("cinema_config_database", "config , value", value_1);
                    database_control.Insert_Data("cinema_config_database", "config , value", value_2);
                    database_control.Insert_Data("cinema_config_database", "config , value", value_3);
                }
                    
            } catch { MessageBox.Show("Ayar Kaydedilemedi"); }
        }
    }
}
