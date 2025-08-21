using CRM.Kernel.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CRM.UI
{
    public partial class ModelForm : Form
    {
        ShopComputerModel model = new ShopComputerModel();

        public ModelForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cashDesks = new List<CashDeskView>();

            for (int i = 0; i < model.CashDesks.Count; i++) 
            {
                var cashdesk = new CashDeskView(model.CashDesks[i], i, 10, 26 * i);
                cashDesks.Add(cashdesk);
                Controls.Add(cashdesk.CashDeskName);
                Controls.Add(cashdesk.Price);
                Controls.Add(cashdesk.QueueLength);
                Controls.Add(cashdesk.LeaveCustomersCount);
            }

            model.Start();
        }

        private void ModelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            model.Stop();
        }

        private void ModelForm_Load(object sender, EventArgs e)
        {
            CustomerSpeed.Value = model.CustomerSpeed;
            CashDeskSpeed.Value = model.CashDeskSpeed;
        }

        private void CustomerSpeed_ValueChanged(object sender, EventArgs e)
        {
            model.CustomerSpeed = (int)CustomerSpeed.Value;
        }

        private void CashDeskSpeed_ValueChanged(object sender, EventArgs e)
        {
            model.CashDeskSpeed = (int)CashDeskSpeed.Value;
        }
    }
}
