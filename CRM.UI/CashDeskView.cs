using CRM.Kernel.Models;
using System;
using System.Windows.Forms;

namespace CRM.UI
{
    internal class CashDeskView
    {
        CashDesk CashDesk;

        public Label CashDeskName { get; set; }
        public NumericUpDown Price { get; set; }
        public ProgressBar QueueLength { get; set; }
        public Label LeaveCustomersCount { get; set; }

        public CashDeskView(CashDesk cashDesk, int number, int x, int y)
        {
            CashDesk = cashDesk;

            CashDeskName = new Label();
            CashDeskName.AutoSize = true;
            CashDeskName.Location = new System.Drawing.Point(x, y);
            CashDeskName.Name = "label" + number;
            CashDeskName.Size = new System.Drawing.Size(35, 13);
            CashDeskName.TabIndex = number;
            CashDeskName.Text = cashDesk.ToString();

            Price = new NumericUpDown();
            Price.Location = new System.Drawing.Point(x + 65, y);
            Price.Name = "numericUpDown" + number;
            Price.Size = new System.Drawing.Size(120, 20);
            Price.TabIndex = number;
            Price.Maximum = decimal.MaxValue;

            QueueLength = new ProgressBar();
            QueueLength.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            QueueLength.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            QueueLength.Location = new System.Drawing.Point(x + 200, y);
            QueueLength.Maximum = cashDesk.MaxQueueLength;
            QueueLength.Name = "progressBar1" + number;
            QueueLength.Size = new System.Drawing.Size(100, 23);
            QueueLength.TabIndex = number;
            QueueLength.Value = 0;

            LeaveCustomersCount = new Label();
            LeaveCustomersCount.AutoSize = true;
            LeaveCustomersCount.Location = new System.Drawing.Point(x + 310, y);
            LeaveCustomersCount.Name = "label2" + number;
            LeaveCustomersCount.Size = new System.Drawing.Size(35, 13);
            LeaveCustomersCount.TabIndex = number;
            LeaveCustomersCount.Text = "";

            cashDesk.ReceiptClosed += CashDesk_ReceiptClosed;
        }

        private void CashDesk_ReceiptClosed(object sender, Receipt e)
        {
            Price.Invoke((Action)delegate 
            { 
                Price.Value += e.Price;
                QueueLength.Value = CashDesk.Count;
                LeaveCustomersCount.Text = $"Недождалось очереди: {CashDesk.ExitCustomer.ToString()}";
            });
        }
    }
}
