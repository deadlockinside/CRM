using CRM.Kernel.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM.UI
{
    public partial class Main : Form
    {
        private Context _db;
        private Cart _cart;
        private Customer _customer;
        private CashDesk _cashDesk;

        public Main()
        {
            InitializeComponent();
            _db = new Context();
            _cart = new Cart(_customer);
            _cashDesk = new CashDesk(1, _db.Sellers.FirstOrDefault(), _db);
            _cashDesk.IsModel = false;
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e) => ShowCatalog(new Catalog<Product>(_db.Products, _db));

        private void sellerToolStripMenuItem_Click(object sender, EventArgs e) => ShowCatalog(new Catalog<Seller>(_db.Sellers, _db));

        private void customerToolStripMenuItem_Click(object sender, EventArgs e) => ShowCatalog(new Catalog<Customer>(_db.Customers, _db));

        private void receiptToolStripMenuItem_Click(object sender, EventArgs e) => ShowCatalog(new Catalog<Receipt>(_db.Receipts, _db));

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

        private void sellerAddToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new SellerForm();

            if (form.ShowDialog() == DialogResult.OK) 
            { 
                _db.Sellers.Add(form.Seller);
                _db.SaveChanges();
            }
        }

        private void productAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ProductForm();

            if (form.ShowDialog() == DialogResult.OK) 
            {
                _db.Products.Add(form.Product);
                _db.SaveChanges();
            }
        }

        private void modelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ModelForm();
            form.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                listBox1.Invoke((Action)delegate
                {
                    listBox1.Items.AddRange(_db.Products.ToArray());
                    UpdateLists();
                });
            });
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem is Product product) 
            {
                _cart.Add(product);
                listBox2.Items.Add(product);
            }
        }

        private void UpdateLists()
        {
            listBox2.Items.Clear();
            listBox2.Items.AddRange(_cart.GetAll().ToArray());
            label1.Text = $"Итого: {_cart.Price}";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new Login();
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK) 
            {
                var tempCustomer = _db.Customers.FirstOrDefault(c => c.Name.Equals(form.Customer.Name));

                if (tempCustomer != null) 
                { 
                    _customer = tempCustomer;
                }
                else 
                {
                    _db.Customers.Add(form.Customer);
                    _db.SaveChanges();
                    _customer = form.Customer;
                }

                _cart.Customer = _customer;
            }

            linkLabel1.Text = $"Здравствуй, {_customer.Name}!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_customer != null) 
            {
                _cashDesk.Enqueue(_cart);
                _cashDesk.Dequeue();
                listBox2.Items.Clear();
                _cart = new Cart(_customer);
                MessageBox.Show($"Покупка выполнена успешно! Сумма: {_cart.Price}", "Покупка выполнена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                MessageBox.Show("Авторизуйтесь, пожалуйста!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
