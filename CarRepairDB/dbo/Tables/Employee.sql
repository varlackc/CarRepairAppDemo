CREATE TABLE [dbo].[Employee]
(
	[EmployeeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserName] VARCHAR(100) NOT NULL, 
    [FirstName] VARCHAR(100) NULL, 
    [LastName] VARCHAR(100) NULL, 
    [Location] VARCHAR(250) NULL, 
    [PhoneNumber] VARCHAR(50) NULL, 
    [Status] VARCHAR(50) NULL
)
