CREATE TABLE [dbo].[tblOrder]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CustomerID] INT NOT NULL, 
    [OrderDate] DATETIME NOT NULL, 
    [UserID] INT NOT NULL, 
    [ShipDate] DATETIME NOT NULL
)
