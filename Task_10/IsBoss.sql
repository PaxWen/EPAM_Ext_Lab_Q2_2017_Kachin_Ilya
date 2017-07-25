USE [Northwind]
GO

/****** Объект: Scalar Function [dbo].[IsBoss] Дата скрипта: 24.07.2017 14:08:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER FUNCTION dbo.IsBoss
(
	@param1 int
)
RETURNS BIT
AS
BEGIN 
DECLARE @CountEmp bit
Set @CountEmp = 
	(
	Select Count (*)
	From Northwind.Northwind.Employees 
	Where ReportsTo = @CountEmp
	)
Return @CountEmp
END
