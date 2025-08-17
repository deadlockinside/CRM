using CRM.Kernel.Models;
using System.Windows.Forms;

namespace CRM.UI
{
    public partial class CustomerForm : Form
    {
        public Customer Customer { get; set; }

        public CustomerForm()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, System.EventArgs e)
        {
            Customer = new Customer
            {
                Name = textBoxName.Text
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
