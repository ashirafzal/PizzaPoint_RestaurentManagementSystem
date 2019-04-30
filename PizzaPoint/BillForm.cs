using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;


namespace PizzaPoint
{
    public partial class BillForm : Form
    {
        public BillForm()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string orderID; ;

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=PizzaPoint;Integrated Security=SSPI;MultipleActiveResultSets = True");
            con.Open();
            SqlTransaction tran = con.BeginTransaction();

            SqlCommand cmd = new SqlCommand("select top 1 OrderID from Orders order by OrderID DESC", con, tran);
            cmd.ExecuteNonQuery();

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    orderID = dr["OrderID"].ToString();

                    using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                    {
                        if (db.State == ConnectionState.Closed)
                            db.Open();
                        string query = "select CustID,CustName,OrderDate,OrderID,OrderTime,ProductName,ProductPrice,ProductQuantity,TotalAmount,Totalqty from Bill where OrderID  = '" + orderID +"' ";
                        ordersDetailsBindingSource.DataSource = db.Query<OrdersDetails>(query, commandType: CommandType.Text);
                    }
                }
            }
        }

        private void BillForm_Load(object sender, EventArgs e)
        {
            dgv_CashierRegister();
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
            dgv1.RowsDefaultCellStyle.Font = new Font("Arial", 8F, FontStyle.Regular);
            dgv1.RowsDefaultCellStyle.ForeColor = Color.White;
            dgv1.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgv1.RowsDefaultCellStyle.BackColor = Color.Black;
            dgv1.AlternatingRowsDefaultCellStyle.BackColor = Color.Maroon;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            string orderID,orderdate,ordertime;

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=PizzaPoint;Integrated Security=SSPI;MultipleActiveResultSets = True");
            con.Open();
            SqlTransaction tran = con.BeginTransaction();

            SqlCommand cmd = new SqlCommand("select top 1 OrderID,Ordertime,OrderDate from Orders order by OrderID DESC", con, tran);
            cmd.ExecuteNonQuery();

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    orderID = dr["OrderID"].ToString();
                    ordertime = dr["Ordertime"].ToString();
                    orderdate = dr["OrderDate"].ToString();

                    OrdersDetails obj = ordersDetailsBindingSource.Current as OrdersDetails;
                    if (obj != null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                                db.Open();
                            string query = "select top 1 CustID,CustName,OrderDate,OrderID,OrderTime,ProductName,ProductPrice,ProductQuantity,TotalAmount,Totalqty from Bill order by CustID DESC ";
                            //string query = "select CustID,CustName,OrderDate,OrderID,OrderTime,ProductName,ProductPrice,ProductQuantity,TotalAmount,Totalqty from Bill where Ordertime = '"+ ordertime +"' and orderDate = '" + orderdate +"' ";
                            List<BillDetails> list = db.Query<BillDetails>(query, commandType: CommandType.Text).ToList();
                            //OrderID  = '" + orderID + "' //
                            using (BillPrint frm = new BillPrint(obj, list))
                            {
                                this.Close();
                                frm.ShowDialog();
                            }
                        }
                    }
                }
            }   
        }
    }
}