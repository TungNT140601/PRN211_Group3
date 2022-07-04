
drop database FStoreAssigment1 
go
create database FStoreAssigment1
go
use FStoreAssigment1
create table Member(
	MemberID int PRIMARY KEY not null,
	MemberName nvarchar(100) not null,
	Email nvarchar(100) not null,
	City nvarchar(15) not null,
	Country nvarchar(15) not null,
	Password nvarchar(30) not null,
)
go

INSERT INTO Member (MemberId, MemberName, Email, City,Country,Password)  VALUES (1, 'Tung', 'member1@gmail.com', 'HCM','VietNam','123');
go
INSERT INTO Member (MemberId, MemberName, Email, City,Country,Password)  VALUES (2, 'Vu', 'member2@gmail.com', 'Hai Phong','VietNam','123');
go
INSERT INTO Member (MemberId, MemberName, Email, City,Country,Password)  VALUES (3, 'Tu', 'member3@gmail.com', 'Hue','VietNam','123');
go
INSERT INTO Member (MemberId, MemberName, Email, City,Country,Password)  VALUES (4, 'Truong', 'member4@gmail.com', 'Binh Duong','VietNam','123');
go
INSERT INTO Member (MemberId, MemberName, Email, City,Country,Password)  VALUES (5, 'Tuong', 'member5@gmail.com', 'An Giang','VietNam','123');
go
INSERT INTO Member (MemberId, MemberName, Email, City,Country,Password)  VALUES (6, 'Nguyen', 'member6@gmail.com', 'Ben Tre','VietNam','123');
go
INSERT INTO Member (MemberId, MemberName, Email, City,Country,Password)  VALUES (7, 'Tuan', 'member7@gmail.com', 'Vung Tau','VietNam','123');
go
INSERT INTO Member (MemberId, MemberName, Email, City,Country,Password)  VALUES (8, 'Trang', 'member8@gmail.com', 'Da Lat','VietNam','123');
go
INSERT INTO Member (MemberId, MemberName, Email, City,Country,Password)  VALUES (9, 'Thien', 'member9@gmail.com', 'Nha Trang','VietNam','123');
go
INSERT INTO Member (MemberId, MemberName, Email, City,Country,Password)  VALUES (10, 'An', 'member10@gmail.com', 'Ha Noi','VietNam','123');
go

select * from Member