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
using Zadanie4;                  //ссылка библиотеку описанную в 4 задании
using static Zadanie4.Connection;//ссылка библиотеку описанную в 4 задании


namespace IS_1_20_KostromitinDD_U
{
    public partial class Zadanie5 : Form
    {
        public Zadanie5()
        {
            InitializeComponent();
        }
        public MySqlConnection conn;
        Connection MySQL;

        private void Zadanie5_Load(object sender, EventArgs e)
        {
            MySQL = new Connection();
            MySQL.connect();
            conn = new MySqlConnection(MySQL.ConnStr);
            gridload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string tb1 = textBox1.Text; //Текст бокс откуда будет браться информация ввода 
                DateTime DT = DateTime.Now;
                conn.Open();
                string insert = $"INSERT INTO t_Uchebka_Kostromitin(fioStud, datetimeStud) " + $"VALUES ('{tb1}', '{String.Format("{0:s}", DT)}');";//sql запрос на добавление
                MySqlCommand command = new MySqlCommand(insert, conn);
                command.ExecuteNonQuery();
                MessageBox.Show("Данные успешно введены!");     
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
            reload_list();
        }

        public void gridload()
        {
            try
            {
                conn.Open();
                string sql = $"SELECT * FROM t_Uchebka_Kostromitin";
                dataGridView1.Columns.Add("idStud", "ид");
                dataGridView1.Columns["idStud"].Width = 100;
                dataGridView1.Columns.Add("fioStud", "фио");
                dataGridView1.Columns["fioStud"].Width = 185;
                dataGridView1.Columns.Add("datetimeStud", "дата");
                dataGridView1.Columns["datetimeStud"].Width = 185;
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) //ридер читает данные из бд
                {
                    dataGridView1.Rows.Add(reader["idStud"].ToString(), reader["fioStud"].ToString(), reader["datetimeStud"].ToString());

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

        //обновление DataGridView
        public void updategrid()
        {
            try
            {
                conn.Open();
                string sql = $"SELECT * FROM t_Uchebka_Kostromitin";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) //ридер читает данные из бд
                {
                    dataGridView1.Rows.Add(reader["idStud"].ToString(), reader["fioStud"].ToString(), reader["datetimeStud"].ToString());

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

        //обновление DataGridView
        void reload_list()
        {
            dataGridView1.Rows.Clear();
            updategrid();
        }
    }
}
