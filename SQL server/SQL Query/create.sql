create database ShopDienThoai
on primary
(
	name = "ShopDienThoai",
	filename = "D:\Do An TN\SQL server\ShopDienThoai.mdf"
)
log on
(
	name = "ShopDienThoai_log",
	filename = "D:\Do An TN\SQL server\ShopDienThoai.ldf"
)
go

use ShopDienThoai
go

create table Categories
(
	id int primary key identity(1,1),
	name nvarchar(100) not null,
	description nvarchar(500),
	isDelete bit default 0,
	isDisplay bit default 1,
	lastUpdate datetime default GETDATE()
)
go

create table Roles
(
	id int primary key identity(1,1),
	name nvarchar(100) not null,
	role int not null,
	isDelete bit default 0,
	isDisplay bit default 1,
	lastUpdate datetime default GETDATE()
)
go

create table Users
(
	id int primary key identity(1,1),
	username varchar(255) not null,
	password varchar(255) not null,
	avatar nvarchar(255) default 'user.jpg',
	firstName nvarchar(50) not null,
	lastName nvarchar(50) not null,
	gender nvarchar(5),
	birthDay date,
	isDelete bit default 0,
	isDisplay bit default 1,
	lastUpdate datetime default GETDATE()
)
go

create table UserRoles
(
	id int primary key identity(1,1),
	userId int not null,
	roleId int not null,
	foreign key (userId) references Users (id),
	foreign key (roleId) references Roles (id)
)
go

create table Address
(
	id int primary key identity(1,1),
	userId int not null,
	firstName nvarchar(50) not null,
	lastName nvarchar(50) not null,
	phone varchar(10) not null,
	city nvarchar(50) not null,
	district nvarchar(50) not null,
	address nvarchar(100) not null,
	status bit default 0,
	isDelete bit default 0,
	isDisplay bit default 1,
	lastUpdate datetime default GETDATE()
	foreign key (userId) references Users (id)
)
go

create table Products
(
	id int primary key identity(1,1),
	name nvarchar(100) not null,
	categoryId int not null,
	imagePath nvarchar(max),
	sellCost float,
	isDelete bit default 0,
	isDisplay bit default 1,
	lastUpdate datetime default GETDATE(),
	foreign key (categoryId) references Categories (id)
)
go

create table Comments
(
	id int primary key identity(1,1),
	userId int not null,
	productId int not null,
	reliability float not null,
	content nvarchar(500),
	commentDate datetime not null default GETDATE(),
	imagePath nvarchar(255),
	status bit not null default 0,
	foreign key (userId) references Users (id),
	foreign key (productId) references Products (id)
)
go

create table ProductDetails
(
	id int primary key identity(1,1),
	productId int not null,
	quantity int not null,
	productColor nvarchar(50),
	imagePath nvarchar(max),
	isDelete bit default 0,
	isDisplay bit default 1,
	lastUpdate datetime default GETDATE(),
	foreign key (productId) references Products (id)
)
go

create table Specifications
(
	id int primary key,
	storage varchar(10),
	ram varchar(10),
	Fcamera nvarchar(50),
	Scamera nvarchar(50),
	cpu nvarchar(50),
	resolution varchar(20),
	battery varchar(50),
	os varchar(50),
	screenSize nvarchar(50),
	simNumber varchar(50),
	fastCharge nvarchar(50),
	SDcard nvarchar(50),
	lastUpdate datetime default GETDATE(),
	foreign key (id) references Products (id)
)
go

create table CodeTypes
(
	id int primary key identity(1,1),
	name nvarchar(255) not null,
	description nvarchar(255),
	isDelete bit default 0,
	isDisplay bit default 1,
	lastUpdate datetime default GETDATE()
)
go

create table SaleCodes
(
	id int primary key identity(1,1),
	codeTypeId int not null,
	code varchar(10) not null,
	conditionSale nvarchar(100),
	startDate datetime,
	closedDate datetime,
	quantity int not null,
	description nvarchar(500),
	sale float not null,
	isDelete bit default 0,
	isDisplay bit default 1,
	lastUpdate datetime default GETDATE()
	foreign key (codetypeId) references CodeTypes (id)
)
go

create table ManagementSaleCodes
(
	id int primary key identity(1,1),
	userId int not null,
	saleCodeId int not null,
	status bit not null default 1,
	foreign key (userId) references Users (id),
	foreign key (saleCodeId) references SaleCodes (id)
)
go

create table Orders
(
	id int primary key identity(1,1),
	userId int,
	fullName nvarchar(50),
	phone varchar(10),
	address nvarchar(255),
	orderDate datetime not null default GETDATE(),
	closedDate datetime,
	status bit not null default 0,
	saleCodeId int,
	total float not null,
	isDelete bit default 0,
	isDisplay bit default 1,
	lastUpdate datetime default GETDATE(),
	foreign key (userId) references Users (id)
)
go

create table OrderDetails
(
	id int primary key identity(1,1),
	orderId int not null,
	productDetailId int not null,
	quantity int not null,
	total float not null,
	isDelete bit default 0,
	isDisplay bit default 1,
	lastUpdate datetime default GETDATE(),
	foreign key (orderId) references Orders (id),
	foreign key (productDetailId) references ProductDetails (id)
)
go

create table ReceivedManagements
(
	id int primary key identity(1,1),
	productName nvarchar(100) not null,
	categoryName nvarchar(100) not null,
	receiptDate datetime not null default GETDATE(),
	unit nvarchar(10)not null,
	quantity int not null,
	buyCost float not null,
	total float not null,
	isDelete bit default 0,
	isDisplay bit default 1,
	lastUpdate datetime default GETDATE(),
)
go