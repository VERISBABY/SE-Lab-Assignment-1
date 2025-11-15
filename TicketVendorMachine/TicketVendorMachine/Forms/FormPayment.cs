using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicketVendorMachine.Data;
using TicketVendorMachine.Services;

namespace TicketVendorMachine.Forms
{
    public partial class FormPayment : Form
    {
        private readonly int _destId;
        private readonly int _fare;
        private readonly string _destName;

        public FormPayment(int destinationId, string destinationName, int fareVnd)
        {
            InitializeComponent();
            _destId = destinationId; _fare = fareVnd; _destName = destinationName;

            Load += (s, e) =>
            {
                cboMethod.Items.AddRange(new object[] { "Card", "MoMo", "VNPay", "ZaloPay" });
                cboMethod.SelectedIndex = 0;
                lblSummary.Text = $"Destination: {_destName}   Amount: {_fare.ToString("#,0", CultureInfo.GetCultureInfo("vi-VN"))} ₫";
            };

            btnBack.Click += (s, e) => { new FormDestination().Show(); Close(); };
            btnPay.Click += BtnPay_Click;
        }

        private async void BtnPay_Click(object? sender, EventArgs e)
        {
            var method = cboMethod.SelectedItem?.ToString() ?? "Card";

            // 1) Tạo dòng thanh toán (Pending) trong DB
            int paymentId = Db.CreatePayment(method, _fare);

            // 2) Giả lập gọi API thanh toán
            btnPay.Enabled = false;
            btnPay.Text = "Processing...";
            var (ok, providerRef) = await PaymentServiceMock.PayAsync(method, _fare);

            if (ok)
            {
                Db.ApprovePayment(paymentId, providerRef);

                // 3) Xuất vé (lưu vào DB)
                var (ticketId, ticketCode) = TicketService.Issue(_destId, paymentId);

                // 4) Hiển thị kết quả (Sẽ gạch đỏ nếu chưa làm 4.3)
                var r = new FormResult(_destName, _fare, ticketCode, method);
                r.StartPosition = FormStartPosition.CenterScreen;
                r.Show();
                Close();
            }
            else
            {
                Db.DeclinePayment(paymentId);
                btnPay.Enabled = true;
                btnPay.Text = "Conduct payment";
                MessageBox.Show("Payment declined. Please try another method.", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lblSummary_Click(object sender, EventArgs e)
        {

        }
    }
}