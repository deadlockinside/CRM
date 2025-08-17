using CRM.Kernel.Models;
using System;
using System.Windows.Forms;

namespace CRM.UI
{
    public partial class Main : Form
    {
        private Context _db;

        public Main()
        {
            InitializeComponent();
            _db = new Context();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e) => ShowCatalog(new Catalog<Product>(_db.Products));

        private void sellerToolStripMenuItem_Click(object sender, EventArgs e) => ShowCatalog(new Catalog<Seller>(_db.Sellers));

        private void customerToolStripMenuItem_Click(object sender, EventArgs e) => ShowCatalog(new Catalog<Customer>(_db.Customers));

        private void receiptToolStripMenuItem_Click(object sender, EventArgs e) => ShowCatalog(new Catalog<Receipt>(_db.Receipts));

        private void ShowCatalog<T>(Catalog<T> catalog) where T : class
        {
            var form = catalog;
            form.Show();
        }

        private void customerAddToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var form = new CustomerForm();

            if (form.ShowDialog() == DialogResult.OK) 
            {
                _db.Customers.Add(form.Customer);
                _db.SaveChanges();
            }
        }
    }
}
