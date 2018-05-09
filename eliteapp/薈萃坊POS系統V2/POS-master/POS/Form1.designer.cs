namespace POS
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.shift_time = new System.Windows.Forms.TextBox();
            this.out_meal = new System.Windows.Forms.TextBox();
            this.people_num = new System.Windows.Forms.TextBox();
            this.time_revenue = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.export = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(750, 264);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 315);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "當班時間";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(389, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "該時段出餐數";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(192, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "該時段人數";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(601, 315);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "該時段收益";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(14, 358);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "售價說明";
            // 
            // shift_time
            // 
            this.shift_time.Location = new System.Drawing.Point(85, 312);
            this.shift_time.Name = "shift_time";
            this.shift_time.ReadOnly = true;
            this.shift_time.Size = new System.Drawing.Size(51, 27);
            this.shift_time.TabIndex = 7;
            this.shift_time.TabStop = false;
            this.shift_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // out_meal
            // 
            this.out_meal.Location = new System.Drawing.Point(497, 312);
            this.out_meal.Name = "out_meal";
            this.out_meal.ReadOnly = true;
            this.out_meal.Size = new System.Drawing.Size(69, 27);
            this.out_meal.TabIndex = 8;
            this.out_meal.TabStop = false;
            this.out_meal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // people_num
            // 
            this.people_num.Location = new System.Drawing.Point(283, 312);
            this.people_num.Name = "people_num";
            this.people_num.ReadOnly = true;
            this.people_num.Size = new System.Drawing.Size(60, 27);
            this.people_num.TabIndex = 9;
            this.people_num.TabStop = false;
            this.people_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // time_revenue
            // 
            this.time_revenue.Location = new System.Drawing.Point(691, 313);
            this.time_revenue.Name = "time_revenue";
            this.time_revenue.ReadOnly = true;
            this.time_revenue.Size = new System.Drawing.Size(70, 27);
            this.time_revenue.TabIndex = 10;
            this.time_revenue.TabStop = false;
            this.time_revenue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(85, 354);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(675, 27);
            this.txtDescription.TabIndex = 11;
            this.txtDescription.TabStop = false;
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(662, 391);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(98, 30);
            this.export.TabIndex = 13;
            this.export.Text = "匯出表格";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 429);
            this.Controls.Add(this.export);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.time_revenue);
            this.Controls.Add(this.people_num);
            this.Controls.Add(this.out_meal);
            this.Controls.Add(this.shift_time);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "財務報表系統";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox shift_time;
        private System.Windows.Forms.TextBox out_meal;
        private System.Windows.Forms.TextBox people_num;
        private System.Windows.Forms.TextBox time_revenue;
        private System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button export;
    }
}

