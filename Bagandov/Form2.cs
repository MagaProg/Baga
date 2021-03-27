using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bagandov
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            MaximizeBox = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 train = new Form1();
            this.Visible = true;
            train.ShowDialog();
            
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 train = new Form4();
            this.Visible = false;
            train.ShowDialog();
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
    }

