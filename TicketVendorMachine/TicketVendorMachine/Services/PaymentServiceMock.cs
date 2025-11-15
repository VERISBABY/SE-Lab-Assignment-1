using System;
using System.Threading.Tasks;

// 1. Đảm bảo namespace là "TicketVendorMachine.Services"
namespace TicketVendorMachine.Services
{
    // 2. "Mock" = Giả lập. Giả vờ gọi API thanh toán thật
    public static class PaymentServiceMock
    {
        public static async Task<(bool ok, string providerRef)> PayAsync(string method, int amountVnd)
        {
            // 3. Giả vờ "chờ" mạng 0.8 giây
            await Task.Delay(800);

            // 4. Luôn luôn trả về "Thành công" để test cho dễ
            var ok = true;
            var refCode = $"{method.ToUpperInvariant()}-{DateTime.UtcNow:HHmmssffff}";
            return (ok, refCode);
        }
    }
}