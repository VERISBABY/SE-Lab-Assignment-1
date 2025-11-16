namespace TicketVendorMachine.Forms
{
    partial class FormDestination
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
            cboDestination = new ComboBox();
            lblFare = new Label();
            btnNext = new Button();
            cboLanguage = new ComboBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(193, 67);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 0;
            label1.Text = "Destination";
            // 
            // cboDestination
            // 
            cboDestination.FormattingEnabled = true;
            cboDestination.Location = new Point(314, 67);
            cboDestination.Name = "cboDestination";
            cboDestination.Size = new Size(151, 28);
            cboDestination.TabIndex = 1;
            // 
            // lblFare
            // 
            lblFare.AutoSize = true;
            lblFare.Location = new Point(266, 174);
            lblFare.Name = "lblFare";
            lblFare.Size = new Size(50, 20);
            lblFare.TabIndex = 2;
            lblFare.Text = "label2";
            // 
            // btnNext
            // 
            btnNext.Location = new Point(470, 165);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(94, 29);
            btnNext.TabIndex = 3;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // cboLanguage
            // 
            cboLanguage.FormattingEnabled = true;
            cboLanguage.Location = new Point(3, 12);
            cboLanguage.Name = "cboLanguage";
            cboLanguage.Size = new Size(151, 28);
            cboLanguage.TabIndex = 4;
            cboLanguage.SelectedIndexChanged += cboLanguage_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 52);
            label2.Name = "label2";
            label2.Size = new Size(118, 20);
            label2.TabIndex = 5;
            label2.Text = "Select Language";
            // 
            // FormDestination
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 236);
            Controls.Add(label2);
            Controls.Add(cboLanguage);
            Controls.Add(btnNext);
            Controls.Add(lblFare);
            Controls.Add(cboDestination);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormDestination";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormDestination";
            Load += FormDestination_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cboDestination;
        private Label lblFare;
        private Button btnNext;
        private ComboBox cboLanguage;
        private Label label2;
    }
}