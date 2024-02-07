using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace Sinema_Otomasyonu
{
    internal class Database_Control
    {
        // Veritabanı adı ve konumu
        string path = "database.db", cs = @"URI=file:" + Application.StartupPath + "\\database.db";

        // Gerekli tanımlamalar
        SQLiteConnection data_connection;
        SQLiteCommand command;
        SQLiteDataReader reader;



        public void Create_Database(String datatable_name, String data_options)
        {
            // Veritablosu yoksa oluşturulur. Varsa oluşturmaz. Hata durumunda kullanıcıya belirtilir.
            try
            {
                // Veritabanı var mı sorgulama
                if (!System.IO.File.Exists(path))
                {
                    // if sorgusunda '!' işareti mevcut olduğundan veritabanı yoktur. Bu yüzden veritabanı dosyası oluşturulur.
                    SQLiteConnection.CreateFile(path);
                }

                // İstenilen veritablosu yoksa oluşturulur.
                using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
                {
                    sqlite.Open();
                    string sql = "CREATE TABLE IF NOT EXISTS " + datatable_name + " (" + data_options + ")";
                    SQLiteCommand cmd = new SQLiteCommand(sql, sqlite);
                    cmd.ExecuteNonQuery();
                    cmd.Cancel();
                }
            } catch { MessageBox.Show("Veritabanı Oluşturma Hatası"); }
           
        }

        public void Get_Data_From_Database(String datatable_name, DataGridView dataGrid)
        {
            string connectionString = cs;

            // SQLite bağlantısı oluşturma
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Tabloyu seçme sorgusu
                string selectQuery = $"SELECT * FROM {datatable_name}";

                // SQLite komutu oluşturma
                using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
                {
                    // Verileri almak için bir SQLiteDataAdapter oluşturma
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        // Verileri bir DataSet nesnesine doldurma
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);

                        // DataGridView'e verileri atama
                        dataGrid.DataSource = dataSet.Tables[0];
                    }
                }

                connection.Close();
            }

        }

        public String Get_Data_From_ConfigDatabase( String config_name)
        {
            // Burası sadece ayarlar içindir.
            // Veritablosundan ayar verileri alınır ve istenilen yere geri döndürür.
            // Hata durumunda kullanıcıya belirtilir ve varsayılan olarak '0' değerini döndürür.
            try
            {
                String value = string.Empty;
                var data_connection = new SQLiteConnection(cs);
                data_connection.Open();
                String stm = "SELECT * FROM cinema_config_database WHERE config='" + config_name + "'";
                var command = new SQLiteCommand(stm, data_connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    value = reader.GetString(1);

                }
                if (value.Length != 1)
                {
                    return value;
                }
                else
                    return "0";
            } catch { MessageBox.Show("Veri Alımı Hatası"); return "0"; }
            
        }

        public void Get_Data_From_Database_For_Sales_List(String datatable_name, DataGridView dataGrid)
        {
            // Burası sadece satış listesi formu içindir.
            // Verilerin girileceği yer (datagrid) temizlenir ve veritablosundan veriler alınıp verilerin girileceği tabloya (datagrid) işlenir.
            // Hata durumunda kullanıcıya belirtilir.
            try
            {
                dataGrid.Rows.Clear();
                var data_connection = new SQLiteConnection(cs);
                data_connection.Open();
                String stm = "SELECT * FROM " + datatable_name;
                var command = new SQLiteCommand(stm, data_connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dataGrid.Rows.Insert(0, reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetValue(5), reader.GetValue(6));
                }
            } catch { MessageBox.Show("Veri Alımı Hatası"); }

            
        }

        public int Get_Data_From_Database_For_Cash_Info()
        {
            // Burası tüm satılan biletlerin toplam para miktarını vermek içindir.
            // Veritablosundan veriler alınıp toplanır ve istenilen yere toplam değeri döndürür.
            // Hata durumunda kullanıcıya belirtilir ve varsayılan olarak '0' değerini döndürür.
            try
            {
                int total_cash = 0;
                var data_connection = new SQLiteConnection(cs);
                data_connection.Open();
                String stm = "SELECT * FROM cinema_sales_database";
                var command = new SQLiteCommand(stm, data_connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    total_cash = total_cash + Convert.ToInt32(reader.GetValue(6));


                }
                return total_cash;
            } catch { MessageBox.Show("Veri Alımı Hatası"); return 0; }
            
        }

        public chair_view Get_Data_From_Database_For_Chair_Info(String date,String room_name, String time)
        {
            // Burası Ana ekrandaki koltuk göstergesi içindir.
            // Veritablosundan dolu koltuk bilgileri alınır ve oluşturulan yeni koltuk göstergesine işlenir.
            // Ardından istenilen yere koltuk göstergesi objesi olarak geri döndürür.
            // Hata durumunda tüm koltukların boş olduğunu gösteren varsayılan koltuk göstergesi döndürülür.
            // Ve kullanıcıya hata oluştuğu konusunda bilgi verilir.

           chair_view chair_View = new chair_view();
            chair_View.Dock = DockStyle.Fill;
            try
            {
                var data_connection = new SQLiteConnection(cs);
                data_connection.Open();
                String stm = "SELECT * FROM cinema_sales_database WHERE ticket_date = '" + date + "' AND room_name = '" + room_name + "' AND time = '" + time + "'";
                var command = new SQLiteCommand(stm, data_connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int v = Convert.ToInt32(reader.GetValue(5));
                    chair_View.check_empty_chair(v);
                }

                return chair_View;
            } catch { MessageBox.Show("Veri Alımı Hatası"); return chair_View; }
            
        }

        public int Check_Chair(String date, String room_name, int chair_no)
        {
            // Burası istenilen koltuğun dolu ya da boş olduğunu kontrol eder.
            // Veritablosundan veriler alınır ve karşılaştırılır.
            // İstenilen koltuğun dolu olup olmadığı kullanıcıya belirtilir.
            // Hata durumunda kullanıcıya hata oluştuğu bildirilir ve varsayılan olarak koltuğun boş olduğu belirtilir.
                int v = 0;
            try
            { 
            var data_connection = new SQLiteConnection(cs);
            data_connection.Open();
            String stm = "SELECT * FROM cinema_sales_database WHERE ticket_date = '" + date + "' AND room_name = '" + room_name + "'";
            var command = new SQLiteCommand(stm, data_connection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                 v = Convert.ToInt32(reader.GetValue(5));
                
            }
                if (chair_no == v)
                {
                    return 1;
                }
                else
                    return 0;
            
            } catch { MessageBox.Show("Veri Alımı Hatası"); return 0; }

            

            

        }
       


        public void Get_Data_From_Database_For_Combobox(String datatable_name, ComboBox comboBox)
        {
            // Burası ana ekrandaki comboboxlar içindir.
            // Veritablolarından gerekli bilgiler alınır ve ilgili comboboxlara seçenek olarak işlenir.
            // Hata durumunda kullanıcıya belirtilir.
            try
            {
                comboBox.Items.Clear();
                var data_connection = new SQLiteConnection(cs);
                data_connection.Open();
                String stm = "SELECT * FROM " + datatable_name;
                var command = new SQLiteCommand(stm, data_connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBox.Items.Add(reader.GetString(1));

                }
            } catch { MessageBox.Show("Veri Alımı Hatası"); }

            
        }

        public void Delete_Data_For_Ticket(String datatable_name, String full_name, String ticket_date, String room_name, String time , int chair_no)
        {
            // Burası alınan bileti veritablosundan silmek içindir. (Bilet iade işlemi)
            // Hata durumunda kullanıcıya belirtilir.
            try
            {
                var con = new SQLiteConnection(cs);
                con.Open();
                var cmd = new SQLiteCommand(con);
                cmd.CommandText = "DELETE FROM "+ datatable_name + " WHERE full_name = '" + full_name + "' AND ticket_date = '" + ticket_date + "' AND room_name = '" + room_name + "' AND time = '" + time + "' AND chair_no = " + chair_no + "";
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                cmd.Cancel();
            }
            catch { MessageBox.Show("Veri Silme Hatası"); }
        }

        public void Delete_Data(String datatable_name, String database_item_name, String item_name)
        {
            // Burası (Genel) veritablosundan veri silme yeridir. Hata durumunda kullanıcıya belirtilir.
            try
            {
                var con = new SQLiteConnection(cs);
                con.Open();
                var cmd = new SQLiteCommand(con);
                cmd.CommandText = "DELETE FROM " + datatable_name + " WHERE " + database_item_name + "=@name";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@name", item_name);
                cmd.ExecuteNonQuery();
                cmd.Cancel();
            }
            catch  { MessageBox.Show("Veri Silme Hatası"); }
        }

        public void Insert_Data(String datatable_name,String database_item_name,String item_name,DataGridView dataGrid)
        {
            // Burası veritablosuna tek bir veri işlemek içindir.
            // İlk önce veritablosunda oluşturulacak item var mı kontrol edilir. Varsa bildirilir. Yoksa oluşturulup işlenir.
            // Hata durumunda ayrıca belirtilir.
            try
            {
                if (Control_Item(datatable_name, database_item_name, item_name) != 0)
                {
                    MessageBox.Show("Veri Zaten Mevcut");
                }
                else
                {
                    var con = new SQLiteConnection(cs);
                    con.Open();
                    var cmd = new SQLiteCommand(con);
                    cmd.CommandText = "INSERT INTO " + datatable_name + "(" + database_item_name + ") VALUES(@name)";
                    cmd.Parameters.AddWithValue("@name", item_name);
                    
                    cmd.ExecuteNonQuery();
                    cmd.Cancel();
                }
            } catch { MessageBox.Show("Veri Giriş Hatası"); }

            
        }


        public void Insert_Data(String datatable_name, String item_names , String item_values)
        {
            // Burası veritablosuna birden fazla veri işlemek içindir.
            // Hata durumunda ayrıca belirtilir.
            try
            {
                var con = new SQLiteConnection(cs);
                con.Open();
                var cmd = new SQLiteCommand(con);
                cmd.CommandText = "INSERT INTO " + datatable_name + "(" + item_names + ") VALUES(" + item_values + ")";
                cmd.ExecuteNonQuery();
                cmd.Cancel();
            } catch { MessageBox.Show("Veri Giriş Hatası"); }
               
            
        }

        public void Update_ConfigData(String datatable_name,String config_name, String item_name , String item_value)
        {
            // Burası ayarların verilerini güncellemek içindir. Hata durumunda belirtilir.
            try
            {
                var con = new SQLiteConnection(cs);
                con.Open();
                var cmd = new SQLiteCommand(con);
                cmd.CommandText = "UPDATE " + datatable_name + " SET " + item_name + "=@value WHERE config=@name";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@name", config_name);
                cmd.Parameters.AddWithValue("@value", item_value);
                cmd.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Veri Değiştirme Hatası"); }


        }
        public int Control_Item(String datatable_name,String database_item_name, String item_name)
        {
            // Kontrol edilmesi istenen veriler veritablosunda mevcut mu değil mi kontrol edilir.
            // Varsa var olduğu bilgisi geri döndürülür. Yoksa olmadığı geri döndürülür.
            // Hata durumunda ayrıca belirtilir ve varsayılan olarak olmadığı bilgisi geri döndürülür.
            try
            {
            var con = new SQLiteConnection(cs);
            con.Open();
            var cmd = new SQLiteCommand(con);
            cmd.CommandText = "SELECT COUNT(*) FROM " + datatable_name + " WHERE " + database_item_name + " ='" + item_name +"'";

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count > 0)
            {
                Console.WriteLine("Belirtilen öğe var.");
            }
            else
            {
                Console.WriteLine("Belirtilen öğe yok.");
            }
            cmd.Cancel();
            return count;
            }
            catch { MessageBox.Show("Veri Alımı Hatası"); return 0; }

            

        }

    }
}
