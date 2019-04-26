using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using System.Configuration;

namespace PizzaPoint
{
    public partial class CashierRegister : Form
    {
        // For Resizing Of the Form
        private int _lastFormSize;

        //ForData gridViewstyling getter and setters
        public System.Windows.Forms.DataGridViewCellStyle RowHeadersDefaultCellStyle { get; set; }

        //For Padding the getter and setters 
        public new System.Windows.Forms.Padding Padding { get; set; }

        //For Changing Form FontSize a/c to change in size
        public int CUSTOM_CONTENT_HEIGHT { get; private set; }

        //Declaring The Generic Lists for the Items Collection

        List<int> productquantity = new List<int>();
        List<double> productPrice = new List<double>();
        List<string> productname = new List<string>();

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgv1.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 25F, GraphicsUnit.Pixel);
            }
        }

        public void dgv_CashierRegister()
        {
            dgv1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            //This Part of Code is for the styling of the Grid Padding
            Padding newPadding = new Padding(10, 8, 0, 8);
            this.dgv1.ColumnHeadersDefaultCellStyle.Padding = newPadding;

            // For Changing Grid Color
            this.dgv1.GridColor = Color.Maroon;

            //This Part of Code is for the styling of the Grid Columns
            dgv1.ColumnHeadersDefaultCellStyle.BackColor = Color.Maroon;
            dgv1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);

            //This Part of Code is for the styling of the Visaul Style
            dgv1.EnableHeadersVisualStyles = false;

            // This Part of Code is for the styling of the Grid Border
            this.dgv1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv1.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;


            //This Part of Code is for the styling of the Grid RowsHeader which is on the left side
            this.dgv1.RowHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgv1.RowHeadersDefaultCellStyle.BackColor = Color.Black;

            //This Part of Code is for the styling of the Grid Rows
            dgv1.RowsDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Regular);
            dgv1.RowsDefaultCellStyle.ForeColor = Color.White;
            dgv1.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgv1.RowsDefaultCellStyle.BackColor = Color.Black;
            dgv1.AlternatingRowsDefaultCellStyle.BackColor = Color.Maroon;

        }


        // For filling the Datagridview on formload
        public void fillGrid()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=PizzaPoint;Integrated Security=True");
            con.Open();
            SqlCommand command;
            SqlDataAdapter da;
            string selectQuery = "Select ProductName , ProductPrice , ProductImage from Products";
            command = new SqlCommand(selectQuery,con);
            da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv1.RowTemplate.Height = 200;
            dgv1.AllowUserToAddRows = false;
            da.Fill(dt);
            dgv1.DataSource = dt;
            //dgv1.AutoGenerateColumns = false;
            con.Close();
        }

        public CashierRegister()
        {

            InitializeComponent();
            this.MinimumSize = new Size(1300, 850);
            this.Resize += new EventHandler(Form2_Resize);
            _lastFormSize = GetFormArea(this.Size);
        }

        private int GetFormArea(Size size)
        {
            return size.Height * size.Width;
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            float scaleFactor = (float)GetFormArea(control.Size) / (float)_lastFormSize;

            ResizeFont(this.Controls, scaleFactor);

            _lastFormSize = GetFormArea(control.Size);

        }

        private void ResizeFont(Control.ControlCollection coll, float scaleFactor)
        {
            foreach (Control c in coll)
            {
                if (c.HasChildren)
                {
                    ResizeFont(c.Controls, scaleFactor);
                }
                else
                {
                    //if (c.GetType().ToString() == "System.Windows.Form.Label")
                    if (true)
                    {
                        // scale font
                        c.Font = new Font(c.Font.FontFamily.Name, c.Font.Size * scaleFactor);
                    }
                }
            }
        }

        // To get input of the numbers in the Quantity Box This Method willl recieve a value on button Click Event
        void writeExpression(String value)
        {
            String expression = txtQuantity.Text;
            expression = expression + value;

            txtQuantity.Text = expression;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            writeExpression("9");
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            writeExpression("8");
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            writeExpression("7");
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            writeExpression("6");
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            writeExpression("5");
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            writeExpression("4");
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            writeExpression("3");
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            writeExpression("1");
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            writeExpression("2");
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            writeExpression("0");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                String processor;
                processor = txtQuantity.Text;
                processor = processor.Substring(0, processor.Length - 1);
                txtQuantity.Text = processor;
            }
            catch (Exception)
            {
                txtQuantity.Text = "";
            }
        }

        private void HomePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CashierRegister_Load(object sender, EventArgs e)
        {
            fillGrid();
            dgv_CashierRegister();
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv1.Rows[e.RowIndex];

                comboBox1.Text = row.Cells["ProductName"].Value.ToString();
                txtItemPrice.Text = row.Cells["ProductPrice"].Value.ToString();
                txtQuantity.Text = "1";
            }
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            this.Hide();
            Product product = new Product();
            product.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Administrator admin = new Administrator();
            admin.Show();
        }

        private void dgv1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = "";
            txtItemPrice.Text = "";
            txtQuantity.Text = "";
        }

        private void btnEnterData_Click(object sender, EventArgs e)
        {

            try
            {
                int a; double b;
                a = Convert.ToInt16(txtQuantity.Text.ToString());
                b = Convert.ToDouble(txtItemPrice.Text);

                productname.Add(comboBox1.Text);
                productquantity.Add(a);
                productPrice.Add(b);

                if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(txtQuantity.Text) || string.IsNullOrEmpty(txtItemPrice.Text))
 
                return;
                ListViewItem item = new ListViewItem(comboBox1.Text);
                item.SubItems.Add(txtQuantity.Text);
                item.SubItems.Add(txtItemPrice.Text);
                listView1.Items.Add(item);
                //comboBox1.Items.Clear();
                //comboBox1.Focus();

                qtyResult.Text = (productquantity.Sum(x => x)).ToString();
                MainTotalResult.Text = (productPrice.Sum(x => x)).ToString();
            }
            catch (Exception)
            {

                if (txtQuantity.TextLength < 0 || txtItemPrice.TextLength < 0 || string.IsNullOrEmpty(comboBox1.Text))
                {
                    MessageBox.Show("Fields can't be Empty");
                }

                else if (string.IsNullOrEmpty(comboBox1.Text))
                {
                    MessageBox.Show("Choose item name");
                }

                else if (txtQuantity.Text.Length == 0)
                {
                    //a = 1;
                    MessageBox.Show("Quantity cant be Zero");
                }

                else if (txtItemPrice.Text.Length == 0)
                {
                    MessageBox.Show("Enter price for item");
                }

            }
           

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.Items.Count > 0)
                {

                    /* int quantity2 = Int32.Parse(listView1.SelectedItems[0].SubItems[1].Text);
                     double price2 = double.Parse(listView1.SelectedItems[0].SubItems[2].Text.ToString()); ;

                     //comboBox1.Text = "";
                     txtQuantity.Text = quantity2.ToString();
                     txtItemPrice.Text = price2.ToString();*/

                    listView1.Items.Remove(listView1.SelectedItems[0]);
                   
                    /* int a; double b;
                     a = Convert.ToInt16(txtQuantity.Text.ToString());
                     b = Convert.ToDouble(txtItemPrice.Text);*/

                    decimal newqty = 0;
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        newqty += decimal.Parse(listView1.Items[i].SubItems[1].Text);
                    }

                    decimal newTotal = 0;
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        newTotal += decimal.Parse(listView1.Items[i].SubItems[2].Text);
                    }


                    //qtyResult.Text = (productquantity.Sum(x => x)- a).ToString();
                    //MainTotalResult.Text = (productPrice.Sum(x => x) - b).ToString();
                    qtyResult.Text = newqty.ToString();
                    MainTotalResult.Text = newTotal.ToString();
                }
                else
                {
                    listView1.Items.Clear();
                }
            }
            catch (Exception)
            {

            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            txtItemPrice.Text = "";
            txtQuantity.Text = "";
            listView1.Items.Clear();
            MainTotalResult.Text = "0";
            qtyResult.Text = "0";
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            string Custname = "Valuable Customer";
            string CustContact = "***********";

            string CUSTID,ORDERID,CUSTNAME,ORDERTIME,ORDERDATE,CUSTCONTACT;
            string OrderType = "Food Item";
            string OrderCategory = "Food";

            /* Connection String me Integrated Security=True; ko Integrated Security=SSPI; se change karna hoga
             or phir MultipleActiveResultSets = True connection string me add karna hoga takai Sql Reader ke while
             condition me aik se sql queries ki queires ko implement kara jasakai*/

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=PizzaPoint;Integrated Security=SSPI;MultipleActiveResultSets = True");
            con.Open();
            SqlTransaction tran = con.BeginTransaction();
            try
            { 

                SqlCommand cmd1 = new SqlCommand("insert into Customer values ('" + Custname + "','" + CustContact + "','" + DateTime.Now.ToShortTimeString() + "','" + DateTime.Now.Date + "')", con, tran);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("select top 1 CustID from Customer order by CustID DESC", con, tran);
                cmd2.ExecuteNonQuery();

                using (SqlDataReader dr = cmd2.ExecuteReader())
                {
                    while (dr.Read())
                    {    
                        CUSTID = dr["CustID"].ToString();
                        SqlCommand cmd3 = new SqlCommand("insert into Orders values ('" + CUSTID + "','" + OrderType.ToString() + "','" + OrderCategory.ToString() + "','" + DateTime.Now.ToShortTimeString() + "','" + DateTime.Now.Date + "')", con, tran);
                        cmd3.ExecuteNonQuery();
                    }                   
                }

                SqlCommand cmd4 = new SqlCommand("select top 1 CustID,CustName,Contact from Customer order by CustID DESC", con, tran);
                cmd4.ExecuteNonQuery();
                SqlCommand cmd5 = new SqlCommand("select top 1 OrderID,OrderTime,OrderDate from Orders order by OrderID DESC", con, tran);
                cmd5.ExecuteNonQuery();

                using (SqlDataReader dr = cmd4.ExecuteReader())
                {
                    using (SqlDataReader dr1 = cmd5.ExecuteReader())
                    {
                        string itemname;
                        string itemqty;
                        string itemprice;
                        string billtotal = MainTotalResult.Text;
                        string totalqty = qtyResult.Text;

                        while (dr.Read())
                        {
                            CUSTID = dr["CustID"].ToString();
                            CUSTNAME = dr["CustName"].ToString();
                            CUSTCONTACT = dr["Contact"].ToString();
                            while (dr1.Read())
                            {
                                //ORDERID = dr1.GetSqlValue(0).ToString();
                                ORDERID = dr1["OrderID"].ToString();
                                ORDERTIME = dr1["OrderTime"].ToString();
                                ORDERDATE = dr1["OrderDate"].ToString();
                              
                                //
                                SqlCommand cmd7 = new SqlCommand("insert into Sales values ('" + ORDERID + "','" + CUSTID + "','" + CUSTNAME + "','" + CUSTCONTACT + "','" + OrderType + "','" + OrderCategory + "','" + ORDERTIME + "','" + ORDERDATE + "')", con, tran);
                                cmd7.ExecuteNonQuery();

                                SqlCommand cmd6;
                                for (int i = 0; i < listView1.Items.Count; i++)
                                {
                                    itemname = Convert.ToString(listView1.Items[i].SubItems[0].Text).ToString();
                                    itemqty = Convert.ToString(listView1.Items[i].SubItems[1].Text);
                                    itemprice = Convert.ToString(listView1.Items[i].SubItems[2].Text);

                                    //MessageBox.Show(""+itemname+""+itemprice+""+itemqty);
                                    comboBox1.Text = itemname;
                                    txtQuantity.Text = itemqty;
                                    txtItemPrice.Text = itemprice;
                                    cmd6 = new SqlCommand("insert into Bill values ('" + CUSTID + "','" + ORDERID + "','" + CUSTNAME + "','" + comboBox1.Text + "','" + txtQuantity.Text + "','" + txtItemPrice.Text + "','" + ORDERTIME + "','" + ORDERDATE + "','" + totalqty.ToString() + "','" + billtotal.ToString() + "')", con, tran);
                                    //cmd6 = new SqlCommand("insert into Bill values ('" + CUSTID + "','" + ORDERID + "','" + CUSTNAME + "','" + ProductName + "','" + productquantity + "','" + productPrice + "','" + ORDERTIME + "','" + ORDERDATE + "','" + totalqty + "','" + billtotal  + "')", con, tran);
                                    cmd6.ExecuteNonQuery();

                                }

                                BillForm b = new BillForm();
                                b.Show();

                                //MessageBox.Show("Operation Successfull");
                            }
                        }
                    }
                
                    tran.Commit();
                }
            }
            catch (SqlException)
            {
                tran.Rollback();
                MessageBox.Show("Operation Unsuccessfull");
            }

        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            this.Hide();
            order.Show();
        }

        private void btnPrices_Click(object sender, EventArgs e)
        {
            Prices prices = new Prices();
            this.Hide();
            prices.Show();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            Sales sales = new Sales();
            this.Hide();
            sales.Show();
        }

        private void ClockOut_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();
            inventory.Show();
        }
    }
}
