using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace POS
{
    public partial class Order_Form : Form
    {
        //BMS_Form bms_form = new BMS_Form();
        List<int> count5_store = new List<int>();//Form1專用
        List<string> item_store = new List<string>();
        List<int> customer_store = new List<int>();
        List<int> meal_store = new List<int>();
        List<int> revenue_store = new List<int>();
        List<int> null_class = new List<int>();
        public static int blank;
        int index_confirm = 0;
        //建立員工出餐的datatable
        DataTable board = new DataTable();
        int count = 0;
        int count2 = 0;
        int count3 = 1;

        public List<Menu> l_menu = new List<Menu>();


        public Order_Form()
        {
            InitializeComponent();
            //單點
            list_single.Items.Add("美式咖啡(35)");
            list_single.Items.Add("咖啡拿鐵(45)");
            list_single.Items.Add("巧克力牛奶(30)");
            list_single.Items.Add("紅茶拿鐵(30)");
            list_single.Items.Add("抹茶拿鐵(35)");
            list_single.Items.Add("紅茶(20)");
            list_single.Items.Add("鮮奶(30)");
            list_single.Items.Add("日本高鈣(30)");
            list_single.Items.Add("荷蘭貴族(35)");
            list_single.Items.Add("蜂蜜蛋糕(35)");

            //單點內用OR外帶
            in_or_out_1.Items.Add("內用");
            in_or_out_1.Items.Add("外帶");

            //套餐
            list_double.Items.Add("A:美式咖啡+日本高鈣(50)");
            list_double.Items.Add("B:咖啡拿鐵+日本高鈣(60)");
            list_double.Items.Add("C:巧克力牛奶+荷蘭貴族(64)");
            list_double.Items.Add("D:紅茶拿鐵+荷蘭貴族(39)");
            list_double.Items.Add("E:抹茶拿鐵+蜂蜜蛋糕(60)");
            list_double.Items.Add("F:紅茶+蜂蜜蛋糕(40)");

            //套餐內用OR外帶
            in_or_out_2.Items.Add("內用");
            in_or_out_2.Items.Add("外帶");
            int column_count = meal_for_cashier.ColumnCount;
            meal_for_cashier.ColumnHeadersDefaultCellStyle.Font = new Font("細明體", 12, FontStyle.Regular);
            meal_for_cashier.Columns[0].Width = 140;
            meal_for_cashier.Columns[4].Width = 120;
            int column_count2 = meal_for_cashier.Columns.Count;
            for (int i = 0; i < column_count2; i++)     //設置標題Column置中
            {
                meal_for_cashier.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        #region tool strip button

        private void bms_ts_button_Click(object sender, EventArgs e)
        {
           
        }

        #endregion

        public class Menu
        {
            public string name { get; set; }
            public int price { get; set; }
        }

        private void add_in_meal_Click(object sender, EventArgs e)
        {
            string inout = "";
            //加入客人點的菜單
            //加入產品
            string product = list_single.SelectedItem.ToString();
       
            //加入數量
            int count = (int)single_num.Value;

            //加入金額,金額是從產品中把數字部分萃取出來
            string price;
            getstrint(product, out price);

            int total = count * Convert.ToInt32(price);
            //算總價,要轉換型別

            //避免店員忘記選擇餐點數量
            if (total == 0)
            {
                MessageBox.Show("請輸入餐點數量");
            }

            //判斷內用還是外帶
            if (total != 0)
            {
                try
                {
                    
                    inout = in_or_out_1.SelectedItem.ToString();
                    //加入表格
                    DataGridViewRowCollection rows = meal_for_cashier.Rows;
                    rows.Add(new Object[] { product, price, count, total, inout });
                    single_num.Value = 0;
                    //消除點選的藍色背景
                    //clear_backgound(list_single.SelectedIndex, in_or_out_1.SelectedIndex);此作法失敗
                    list_single.SelectedIndex = -1;
                    in_or_out_1.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("請輸入內用or外帶");
                }
            }
            

            //計算總價
            //calculateTotal();


        }
        private void add_in_meal_two_Click(object sender, EventArgs e)
        {
            string inout = "";
            //加入客人點的菜單
            //加入產品
            string product = list_double.SelectedItem.ToString();

            //加入數量
            int count = (int)double_num.Value;

            //加入金額,金額是從產品中把數字部分萃取出來
            string price;
            getstrint(product, out price);

            //算總價,要轉換型別
            int total = count * Convert.ToInt32(price);

            //避免店員忘記選擇餐點數量
            if (total == 0)
            {
                MessageBox.Show("請輸入餐點數量");
            }


            //判斷內用還是外帶
            if (total != 0)
            {
                try
                {
                    inout = in_or_out_2.SelectedItem.ToString();
                    //加入表格
                    DataGridViewRowCollection rows = meal_for_cashier.Rows;
                    rows.Add(new Object[] { product, price, count, total, inout });
                    double_num.Value = 0;
                    //消除點選的藍色背景
                    //clear_backgound(list_double.SelectedIndex, in_or_out_2.SelectedIndex); 此作法失敗
                    list_double.SelectedIndex = -1;
                    in_or_out_2.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("請輸入內用or外帶");
                }
            }
            



            //計算總價
            //calculateTotal();
        }
        //將字串的數字部分讀出來
        public static void getstrint(string msg, out string intstr)
        {
            intstr = Regex.Replace(msg, "[^0-9]", "");
        }
        //清除listbox的點選紀錄(背景)
        public static void clear_backgound(int a, int b)
        {
            a = -1;
            b = -1;
        }


        private void confirm_Click(object sender, EventArgs e)
        {

            //total_money.Text = "" + meal_for_cashier.Rows[0].Cells[1].Value;
            calculateTotal();

            index_confirm = 1;

        }
        //計算總金額
        private void calculateTotal()
        {
            int total = 0;
            int num_of_row = meal_for_cashier.RowCount;
            for (int i = 0; i < num_of_row; i++)//每列"小計"的總和
            {
                DataGridViewRow row = meal_for_cashier.Rows[i];
                if (row.Cells[0].Value != null)
                {
                    total += (int)row.Cells[3].Value;
                }
            }
            total_money.Text = total.ToString();
        }
        //客人點的餐點確認前可以修改
        private void delete_button_Click(object sender, EventArgs e)
        {
            DataGridViewRow r1 = meal_for_cashier.CurrentRow;
            meal_for_cashier.Rows.Remove(r1);
        }
        //付錢後要清空欄位
        private void pay_button_Click(object sender, EventArgs e)
        {
            if (index_confirm == 0)
            {
                MessageBox.Show("請先按\"確認點餐\"");
            }
            else
            {

                //board = new DataTable();
                //建立欄位
                CreateDataColumn();
                //清空cashier的介面
                
                meal_for_cashier.Rows.Clear();
                //重新歸零
                index_confirm = 0;
                //點餐金額重新歸零
                total_money.Text = "0";

                meal_of_custom.DataSource = board;
                meal_of_custom.Columns[3].Width = 200;//設置Column寬度
                int column_count = meal_of_custom.Columns.Count;
                for (int i = 0; i < column_count; i++)     //設置標題Column置中
                {
                    meal_of_custom.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

            }
        }

        private void ts_ts_button_Click(object sender, EventArgs e)
        {
            Form1 finance = new Form1();
            bool if_no_customer = checkBox1.Checked;
            finance.Datatable_value(meal_of_custom,ref count5_store,ref customer_store,ref meal_store,ref revenue_store,ref null_class, textBox1.Text,textBox2.Text, earn_money.Text,if_no_customer, ref blank);
            Debug.Print("blank={0}", blank);
            finance.ShowDialog();
        }

        private void CreateDataColumn()
        {
            if (count == 0)
            {
                //商品編號
                DataColumn colGoodsID = new DataColumn("餐點編號");
                colGoodsID.DataType = System.Type.GetType("System.String");
                colGoodsID.MaxLength = 100;
                colGoodsID.AllowDBNull = false;
                //顧客號碼
                DataColumn customerID = new DataColumn("顧客號碼");
                customerID.DataType = System.Type.GetType("System.String");
                customerID.MaxLength = 100;
                customerID.AllowDBNull = false;　
                //商品名稱
                DataColumn colTitle = new DataColumn("品名");
                colTitle.DataType = System.Type.GetType("System.String");
                colTitle.MaxLength = 100;
                colTitle.AllowDBNull = false;
                colTitle.Unique = false;
                //銷量
                DataColumn colQuantity = new DataColumn("數量");
                colQuantity.DataType = System.Type.GetType("System.Int32");
                //價錢
                DataColumn colprice = new DataColumn("總價");
                colprice.DataType = System.Type.GetType("System.Int32");
                //內用or外帶
                DataColumn in_or_out8 = new DataColumn("內用/外帶");
                in_or_out8.DataType = System.Type.GetType("System.String");
                //是否出餐
                DataColumn is_or_not = new DataColumn("是否出餐");
                is_or_not.DataType = System.Type.GetType("System.Boolean");
                is_or_not.AllowDBNull = true;//允許出現null值
                //將欄位加入資料表
                board.Columns.Add(is_or_not);
                board.Columns.Add(colGoodsID);
                board.Columns.Add(customerID);
                board.Columns.Add(colTitle);
                board.Columns.Add(colQuantity);
                board.Columns.Add(colprice);
                board.Columns.Add(in_or_out8);

            }
            int row_num = meal_for_cashier.RowCount;//**不包含標題，但包含最後一列空白列
            Boolean a = false; //一開始的checkbox都沒有被勾選
            count++;
            for (int i = 0; i < row_num - 1; i++)
            {
                count2++;
                board.Rows.Add(new object[] { a, count2, count, meal_for_cashier.Rows[i].Cells[0].Value, meal_for_cashier.Rows[i].Cells[2].Value, meal_for_cashier.Rows[i].Cells[3].Value, meal_for_cashier.Rows[i].Cells[4].Value });//取得第i列第1,2,3行的值
            }
            
            textBox1.Text = count.ToString();//顯示來客人數
        }

        private void meal_of_custom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void complete_MouseDown(object sender, MouseEventArgs e)
        {
            
            for (int i = 0; i < board.Rows.Count; i++)
            {
                if ((bool)board.Rows[i][0] == true)
                {
                    string item = board.Rows[i][1].ToString() + "號餐已出餐";

                    if (item_store.Contains(item)==false)
                    {
                      item_store.Add(item);
                      menu_listBox.Items.Add(item);
                      textBox2.Text = count3.ToString();//顯示出餐數
                      count3++;
                    }
                       
                }
            }
        }

        private void total_coco_MouseClick(object sender, MouseEventArgs e)
        {
            int total = 0;
            for (int i = 0; i < board.Rows.Count; i++)
            {
                total += (int)board.Rows[i][5];
            }
            earn_money.Text = total.ToString();
        }
        


        private void shift_Click(object sender, EventArgs e)
        {
            //meal_of_custom.DataSource=null; 失敗做法!雖然表面數據可移除，但歷史資料仍舊存在
            //meal_of_custom.Rows.Clear(); 失敗做法2!會出現提示“不能清除此列表”！
            //---------------------------------------------------------------------------------
            //DataTable dt = (DataTable)meal_of_custom.DataSource;
            //if (meal_of_custom.RowCount != 0)
            //{
            //    dt.Rows.Clear();
            //    meal_of_custom.DataSource = dt;
            //}
            //-------------------------------------------------------------------------------
            bool if_no_customer = checkBox1.Checked;
            Form1 finance = new Form1();//不得將此放在設定全域變數的地方，因為Form1介面也有在全域處呼叫Order_Form，如此便會造成"StackOverflowError"
            finance.Datatable_value(meal_of_custom, ref count5_store, ref customer_store,ref meal_store,ref revenue_store,ref null_class, textBox1.Text, textBox2.Text, earn_money.Text,if_no_customer,ref blank);
            finance.ShowDialog();
            if (checkBox1.Checked == true)
            {
                checkBox1.Checked = false;
            }
            menu_listBox.Items.Clear();
        }


    }
}
