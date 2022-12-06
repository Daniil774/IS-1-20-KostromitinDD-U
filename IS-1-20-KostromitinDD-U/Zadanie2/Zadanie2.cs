using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace IS_1_20_KostromitinDD_U
{
    public partial class Zadanie2 : Form
    {
        public Zadanie2()
        {
            InitializeComponent();
        }
        public MySqlConnection conn;
        Connection MySql;

        //подключение
        class Connection
        {
            //public string host = "10.90.12.110"; 
            string Host = "chuc.caseum.ru";
            string Port = "33333";
            string User = "uchebka";
            string DataBase = "uchebka";
            string Password = "uchebka";
            public string ConnStr;
            public string connect()// строка подключения
            {
                return ConnStr = $"server={Host};Port={Port};User={User};DataBase={DataBase};Password={Password};";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySql = new Connection();
                MySql.connect();
                conn = new MySqlConnection(MySql.ConnStr);
                conn.Open();
                conn.Close();
                MessageBox.Show("Всё тип топ!");
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }
    }
}
