using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spravka
{
    public partial class Form1 : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbCommand cmd1;
        public Form1()
        {
            InitializeComponent();
            Form2 f = new Form2();
            f.Owner = this;
        }
       
        private void label1_Click(object sender, EventArgs e)
        {

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
           //изменить тут================================================
            con = new OleDbConnection(@"Provider=Microsoft.ACE.Oledb.12.0;Data Source=D:\ИС И ТЕХ\Spravka\university.accdb");
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            con.Open();
            OleDbDataReader reader = null;
            cmd.CommandText = "SELECT Логин, Пароль FROM [Персональные данные] where Логин='" + textBox1.Text + "' AND Пароль='" + textBox2.Text + "'";
            reader = cmd.ExecuteReader();
            int num = 0;
            
            while (reader.Read())
            {
                num += 1;
            }

            if (num>0)
            {
                reader.Close();
                con.Close();
                MessageBox.Show("Вы успешно вошли");
                Form2 frm2 = new Form2();
                frm2.Show(this);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
        }

        bool chek_val = true;
        private void label4_Click(object sender, EventArgs e)
        {
            if (chek_val)
            {
                textBox2.UseSystemPasswordChar = false;
                chek_val = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                chek_val = true;
            }
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Red;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
