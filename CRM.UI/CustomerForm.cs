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
            Customer = customer ?? new Customer();
            textBoxName.Text = Customer.Name;
        }

        private void buttonOK_Click(object sender, System.EventArgs e)
        {
            Customer = Customer ?? new Customer();
            Customer.Name = textBoxName.Text;
            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
