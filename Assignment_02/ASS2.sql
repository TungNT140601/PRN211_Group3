drop database FStore
 go
create database FStore
go
use FStore
create table Member(
	MemberId int PRIMARY KEY not null,
	Email nvarchar(100) not null,
	Companyname nvarchar(40) not null,
	City nvarchar(15) not null,
	Country nvarchar(15) not null,
	Password nvarchar(30) not null
)
go
create table tbl_Order(
	OrderId int IDENTITY(101,1) PRIMARY KEY not null,
	MemberId int not null FOREIGN KEY REFERENCES Member(MemberId),
	OrderDate datetime not null,
	RequiredDate datetime null,
	ShippedDate datetime  null,
	Freight money null
)
go
create table Product(
	ProductId int IDENTITY(10001,1) PRIMARY KEY,
	CategoryId int not null,
	ProductName nvarchar(40) not null,
	Weight nvarchar(20) not null,
	UnitPrice money not null,
	UnitInStock int not null
)
go
create table OrderDetail(
	OrderId int FOREIGN KEY REFERENCES tbl_Order(OrderId) not null,
	ProductId int FOREIGN KEY REFERENCES Product(ProductId) not null,
	UnitPrice money not null,
	Quantity int not null,
	Discount float not null
)
go


INSERT INTO Member (MemberId, Email, Companyname, City,Country,Password)  VALUES (1, 'member1@gmail.com', 'company1','HCM','VietNam','123');
go
INSERT INTO Member (MemberId, Email, Companyname, City,Country,Password)  VALUES (2, 'member2@gmail.com', 'company1','HCM','VietNam','123');
go
INSERT INTO Member (MemberId, Email, Companyname, City,Country,Password)  VALUES (3, 'member3@gmail.com', 'company1','HCM','VietNam','123');
go
INSERT INTO Member (MemberId, Email, Companyname, City,Country,Password)  VALUES (4, 'member4@gmail.com', 'company1','HCM','VietNam','123');
go
INSERT INTO Member (MemberId, Email, Companyname, City,Country,Password)  VALUES (5, 'member5@gmail.com', 'company1','HCM','VietNam','123');
go
INSERT INTO Member (MemberId, Email, Companyname, City,Country,Password)  VALUES (6, 'member6@gmail.com', 'company1','HCM','VietNam','123');
go
INSERT INTO Member (MemberId, Email, Companyname, City,Country,Password)  VALUES (7, 'member7@gmail.com', 'company1','HCM','VietNam','123');
go
INSERT INTO Member (MemberId, Email, Companyname, City,Country,Password)  VALUES (8, 'member8@gmail.com', 'company1','HCM','VietNam','123');
go
INSERT INTO Member (MemberId, Email, Companyname, City,Country,Password)  VALUES (9, 'member9@gmail.com', 'company1','HCM','VietNam','123');
go
INSERT INTO Member (MemberId, Email, Companyname, City,Country,Password)  VALUES (10, 'member10@gmail.com', 'company1','HCM','VietNam','123');
go
INSERT INTO Member (MemberId, Email, Companyname, City,Country,Password)  VALUES (11, 'member11@gmail.com', 'company1','HCM','VietNam','123');
go
INSERT INTO Member (MemberId, Email, Companyname, City,Country,Password)  VALUES (12, 'member12@gmail.com', 'company1','HCM','VietNam','123');
go
INSERT INTO Member (MemberId, Email, Companyname, City,Country,Password)  VALUES (13, 'member13@gmail.com', 'company1','HCM','VietNam','123');
go
INSERT INTO Member (MemberId, Email, Companyname, City,Country,Password)  VALUES (14, 'member15@gmail.com', 'company1','HCM','VietNam','123');
go
INSERT INTO Member (MemberId, Email, Companyname, City,Country,Password)  VALUES (15, 'member17@gmail.com', 'company1','HCM','VietNam','123');
go
INSERT INTO Member (MemberId, Email, Companyname, City,Country,Password)  VALUES (16, 'member16@gmail.com', 'company1','HCM','VietNam','123');
go
INSERT INTO Member (MemberId, Email, Companyname, City,Country,Password)  VALUES (17, 'member17@gmail.com', 'company1','HCM','VietNam','123');
go
INSERT INTO Member (MemberId, Email, Companyname, City,Country,Password)  VALUES (18, 'member18@gmail.com', 'company1','HCM','VietNam','123');
go
INSERT INTO Member (MemberId, Email, Companyname, City,Country,Password)  VALUES (19, 'member19@gmail.com', 'company1','HCM','VietNam','123');
go
INSERT INTO Member (MemberId, Email, Companyname, City,Country,Password)  VALUES (20, 'member20@gmail.com', 'company1','HCM','VietNam','123');
go




INSERT INTO tbl_Order (OrderId, MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES (10001, 1, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order (OrderId, MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES (10002, 2, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order (OrderId, MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES (10003, 3, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order (OrderId, MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES (10004, 4, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order (OrderId, MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES (10005, 5, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order (OrderId, MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES (10006, 6, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order (OrderId, MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES (10007, 7, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order (OrderId, MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES (10008, 8, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order (OrderId, MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES (10009, 9, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order (OrderId, MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES (10010, 10, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order (OrderId, MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES (10011, 11, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order (OrderId, MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES (10012, 12, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order (OrderId, MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES (10013, 13, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order (OrderId, MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES (10014, 14, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order (OrderId, MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES (10015, 15, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order (OrderId, MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES (10016, 16, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order (OrderId, MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES (10017, 17, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go


INSERT INTO Product (ProductId, CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES (101, 1, N'T-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product (ProductId, CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES (102, 2, N'A-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product (ProductId, CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES (103, 3, N'V-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product (ProductId, CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES (104, 4, N'B-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product (ProductId, CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES (105, 5, N'C-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product (ProductId, CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES (106, 6, N'D-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product (ProductId, CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES (107, 7, N'R-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product (ProductId, CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES (108, 8, N'W-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product (ProductId, CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES (109, 9, N'Q-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product (ProductId, CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES (110, 10, N'S-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product (ProductId, CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES (111, 11, N'T-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product (ProductId, CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES (112, 12, N'T-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product (ProductId, CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES (113, 13, N'T-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product (ProductId, CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES (114, 14, N'T-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product (ProductId, CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES (115, 15, N'T-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product (ProductId, CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES (116, 16, N'T-shirt',2,'$ 0.0001',1);
go




INSERT INTO OrderDetail(OrderId, ProductId, UnitPrice, Quantity,Discount)  VALUES (10001, 101,2,1,1.1);
go
INSERT INTO OrderDetail(OrderId, ProductId, UnitPrice, Quantity,Discount)  VALUES (10002, 102,2,1,1.1);
go
INSERT INTO OrderDetail(OrderId, ProductId, UnitPrice, Quantity,Discount)  VALUES (10003, 103,2,1,1.1);
go
INSERT INTO OrderDetail(OrderId, ProductId, UnitPrice, Quantity,Discount)  VALUES (10004, 104,2,1,1.1);
go
INSERT INTO OrderDetail(OrderId, ProductId, UnitPrice, Quantity,Discount)  VALUES (10005, 105,2,1,1.1);
go
INSERT INTO OrderDetail(OrderId, ProductId, UnitPrice, Quantity,Discount)  VALUES (10006, 106,2,1,1.1);
go
INSERT INTO OrderDetail(OrderId, ProductId, UnitPrice, Quantity,Discount)  VALUES (10007, 107,2,1,1.1);
go
INSERT INTO OrderDetail(OrderId, ProductId, UnitPrice, Quantity,Discount)  VALUES (10008, 108,2,1,1.1);
go
INSERT INTO OrderDetail(OrderId, ProductId, UnitPrice, Quantity,Discount)  VALUES (10009, 109,2,1,1.1);
go
INSERT INTO OrderDetail(OrderId, ProductId, UnitPrice, Quantity,Discount)  VALUES (10010, 110,2,1,1.1);
go
INSERT INTO OrderDetail(OrderId, ProductId, UnitPrice, Quantity,Discount)  VALUES (10011, 111,2,1,1.1);
go






