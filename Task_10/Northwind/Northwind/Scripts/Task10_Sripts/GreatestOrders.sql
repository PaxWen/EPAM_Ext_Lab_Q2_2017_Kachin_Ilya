 
GO
CREATE PROCEDURE [dbo].[GreatestOrders]
@n int
AS
Begin
	SELECT FirstName
	,LastName
	,MAX(Sum1) as 'MAX Order'
	FROM (
		Select Employees.EmployeeID as 'EmpID'
		,Employees.FirstName as 'FirstName'
		,Employees.LastName as 'LastName'
		,[Order Details].OrderID as 'OrdID'
		,sum([Order Details].UnitPrice -[Order Details].UnitPrice * [Order Details].Discount) as 'Sum1'
		from (Northwind.Northwind.Employees join Northwind.Northwind.Orders 
			on Employees.EmployeeID = Orders.EmployeeID) join  Northwind.Northwind.[Order Details]
			on Orders.OrderID = [Order Details].OrderID
		Where Year(Orders.OrderDate) = n
		Group by Employees.EmployeeID,FirstName,LastName,[Order Details].OrderID
		) as Table2
	Group by FirstName,LastName
End
GO