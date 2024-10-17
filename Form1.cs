using System.Windows.Forms;
using System.Net.Mail;
using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Telegram.Bot;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class Task()
        {
            public string date;
            public string main;
            public string text;

        }

        class Contact()
        {
            public string name;
            public string number;
        }


        bool panel1mode = false;
        bool panel2mode = false;
        bool panel3mode = false;
        bool panel4mode = false;
        bool panel5mode = false;
        string api = "";
        string id = "1170255486";

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point(-1200, 0);
            panel2.Location = new Point(-1200, 0);
            panel3.Location = new Point(-1200, 0);
            panel4.Location = new Point(-1200, 0);
            panel5.Location = new Point(-1200, 0);
            monthCalendar1.Visible = false;
            DataLoad();
        }

        List<Contact> contacts = new List<Contact>();
        List<Task> tasks = new List<Task>();
        List<Task> todayTasks = new List<Task>();

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

        void ComboRefresh()
        {
            comboBox1.Items.Clear();
            foreach (Task task in tasks)
            {
                comboBox1.Items.Add(task.main);
            }
        }

        void DataLoad()
        {
            if (File.Exists("Tasks.txt") && File.Exists("Contacts.txt"))
            {
                todayTasks.Clear();
                tasks.Clear();
                contacts.Clear();

                StreamReader sr = File.OpenText("Tasks.txt");

                while (!sr.EndOfStream )
                {

                    Task task = new Task();
                    string[] temp = sr.ReadLine().Split('|');
                    task.date = temp[0];
                    task.main = temp[1];
                    task.text = temp[2];

                    string[] isToday = temp[0].Split(' ');
                    string today = DateTime.Today.ToString();
                    string[] todayDate = today.Split(' ');

                    if (isToday[0] == todayDate[0])
                    {
                        todayTasks.Add(task);
                    }

                    tasks.Add(task);
                }

                sr.Close();

                StreamReader st = File.OpenText("Contacts.txt");

                while (!st.EndOfStream)
                {

                    Contact contact = new Contact();
                    string[] temp = st.ReadLine().Split('|');
                    contact.name = temp[0];
                    contact.number = temp[1];

                    contacts.Add(contact);

                }

                st.Close();

                int i = 1;
                int j = 1;

                listBox1.Items.Clear();
                listBox2.Items.Clear();

                foreach (Task task in tasks)
                {
                    listBox2.Items.Add($"Задача {i} | Дата : {task.date}, Ответст.: {task.main}, Текст : {task.text}");
                    i++;
                }
                foreach (Contact contact in contacts)
                {
                    listBox1.Items.Add($"Контакт {j} | Имя : {contact.name}, Номер : {contact.number}");
                    j++;
                }

                ComboRefresh();
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

        private void button9_Click(object sender, EventArgs e)
        {
            if ((textBox6.Text.Length != 0) && (textBox5.Text.Length != 0))
            {

                if (File.Exists("Contacts.txt"))
                {
                    StreamWriter sr = File.AppendText("Contacts.txt");


                    sr.WriteLine($"{textBox6.Text}|{textBox5.Text}");

                    sr.Close();
                }

                Contact contact = new Contact();
                contact.name = textBox6.Text;
                contact.number = textBox5.Text;
                contacts.Add(contact);
                DataLoad();

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

                if (File.Exists("Tasks.txt"))
                {
                    StreamWriter sr = File.AppendText("Tasks.txt");


                    sr.WriteLine($"{textBox1.Text}|{comboBox1.Text}|{textBox7.Text}");

                    sr.Close();
                }

                var bot = new TelegramBotClient(api);
                await bot.SendTextMessageAsync(id, "Дата выполнения : " + textBox1.Text + "\nОтветственность : " + comboBox1.Text + "\nТекст задачи : " + textBox7.Text);

                Task task = new Task();
                task.date = textBox1.Text;
                task.main = comboBox1.Text;
                task.text = textBox7.Text;
                tasks.Add(task);
                DataLoad();
                MessageBox.Show("Задача успешно создана");
            }
            else
            {
                MessageBox.Show("Данные введены неверно");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void monthCalendar1_MouseLeave(object sender, EventArgs e)
        {
            monthCalendar1.Visible = false;
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = monthCalendar1.SelectionStart.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (todayTasks.Count > 0)
            {
                int i = 1;
                foreach (Task task in todayTasks)
                {
                    MessageBox.Show($"Задача {i} | Дата : {task.date}, Ответст.: {task.main}, Текст : {task.text}");
                        i++;
                }
            }
            else
            {
                MessageBox.Show("На сегодня задач нет!");
            }

           
        }
    }
}
