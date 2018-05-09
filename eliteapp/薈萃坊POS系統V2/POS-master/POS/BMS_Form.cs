using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POS
{
    public partial class BMS_Form : Form
    {
        public BMS_Form()
        {
            InitializeComponent();
            
        }
        public Order_Form of3;
        string item = "";
        string price = "";

        private void new_menu_button_Click(object sender, EventArgs e)
        {
            KeyInForm kif;
            kif= new KeyInForm("品項");
            kif.ShowDialog();
            item = kif.key_in_textBox.Text;
            kif = new KeyInForm("價錢");
            kif.ShowDialog();
            price = kif.key_in_textBox.Text;

            of3.menu_listBox.Items.Add(item);
            //of3.count_listBox.Items.Add(0);

            //text_Form t_f = new text_Form(item + "-"+price);
            //t_f.Show();
        }

        private void confirm_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            // Enter 鍵 -> 確認按鈕
            if (keyData == Keys.Enter && !this.confirm_button.Focused)
            {
                confirm_button_Click(null, null);
            }

            if (keyData == Keys.N && !this.new_menu_button.Focused)
            {
                new_menu_button_Click(null, null);
            }

            return base.ProcessDialogKey(keyData);
        }

        private void BMS_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
