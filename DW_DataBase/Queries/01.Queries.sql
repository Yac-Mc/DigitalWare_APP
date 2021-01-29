--QUERY #1: Obtener la lista de precios de todos los productos
SELECT I.*, P.Name AS ProductName 
FROM [dbo].[Inventory] I 
	INNER JOIN  dbo.Product P ON P.Id = I.ProductId

--QUERY #2: Obtener la lista de productos cuya existencia en el inventario haya llegado al m�nimo permitido (5 unidades)
DECLARE @v_QuantityMin INT = 5
SELECT I.*, P.Name AS ProductName 
FROM [dbo].[Inventory] I 
	INNER JOIN  dbo.Product P ON P.Id = I.ProductId
WHERE I.Quantity >= @v_QuantityMin

--QUERY #2: Obtener una lista de clientes no mayores de 35 a�os que hayan realizado compras entre el 1 de febrero de 2000 y el 25 de mayo de 2000
DECLARE @v_Age INT = 35, @v_SaleDateIni DATE = '2000-02-01', @v_SaleDateFin DATE = '2000-05-25'
SELECT C.* 
FROM dbo.Client C
	INNER JOIN [dbo].[Sales] S ON S.ClientId = C.Id
WHERE
DATEDIFF(YEAR, C.BirthDate, GETDATE()) <= @v_Age
AND S.SaleDate BETWEEN @v_SaleDateIni AND @v_SaleDateFin

--QUERY #3: Obtener el valor total vendido por cada producto en el a�o 2000