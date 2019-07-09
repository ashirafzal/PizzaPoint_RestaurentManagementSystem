using System;
using System.Threading;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace PizzaPoint
{
    public partial class Login : Form
    {
        public Login()
        {
            //Thread t = new Thread(new ThreadStart(StartForm));
            //t.Start();
            //Thread.Sleep(300);
            InitializeComponent();
            //t.Abort();
        }

        public void StartForm()
        {
            Application.Run(new SplashScreen());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=PizzaPoint;Integrated Security=True");
            con.Open();
            try
            {
                if (txtLoginID.Text == "user" || txtPass.Text == "pass")
                {
                    CashierRegisters cr = new CashierRegisters();
                    this.Hide();
                    cr.Show();
                }
                else if (txtLoginID.Text == string.Empty || txtPass.Text == string.Empty)
                {
                    MessageBox.Show("Please Enter Username and Password");
                }
                else
                {
                    int a = Convert.ToInt16(txtLoginID.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT UserLoginID,UserPass from Users where UserLoginID = '" + a + "' and UserPass = '" + txtPass.Text + "'", con);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        CashierRegisters cr = new CashierRegisters();
                        this.Hide();
                        cr.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Please enter ID in numeric form or use the default username and password for login",
                    "User Mishandling",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            con.Close();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
