using MySql.Data.MySqlClient;
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
using static Zadanie3.Program;

namespace IS_1_20_KostromitinDD_U
{
    public partial class Zadanie3 : Form
    {
        MySqlConnection conn;
        Connection MySQL;

        public Zadanie3()
        {
            InitializeComponent();
        }

        private void Zadanie3_Load(object sender, EventArgs e)
        {
            MySQL = new Connection();//подключение
            MySQL.connect();
            conn = new MySqlConnection(MySQL.ConnStr);
        }

            private void button1_Click(object sender, EventArgs e)
            {
            try
            {
                conn.Open();
                string connStr = "SELECT id_cl, cl_name_U, fam_U, id_car_U, car_name_U, car_color_U FROM Car_U INNER JOIN Client_U ON id_car_U = id_cl ORDER BY id_car_U;";// это команда с INNER JOIN 
                dataGridView1.Columns.Add("id_cl", "ID Клиента");
                dataGridView1.Columns["id_cl"].Width = 100;
                dataGridView1.Columns.Add("cl_name_U", "Имя");
                dataGridView1.Columns["cl_name_U"].Width = 100;
                dataGridView1.Columns.Add("fam_U", "фамилия");
                dataGridView1.Columns["fam_U"].Width = 100;
                dataGridView1.Columns.Add("id_car_U", "ид авто");
                dataGridView1.Columns["id_car_U"].Width = 100;
                dataGridView1.Columns.Add("car_name_U", "имя авто");
                dataGridView1.Columns["car_name_U"].Width = 100;
                dataGridView1.Columns.Add("car_color_U", "цвет авто");
                dataGridView1.Columns["car_color_U"].Width = 100;
                MySqlCommand command = new MySqlCommand(connStr, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) //чтение данных из бд
                {
                    dataGridView1.Rows.Add(reader["id_cl"].ToString(), reader["cl_name_U"].ToString(), reader["fam_U"].ToString(), 
                        reader["id_car_U"].ToString(), reader["car_name_U"].ToString(), reader["car_color_U"].ToString()); 
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

        //вывод при нажатии на поле в grid'e
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null) 
                {
                    MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Вы не выбрали запись в DataGrid");
            }
        }
    }
}
