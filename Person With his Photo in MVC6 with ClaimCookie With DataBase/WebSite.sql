USE [master]
GO
/****** Object:  Database [WebSite]    Script Date: 6/2/2023 12:12:59 AM ******/
CREATE DATABASE [WebSite]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WebSite', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\WebSite.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WebSite_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\WebSite_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [WebSite] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WebSite].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WebSite] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WebSite] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WebSite] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WebSite] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WebSite] SET ARITHABORT OFF 
GO
ALTER DATABASE [WebSite] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WebSite] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WebSite] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WebSite] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WebSite] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WebSite] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WebSite] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WebSite] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WebSite] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WebSite] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WebSite] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WebSite] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WebSite] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WebSite] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WebSite] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WebSite] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WebSite] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WebSite] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WebSite] SET  MULTI_USER 
GO
ALTER DATABASE [WebSite] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WebSite] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WebSite] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WebSite] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WebSite] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WebSite] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [WebSite] SET QUERY_STORE = OFF
GO
USE [WebSite]
GO
/****** Object:  Table [dbo].[Admin_Login]    Script Date: 6/2/2023 12:12:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin_Login](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](30) NULL,
	[Password] [varchar](200) NULL,
 CONSTRAINT [PK_Admin_Login] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Istifadecilers]    Script Date: 6/2/2023 12:12:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Istifadecilers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NULL,
	[Surname] [varchar](20) NULL,
	[Photo] [varchar](200) NULL,
	[Uni] [varchar](20) NULL,
	[About] [varchar](500) NULL,
 CONSTRAINT [PK_Istifadecilers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registered_User]    Script Date: 6/2/2023 12:12:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registered_User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Email] [varchar](80) NULL,
	[Password] [varchar](300) NULL,
 CONSTRAINT [PK_Registered_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [WebSite] SET  READ_WRITE 
GO
