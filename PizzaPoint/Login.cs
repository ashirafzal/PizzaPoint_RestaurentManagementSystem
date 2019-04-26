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
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(300);
            t.Abort();
            InitializeComponent();
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
            try
            {
                int a = Convert.ToInt16(txtLoginID.Text);
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=PizzaPoint;Integrated Security=True");
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT AdminLoginID,AdminPass from Admin where AdminLoginID = '" + a + "' and AdminPass = '" + txtPass.Text + "'", con);
                DataTable table = new DataTable();
                DataTable table2 = new DataTable();
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    MessageBox.Show("Welcome Admin");
                    CashierRegister cr = new CashierRegister();
                    this.Hide();
                    cr.Show();
                }
                else
                {
                    SqlDataAdapter adapter2 = new SqlDataAdapter("SELECT empLoginID,empLoginPass from Employee where empLoginID = '" + a + "' and empLoginPass = '" + txtPass.Text + "'", con);
                    adapter2.Fill(table2);
                    MessageBox.Show("Welcome Employee");
                    CashierRegister cr = new CashierRegister();
                    this.Hide();
                    cr.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Username or Password");
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
