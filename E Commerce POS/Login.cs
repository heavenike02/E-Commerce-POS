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


namespace E_Commerce_POS
{
    public partial class Login : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public string _pass = "";
        public bool _isactive;
        public Login()
        {
            conn = new SqlConnection(dbcon.myConnection());
            InitializeComponent();
            UsernameTextBox.Focus();
        }

        private void ExitPictureBox_Click(object sender, EventArgs e)
        {
          
            if (MessageBox.Show("Exit Application ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }


        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string _username = "", _name = "", _role = "";
            try
            {
                bool found;
                conn.Open();
                cmd = new SqlCommand("Select * From tbUsersettings where username = @username and password = @password", conn);
                cmd.Parameters.AddWithValue("@username",UsernameTextBox.Text);
                cmd.Parameters.AddWithValue("@password", PasswordTextBox.Text);
                dr = cmd.ExecuteReader();
                dr.Read();
                    if (dr.HasRows)
                    {
                        found = true;
                        _username = dr["username"].ToString();
                        _name = dr["name"].ToString();
                        _role = dr["role"].ToString();
                        _pass = dr["password"].ToString();
                        _isactive = bool.Parse(dr["isactive"].ToString());
                    }
                    else
                    {
                        found = false;
                    }
                    dr.Close();
                    conn.Close();

                                if (found == true)
                                {
                   
                                    if (!_isactive) 
                                    {
                                        MessageBox.Show("Account is inactive Unable to login ", "Inactive Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }

                                    if (_role == "Sales Personel")
                                    {
                                        MessageBox.Show("Welcome " + _name + "", " ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        UsernameTextBox.Clear();
                                        PasswordTextBox.Clear();
                                        this.Hide();
                                        CashierForm cashierform = new CashierForm();
                                        cashierform.UserNameLabel.Text = _username;
                                        cashierform.NameLabel.Text = _name;
                                        cashierform.RoleLabel.Text = _role;
                                        cashierform.ShowDialog();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Welcome " + _name , " ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        UsernameTextBox.Clear();
                                        PasswordTextBox.Clear();
                                        this.Hide();
                                        MainForm main = new MainForm();
                                        main.UsernameLabel.Text = _username;
                                        main._pass = _pass;
                                        main.ShowDialog();      
                       

                                    }
                   
                                }

                                 if (found != true)
                                {
                                    MessageBox.Show("invalid username and password!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    UsernameTextBox.Clear();
                                    UsernameTextBox.Focus();
                                    PasswordTextBox.Clear();

                                }
            }
            catch (Exception ex)

            {
                conn.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

       
       
    }
}
