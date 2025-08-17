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

        private void buttonOK_Click(object sender, System.EventArgs e)
        {
            Product = new Product 
            {
                Name = textBoxName.Text,
                Price = numericUpDownPrice.Value,
                Count = (int)numericUpDownCount.Value
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
