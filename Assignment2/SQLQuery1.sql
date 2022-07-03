create database FStore_Ass2
go
use FStore_Ass2
go
create table tbl_Member
(
MemberId int primary key not null,
Email varchar(100) not null,
CompanyName varchar(40) not null,
City varchar(15) not null,
Country varchar(15) not null,
Password varchar(30) not null
)
Go
create table tbl_Order
(
OrderId int identity primary key not null,
MemberId int foreign key references tbl_Member(MemberId) not null,
OrderDate datetime not null,
RequiredDate datetime null,
ShippedDate datetime null,
Freight money not null
)
GO
create table tbl_Product
(
ProductId int primary key not null,
CategoryId int not null,
ProductName varchar(40) not null,
Weight varchar(20) not null,
UnitPrice money not null,
UnitslnStock int not null
)
Go
create table tbl_OrderDetail
(
OrderId int foreign key references tbl_Order(OrderId) not null,
ProductId int foreign key references tbl_Product(ProductId) not null,
UnitPrice money not null,
Quantity int not null,
Discount float not null
)
go

insert into tbl_Member (MemberId, Email, CompanyName, City, Country, Password) values (1, 'tung@gmail.com', N'Thanh Tùng', N'Hồ Chí Minh', 'Vietnam', '12345');
go
insert into tbl_Member (MemberId, Email, CompanyName, City, Country, Password) values (2, 'qdjokovic1@netlog.com', 'Photobug', N'Quế Sơn', 'Vietnam', '12345');
go
insert into tbl_Member (MemberId, Email, CompanyName, City, Country, Password) values (3, 'kmarrow2@cnet.com', 'Devshare', N'Chợ Chu', 'Vietnam', '12345');
go
insert into tbl_Member (MemberId, Email, CompanyName, City, Country, Password) values (4, 'lbarwack3@skype.com', 'Flashspan', N'Chư Ty', 'Vietnam', '12345');
go
insert into tbl_Member (MemberId, Email, CompanyName, City, Country, Password) values (5, 'bguilloton4@gov.uk', 'Vitz', N'Phú Túc', 'Vietnam', '12345');
go
insert into tbl_Member (MemberId, Email, CompanyName, City, Country, Password) values (6, 'rzecchii5@google.com.br', 'Babbleblab', N'Thị Trấn Mỹ Lộc', 'Vietnam', '12345');
go
insert into tbl_Member (MemberId, Email, CompanyName, City, Country, Password) values (7, 'mcassie6@vistaprint.com', 'Gevee', N'La Gi', 'Vietnam', '12345');
go
insert into tbl_Member (MemberId, Email, CompanyName, City, Country, Password) values (8, 'ldanihel7@ifeng.com', 'Rhycero', N'Thủ Thừa', 'Vietnam', '12345');
go
insert into tbl_Member (MemberId, Email, CompanyName, City, Country, Password) values (9, 'dferonet8@constantcontact.com', 'Layo', N'Trà Vinh', 'Vietnam', '12345');
go
insert into tbl_Member (MemberId, Email, CompanyName, City, Country, Password) values (10, 'vjiran9@issuu.com', 'Camido', N'Văn Giang', 'Vietnam', '12345');
go

insert into tbl_Product (ProductId, CategoryId, ProductName, Weight, UnitPrice, UnitslnStock) values (1,1,N'Product 1','250g',20000,20)
go
insert into tbl_Product (ProductId, CategoryId, ProductName, Weight, UnitPrice, UnitslnStock) values (2,1,N'Product 2','250g',20000,20)
go
insert into tbl_Product (ProductId, CategoryId, ProductName, Weight, UnitPrice, UnitslnStock) values (3,2,N'Product 3','350g',30000,20)
go
insert into tbl_Product (ProductId, CategoryId, ProductName, Weight, UnitPrice, UnitslnStock) values (4,2,N'Product 4','350g',30000,20)
go
insert into tbl_Product (ProductId, CategoryId, ProductName, Weight, UnitPrice, UnitslnStock) values (5,3,N'Product 5','450g',40000,20)
go
insert into tbl_Product (ProductId, CategoryId, ProductName, Weight, UnitPrice, UnitslnStock) values (6,3,N'Product 6','450g',40000,20)
go
