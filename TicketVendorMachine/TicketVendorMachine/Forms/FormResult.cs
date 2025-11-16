using System.Globalization;
using System.Windows.Forms;

namespace TicketVendorMachine.Forms
{
    public partial class FormResult : Form
    {
        public FormResult(string destinationName, int fareVnd, string ticketCode, string method)
        {
            InitializeComponent();
            lblTitle.Text = "Ticket Purchased!";
            txtDetails.ReadOnly = true;
            txtDetails.Text =
                $"Destination: {destinationName}\r\n" +
                $"Amount: {fareVnd.ToString("#,0", CultureInfo.GetCultureInfo("vi-VN"))} ₫\r\n" +
                $"Payment: {method}\r\n" +
                $"Ticket Code: {ticketCode}";

            // 1. Quay về màn hình chính
            btnDone.Click += (s, e) => { new FormDestination().Show(); Close(); };
        }
    }
}