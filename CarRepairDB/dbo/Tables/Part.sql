CREATE TABLE [dbo].[Part]
(
	[PartId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PartName] VARCHAR(100) NOT NULL, 
    [PartDescription] VARCHAR(250) NULL, 
    [PartNumber] VARCHAR(100) NULL, 
    [PartSupplier] VARCHAR(100) NULL, 
    [PartCost] MONEY NULL, 
    [PartPrice] MONEY NULL, 
    [PartManufacturer] VARCHAR(50) NULL
)
