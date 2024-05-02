--1. Create the database named "TechShop" 
CREATE DATABASE TechShop;
--Using the Techshop  DataBase
USE TechShop;
--2. Define the schema for the Customers, Products, Orders, OrderDetails and Inventory tables based on the provided schema. 
CREATE TABLE Customers(
CustomerId int not null primary key,
FirstName varchar(20) not null,
LastName varchar(20) not null,
email varchar(20) not null,
phone numeric not null,
Address varchar(20) not null
);

--creating the products table and adding primary key constraint

CREATE TABLE Products(
ProductId int not null primary key,
ProductName varchar(20) not null,
Description varchar(50) not null,
price float not null
);

--creating the orders table and adding primary key and foreign key constraints

CREATE TABLE Orders(
OrderID int not null primary key,
CustomerId int,
OrderDate datetime not null,
TotalAmount float not null,
foreign key(CustomerId) references Customers(CustomerId)
);

--creating the OrderDeatils table and adding primary key and foreign key constraints

CREATE TABLE OrderDetails(
OrderDetailId int not null primary key,
OrderId int,
ProductId int,
Quantity int not null,
foreign key(OrderId) references Orders(OrderId),
foreign key(ProductId) references Products(ProductId)
);

--creating the Inventory table and adding primary key and foreign key constraints


CREATE TABLE Inventory(
InventoryId int not null primary key,
ProductId int,
QuantityInStock int not null,
LackStockUpdate DateTime not null,
foreign key(ProductId) references Products(ProductId)
);

--4. Create appropriate Primary Key and Foreign Key constraints for referential integrity.

-- adding primary key for Customers Table
alter table Customers
add Constraint pk_customers_customerid
primary key CustomerId

--adding the unique key for the customer email
alter table Customers
add Constraint uk_customers_email
UNIQUE (email)

--adding primary key for Products Table
alter table Products
add Constraint pk_Products_productid
primary key ProductId

-- adding primary key for Orders Table
alter table Orders
add Constraint pk_orders_orderid
primary key OrderId

--adding foreign key constraint 
alter table Orders
add Constraint fk_orders_customerid
foreign key(CustomerId) references Customers(CustomerId) on delete cascade

-- adding primary key for OrderItems Table
alter table OrdersItems
add Constraint pk_ordersitems_orderitemsid
primary key OrderDetailId

--adding foreign key constraint 
alter table OrdersItems
add Constraint fk_ordersItems_orderid
foreign key(OrderId) references Orders(OrderId) on delete cascade,

alter table OrdersItems
add Constraint fk_ordersItems_productid
foreign key(ProductId) references Products(ProductId) on delete cascade

-- adding primary key for Inventory Table
alter table Inventory
add Constraint pk_inventory_inventoryid
primary key InventoryId
--adding foreign key constraint
alter table Inventory
add Constraint fk_Inventory_productid
foreign key(ProductId) references Products(ProductId) on delete cascade


/*5. Insert at least 10 sample records into each of the following tables. 
a. Customers 
b. Products 
c. Orders 
d. OrderDetails 
e. Inventory
*/
select * FROM Customers
--Inserting 10 records into customers table
insert into Customers
values(1,'jhon','deo','jhon@gmail.com',1234567890,'345-Newyork'),
(2,'rohith','sai','rohith@gmail.com',9394416682,'298-Tirupathi'),
(3,'sunil','ganesh','sunil@gmail.com',7013373120,'1-44 Banglore'),
(4,'sai','surya','sai@gmail.com',9652636425,'45/2-Chennai'),
(5,'varsith','sai','varsith@gmail.com',0123456788,'196-Newjersey'),
(6,'sanjana','muthineedi','sanjana@gmail.com',5624569454,'24589-canada'),
(7,'sowmya','sai','sowmya@gmail.com',5687945125,'596/12-Newyork'),
(8,'kundan','valli','kundan@gmail.com',9605827391,'589-Hyderabad'),
(9,'sai','ram','ram@gmail.com',9652636425,'12-45-Banglore'),
(10,'Uday','Kiran','Uday@gmail.com',9542841149,'58/chennai')

select * from Products
--inserting values into products table
insert into Products
values(01,'Laptop','high performance includes SSD',60000.99),
(02,'Smart Phone','Latestmodel with Dual camera',29000.56),
(03,'Tablet','Light Weight Long Battery',14000.99),
(04,'Headphone','Noise Cancelling HEadPhones',14900.9),
(05,'SmartWatch','Fitness Tracker with HEart Rate monitor',14999.9),
(06,'Desktop Computer',' gaming and multitasking',15000.89),
(07,'Digital Camera',' DSLR camera with interchangeable lenses',79000.99),
(08,'Wireless Earbuds','True wireless earbuds with touch controls',12900.99),
(09,'External Hard Drive','Portable hard drive with USB 3.0 connectivity',79000.99),
(10,'Bluetooth Speaker','speaker with waterproof design',49000.99)

--inserting into orders table
insert into Orders
values(1,1,'2024-04-25',14990.99),
(2,3,'2024-04-24',7990.99),
(3,2,'2024-04-23',6990.99),
(4,5,'2024-04-22',2990.99),
(5,4,'2024-04-21',12900.9),
(6,7,'2024-04-20',19900.99),
(7,6,'2024-04-19',14900.99),
(8,8,'2024-04-18',79090.99),
(9,9,'2024-04-17',4900.99),
(10,10,'2024-04-16',9990.99)

select * from Orders

--inserting values into Order Details Table
insert into OrderDetails
values(1,1,6,1),
(2,2,7,1),
(3,3,2,1),
(4,4,3,1),
(5,5,8,1),
(6,6,5,1),
(7,7,4,1),
(8,8,9,1),
(9,9,10,1),
(10,10,1,1)

select * from OrderDetails

--inserting values into inventory table 
insert into Inventory
values(1,1,20,GETDATE()),
(2,2,15,GETDATE()),
(3,3,10,GETDATE()),
(4,4,5,GETDATE()),
(5,5,30,GETDATE()),
(6,6,25,GETDATE()),
(7,7,8,GETDATE()),
(8,8,12,GETDATE()),
(9,9,18,GETDATE()),
(10,10,22,GETDATE())

select * from Inventory;
/*
Tasks 2: Select, Where, Between, AND, LIKE:  
1. Write an SQL query to retrieve the names and emails of all customers.  */

select concat(FirstName,concat(' ',LastName)) as [Name], email from Customers;

--2. Write an SQL query to list all orders with their order dates and corresponding customer names. 

select o.OrderId,o.OrderDate, concat(c.FirstName,concat(' ',c.LastName)) as Name from Orders o join Customers c
on
o.CustomerId=c.CustomerId


--3 Write an SQL query to insert a new customer record into the "Customers" table. Include customer information such as name
--, email, and address. 
insert into Customers
values(11,'sai','ganesh','ganesh@gmail.com',12345678910,'47-12 Tirupathi')

--4 Write an SQL query to update the prices of all electronic gadgets in the "Products" table by increasing them by 10%.

Update Products
set price=price * 1.10
where category='Electronic'

/*
5 Write an SQL query to delete a specific order and its associated order details from the 
"Orders" and "OrderDetails" tables. Allow users to input the order ID as a parameter. 
*/


Alter Table OrderDetails
add constraint fk_OrderItem_orderId
foreign key(OrderId) references Orders(OrderID) on delete cascade

declare @order_details int = 10;
delete from  Orders
where OrderID=@order_details


/*
6. Write an SQL query to insert a new order into the "Orders" table. Include the customer ID, 
order date, and any other necessary information
*/

insert into Orders
values(10,10,'2024-04-16',9990.99)

/*7. Write an SQL query to update the contact information (e.g., email and address) of a specific 
customer in the "Customers" table. Allow users to input the customer ID and new contact 
information.*/

declare @custmoreid int =11;
declare @email varchar(20) ='saiganesh@gmail.com'
declare @phone numeric=9966391914
declare @add varchar(25)='1/25 Tirupathi'

update Customers
set email=@email,
Phone=@phone,
Address = @add
where CustomerId=@custmoreid;

/*
8. Write an SQL query to recalculate and update the total cost of each order in the "Orders" 
table based on the prices and quantities in the "OrderDetails" table. 
*/

select * from Products
Select * from OrderDetails
select * from Orders

update Orders
set TotalAmount=(select sum(p.price*o.quantity) from Products p join OrderDetails o 
on p.ProductId=o.ProductId)
where OrderID in (select OrderID from OrderDetails)

/*
9.Write an SQL query to delete all orders and their associated order details for a specific 
customer from the "Orders" and "OrderDetails" tables. Allow users to input the customer ID 
as a parameter.
*/
declare @customerid int =7

Alter Table OrderDetails
add constraint fk_OrderItem_orderId
foreign key(OrderId) references Orders(OrderID) on delete cascade

delete from Orders
where CustomerId=@customerid;

select * from Orders
select * from OrderDetails

/*
10. Write an SQL query to insert a new electronic gadget product into the "Products" table, 
including product name, category, price, and any other relevant details. */
select * from Products

insert into Products
values(11,'VR Headset','stunning Visuals',450010.99)

/*
11. Write an SQL query to update the status of a specific order in the "Orders" table (e.g., from 
"Pending" to "Shipped"). Allow users to input the order ID and the new status.
*/
select * from Orders;

alter table Orders
add status varchar(20)

update Orders
set status='Pending'

alter table Orders
add constraint ck_Orders_Status
check (status in ('Pending','Processing','Shipped'))

update Orders
set status='Shipped'
where OrderId=7


/*12. Write an SQL query to calculate and update the number of orders placed by each customer 
in the "Customers" table based on the data in the "Orders" table. */

select * from Customers
select * from Orders
alter table Customers
add ordercount int;


UPDATE Customers
SET ordercount = (
    SELECT COUNT(*)
    FROM Orders
    WHERE Customers.CustomerId = Orders.CustomerId
    GROUP BY Orders.CustomerId
);




/*Task 3. Aggregate functions, Having, Order By, GroupBy and Joins:  
1. Write an SQL query to retrieve a list of all orders along with customer information (e.g., 
customer name) for each order.
*/
select o.OrderID, concat(c.FirstName,concat(' ',c.LastName)) as Name, c.email,c.[address]
from Orders o inner join Customers c on 
o.CustomerId=c.CustomerId
/*
2. Write an SQL query to find the total revenue generated by each electronic gadget product. 
Include the product name and the total revenue.
*/
select * from Products
select * from Orders

select p.ProductName, sum(p.price *o.quantity) as [Total Revenue] from Products p inner join OrderDetails o
on p.ProductId=o.OrderDetailID
group by ProductName


/*
3. Write an SQL query to list all customers who have made at least one purchase. Include their 
names and contact information. */
select * from Orders

select  concat(c.FirstName,concat(' ',c.LastName)) as Name, c.email,c.[Address],OrderID from Customers c join Orders o
on c.CustomerId=o.CustomerId

/*
4. Write an SQL query to find the most popular electronic gadget, which is the one with the highest 
total quantity ordered. Include the product name and the total quantity ordered. */
select top 1 p.ProductName,sum(o.Quantity) as TotalQuantity from Products p join OrderDetails o
on p.ProductId=o.ProductId
group by ProductName
order by sum(o.Quantity) desc 

/*
5. Write an SQL query to retrieve a list of electronic gadgets along with their corresponding 
categories. */
alter table products 
add category varchar(20)
select ProductName,category from Products
where category='Electronic'

/*
6. Write an SQL query to calculate the average order value for each customer. Include the 
customer's name and their average order value. */
select * from Orders
select * from Customers
select concat(c.FirstName,concat(' ',c.LastName)) as Name,avg(o.TotalAmount) from Customers c join Orders o 
on c.CustomerId=o.CustomerId
group by concat(c.FirstName,concat(' ',c.LastName))


/*
7. Write an SQL query to find the order with the highest total revenue. Include the order ID, 
customer information, and the total revenue. */

select  top 1 Orders.OrderId,concat(c.FirstName,concat(' ',c.LastName)) as name ,
c.email,c.[Address],sum(Products.price* OrderDetails.Quantity) as [Total Revenue] from Orders
join Customers c
on Orders.CustomerId=c.CustomerId
join OrderDetails
on OrderDetails.OrderId=Orders.OrderID
join Products
on Products.ProductId=OrderDetails.ProductId
group by Orders.OrderId,concat(c.FirstName,concat(' ',c.LastName)),c.email,c.[Address]
order by sum(Products.price* OrderDetails.Quantity) desc 

/*
8. Write an SQL query to list electronic gadgets and the number of times each product has been 
ordered. */
select * from orderDetails;
select * from Products

select ProductName,count(OrderDetails.OrderDetailId) as Ordered from OrderDetails join Products
on Products.ProductId=OrderDetails.ProductId
join 
Orders 
on OrderDetails.OrderId=Orders.OrderID
where Products.category='Electronic'
group by ProductName

/*
9. Write an SQL query to find customers who have purchased a specific electronic gadget product. 
Allow users to input the product name as a parameter. */

declare @productname varchar(20)='Smart Phone'

select distinct concat(c.FirstName,concat(' ',c.LastName)) from Customers c join Orders
on c.CustomerId=Orders.CustomerId
join 
OrderDetails on OrderDetails.OrderId=Orders.OrderID
join 
Products on OrderDetails.ProductId=Products.ProductId

where ProductName=@productname and Products.category='Electronic'


/*
10. Write an SQL query to calculate the total revenue generated by all orders placed within a 
specific time period. Allow users to input the start and end dates as parameters.
*/
declare @startdate datetime = '2024-04-17'
declare @enddate datetime = '2024-04-23'


select sum(Products.price*OrderDetails.Quantity) as [Total Revenue] from OrderDetails join Orders
on Orders.OrderID=OrderDetails.OrderId
join Products on 
Products.ProductId=OrderDetails.OrderId
where Orders.OrderDate Between @startdate and @enddate





/*

Task 4. Subquery and its type:  32
1. Write an SQL query to find out which customers have not placed any orders. */
select concat(FirstName,concat(' ',LastName)) as [Name] from Customers
where CustomerId not in (select Distinct CustomerId from Orders)
select * from Customers;


/*2. Write an SQL query to find the total number of products available for sale.  */
select ProductName from Products
where ProductId in (select ProductId from Inventory
where QuantityInStock>0)
order by ProductName

/*3. Write an SQL query to calculate the total revenue generated by TechShop.  */
select sum(TotalRevenue) as [Total Revenue] from(
select sum(Products.Price * OrderDetails.Quantity) as TotalRevenue from Orders join OrderDetails
on OrderDetails.OrderId=Orders.OrderID
join Products on Products.ProductId= OrderDetails.ProductId) as Reveneue


/*4. Write an SQL query to calculate the average quantity ordered for products in a specific category. 
Allow users to input the category name as a parameter. */

declare @category varcahr(20)='Electronic'
select avg(sub.averagequantity) as [Average Quantity Ordered] from(
select avg(OrderDetails.Quantity) as averagequantity from OrderDetails join Products 
on
OrderDetails.ProductId=Products.ProductId
where Products.category=@category) as sub;





/*5. Write an SQL query to calculate the total revenue generated by a specific customer. Allow users 
to input the customer ID as a parameter. */
declare @customerid int=2
select sum(sub.totalrevenue) as [Total Revenue] from(
select sum(Products.price * OrderDetails.Quantity) as totalrevenue from Orders join OrderDetails  on Orders.OrderId=OrderDetails.OrderId
join Products
on Products.ProductId=OrderDetails.ProductId
where CustomerId=@customerid) as sub



/*6. Write an SQL query to find the customers who have placed the most orders. List their names 
and the number of orders they've placed.*/

select  top 1 concat(c.FirstName,concat(' ',c.LastName)) as CustomerName,count(Orders.OrderID) as OrdersCount from Customers c 
left join Orders
on Orders.CustomerId=c.CustomerId
group by 
c.CustomerId,concat(c.FirstName,concat(' ',c.LastName))
order by OrdersCount desc



/*7. Write an SQL query to find the most popular product category, which is the one with the highest 
total quantity ordered across all orders.*/ 

select top 1  Products.ProductName,sum(OrderDetails.Quantity) as [Quantity Ordered] from Products join OrderDetails
on Products.ProductId=OrderDetails.ProductId
group by Products.ProductName
order by sum(OrderDetails.Quantity) desc

/*8. Write an SQL query to find the customer who has spent the most money (highest total revenue) 
on electronic gadgets. List their name and total spending. */
select top 1 concat(c.FirstName,concat(' ',c.LastName)),sum(Products.price* OrderDetails.Quantity) as [Total Revenue]
from Customers c join Orders
on Orders.CustomerId=c.CustomerId
join OrderDetails 
on OrderDetails.OrderId=Orders.OrderID
join Products on 
OrderDetails.ProductId=Products.ProductId
group by concat(c.FirstName,concat(' ',c.LastName))
order by sum(Products.price* OrderDetails.Quantity) desc

/*9. Write an SQL query to calculate the average order value (total revenue divided by the number of 
orders) for all customers.*/

select concat(c.FirstName,concat(' ',c.LastName)),(sum(Products.price* OrderDetails.Quantity)/count(Orders.OrderID))
as [Average Order Value] from Customers c join Orders
on Orders.CustomerId=c.CustomerId
join OrderDetails 
on OrderDetails.OrderId=Orders.OrderID
join Products on 
OrderDetails.ProductId=Products.ProductId

group by concat(c.FirstName,concat(' ',c.LastName))
order by (sum(Products.price* OrderDetails.Quantity)/count(Orders.OrderID)) desc


/*10. Write an SQL query to find the total number of orders placed by each customer and list their 
names along with the order count.*/

select concat(c.FirstName,concat(' ',c.LastName)) as CustomerName,count(Orders.OrderID) as OrdersCount from Customers c 
left join Orders
on Orders.CustomerId=c.CustomerId
group by 
c.CustomerId,concat(c.FirstName,concat(' ',c.LastName))
order by OrdersCount