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
    public partial class Bill2 : Form
    {
        public Bill2()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("Billid", typeof(string));
            dt.Columns.Add("CustID", typeof(string));
            dt.Columns.Add("OrderID", typeof(string));
            dt.Columns.Add("CustName", typeof(string));
            dt.Columns.Add("ProductName", typeof(string));
            dt.Columns.Add("ProductQuantity", typeof(string));
            dt.Columns.Add("ProductPrice", typeof(string));
            dt.Columns.Add("OrderTime", typeof(string));
            dt.Columns.Add("OrderDate", typeof(string));
            dt.Columns.Add("Totalqty", typeof(string));
            dt.Columns.Add("TotalAmount", typeof(string));

            foreach (DataGridViewRow dgv in dataGridView1.Rows)
            {
                dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value, dgv.Cells[6].Value, dgv.Cells[7].Value, dgv.Cells[8].Value, dgv.Cells[9].Value, dgv.Cells[10].Value);
            }

            ds.Tables.Add(dt);
            ds.WriteXmlSchema("C://Users/ashirafzal/source/repos/PizzaPoint/PizzaPoint/Bill/Bill.xml");

            CrystalReport1 cr = new CrystalReport1();
            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;
        }

        public void report()
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
                        string query = "select Billid,CustID,CustName,OrderDate,OrderID,OrderTime,ProductName,ProductPrice,ProductQuantity,TotalAmount,Totalqty from Bill where OrderID  = '" + orderID + "' ";
                        billDetailsBindingSource.DataSource = db.Query<OrdersDetails>(query, commandType: CommandType.Text);
                    }
                }
            }
        }

        private void Bill2_Load(object sender, EventArgs e)
        {
            dgv_CashierRegister();
        }

        private void Detail_Click(object sender, EventArgs e)
        {
            report();
        }

        public void dgv_CashierRegister()
        {
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            //This Part of Code is for the styling of the Grid Padding
            Padding newPadding = new Padding(10, 8, 0, 8);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Padding = newPadding;

            // For Changing Grid Color
            this.dataGridView1.GridColor = Color.Maroon;

            //This Part of Code is for the styling of the Grid Columns
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Maroon;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10.5F, FontStyle.Regular);

            //This Part of Code is for the styling of the Visaul Style
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.DefaultCellStyle.Padding = new Padding(8, 1, 0, 1);
            dataGridView1.RowTemplate.Height = 30;


            // This Part of Code is for the styling of the Grid Border
            this.dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;


            //This Part of Code is for the styling of the Grid RowsHeader which is on the left side
            this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Black;

            //This Part of Code is for the styling of the Grid Rows
            dataGridView1.RowsDefaultCellStyle.Font = new Font("Arial", 10.2F, FontStyle.Regular);
            dataGridView1.RowsDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.Black;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Maroon;

        }
    }
}
