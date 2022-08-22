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
    public partial class ChangePasswordForm : Form
    {
    SqlConnection conn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    DBConnect dbcon = new DBConnect();
    SqlDataReader dr;
        CashierForm cashier;
        public ChangePasswordForm(CashierForm cash)
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.myConnection());

            cashier = cash;
            UsernameLabel.Text = cashier.UserNameLabel.Text;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            try
            {
                string oldpass = getPassword(UsernameLabel.Text);
                if (oldpass != PasswordTextBox.Text)
                {
                    MessageBox.Show("Wrong password, please try again ! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    PasswordTextBox.Visible = false;
                    NextButton.Visible = false;


                    NewPasswordTextBox.Visible = true;
                    ConfirmPassword.Visible=true;
                    ConfirmButton.Visible=true; 

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                
            }
        }

        private void ExitPictureBox_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(NewPasswordTextBox.Text != ConfirmPassword.Text)
                {
                    MessageBox.Show("Password did not match, please try again ! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
                else
                {
                    if (MessageBox.Show("Change Password? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                    {
                       
                        conn.Open();
                        cmd = new SqlCommand("UPDATE tbUsersettings set password = '" + NewPasswordTextBox.Text + "' WHERE username = '" + UsernameLabel.Text + "'", conn);
                        cmd.ExecuteNonQuery(); ;
                        conn.Close();
                        NewPasswordTextBox.Clear();
                        ConfirmPassword.Clear();
                           

                    }
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        public String getPassword(string username)
        {
            
            string password = "";
           cmd = new SqlCommand("SELECT password FROM tbUsersettings where username = '" + username + "'", conn);
            conn.Open();
           
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                password = dr["password"].ToString();
            }
            
            dr.Close();
            conn.Close();

            return password;

        }
    }
}
