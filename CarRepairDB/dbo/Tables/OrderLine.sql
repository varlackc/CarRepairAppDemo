CREATE TABLE [dbo].[OrderLine]
(
	[OrderLineId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [OrderId] INT NOT NULL, 
    [PartId] INT NULL, 
    [ServiceId] INT NULL, 
    [LineNo] INT NULL, 
    [LineDescription] VARCHAR(250) NULL, 
    [ServiceQty] INT NULL DEFAULT 0, 
    [PartQty] INT NULL DEFAULT 0, 
    [Status] VARCHAR(50) NULL, 
    [OrderNotes] VARCHAR(250) NULL, 
    CONSTRAINT [FK_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Order]([OrderId]), 
    CONSTRAINT [FK_PartId] FOREIGN KEY ([PartId]) REFERENCES [Part]([PartId]), 
    CONSTRAINT [FK_ServiceId] FOREIGN KEY ([ServiceId]) REFERENCES [Service]([ServiceId])
)
