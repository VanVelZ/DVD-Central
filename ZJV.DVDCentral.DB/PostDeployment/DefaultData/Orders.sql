Begin
	Insert into dbo.tblOrder(Id, CustomerID, OrderDate, UserID, ShipDate)
	values 
	(1, 1, GETDATE(), 1, GETDATE()),
	(2, 2, GETDATE(), 2, GETDATE()),
	(3, 3, GETDATE(), 3, GETDATE())
End