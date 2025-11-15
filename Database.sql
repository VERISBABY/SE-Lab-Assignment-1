CREATE DATABASE TicketKioskDB;
GO
USE TicketKioskDB;
GO


CREATE TABLE dbo.Destinations(
  DestinationId INT IDENTITY(1,1) PRIMARY KEY,
  Name NVARCHAR(100) NOT NULL UNIQUE,
  FareVND INT NOT NULL CHECK (FareVND >= 0),
  IsActive BIT NOT NULL DEFAULT 1
);
INSERT INTO dbo.Destinations(Name, FareVND) VALUES
(N'Ben Thanh', 15000),
(N'Suoi Tien', 20000),
(N'Tan Son Nhat', 18000);

CREATE TABLE dbo.Payments(
  PaymentId INT IDENTITY(1,1) PRIMARY KEY,
  Method NVARCHAR(20) NOT NULL,          -- 'Card' | 'MoMo' | 'VNPay' | 'ZaloPay'
  AmountVND INT NOT NULL CHECK (AmountVND >= 0),
  Status NVARCHAR(20) NOT NULL,          -- 'Pending' | 'Approved' | 'Declined'
  ProviderRef NVARCHAR(100) NULL,
  CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
  ApprovedAt DATETIME2 NULL
);

CREATE TABLE dbo.Tickets(
  TicketId INT IDENTITY(1,1) PRIMARY KEY,
  TicketCode AS ('TC' + RIGHT('00000000' + CONVERT(varchar(8), TicketId), 8)) PERSISTED,
  DestinationId INT NOT NULL FOREIGN KEY REFERENCES dbo.Destinations(DestinationId),
  FareVND INT NOT NULL,
  PaymentId INT NOT NULL FOREIGN KEY REFERENCES dbo.Payments(PaymentId),
  PrintedAt DATETIME2 NULL,
  CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

-- Stored procedures used by the app
GO
CREATE OR ALTER PROCEDURE dbo.sp_ListDestinations
AS
BEGIN
  SET NOCOUNT ON;
  SELECT DestinationId, Name, FareVND FROM dbo.Destinations
  WHERE IsActive = 1 ORDER BY Name;
END
GO
CREATE OR ALTER PROCEDURE dbo.sp_CreatePayment
  @Method NVARCHAR(20),
  @AmountVND INT,
  @PaymentId INT OUTPUT
AS
BEGIN
  SET NOCOUNT ON;
  INSERT INTO dbo.Payments(Method, AmountVND, Status) VALUES(@Method, @AmountVND, 'Pending');
  SET @PaymentId = SCOPE_IDENTITY();
END
GO
CREATE OR ALTER PROCEDURE dbo.sp_ApprovePayment
  @PaymentId INT,
  @ProviderRef NVARCHAR(100)=NULL
AS
BEGIN
  UPDATE dbo.Payments
    SET Status='Approved', ApprovedAt=SYSDATETIME(), ProviderRef=@ProviderRef
  WHERE PaymentId=@PaymentId;
END
GO
CREATE OR ALTER PROCEDURE dbo.sp_DeclinePayment
  @PaymentId INT
AS
BEGIN
  UPDATE dbo.Payments SET Status='Declined' WHERE PaymentId=@PaymentId AND Status='Pending';
END
GO
CREATE OR ALTER PROCEDURE dbo.sp_IssueTicket
  @DestinationId INT,
  @PaymentId INT
AS
BEGIN
  SET NOCOUNT ON;
  DECLARE @fare INT;
  SELECT @fare = FareVND FROM dbo.Destinations WHERE DestinationId=@DestinationId;

  INSERT INTO dbo.Tickets(DestinationId, FareVND, PaymentId, PrintedAt)
  VALUES(@DestinationId, @fare, @PaymentId, SYSDATETIME());

  SELECT TicketId, TicketCode FROM dbo.Tickets WHERE TicketId = SCOPE_IDENTITY();
END
GO
