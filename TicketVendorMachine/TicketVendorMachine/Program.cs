using System;
using System.Windows.Forms;
using TicketVendorMachine.Forms; // Thêm dòng này ?? C# bi?t FormDestination ? ?âu

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        // Dòng này ???c thay ??i: ch?y FormDestination thay vì Form1
        Application.Run(new FormDestination());
    }
}