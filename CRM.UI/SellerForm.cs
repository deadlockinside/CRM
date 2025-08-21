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

        public SellerForm(Seller seller) : this() 
        {
            Seller = seller ?? new Seller();
            textBox.Text = seller.Name;
        } 

        private void buttonOK_Click(object sender, System.EventArgs e)
        {
            Seller = Seller ?? new Seller();
            Seller.Name = textBox.Text;
            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
