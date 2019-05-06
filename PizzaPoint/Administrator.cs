﻿using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PizzaPoint
{
    public partial class Administrator : Form
    {
        
        private int _lastFormSize;
        public int CUSTOM_CONTENT_HEIGHT { get; private set; }

        public Administrator()
        {
            InitializeComponent();
            this.MinimumSize = new Size(1300, 850);
            this.Resize += new EventHandler(Form2_Resize);
            _lastFormSize = GetFormArea(this.Size);
        }

        private void Administrator_Load(object sender, EventArgs e)
        {

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

        private void btnCreateEmp_Click(object sender, EventArgs e)
        {
            try
            {
                int b;
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=PizzaPoint;Integrated Security=True");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                b = Convert.ToInt32(empLoginID.Text);
                cmd.CommandText = "insert into Employee values ('" + empName.Text + "','" + b + "','" + empPass.Text + "','" + empPosition.Text + "','" + empEducation.Text + "','" + empNum.Text + "','" + empAddress.Text + "','" + empEmail.Text + "','" + empIdentity.Text + "','" + empDegree.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee Create Successfully");
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill all required fields");
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                int a1;

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=PizzaPoint;Integrated Security=True");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                a1 = Convert.ToInt16(AdminLoginID.Text);
                cmd.CommandText = "insert into Admin (AdminName,AdminPost,AdminEducation,AdminLoginID,AdminPass) values ('" + AdminName.Text + "','" + AdminPost.Text + "','" + AdminEducation.Text + "','" + a1 + "','" + AdminPass.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Admin Created Successfully");
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill all required fields");
            }
        }

        private void AdminLoginID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateEmp_Click(object sender, EventArgs e)
        {
            try
            {
                int b, d, e1;

                b = Convert.ToInt32(empLoginID.Text);
                //d = Convert.ToInt32(empNum.Text);
                //e1 = Convert.ToInt32(empIdentity.Text);

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=PizzaPoint;Integrated Security=True");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Employee set EmpName = '" + empName.Text + "', EmpPass = '" + empPass.Text + "', EmpPosition = '" + empPosition.Text + "', EmpEducation = '" + empEducation.Text + "', EmpPhone = '" + empNum.Text + "', EmpAddress = '" + empAddress.Text + "', EmpEmail = '" + empEmail.Text + "', EmpCNIC = '" + empIdentity.Text + "', EmpDegree = '" + empDegree.Text + "' where EmpLogin = '" + b + "'  ";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Employee Record updated Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill all required fields");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=PizzaPoint;Integrated Security=True");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                int a1 = Convert.ToInt16(AdminLoginID.Text);
                cmd.CommandText = "update Admin set AdminName = '" + AdminName.Text + "' , AdminPost = '" + AdminPost.Text + "', AdminEducation = '" + AdminEducation.Text + "', AdminPass = '" + AdminPass.Text + "' where AdminLoginID = '" + a1 + "'  ";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Admin Record updated Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill all required fields");
            }
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=PizzaPoint;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            int a1 = Convert.ToInt16(AdminLoginID.Text);
            cmd.CommandText = "delete from Admin where AdminLoginID ='" + a1 + "'";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Admin Deleted Successfully");
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminRecord adminRecord = new AdminRecord();
            adminRecord.Show();
        }

        private void btnViewEmp_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeRecord employee = new EmployeeRecord();
            employee.Show();
        }

        private void btnDeleteEmp_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=PizzaPoint;Integrated Security=True");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                int a1 = Convert.ToInt16(empLoginID.Text);
                cmd.CommandText = "delete from Employee where EmpID ='" + a1 + "'";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Employee Deleted Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Employee Id is must to Delete Employee Record"+"Please Provide Employee ID for further Operations");
            }
          
        }

        private void Administrator_FormClosed(object sender, FormClosedEventArgs e)
        {
            CashierRegister cr = new CashierRegister();
            this.Hide();
            cr.Show();
        }
    }
}
