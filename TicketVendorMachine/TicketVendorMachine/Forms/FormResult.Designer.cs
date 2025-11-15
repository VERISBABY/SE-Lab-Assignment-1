namespace TicketVendorMachine.Forms
{
    partial class FormResult
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
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            txtDetails = new TextBox();
            btnDone = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Times New Roman", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(84, 45);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(77, 33);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Label";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // txtDetails
            // 
            txtDetails.Location = new Point(84, 94);
            txtDetails.Multiline = true;
            txtDetails.Name = "txtDetails";
            txtDetails.ReadOnly = true;
            txtDetails.Size = new Size(295, 157);
            txtDetails.TabIndex = 2;
            // 
            // btnDone
            // 
            btnDone.Location = new Point(174, 284);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(94, 29);
            btnDone.TabIndex = 3;
            btnDone.Text = "Done";
            btnDone.UseVisualStyleBackColor = true;
            // 
            // FormResult
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 338);
            Controls.Add(btnDone);
            Controls.Add(txtDetails);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
            Name = "FormResult";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormResult";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox txtDetails;
        private Button btnDone;
    }
}