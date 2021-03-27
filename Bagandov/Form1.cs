using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bagandov
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;
        public Form1()
        {
            

           
            InitializeComponent();
            MaximizeBox = false;
            
        }
 private async void Form1_Load(object sender, EventArgs e)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);

            string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionstring);
            await sqlConnection.OpenAsync();

            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string tx1 = textBox1.Text;
            string tx2 = textBox2.Text;
            string tx3 = textBox3.Text;
            string tx4 = textBox4.Text;
            string tx5 = textBox5.Text;
            string tx6 = textBox6.Text;

            if (tx1 == "" || tx2 == "" || tx3 == "" || tx4 == "" || tx5 == "" || tx6 == "")
            {
                label8.Text = " Заполните все поля! ";

                return;
            } 
            
            MessageBox.Show("Заказ успешно оформлен");
            SqlCommand comand = new SqlCommand("INSERT  INTO [Table] (Клиент, Тип, Производитель, Модель, SN, Описниенеисправности)VALUES(@Клиент, @Тип, @Производитель, @Модель, @SN, @Описниенеисправности)", sqlConnection);
            comand.Parameters.AddWithValue("Клиент", textBox1.Text);
            comand.Parameters.AddWithValue("Тип", textBox2.Text);
            comand.Parameters.AddWithValue("Производитель", textBox3.Text);
            comand.Parameters.AddWithValue("Модель", textBox4.Text);
            comand.Parameters.AddWithValue("SN", textBox5.Text);
            comand.Parameters.AddWithValue("Описниенеисправности", textBox6.Text);
            
            await comand.ExecuteNonQueryAsync();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            label8.Text = "";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 train = new Form1();
           
           
            this.Close();
        }

       

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
        }
    }
    }

