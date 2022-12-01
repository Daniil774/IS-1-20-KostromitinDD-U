using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IS_1_20_KostromitinDD_U
{
    public partial class Task1 : Form
    {
        public Task1()
        {
            InitializeComponent();
        }
        hard_drives hdd;
        Videocard vid;
        abstract class Accessories
        {
            public int Price;
            public string Years_of_release;
            public string Articyl;
            public Accessories(int pr, string yor, string art)
            {
                Price = pr;
                Years_of_release = yor;
                Articyl = art;
            }
            public void Display()
            {
            }
        }

        class hard_drives : Accessories
        {
            int Turnovers { set; get; }
            string Interface { set; get; }
            int Volume { set; get; }
            public hard_drives(int pr, string yor, string art, int Tu, string In, int Vo) : base(pr, yor, art)
            {
                Turnovers = Tu;
                Interface = In;
                Volume = Vo;
            }

            public new string Display()
            {
                return ($"Цена:{Price}$, Год выпуска:{Years_of_release}, Артикул:{Articyl}, " +
                        $"Количество оборотов:{Turnovers}, Интерфейс:{Interface}, Объем:{Volume}gb");
            }
        }
        class Videocard : Accessories
        {
            int GPU_frequency { set; get; }
            int Manufacturer { set; get; }
            int Memory { set; get; }
            public Videocard(int pr, string yor, string art, int gpu, int man, int mem) : base(pr, yor, art)
            {
                GPU_frequency = gpu;
                Manufacturer = man;
                Memory = mem;
            }
            public new string Display()
            {
                return ($"Цена:{Price}$, Год выпуска:{Years_of_release}, Артикул:{Articyl}, " +
                        $"Частота CPU:{GPU_frequency}, Производительность:{Manufacturer}, Объем памяти:{Memory}gb");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                hdd = new hard_drives(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, 
                    Convert.ToInt32(textBox4.Text), textBox5.Text, Convert.ToInt32(textBox10.Text));
                listBox1.Items.Add(hdd.Display());
            }
            catch
            {
                MessageBox.Show("Ведите данные");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                vid = new Videocard(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox6.Text, 
                    Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox9.Text));
                listBox1.Items.Add(vid.Display());
            }
            catch
            {
                MessageBox.Show("Ведите данные");
            }
        }
    }
}
