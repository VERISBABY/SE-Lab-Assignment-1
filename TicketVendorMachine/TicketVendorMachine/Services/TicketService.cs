using TicketVendorMachine.Data; // 1. File này gọi file Db.cs

// 2. Đảm bảo namespace là "TicketVendorMachine.Services"
namespace TicketVendorMachine.Services
{
    public static class TicketService
    {
        // 3. Đây chỉ là một hàm gọi "pass-through" (chuyển tiếp)
        //    Logic của UI sẽ gọi hàm này, hàm này gọi lớp Db
        public static (int ticketId, string ticketCode) Issue(int destinationId, int paymentId)
            => Db.IssueTicket(destinationId, paymentId);
    }
}