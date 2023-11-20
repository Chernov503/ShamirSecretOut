using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int Randomaizer()
        {
            Random rand = new Random();
            Thread.Sleep(100);
            return rand.Next(3, 120);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int k = int.Parse(textBox2.Text);
                int Secret = int.Parse(textBox1.Text);
                Dictionary<BigInteger, BigInteger> keys = new Dictionary<BigInteger, BigInteger>(); //словарь ключей
                int[] KFs = new int[k]; // коэфициенты функции рандомные


                textBox3.Text = $"F(x) = {Secret}"; // Вывод функции


                for(int i = 1; i < k; i++)
                {
                    KFs[i] = Randomaizer();
                }

                for(int i = 0; i < int.Parse(textBox4.Text) ;i++) // генерация ключей
                {
                    // Вывод функции
                    if (i > 0 && i < k)
                    { 
                        textBox3.Text += $" + {KFs[i]}x^{i}"; 
                    } 

                    BigInteger x = Randomaizer(); // рандомный y
                    BigInteger y = Secret;
                    for(int j =1; j < k;j++)
                    {
                        y += (BigInteger)Math.Pow((double)x, (double)j) * KFs[j]; // => 4x^2 => 2x^3 и т.д.
                    }
                    keys.Add(x,y);
                }


                foreach(var el in keys)
                {
                    textBox3.Text += Environment.NewLine + $"{el}";
                }
            }
            catch(Exception err) { MessageBox.Show($"\nКод ошибки {err.Message}", "Ошибка"); }

        }
    }
}
