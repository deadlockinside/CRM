using CRM.Kernel.Models;
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
            Product = product;
            textBoxName.Text = product.Name;
            numericUpDownPrice.Value = product.Price;
            numericUpDownCount.Value = product.Count;
        }

        private void buttonOK_Click(object sender, System.EventArgs e)
        {
            var p = Product ?? new Product();
            p.Name = textBoxName.Text;
            p.Price = numericUpDownPrice.Value;
            p.Count = (int)numericUpDownCount.Value;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
