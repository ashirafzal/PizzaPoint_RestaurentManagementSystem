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
    public partial class Inventory : Form
    {
        public Inventory()
        {    
            InitializeComponent();     
            btnInventory.Visible = false;
            txtBarcode.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pizzaPointDataSet1.RawMaterial' table. You can move, or remove it, as needed.
            this.rawMaterialTableAdapter1.Fill(this.pizzaPointDataSet1.RawMaterial);
            dgv_CashierRegister();
        }

        private void label6_Click(object sender, EventArgs e)
        {

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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int b, c;
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=PizzaPoint;Integrated Security=True");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                b = Convert.ToInt32(txtMaterialPrice.Text);
                c = Convert.ToInt32(txtMaterialQuantitty.Text);
                cmd.CommandText = "insert into RawMaterial values ('" + txtMaterialName.Text + "','" + txtBarcode.Text + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToLocalTime() + "','" + txtMaterialType.Text + "','" + b + "','" + c + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Material Record Saved Successfully");
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill all required fields");
            }
        }

        private void btnViewInventory_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;


            if (panel2.Visible == false)
            {
                button2.Visible = false;
                btnViewInventory.Visible = false;
                btnInventory.Visible = true;
            }
            else
            {
                button2.Visible = true;
                btnViewInventory.Visible = true;
                btnInventory.Visible = false;
            }
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            //InitializeComponent();
            panel2.Visible = true;
            btnInventory.Visible = false;
            button2.Visible = true;
            btnViewInventory.Visible = true;
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}