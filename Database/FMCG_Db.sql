USE [master]
GO
/****** Object:  Database [FMCG_Db]    Script Date: 5/22/2018 7:34:33 PM ******/
CREATE DATABASE [FMCG_Db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FMCG_Db', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\FMCG_Db.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FMCG_Db_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\FMCG_Db_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FMCG_Db] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FMCG_Db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FMCG_Db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FMCG_Db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FMCG_Db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FMCG_Db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FMCG_Db] SET ARITHABORT OFF 
GO
ALTER DATABASE [FMCG_Db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FMCG_Db] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [FMCG_Db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FMCG_Db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FMCG_Db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FMCG_Db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FMCG_Db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FMCG_Db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FMCG_Db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FMCG_Db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FMCG_Db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FMCG_Db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FMCG_Db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FMCG_Db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FMCG_Db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FMCG_Db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FMCG_Db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FMCG_Db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FMCG_Db] SET RECOVERY FULL 
GO
ALTER DATABASE [FMCG_Db] SET  MULTI_USER 
GO
ALTER DATABASE [FMCG_Db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FMCG_Db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FMCG_Db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FMCG_Db] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [FMCG_Db]
GO
/****** Object:  Table [dbo].[tb_Area]    Script Date: 5/22/2018 7:34:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_Area](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AreaName] [varchar](50) NOT NULL,
	[AreaCode] [varchar](5) NOT NULL,
 CONSTRAINT [PK_tb_Area] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_Category]    Script Date: 5/22/2018 7:34:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tb_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_Designation]    Script Date: 5/22/2018 7:34:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_Designation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DesignationName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tb_Designation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_Employee]    Script Date: 5/22/2018 7:34:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [varchar](50) NOT NULL,
	[FatherName] [varchar](50) NOT NULL,
	[MotherName] [varchar](50) NOT NULL,
	[GenderId] [int] NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[NID_Number] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](20) NOT NULL,
 CONSTRAINT [PK_tb_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_EmployeePasswordAndDesignation]    Script Date: 5/22/2018 7:34:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_EmployeePasswordAndDesignation](
	[Id] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[DesignationId] [int] NOT NULL,
	[Password] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_EmployeeRole]    Script Date: 5/22/2018 7:34:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_EmployeeRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_tb_EmployeeRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_Gender]    Script Date: 5/22/2018 7:34:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_Gender](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GenderName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tb_Gender] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_Item]    Script Date: 5/22/2018 7:34:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_Item](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tb_Item] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_ShopInfo]    Script Date: 5/22/2018 7:34:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_ShopInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShopName] [varchar](50) NOT NULL,
	[ShopkeeperName] [varchar](50) NOT NULL,
	[AreaId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[PhoneNumber] [varchar](20) NOT NULL,
 CONSTRAINT [PK_tb_ShopInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_StockIn]    Script Date: 5/22/2018 7:34:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_StockIn](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
	[Quentity] [int] NOT NULL,
	[EntryDate] [date] NOT NULL,
	[EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_tb_StockIn] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_StockOut]    Script Date: 5/22/2018 7:34:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_StockOut](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
	[Quentity] [int] NOT NULL,
	[ShopId] [int] NOT NULL,
	[AreaId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[OrderCollectDate] [date] NOT NULL,
	[Status] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tb_StockOut] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_UserRole]    Script Date: 5/22/2018 7:34:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tb_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_WH_Info]    Script Date: 5/22/2018 7:34:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_WH_Info](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WH_Name] [varchar](50) NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[Capacity] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_tb_WH_Info] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tb_Category] ON 

INSERT [dbo].[tb_Category] ([Id], [CategoryName]) VALUES (1, N'Food')
SET IDENTITY_INSERT [dbo].[tb_Category] OFF
ALTER TABLE [dbo].[tb_Employee]  WITH CHECK ADD  CONSTRAINT [FK_tb_Employee_tb_Gender] FOREIGN KEY([GenderId])
REFERENCES [dbo].[tb_Gender] ([Id])
GO
ALTER TABLE [dbo].[tb_Employee] CHECK CONSTRAINT [FK_tb_Employee_tb_Gender]
GO
ALTER TABLE [dbo].[tb_EmployeePasswordAndDesignation]  WITH CHECK ADD  CONSTRAINT [FK_tb_EmployeePasswordAndDesignation_tb_Designation] FOREIGN KEY([DesignationId])
REFERENCES [dbo].[tb_Designation] ([Id])
GO
ALTER TABLE [dbo].[tb_EmployeePasswordAndDesignation] CHECK CONSTRAINT [FK_tb_EmployeePasswordAndDesignation_tb_Designation]
GO
ALTER TABLE [dbo].[tb_EmployeePasswordAndDesignation]  WITH CHECK ADD  CONSTRAINT [FK_tb_EmployeePasswordAndDesignation_tb_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[tb_Employee] ([Id])
GO
ALTER TABLE [dbo].[tb_EmployeePasswordAndDesignation] CHECK CONSTRAINT [FK_tb_EmployeePasswordAndDesignation_tb_Employee]
GO
ALTER TABLE [dbo].[tb_EmployeeRole]  WITH CHECK ADD  CONSTRAINT [FK_tb_EmployeeRole_tb_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[tb_Employee] ([Id])
GO
ALTER TABLE [dbo].[tb_EmployeeRole] CHECK CONSTRAINT [FK_tb_EmployeeRole_tb_Employee]
GO
ALTER TABLE [dbo].[tb_EmployeeRole]  WITH CHECK ADD  CONSTRAINT [FK_tb_EmployeeRole_tb_UserRole] FOREIGN KEY([RoleId])
REFERENCES [dbo].[tb_UserRole] ([Id])
GO
ALTER TABLE [dbo].[tb_EmployeeRole] CHECK CONSTRAINT [FK_tb_EmployeeRole_tb_UserRole]
GO
ALTER TABLE [dbo].[tb_ShopInfo]  WITH CHECK ADD  CONSTRAINT [FK_tb_ShopInfo_tb_Area] FOREIGN KEY([AreaId])
REFERENCES [dbo].[tb_Area] ([Id])
GO
ALTER TABLE [dbo].[tb_ShopInfo] CHECK CONSTRAINT [FK_tb_ShopInfo_tb_Area]
GO
ALTER TABLE [dbo].[tb_ShopInfo]  WITH CHECK ADD  CONSTRAINT [FK_tb_ShopInfo_tb_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[tb_Employee] ([Id])
GO
ALTER TABLE [dbo].[tb_ShopInfo] CHECK CONSTRAINT [FK_tb_ShopInfo_tb_Employee]
GO
ALTER TABLE [dbo].[tb_StockIn]  WITH CHECK ADD  CONSTRAINT [FK_tb_StockIn_tb_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[tb_Category] ([Id])
GO
ALTER TABLE [dbo].[tb_StockIn] CHECK CONSTRAINT [FK_tb_StockIn_tb_Category]
GO
ALTER TABLE [dbo].[tb_StockIn]  WITH CHECK ADD  CONSTRAINT [FK_tb_StockIn_tb_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[tb_Employee] ([Id])
GO
ALTER TABLE [dbo].[tb_StockIn] CHECK CONSTRAINT [FK_tb_StockIn_tb_Employee]
GO
ALTER TABLE [dbo].[tb_StockIn]  WITH CHECK ADD  CONSTRAINT [FK_tb_StockIn_tb_Item] FOREIGN KEY([ItemId])
REFERENCES [dbo].[tb_Item] ([Id])
GO
ALTER TABLE [dbo].[tb_StockIn] CHECK CONSTRAINT [FK_tb_StockIn_tb_Item]
GO
ALTER TABLE [dbo].[tb_StockOut]  WITH CHECK ADD  CONSTRAINT [FK_tb_StockOut_tb_Area] FOREIGN KEY([AreaId])
REFERENCES [dbo].[tb_Area] ([Id])
GO
ALTER TABLE [dbo].[tb_StockOut] CHECK CONSTRAINT [FK_tb_StockOut_tb_Area]
GO
ALTER TABLE [dbo].[tb_StockOut]  WITH CHECK ADD  CONSTRAINT [FK_tb_StockOut_tb_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[tb_Category] ([Id])
GO
ALTER TABLE [dbo].[tb_StockOut] CHECK CONSTRAINT [FK_tb_StockOut_tb_Category]
GO
ALTER TABLE [dbo].[tb_StockOut]  WITH CHECK ADD  CONSTRAINT [FK_tb_StockOut_tb_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[tb_Employee] ([Id])
GO
ALTER TABLE [dbo].[tb_StockOut] CHECK CONSTRAINT [FK_tb_StockOut_tb_Employee]
GO
ALTER TABLE [dbo].[tb_StockOut]  WITH CHECK ADD  CONSTRAINT [FK_tb_StockOut_tb_Item] FOREIGN KEY([ItemId])
REFERENCES [dbo].[tb_Item] ([Id])
GO
ALTER TABLE [dbo].[tb_StockOut] CHECK CONSTRAINT [FK_tb_StockOut_tb_Item]
GO
ALTER TABLE [dbo].[tb_StockOut]  WITH CHECK ADD  CONSTRAINT [FK_tb_StockOut_tb_ShopInfo] FOREIGN KEY([ShopId])
REFERENCES [dbo].[tb_ShopInfo] ([Id])
GO
ALTER TABLE [dbo].[tb_StockOut] CHECK CONSTRAINT [FK_tb_StockOut_tb_ShopInfo]
GO
ALTER TABLE [dbo].[tb_WH_Info]  WITH CHECK ADD  CONSTRAINT [FK_tb_WH_Info_tb_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[tb_Employee] ([Id])
GO
ALTER TABLE [dbo].[tb_WH_Info] CHECK CONSTRAINT [FK_tb_WH_Info_tb_Employee]
GO
USE [master]
GO
ALTER DATABASE [FMCG_Db] SET  READ_WRITE 
GO
