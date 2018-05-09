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
    public partial class KeyInForm : Form
    {
        public KeyInForm()
        {
            InitializeComponent();
        }

        public KeyInForm(string KeyValue)
        {
            InitializeComponent();
            this.label1.Text = KeyValue;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            // Enter 鍵 -> 確認按鈕
            if (keyData == Keys.Enter && !this.confirm_button.Focused)
            {
                confirm_button_Click(null, null);
            }
            return base.ProcessDialogKey(keyData);
        }

        private void confirm_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
