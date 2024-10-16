using System.Windows.Forms;
using System.Net.Mail;
using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool panel1mode = false;
        bool panel2mode = false;
        bool panel3mode = false;
        bool panel4mode = false;
        bool panel5mode = false;
        string api = "7837564819:AAHc4ze4TAgy5TYfUGj63pHHVM5EH94QNcI";
        string id = "1170255486";



        void BubbleScreen(Button button, Panel panel, bool mode)
        {

            if (mode == false)
            {
                for (int i = 0; i < 10; i++)
                {
                    panel.Location = new Point(panel.Location.X - 150, button.Location.Y);
                    Thread.Sleep(25);
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    panel.Location = new Point(panel.Location.X + 150, button.Location.Y);
                    Thread.Sleep(25);
                }
            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (panel1mode == false)
            {
                panel1mode = true;
            }
            else
            {
                panel1mode = false;
            }
            BubbleScreen(button1, panel1, panel1mode);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (panel2mode == false)
            {
                panel2mode = true;
            }
            else
            {
                panel2mode = false;
            }
            BubbleScreen(button2, panel2, panel2mode);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (panel3mode == false)
            {
                panel3mode = true;
            }
            else
            {
                panel3mode = false;
            }
            BubbleScreen(button3, panel3, panel3mode);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (panel4mode == false)
            {
                panel4mode = true;
            }
            else
            {
                panel4mode = false;
            }
            BubbleScreen(button4, panel4, panel4mode);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (panel5mode == false)
            {
                panel5mode = true;
            }
            else
            {
                panel5mode = false;
            }
            BubbleScreen(button5, panel5, panel5mode);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            /*Random rnd = new Random();
            int random = rnd.Next(1, 4);
            if (random == 1)
            {
                button6.BackColor = Color.Aqua;
            }
            else if (random == 2)
            {
                button6.BackColor = Color.Red;
            }
            else if (random == 3)
            {
                button6.BackColor = Color.Green;
            }
            else
            {
                button6.BackColor = Color.DarkBlue;
            }*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point(-1200, 0);
            panel2.Location = new Point(-1200, 0);
            panel3.Location = new Point(-1200, 0);
            panel4.Location = new Point(-1200, 0);
            panel5.Location = new Point(-1200, 0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            /* string recevier = textBox2.Text;
             MailAddress from = new MailAddress("matuhazapominalkin@gmail.com", "Менеджер");
             MailAddress to = new MailAddress(recevier);
             MailMessage m = new MailMessage(from, to);
             m.Subject = "Пришла новая задача";
             m.Body = textBox1.Text;
             m.IsBodyHtml = true;
             SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
             smtp.UseDefaultCredentials = false;

             smtp.Credentials = new NetworkCredential("matuhazapominalkin@gmail.com", "matvey3355");

             smtp.EnableSsl = true;
             smtp.Send(m);*/

        }

        void ComboRefresh()
        {
            comboBox1.Items.Clear();
            foreach (string obj in listBox1.Items)
            {
                comboBox1.Items.Add(obj);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if ((textBox6.Text.Length != 0) && (textBox5.Text.Length != 0))
            {
                listBox1.Items.Add(textBox6.Text + " " + textBox5.Text);
                ComboRefresh();
                MessageBox.Show("Контакт успешно добавлен");
            }
            else
            {
                MessageBox.Show("Данные введены неверно");
            }

        }

        private async void button7_Click_1(object sender, EventArgs e)
        {
            if ((textBox1.Text.Length != 0) && (textBox7.Text.Length != 0) && (comboBox1.Text.Length != 0))
            {
                var bot = new TelegramBotClient(api);
                await bot.SendTextMessageAsync(id, "Название : " + textBox1.Text + "\nОтветственность : " + comboBox1.Text + "\nТекст задачи : " + textBox7.Text);
                MessageBox.Show("Задача успешно создана");
            }
            else
            {
                MessageBox.Show("Данные введены неверно");
            }
            
        }
    }
}
