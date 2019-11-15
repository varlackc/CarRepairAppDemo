CREATE TABLE [dbo].[Service]
(
	[ServiceId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ServiceName] VARCHAR(100) NOT NULL, 
    [ServiceDescription] VARCHAR(250) NULL, 
    [ServiceDate] DATETIME2 NULL, 
    [Status] VARCHAR(50) NULL
)
