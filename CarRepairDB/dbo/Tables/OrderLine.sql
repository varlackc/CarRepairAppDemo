CREATE TABLE [dbo].[OrderLine]
(
	[OrderLineId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [OrderId] INT NOT NULL, 
    [PartId] INT NULL, 
    [ServiceId] INT NULL, 
    [LineNo] INT NULL, 
    [LineDescription] VARCHAR(250) NULL, 
    [ServiceQty] INT NOT NULL DEFAULT 0, 
    [PartQty] INT NOT NULL DEFAULT 0, 
    [Status] VARCHAR(50) NULL, 
    [OrderNotes] VARCHAR(250) NULL
)
