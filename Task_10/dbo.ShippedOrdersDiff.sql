CREATE PROCEDURE [dbo].[ShippedOrdersDiff]
	@param1 int 
AS
	Select OrderID
	,OrderDate
	,ShippedDate
	,DateDIFF(day,OrderDate,ShippedDate ) As 'ShippedDelay'
	From Northwind.Northwind.Orders 
	where (DateDIFF(day,OrderDate,ShippedDate)>@param1) or (DateDIFF(day,OrderDate,ShippedDate)is null)
RETURN 0
