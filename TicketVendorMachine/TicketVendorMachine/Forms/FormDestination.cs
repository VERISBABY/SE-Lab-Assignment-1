using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TicketVendorMachine.Data;

namespace TicketVendorMachine.Forms
{
    public partial class FormDestination : Form
    {
        // Dictionary to store Vietnamese translations
        private System.Collections.Generic.Dictionary<string, string> vietnameseTexts;

        public FormDestination()
        {
            InitializeComponent();
            Load += FormDestination_Load;
            btnNext.Click += BtnNext_Click;
            cboDestination.SelectedIndexChanged += (_, __) => UpdateFare();
            cboLanguage.SelectedIndexChanged += cboLanguage_SelectedIndexChanged;
        }

        private void FormDestination_Load(object? sender, EventArgs e)
        {
            InitializeVietnameseTexts();

            cboLanguage.Items.Clear();
            cboLanguage.Items.Add("Vietnamese");
            cboLanguage.Items.Add("English");
            cboLanguage.SelectedIndex = 1; // Set "English" as default

            var dt = Db.ListDestinations();
            cboDestination.DisplayMember = "Name";
            cboDestination.ValueMember = "DestinationId";
            cboDestination.DataSource = dt;
            if (dt.Rows.Count > 0) cboDestination.SelectedIndex = 0;
            UpdateFare();
        }

        private void InitializeVietnameseTexts()
        {
            vietnameseTexts = new System.Collections.Generic.Dictionary<string, string>
            {
                { "lblTitle", "CHỌN ĐIỂM ĐẾN" },
                { "label1", "Điểm đến:" },  // Vietnamese for "Destination"
                { "label2", "Chọn Ngôn Ngữ:" },  // Vietnamese for "Select Language"
                { "lblFare", "Giá vé: " },
                { "btnNext", "TIẾP THEO" },
                { "btnBack", "QUAY LẠI" }
            };
        }

        private void UpdateFare()
        {
            if (cboDestination.SelectedItem is DataRowView rv)
            {
                var fare = (int)rv["FareVND"];
                string fareText = cboLanguage.SelectedIndex == 0 ? "Giá vé: " : "Fare: ";
                lblFare.Text = $"{fareText}{fare.ToString("#,0", CultureInfo.GetCultureInfo("vi-VN"))} ₫";
            }
        }

        private void BtnNext_Click(object? sender, EventArgs e)
        {
            if (cboDestination.SelectedItem is DataRowView rv)
            {
                int destId = (int)rv["DestinationId"];
                int fare = (int)rv["FareVND"];
                string destName = rv["Name"].ToString()!;

                var f = new FormPayment(destId, destName, fare);

                f.StartPosition = FormStartPosition.CenterScreen;
                f.Show();
                Hide();
            }
        }

        private void cboLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLanguage.SelectedIndex == 0) // Vietnamese selected
            {
                ChangeToVietnamese();
            }
            else // English selected
            {
                ChangeToEnglish();
            }
            UpdateFare(); // Update fare display with correct language
        }

        private void ChangeToVietnamese()
        {
            // Update form title
            this.Text = "Máy Bán Vé - Chọn Điểm Đến";

            // Update all controls with Vietnamese text
            if (vietnameseTexts != null)
            {
                // Update labels and buttons
                foreach (Control control in this.Controls)
                {
                    if (control is Label label && vietnameseTexts.ContainsKey(label.Name))
                    {
                        label.Text = vietnameseTexts[label.Name];
                    }
                    else if (control is Button button && vietnameseTexts.ContainsKey(button.Name))
                    {
                        button.Text = vietnameseTexts[button.Name];
                    }
                }

                // If you have group boxes or other containers
                UpdateControlsInContainers(this.Controls);
            }
        }

        private void ChangeToEnglish()
        {
            // Update form title
            this.Text = "Ticket Vendor Machine - Select Destination";

            // Reset all controls to English text
            foreach (Control control in this.Controls)
            {
                switch (control.Name)
                {
                    case "lblTitle":
                        control.Text = "SELECT DESTINATION";
                        break;
                    case "label1":  // Reset label1 to English
                        control.Text = "Destination:";
                        break;
                    case "label2":  // Reset label2 to English
                        control.Text = "Select Language:";
                        break;
                    case "lblFare":
                        // Fare label will be updated by UpdateFare method
                        break;
                    case "btnNext":
                        control.Text = "NEXT";
                        break;
                    case "btnBack":
                        control.Text = "BACK";
                        break;
                }
            }
        }

        private void UpdateControlsInContainers(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Label label && vietnameseTexts.ContainsKey(label.Name))
                {
                    label.Text = vietnameseTexts[label.Name];
                }
                else if (control is Button button && vietnameseTexts.ContainsKey(button.Name))
                {
                    button.Text = vietnameseTexts[button.Name];
                }

                // Recursively check containers within containers
                if (control.HasChildren)
                {
                    UpdateControlsInContainers(control.Controls);
                }
            }
        }
    }
}