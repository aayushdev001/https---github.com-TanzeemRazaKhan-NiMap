USE [NimapByTanzeem]
GO
/****** Object:  Table [dbo].[tbl_Category]    Script Date: 6/14/2023 1:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Category](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[categoruycode] [varchar](50) NOT NULL,
	[cattegoryname] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Product]    Script Date: 6/14/2023 1:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Product](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[productcode] [varchar](50) NOT NULL,
	[productname] [varchar](50) NOT NULL,
	[category] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Category] ON 

INSERT [dbo].[tbl_Category] ([id], [categoruycode], [cattegoryname]) VALUES (1, N'112L2', N'Laptop')
INSERT [dbo].[tbl_Category] ([id], [categoruycode], [cattegoryname]) VALUES (3, N'112L', N'Laptopsa')
INSERT [dbo].[tbl_Category] ([id], [categoruycode], [cattegoryname]) VALUES (4, N'Car1', N'Car')
INSERT [dbo].[tbl_Category] ([id], [categoruycode], [cattegoryname]) VALUES (5, N'Car2', N'Car')
INSERT [dbo].[tbl_Category] ([id], [categoruycode], [cattegoryname]) VALUES (6, N'COM12', N'Computer')
SET IDENTITY_INSERT [dbo].[tbl_Category] OFF
SET IDENTITY_INSERT [dbo].[tbl_Product] ON 

INSERT [dbo].[tbl_Product] ([id], [productcode], [productname], [category]) VALUES (1, N'112L', N'Car', N'Laptop')
INSERT [dbo].[tbl_Product] ([id], [productcode], [productname], [category]) VALUES (2, N'En1', N'Engine', N'Car')
SET IDENTITY_INSERT [dbo].[tbl_Product] OFF
