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
    public partial class Form2 : Form
    {
        DAOAdmin dao;
        DAOAnim daoanim;
        Demande d;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dao = new DAOAdmin();
            daoanim = new DAOAnim();
            dataGridView1.Visible = true;
            // on associe dataset et datagrid
            DataSet donnees = dao.GetAllDemandesInDataSet();
            dataGridView1.DataSource = donnees;

            dataGridView1.DataMember = donnees.Tables[0].ToString();

            label1.Hide();
            label2.Hide();
            label3.Hide();
            label5.Hide();
            tb_date.Hide();
            tb_debut.Hide();
            tb_fin.Hide();
            tb_remarque.Hide();

            DataSet test = daoanim.getAllanim2(); 
            comboBox2.DataSource = test.Tables[0];
            comboBox2.ValueMember = "id";
            comboBox2.DisplayMember = "nom";


            /*foreach(Animateur anim in lAnim)
            {

                comboBox2.Items.Add(anim);
                comboBox2.SelectedIndex = 0;
                
            }*/


        }

        private void button1_Click(object sender, EventArgs e)
        {
            d = new Demande(Convert.ToInt16(dataGridView1.CurrentRow.Cells["id"].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value), Convert.ToInt16(dataGridView1.CurrentRow.Cells[7].Value), Convert.ToInt16(dataGridView1.CurrentRow.Cells[8].Value),0);

            label1.Show();
            label2.Show();
            label3.Show();
            label5.Show();
            tb_date.Show();
            tb_debut.Show();
            tb_fin.Show();
            tb_remarque.Show();

        }
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vous allez accepter la demande numero " + dataGridView1.CurrentRow.Cells[0].Value);

            string value = "Entrez ici une remarque";
            if (InputBox("Remarque", "remarque :", ref value) == DialogResult.OK)
            {
                MessageBox.Show("La remaque sera : " + value);
                dataGridView1.CurrentRow.Cells[6].Value = value;
                int test2 = Convert.ToInt16(comboBox2.SelectedValue);
                dao.accepterDemande(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value) ,value,Convert.ToInt16(comboBox2.SelectedValue));
            }
            hidetb();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vous allez refuser la demande numero " + dataGridView1.CurrentRow.Cells[0].Value);

            string value = "Entrez ici une remarque";
            if (InputBox("Remarque", "remarque :", ref value) == DialogResult.OK)
            {
                MessageBox.Show("La remaque sera : " + value);
                dataGridView1.CurrentRow.Cells[6].Value = value;
                dataGridView1.CurrentRow.Cells[4].Value = "accepter";
                dao.refuserDemande(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value), value);
            }
            hidetb();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Demande d2 = new Demande(0, tb_date.Text, tb_debut.Text,tb_fin.Text,tb_remarque.Text,"en attente","",d.IdProd,d.IdPharma,d.Id);
            dao.insertDemande(d2);
            

            dataGridView1.DataSource = null;
            DataSet donnees = dao.GetAllDemandesInDataSet();
            dataGridView1.DataSource = donnees;

            dataGridView1.DataMember = donnees.Tables[0].ToString();

            hidetb();
        }


        public void hidetb()
        {
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label5.Hide();
            tb_date.Hide();
            tb_debut.Hide();
            tb_fin.Hide();
            tb_remarque.Hide();
            tb_date.Clear();
            tb_debut.Clear();
            tb_fin.Clear();
            tb_remarque.Clear();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            DataSet donnees = dao.GetAllDemandesInDataSet();
            dataGridView1.DataSource = donnees;

            dataGridView1.DataMember = donnees.Tables[0].ToString();
        }
    }
}