using CRM.Kernel.Models;
using System.Windows.Forms;

namespace CRM.UI
{
    public partial class SellerForm : Form
    {
        public Seller Seller { get; set; }

        public SellerForm()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, System.EventArgs e)
        {
            Seller = new Seller
            {
                Name = textBox.Text
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
