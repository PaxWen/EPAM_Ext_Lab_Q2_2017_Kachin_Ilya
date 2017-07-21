/*По таблице Orders найти количество заказов с группировкой по годам. 
В результатах запроса надо высвечивать две колонки c названиями Year и Total. 
Написать проверочный запрос, который вычисляет количество всех заказов.*/
Select Count(*) as 'ALL ORDERS'
From Northwind.Northwind.Orders

Select Distinct YEAR(ShippedDate) as 'Year', COUNT(*) as 'Total'
From Northwind.Northwind.Orders
Group by YEAR(ShippedDate)