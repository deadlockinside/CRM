using CRM.Kernel.Models;
using System;
using System.Windows.Forms;

namespace CRM.UI
{
    public partial class ProductForm : Form
    {
        public Product Product { get; set; }

        public ProductForm()
        {
            InitializeComponent();
        }

        public ProductForm(Product product) : this()
        {
            Product = product ?? new Product();
            textBoxName.Text = product.Name;
            numericUpDownPrice.Value = product.Price;
            numericUpDownCount.Value = product.Count;
        }

        private void buttonOK_Click(object sender, System.EventArgs e)
        {
            Product = Product ?? new Product();
            Product.Name = textBoxName.Text;
            Product.Price = numericUpDownPrice.Value;
            Product.Count = Convert.ToInt32(numericUpDownCount.Value);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
