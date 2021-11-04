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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            DBProducts db = new DBProducts();
        }
              
        private void pictureBoxMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool flag = false;
            
            foreach (var item in DBUsers.userList)
            {
                if ((item.Username == txtUsername.Text) && (item.Password == txtPassword.Text))
                {
                    StoreForm stf = new StoreForm(item);
                    stf.Show();
                    //this.close();
                    flag = true;
                }
            }
            if (flag == false)
            {
                MessageBox.Show("Invalid Username or Password!","User");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            foreach (var item in DBUsers.adminList)
            {
                if ((item.Username == txtUsername.Text) && (item.Password == txtPassword.Text))
                {
                    Form1 form1 = new Form1();
                    form1.Show();
                    
                    flag = true;
                }

            }
            if (flag == false)
            {
                MessageBox.Show("Invalid Username or Password!", "Admin");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();        
            registerForm.Show();
        }
    }
}
