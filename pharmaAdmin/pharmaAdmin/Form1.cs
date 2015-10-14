using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmaAdmin
{
    public partial class Form1 : Form
    {
        DAOAdmin dao;
        public Form1()
        {
            InitializeComponent();
            dao = new DAOAdmin();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dao.conecAdmin(textBox2.Text,textBox1.Text)==true)
            {
               
                Form2 frm = new Form2();
                frm.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("mdp ou login faux");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
