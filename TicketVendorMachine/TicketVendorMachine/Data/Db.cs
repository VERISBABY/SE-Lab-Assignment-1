using System;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

// 1. Đảm bảo namespace là "TicketVendorMachine.Data"
namespace TicketVendorMachine.Data
{
    public static class Db
    {
        // 2. Dòng này sẽ ĐỌC file App.config của bạn
        //    Đây là lý do bạn phải cài NuGet System.Configuration.ConfigurationManager
        private static readonly string ConnStr =
            ConfigurationManager.ConnectionStrings["TicketKioskDB"].ConnectionString;

        // 3. Các phương thức này gọi Stored Procedures trong SQL Server
        // (Đây là các "sp_..." mà bạn sẽ tạo ở BƯỚC 4 của hướng dẫn)
        public static DataTable ListDestinations()
        {
            using var cn = new SqlConnection(ConnStr);
            using var cmd = new SqlCommand("dbo.sp_ListDestinations", cn) { CommandType = CommandType.StoredProcedure };
            var dt = new DataTable();
            cn.Open();
            using var rdr = cmd.ExecuteReader();
            dt.Load(rdr);
            return dt;
        }

        public static int CreatePayment(string method, int amountVnd)
        {
            using var cn = new SqlConnection(ConnStr);
            using var cmd = new SqlCommand("dbo.sp_CreatePayment", cn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Method", method);
            cmd.Parameters.AddWithValue("@AmountVND", amountVnd);
            var p = new SqlParameter("@PaymentId", SqlDbType.Int) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(p);
            cn.Open();
            cmd.ExecuteNonQuery();
            return (int)p.Value;
        }

        public static void ApprovePayment(int paymentId, string providerRef = null)
        {
            using var cn = new SqlConnection(ConnStr);
            using var cmd = new SqlCommand("dbo.sp_ApprovePayment", cn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@PaymentId", paymentId);
            cmd.Parameters.AddWithValue("@ProviderRef", (object?)providerRef ?? DBNull.Value);
            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public static void DeclinePayment(int paymentId)
        {
            using var cn = new SqlConnection(ConnStr);
            using var cmd = new SqlCommand("dbo.sp_DeclinePayment", cn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@PaymentId", paymentId);
            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public static (int TicketId, string TicketCode) IssueTicket(int destinationId, int paymentId)
        {
            using var cn = new SqlConnection(ConnStr);
            using var cmd = new SqlCommand("dbo.sp_IssueTicket", cn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@DestinationId", destinationId);
            cmd.Parameters.AddWithValue("@PaymentId", paymentId);
            cn.Open();
            using var rdr = cmd.ExecuteReader();
            rdr.Read();
            return (rdr.GetInt32(0), rdr.GetString(1));
        }
    }
}