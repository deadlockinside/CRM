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

        public CustomerForm(Customer customer) : this() 
        {
            Customer = customer;
            textBoxName.Text = Customer.Name;
        }

        private void buttonOK_Click(object sender, System.EventArgs e)
        {
            var c = Customer ?? new Customer();
            c.Name = textBoxName.Text;
            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
