USE [master]
GO
/****** Object:  Database [MyInsurance]    Script Date: 9.10.2018 06:44:46 ******/
CREATE DATABASE [MyInsurance]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyInsurance', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\MyInsurance.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MyInsurance_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\MyInsurance_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MyInsurance] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyInsurance].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyInsurance] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyInsurance] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyInsurance] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyInsurance] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyInsurance] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyInsurance] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MyInsurance] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyInsurance] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyInsurance] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyInsurance] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyInsurance] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyInsurance] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyInsurance] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyInsurance] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyInsurance] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MyInsurance] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyInsurance] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyInsurance] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyInsurance] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyInsurance] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyInsurance] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyInsurance] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyInsurance] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MyInsurance] SET  MULTI_USER 
GO
ALTER DATABASE [MyInsurance] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyInsurance] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyInsurance] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyInsurance] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MyInsurance] SET DELAYED_DURABILITY = DISABLED 
GO
USE [MyInsurance]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 9.10.2018 06:44:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Logo] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[ServiceDomain] [nvarchar](100) NULL,
	[ServicePath] [nvarchar](100) NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerCars]    Script Date: 9.10.2018 06:44:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerCars](
	[PlateNumber] [nvarchar](12) NOT NULL,
	[LicenseSerialCode] [nvarchar](50) NULL,
	[LicenseSerialNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_CustomerCars] PRIMARY KEY CLUSTERED 
(
	[PlateNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customers]    Script Date: 9.10.2018 06:44:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[TCNumber] [nvarchar](11) NOT NULL,
	[PlateNumber] [nvarchar](12) NOT NULL,
 CONSTRAINT [PK_Customers_1] PRIMARY KEY CLUSTERED 
(
	[TCNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OfferDetail]    Script Date: 9.10.2018 06:44:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OfferDetail](
	[Id] [int] NOT NULL,
	[Price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_OfferDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Offers]    Script Date: 9.10.2018 06:44:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerTcNumber] [nvarchar](11) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Description] [nvarchar](300) NULL,
 CONSTRAINT [PK_Offers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Companies] ON 

INSERT [dbo].[Companies] ([Id], [Name], [Logo], [Address], [ServiceDomain], [ServicePath]) VALUES (1, N'Allianz', N'logo-allianz.jpg', N'Kadiköy', N'http://localhost:1096', N'/api/offer/getallianzoffer')
INSERT [dbo].[Companies] ([Id], [Name], [Logo], [Address], [ServiceDomain], [ServicePath]) VALUES (2, N'Axa Sigorta', N'logo-axa.jpg', N'Ümraniye', N'http://localhost:1096', N'/api/offer/getaxaoffer')
INSERT [dbo].[Companies] ([Id], [Name], [Logo], [Address], [ServiceDomain], [ServicePath]) VALUES (3, N'Acıbadem Sigorta', N'logo-acibadem.jpg', N'Kartal', N'http://localhost:1096', N'/api/offer/getacibademoffer')
SET IDENTITY_INSERT [dbo].[Companies] OFF
INSERT [dbo].[CustomerCars] ([PlateNumber], [LicenseSerialCode], [LicenseSerialNumber]) VALUES (N'34TV8725', N'123', N'456')
INSERT [dbo].[CustomerCars] ([PlateNumber], [LicenseSerialCode], [LicenseSerialNumber]) VALUES (N'34TV8726', N'123123', N'dfgdfg')
INSERT [dbo].[CustomerCars] ([PlateNumber], [LicenseSerialCode], [LicenseSerialNumber]) VALUES (N'34TV8727', N'ttt', N'gg')
INSERT [dbo].[CustomerCars] ([PlateNumber], [LicenseSerialCode], [LicenseSerialNumber]) VALUES (N'34TV8728', N'123', N'456')
INSERT [dbo].[CustomerCars] ([PlateNumber], [LicenseSerialCode], [LicenseSerialNumber]) VALUES (N'34TV8729', N'123', N'456')
INSERT [dbo].[CustomerCars] ([PlateNumber], [LicenseSerialCode], [LicenseSerialNumber]) VALUES (N'34TV8730', N'123', N'456')
INSERT [dbo].[Customers] ([TCNumber], [PlateNumber]) VALUES (N'12345678912', N'34TV8725')
INSERT [dbo].[Customers] ([TCNumber], [PlateNumber]) VALUES (N'12345678913', N'34TV8726')
INSERT [dbo].[Customers] ([TCNumber], [PlateNumber]) VALUES (N'12345678914', N'34TV8727')
INSERT [dbo].[Customers] ([TCNumber], [PlateNumber]) VALUES (N'12345678915', N'34TV8728')
INSERT [dbo].[Customers] ([TCNumber], [PlateNumber]) VALUES (N'12345678916', N'34TV8729')
INSERT [dbo].[Customers] ([TCNumber], [PlateNumber]) VALUES (N'12345678917', N'34TV8730')
INSERT [dbo].[OfferDetail] ([Id], [Price]) VALUES (1, CAST(1240 AS Decimal(18, 0)))
INSERT [dbo].[OfferDetail] ([Id], [Price]) VALUES (2, CAST(1587 AS Decimal(18, 0)))
INSERT [dbo].[OfferDetail] ([Id], [Price]) VALUES (3, CAST(1667 AS Decimal(18, 0)))
INSERT [dbo].[OfferDetail] ([Id], [Price]) VALUES (4, CAST(1622 AS Decimal(18, 0)))
INSERT [dbo].[OfferDetail] ([Id], [Price]) VALUES (7, CAST(1403 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Offers] ON 

INSERT [dbo].[Offers] ([Id], [CustomerTcNumber], [CompanyId], [Description]) VALUES (1, N'12345678913', 2, N'Allianz Kasko Teklifi')
INSERT [dbo].[Offers] ([Id], [CustomerTcNumber], [CompanyId], [Description]) VALUES (2, N'12345678915', 2, N'Allianz Kasko Teklifi')
INSERT [dbo].[Offers] ([Id], [CustomerTcNumber], [CompanyId], [Description]) VALUES (3, N'12345678916', 2, N'Allianz Kasko Teklifi')
INSERT [dbo].[Offers] ([Id], [CustomerTcNumber], [CompanyId], [Description]) VALUES (4, N'12345678917', 2, N'Allianz Kasko Teklifi')
INSERT [dbo].[Offers] ([Id], [CustomerTcNumber], [CompanyId], [Description]) VALUES (5, N'12345678917', 2, N'Axa Kasko Teklifi')
INSERT [dbo].[Offers] ([Id], [CustomerTcNumber], [CompanyId], [Description]) VALUES (6, N'12345678917', 2, N'Axa Kasko Teklifi')
INSERT [dbo].[Offers] ([Id], [CustomerTcNumber], [CompanyId], [Description]) VALUES (7, N'12345678917', 3, N'Acıbadem Sigorta Kasko Teklifi')
SET IDENTITY_INSERT [dbo].[Offers] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Customers]    Script Date: 9.10.2018 06:44:46 ******/
CREATE NONCLUSTERED INDEX [IX_Customers] ON [dbo].[Customers]
(
	[TCNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_CustomerCars1] FOREIGN KEY([PlateNumber])
REFERENCES [dbo].[CustomerCars] ([PlateNumber])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_CustomerCars1]
GO
ALTER TABLE [dbo].[OfferDetail]  WITH CHECK ADD  CONSTRAINT [FK_OfferDetail_Offers] FOREIGN KEY([Id])
REFERENCES [dbo].[Offers] ([Id])
GO
ALTER TABLE [dbo].[OfferDetail] CHECK CONSTRAINT [FK_OfferDetail_Offers]
GO
ALTER TABLE [dbo].[Offers]  WITH CHECK ADD  CONSTRAINT [FK_Offers_Companies] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[Offers] CHECK CONSTRAINT [FK_Offers_Companies]
GO
ALTER TABLE [dbo].[Offers]  WITH CHECK ADD  CONSTRAINT [FK_Offers_Customers1] FOREIGN KEY([CustomerTcNumber])
REFERENCES [dbo].[Customers] ([TCNumber])
GO
ALTER TABLE [dbo].[Offers] CHECK CONSTRAINT [FK_Offers_Customers1]
GO
USE [master]
GO
ALTER DATABASE [MyInsurance] SET  READ_WRITE 
GO
