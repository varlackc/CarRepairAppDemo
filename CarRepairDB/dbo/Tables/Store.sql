CREATE TABLE [dbo].[Store]
(
	[StoreId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StoreName] VARCHAR(100) NOT NULL, 
    [StoreAddress] VARCHAR(250) NULL, 
    [PhoneNumber] VARCHAR(50) NULL, 
    [HoursOfOperation] VARCHAR(250) NULL
)
