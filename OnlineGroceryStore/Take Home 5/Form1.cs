using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Take_Home_5
{
    public partial class Form1 : Form
    {
        
        Image i;
        Bitmap b;
        void cleartextboxes()
        {
            txtName.Text = "";
            txtPrice.Text = "";
            txtDescription.Text = "";
            txtFileName.Text = "";
            txtName.Focus();
            pictureBox1.Image = Image.FromFile((Path.Combine(Environment.CurrentDirectory, @"Images\", "NoImage.png")).ToString());
        }
        public Form1()
        {
            InitializeComponent();
            
            foreach (var item in DBProducts.products)
            {
                lstBxProducts.Items.Add(item);
            }
            cleartextboxes();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ProductClass selectedProduct;
                selectedProduct = new ProductClass();
                selectedProduct = (ProductClass)lstBxProducts.SelectedItem;
                if (selectedProduct != null)
                {
                    txtName.Text = selectedProduct.name;
                    txtPrice.Text = selectedProduct.price.ToString();
                    txtDescription.Text = selectedProduct.description;
                    txtFileName.Text = selectedProduct.fileName;

                    Image i;
                    Bitmap b;

                    OpenFileDialog odf = new OpenFileDialog();
                    odf.FileName = Path.Combine(Environment.CurrentDirectory, @"Images\", selectedProduct.fileName);
                    i = Image.FromFile(odf.FileName);
                    b = (Bitmap)i;
                    pictureBox1.Image = b;
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult re = ofd.ShowDialog();
            if (re == DialogResult.OK)
            {
                i = Image.FromFile(ofd.FileName);
                b = (Bitmap)i;
                pictureBox1.Image = b;
            }

            string filename1 = ofd.FileName;
            string str = Path.Combine(Environment.CurrentDirectory, @"Images\", txtFileName.Text);

            try
            {
                File.Copy(filename1, str, true);
                ProductClass p1 = new ProductClass(txtName.Text, Convert.ToDouble(txtPrice.Text), txtDescription.Text, txtFileName.Text);
                lstBxProducts.Items.Add(p1);
                DBProducts.products.Add(p1);
            }
            catch (Exception)
            {
            }
         
            cleartextboxes();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstBxProducts.Items.Count > 0)
            {
                DialogResult dg = new DialogResult();
                dg = MessageBox.Show("Are you sure to delete this product? ", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dg == DialogResult.Yes)
                {
                    DBProducts.products.RemoveAt(lstBxProducts.SelectedIndex);
                    lstBxProducts.Items.Remove(lstBxProducts.SelectedItem);
                   // Application.OpenForms["StoreForm"].Controls["flpProduct"].Controls.Clear();
                  //  DBProducts.i = 0;
                }
            }
            else
            {
                MessageBox.Show("There is not item to delete..!", "Error");
            }
            cleartextboxes();

        }

        static public bool isClicked = false;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult re = ofd.ShowDialog();
            if (re == DialogResult.OK)
            {
                i = Image.FromFile(ofd.FileName);
                b = (Bitmap)i;
                pictureBox1.Image = b;
            }

            string filename1 = ofd.FileName;
            string str = Path.Combine(Environment.CurrentDirectory, @"Images\", txtFileName.Text);

            try
            {
                File.Copy(filename1, str, true);
                
                ProductClass temp = new ProductClass(txtName.Text, Convert.ToDouble(txtPrice.Text), txtDescription.Text, txtFileName.Text);
                lstBxProducts.Items[lstBxProducts.SelectedIndex] = temp;
                DBProducts.products[lstBxProducts.SelectedIndex] = temp;
                Application.OpenForms["StoreForm"].Controls["flpProduct"].Controls.Clear();
                DBProducts.i = 0;
                isClicked = true;
            }
            catch (Exception)
            {
            }
           
        }
        static public bool isClear = false;
        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult dg = new DialogResult();
            dg = MessageBox.Show("Are you sure to clear all products? ", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(dg == DialogResult.Yes)
            {
                lstBxProducts.Items.Clear();
                DBProducts.products.Clear();
                isClear = true;
                DBProducts.i = 0;
                cleartextboxes();
            }
           
        }
        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
