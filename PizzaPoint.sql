

					/***********************Created by AshirAfzal Date : 1-May-2019 **********************/
					/***********************Edited by AshirAfzal Date : 14-May-2019 **********************/

Create database PizzaPoint

CREATE TABLE [dbo].[Users] (
    [UserID]        INT           IDENTITY (1, 1) NOT NULL,
    [UserName]      NVARCHAR (50) NOT NULL,
    [UserPost]      NVARCHAR (50) NULL,
    [UserEducation] NVARCHAR (50) NULL,
    [UserLoginID]   INT           NOT NULL,
    [UserPass]      NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);

CREATE TABLE [dbo].[Customer] (
    [CustID]    INT           IDENTITY (1, 1) NOT NULL,
    [CustName]  NVARCHAR (50) NULL,
    [Contact]   NVARCHAR (50) NULL,
    [OrderTime] TIME (7)      NOT NULL,
    [OrderDate] DATE          NOT NULL,
    PRIMARY KEY CLUSTERED ([CustID] ASC)
);

CREATE TABLE [dbo].[Items] (
    [itemID]       INT           NOT NULL,
    [ItemName]     NVARCHAR (50) NOT NULL,
    [ItemPrice]    INT           NOT NULL,
    [ItemWeight]   INT           NULL,
    [itemCategory] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([itemID] ASC)
);

CREATE TABLE [dbo].[Orders] (
    [OrderID]       INT           IDENTITY (1, 1) NOT NULL,
    [CustID]        INT           NOT NULL,
    [OrderType]     NVARCHAR (50) NULL,
    [OrderCategory] NVARCHAR (50) NULL,
    [Ordertime]     TIME (7)      NOT NULL,
    [OrderDate]     DATE          NOT NULL,
    PRIMARY KEY CLUSTERED ([OrderID] ASC),
    CONSTRAINT [FK_Orders_custID] FOREIGN KEY ([CustID]) REFERENCES [dbo].[Customer] ([CustID])
);

CREATE TABLE [dbo].[Products] (
    [ProductId]    INT           IDENTITY (1, 1) NOT NULL,
    [ProductName]  NVARCHAR (50) NULL,
    [ProductPrice] NVARCHAR (50) NULL,
    [ProductImage] IMAGE         NULL,
    PRIMARY KEY CLUSTERED ([ProductId] ASC)
);

CREATE TABLE [dbo].[RawMaterial] (
    [RawMaterialName] NVARCHAR (50)  NOT NULL,
    [Barcode]         NVARCHAR (MAX) NULL,
    [ArrivalDate]     DATE           NOT NULL,
    [ArrivalTime]     TIME (7)       NOT NULL,
    [MaterialType]    NVARCHAR (50)  NULL,
    [Price]           INT            NOT NULL,
    [Quantity]        INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([RawMaterialName] ASC)
);

CREATE TABLE [dbo].[Sales] (
    [OrderID]       INT           NOT NULL,
    [CustID]        INT           NOT NULL,
    [CustName]      NVARCHAR (50) NOT NULL,
    [Contact]       NVARCHAR (50) NOT NULL,
    [OrderType]     NVARCHAR (50) NOT NULL,
    [OrderCategory] NVARCHAR (50) NOT NULL,
    [OrderTime]     TIME (7)      NOT NULL,
    [OrderDate]     DATE          NOT NULL,
    CONSTRAINT [FK_Sales_OrderID] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([OrderID]),
    CONSTRAINT [FK_Sales_CustID] FOREIGN KEY ([CustID]) REFERENCES [dbo].[Customer] ([CustID])
);

CREATE TABLE [dbo].[Bill] (
    [Billid]          INT           IDENTITY (1, 1) NOT NULL,
    [CustID]          INT           NOT NULL,
    [OrderID]         INT           NOT NULL,
    [CustName]        NVARCHAR (50) NOT NULL,
    [ProductName]     NVARCHAR (50) NULL,
    [ProductQuantity] NVARCHAR (50) NULL,
    [ProductPrice]    NVARCHAR (50) NULL,
    [OrderTime]       TIME (7)      NOT NULL,
    [OrderDate]       DATE          NOT NULL,
    [Totalqty]        NVARCHAR (50) NULL,
    [TotalAmount]     NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Billid] ASC),
    CONSTRAINT [FK_Bill_CustID] FOREIGN KEY ([CustID]) REFERENCES [dbo].[Customer] ([CustID]),
    CONSTRAINT [FK_Bill_OrderID] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([OrderID])
);

