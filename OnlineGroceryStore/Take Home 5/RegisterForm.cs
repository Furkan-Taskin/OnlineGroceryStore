using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Take_Home_5
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length > 0 && (txtPassword.Text == txtConfirmPassword.Text))
            {
                User user = new User(txtUsername.Text, txtPassword.Text);
                DBUsers.userList.Add(user);

                notify = new NotifyIcon();
                notify.BalloonTipText = "You have successfully registered!";
                notify.BalloonTipTitle = "Registration Successfull";
                notify.Tag = "Online Grocery Store Application";
                notify.Visible = true;
                notify.Icon = SystemIcons.Information;
                notify.BalloonTipIcon = ToolTipIcon.Info;
                notify.ShowBalloonTip(1500);
                this.Close();
                StoreForm stf = new StoreForm(user);
                stf.Show();

            }
            else
            {
                MessageBox.Show("Password is not match or lenght is cannot be empty..!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            //LoginForm loginForm = new LoginForm();
            //loginForm.Show();
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBoxMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
