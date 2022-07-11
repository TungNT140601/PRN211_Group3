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





INSERT INTO tbl_Order ( MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES ( 1, convert(datetime,'18-06-12 10:34:09 PM',5),convert(datetime,'18-06-12 10:34:09 PM',5),convert(datetime,'18-06-12 10:34:09 PM',5),1);
go
INSERT INTO tbl_Order ( MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES ( 2, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order ( MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES ( 3, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order ( MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES ( 4, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order ( MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES ( 5, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order ( MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES ( 6, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order ( MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES ( 7, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order ( MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES ( 8, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order ( MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES ( 9, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order ( MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES ( 10, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order ( MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES ( 11, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order ( MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES ( 12, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order ( MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES ( 13, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order ( MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES ( 14, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order ( MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES ( 15, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order ( MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES ( 16, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go
INSERT INTO tbl_Order ( MemberId, OrderDate, RequiredDate,ShippedDate,Freight)  VALUES ( 17, convert(datetime,'18-06-12 10:34:09 PM',5),null,null,null);
go



INSERT INTO Product ( CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES ( 1, N'T-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product ( CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES ( 2, N'A-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product ( CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES ( 3, N'V-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product ( CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES ( 4, N'B-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product ( CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES ( 5, N'C-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product ( CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES ( 6, N'D-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product ( CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES ( 7, N'R-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product ( CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES ( 8, N'W-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product ( CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES ( 9, N'Q-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product ( CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES ( 10, N'S-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product ( CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES ( 11, N'T-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product ( CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES ( 12, N'T-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product ( CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES ( 13, N'T-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product ( CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES ( 14, N'T-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product ( CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES ( 15, N'T-shirt',2,'$ 0.0001',1);
go
INSERT INTO Product ( CategoryId, ProductName, Weight,UnitPrice,UnitInStock)  VALUES ( 16, N'T-shirt',2,'$ 0.0001',1);
go




INSERT INTO OrderDetail(OrderId, ProductId, UnitPrice, Quantity,Discount)  VALUES (101, 10001,2,1,1.1);
go
INSERT INTO OrderDetail(OrderId, ProductId, UnitPrice, Quantity,Discount)  VALUES (102, 10002,2,1,1.1);
go
INSERT INTO OrderDetail(OrderId, ProductId, UnitPrice, Quantity,Discount)  VALUES (103, 10003,2,1,1.1);
go
INSERT INTO OrderDetail(OrderId, ProductId, UnitPrice, Quantity,Discount)  VALUES (104, 10004,2,1,1.1);
go
INSERT INTO OrderDetail(OrderId, ProductId, UnitPrice, Quantity,Discount)  VALUES (105, 10005,2,1,1.1);
go
INSERT INTO OrderDetail(OrderId, ProductId, UnitPrice, Quantity,Discount)  VALUES (106, 10006,2,1,1.1);
go
INSERT INTO OrderDetail(OrderId, ProductId, UnitPrice, Quantity,Discount)  VALUES (107, 10007,2,1,1.1);
go
INSERT INTO OrderDetail(OrderId, ProductId, UnitPrice, Quantity,Discount)  VALUES (108, 10008,2,1,1.1);
go
INSERT INTO OrderDetail(OrderId, ProductId, UnitPrice, Quantity,Discount)  VALUES (109, 10009,2,1,1.1);
go
INSERT INTO OrderDetail(OrderId, ProductId, UnitPrice, Quantity,Discount)  VALUES (110, 10010,2,1,1.1);
go
INSERT INTO OrderDetail(OrderId, ProductId, UnitPrice, Quantity,Discount)  VALUES (111, 10011,2,1,1.1);
go
 select * from Member