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
using System.Threading;
using System.Timers;
using System.Globalization;

namespace Spravka
{
    public partial class Form2 : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        public Form2()
        {
            InitializeComponent();
            Form3 f = new Form3();
            f.Owner = this;
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
           
        }
      
        private void label5_Click(object sender, EventArgs e)
        {
          
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (label8.Text == "Нажмите сюда")
            {
                Form3 frm3 = new Form3();
                //frm3.Show(this);
                this.Hide();
            }
        }
        static public string date_now;
        static public int control_num = 0;
        static public DateTime dt;
        static public string s1;
        static public string s2;
        static public string dek;
        static public string facult;
        public async void button1_Click(object sender, EventArgs e)
        {
            
            Form1 main = this.Owner as Form1;
          
            s1 = main.textBox1.Text;
            s2 = main.textBox2.Text;

           
            label5.Text= DateTime.Now.ToShortDateString();
            int x = DateTime.Now.Month;
            string month = "";
            switch (x)
            {
                case 1:
                    month = "Январь";
                    break;
                case 2:
                    month = "Февраль";
                    break;
                case 3:
                    month = "Март";
                    break;
                case 4:
                    month = "Апрель";
                    break;
                case 5:
                    month = "Май";
                    break;
                case 6:
                    month = "Июнь";
                    break;
                case 7:
                    month = "Июль";
                    break;
                case 8:
                    month = "Август";
                    break;
                case 9:
                    month = "Сентябрь";
                    break;
                case 10:
                    month = "Октябрь";
                    break;
                case 11:
                    month = "Ноябрь";
                    break;
                case 12:
                    month = "Декабрь";
                    break;
            }
            month = month.ToLower();
            month = month.Substring(0, month.Length - 1)+"я";
            date_now = DateTime.Now.Day.ToString() +" "+ month + " " + DateTime.Now.Year.ToString();
            //изменить тут================================================
            con = new OleDbConnection(@"Provider=Microsoft.ACE.Oledb.12.0;Data Source=D:\ИС И ТЕХ\Spravka\university.accdb");
            OleDbCommand cmd = new OleDbCommand();
            OleDbCommand cmd1 = new OleDbCommand();
            cmd.Connection = con;
            cmd1.Connection = con;
            con.Open();
            OleDbDataReader reader = null;
            cmd.CommandText = "SELECT d.Фамилия, d.Имя, d.Отчество, f.Факультет FROM [Деканат] as d inner join Факультет as f on d.[Код деканата]=f.[Код деканата]," +
                " Студенты as s, [Персональные данные] as p where Логин='" + s1 + "' AND Пароль='" + s2 + "' and s.[Код студента] = f.[Код студента]" +
                "and s.[Номер зачётной книжки] = p.[Номер зачётной книжки]";

            reader = cmd.ExecuteReader();
            int num = 0;
            string[] mass = new string[1000];
            
                while (reader.Read())
            {
                //mass[num] = reader[num].ToString();
                if (num == 0)
                {
                    dek = reader["Имя"].ToString().Substring(0, 1) + "." + reader["Отчество"].ToString().Substring(0, 1) + ". "+reader["Фамилия"].ToString();
                    facult = reader["Факультет"].ToString();
                }
                num += 1;
            }
            
            label8.Text = "Справка не готова";
            reader.Close();
            ///*
            OleDbDataReader reader1 = null;
            cmd.CommandText = "SELECT [Код студента] FROM [Студенты] as s inner join [Персональные данные] as p on s.[Номер зачётной книжки]=p.[Номер зачётной книжки]" +
              "where Логин='" + s1 + "' AND Пароль='" + s2 + "'";
            string cod_stud = "";
            reader1 = cmd.ExecuteReader();
            while (reader1.Read())
            {
                cod_stud = reader1["Код студента"].ToString();
            }
            reader1.Close();
            int cod = Int32.Parse(cod_stud);
          
                
                string sql_in = "insert into Запросы ([Дата запроса], [Код студента]) values ('" + DateTime.Now.ToString() + "', '" + cod_stud + "')";
                cmd.CommandText = sql_in;
                cmd.ExecuteNonQuery();
                
            con.Close();
            label6.Text = dek;
            label7.Text = "Принята";
            control_num = 1;
            label8.Text = "Ваша справка не готова";
            await time1();
        }


        public async Task time1()
        {
            //задержка
            await Task.Delay(2000);
            label8.Text = "Нажмите сюда";
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label8_MouseHover(object sender, EventArgs e)
        {
           if(label8.Text=="Нажмите сюда")
                label8.ForeColor = Color.Blue;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Black;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
