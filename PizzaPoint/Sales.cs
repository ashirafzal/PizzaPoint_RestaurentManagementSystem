using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PizzaPoint
{
    public partial class Sales : Form
    {
        public Sales()
        {
            InitializeComponent();
            fillGrid();
            dgv_CashierRegister();
        }

        private void Sales_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            CashierRegisters cr = new CashierRegisters();
            cr.Show();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public void fillGrid()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=PizzaPoint;Integrated Security=True");
            con.Open();
            SqlCommand command;
            SqlDataAdapter da;
            string selectQuery = "select OrderID,CustID,CustName,Contact,OrderType,OrderCategory,Ordertime,OrderDate from Sales order by OrderID DESC";
            command = new SqlCommand(selectQuery, con);
            da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv1.AllowUserToAddRows = false;
            da.Fill(dt);
            dgv1.DataSource = dt;
            //dgv1.AutoGenerateColumns = false;
            con.Close();
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
            dgv1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Regular);

            //This Part of Code is for the styling of the Visaul Style
            dgv1.EnableHeadersVisualStyles = false;
            dgv1.DefaultCellStyle.Padding = new Padding(8, 1, 0, 1);
            dgv1.RowTemplate.Height = 30;

            // This Part of Code is for the styling of the Grid Border
            this.dgv1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv1.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;


            //This Part of Code is for the styling of the Grid RowsHeader which is on the left side
            this.dgv1.RowHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgv1.RowHeadersDefaultCellStyle.BackColor = Color.Black;

            //This Part of Code is for the styling of the Grid Rows
            dgv1.RowsDefaultCellStyle.Font = new Font("Arial", 9.5F, FontStyle.Regular);
            dgv1.RowsDefaultCellStyle.ForeColor = Color.White;
            dgv1.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgv1.RowsDefaultCellStyle.BackColor = Color.Black;
            dgv1.AlternatingRowsDefaultCellStyle.BackColor = Color.Maroon;

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Sales_FormClosed(object sender, FormClosedEventArgs e)
        {
            CashierRegisters cr = new CashierRegisters();
            cr.Show();
        }
    }
}
