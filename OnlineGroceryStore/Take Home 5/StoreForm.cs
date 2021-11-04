using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Take_Home_5
{
    public partial class StoreForm : Form
    {
        public StoreForm(User user)
        {
            InitializeComponent();

            timer1.Start();
            DBProducts.i = 0;
            lblInfo.Text ="Welcome, " + user.Username;
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBoxMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void pb1_Click(object sender, EventArgs e)
        {
            PictureBox pc = new PictureBox();
            pc = (PictureBox)sender;

            ProductClass prd = DBProducts.products[Convert.ToInt32(pc.Name)];
            ProductPopUp productPopUp = new ProductPopUp(prd);
            productPopUp.ShowDialog();

            
        }
        int oldCount = DBProducts.products.Count;
        bool flag = true;      
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (flag && DBProducts.products.Count > 0)
            {
                Image ifoto;
                Bitmap bfoto;
                string str = Path.Combine(Environment.CurrentDirectory, @"Images\", DBProducts.products[DBProducts.i].fileName);
                ifoto = Image.FromFile(str);
                bfoto = (Bitmap)ifoto;
                PictureBox pb1 = new PictureBox();
                pb1.Name = DBProducts.i.ToString();
                pb1.Size = new System.Drawing.Size(150, 200);
                pb1.SizeMode = PictureBoxSizeMode.StretchImage;
                pb1.Click += pb1_Click;
                pb1.Image = bfoto;
                flpProduct.Controls.Add(pb1);
                Label labl = new Label();
                labl.Text = DBProducts.products[DBProducts.i].name;
                labl.Font = new System.Drawing.Font("Georgia", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                labl.Size = new Size(250,200);
                labl.Location = new Point(x: 200, y: 200);
                flpProduct.Controls.Add(labl);
                DBProducts.i++;
                Form1.isClicked = false;
                Form1.isClear = false;
                
            }
            if (oldCount != DBProducts.products.Count)
            {
                flag = true;
            }
            if (DBProducts.i == DBProducts.products.Count)
            {
                flag = false;
                oldCount = DBProducts.products.Count;
            }
            if (Form1.isClicked == true) 
            {
                flag = true;
                oldCount = DBProducts.products.Count;
                DBProducts.i = 0;
            }
            if(Form1.isClear == true)
            {
                flpProduct.Controls.Clear();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dg = new DialogResult();

            dg = MessageBox.Show("Your total price is: $" + lblTotalPrice.Text + ". Do you confirm?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dg == DialogResult.Yes)
            {
                notify = new NotifyIcon();
                notify.BalloonTipText = "Your shopping is completed.";
                notify.BalloonTipTitle = "Shopping Successful";
                notify.Tag = "Online Grocery Store Application";
                notify.Visible = true;
                notify.Icon = SystemIcons.Information;
                notify.BalloonTipIcon = ToolTipIcon.Info;
                notify.ShowBalloonTip(1500);
                flpShoppingCart.Controls.Clear();
                lblTotalPrice.Text = "0";

                ProductPopUp.totalPrice = 0;
                ProductPopUp.count = 1;
            }
        }
      
    }
}
