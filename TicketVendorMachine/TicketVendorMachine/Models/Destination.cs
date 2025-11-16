// 1. Đảm bảo namespace là "TicketVendorMachine.Models"
namespace TicketVendorMachine.Models
{
    public sealed class Destination
    {
        // 2. Các thuộc tính này PHẢI KHỚP với tên cột
        //    trong bảng "dbo.Destinations" của bạn
        public int DestinationId { get; set; }
        public string Name { get; set; } = "";
        public int FareVND { get; set; }

        // 3. Hàm này rất hữu ích:
        //    Khi bạn ném object này vào ComboBox (Dropdown list),
        //    nó sẽ tự động hiển thị "Name" thay vì chữ "Destination"
        public override string ToString() => Name;
    }
}