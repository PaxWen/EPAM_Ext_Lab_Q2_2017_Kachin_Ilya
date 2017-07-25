/*1.1
Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года (колонка ShippedDate) 
включительно и которые доставлены с ShipVia >= 2. Формат указания даты должен быть верным при любых 
региональных настройках, согласно требованиям статьи “Writing International Transact-SQL Statements” 
в Books Online раздел “Accessing and Changing Relational Data Overview”. Этот метод использовать далее для 
всех заданий. Запрос должен высвечивать только колонки OrderID, ShippedDate
и ShipVia. 
Пояснить почему сюда не попали заказы с NULL-ом в колонке ShippedDate.
--Потому что сравнение с NULL возвращает UNKNOW, а не TRUE или FALSE
*/
Select OrderID,ShippedDate 
from Northwind.Northwind.Orders
Where 
(ShippedDate>=CONVERT(datetime,'05.06.1998'))
and
(ShipVia>=2)

/*1.2
Написать запрос, который выводит только недоставленные заказы из таблицы Orders. 
В результатах запроса высвечивать для колонки ShippedDate вместо значений NULL строку 
‘Not Shipped’ – использовать системную функцию CASЕ. Запрос должен высвечивать 
только колонки OrderID и ShippedDate.
*/
Select OrderID, 
case
when ShippedDate is NULL
then 'Not Shipped'
end ShippedDate
from Northwind.Northwind.Orders
where ShippedDate is null
 
 /* 1.3 
 Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года 
 (ShippedDate) не включая эту дату или которые еще не доставлены. 
 В запросе должны высвечиваться только колонки OrderID (переименовать в Order Number) 
 и ShippedDate (переименовать в Shipped Date). В результатах запроса высвечивать 
 для колонки ShippedDate вместо значений NULL строку ‘Not Shipped’, 
 для остальных значений высвечивать дату в формате по умолчанию.
 
 */
Select OrderID as 'Order Number', 
case
when ShippedDate is NULL
then 'Not Shipped'
else Cast(ShippedDate as char(20))
end as 'Shipped Date' 
from Northwind.Northwind.Orders
where (ShippedDate is null) OR (ShippedDate>=CONVERT(datetime,'05.06.1998'))

/*2.1 
Выбрать из таблицы Customers всех заказчиков, проживающих в USA и Canada. 
Запрос сделать с только помощью оператора IN. Высвечивать колонки с именем 
пользователя и названием страны в результатах запроса. Упорядочить результаты 
запроса по имени заказчиков и по месту проживания.
*/
Select ContactName,Country
From Northwind.Northwind.Customers
Where Country in ('USA','Canada')
Order by ContactName,Country

/*2.2
Выбрать из таблицы Customers всех заказчиков, не проживающих в USA и Canada. 
Запрос сделать с помощью оператора IN. Высвечивать колонки с именем пользователя 
и названием страны в результатах запроса. 
Упорядочить результаты запроса по имени заказчиков.
*/
Select ContactName,Country
From Northwind.Northwind.Customers
Where Country not in ('USA','Canada')
Order by ContactName

/* 2.3 
Выбрать из таблицы Customers все страны, в которых проживают заказчики. 
Страна должна быть упомянута только один раз и список отсортирован по убыванию. 
Не использовать предложение GROUP BY. 
Высвечивать только одну колонку в результатах запроса.
*/
Select Distinct Country
From Northwind.Northwind.Customers
Order by Country Desc

/* 3.1 
Выбрать все заказы (OrderID) из таблицы Order Details (заказы не должны повторяться), 
где встречаются продукты с количеством от 3 до 10 включительно – это колонка Quantity 
в таблице Order Details. Использовать оператор BETWEEN. 
Запрос должен высвечивать только колонку OrderID.
*/
 Select Distinct OrderID
 From Northwind.Northwind.[Order Details]
 Where Quantity between 3 and 10

 /* 3.2 
 Выбрать всех заказчиков из таблицы Customers, у которых название страны начинается на буквы из диапазона b и g. 
 Использовать оператор BETWEEN. Проверить, что в результаты запроса попадает Germany. 
 Запрос должен высвечивать только колонки CustomerID и Country и отсортирован по Country.
 */
  --Execution Plan 00:00:00.0580033
 Select CustomerID,Country
 From Northwind.Northwind.[Customers]
 Where (Country between 'B%' and 'H%') --cделал до 'H%' т.к. до 'G%' он не вносил Германию
 Order by Country

 /* 3.3 
 Выбрать всех заказчиков из таблицы Customers, у которых название страны начинается 
 на буквы из диапазона b и g, не используя оператор BETWEEN. 
 С помощью опции “Execution Plan” определить какой запрос предпочтительнее 3.2 или 3.3 – 
 для этого надо ввести в скрипт выполнение текстового Execution Plan-a для двух этих запросов, 
 результаты выполнения Execution Plan надо ввести в скрипт в виде комментария и по их результатам 
 дать ответ на вопрос – по какому параметру было проведено сравнение. Запрос должен высвечивать 
 только колонки CustomerID и Country и отсортирован по Country.
 */
 --Execution Plan 00:00:00.0600034
--Вариант 3.2 предпочтительнее 
Select CustomerID,Country
 From Northwind.Northwind.[Customers]
 Where Country Like '[B-H]%' --cделал до 'H%' т.к. до 'G%' он не вносил Германию
 Order by Country

 /* 4.1 
 В таблице Products найти все продукты (колонка ProductName), где встречается подстрока 'chocolade'. 
 Известно, что в подстроке 'chocolade' может быть изменена одна буква 'c' в середине - найти все 
 продукты, которые удовлетворяют этому условию. Подсказка: результаты запроса должны высвечивать 2 строки.
 
 */
 Select ProductName
 From Northwind.Northwind.Products
 Where ProductName Like '%cho_olade%'
 
 /*5.1 
 Найти общую сумму всех заказов из таблицы Order Details с учетом количества закупленных 
 товаров и скидок по ним. Результат округлить до сотых и высветить в стиле 1 для типа данных money. 
 Скидка (колонка Discount) составляет процент из стоимости для данного товара. 
 Для определения действительной цены на
 проданный продукт надо вычесть скидку из указанной в колонке UnitPrice цены. 
 Результатом запроса должна быть одна запись с одной колонкой с названием колонки 'Totals'.
 */
  Select Convert(money,Round(SUM(UnitPrice - UnitPrice * Discount),2)) as 'Totals'
 From Northwind.Northwind.[Order Details]

/*5.2 
По таблице Orders найти количество заказов, которые еще не были доставлены 
(т.е. в колонке ShippedDate нет значения даты доставки). 
Использовать при этом запросе только оператор COUNT. 
Не использовать предложения WHERE и GROUP.
*/
 Select COUNT(*) - COUNT(ShippedDate) as 'Not shipped' --Сделал так т.к. не понял как сделать по другому без WHERE или с помощью CASE т.п. (убил на пробы 1.5 часа)
From Northwind.Northwind.Orders

/* 5.3 
По таблице Orders найти количество различных покупателей (CustomerID), 
сделавших заказы. Использовать функцию COUNT и не использовать предложения WHERE и GROUP.
*/
Select COUNT(Distinct CustomerID) as 'Unic Orders'
From Northwind.Northwind.Orders

/* 6.1 
По таблице Orders найти количество заказов с группировкой по годам. В результатах запроса надо высвечивать две колонки c названиями Year и Total. 
Написать проверочный запрос, который вычисляет количество всех заказов.
*/
Select Count(*) as 'ALL ORDERS'
From Northwind.Northwind.Orders

Select Distinct YEAR(ShippedDate) as 'Year', COUNT(*) as 'Total'
From Northwind.Northwind.Orders
Group by YEAR(ShippedDate)

/* 6.2 
По таблице Orders найти количество заказов, cделанных каждым продавцом. 
Заказ для указанного продавца – это любая запись в таблице Orders, где в колонке EmployeeID 
задано значение для данного продавца. В результатах запроса надо высвечивать колонку с именем 
продавца (Должно высвечиваться имя полученное конкатенацией LastName & FirstName.
 Эта строка LastName & FirstName должна быть получена отдельным запросом в колонке основного запроса. 
 Также основной запрос должен использовать группировку по EmployeeID.) с названием колонки ‘Seller’ 
 и колонку c количеством заказов высвечивать с названием 'Amount'. Результаты запроса должны быть 
 упорядочены по убыванию количества заказов.
*/
Select Distinct Orders.EmployeeID as 'ID',
	(Select CONCAT(Employees.FirstName,Employees.LastName)
	From Northwind.Northwind.Employees
	Where Orders.EmployeeID = Employees.EmployeeID ) as 'Seller'
,Count(Orders.EmployeeID) as 'Amount'
From Northwind.Northwind.Orders--, Northwind.Northwind.Employees
Group by Orders.EmployeeID
Order by Amount DESC

/* 6.3 
По таблице Orders найти количество заказов, cделанных каждым продавцом и для каждого покупателя. 
Необходимо определить это только для заказов сделанных в 1998 году. В
 результатах запроса надо высвечивать колонку с именем продавца (название колонки ‘Seller’), 
 колонку с именем покупателя (название колонки ‘Customer’) и колонку c количеством заказов 
 высвечивать с названием 'Amount'. В запросе необходимо использовать специальный оператор языка 
 T-SQL для работы с выражением GROUP (Этот же оператор поможет выводить строку “ALL” в результатах запроса). 
 Группировки должны быть сделаны по ID продавца и покупателя. Результаты запроса должны быть упорядочены по продавцу, 
 покупателю и по убыванию количества продаж. В результатах должна быть сводная информация по продажам. 
 Т.е. в резульирующем наборе должны присутствовать дополнительно к информации о продажах продавца 
 для каждого покупателя следующие строчки:
*/
Select Case When Orders.EmployeeID is Null then 'ALL' else 
		(Select Employees.FirstName
		From Northwind.Northwind.Employees
		Where Orders.EmployeeID = Employees.EmployeeID )
	end as 'Seller'
,	Case When Orders.CustomerID is Null then 'ALL' else 
		(Select ContactName
		From Northwind.Northwind.Customers
		Where Orders.CustomerID = Customers.CustomerID) 
	end as 'Customer'
,Count(Orders.EmployeeID) as 'Amount'
From Northwind.Northwind.Orders--, Northwind.Northwind.Employees
Where YEAR(ShippedDate) = 1998
Group by ROLLUP (Orders.EmployeeID,Orders.CustomerID)
Order by Seller, Customer, Amount

/* 6.4

Найти покупателей и продавцов, которые живут в одном городе. 
Если в городе живут только один или несколько продавцов или только один или 
несколько покупателей, то информация о таких покупателя и продавцах не должна 
попадать в результирующий набор. Не использовать конструкцию JOIN. 
В результатах запроса необходимо вывести следующие заголовки для результатов запроса: 
‘Person’, ‘Type’ (здесь надо выводить строку ‘Customer’ или ‘Seller’ в завимости от типа записи), 
‘City’. Отсортировать результаты запроса по колонке ‘City’ и по ‘Person’.
*/
SELECT Customers.ContactName AS Person, 'Customer' AS Type,Customers.City AS City
FROM Northwind.Northwind.Customers
WHERE EXISTS (
              SELECT Employees.City 
              FROM Northwind.Northwind.Employees
              WHERE Employees.City=Customers.City
              )
UNION ALL
SELECT FirstName+' '+LastName AS Person, 'Seller' AS Type,City AS City
FROM Northwind.Northwind.Employees 
WHERE EXISTS (
              SELECT City 
              FROM Northwind.Northwind.Customers 
              WHERE Employees.City=Customers.City
              )
Order by City,Person

/* 6.5
Найти всех покупателей, которые живут в одном городе. 
В запросе использовать соединение таблицы Customers c собой - самосоединение. 
Высветить колонки CustomerID и City. Запрос не должен высвечивать дублируемые записи.
 Для проверки написать запрос, который высвечивает города, которые встречаются более одного раза в таблице Customers. 
 Это позволит проверить правильность запроса.
*/
Select Distinct cus1.CustomerID, cus2.City
From Northwind.Northwind.Customers cus1 join Northwind.Northwind.Customers cus2
	on cus1.CustomerID != cus2.CustomerID
where (cus1.City = cus2.City) and (cus1.CustomerID <> cus2.CustomerID)
Order by cus2.City,cus1.CustomerID

Select COUNT(*) as 'citizens', City
From Northwind.Northwind.Customers
Group by City
Having COUNT(*) > 1



/* 6.6 
По таблице Employees найти для каждого продавца его руководителя, т.е. кому он делает репорты. 
Высветить колонки с именами 'User Name' (LastName) и 'Boss'. В колонках должны быть
высвечены имена из колонки LastName. Высвечены ли все продавцы в этом запросе?
-- Нет. т.к. у Fuller отстутвует руководитель он будет отсутвовать и в таблице
*/
Select emp2.LastName as 'User Name',emp1.LastName as 'Boss'
From Northwind.Northwind.Employees emp1 join Northwind.Northwind.Employees emp2
	on emp1.EmployeeID = emp2.ReportsTo


/*7.1 
Определить продавцов, которые обслуживают регион 'Western' (таблица Region). Результаты запроса должны высвечивать два поля: 
'LastName' продавца и название обслуживаемой территории ('TerritoryDescription' из таблицы Territories). 
Запрос должен использовать JOIN в предложении FROM. 
Для определения связей между таблицами Employees и Territories надо использовать графические диаграммы для базы Northwind.
*/
Select Employees.LastName, Territories.TerritoryDescription 
From (Northwind.Northwind.Territories join Northwind.Northwind.EmployeeTerritories 
on (Territories.TerritoryID = EmployeeTerritories.TerritoryID)) join Northwind.Northwind.Employees
on (EmployeeTerritories.EmployeeID = Employees.EmployeeID)

/*8.1 
Высветить в результатах запроса имена всех заказчиков из таблицы Customers и суммарное
 количество их заказов из таблицы Orders. Принять во внимание, что у 
 некоторых заказчиков нет заказов, но они также должны быть выведены в 
 результатах запроса. Упорядочить результаты запроса по возрастанию количества заказов.

*/
 Select Customers.ContactName, COUNT(Orders.CustomerID) as 'Amount'
 From Northwind.Northwind.Customers full outer join Northwind.Northwind.Orders on Customers.CustomerID = Orders.CustomerID
 Group by Customers.ContactName

 /*9.1
 Высветить всех поставщиков колонка CompanyName в таблице Suppliers, 
 у которых нет хотя бы одного продукта на складе (UnitsInStock в таблице Products равно 0).
  Использовать вложенный SELECT для этого запроса с использованием оператора IN. 
  Можно ли использовать вместо оператора IN оператор '=' ?
 */
 -- Нет т.к. оператор = сравнивает только с 1 записью, не с целой коллекцией
  Select CompanyName
 From Northwind.Northwind.Suppliers
 where SupplierID in (
	Select SupplierID
	From Northwind.Northwind.Products
	Where UnitsInStock = 0)

/* 10.1 
Высветить всех продавцов, которые имеют более 150 заказов. Использовать вложенный коррелированный SELECT.
*/
 Select FirstName, LastName, EmployeeID
 From Northwind.Northwind.Employees 
 where 150 < (
	Select Count(EmployeeID)
	From Northwind.Northwind.Orders
	Where Employees.EmployeeID = Orders.EmployeeID
	Group by EmployeeID)

/*11.1 
Высветить всех заказчиков (таблица Customers), которые не имеют ни одного заказа (подзапрос по таблице Orders). 
Использовать коррелированный SELECT и оператор EXISTS
*/
Select ContactName, CustomerID
 From Northwind.Northwind.Customers
 where not Exists (
	Select Count(Orders.CustomerID)
	From Northwind.Northwind.Orders
	Where Customers.CustomerID = Orders.CustomerID
	Group by Orders.CustomerID)

/*12.1 
Для формирования алфавитного указателя Employees высветить из таблицы Employees список только тех букв алфавита, 
с которых начинаются фамилии Employees (колонка LastName ) из этой таблицы. Алфавитный список 
должен быть отсортирован по возрастанию.
*/
 Select (Left (LastName,1)) as 'Letters'
 From Northwind.Northwind.Employees
 Order by Letters

/* 13.1 !=
Написать процедуру, которая возвращает самый крупный заказ для каждого из продавцов за определенный год. 
В результатах не может быть несколько заказов одного продавца, должен быть только один и самый крупный. 
В результатах запроса должны быть выведены следующие колонки: колонка с именем и фамилией продавца 
(FirstName и LastName – пример: Nancy Davolio), номер заказа и его стоимость. 
В запросе надо учитывать Discount при продаже товаров. Процедуре передается год, за который надо 
сделать отчет, и количество возвращаемых записей. Результаты запроса должны быть упорядочены 
по убыванию суммы заказа. Процедура должна быть реализована с использованием оператора
SELECT и БЕЗ ИСПОЛЬЗОВАНИЯ КУРСОРОВ. Название функции соответственно GreatestOrders. 
Необходимо продемонстрировать использование этих процедур. Также помимо демонстрации вызовов процедур 
в скрипте Query.sql надо написать отдельный ДОПОЛНИТЕЛЬНЫЙ проверочный запрос для тестирования правильности 
работы процедуры GreatestOrders. Проверочный запрос должен выводить в удобном для сравнения с результатами 
работы процедур виде для определенного продавца для всех его заказов за определенный указанный год в 
результатах следующие колонки: имя продавца, номер заказа, сумму заказа. Проверочный запрос не должен 
повторять запрос, написанный в процедуре, - он должен выполнять только то, 
что описано в требованиях по нему. ВСЕ ЗАПРОСЫ ПО ВЫЗОВУ ПРОЦЕДУР ДОЛЖНЫ БЫТЬ НАПИСАНЫ В ФАЙЛЕ Query.sql
 – см. пояснение ниже в разделе «Требования к оформлению».
*/
	Select 2
	from dbo.GreatestOrders 
	Where n = 1998; 

	/* 13.2 !=
	Написать процедуру, которая возвращает заказы в таблице Orders, 
	согласно указанному сроку доставки в днях (разница между OrderDate и ShippedDate). 
	В результатах должны быть возвращены заказы, срок которых превышает переданное значение
	 или еще недоставленные заказы. Значению по умолчанию для передаваемого срока 35 дней. 
	 Название процедуры ShippedOrdersDiff. Процедура должна высвечивать следующие 
	 колонки: OrderID, OrderDate, ShippedDate, ShippedDelay (разность в днях между ShippedDate и OrderDate), 
	 SpecifiedDelay (переданное в процедуру значение). Необходимо продемонстрировать использование этой процедуры.
	*/

	EXECUTE dbo.ShippedOrdersDiff 35

	/* 13.3 !=
	Написать процедуру, которая высвечивает всех подчиненных заданного продавца, 
	как непосредственных, так и подчиненных его подчиненных. В качестве входного параметра 
	функции используется EmployeeID. Необходимо распечатать имена подчиненных и выровнять их в тексте 
	(использовать оператор PRINT) согласно иерархии подчинения. 
	Продавец, для которого надо найти подчиненных также должен быть высвечен. 
	Название процедуры SubordinationInfo. В качестве алгоритма для решения этой задачи 
	надо использовать пример, приведенный в Books Online и рекомендованный Microsoft для 
	решения подобного типа задач. Продемонстрировать использование процедуры.
	*/
	Select  distinct emp1.EmployeeID  as 'nas'
		,emp2.EmployeeID 'pod'
	From Northwind.Northwind.Employees emp1, Northwind.Northwind.Employees emp2  -- сделано для получения всех вариантов
		where emp2.EmployeeID in (
			Select emp2.EmployeeID
			From Northwind.Northwind.Employees emp3
			Where (emp1.EmployeeID = emp3.ReportsTo) or ((emp2.ReportsTo = emp1.EmployeeID) and (emp2.EmployeeID = emp3.ReportsTo))
		)
	Order by emp1.EmployeeID 
		 

	/* 13.4 !=
	Написать функцию, которая определяет, есть ли у продавца подчиненные. В
	озвращает тип данных BIT. В качестве входного параметра функции используется EmployeeID. 
	Название функции IsBoss. Продемонстрировать использование функции для всех продавцов из таблицы Employees.
	*/


	Select EmployeeID
	From Northwind.Northwind.Employees 
	Where dbo.IsBoss(EmployeeID)>2

	Select Count(Employees.EmployeeID)
	From Northwind.Northwind.Employees
	Where Employees.ReportsTo = 5