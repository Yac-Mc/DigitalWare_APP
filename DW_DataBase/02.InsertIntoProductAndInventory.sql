USE DW_DataBase

INSERT INTO [Product] ([Name], [Description], [Maker]) VALUES ('Chocoramo', 'Ponqué con forma cuadrada cubierto de chocolate', 'Ramo')
INSERT INTO [Product] ([Name], [Description], [Maker]) VALUES ('Coca-Cola', 'Bebida gaseosa y refrescante', 'The Coca-Cola Company')
INSERT INTO [Product] ([Name], [Description], [Maker]) VALUES ('Leche Entera Alqueria', 'Bolsa de leche', 'Alquería')

DECLARE @v_ProductId INT = (SELECT Id FROM [Product] WHERE [Name] = 'Chocoramo')
INSERT INTO [Inventory] (ProductId, UnitPrice, Quantity, PurchaseDate) VALUES(@v_ProductId, 1200.00, 50, GETDATE())

SET @v_ProductId = (SELECT Id FROM [Product] WHERE [Name] = 'Coca-Cola')
INSERT INTO [Inventory] (ProductId, UnitPrice, Quantity, PurchaseDate) VALUES(@v_ProductId, 1500.00, 25, '2020-12-21')

SET @v_ProductId = (SELECT Id FROM [Product] WHERE [Name] = 'Leche Entera Alqueria')
INSERT INTO [Inventory] (ProductId, UnitPrice, Quantity, PurchaseDate) VALUES(@v_ProductId, 1200.00, 30, '2021-01-15')