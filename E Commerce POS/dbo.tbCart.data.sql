SET IDENTITY_INSERT [dbo].[tbCart] ON
INSERT INTO [dbo].[tbCart] ([Id], [transactionnumber], [price], [discpercent], [disc], [total], [saledate], [status], [cashier], [reg]) VALUES (12, N'202207151001', CAST(18000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(18000.00 AS Decimal(18, 2)), N'2022-07-13', N'pending', N'Name And Role', N'11lm720')
SET IDENTITY_INSERT [dbo].[tbCart] OFF
