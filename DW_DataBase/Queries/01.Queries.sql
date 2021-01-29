--QUERY #1: Obtener la lista de precios de todos los productos
SELECT I.*, P.Name AS ProductName 
FROM [dbo].[Inventory] I 
	INNER JOIN  dbo.Product P ON P.Id = I.ProductId

--QUERY #2: Obtener la lista de productos cuya existencia en el inventario haya llegado al mínimo permitido (5 unidades)
DECLARE @v_QuantityMin INT = 5
SELECT I.*, P.Name AS ProductName 
FROM [dbo].[Inventory] I 
	INNER JOIN  dbo.Product P ON P.Id = I.ProductId
WHERE I.Quantity >= @v_QuantityMin

--QUERY #2: Obtener una lista de clientes no mayores de 35 años que hayan realizado compras entre el 1 de febrero de 2000 y el 25 de mayo de 2000
DECLARE @v_Age INT = 35, @v_SaleDateIni DATE = '2000-02-01', @v_SaleDateFin DATE = '2000-05-25'
SELECT C.* 
FROM dbo.Client C
	INNER JOIN [dbo].[Sales] S ON S.ClientId = C.Id
WHERE
DATEDIFF(YEAR, C.BirthDate, GETDATE()) <= @v_Age
AND S.SaleDate BETWEEN @v_SaleDateIni AND @v_SaleDateFin

--QUERY #3: Obtener el valor total vendido por cada producto en el año 2000SELECT I.ProductId,SUM(I.UnitPrice * S.Quantity) ProductSaleTotalFROM [dbo].[Sales] S	INNER JOIN [dbo].[Inventory] I ON S.ProductId = I.ProductIdGROUP BY I.ProductId--QUERY #4: Obtener la última fecha de compra de un cliente y según su frecuencia de compra estimar en qué fecha podría volver a comprarSELECT S.ClientId,MAX(S.SaleDate) LastDatePurchase,DATEDIFF(DAY, MIN(S.SaleDate), MAX(S.SaleDate)) DaysNextPurchaseFROM [dbo].[Sales] SGROUP BY S.ClientId