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
    public partial class ProductPopUp : Form
    {
        ProductClass selectedProduct;
        public ProductPopUp(ProductClass product)
        {
            InitializeComponent();
            selectedProduct = product;
            Image ifoto;
            Bitmap bfoto;
            string str = Path.Combine(Environment.CurrentDirectory, @"Images\", product.fileName);
            ifoto = Image.FromFile(str);
            bfoto = (Bitmap)ifoto;
            
            lblProductName.Text = product.name;
            lblProductPrice.Text = product.price.ToString();
            lblProductdes.Text = product.description;
            pctProducts.Image = bfoto;
            pctProducts.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInc_Click(object sender, EventArgs e)
        {
            int counter = Convert.ToInt32(txtcounter.Text);
            counter++;
            txtcounter.Text = counter.ToString();
        }

        private void btnDec_Click(object sender, EventArgs e)
        {
            int counter = Convert.ToInt32(txtcounter.Text);
            
            counter--;
            if (counter < 1) counter = 1;
            txtcounter.Text = counter.ToString();
        }
        static public int count = 0;
        private void lbl14_Click(object sender, EventArgs e)
        {
            try
            {
                Label label = new Label();
                label = (Label)sender;
                
                totalPrice -= selectedProduct.price * Convert.ToInt32(txtcounter.Text);

                if (totalPrice < 0 || totalPrice > Int16.MaxValue)
                {
                    totalPrice = 0;
                }
                //Application.OpenForms["StoreForm"].Controls["flpShoppingCart"].Controls.RemoveAt(Convert.ToInt32(label.Name)); ;
                
                Application.OpenForms["StoreForm"].Controls["flpShoppingCart"].Controls.Remove((Label) sender); ;
                Application.OpenForms["StoreForm"].Controls["lblTotalPrice"].Text = String.Format("{0:0.00}", totalPrice);


            }
            catch (Exception)
            {

            }
           
        }

        static public double totalPrice = 0;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Label label13 = new Label();
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label13.ForeColor = System.Drawing.Color.White;
            label13.Location = new System.Drawing.Point(12, 89);
            label13.Name = (count).ToString();
            label13.Size = new System.Drawing.Size(163, 23);
            label13.TabIndex = 23;
            label13.Click += lbl14_Click;
            label13.Text = "---> "+txtcounter.Text +" x " + selectedProduct.name + " $" + selectedProduct.price.ToString() + "                          ";
            count++;
            totalPrice += selectedProduct.price * Convert.ToInt32(txtcounter.Text);
            Application.OpenForms["StoreForm"].Controls["flpShoppingCart"].Controls.Add(label13);

            this.Close();
            Application.OpenForms["StoreForm"].Controls["lblTotalPrice"].Text = totalPrice.ToString(); ;
        }
    }
}
