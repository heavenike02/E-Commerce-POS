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
    public partial class UserAccount : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        MainForm main;
        public string username;
        string name;
        string role;
        string accountstatus;

        public UserAccount(MainForm mn)
        {
            conn = new SqlConnection(dbcon.myConnection());
            InitializeComponent();
            main = mn;
            LoadUserAccounts();
        }
         public void LoadUserAccounts()
        {
            try
            {
                int i = 1 ;
                DGVUser.Rows.Clear();
                
                cmd = new SqlCommand("SELECT * FROM tbUsersettings",  conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    
                    DGVUser.Rows.Add(i, dr[0].ToString(), dr[3].ToString(), dr[4].ToString(), dr[2].ToString());
                    i++;
                }
                dr.Close();
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }


        private void UserAccount_Load(object sender, EventArgs e)
        {
            UsernameLabel.Text =  main.UsernameLabel.Text;
            DGVUser.CurrentCell = null;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (PasswordTextbox.Text != ReTypePasswordTextBox.Text)
                {
                    MessageBox.Show(" Password did not Match .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to Create  this Account?", "Create Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("Insert into tbUsersettings(username,password,role,name)Values (@username,@password,@role,@name)", conn);
                    cmd.Parameters.AddWithValue("@username", UserNameTextbox.Text);
                    cmd.Parameters.AddWithValue("@password", PasswordTextbox.Text);
                    cmd.Parameters.AddWithValue("@role", RoleComboBox.Text);
                    cmd.Parameters.AddWithValue("@name", FullNameTextBox.Text);
                    cmd.ExecuteNonQuery(); 
                    conn.Close();
                    MessageBox.Show(" New Account has been sucessfully saved.", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "warning");
            }
        }

        public void Clear()
        {
            PasswordTextbox.Clear();
            FullNameTextBox.Clear();
            RoleComboBox.Text = "";
            UserNameTextbox.Clear();
            ReTypePasswordTextBox.Clear();
        }

        private void SaveButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentPasswordTextBox.Text != main._pass)
                {
                    MessageBox.Show("Current Password did not match!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (NewPasswordTextBox.Text != RETypePasswordTexBox.Text)
                {
                    MessageBox.Show("Confim New Password did not match!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                conn.Open();
                cmd = new SqlCommand("Update  tbUsersettings SET Password = '" +NewPasswordTextBox.Text+ "'Where username = '"+UsernameLabel.Text+"'", conn);
                cmd.ExecuteNonQuery(); ;
                conn.Close();
                MessageBox.Show("Password has been suceessfully changed!", "Changed Password", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void CancelButton2_Click(object sender, EventArgs e)
        {

        }
        public void ClearCP()
        {
            CurrentPasswordTextBox.Clear();
            NewPasswordTextBox.Clear();
            RETypePasswordTexBox.Clear();
        }

            private void DGVUser_SelectionChanged(object sender, EventArgs e)
            {
                int i = DGVUser.CurrentRow.Index;
                username = DGVUser[1, i].Value.ToString();
                name = DGVUser[2, i].Value.ToString();  
            role = DGVUser[4, i].Value.ToString();  
            accountstatus = DGVUser[3, i].Value.ToString();
            if (UsernameLabel.Text == username)
            {
                RemoveButton.Enabled = false;
                ResetPasswordButton.Enabled = false;
                ChangePasswordLabel.Text = "To change your password, go to change password tag";

            }
            else
            {
                RemoveButton.Enabled = true; ;
                ResetPasswordButton.Enabled = true;
                ChangePasswordLabel.Text = "To change the password for " + username + ",Click Reset Password.";

            }

            PasswordForUsernameGroupBox.Text = "Password For " + username;
            
        }

        private void ResetPasswordButton_Click(object sender, EventArgs e)
        {
            ResetPasswordForm reset = new ResetPasswordForm(this);
            reset.ShowDialog();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                    if (MessageBox.Show("You chose to remove this account from this Point of Sales System's user list. \n\n Are you sure you want to remove '" +username+"'\\'" +role+ "'","User Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                   {
                    conn.Open();
                    cmd = new SqlCommand("DELETE FROM tbUsersetings  where username = '" +username+ "'", conn);
            
                    cmd.ExecuteNonQuery(); 
                    conn.Close();
                    MessageBox.Show(" Account has been successfully deleted.", " Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUserAccounts();
                   }
            }
            catch (Exception ex)


            {
                MessageBox.Show(ex.Message, "Error");
            }
           

        }

        private void PropertiesButton_Click(object sender, EventArgs e)
        {
            PropertiesForm properties =  new PropertiesForm(this);
            properties.NameTextbox.Text = name;
            properties.RoleComboBox.Text = role;
            properties.AccountStatusComboBox.Text = accountstatus;
            properties.username = username;
            properties.ShowDialog();    
        }
    }
}    

