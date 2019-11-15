CREATE TABLE [dbo].[Order]
(
	[OrderId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ClientId] INT NULL, 
    [StoreId] INT NULL, 
    [EmployeeId] INT NULL, 
    [OrderTime] DATETIME2 NULL, 
    [OrderType] VARCHAR(50) NULL, 
    [Specifications] VARCHAR(250) NULL, 
    [Description] VARCHAR(250) NULL, 
    [Location] VARCHAR(250) NULL, 
    [Status] VARCHAR(50) NULL, 
    CONSTRAINT [FK_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Client]([ClientId]), 
    CONSTRAINT [FK_StoreId] FOREIGN KEY ([StoreId]) REFERENCES [Store]([StoreId]), 
    CONSTRAINT [FK_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employee]([EmployeeId])
)
