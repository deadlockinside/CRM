using CRM.Kernel.Models;
using System.Data.Entity;
using System.Windows.Forms;

namespace CRM.UI
{
    public partial class Catalog<T> : Form 
    where T : class
    {
        private Context _db;
        private DbSet<T> _set;

        public Catalog(DbSet<T> set, Context db)
        {
            InitializeComponent();

            _db = db;
            _set = set;
            set.Load();
            dataGridView.DataSource = set.Local.ToBindingList();
        }

        private void buttonEdit_Click(object sender, System.EventArgs e)
        {
            var id = dataGridView.SelectedRows[0].Cells[0].Value;

            if (typeof(T) == typeof(Product))
            {
                var product = _set.Find(id) as Product;

                if (product != null)
                {
                    var form = new ProductForm(product);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        product = form.Product;
                        _db.SaveChanges();
                        dataGridView.Update();
                    }
                }
            }
            else if (typeof(T) == typeof(Seller))
            {
                var seller = _set.Find(id) as Seller;

                if (seller != null)
                {
                    var form = new SellerForm(seller);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        seller = form.Seller;
                        _db.SaveChanges();
                        dataGridView.Update();
                    }
                }
            }
            else if (typeof(T) == typeof(Customer)) 
            { 
                var customer = _set.Find(id) as Customer;

                if (customer != null) 
                {
                    var form = new CustomerForm(customer);

                    if (form.ShowDialog() == DialogResult.OK) 
                    {
                        customer = form.Customer;
                        _db.SaveChanges();
                        dataGridView.Update();
                    }
                }
            }
        }
    }
}
