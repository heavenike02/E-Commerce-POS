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
   
    public partial class ResetPasswordForm : Form
    { 
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        UserAccount account;
        public ResetPasswordForm(UserAccount acc)
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.myConnection());
            account = acc;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (NewPasswordTextBox.Text != ConfirmPassword.Text)
            {
                MessageBox.Show("Password did not match, please try again ! ", "User Wizard", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else
            {
                if (MessageBox.Show("Change Password? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    conn.Open();
                    cmd = new SqlCommand("UPDATE tbUsersettings set password = '" + NewPasswordTextBox.Text + "' WHERE username = '" +account.username + "'", conn);
                    cmd.ExecuteNonQuery(); 
                    conn.Close();
                    MessageBox.Show("Password has been successfully reset", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();


                }
            }
        }

        private void CancelButton2_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }
    }
}
