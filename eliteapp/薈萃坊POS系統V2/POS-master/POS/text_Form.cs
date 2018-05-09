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
    public partial class text_Form : Form
    {
        public text_Form()
        {
            InitializeComponent();
        }

        public text_Form(string text)
        {
            InitializeComponent();
            richTextBox1.Text = text;
        }
    }
}
