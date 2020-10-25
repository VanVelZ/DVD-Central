Begin
	Insert into dbo.tblCustomer(Id, FirstName, LastName, [Address], City, [State], ZIP, Phone, UserID)
	values 
	(1, 'Zachary', 'Vander Velden', '555 what way', 'Kaukauna', 'WI', '54130', 'phone', 5),
	(2, 'Bob', 'Vander Velden', '555 what way', 'Kaukauna', 'WI', '54130', 'phone', 3),
	(3, 'John', 'Vander Velden', '555 what way', 'Kaukauna', 'WI', '54130', 'phone', 2)
End