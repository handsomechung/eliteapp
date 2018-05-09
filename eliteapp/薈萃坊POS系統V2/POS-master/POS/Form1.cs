using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace POS
{
    public partial class Form1 : Form
    {
        
        DataTable dtBooks;
        int count4=0;//當班班次
        int count5;
        int blank=0;
        string customer_num;
        string meal_num;
        string revenue2;
        bool if_no_customer;
        List<int> count5_store = new List<int>();
        List<int> customer_store = new List<int>();
        List<int> meal_store = new List<int>();
        List<int> revenue_store = new List<int>();
        List<int> null_class = new List<int>();
        Order_Form order = new Order_Form(); //new一個新物件無法傳遞值
        public Form1()
        {
            InitializeComponent();
        }
        public void Datatable_value(DataGridView data,ref List<int> count5_store, ref List<int> customer_store,ref List<int> meal_store,ref List<int> revenue_store,ref List<int> null_class, string customer_num,string meal_num, string revenue,bool if_no_customer,ref int blank)//將Order_Form的datagridview傳值過來
        {
            order.meal_of_custom = data;
            this.count5_store = count5_store;
            this.customer_num = customer_num;
            this.customer_store = customer_store;
            this.meal_store = meal_store;
            this.meal_num = meal_num;
            this.revenue_store = revenue_store;
            this.revenue2 = revenue;
            this.if_no_customer = if_no_customer;
            this.blank = blank;
            this.null_class = null_class;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dtBooks = new DataTable("Goods");
            //建立欄位
            CreateDataColumn();
            
            //設定DataGridView控制項顯示dsKINGS資料集裡的Product資料表
            dataGridView1.DataSource = dtBooks;
            dataGridView1.Columns[1].Width = 200;//設置Column寬度
            dataGridView1.Columns[4].Width = 130;//設置Column寬度
            dataGridView1.Columns[5].Width = 130;//設置Column寬度
            int column_count=dataGridView1.Columns.Count;
            for(int i = 0; i < column_count; i++)      //設置Column的標題及內文置中
            {
                dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//需搭配Form1的屬性AuternatinGrowsDefault方能使內文完全置中
            }

            //設定TextBox控制項的資料繫結
            shift_time.DataBindings.Add("Text", dtBooks, "當班時間");
        }

        private void CreateDataColumn()
        {
                //當班節次
                DataColumn shift = new DataColumn("當班時間");
                shift.DataType = System.Type.GetType("System.Int32");
                shift.AllowDBNull = true;
            //商品名稱
            DataColumn colTitle = new DataColumn("品名");
                colTitle.DataType = System.Type.GetType("System.String");
                colTitle.MaxLength = 500;
                colTitle.AllowDBNull = true;
                //總價
                DataColumn colPrice = new DataColumn("總價");
                colPrice.DataType = System.Type.GetType("System.Int32");
                colPrice.AllowDBNull = true;

                //銷量
                DataColumn colQuantity = new DataColumn("數量");
                colQuantity.DataType = System.Type.GetType("System.Int32");
                colQuantity.AllowDBNull = true;

                //到訪人數
                DataColumn people = new DataColumn("各班到訪人數");
                people.DataType = System.Type.GetType("System.Int32");
                people.AllowDBNull = true;

                //班次出餐數
                DataColumn meal = new DataColumn("各班出餐數");
                meal.DataType = System.Type.GetType("System.Int32");
                meal.AllowDBNull = true;

                //班次收益
                DataColumn revenue = new DataColumn("各班收益");
                revenue.DataType = System.Type.GetType("System.Int32");
                revenue.AllowDBNull = true;
                

                //將欄位加入資料表
                dtBooks.Columns.Add(shift);
                dtBooks.Columns.Add(colTitle);
                dtBooks.Columns.Add(colQuantity);
                dtBooks.Columns.Add(colPrice);
                dtBooks.Columns.Add(people);
                dtBooks.Columns.Add(meal);
                dtBooks.Columns.Add(revenue);
           
            int row = order.meal_of_custom.RowCount;
            int i = 0;//迴圈專用
            count4++;
            if (if_no_customer == true)
            {
                StatusObject.count_blank++;
                blank++;
            }
            row += StatusObject.count_blank;
            for (i= 0; i< row-1 ; i++)
            {
                if (count5_store.Count == 0)
                {
                    if (i==row-2)           //it's just for skipping of count5_store[count4-1](一開始佇列是空的，會超值)
                    {
                        customer_store.Add(0);
                        meal_store.Add(0);
                        revenue_store.Add(0);
                    }               
                }
                else if (i == count5_store[count4-1])
                {
                    if (count4 == count5_store.Count)
                    {
                        count5_store.Add(0);//avoiding count5_store[count4-1]超值
                    }

                    if (null_class.Contains(count4) == false)
                    {
                        dtBooks.Rows.RemoveAt(i - 1);
                        dtBooks.Rows.Add(new object[] { count4, order.meal_of_custom.Rows[i - 1].Cells[3].Value, order.meal_of_custom.Rows[i - 1].Cells[4].Value, order.meal_of_custom.Rows[i - 1].Cells[5].Value, customer_store[count4] - customer_store[count4 - 1], meal_store[count4] - meal_store[count4 - 1], revenue_store[count4] - revenue_store[count4 - 1] });
                    }
                    else
                    {
                        dtBooks.Rows.Add(new object[] { count4,null,null,null, 0,0,0});
                        i--;
                    }
                    
                    count4++;
                }

                if (order.meal_of_custom.Rows[i].Cells[3].Value == null||null_class.Contains(count4))
                {
                    null_class.Add(count4);
                    dtBooks.Rows.Add(new object[] { count4, null, null});
                }
                else
                {
                    dtBooks.Rows.Add(new object[] { count4, order.meal_of_custom.Rows[i].Cells[3].Value, order.meal_of_custom.Rows[i].Cells[4].Value, order.meal_of_custom.Rows[i].Cells[5].Value });//取得第i列第3,4,5行的值
                }
                count5++;
            }
            count5_store.Remove(0);
            
            if (!count5_store.Contains(count5) && row != 0&&count5!=0) //避免當重複按下"交班"或"財務報表"時會出問題! **count5!=0:避免第一班沒顧客的時候發生錯誤
            {
                count5_store.Add(count5);
                meal_store.Add(Convert.ToInt32(meal_num));
                customer_store.Add(Convert.ToInt32(customer_num));
                revenue_store.Add(Convert.ToInt32(revenue2));
                if (count5_store.Count > 1) //使每一次交班時的最後一行皆會顯示"該班收益"等資訊
                {
                    //dtBooks.Rows.RemoveAt(i - 1);
                    if (null_class.Count == 0)
                    {
                        dtBooks.Rows.RemoveAt(i - 1);
                        dtBooks.Rows.Add(new object[] { count4, order.meal_of_custom.Rows[i - 1].Cells[3].Value, order.meal_of_custom.Rows[i - 1].Cells[4].Value, order.meal_of_custom.Rows[i - 1].Cells[5].Value, customer_store[count4] - customer_store[count4 - 1], meal_store[count4] - meal_store[count4 - 1], revenue_store[count4] - revenue_store[count4 - 1] });
                    }
                    else
                    {
                        dtBooks.Rows.RemoveAt(i-1);
                    }
                    
                }
            }
            else //當店員不小心重複按了"交班鈕"，往後的所有資料不會受到更動
            {
                if (count5_store.Count > 1) //使每一次交班時的最後一行皆會顯示"該班收益"等資訊
                {
                    if (null_class.Contains(count4) == false)
                    {
                        dtBooks.Rows.RemoveAt(i - 1);
                        dtBooks.Rows.Add(new object[] { count4, order.meal_of_custom.Rows[i - 1].Cells[3].Value, order.meal_of_custom.Rows[i - 1].Cells[4].Value, order.meal_of_custom.Rows[i - 1].Cells[5].Value, customer_store[count4] - customer_store[count4 - 1], meal_store[count4] - meal_store[count4 - 1], revenue_store[count4] - revenue_store[count4 - 1] });
                    }
                    else
                    {
                        dtBooks.Rows.Add(new object[] { count4+1, order.meal_of_custom.Rows[i - 1].Cells[3].Value, order.meal_of_custom.Rows[i - 1].Cells[4].Value, order.meal_of_custom.Rows[i - 1].Cells[5].Value, customer_store[count4] - customer_store[count4 - 1], meal_store[count4] - meal_store[count4 - 1], revenue_store[count4] - revenue_store[count4 - 1] });
                    }

                }
                MessageBox.Show("目前表單無新資訊!");
            }


            //售價說明
            //DataColumn colDescription = new DataColumn("售價說明");
            //colDescription.DataType = System.Type.GetType("System.String");
            //colDescription.Expression = "'商品名稱：' + TRIM(colTitle) + '的售價是NT$' + price";
            //銷售評價
            //DataColumn colAppraisal = new DataColumn("銷售評價");
            //colAppraisal.DataType = System.Type.GetType("System.String");
            //colAppraisal.Expression = "IIF(Quantity > 10,'優良產品!', '再接再厲!')";
            //將計算欄位加入資料表
            //dtBooks.Columns.Add(colDescription);
            //dtBooks.Columns.Add(colAppraisal);
            //建立商品資料表的主索引鍵
            //dtBooks.PrimaryKey = new DataColumn[] { shift };
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }



        private void export_Click(object sender, EventArgs e)
        {
            //dataGridView1[行,列]
            string data = DateTime.Now.ToLongDateString() + "財務報表";
            using (StreamWriter sr = new StreamWriter("C:\\Users\\user\\Desktop\\" + data + ".csv", false, Encoding.Default))
            {
                for(int k = 0; k < dataGridView1.ColumnCount; k++) //印出標題
                {
                    sr.Write(dataGridView1.Columns[k].HeaderText + ",");
                }
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    sr.WriteLine();
                    for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                    {
                        sr.Write(dataGridView1[j, i].Value.ToString()+","); //csv檔以逗號分隔
                    }
                    
                }
            }
            MessageBox.Show("匯出檔案成功!");
                
    
        }
        
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            txtDescription.Text = "商品名稱:" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "販售總價NT$" + dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            int i = e.RowIndex;
            while (true)
            {
                 if (dataGridView1.Rows[i + 1].Cells[0].Value != null)
                 {
                     if (dataGridView1.Rows[i].Cells[0].Value.ToString() != dataGridView1.Rows[i + 1].Cells[0].Value.ToString())
                     {
                            people_num.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                            time_revenue.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
                            out_meal.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
                            break;
                     }
                 }
                 else if (dataGridView1.Rows[i + 1].Cells[0].Value == null)
                 {
                        people_num.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                        time_revenue.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
                        out_meal.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
                        break;
                 }
                 i++;
            }
            
            
        }
    }
}
