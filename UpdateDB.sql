
/****** Object:  Table [dbo].[Location]    Script Date: 10/17/2018 3:50:20 AM ******/
DROP TABLE [dbo].[Location]
GO
/****** Object:  Table [dbo].[AssignLine]    Script Date: 10/17/2018 3:50:20 AM ******/
DROP TABLE [dbo].[AssignLine]
GO
/****** Object:  Table [dbo].[AssignHeader]    Script Date: 10/17/2018 3:50:20 AM ******/
DROP TABLE [dbo].[AssignHeader]
GO
/****** Object:  Table [dbo].[AssignHeader]    Script Date: 10/17/2018 3:50:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignHeader](
	[AssignHeaderID] [numeric](20, 0) NOT NULL,
	[DocumentNo] [nvarchar](20) NOT NULL,
	[UserID] [int] NULL,
	[UserFirstName] [nvarchar](100) NULL,
	[UserSurname] [nvarchar](100) NULL,
	[UserPosition] [nvarchar](100) NULL,
	[UserSectionCode] [nvarchar](20) NULL,
	[UserSectionName] [nvarchar](100) NULL,
	[UserDepartmentCode] [nvarchar](20) NULL,
	[UserDepartmentName] [nvarchar](100) NULL,
	[UserPhone] [nvarchar](20) NULL,
	[UserMobile] [nvarchar](20) NULL,
	[Approver] [nvarchar](100) NULL,
	[DocumentDate] [datetime] NULL,
	[ApproveBy] [numeric](20, 0) NULL,
	[ApproveByCode] [nvarchar](20) NULL,
	[DueDate] [datetime] NULL,
	[Remark] [nvarchar](300) NULL,
	[UpdateBy] [nvarchar](20) NULL,
	[UpdateDate] [datetime] NULL,
	[CreateBy] [nvarchar](20) NULL,
	[CreateDate] [datetime] NULL,
	[RequestHeaderStatus] [numeric](5, 0) NULL,
 CONSTRAINT [PK_AssignHeader] PRIMARY KEY CLUSTERED 
(
	[AssignHeaderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[AssignLine]    Script Date: 10/17/2018 3:50:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignLine](
	[AssignHeaderID] [numeric](20, 0) NOT NULL,
	[AssignLineID] [numeric](20, 0) NOT NULL,
	[AssignLineDescription] [nvarchar](100) NULL,
	[Place] [nvarchar](100) NULL,
	[Location] [nvarchar](100) NULL,
	[Province] [nvarchar](50) NULL,
	[ForUseID] [int] NULL,
	[ForUseName] [nvarchar](200) NULL,
	[Priority] [nvarchar](20) NULL,
	[DriverID] [numeric](5, 0) NULL,
	[DriverCode] [nvarchar](20) NULL,
	[DriverName] [nvarchar](80) NULL,
	[DriverMobile] [nvarchar](40) NULL,
	[RouteID] [numeric](5, 0) NULL,
	[RouteCode] [nvarchar](50) NULL,
	[RouteName] [nvarchar](100) NULL,
	[Amount] [numeric](18, 2) NULL,
	[Quantity] [int] NULL,
	[ContactName] [nvarchar](100) NULL,
	[UpdateBy] [nvarchar](20) NULL,
	[UpdateDate] [datetime] NULL,
	[CreateBy] [nvarchar](20) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_AssignLine] PRIMARY KEY CLUSTERED 
(
	[AssignHeaderID] ASC,
	[AssignLineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Location]    Script Date: 10/17/2018 3:50:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[LocationID] [numeric](5, 0) IDENTITY(1,1) NOT NULL,
	[LocationCode] [nvarchar](20) NULL,
	[LocationName] [nvarchar](80) NULL,
	[Status] [numeric](2, 0) NULL,
	[UpdateBy] [nvarchar](20) NULL,
	[UpdateDate] [datetime] NULL,
	[CreateBy] [nvarchar](20) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET IDENTITY_INSERT [dbo].[Location] ON 

INSERT [dbo].[Location] ([LocationID], [LocationCode], [LocationName], [Status], [UpdateBy], [UpdateDate], [CreateBy], [CreateDate]) VALUES (CAST(1 AS Numeric(5, 0)), N'L001', N'รัชดาภิเษก', CAST(1 AS Numeric(2, 0)), NULL, CAST(N'2018-10-16 20:17:22.873' AS DateTime), N'test001', NULL)
INSERT [dbo].[Location] ([LocationID], [LocationCode], [LocationName], [Status], [UpdateBy], [UpdateDate], [CreateBy], [CreateDate]) VALUES (CAST(2 AS Numeric(5, 0)), N'L002', N'วิภาวดี', CAST(1 AS Numeric(2, 0)), NULL, CAST(N'2018-10-16 20:17:41.653' AS DateTime), N'test001', NULL)
SET IDENTITY_INSERT [dbo].[Location] OFF
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF__Location__Status__5FB337D6]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF__Location__Update__60A75C0F]  DEFAULT (getdate()) FOR [UpdateDate]
GO
