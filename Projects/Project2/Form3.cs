using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;
using System.Data.OleDb;
using System.Threading;
namespace Spravka
{
    public partial class Form3 : Form
    {
        //изменить тут================================================
        private readonly string TemplateFileName = @"D:\\ИС И ТЕХ\\Spravka\\Spravka_maket.docx";
        OleDbConnection con;
        public Form3()
        {
           
            if (Form2.control_num == 1)
            {
                 InitializeComponent();
                //Form2 main = this.Owner as Form2;
                
                //текущая дата
                string get_date = Form2.date_now.ToString();

                var wordApp = new Word.Application();
                wordApp.Visible = false;
                //изменить тут================================================
                con = new OleDbConnection(@"Provider=Microsoft.ACE.Oledb.12.0;Data Source=D:\ИС И ТЕХ\Spravka\university.accdb");
                OleDbCommand cmd = new OleDbCommand();
                OleDbCommand cmd1 = new OleDbCommand();
                cmd.Connection = con;
                cmd1.Connection = con;
                con.Open();
                OleDbDataReader reader = null;
                cmd.CommandText = "SELECT * FROM Студенты as s inner join [Персональные данные] as p on s.[Номер зачётной книжки] = p.[Номер зачётной книжки]" +
                    " where Логин='" + Form2.s1 + "' AND Пароль='" + Form2.s2 + "'";

                reader = cmd.ExecuteReader();
                string name_stud = "";
                string byrth = "";
                string num_kurs = "";
                string form_stud = "";
                string spec_stud = "";
                string osnov_stud = "";
                string num_prik = "";
                string data_zach = "";
                while (reader.Read())
                {
                    name_stud = reader["Фамилия"].ToString()+ " " + reader["Имя"].ToString() + " " + reader["Отчество"].ToString();
                    byrth = reader["Дата рождения"].ToString();
                    num_kurs = reader["Курс"].ToString();
                    form_stud = reader["Форма обучения"].ToString();
                    spec_stud = reader["Специальность"].ToString();
                    osnov_stud = reader["Основа обучения"].ToString();
                    num_prik = reader["Номер приказа о зачислении"].ToString();
                    data_zach = reader["Дата зачисления"].ToString();
                }
                if (form_stud.Length==5)
                {
                    form_stud = form_stud.Substring(0, 3) + "ой";
                }
                else
                {
                    form_stud = form_stud.Substring(0, 5) + "ой";
                }
                string faclt = Form2.facult.ToLower();

                if (faclt == "строительный")
                {
                    faclt = "строительного";
                }
                if (faclt == "информатика и вычислительная техника")
                {
                    faclt = "информатики и вычислительной техники";
                }
                if (faclt == "юридический")
                {
                    faclt = "юридического";
                }

                if (osnov_stud == "бюджет")
                {
                    osnov_stud = "бюджетной";
                }
                else
                {
                    osnov_stud = "платной";
                }
               
                spec_stud = spec_stud.Substring(0, 8) + " «" + spec_stud.Substring(9, spec_stud.Length-9) + "»";
                data_zach = data_zach.Substring(0, 10);
                byrth = byrth.Substring(0, 10);
                name_stud = name_stud.ToUpper();
                reader.Close();
                //Номер справки
                ///*
                OleDbDataReader reader1 = null;
                cmd.CommandText = "SELECT [Код запроса] FROM [Запросы] Order by [Код запроса]";
                string cod_zap = "";
                reader1 = cmd.ExecuteReader();
                while (reader1.Read())
                {
                    cod_zap = reader1["Код запроса"].ToString();
                }
                cod_zap = cod_zap + "/кб";
                reader1.Close();
                con.Close();
                var wordDocument = wordApp.Documents.Open(TemplateFileName);
                var wordapp1 = wordDocument;
                    
                ReplaceWordStub("{getdate}", get_date, wordapp1);
                ReplaceWordStub("{numspravka}", cod_zap, wordapp1);
                    ReplaceWordStub("{NAMESTUD}", name_stud, wordapp1);
                    ReplaceWordStub("{byrth}", byrth, wordapp1);
                    ReplaceWordStub("{formstud}", form_stud, wordapp1);
                    ReplaceWordStub("{numkurs}", num_kurs, wordapp1);
                    ReplaceWordStub("{namedek}", Form2.dek, wordapp1);
                    ReplaceWordStub("{faculty}", faclt, wordapp1);
                    ReplaceWordStub("{specstud}", spec_stud, wordapp1);
                    ReplaceWordStub("{osnovstud}", osnov_stud, wordapp1);
                    ReplaceWordStub("{numprikaz}", num_prik, wordapp1);
                    ReplaceWordStub("{datazach}", data_zach, wordapp1);
                //wordapp1.SaveAs2(@"E:\\ИС И ТЕХ\\Spravka\\Spravka.docx");
                // string dirname = @"C:";

                //изменить тут================================================
                if (!Directory.Exists(@"D:\\Справка")) 
                    {
                    Directory.CreateDirectory(@"D:\\Справка");
                    }
                   
                    wordapp1.SaveAs2(@"D:\Справка\Spravka.docx");
                    wordapp1.Application.Visible = true;
                    MessageBox.Show("Ваша справка находится в диске «C» в папке «Справка».");
            }

        }
        private void ReplaceWordStub(string stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
