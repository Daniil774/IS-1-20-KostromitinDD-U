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
        hard_drives<int> hdd;
        Videocard<string> vid;
        abstract class Accessories<A>
        {
            public int Price;
            public string Years_of_release;
            public A Articyl;
            public Accessories(int pr, string yor, A art)
            {
                Price = pr;
                Years_of_release = yor;
                Articyl = art;
            }
            public void Display()
            {
            }
        }

        class hard_drives<A> : Accessories<A>
        {
            int Turnovers { get; set; }
            string Interface { get; set; }
            int Volume { get; set; }
            public hard_drives(int pr, string yor, A art, int Tu, string In, int Vo) : base(pr, yor, art)
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
        class Videocard<A> : Accessories<A>
        {
            int GPU_frequency { get; set; }
            int Manufacturer { get; set; }
            int Memory { get; set; }
            public Videocard(int pr, string yor, A art, int gpu, int man, int mem) : base(pr, yor, art)
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
                hdd = new hard_drives<int>(Convert.ToInt32(textBox1.Text), textBox2.Text, Convert.ToInt32(textBox3.Text), 
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
                vid = new Videocard<string>(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox6.Text, 
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
