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
        public partial class Form3 : Form
        {
            SqlConnection sqlConnection;
            public Form3()
            {
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
                public string ккк { get; set; }
                public string кккк { get; set; }


            }
            private async void Form3_Load(object sender, EventArgs e)
            {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);

            string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionstring);
                await sqlConnection.OpenAsync();
                SqlDataReader sqlrider = null;
                SqlCommand comand = new SqlCommand("SELECT * FROM [Table1]", sqlConnection);
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
                SqlDataReader sqlrider1 = null;
                SqlCommand comand1 = new SqlCommand("SELECT * FROM [Table2]", sqlConnection);
                var models1 = new List<Model>();
                try
                {
                    sqlrider1 = await comand1.ExecuteReaderAsync();

                    while (await sqlrider1.ReadAsync())
                    {


                        Model n = new Model();
                        n.Id = (int)sqlrider1["Id"];
                        n.Клиент = (string)sqlrider1["Клиент"];
                        n.ккк = (string)sqlrider1["ккк"];
                        n.кккк = (string)sqlrider1["кккк"];
                    




                        models1.Add(n);
                    }
               
                dataGrid3.DataSource = models1;
                dataGrid3.Columns[0].Width = 50;
                dataGrid3.Columns[1].Width = 150;
                dataGrid3.Columns[2].Width = 0;
                dataGrid3.Columns[3].Width = 0;
                dataGrid3.Columns[4].Width = 0;
                dataGrid3.Columns[5].Width = 0;
                dataGrid3.Columns[6].Width = 0;
                dataGrid3.Columns[7].Width = 250;
                dataGrid3.Columns[8].Width =250;


            }

            finally
            {
                if (sqlrider1 != null)
                {
                    sqlrider1.Close();
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text)
                && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
                && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
            {
               


               

                SqlCommand comand1 = new SqlCommand("INSERT INTO [Table2]( Клиент,ккк, кккк )  SELECT  Клиент,@ккк, @кккк FROM [Table1] WHERE  [id]=@id",  sqlConnection);
                comand1.Parameters.AddWithValue("id", textBox1.Text);
                comand1.Parameters.AddWithValue("ккк", textBox2.Text);
                comand1.Parameters.AddWithValue("кккк", textBox3.Text);
                await comand1.ExecuteNonQueryAsync();

                if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))
                {

                    SqlCommand comand = new SqlCommand("DELETE FROM [Table1] WHERE [id]=@id", sqlConnection);
                    comand.Parameters.AddWithValue("id", textBox1.Text);

                    await comand.ExecuteNonQueryAsync();

                }
               
            }
            else
            {
                label2.Visible = true;
                label2.Text = "Заполните поле";
            }

           
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 train = new Form3();


            this.Close();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            SqlDataReader sqlrider = null;
            SqlCommand comand = new SqlCommand("SELECT * FROM [Table1]", sqlConnection);
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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void button6_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))
            {

                SqlCommand comand = new SqlCommand("DELETE FROM [Table1] WHERE [id]=@id", sqlConnection);
                comand.Parameters.AddWithValue("id", textBox1.Text);

                await comand.ExecuteNonQueryAsync();

            }
            
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            SqlDataReader sqlrider1 = null;
            SqlCommand comand1 = new SqlCommand("SELECT * FROM [Table2]", sqlConnection);
            var models1 = new List<Model>();
            try
            {
                sqlrider1 = await comand1.ExecuteReaderAsync();

                while (await sqlrider1.ReadAsync())
                {


                    Model n = new Model();
                    n.Id = (int)sqlrider1["Id"];
                    n.Клиент = (string)sqlrider1["Клиент"];
                    n.ккк = (string)sqlrider1["ккк"];
                    n.кккк = (string)sqlrider1["кккк"];





                    models1.Add(n);
                }

                dataGrid3.DataSource = models1;
                dataGrid3.Columns[0].Width = 50;
                dataGrid3.Columns[1].Width = 150;
                dataGrid3.Columns[2].Width = 0;
                dataGrid3.Columns[3].Width = 0;
                dataGrid3.Columns[4].Width = 0;
                dataGrid3.Columns[5].Width = 0;
                dataGrid3.Columns[6].Width = 0;
                dataGrid3.Columns[7].Width = 250;
                dataGrid3.Columns[8].Width = 250;


            }

            finally
            {
                if (sqlrider1 != null)
                {
                    sqlrider1.Close();
                }
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {

                SqlCommand comand = new SqlCommand("DELETE FROM [Table2] WHERE [id]=@id", sqlConnection);
                comand.Parameters.AddWithValue("id", textBox4.Text);

                await comand.ExecuteNonQueryAsync();

            }
        }
    }
}
