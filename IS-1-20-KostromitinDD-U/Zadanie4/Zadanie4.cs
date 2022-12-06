using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Zadanie4;
using static Zadanie4.Connection;//ссылка на подключение в библиотеке


namespace IS_1_20_KostromitinDD_U
{
    public partial class Zadanie4 : Form
    {
        public Zadanie4()
        {
            InitializeComponent();
        }
        public MySqlConnection conn;
        Connection MySQL;

        private void zadanie4_Load(object sender, EventArgs e)
        {
            //подключение
            MySQL = new Connection();
            MySQL.connect();
            conn = new MySqlConnection(MySQL.ConnStr);
            //загрузка грида при запуске формы
            select();
        }

        //заполнение грида
        private void select()
        {
            try
            {
                MySQL = new Connection();
                MySQL.connect(); 
                conn = new MySqlConnection(MySQL.ConnStr);
                conn.Open();
                string sql = $"SELECT * FROM t_datatime";
                dataGridView1.Columns.Add("fio", "ФИО");
                dataGridView1.Columns["fio"].Width = 100; 
                dataGridView1.Columns.Add("date_of_Birth", "День рождения");
                dataGridView1.Columns["date_of_Birth"].Width = 185;
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) //ридер читает данные из бд
                {
                    dataGridView1.Rows.Add(reader["fio"].ToString(), reader["date_of_Birth"].ToString());

                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            select();
        }

        //вывод изображения в picturebox1 при нажатии на поле в grid'e
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            conn.Open();
            int id = dataGridView1.SelectedCells[0].RowIndex + 1; 
            string url = $"SELECT photoUrl FROM t_datatime WHERE id = {id}";
            MySqlCommand com = new MySqlCommand(url, conn);
            string name = com.ExecuteScalar().ToString();
            conn.Close();
            pictureBox1.ImageLocation = $"{name}";
        }
    }
}
