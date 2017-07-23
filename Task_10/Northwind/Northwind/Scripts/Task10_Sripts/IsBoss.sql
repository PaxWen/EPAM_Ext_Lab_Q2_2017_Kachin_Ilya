
CREATE FUNCTION dbo.IsBoss
(
	@param1 int
)
RETURNS INT
AS
BEGIN 
DECLARE @CountEmp bit
Set @CountEmp = 
	(
	Select Count (*)
	From Northwind.Northwind.Employees 
	Where ReportsTo = @param1
	)
Return @CountEmp
END
