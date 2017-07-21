/*
По таблице Orders найти количество заказов, cделанных каждым продавцом. 
Заказ для указанного продавца – это любая запись в таблице Orders, 
где в колонке EmployeeID задано значение для данного продавца. 
В результатах запроса надо высвечивать колонку с именем продавца 
(Должно высвечиваться имя полученное конкатенацией LastName & FirstName. 
Эта строка LastName & FirstName должна быть получена отдельным запросом в колонке основного запроса. 
Также основной запрос должен использовать группировку по EmployeeID.) с названием колонки ‘Seller’ 
и колонку c количеством заказов высвечивать с названием 'Amount'. Результаты запроса должны быть 
упорядочены по убыванию количества заказов
 */

 Select (Employees.FirstName + Employees.LastName) as 'Seller'
 , COUNT( Distinct OrderID) as 'Amount'
From Northwind.Northwind.Orders, Northwind.Northwind.Employees
where Exists (select LastName,FirstName From Northwind.Northwind.Employees where Orders.EmployeeID = Employees.EmployeeID)
Group by Orders.EmployeeID
Order by Amount Desc