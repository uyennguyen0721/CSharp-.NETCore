IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Categories] (
    [CategoryID] int NOT NULL IDENTITY,
    [CategoryName] nvarchar(255) NULL,
    [Description] nvarchar(255) NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryID])
);
GO

CREATE TABLE [Customers] (
    [CustomerID] int NOT NULL IDENTITY,
    [CustomerName] nvarchar(255) NULL,
    [ContactName] nvarchar(255) NULL,
    [Address] nvarchar(255) NULL,
    [City] nvarchar(255) NULL,
    [PostalCode] nvarchar(255) NULL,
    [Country] nvarchar(255) NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([CustomerID])
);
GO

CREATE TABLE [Employees] (
    [EmployeeID] int NOT NULL IDENTITY,
    [LastName] nvarchar(255) NULL,
    [FirstName] nvarchar(255) NULL,
    [BirthDate] date NULL,
    [Photo] nvarchar(255) NULL,
    [Notes] text NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([EmployeeID])
);
GO

CREATE TABLE [Shippers] (
    [ShipperID] int NOT NULL IDENTITY,
    [ShipperName] nvarchar(255) NULL,
    [Phone] nvarchar(255) NULL,
    CONSTRAINT [PK_Shippers] PRIMARY KEY ([ShipperID])
);
GO

CREATE TABLE [Suppliers] (
    [SupplierID] int NOT NULL IDENTITY,
    [SupplierName] nvarchar(255) NULL,
    [ContactName] nvarchar(255) NULL,
    [Address] nvarchar(255) NULL,
    [City] nvarchar(255) NULL,
    [PostalCode] nvarchar(255) NULL,
    [Country] nvarchar(255) NULL,
    [Phone] nvarchar(255) NULL,
    CONSTRAINT [PK_Suppliers] PRIMARY KEY ([SupplierID])
);
GO

CREATE TABLE [Orders] (
    [OrderID] int NOT NULL IDENTITY,
    [CustomerId] int NULL,
    [EmployeeId] int NULL,
    [OrderDate] date NULL,
    [ShipperId] int NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderID]),
    CONSTRAINT [FK_Orders_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([CustomerID]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Orders_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([EmployeeID]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Orders_Shippers_ShipperId] FOREIGN KEY ([ShipperId]) REFERENCES [Shippers] ([ShipperID]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Products] (
    [ProductID] int NOT NULL IDENTITY,
    [ProductName] nvarchar(255) NULL,
    [SupplierId] int NULL,
    [CategoryId] int NULL,
    [Unit] nvarchar(255) NULL,
    [Price] money NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([ProductID]),
    CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([CategoryID]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Products_Suppliers_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [Suppliers] ([SupplierID]) ON DELETE NO ACTION
);
GO

CREATE TABLE [OrderDetails] (
    [OrderDetailID] int NOT NULL IDENTITY,
    [OrderId] int NULL,
    [ProductId] int NULL,
    [Quantity] int NULL,
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY ([OrderDetailID]),
    CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([OrderID]) ON DELETE NO ACTION,
    CONSTRAINT [FK_OrderDetails_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductID]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_OrderDetails_OrderId] ON [OrderDetails] ([OrderId]);
GO

CREATE INDEX [IX_OrderDetails_ProductId] ON [OrderDetails] ([ProductId]);
GO

CREATE INDEX [IX_Orders_CustomerId] ON [Orders] ([CustomerId]);
GO

CREATE INDEX [IX_Orders_EmployeeId] ON [Orders] ([EmployeeId]);
GO

CREATE INDEX [IX_Orders_ShipperId] ON [Orders] ([ShipperId]);
GO

CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);
GO

CREATE INDEX [IX_Products_SupplierId] ON [Products] ([SupplierId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210703080656_V0', N'5.0.7');
GO

COMMIT;
GO

