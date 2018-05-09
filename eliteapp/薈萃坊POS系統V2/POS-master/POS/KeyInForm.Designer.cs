namespace POS
{
    partial class KeyInForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.key_in_textBox = new System.Windows.Forms.TextBox();
            this.confirm_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // key_in_textBox
            // 
            this.key_in_textBox.Location = new System.Drawing.Point(14, 25);
            this.key_in_textBox.Name = "key_in_textBox";
            this.key_in_textBox.Size = new System.Drawing.Size(258, 22);
            this.key_in_textBox.TabIndex = 1;
            // 
            // confirm_button
            // 
            this.confirm_button.Location = new System.Drawing.Point(197, 62);
            this.confirm_button.Name = "confirm_button";
            this.confirm_button.Size = new System.Drawing.Size(75, 23);
            this.confirm_button.TabIndex = 2;
            this.confirm_button.Text = "確認";
            this.confirm_button.UseVisualStyleBackColor = true;
            this.confirm_button.Click += new System.EventHandler(this.confirm_button_Click);
            // 
            // KeyInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 97);
            this.Controls.Add(this.confirm_button);
            this.Controls.Add(this.key_in_textBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "KeyInForm";
            this.Text = "輸入資料";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button confirm_button;
        public System.Windows.Forms.TextBox key_in_textBox;
    }
}