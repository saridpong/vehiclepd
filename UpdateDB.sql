
/****** Object:  Table [dbo].[Vihicle]    Script Date: 10/4/2018 6:34:49 PM ******/
DROP TABLE [dbo].[Vihicle]
GO
/****** Object:  Table [dbo].[UserData]    Script Date: 10/4/2018 6:34:49 PM ******/
DROP TABLE [dbo].[UserData]
GO
/****** Object:  Table [dbo].[Section]    Script Date: 10/4/2018 6:34:49 PM ******/
DROP TABLE [dbo].[Section]
GO
/****** Object:  Table [dbo].[RequestLine]    Script Date: 10/4/2018 6:34:49 PM ******/
DROP TABLE [dbo].[RequestLine]
GO
/****** Object:  Table [dbo].[RequestHeader]    Script Date: 10/4/2018 6:34:49 PM ******/
DROP TABLE [dbo].[RequestHeader]
GO
/****** Object:  Table [dbo].[RefreshToken]    Script Date: 10/4/2018 6:34:49 PM ******/
DROP TABLE [dbo].[RefreshToken]
GO
/****** Object:  Table [dbo].[Place]    Script Date: 10/4/2018 6:34:49 PM ******/
DROP TABLE [dbo].[Place]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 10/4/2018 6:34:49 PM ******/
DROP TABLE [dbo].[Location]
GO
/****** Object:  Table [dbo].[InformationLogin]    Script Date: 10/4/2018 6:34:49 PM ******/
DROP TABLE [dbo].[InformationLogin]
GO
/****** Object:  Table [dbo].[ForUse]    Script Date: 10/4/2018 6:34:49 PM ******/
DROP TABLE [dbo].[ForUse]
GO
/****** Object:  Table [dbo].[Driver]    Script Date: 10/4/2018 6:34:49 PM ******/
DROP TABLE [dbo].[Driver]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 10/4/2018 6:34:49 PM ******/
DROP TABLE [dbo].[Department]
GO
/****** Object:  Table [dbo].[CarType]    Script Date: 10/4/2018 6:34:49 PM ******/
DROP TABLE [dbo].[CarType]
GO
/****** Object:  Table [dbo].[CarType]    Script Date: 10/4/2018 6:34:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarType](
	[CarTypeID] [numeric](5, 0) IDENTITY(1,1) NOT NULL,
	[CarTypeCode] [nvarchar](20) NULL,
	[CarTypeName] [nvarchar](80) NULL,
	[Status] [numeric](2, 0) NULL,
	[UpdateBy] [nvarchar](20) NULL,
	[UpdateDate] [datetime] NULL,
	[CreateBy] [nvarchar](20) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_CarType] PRIMARY KEY CLUSTERED 
(
	[CarTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Department]    Script Date: 10/4/2018 6:34:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentID] [numeric](5, 0) NOT NULL,
	[DepartmentCode] [nvarchar](20) NOT NULL,
	[DepartmentName] [nvarchar](80) NOT NULL,
	[Status] [numeric](2, 0) NOT NULL,
	[UpdateBy] [nvarchar](20) NOT NULL,
	[UpdateDate] [datetime] NOT NULL
)

GO
/****** Object:  Table [dbo].[Driver]    Script Date: 10/4/2018 6:34:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Driver](
	[DriverID] [numeric](5, 0) IDENTITY(1,1) NOT NULL,
	[DriverCode] [nvarchar](20) NULL,
	[DriverName] [nvarchar](80) NULL,
	[DriverMobile] [nvarchar](40) NULL,
	[Status] [numeric](2, 0) NULL,
	[UpdateBy] [nvarchar](20) NULL,
	[UpdateDate] [datetime] NULL,
	[CreateBy] [nvarchar](20) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Driver] PRIMARY KEY CLUSTERED 
(
	[DriverID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[ForUse]    Script Date: 10/4/2018 6:34:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ForUse](
	[ForUseID] [int] IDENTITY(1,1) NOT NULL,
	[ForUseCode] [nvarchar](20) NULL,
	[ForUseName] [nvarchar](80) NULL,
	[Status] [numeric](2, 0) NULL,
	[UpdateBy] [nvarchar](20) NULL,
	[UpdateDate] [datetime] NULL,
	[CreateBy] [nvarchar](20) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_ForUse] PRIMARY KEY CLUSTERED 
(
	[ForUseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[InformationLogin]    Script Date: 10/4/2018 6:34:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InformationLogin](
	[InformationLoginID] [numeric](5, 0) NOT NULL,
	[InformationLoginData] [nvarchar](2000) NOT NULL,
	[Status] [numeric](2, 0) NOT NULL,
	[UpdateBy] [nvarchar](20) NOT NULL,
	[UpdateDate] [datetime] NOT NULL
)

GO
/****** Object:  Table [dbo].[Location]    Script Date: 10/4/2018 6:34:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[LocationID] [numeric](5, 0) NOT NULL,
	[LocationCode] [nvarchar](20) NOT NULL,
	[LocationName] [nvarchar](80) NOT NULL,
	[Status] [numeric](2, 0) NOT NULL,
	[UpdateBy] [nvarchar](20) NOT NULL,
	[UpdateDate] [datetime] NOT NULL
)

GO
/****** Object:  Table [dbo].[Place]    Script Date: 10/4/2018 6:34:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Place](
	[PlaceID] [int] IDENTITY(1,1) NOT NULL,
	[PlaceCode] [nvarchar](20) NULL,
	[PlaceName] [nvarchar](80) NULL,
	[LocationName] [nvarchar](100) NULL,
	[Province] [nvarchar](50) NULL,
	[Status] [numeric](2, 0) NULL,
	[UpdateBy] [nvarchar](20) NULL,
	[UpdateDate] [datetime] NULL,
	[CreateBy] [nvarchar](20) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Place] PRIMARY KEY CLUSTERED 
(
	[PlaceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[RefreshToken]    Script Date: 10/4/2018 6:34:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefreshToken](
	[ID] [nvarchar](400) NOT NULL,
	[Subject] [nvarchar](50) NOT NULL,
	[IssuedUtc] [datetime] NULL,
	[ExpiresUtc] [datetime] NULL,
	[ProtectedTicket] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_RefreshToken] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[RequestHeader]    Script Date: 10/4/2018 6:34:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestHeader](
	[RequestHeaderID] [numeric](20, 0) NOT NULL,
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
	[JobType] [nvarchar](200) NULL,
	[Priority] [nvarchar](20) NULL,
	[DateStart] [datetime] NULL,
	[DateEnd] [datetime] NULL,
	[TotalPasenger] [numeric](2, 0) NULL,
	[EstimateDistance] [numeric](20, 2) NULL,
	[EstimateCost] [numeric](20, 2) NULL,
	[Remark] [nvarchar](300) NULL,
	[UpdateBy] [nvarchar](20) NULL,
	[UpdateDate] [datetime] NULL,
	[CreateBy] [nvarchar](20) NULL,
	[CreateDate] [datetime] NULL,
	[RequestHeaderStatus] [numeric](5, 0) NULL,
	[VehicleID] [numeric](5, 0) NULL,
	[VehicleCode] [nvarchar](50) NULL,
	[VehicleTypeCode] [nvarchar](20) NULL,
	[VehicleTypeName] [nvarchar](100) NULL,
	[DriverID] [numeric](5, 0) NULL,
	[DriverCode] [nvarchar](20) NULL,
	[DriverName] [nvarchar](80) NULL,
	[DriverMobile] [nvarchar](40) NULL,
	[ApproveRemark] [nvarchar](300) NULL,
	[MilesIn] [numeric](8, 0) NULL,
	[MilesOut] [numeric](8, 0) NULL,
	[Diff_Miles] [numeric](8, 0) NULL,
	[Diff_Miles_Est] [numeric](8, 0) NULL,
	[VehicleTimeIn] [datetime] NULL,
	[VehicleTimeOut] [datetime] NULL,
	[DiffVehicleTime] [time](7) NULL,
 CONSTRAINT [PK_RequestHeader] PRIMARY KEY CLUSTERED 
(
	[RequestHeaderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[RequestLine]    Script Date: 10/4/2018 6:34:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestLine](
	[RequestHeaderID] [numeric](20, 0) NOT NULL,
	[RequestLineID] [numeric](20, 0) NOT NULL,
	[RequestLineDescription] [nvarchar](100) NULL,
	[Place] [nvarchar](100) NULL,
	[Location] [nvarchar](100) NULL,
	[Province] [nvarchar](50) NULL,
	[ContactName] [nvarchar](100) NULL,
	[UpdateBy] [nvarchar](20) NULL,
	[UpdateDate] [datetime] NULL,
	[CreateBy] [nvarchar](20) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_RequestLine] PRIMARY KEY CLUSTERED 
(
	[RequestHeaderID] ASC,
	[RequestLineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Section]    Script Date: 10/4/2018 6:34:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Section](
	[SectionID] [numeric](5, 0) NOT NULL,
	[SectionCode] [nvarchar](20) NOT NULL,
	[SectionName] [nvarchar](100) NULL,
	[SectionApproveName] [nvarchar](100) NULL,
	[SectionApprovePosition] [nvarchar](100) NULL,
	[UpdateBy] [nvarchar](20) NULL,
	[UpdateDate] [datetime] NULL,
	[Status] [numeric](2, 0) NOT NULL
)

GO
/****** Object:  Table [dbo].[UserData]    Script Date: 10/4/2018 6:34:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserData](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserCode] [nvarchar](20) NOT NULL,
	[UserPassword] [text] NULL,
	[UserTitleName] [nvarchar](20) NULL,
	[UserName] [nvarchar](100) NULL,
	[UserSurname] [nvarchar](100) NULL,
	[UserPosition] [nvarchar](100) NULL,
	[UserSectionCode] [nvarchar](20) NULL,
	[UserSectionName] [nvarchar](100) NULL,
	[UserDepartmentCode] [nvarchar](20) NULL,
	[UserDepartmentName] [nvarchar](100) NULL,
	[UserPhone] [nvarchar](20) NULL,
	[UserMobile] [nvarchar](20) NULL,
	[UserPermission] [int] NULL,
	[Approver] [nvarchar](200) NULL,
	[Status] [numeric](2, 0) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [nvarchar](20) NULL,
 CONSTRAINT [PK_UserData] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Vihicle]    Script Date: 10/4/2018 6:34:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vihicle](
	[VihicleID] [numeric](5, 0) IDENTITY(1,1) NOT NULL,
	[VihicleCode] [nvarchar](20) NOT NULL,
	[VihicleBrand] [nvarchar](50) NULL,
	[VihicleModel] [nvarchar](50) NULL,
	[VihicleFuelType] [nvarchar](50) NULL,
	[VihicleDate] [nvarchar](50) NULL,
	[VihicleCost] [numeric](10, 2) NULL,
	[VihicleTypeCode] [nvarchar](20) NULL,
	[VehicleTypeName] [nvarchar](100) NULL,
	[VihicleYear] [int] NULL,
	[VihicleAsset] [nvarchar](50) NULL,
	[VihicleInsurance] [nvarchar](100) NULL,
	[VihicleInsuranceType] [nvarchar](100) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [nvarchar](20) NULL,
	[Status] [numeric](2, 0) NOT NULL,
 CONSTRAINT [PK_Vihicle] PRIMARY KEY CLUSTERED 
(
	[VihicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET IDENTITY_INSERT [dbo].[CarType] ON 

INSERT [dbo].[CarType] ([CarTypeID], [CarTypeCode], [CarTypeName], [Status], [UpdateBy], [UpdateDate], [CreateBy], [CreateDate]) VALUES (CAST(1 AS Numeric(5, 0)), N'T001', N'รถเก่ง 4 ที่นั่ง', CAST(1 AS Numeric(2, 0)), NULL, CAST(N'2018-10-03 17:26:29.307' AS DateTime), N'test001', NULL)
INSERT [dbo].[CarType] ([CarTypeID], [CarTypeCode], [CarTypeName], [Status], [UpdateBy], [UpdateDate], [CreateBy], [CreateDate]) VALUES (CAST(2 AS Numeric(5, 0)), N'T002', N'รถ SUV', CAST(1 AS Numeric(2, 0)), NULL, CAST(N'2018-10-03 17:26:45.200' AS DateTime), N'test001', NULL)
INSERT [dbo].[CarType] ([CarTypeID], [CarTypeCode], [CarTypeName], [Status], [UpdateBy], [UpdateDate], [CreateBy], [CreateDate]) VALUES (CAST(3 AS Numeric(5, 0)), N'T003', N'รถกระบะ 4 ประตู', CAST(1 AS Numeric(2, 0)), NULL, CAST(N'2018-10-03 17:27:21.497' AS DateTime), N'test001', NULL)
SET IDENTITY_INSERT [dbo].[CarType] OFF
SET IDENTITY_INSERT [dbo].[Driver] ON 

INSERT [dbo].[Driver] ([DriverID], [DriverCode], [DriverName], [DriverMobile], [Status], [UpdateBy], [UpdateDate], [CreateBy], [CreateDate]) VALUES (CAST(1 AS Numeric(5, 0)), N'D001', N'นาย สมชาย ช่างไม้', N'0823334444', CAST(1 AS Numeric(2, 0)), NULL, CAST(N'2018-10-03 17:11:49.423' AS DateTime), N'test001', NULL)
INSERT [dbo].[Driver] ([DriverID], [DriverCode], [DriverName], [DriverMobile], [Status], [UpdateBy], [UpdateDate], [CreateBy], [CreateDate]) VALUES (CAST(2 AS Numeric(5, 0)), N'D002', N'นาย สมชาย ช่างเชื่อม', N'0824445555', CAST(1 AS Numeric(2, 0)), NULL, CAST(N'2018-10-03 17:12:08.783' AS DateTime), N'test', NULL)
INSERT [dbo].[Driver] ([DriverID], [DriverCode], [DriverName], [DriverMobile], [Status], [UpdateBy], [UpdateDate], [CreateBy], [CreateDate]) VALUES (CAST(3 AS Numeric(5, 0)), N'D003', N'นาย สมชาย นามสกุล', N'0864441111', CAST(1 AS Numeric(2, 0)), NULL, CAST(N'2018-10-03 17:12:44.580' AS DateTime), N'test001', NULL)
SET IDENTITY_INSERT [dbo].[Driver] OFF
SET IDENTITY_INSERT [dbo].[ForUse] ON 

INSERT [dbo].[ForUse] ([ForUseID], [ForUseCode], [ForUseName], [Status], [UpdateBy], [UpdateDate], [CreateBy], [CreateDate]) VALUES (1, N'C001', N'ติดต่อลูกค้า', CAST(1 AS Numeric(2, 0)), NULL, CAST(N'2018-10-01 09:49:45.457' AS DateTime), N'test001', CAST(N'2018-10-01 00:00:00.000' AS DateTime))
INSERT [dbo].[ForUse] ([ForUseID], [ForUseCode], [ForUseName], [Status], [UpdateBy], [UpdateDate], [CreateBy], [CreateDate]) VALUES (2, N'C002', N'รับส่งลูกค้า', CAST(1 AS Numeric(2, 0)), NULL, CAST(N'2018-10-01 09:50:19.487' AS DateTime), N'test001', CAST(N'2018-10-01 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[ForUse] OFF
SET IDENTITY_INSERT [dbo].[Place] ON 

INSERT [dbo].[Place] ([PlaceID], [PlaceCode], [PlaceName], [LocationName], [Province], [Status], [UpdateBy], [UpdateDate], [CreateBy], [CreateDate]) VALUES (1, N'P001', N'PANDORA', N'บางนา', N'กรุงเทพมหานคร', CAST(1 AS Numeric(2, 0)), NULL, NULL, N'test001', NULL)
INSERT [dbo].[Place] ([PlaceID], [PlaceCode], [PlaceName], [LocationName], [Province], [Status], [UpdateBy], [UpdateDate], [CreateBy], [CreateDate]) VALUES (2, N'P002', N'PAN', N'รัชดา', N'กรุงเทพมหานคร', CAST(1 AS Numeric(2, 0)), NULL, NULL, N'test001', NULL)
SET IDENTITY_INSERT [dbo].[Place] OFF
INSERT [dbo].[RefreshToken] ([ID], [Subject], [IssuedUtc], [ExpiresUtc], [ProtectedTicket]) VALUES (N'ahJVFjzj+2/gH/qlrlHhLqmqSakaClqgQnk3UvQxdiA=', N'test001', CAST(N'2018-10-04 10:13:50.873' AS DateTime), CAST(N'2018-10-04 11:22:50.873' AS DateTime), N'0z7bOwCT3sY6Tw0mQq1s7nTJWi4VJCIEKRFI_K9_pQgBrW1r3itvrKHX2U7rEREQkvGEQKbapJ56vfKXxS_zVyEGVTXnb_RmJrmILddLGeDipxlnaR1KeinEzL8KHLaEyoY5cJXkh2VzZo3jqUakroP5qQPqnGyxBObbuY_qWIvrt7dGiYtrMYyXHt0GkBoE3mHOqB4ccA9Pn8a5ljG90i_VHLhhPNe3IcuP5FbCoyzmQXTLO-gaqELx1vBU7FINUXEIpSPH5qqx-66xflISqKQcxixsOSc1DA5auySx3meTumwi_XDm0YgyMhI--6n8wPI6ytCc4_en2GobnDPgXv2Un4BmaGhLHJJVKLJIMICnIepgbDwq1Xcq9iQwMlrk9WyDxSRNvxR4y8t2-76HSLFevssfg7jG9P_XLvGba4MvWYNX_oeztBEEdN_C-Eh9FKRc8xrOJ_-rsC-W8L9NI6D--qeN0WvFCSCMOyDtMDqV8LGX1Mz_rsmN5fNZeogNbXZi0aNs3VS-3A2XRJCeIYhkKIt3rYs3rhKoFmGHkINmfOlxoIWNEwsRpk45h43bq-GBxwBRLIRkM03PHtdxuoaga7QmdtvgGs34t7Y2d3E')
INSERT [dbo].[RefreshToken] ([ID], [Subject], [IssuedUtc], [ExpiresUtc], [ProtectedTicket]) VALUES (N'rlTp083XCMQ16+sVwFKoF0bipUrahU0oJCIpsA5L34o=', N'test002', CAST(N'2018-10-04 10:13:41.217' AS DateTime), CAST(N'2018-10-04 11:22:41.197' AS DateTime), N'BeZnYf0xCu-2LbYxaMxRx2MbyvB4ZRmb7nyMcN2sp0Cud4EvW3ke6dHAE3UZgx7pCPVsq-wZJ7NEAnffvCSTecULJVpxLdnUpx0LSWZ7_D-DYAerLLH44iyrTsHlU7LWJ4fOGg-SjzZ_-m9E44r4ZZLsNEQZ4mQkQsWe0S-kouyomvSu9CSggz9ORWsiSxVuXE3QgAIPqXuSp5SIw5ApHDSn7o5_oz8LU3sAm7mMN9NBRKHlmEu4tXgzkmVlqTECTnJhKjSHN7GJNQ7zH4pu-xQKxos2FqTXb69m2HsDODzxwMacG7jthHO8kXYl66FUNlKXbk3NVEXPd21sBPTFHbJ4wqbAheIPRmOEdsrqwLWFd5fB09CR6xcvrQiQqsRczm5-F0eRaaX-svEXj5-c9Sv4cNDnoGp_NvKSQYZpzck7YUsRidhWW2BzCAL-2VB8FNa3KBaHI_x0jZl650i-e-WEn46qNZwo2naY6aVJwNNufCZToJ_iRxpk2yOrn8ld4yt48h82-FinGIRIRuR9oN93O6AxYwVveK9Kq3AXWoRV1nQUKPrwHX6iMx3p2_6cmtfVm8g8XSJ4xNqfbYNI-Q')
INSERT [dbo].[RefreshToken] ([ID], [Subject], [IssuedUtc], [ExpiresUtc], [ProtectedTicket]) VALUES (N'tCRMsuCz5rkakT+FhTdsJSzz2a77qDwIr8T9b0swwVA=', N'test003', CAST(N'2018-10-04 10:02:17.030' AS DateTime), CAST(N'2018-10-04 11:11:16.927' AS DateTime), N'VVwmsRV7uH2Cx7FWme7XKoXoOi2ZQhLHgZrEYQgyybvp3OwB_7-7JbI4Fub15C1aD_I70ZWsLe3224yf5noqB_7COXl-HG_7oEZDy3OcNapghK0BsZdg2KCtzJVwdio3Xe7FoSAUqpstxToSkXIxgDHT1mbJS34fTJsC0e1MT97tuN_nyEZewrgvRls7bw-9KAjEVx5CV71br5QWxD211SJsWDpADolDsU4JEfX9CQ2iaFqyHBf5Z_JdUGA6pxC1UylVybqt4uBHtHDaXOPh3ZHkFGP5QGAC93zllf2pS_bVF8KRVnju5qkP5M4RmFWlIGVcaBeg4jQetgn45UXo3k0Da2byHmtFk8QItEFKfE5WmhEcQGKgoj8ptwL_5x6ObLmvjCviDfNC7Yu0f6LWubCj0_W2eGEXouyJK_qbYEEl3tOoOSMaPk6k35bAnJnOk5-8OmLDvpaqIThxRdnf7-empS28i8q4V3uA5VbP3BO_uBGEpvK42DViLNvNlccpYVOl2epSj2s_bN03XBhoNFHAAadtZT9-_hiGVQgINzfYza0ZUYAhEsvUgUFY52HzL0HtA7CEE19GNcVAsApuhA')
INSERT [dbo].[RequestHeader] ([RequestHeaderID], [DocumentNo], [UserID], [UserFirstName], [UserSurname], [UserPosition], [UserSectionCode], [UserSectionName], [UserDepartmentCode], [UserDepartmentName], [UserPhone], [UserMobile], [Approver], [DocumentDate], [ApproveBy], [ApproveByCode], [JobType], [Priority], [DateStart], [DateEnd], [TotalPasenger], [EstimateDistance], [EstimateCost], [Remark], [UpdateBy], [UpdateDate], [CreateBy], [CreateDate], [RequestHeaderStatus], [VehicleID], [VehicleCode], [VehicleTypeCode], [VehicleTypeName], [DriverID], [DriverCode], [DriverName], [DriverMobile], [ApproveRemark], [MilesIn], [MilesOut], [Diff_Miles], [Diff_Miles_Est], [VehicleTimeIn], [VehicleTimeOut], [DiffVehicleTime]) VALUES (CAST(1 AS Numeric(20, 0)), N'V201810001', 1, N'FirstName', N'LastName', N'หัวหน้าแผนก', N'D001', N'โรงงาน 1', N'100100', N'โรงงาน', N'0811112222', N'083224442', N'นายอนุมัติ 1', CAST(N'2018-10-04 14:56:35.900' AS DateTime), CAST(1 AS Numeric(20, 0)), N'test001', N'ติดต่อลูกค้า', N'B', CAST(N'2018-10-02 14:06:34.817' AS DateTime), CAST(N'2018-10-02 15:06:35.397' AS DateTime), CAST(4 AS Numeric(2, 0)), CAST(40.00 AS Numeric(20, 2)), CAST(500.00 AS Numeric(20, 2)), N'รับที่สนามบิน', N'test003', CAST(N'2018-10-04 17:02:24.950' AS DateTime), N'test002', CAST(N'2018-10-02 14:07:07.517' AS DateTime), CAST(4 AS Numeric(5, 0)), CAST(6 AS Numeric(5, 0)), N'กจ-5555', N'T001', N'รถเก่ง 4 ที่นั่ง', CAST(3 AS Numeric(5, 0)), N'D003', N'นาย สมชาย นามสกุล', N'0864441111', N'ทดสอบ', CAST(350 AS Numeric(8, 0)), CAST(300 AS Numeric(8, 0)), CAST(50 AS Numeric(8, 0)), CAST(10 AS Numeric(8, 0)), CAST(N'2018-10-04 17:02:24.547' AS DateTime), CAST(N'2018-10-04 16:26:44.630' AS DateTime), CAST(N'00:35:39.9160000' AS Time))
INSERT [dbo].[RequestHeader] ([RequestHeaderID], [DocumentNo], [UserID], [UserFirstName], [UserSurname], [UserPosition], [UserSectionCode], [UserSectionName], [UserDepartmentCode], [UserDepartmentName], [UserPhone], [UserMobile], [Approver], [DocumentDate], [ApproveBy], [ApproveByCode], [JobType], [Priority], [DateStart], [DateEnd], [TotalPasenger], [EstimateDistance], [EstimateCost], [Remark], [UpdateBy], [UpdateDate], [CreateBy], [CreateDate], [RequestHeaderStatus], [VehicleID], [VehicleCode], [VehicleTypeCode], [VehicleTypeName], [DriverID], [DriverCode], [DriverName], [DriverMobile], [ApproveRemark], [MilesIn], [MilesOut], [Diff_Miles], [Diff_Miles_Est], [VehicleTimeIn], [VehicleTimeOut], [DiffVehicleTime]) VALUES (CAST(2 AS Numeric(20, 0)), N'V201810002', 1, N'FirstName', N'LastName', N'หัวหน้าแผนก', N'D001', N'โรงงาน 1', N'100100', N'โรงงาน', N'0811112222', N'083224442', N'นายอนุมัติ 1', CAST(N'2018-10-04 16:27:43.383' AS DateTime), CAST(1 AS Numeric(20, 0)), N'test001', N'รับส่งลูกค้า', N'B', CAST(N'2018-10-04 14:07:17.000' AS DateTime), CAST(N'2018-10-04 15:07:19.000' AS DateTime), CAST(1 AS Numeric(2, 0)), CAST(30.00 AS Numeric(20, 2)), CAST(1000.00 AS Numeric(20, 2)), N'รับที่บ้าน', N'test001', CAST(N'2018-10-04 16:27:43.383' AS DateTime), N'test002', CAST(N'2018-10-02 14:07:38.777' AS DateTime), CAST(2 AS Numeric(5, 0)), CAST(6 AS Numeric(5, 0)), N'กจ-5555', N'T001', N'รถเก่ง 4 ที่นั่ง', CAST(3 AS Numeric(5, 0)), N'D003', N'นาย สมชาย นามสกุล', N'0864441111', N'ทดสอบ ทดสอบ', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[RequestHeader] ([RequestHeaderID], [DocumentNo], [UserID], [UserFirstName], [UserSurname], [UserPosition], [UserSectionCode], [UserSectionName], [UserDepartmentCode], [UserDepartmentName], [UserPhone], [UserMobile], [Approver], [DocumentDate], [ApproveBy], [ApproveByCode], [JobType], [Priority], [DateStart], [DateEnd], [TotalPasenger], [EstimateDistance], [EstimateCost], [Remark], [UpdateBy], [UpdateDate], [CreateBy], [CreateDate], [RequestHeaderStatus], [VehicleID], [VehicleCode], [VehicleTypeCode], [VehicleTypeName], [DriverID], [DriverCode], [DriverName], [DriverMobile], [ApproveRemark], [MilesIn], [MilesOut], [Diff_Miles], [Diff_Miles_Est], [VehicleTimeIn], [VehicleTimeOut], [DiffVehicleTime]) VALUES (CAST(3 AS Numeric(20, 0)), N'V201810003', 2, N'First', N'Last', N'พนักงาน', N'D002', N'โรงงาน 2', N'100101', N'โรงงาน 2', N'0821113333', N'0891124444', N'นายอนุมัติ 1', CAST(N'2018-10-03 01:17:53.907' AS DateTime), NULL, NULL, N'ติดต่อลูกค้า', N'A', CAST(N'2018-10-02 14:06:34.817' AS DateTime), CAST(N'2018-10-02 15:06:35.397' AS DateTime), CAST(4 AS Numeric(2, 0)), CAST(40.00 AS Numeric(20, 2)), CAST(500.00 AS Numeric(20, 2)), N'รับที่สนามบิน', NULL, NULL, N'test002', CAST(N'2018-10-03 01:17:53.907' AS DateTime), CAST(1 AS Numeric(5, 0)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[RequestHeader] ([RequestHeaderID], [DocumentNo], [UserID], [UserFirstName], [UserSurname], [UserPosition], [UserSectionCode], [UserSectionName], [UserDepartmentCode], [UserDepartmentName], [UserPhone], [UserMobile], [Approver], [DocumentDate], [ApproveBy], [ApproveByCode], [JobType], [Priority], [DateStart], [DateEnd], [TotalPasenger], [EstimateDistance], [EstimateCost], [Remark], [UpdateBy], [UpdateDate], [CreateBy], [CreateDate], [RequestHeaderStatus], [VehicleID], [VehicleCode], [VehicleTypeCode], [VehicleTypeName], [DriverID], [DriverCode], [DriverName], [DriverMobile], [ApproveRemark], [MilesIn], [MilesOut], [Diff_Miles], [Diff_Miles_Est], [VehicleTimeIn], [VehicleTimeOut], [DiffVehicleTime]) VALUES (CAST(4 AS Numeric(20, 0)), N'V201810004', 2, N'First', N'Last', N'พนักงาน', N'D002', N'โรงงาน 2', N'100101', N'โรงงาน 2', N'0821113333', N'0891124444', N'นายอนุมัติ 1', CAST(N'2018-10-03 01:18:34.330' AS DateTime), NULL, NULL, N'ติดต่อลูกค้า', N'A', CAST(N'2018-10-02 14:06:34.817' AS DateTime), CAST(N'2018-10-02 15:06:35.397' AS DateTime), CAST(4 AS Numeric(2, 0)), CAST(40.00 AS Numeric(20, 2)), CAST(500.00 AS Numeric(20, 2)), N'รับที่สนามบิน', NULL, NULL, N'test002', CAST(N'2018-10-03 01:18:34.330' AS DateTime), CAST(1 AS Numeric(5, 0)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[RequestLine] ([RequestHeaderID], [RequestLineID], [RequestLineDescription], [Place], [Location], [Province], [ContactName], [UpdateBy], [UpdateDate], [CreateBy], [CreateDate]) VALUES (CAST(1 AS Numeric(20, 0)), CAST(1 AS Numeric(20, 0)), N'readf', N'PANDORA', N'บางนา', N'กรุงเทพมหานคร', N'BEnz', N'test001', CAST(N'2018-10-04 14:56:36.073' AS DateTime), N'test002', CAST(N'2018-10-03 03:20:58.113' AS DateTime))
INSERT [dbo].[RequestLine] ([RequestHeaderID], [RequestLineID], [RequestLineDescription], [Place], [Location], [Province], [ContactName], [UpdateBy], [UpdateDate], [CreateBy], [CreateDate]) VALUES (CAST(1 AS Numeric(20, 0)), CAST(2 AS Numeric(20, 0)), N'adsf', N'PAN', N'รัชดา', N'กรุงเทพมหานคร', N'badf', N'test001', CAST(N'2018-10-04 14:56:36.073' AS DateTime), N'test002', CAST(N'2018-10-03 03:30:41.120' AS DateTime))
INSERT [dbo].[RequestLine] ([RequestHeaderID], [RequestLineID], [RequestLineDescription], [Place], [Location], [Province], [ContactName], [UpdateBy], [UpdateDate], [CreateBy], [CreateDate]) VALUES (CAST(2 AS Numeric(20, 0)), CAST(1 AS Numeric(20, 0)), NULL, N'PAN', N'รัชดา', N'กรุงเทพมหานคร', NULL, N'test001', CAST(N'2018-10-04 16:27:43.493' AS DateTime), N'test002', CAST(N'2018-10-02 14:07:38.777' AS DateTime))
INSERT [dbo].[RequestLine] ([RequestHeaderID], [RequestLineID], [RequestLineDescription], [Place], [Location], [Province], [ContactName], [UpdateBy], [UpdateDate], [CreateBy], [CreateDate]) VALUES (CAST(3 AS Numeric(20, 0)), CAST(1 AS Numeric(20, 0)), NULL, N'PANDORA', N'บางนา', N'กรุงเทพมหานคร', NULL, NULL, NULL, N'test002', CAST(N'2018-10-03 01:17:54.020' AS DateTime))
INSERT [dbo].[RequestLine] ([RequestHeaderID], [RequestLineID], [RequestLineDescription], [Place], [Location], [Province], [ContactName], [UpdateBy], [UpdateDate], [CreateBy], [CreateDate]) VALUES (CAST(4 AS Numeric(20, 0)), CAST(1 AS Numeric(20, 0)), NULL, N'PANDORA', N'บางนา', N'กรุงเทพมหานคร', NULL, NULL, NULL, N'test002', CAST(N'2018-10-03 01:18:34.330' AS DateTime))
SET IDENTITY_INSERT [dbo].[UserData] ON 

INSERT [dbo].[UserData] ([UserID], [UserCode], [UserPassword], [UserTitleName], [UserName], [UserSurname], [UserPosition], [UserSectionCode], [UserSectionName], [UserDepartmentCode], [UserDepartmentName], [UserPhone], [UserMobile], [UserPermission], [Approver], [Status], [UpdateDate], [UpdateBy]) VALUES (1, N'test001', N'1234', N'Mr.', N'FirstName', N'LastName', N'หัวหน้าแผนก', N'D001', N'โรงงาน 1', N'100100', N'โรงงาน', N'0811112222', N'083224442', 1, N'นายอนุมัติ 1', CAST(1 AS Numeric(2, 0)), NULL, N'test001')
INSERT [dbo].[UserData] ([UserID], [UserCode], [UserPassword], [UserTitleName], [UserName], [UserSurname], [UserPosition], [UserSectionCode], [UserSectionName], [UserDepartmentCode], [UserDepartmentName], [UserPhone], [UserMobile], [UserPermission], [Approver], [Status], [UpdateDate], [UpdateBy]) VALUES (2, N'test002', N'1234', N'Mr.', N'First', N'Last', N'พนักงาน', N'D002', N'โรงงาน 2', N'100101', N'โรงงาน 2', N'0821113333', N'0891124444', 2, N'นายอนุมัติ 1', CAST(1 AS Numeric(2, 0)), NULL, N'test001')
INSERT [dbo].[UserData] ([UserID], [UserCode], [UserPassword], [UserTitleName], [UserName], [UserSurname], [UserPosition], [UserSectionCode], [UserSectionName], [UserDepartmentCode], [UserDepartmentName], [UserPhone], [UserMobile], [UserPermission], [Approver], [Status], [UpdateDate], [UpdateBy]) VALUES (3, N'test003', N'1234', N'Mr.', N'FF', N'Test', N'รปภ', N'D003', N'โรงงาน 2', N'100101', N'โรงงาน 2', N'0814442222', N'080777444', 3, N'นายอนุมัติ 2', CAST(1 AS Numeric(2, 0)), NULL, N'test001')
SET IDENTITY_INSERT [dbo].[UserData] OFF
SET IDENTITY_INSERT [dbo].[Vihicle] ON 

INSERT [dbo].[Vihicle] ([VihicleID], [VihicleCode], [VihicleBrand], [VihicleModel], [VihicleFuelType], [VihicleDate], [VihicleCost], [VihicleTypeCode], [VehicleTypeName], [VihicleYear], [VihicleAsset], [VihicleInsurance], [VihicleInsuranceType], [UpdateDate], [UpdateBy], [Status]) VALUES (CAST(6 AS Numeric(5, 0)), N'กจ-5555', N'Hino', N'T5', N'ดีเซล', N'10/10/2010', CAST(4000000.00 AS Numeric(10, 2)), N'T001', N'รถเก่ง 4 ที่นั่ง', NULL, N'GB-4421', N'วิริยะ', N'ชั้น 1', CAST(N'2018-09-27 00:58:23.277' AS DateTime), N'test001', CAST(1 AS Numeric(2, 0)))
INSERT [dbo].[Vihicle] ([VihicleID], [VihicleCode], [VihicleBrand], [VihicleModel], [VihicleFuelType], [VihicleDate], [VihicleCost], [VihicleTypeCode], [VehicleTypeName], [VihicleYear], [VihicleAsset], [VihicleInsurance], [VihicleInsuranceType], [UpdateDate], [UpdateBy], [Status]) VALUES (CAST(7 AS Numeric(5, 0)), N'งง-3252', N'THAIRUNG', N'G1', N'เบนซิน', N'05/09/2011', CAST(2300000.00 AS Numeric(10, 2)), N'T002', N'รถ SUV', NULL, N'CB-2215', N'ไทยประกันชีวิต', N'ชั้น 1', CAST(N'2018-09-27 00:59:31.077' AS DateTime), N'test001', CAST(1 AS Numeric(2, 0)))
SET IDENTITY_INSERT [dbo].[Vihicle] OFF
ALTER TABLE [dbo].[CarType] ADD  CONSTRAINT [DF__CarType__Status__5629CD9C]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[CarType] ADD  CONSTRAINT [DF__CarType__UpdateD__571DF1D5]  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Department] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Department] ADD  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Driver] ADD  CONSTRAINT [DF__Driver__Status__59FA5E80]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Driver] ADD  CONSTRAINT [DF__Driver__UpdateDa__5AEE82B9]  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[ForUse] ADD  CONSTRAINT [DF__ForUse__Status__5BE2A6F2]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[ForUse] ADD  CONSTRAINT [DF__ForUse__UpdateDa__5CD6CB2B]  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[InformationLogin] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[InformationLogin] ADD  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Location] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Location] ADD  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[RequestHeader] ADD  CONSTRAINT [DF__RequestHe__Piori__619B8048]  DEFAULT ((0)) FOR [Priority]
GO
ALTER TABLE [dbo].[RequestHeader] ADD  CONSTRAINT [DF__RequestHe__Reque__628FA481]  DEFAULT ((0)) FOR [RequestHeaderStatus]
GO
ALTER TABLE [dbo].[RequestLine] ADD  CONSTRAINT [DF__RequestLi__place__6477ECF3]  DEFAULT ((0)) FOR [Place]
GO
ALTER TABLE [dbo].[Section] ADD  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Section] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Vihicle] ADD  CONSTRAINT [DF__Vihicle__Status__2D27B809]  DEFAULT ((1)) FOR [Status]
GO
