﻿CREATE TABLE [dbo].[tblMovie]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Title] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(50) NOT NULL, 
    [Cost] FLOAT NOT NULL, 
    [RatingID] INT NOT NULL, 
    [FormatID] INT NOT NULL, 
    [DirectorID] INT NOT NULL, 
    [InStkQty] INT NOT NULL, 
    [ImagePath] VARCHAR(100) NOT NULL 
)
