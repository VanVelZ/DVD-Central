CREATE TABLE [dbo].[tblOrderItem]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [OrderID] INT NOT NULL, 
    [MovieID] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    [Cost] FLOAT NOT NULL
)
