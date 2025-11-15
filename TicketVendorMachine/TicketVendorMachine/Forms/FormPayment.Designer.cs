namespace TicketVendorMachine.Forms
{
    partial class FormPayment
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
            label1 = new Label();
            lblSummary = new Label();
            btnPay = new Button();
            btnBack = new Button();
            cboMethod = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(153, 102);
            label1.Name = "label1";
            label1.Size = new Size(124, 20);
            label1.TabIndex = 0;
            label1.Text = "Payment method:";
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Location = new Point(269, 39);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(50, 20);
            lblSummary.TabIndex = 1;
            lblSummary.Text = "label2";
            lblSummary.Click += lblSummary_Click;
            // 
            // btnPay
            // 
            btnPay.Location = new Point(142, 172);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(144, 29);
            btnPay.TabIndex = 2;
            btnPay.Text = "Conduct payment";
            btnPay.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(350, 172);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 3;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // cboMethod
            // 
            cboMethod.FormattingEnabled = true;
            cboMethod.Location = new Point(320, 99);
            cboMethod.Name = "cboMethod";
            cboMethod.Size = new Size(151, 28);
            cboMethod.TabIndex = 5;
            // 
            // FormPayment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 285);
            Controls.Add(cboMethod);
            Controls.Add(btnBack);
            Controls.Add(btnPay);
            Controls.Add(lblSummary);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormPayment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormPayment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblSummary;
        private Button btnPay;
        private Button btnBack;
        private ComboBox cboMethod;
    }
}