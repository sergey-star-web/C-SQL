using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Задача1
{   
    public partial class Form3 : Form
    {
        SqlConnection sqlConnection;
      
        public Form3()
        {
            InitializeComponent();
        }

       
        public async void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet.Table". При необходимости она может быть перемещена или удалена.
            this.tableTableAdapter.Fill(this.databaseDataSet.Table);
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath.ToString() + @"\Database.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Table]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Id"]) + "    " + Convert.ToString(sqlReader["семестр"]) + "     " + Convert.ToString(sqlReader["предмет"]) + "     " + Convert.ToString(sqlReader["оценка"]) + "      " + Convert.ToString(sqlReader["долг"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null) ;
                sqlReader.Close();
            }
            
        }



        public void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }

        public void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }


        public async void button1_Click(object sender, EventArgs e)
        {
            if (label5.Visible)
                label5.Visible = false;
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                    !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                    !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                    !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))

            {
                SqlCommand command = new SqlCommand("INSERT INTO [Table] (семестр, предмет, оценка, долг) VALUES (@семестр, @предмет, @оценка, @долг)", sqlConnection);
                command.Parameters.AddWithValue("семестр", textBox1.Text);
                command.Parameters.AddWithValue("предмет", textBox2.Text);
                command.Parameters.AddWithValue("оценка", textBox3.Text);
                command.Parameters.AddWithValue("долг", textBox4.Text);
                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label5.Visible = true;
                label5.Text = "поля должны быть заполнены ";
            }

        }

        public async void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Table]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Id"]) + "    " + Convert.ToString(sqlReader["семестр"]) + "     " + Convert.ToString(sqlReader["предмет"]) + "     " + Convert.ToString(sqlReader["оценка"]) + "      " + Convert.ToString(sqlReader["долг"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null) ;
                sqlReader.Close();

            }
        }


        public async void button3_Click(object sender, EventArgs e)
        {
            if (label16.Visible)
                label16.Visible = false;
            if (!string.IsNullOrEmpty(textBox11.Text) && !string.IsNullOrWhiteSpace(textBox11.Text) &&
                    !string.IsNullOrEmpty(textBox12.Text) && !string.IsNullOrWhiteSpace(textBox12.Text) &&
                    !string.IsNullOrEmpty(textBox13.Text) && !string.IsNullOrWhiteSpace(textBox13.Text) &&
                    !string.IsNullOrEmpty(textBox14.Text) && !string.IsNullOrWhiteSpace(textBox14.Text) &&
                    !string.IsNullOrEmpty(textBox15.Text) && !string.IsNullOrWhiteSpace(textBox15.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [Table] SET [семестр]=@семестр, [предмет]=@предмет,  [оценка]=@оценка, [долг]=@долг WHERE [Id]=@Id", sqlConnection);
                command.Parameters.AddWithValue("Id", textBox11.Text);
                command.Parameters.AddWithValue("долг", textBox12.Text);
                command.Parameters.AddWithValue("оценка", textBox13.Text);
                command.Parameters.AddWithValue("предмет", textBox14.Text);
                command.Parameters.AddWithValue("семестр", textBox15.Text);
                await command.ExecuteNonQueryAsync();
            }

            else if (!string.IsNullOrEmpty(textBox11.Text) && !string.IsNullOrWhiteSpace(textBox11.Text))
            {
                label16.Visible = true;
                label16.Text = "id должен быть заполнен ";
            }
            else
            {
                label16.Visible = true;
                label16.Text = "поля должны быть заполнены ";
            }
        }

        public async void button2_Click(object sender, EventArgs e)
        {
            if (label7.Visible)
                label7.Visible = false;
            if (!string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox10.Text))

            {
                SqlCommand command = new SqlCommand("DELETE FROM [Table] WHERE [Id]=@Id", sqlConnection);
                command.Parameters.AddWithValue("Id", textBox10.Text);

                await command.ExecuteNonQueryAsync();
            }


            else
            {
                label7.Visible = true;
                label7.Text = "Id должен быть заполнен ";
            }
        }

        public void вернутьсяВГлавноеМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        public async void button5_Click(object sender, EventArgs e)
        {
            //массив для хранения суммы оценок за два семестра
            int[] oz = new int[2];
            //массив для хранения количества оценок за каждый семестр
            int[] cn = new int[2];
            //вспомогательные переменные
            int i, oz5 = 0, oz4 = 0, oz3 = 0, dolg = 0, totaloz = 0, curroz, sumoz = 0;
            for (i = 0; i < 2; i++)
            {
                //инициализируем массивы
                oz[i] = 0;
                cn[i] = 0;
            }
            //задаём запрос
            SqlCommand command = new SqlCommand("SELECT * FROM [Table]", sqlConnection);
            SqlDataReader sqlReader = null;
            try
            {
                //выполняем запрос
                sqlReader = await command.ExecuteReaderAsync();
                //получаем данные 
                while (await sqlReader.ReadAsync())
                {
                    //получаем номер семестра
                    i = Convert.ToInt32(sqlReader["семестр"]) - 1;
                    //получаем текущую оценку
                    curroz = Convert.ToInt32(sqlReader["оценка"]);
                    if (i == 0 || i == 1)
                    {
                        //добавляем оценку к сумме оценок за семестр
                        oz[i] += curroz;
                        //увеличиваем количество оценок на 1
                        cn[i]++;
                    }
                    //проверяем оценку если она равна 5 то увеличиваем переменную с количеством 5-к на 1
                    if (curroz == 5) oz5++;
                    //аналогично для 4 и 3
                    if (curroz == 4) oz4++;
                    if (curroz == 3) oz3++;
                    //увеличиваем переменную dolg на текущее количество долгов
                    dolg += Convert.ToInt32(sqlReader["долг"]);
                    //увеличиваем общее количество оценок
                    totaloz++;
                    //суммируем оценки
                    sumoz += curroz;
                }
                //вычисляем среднюю оценку за 1 семестр
                double sr1 = cn[0] > 0 ? Math.Round((double)oz[0] / cn[0], 2) : 0;
                //вычисляем среднюю оценку за 2 семестр
                double sr2 = cn[1] > 0 ? Math.Round((double)oz[1] / cn[1], 2) : 0;
                double sr = Math.Round((double)sumoz / totaloz, 2);
                //формируем строку ответ
                string mes = "Статистика:\n\tСредняя оценка за 1 курс = " + sr + "\n\tСредняя оценка за 1 курс первого семестра = " + sr1 + "\n\tСредняя оценка за 1 курс второго семестра = " + sr2;
                //вычисляем процентное отношение оценок к общему количеству
                double pr5 = Math.Round((double)(oz5 * 100) / totaloz, 2);
                double pr4 = Math.Round((double)(oz4 * 100) / totaloz, 2);
                double pr3 = Math.Round((double)(oz3 * 100) / totaloz, 2);
                //дополняем строку ответ
                mes += "\n\tКоличество оценок отлично = " + pr5 + "%\n\tКоличество оценок хорошо = " + pr4 + "%\n\tКоличество оценок удовлетворительно = " + pr3 + "%\n\tКоличество не сданных долгов = " + dolg;
                //выволим ответ
                MessageBox.Show(mes, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null) sqlReader.Close();

            }

        }

         /*!
          Кнопка для перехода на главную форму
          */
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
