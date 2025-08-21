namespace CRM.UI
{
    partial class ModelForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.CustomerSpeed = new System.Windows.Forms.NumericUpDown();
            this.CashDeskSpeed = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashDeskSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CustomerSpeed
            // 
            this.CustomerSpeed.Location = new System.Drawing.Point(668, 12);
            this.CustomerSpeed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.CustomerSpeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.CustomerSpeed.Name = "CustomerSpeed";
            this.CustomerSpeed.Size = new System.Drawing.Size(120, 20);
            this.CustomerSpeed.TabIndex = 1;
            this.CustomerSpeed.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.CustomerSpeed.ValueChanged += new System.EventHandler(this.CustomerSpeed_ValueChanged);
            // 
            // CashDeskSpeed
            // 
            this.CashDeskSpeed.Location = new System.Drawing.Point(668, 38);
            this.CashDeskSpeed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.CashDeskSpeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.CashDeskSpeed.Name = "CashDeskSpeed";
            this.CashDeskSpeed.Size = new System.Drawing.Size(120, 20);
            this.CashDeskSpeed.TabIndex = 2;
            this.CashDeskSpeed.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.CashDeskSpeed.ValueChanged += new System.EventHandler(this.CashDeskSpeed_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(550, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Скорость клиентов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(550, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Скорость продавцов";
            // 
            // ModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CashDeskSpeed);
            this.Controls.Add(this.CustomerSpeed);
            this.Controls.Add(this.button1);
            this.Name = "ModelForm";
            this.Text = "ModelForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModelForm_FormClosing);
            this.Load += new System.EventHandler(this.ModelForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashDeskSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown CustomerSpeed;
        private System.Windows.Forms.NumericUpDown CashDeskSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}