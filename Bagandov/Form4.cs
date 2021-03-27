using Microsoft.SqlServer.Server;
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
    public partial class Form4 : Form
    {
        private int[] id = new int[10];
        SqlConnection sqlConnection;
        public Form4()
        {
            MaximizeBox = false;
            InitializeComponent();
        }

        public class Model
        {
            public int Id { get; set; }
            public string Клиент { get; set; }


            public string Тип { get; set; }
            public string Произвдитель { get; set; }
            public string Модель { get; set; }
            public string SN { get; set; }
            public string Описниенеисправности { get; set; }


        }
        private async void Form4_Load(object sender, EventArgs e)
        {

            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);

            string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionstring);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlrider = null;
            SqlCommand comand = new SqlCommand("SELECT * FROM [Table]", sqlConnection);
            var models = new List<Model>();
            try
            {
                sqlrider = await comand.ExecuteReaderAsync();

                while (await sqlrider.ReadAsync())
                {


                    Model m = new Model();
                    m.Id = (int)sqlrider["Id"];
                    m.Клиент = (string)sqlrider["Клиент"];
                    m.Тип = (string)sqlrider["Тип"];
                    m.Произвдитель = (string)sqlrider["Производитель"];
                    m.Модель = (string)sqlrider["Модель"];
                    m.SN = (string)sqlrider["SN"];
                    m.Описниенеисправности = (string)sqlrider["Описниенеисправности"];




                    models.Add(m);
                }

                dataGridView1.DataSource = models;
                dataGridView1.Columns[0].Width = 20;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].Width = 150;
                dataGridView1.Columns[4].Width = 150;
                dataGridView1.Columns[5].Width = 150;
                dataGridView1.Columns[6].Width = 1500;


            }

            finally
            {
                if (sqlrider != null)
                {
                    sqlrider.Close();
                }
            }
        }





        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
        }



        private async void button1_Click(object sender, EventArgs e)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
           
            string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionstring);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlrider = null;
            SqlCommand comand = new SqlCommand("SELECT * FROM [Table]", sqlConnection);
            var models = new List<Model>();
            try
            {
                sqlrider = await comand.ExecuteReaderAsync();

                while (await sqlrider.ReadAsync())
                {


                    Model m = new Model();
                    m.Id = (int)sqlrider["Id"];
                    m.Клиент = (string)sqlrider["Клиент"];
                    m.Тип = (string)sqlrider["Тип"];
                    m.Произвдитель = (string)sqlrider["Производитель"];
                    m.Модель = (string)sqlrider["Модель"];
                    m.SN = (string)sqlrider["SN"];
                    m.Описниенеисправности = (string)sqlrider["Описниенеисправности"];




                    models.Add(m);
                }

                dataGridView1.DataSource = models;
                dataGridView1.Columns[0].Width = 20;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].Width = 150;
                dataGridView1.Columns[4].Width = 150;
                dataGridView1.Columns[5].Width = 150;
                dataGridView1.Columns[6].Width = 1500;

            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlrider != null)
                {
                    sqlrider.Close();
                }
            }
        }

        

       

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 train = new Form4();


            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {




            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                
                SqlCommand comand = new SqlCommand("DELETE FROM [Table] WHERE [id]=@id", sqlConnection);
                comand.Parameters.AddWithValue("id", textBox1.Text);
                
                await comand.ExecuteNonQueryAsync();

            }
            else
            {
                label2.Visible = true;
                label2.Text = "Заполните поле";
            }

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))
            {

                SqlCommand comand = new SqlCommand("INSERT INTO [Table1]( Клиент, Тип, Производитель, Модель, SN, Описниенеисправности)SELECT  Клиент, Тип, Производитель, Модель, SN, Описниенеисправности FROM [Table] WHERE [Клиент]=@id", sqlConnection);
                comand.Parameters.AddWithValue("id", textBox1.Text.ToString());
                await comand.ExecuteNonQueryAsync();


                SqlCommand comand1 = new SqlCommand("DELETE FROM [Table] WHERE [Клиент]=@id", sqlConnection);
                    comand1.Parameters.AddWithValue("id", textBox1.Text);

                    await comand1.ExecuteNonQueryAsync();

               
           

            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 train = new Form3();
            this.Visible = true;
            train.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox2.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;

                        }
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                
            }

        }
    }

}
