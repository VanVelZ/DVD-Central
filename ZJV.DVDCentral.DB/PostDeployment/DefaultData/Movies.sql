Begin
	Insert into dbo.tblMovie(id, Title, [Description], Cost, RatingID, FormatID, DirectorID, InStkQty, ImagePath)
	values 
	(1, 'Toy Story', 'Pixar film about toys', 12.22, 3, 1, 1, 22, 'empty'),
	(2, 'Toy Story 2', 'Pixar film about toys', 12.22, 3, 1, 1, 22, 'empty'),
	(3, 'Toy Story 3', 'Pixar film about toys', 12.22, 3, 1, 1, 22, 'empty')
End