using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Record record = new Record();
        public Form1()
        {
            InitializeComponent(); 
        }       

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Сохранить ранее введенные данные", "Внимание", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                record.RecordParam();
            }
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {            
            record.GetListParam(enterType.Text, enterPrice.Text);
            enterType.Clear();
            enterPrice.Clear();
            enterType.Select();
        }

        private void buttonZero_Click(object sender, EventArgs e)
        {
            record.RecordParam();
            record.ZeroPrice();
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Отчет за " + DateTime.Now);
            record.RecordParam();
            record.Total();
            Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            record.GetListLegal(legalType.Text, legalName.Text);
            legalType.Clear();
            legalType.Select();
        }
        
        private void buttonRec_Click(object sender, EventArgs e)
        {
            record.RecordParam();
            record.RecodLegal();
            legalName.Clear();
            legalName.Select();
        }        
    }
}
