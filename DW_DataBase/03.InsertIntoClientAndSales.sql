USE DW_DataBase

INSERT INTO [Client] ([IdentificationNumber], [DocumentType], [FirstName],[SecondName], [Surname], [SecondSurname], [BirthDate]) VALUES ('1026558606', 'CC', 'Yoe', 'Andres', 'Cardenas', NULL, '1988-09-07')
INSERT INTO [Client] ([IdentificationNumber], [DocumentType], [FirstName],[SecondName], [Surname], [SecondSurname], [BirthDate]) VALUES ('1014180267', 'TI', 'Katalina', NULL, 'Lozano', 'Sabogal', '2004-10-14')
INSERT INTO [Client] ([IdentificationNumber], [DocumentType], [FirstName],[SecondName], [Surname], [SecondSurname], [BirthDate]) VALUES ('5235589', 'CC', 'Nelson', 'Javier', 'Lozano', NULL, '1975-09-01')
INSERT INTO [Client] ([IdentificationNumber], [DocumentType], [FirstName],[SecondName], [Surname], [SecondSurname], [BirthDate]) VALUES ('1234567890', 'CC', 'Daniel', 'Alberto', 'Castillo', 'Forero', '1980-02-14')


DECLARE @v_ProductId INT = (SELECT Id FROM [Product] WHERE [Name] = 'Chocoramo')
DECLARE @v_ClientId INT = (SELECT Id FROM [Client] WHERE [IdentificationNumber] = '5235589')
INSERT INTO [Sales] ([ProductId], [ClientId], [SaleDate], [Quantity]) VALUES(@v_ProductId, @v_ClientId, '2000-02-15', 2)

SET @v_ProductId = (SELECT Id FROM [Product] WHERE [Name] = 'Coca-Cola')
INSERT INTO [Sales] ([ProductId], [ClientId], [SaleDate], [Quantity]) VALUES(@v_ProductId, @v_ClientId, '2000-04-10', 1)

SET @v_ProductId = (SELECT Id FROM [Product] WHERE [Name] = 'Leche Entera Alqueria')
SET @v_ClientId = (SELECT Id FROM [Client] WHERE [IdentificationNumber] = '1234567890')
INSERT INTO [Sales] ([ProductId], [ClientId], [SaleDate], [Quantity]) VALUES(@v_ProductId, @v_ClientId, '2000-05-20', 3)

SET @v_ProductId = (SELECT Id FROM [Product] WHERE [Name] = 'Coca-Cola')
SET @v_ClientId = (SELECT Id FROM [Client] WHERE [IdentificationNumber] = '1026558606')
INSERT INTO [Sales] ([ProductId], [ClientId], [SaleDate], [Quantity]) VALUES(@v_ProductId, @v_ClientId, '2000-05-15', 1)

SET @v_ProductId = (SELECT Id FROM [Product] WHERE [Name] = 'Chocoramo')
SET @v_ClientId = (SELECT Id FROM [Client] WHERE [IdentificationNumber] = '1234567890')
INSERT INTO [Sales] ([ProductId], [ClientId], [SaleDate], [Quantity]) VALUES(@v_ProductId, @v_ClientId, GETDATE(), 3)