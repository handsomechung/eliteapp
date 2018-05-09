namespace POS
{
    partial class BMS_Form
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
            this.gb_menu = new System.Windows.Forms.GroupBox();
            this.new_menu_button = new System.Windows.Forms.Button();
            this.confirm_button = new System.Windows.Forms.Button();
            this.gb_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_menu
            // 
            this.gb_menu.Controls.Add(this.new_menu_button);
            this.gb_menu.Location = new System.Drawing.Point(13, 13);
            this.gb_menu.Name = "gb_menu";
            this.gb_menu.Size = new System.Drawing.Size(259, 100);
            this.gb_menu.TabIndex = 0;
            this.gb_menu.TabStop = false;
            this.gb_menu.Text = "菜單";
            // 
            // new_menu_button
            // 
            this.new_menu_button.Location = new System.Drawing.Point(7, 22);
            this.new_menu_button.Name = "new_menu_button";
            this.new_menu_button.Size = new System.Drawing.Size(246, 23);
            this.new_menu_button.TabIndex = 0;
            this.new_menu_button.Text = "新增";
            this.new_menu_button.UseVisualStyleBackColor = true;
            this.new_menu_button.Click += new System.EventHandler(this.new_menu_button_Click);
            // 
            // confirm_button
            // 
            this.confirm_button.Location = new System.Drawing.Point(197, 227);
            this.confirm_button.Name = "confirm_button";
            this.confirm_button.Size = new System.Drawing.Size(75, 23);
            this.confirm_button.TabIndex = 1;
            this.confirm_button.Text = "確定";
            this.confirm_button.UseVisualStyleBackColor = true;
            this.confirm_button.Click += new System.EventHandler(this.confirm_button_Click);
            // 
            // BMS_Form

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 262);
            this.Controls.Add(this.confirm_button);
            this.Controls.Add(this.gb_menu);
            this.Name = "BMS_Form";
            this.Text = "後臺管理系統";
            this.Load += new System.EventHandler(this.BMS_Form_Load);
            this.gb_menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_menu;
        private System.Windows.Forms.Button new_menu_button;
        private System.Windows.Forms.Button confirm_button;
    }
}