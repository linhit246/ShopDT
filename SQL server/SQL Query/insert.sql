USE [ShopDienThoai]
GO

INSERT INTO [dbo].[Category] ([name], [description])
VALUES
	(N'Iphone', N'Điện thoại iphone'),
	(N'Huawei', N'Điện thoại Huawei'),
	(N'Realme', N'Điện thoại realme'),
	(N'SamSung', N'Điện thoại samsung'),
	(N'Tablet', N'Máy tính bảng'),
	(N'Vivo', N'Điện thoại vivo'),
	(N'Vsmart', N'Điện thoại vsmart'),
	(N'Xiaomi', N'Điện thoại xiaomi')
GO

INSERT INTO [dbo].[Roles] ([name], [role])
VALUES
	(N'Xem sản phẩm', 1)
GO

INSERT INTO [dbo].[User] ([phone], [password], [name], [gender], [birthDay])
VALUES
	('0987654321', HASHBYTES('SHA2_256', 'admin'), N'Nguyễn Duy Linh', N'Nam', '2000/11/20')
GO

INSERT INTO [dbo].[UserRoles] ([userId], [roleId])
VALUES
	(1, 1)
GO

INSERT INTO [dbo].[Address] ([userId], [name], [phone], [city], [district], [address], [status])
VALUES
	(1, N'Nguyễn Duy Kiên', '0961525503', N'Hà Nội', N'Đan Phượng', N'Cụm 2 - Tân Lập', '1')
GO

INSERT INTO [dbo].[Product] ([name], [categoryId], [reliability], [description])
VALUES
	(N'Iphone 11', 1, '', N'Điện thoại iphone 11 với thiết kế sang trọng bắt mắt đặc biệt đánh thằng vào túi tiền với cái giá cắt cmn cổ!')
GO

INSERT INTO [dbo].[Comment] ([userId], [productId], [reliability], [comment], [commentDate], [imagePath], [status])
     VALUES
           (1, 1, 4.5, N'Hàng này đắt mà dùng ok phết.', GETDATE(), '', 1)
GO

INSERT INTO [dbo].[ProductDetail] ([productId], [productImage], [productColor], [storage], [number], [sellCost], [buyCost], [sale])
     VALUES
           (1, 'iPhone 11-1.jpg', 'Red', '64GB', 150, 19500000, 16000000, 10)
GO

INSERT INTO [dbo].[Specifications] ([productDetailId], [storage], [ram], [Fcamera], [Scamera], [cpu], [resolution], [battery], [os], [screenSize], [simNumber], [fastCharge], [SDcard])
     VALUES
           (1, '64GB', '4GB', 'Dual 12 MP', '12 MP', 'Apple A13 Bionic (7 nm+)', '828 x 1792 pixels', 'Li-Ion 3110mAh', 
		   'iOS 13', '6.1 inch', '1 nano SIM + 1 eSIM', '', '')
GO

INSERT INTO [dbo].[CodeTypes] ([name], [description])
     VALUES
           (N'Giảm trực tiếp', N'Giảm trực tiếp 1 số tiền nhất định nếu đạt điều kiện')
GO

INSERT INTO [dbo].[SaleCodes] ([codeTypeId], [code], [conditionSale], [startDate], [closedDate], [number], [description], [sale])
     VALUES
           (1, 'GG100K', N'Giảm 100.000 VNĐ với đơn hàng từ 3.000.000 trở lên.', '2020/11/01 00:00:00', '2020/12/01 00:00:00', 200, '', 100000)
GO

INSERT INTO [dbo].[ManagementSaleCode] ([userId], [saleCodeId], [status])
     VALUES
           (1, 1, 1)
GO

INSERT INTO [dbo].[Order] ([userId], [orderDate], [closedDate], [status], [saleCodeId], [totalMoney], [description])
     VALUES
           (1, '2020/11/05 09:25:00', '2020/11/07 09:25:00', 1, 1, 19400000, '')
GO

INSERT INTO [dbo].[OrderDetail] ([orderId], [productDetailId], [number], [totalMoney])
     VALUES
           (1, 1, 1, 19500000)
GO