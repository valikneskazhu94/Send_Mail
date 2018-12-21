using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //отправитель
            MailAddress from = new MailAddress("valikneskazhu@gmail.com", "valik94");
            //кому
            MailAddress to = new MailAddress(textBox4.Text);
            //letter
            MailMessage m = new MailMessage(from,to);
            m.Attachments.Add(new Attachment(textBox2.Text));
            //тема сообщения
            m.Subject = "NORM!";
            m.IsBodyHtml = true;
            m.Body = textBox3.Text;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            //логин и пароль
            smtp.Credentials = new NetworkCredential("valikneskazhu@gmail.com", textBox1.Text);
            smtp.EnableSsl = true;
            smtp.Send(m);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = dialog.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
