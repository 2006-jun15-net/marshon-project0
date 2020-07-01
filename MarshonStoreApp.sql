/* Initialize Tables here

create table Customer(
	CustomerId int identity(1,1) not null,
	Firstname nvarchar(255) not null,
	Lastname nvarchar(255) not null,
	primary key(CustomerId)
);

create table Stores(
	StoreId int identity(1,1) not null,
	StoreName nvarchar(75) not null,
	StoreLocation nvarchar(75),
	primary key(StoreId),
);

CREATE TABLE Orders(
	OrderId int identity(1,1) not null,
	CustomerId int not null,
	OrderDate datetime2 default sysutcdatetime(),
	Cost money not null check(Cost > 0),
	StoreId int null,
	OrderInfo nvarchar(255) not null,
	primary key(OrderId),
	constraint FK_Orders_Customer_CustomerId foreign key(CustomerId) references Customer (CustomerId),
	constraint FK_Orders_Stores_StoreId foreign key(StoreId) references Stores (StoreId)
);


CREATE TABLE Products(
	ProductId int identity(1,1) not null,
	ProductName nvarchar(255) not null unique,
	ProductPrice money not null check(ProductPrice > 0),
	primary key(ProductId)
);

CREATE TABLE Inventory(
	StoreId int not null,
	ProductId int not null,
	Amount int not null check(Amount >= 0),
	constraint PK_Inventory_StoreId_ProductId primary key(StoreId, ProductId),
	constraint FK_Inventory_Stores_StoreId foreign key(StoreId) references Stores (StoreId),
	constraint FK_Inventory_Products_ProductId foreign key(ProductId) references Products (ProductId)
);

CREATE TABLE OrderHistory(
	OrderId int not null,
	ProductId int not null,
	Amount int check(Amount > 0),
	constraint PK_OrderHistory_OrderId_ProductId primary key(OrderId, ProductId),
	constraint FK_OrderHistory_Products_ProductId foreign key(ProductId) references Products (ProductId),
	constraint FK_OrderHistory_Orders_OrderId foreign key(OrderId) references Orders (OrderId)
);
*/


/**
insert into Products (ProductName, ProductPrice) values ('Phone', 200);
insert into Products (ProductName, ProductPrice) values ('Eraser', 2);
insert into Products (ProductName, ProductPrice) values ('Pencil', 1);
**/

/**
insert into Stores (StoreName, StoreLocation) values ('Mart1', 'Gaithersburg');
insert into Stores (StoreName, StoreLocation) values ('Mart2', 'New Market');
insert into Stores (StoreName, StoreLocation) values ('Mart3', 'Frederick');
**/

select * from Orders