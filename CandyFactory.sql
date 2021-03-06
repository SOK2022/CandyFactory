USE [CandyFactory]
GO
/****** Object:  Table [dbo].[Boxes]    Script Date: 23.06.2021 15:16:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Boxes](
	[BoxId] [int] IDENTITY(1,1) NOT NULL,
	[BoxWeight] [float] NULL,
	[BoxName] [nchar](50) NOT NULL,
	[CandyId] [int] NULL,
 CONSTRAINT [PK_Boxes] PRIMARY KEY CLUSTERED 
(
	[BoxId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Candies]    Script Date: 23.06.2021 15:16:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Candies](
	[CandyId] [int] IDENTITY(1,1) NOT NULL,
	[CandyName] [nchar](50) NULL,
 CONSTRAINT [PK_Candies] PRIMARY KEY CLUSTERED 
(
	[CandyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComponentOrder]    Script Date: 23.06.2021 15:16:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComponentOrder](
	[OrderId] [int] NOT NULL,
	[ComponentId] [int] NOT NULL,
	[ComponentAmount] [float] NULL,
	[OrderSum] [money] NULL,
	[OrderData] [date] NULL,
	[BasedOrderId] [int] NOT NULL,
	[ComponentName] [nchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComponentOrders]    Script Date: 23.06.2021 15:16:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComponentOrders](
	[ComponentOrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerOrderId] [int] NOT NULL,
	[ComponentId] [int] NOT NULL,
	[ComponentName] [nchar](50) NULL,
	[ComponentAmount] [float] NULL,
	[CounterpartyId] [int] NOT NULL,
	[CounterpartyName] [nchar](50) NULL,
	[OrderSum] [real] NULL,
	[OrderDate] [date] NULL,
 CONSTRAINT [PK_ComponentOrders] PRIMARY KEY CLUSTERED 
(
	[ComponentOrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Components]    Script Date: 23.06.2021 15:16:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Components](
	[ComponentId] [int] IDENTITY(1,1) NOT NULL,
	[ComponentName] [nchar](50) NULL,
	[CounterpartyId] [int] NOT NULL,
	[Price] [real] NULL,
	[CounterpartyName] [nchar](50) NULL,
 CONSTRAINT [PK_Components] PRIMARY KEY CLUSTERED 
(
	[ComponentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compositions]    Script Date: 23.06.2021 15:16:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compositions](
	[CompositionId] [int] IDENTITY(1,1) NOT NULL,
	[CandyId] [int] NOT NULL,
	[CandyName] [nchar](50) NULL,
	[ComponentId] [int] NOT NULL,
	[ComponentName] [nchar](50) NULL,
	[ComponentAmount] [float] NULL,
 CONSTRAINT [PK_Composition] PRIMARY KEY CLUSTERED 
(
	[CompositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Counterparties]    Script Date: 23.06.2021 15:16:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Counterparties](
	[CounterpartyId] [int] IDENTITY(1,1) NOT NULL,
	[CounterpartyName] [nchar](50) NULL,
	[Address] [nchar](50) NULL,
	[PhoneNumber] [int] NULL,
 CONSTRAINT [PK_Counterparties] PRIMARY KEY CLUSTERED 
(
	[CounterpartyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerOrder]    Script Date: 23.06.2021 15:16:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerOrder](
	[BoxId] [int] NOT NULL,
	[BoxesAmount] [int] NULL,
	[OrderId] [int] NOT NULL,
	[OrderSum] [money] NULL,
	[OrderData] [date] NULL,
	[BoxName] [nchar](50) NULL,
	[BoxWeight] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerOrders]    Script Date: 23.06.2021 15:16:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerOrders](
	[CustomerOrderId] [int] IDENTITY(1,1) NOT NULL,
	[BoxId] [int] NOT NULL,
	[BoxName] [nchar](50) NULL,
	[BoxWeight] [float] NULL,
	[BoxAmount] [int] NULL,
	[CounterpartyId] [int] NOT NULL,
	[CounterpartyName] [nchar](50) NULL,
	[OrderSum] [real] NULL,
	[OrderDate] [date] NULL,
 CONSTRAINT [PK_CustomerOrders] PRIMARY KEY CLUSTERED 
(
	[CustomerOrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 23.06.2021 15:16:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CounterpartyId] [int] NOT NULL,
	[OrderType] [nchar](50) NULL,
	[CounterpartyName] [nchar](50) NULL,
	[OrderTypeId] [int] NULL,
 CONSTRAINT [PK_Orders_1] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderTypes]    Script Date: 23.06.2021 15:16:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderTypes](
	[OrderTypeId] [int] IDENTITY(1,1) NOT NULL,
	[OrderType] [nchar](50) NULL,
 CONSTRAINT [PK_OrderTypes] PRIMARY KEY CLUSTERED 
(
	[OrderTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Boxes] ON 

INSERT [dbo].[Boxes] ([BoxId], [BoxWeight], [BoxName], [CandyId]) VALUES (3017, 8, N'Коркунов                                          ', 4)
INSERT [dbo].[Boxes] ([BoxId], [BoxWeight], [BoxName], [CandyId]) VALUES (3018, 10, N'Коркунов                                          ', 6)
INSERT [dbo].[Boxes] ([BoxId], [BoxWeight], [BoxName], [CandyId]) VALUES (4019, 7, N'Toffifee                                          ', 4)
INSERT [dbo].[Boxes] ([BoxId], [BoxWeight], [BoxName], [CandyId]) VALUES (5020, 8, N'Мерси                                             ', 1)
INSERT [dbo].[Boxes] ([BoxId], [BoxWeight], [BoxName], [CandyId]) VALUES (6020, 80, N'Мерси                                             ', 1)
INSERT [dbo].[Boxes] ([BoxId], [BoxWeight], [BoxName], [CandyId]) VALUES (8020, 8, N'Ассорти                                           ', 1)
INSERT [dbo].[Boxes] ([BoxId], [BoxWeight], [BoxName], [CandyId]) VALUES (9020, 66, N'апркап                                            ', 6)
SET IDENTITY_INSERT [dbo].[Boxes] OFF
SET IDENTITY_INSERT [dbo].[Candies] ON 

INSERT [dbo].[Candies] ([CandyId], [CandyName]) VALUES (1, N'Мерси                                             ')
INSERT [dbo].[Candies] ([CandyId], [CandyName]) VALUES (2, N'Рафаэлло                                          ')
INSERT [dbo].[Candies] ([CandyId], [CandyName]) VALUES (3, N'Ferrero Rocher                                    ')
INSERT [dbo].[Candies] ([CandyId], [CandyName]) VALUES (4, N'Toffifee                                          ')
INSERT [dbo].[Candies] ([CandyId], [CandyName]) VALUES (5, N'Алёнка                                            ')
INSERT [dbo].[Candies] ([CandyId], [CandyName]) VALUES (6, N'Коркунов                                          ')
INSERT [dbo].[Candies] ([CandyId], [CandyName]) VALUES (7, N'Киндер                                            ')
INSERT [dbo].[Candies] ([CandyId], [CandyName]) VALUES (8013, N'Бабаевский                                        ')
SET IDENTITY_INSERT [dbo].[Candies] OFF
SET IDENTITY_INSERT [dbo].[ComponentOrders] ON 

INSERT [dbo].[ComponentOrders] ([ComponentOrderId], [CustomerOrderId], [ComponentId], [ComponentName], [ComponentAmount], [CounterpartyId], [CounterpartyName], [OrderSum], [OrderDate]) VALUES (5002, 7002, 3, NULL, 40, 3, NULL, 4000, CAST(N'2021-05-14' AS Date))
INSERT [dbo].[ComponentOrders] ([ComponentOrderId], [CustomerOrderId], [ComponentId], [ComponentName], [ComponentAmount], [CounterpartyId], [CounterpartyName], [OrderSum], [OrderDate]) VALUES (5003, 7002, 1, NULL, 80, 1, NULL, 6400, CAST(N'2021-05-14' AS Date))
INSERT [dbo].[ComponentOrders] ([ComponentOrderId], [CustomerOrderId], [ComponentId], [ComponentName], [ComponentAmount], [CounterpartyId], [CounterpartyName], [OrderSum], [OrderDate]) VALUES (6002, 8004, 4, NULL, 400, 4, NULL, 28000, CAST(N'2021-05-14' AS Date))
INSERT [dbo].[ComponentOrders] ([ComponentOrderId], [CustomerOrderId], [ComponentId], [ComponentName], [ComponentAmount], [CounterpartyId], [CounterpartyName], [OrderSum], [OrderDate]) VALUES (6003, 8004, 6, NULL, 100, 1, NULL, 5000, CAST(N'2021-05-14' AS Date))
INSERT [dbo].[ComponentOrders] ([ComponentOrderId], [CustomerOrderId], [ComponentId], [ComponentName], [ComponentAmount], [CounterpartyId], [CounterpartyName], [OrderSum], [OrderDate]) VALUES (6004, 8004, 3, NULL, 200, 3, NULL, 20000, CAST(N'2021-05-14' AS Date))
SET IDENTITY_INSERT [dbo].[ComponentOrders] OFF
SET IDENTITY_INSERT [dbo].[Components] ON 

INSERT [dbo].[Components] ([ComponentId], [ComponentName], [CounterpartyId], [Price], [CounterpartyName]) VALUES (1, N'Стружка кокосовая                                 ', 1, 80, NULL)
INSERT [dbo].[Components] ([ComponentId], [ComponentName], [CounterpartyId], [Price], [CounterpartyName]) VALUES (2, N'Молоко Обезжиренное                               ', 2, 120, NULL)
INSERT [dbo].[Components] ([ComponentId], [ComponentName], [CounterpartyId], [Price], [CounterpartyName]) VALUES (3, N'Сыворотка молочная                                ', 3, 100, NULL)
INSERT [dbo].[Components] ([ComponentId], [ComponentName], [CounterpartyId], [Price], [CounterpartyName]) VALUES (4, N'Мука пшеничная                                    ', 4, 70, NULL)
INSERT [dbo].[Components] ([ComponentId], [ComponentName], [CounterpartyId], [Price], [CounterpartyName]) VALUES (6, N'Сахар                                             ', 1, 50, NULL)
SET IDENTITY_INSERT [dbo].[Components] OFF
SET IDENTITY_INSERT [dbo].[Compositions] ON 

INSERT [dbo].[Compositions] ([CompositionId], [CandyId], [CandyName], [ComponentId], [ComponentName], [ComponentAmount]) VALUES (0, 1, N'Мерси                                             ', 3, N'Сыворотка молочная                                ', 5)
INSERT [dbo].[Compositions] ([CompositionId], [CandyId], [CandyName], [ComponentId], [ComponentName], [ComponentAmount]) VALUES (2, 1, N'Мерси                                             ', 1, N'Стружка кокосовая                                 ', 10)
INSERT [dbo].[Compositions] ([CompositionId], [CandyId], [CandyName], [ComponentId], [ComponentName], [ComponentAmount]) VALUES (1003, 6, N'Коркунов                                          ', 4, N'Мука пшеничная                                    ', 20)
INSERT [dbo].[Compositions] ([CompositionId], [CandyId], [CandyName], [ComponentId], [ComponentName], [ComponentAmount]) VALUES (2002, 6, N'Коркунов                                          ', 6, N'Сахар                                             ', 5)
INSERT [dbo].[Compositions] ([CompositionId], [CandyId], [CandyName], [ComponentId], [ComponentName], [ComponentAmount]) VALUES (2003, 6, N'Коркунов                                          ', 3, N'Сыворотка молочная                                ', 10)
SET IDENTITY_INSERT [dbo].[Compositions] OFF
SET IDENTITY_INSERT [dbo].[Counterparties] ON 

INSERT [dbo].[Counterparties] ([CounterpartyId], [CounterpartyName], [Address], [PhoneNumber]) VALUES (1, N'ООО "Вектор"                                      ', N'Екатеринбург                                      ', 677)
INSERT [dbo].[Counterparties] ([CounterpartyId], [CounterpartyName], [Address], [PhoneNumber]) VALUES (2, N'ООО "Заказчик"                                    ', N'Москва                                            ', 456)
INSERT [dbo].[Counterparties] ([CounterpartyId], [CounterpartyName], [Address], [PhoneNumber]) VALUES (3, N'OOO "Klient"                                      ', N'Sankt-Peterburg                                   ', NULL)
INSERT [dbo].[Counterparties] ([CounterpartyId], [CounterpartyName], [Address], [PhoneNumber]) VALUES (4, N'OOO "Proizvoditel"                                ', N'Volgograd                                         ', NULL)
INSERT [dbo].[Counterparties] ([CounterpartyId], [CounterpartyName], [Address], [PhoneNumber]) VALUES (5, N'OOO "Pokupatel"                                   ', N'Vladivostok                                       ', NULL)
INSERT [dbo].[Counterparties] ([CounterpartyId], [CounterpartyName], [Address], [PhoneNumber]) VALUES (6, N'Ivanov                                            ', N'Ufa                                               ', NULL)
INSERT [dbo].[Counterparties] ([CounterpartyId], [CounterpartyName], [Address], [PhoneNumber]) VALUES (7, N'Petrov                                            ', N'Krasnodar                                         ', NULL)
INSERT [dbo].[Counterparties] ([CounterpartyId], [CounterpartyName], [Address], [PhoneNumber]) VALUES (8, N'Okulov                                            ', N'Irbit                                             ', NULL)
INSERT [dbo].[Counterparties] ([CounterpartyId], [CounterpartyName], [Address], [PhoneNumber]) VALUES (9, N'Smirnov                                           ', N'Samara                                            ', NULL)
INSERT [dbo].[Counterparties] ([CounterpartyId], [CounterpartyName], [Address], [PhoneNumber]) VALUES (10, N'Sidorov                                           ', N'Perm                                              ', NULL)
SET IDENTITY_INSERT [dbo].[Counterparties] OFF
SET IDENTITY_INSERT [dbo].[CustomerOrders] ON 

INSERT [dbo].[CustomerOrders] ([CustomerOrderId], [BoxId], [BoxName], [BoxWeight], [BoxAmount], [CounterpartyId], [CounterpartyName], [OrderSum], [OrderDate]) VALUES (7002, 5020, N'Мерси                                             ', 8, 1, 1, N'ООО "Вектор"                                      ', 10400, CAST(N'2021-05-14' AS Date))
INSERT [dbo].[CustomerOrders] ([CustomerOrderId], [BoxId], [BoxName], [BoxWeight], [BoxAmount], [CounterpartyId], [CounterpartyName], [OrderSum], [OrderDate]) VALUES (8004, 3018, N'Коркунов                                          ', 10, 2, 1, N'ООО "Вектор"                                      ', 53000, CAST(N'2021-05-14' AS Date))
SET IDENTITY_INSERT [dbo].[CustomerOrders] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [CounterpartyId], [OrderType], [CounterpartyName], [OrderTypeId]) VALUES (11004, 1, N'Customer                                          ', N'OOO "aaaa"                                        ', 1)
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[OrderTypes] ON 

INSERT [dbo].[OrderTypes] ([OrderTypeId], [OrderType]) VALUES (1, N'Customer                                          ')
INSERT [dbo].[OrderTypes] ([OrderTypeId], [OrderType]) VALUES (2, N'Components                                        ')
SET IDENTITY_INSERT [dbo].[OrderTypes] OFF
ALTER TABLE [dbo].[Boxes]  WITH CHECK ADD  CONSTRAINT [FK_Boxes_Candies] FOREIGN KEY([CandyId])
REFERENCES [dbo].[Candies] ([CandyId])
GO
ALTER TABLE [dbo].[Boxes] CHECK CONSTRAINT [FK_Boxes_Candies]
GO
ALTER TABLE [dbo].[ComponentOrder]  WITH CHECK ADD  CONSTRAINT [FK_ComponentOrder_Components] FOREIGN KEY([ComponentId])
REFERENCES [dbo].[Components] ([ComponentId])
GO
ALTER TABLE [dbo].[ComponentOrder] CHECK CONSTRAINT [FK_ComponentOrder_Components]
GO
ALTER TABLE [dbo].[ComponentOrder]  WITH CHECK ADD  CONSTRAINT [FK_ComponentOrder_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[ComponentOrder] CHECK CONSTRAINT [FK_ComponentOrder_Orders]
GO
ALTER TABLE [dbo].[ComponentOrders]  WITH CHECK ADD  CONSTRAINT [FK_ComponentOrders_Components] FOREIGN KEY([ComponentId])
REFERENCES [dbo].[Components] ([ComponentId])
GO
ALTER TABLE [dbo].[ComponentOrders] CHECK CONSTRAINT [FK_ComponentOrders_Components]
GO
ALTER TABLE [dbo].[ComponentOrders]  WITH CHECK ADD  CONSTRAINT [FK_ComponentOrders_Counterparties] FOREIGN KEY([CounterpartyId])
REFERENCES [dbo].[Counterparties] ([CounterpartyId])
GO
ALTER TABLE [dbo].[ComponentOrders] CHECK CONSTRAINT [FK_ComponentOrders_Counterparties]
GO
ALTER TABLE [dbo].[ComponentOrders]  WITH CHECK ADD  CONSTRAINT [FK_ComponentOrders_CustomerOrders] FOREIGN KEY([CustomerOrderId])
REFERENCES [dbo].[CustomerOrders] ([CustomerOrderId])
GO
ALTER TABLE [dbo].[ComponentOrders] CHECK CONSTRAINT [FK_ComponentOrders_CustomerOrders]
GO
ALTER TABLE [dbo].[Components]  WITH CHECK ADD  CONSTRAINT [FK_Components_Counterparties] FOREIGN KEY([CounterpartyId])
REFERENCES [dbo].[Counterparties] ([CounterpartyId])
GO
ALTER TABLE [dbo].[Components] CHECK CONSTRAINT [FK_Components_Counterparties]
GO
ALTER TABLE [dbo].[Compositions]  WITH CHECK ADD  CONSTRAINT [FK_Composition_Candies] FOREIGN KEY([CandyId])
REFERENCES [dbo].[Candies] ([CandyId])
GO
ALTER TABLE [dbo].[Compositions] CHECK CONSTRAINT [FK_Composition_Candies]
GO
ALTER TABLE [dbo].[Compositions]  WITH CHECK ADD  CONSTRAINT [FK_Composition_Components] FOREIGN KEY([ComponentId])
REFERENCES [dbo].[Components] ([ComponentId])
GO
ALTER TABLE [dbo].[Compositions] CHECK CONSTRAINT [FK_Composition_Components]
GO
ALTER TABLE [dbo].[CustomerOrder]  WITH CHECK ADD  CONSTRAINT [FK_CustomerOrder_Boxes] FOREIGN KEY([BoxId])
REFERENCES [dbo].[Boxes] ([BoxId])
GO
ALTER TABLE [dbo].[CustomerOrder] CHECK CONSTRAINT [FK_CustomerOrder_Boxes]
GO
ALTER TABLE [dbo].[CustomerOrder]  WITH CHECK ADD  CONSTRAINT [FK_CustomerOrder_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[CustomerOrder] CHECK CONSTRAINT [FK_CustomerOrder_Orders]
GO
ALTER TABLE [dbo].[CustomerOrders]  WITH CHECK ADD  CONSTRAINT [FK_CustomerOrders_Boxes] FOREIGN KEY([BoxId])
REFERENCES [dbo].[Boxes] ([BoxId])
GO
ALTER TABLE [dbo].[CustomerOrders] CHECK CONSTRAINT [FK_CustomerOrders_Boxes]
GO
ALTER TABLE [dbo].[CustomerOrders]  WITH CHECK ADD  CONSTRAINT [FK_CustomerOrders_Counterparties] FOREIGN KEY([CounterpartyId])
REFERENCES [dbo].[Counterparties] ([CounterpartyId])
GO
ALTER TABLE [dbo].[CustomerOrders] CHECK CONSTRAINT [FK_CustomerOrders_Counterparties]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Counterparties] FOREIGN KEY([CounterpartyId])
REFERENCES [dbo].[Counterparties] ([CounterpartyId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Counterparties]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_OrderTypes] FOREIGN KEY([OrderTypeId])
REFERENCES [dbo].[OrderTypes] ([OrderTypeId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_OrderTypes]
GO
