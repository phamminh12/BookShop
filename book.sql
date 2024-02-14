USE [master]
GO
/****** Object:  Database [BookShopDb]    Script Date: 1/6/2024 2:24:48 PM ******/
CREATE DATABASE [BookShopDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookShopDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BookShopDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BookShopDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BookShopDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BookShopDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookShopDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookShopDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookShopDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookShopDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookShopDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookShopDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookShopDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookShopDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookShopDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookShopDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookShopDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookShopDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookShopDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookShopDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookShopDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookShopDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BookShopDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookShopDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookShopDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookShopDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookShopDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookShopDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookShopDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookShopDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BookShopDb] SET  MULTI_USER 
GO
ALTER DATABASE [BookShopDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookShopDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookShopDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookShopDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookShopDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BookShopDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BookShopDb] SET QUERY_STORE = OFF
GO
USE [BookShopDb]
GO
/****** Object:  Table [dbo].[AuthorTbl]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthorTbl](
	[AId] [int] IDENTITY(10,1) NOT NULL,
	[AName] [nvarchar](50) NOT NULL,
	[ABirth] [nvarchar](10) NOT NULL,
	[AHome] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AuthorTbl] PRIMARY KEY CLUSTERED 
(
	[AId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillTbl]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillTbl](
	[BillId] [int] IDENTITY(1000,1) NOT NULL,
	[UName] [varchar](50) NOT NULL,
	[ClientName] [varchar](50) NOT NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_BillTbl] PRIMARY KEY CLUSTERED 
(
	[BillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookTbl]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookTbl](
	[BId] [int] IDENTITY(100,1) NOT NULL,
	[BTitle] [varchar](100) NOT NULL,
	[BAuthor] [varchar](50) NOT NULL,
	[BCat] [varchar](50) NOT NULL,
	[BQty] [int] NOT NULL,
	[BPrice] [int] NOT NULL,
 CONSTRAINT [PK_BookTbl] PRIMARY KEY CLUSTERED 
(
	[BId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KindTbl]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KindTbl](
	[KindId] [int] IDENTITY(0,1) NOT NULL,
	[KName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_KindTbl] PRIMARY KEY CLUSTERED 
(
	[KindId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceiptTbl]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceiptTbl](
	[RId] [int] IDENTITY(100,1) NOT NULL,
	[RUser] [varchar](50) NOT NULL,
	[RTitle] [nvarchar](50) NOT NULL,
	[RAuthor] [nvarchar](50) NOT NULL,
	[RCat] [nvarchar](50) NOT NULL,
	[RQty] [int] NOT NULL,
	[RPrice] [int] NOT NULL,
 CONSTRAINT [PK_ReceiptTbl] PRIMARY KEY CLUSTERED 
(
	[RId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTbl]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTbl](
	[UId] [int] IDENTITY(500,1) NOT NULL,
	[UName] [varchar](50) NOT NULL,
	[UPhone] [varchar](50) NOT NULL,
	[UAdd] [varchar](50) NOT NULL,
	[UPass] [varchar](50) NOT NULL,
 CONSTRAINT [PK_UserTbl] PRIMARY KEY CLUSTERED 
(
	[UId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[addBook]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[addBook]
@Title nvarchar(50), @Author nvarchar(50),@Cat nvarchar(50),@Qty nvarchar(50), @Price nvarchar(50)
as
begin
	insert into BookTbl values(@Title, @Author, @Cat, @Qty, @Price)
end
GO
/****** Object:  StoredProcedure [dbo].[displayBook]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[displayBook]
as
begin
	select * from BookTbl
end
GO
/****** Object:  StoredProcedure [dbo].[SP_addAuthor]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_addAuthor]
@Auth nvarchar(50), @Birth nvarchar(10), @Home nvarchar(50)
as
	begin
		insert into AuthorTbl values(@Auth, @Birth, @Home)
	end
GO
/****** Object:  StoredProcedure [dbo].[SP_addAuthorIf]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_addAuthorIf]
@Auth nvarchar(50)
as
	begin
		if not exists (select 1 from AuthorTbl where AName = @Auth)
		begin
			insert into AuthorTbl values (@Auth, 'null','null')
		end
	end
GO
/****** Object:  StoredProcedure [dbo].[SP_addBook]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_addBook]
@Title nvarchar(50), @Author nvarchar(50),@Cat nvarchar(50),@Qty int, @Price int
as
begin
	insert into BookTbl values(@Title, @Author, @Cat, @Qty, @Price)
end
GO
/****** Object:  StoredProcedure [dbo].[SP_addCate]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_addCate]
@Kind nvarchar(50)
as
	begin
		insert into KindTbl values(@Kind)
	end
GO
/****** Object:  StoredProcedure [dbo].[SP_addReceipt]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_addReceipt]
@User varchar(50), @Title nvarchar(50), @Author nvarchar(50), @Cate nvarchar(50), @Qty int, @Price int
as
	begin
		insert into ReceiptTbl
		values (@User, @Title, @Author, @Cate, @Qty, @Price)
	end
GO
/****** Object:  StoredProcedure [dbo].[SP_deleteAuthor]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_deleteAuthor]
@Id int
as
	begin
		delete from AuthorTbl
		where AId=@Id
	end
GO
/****** Object:  StoredProcedure [dbo].[SP_deleteBook]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_deleteBook]
@Id int
as 
	begin
		delete BookTbl where BId = @Id
	end
GO
/****** Object:  StoredProcedure [dbo].[SP_deleteCate]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_deleteCate]
@Id int
as
	begin
		delete from KindTbl
		where KindId = @Id
	end
GO
/****** Object:  StoredProcedure [dbo].[SP_deleteReceipt]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_deleteReceipt]
@Id int
as
	begin
		delete from ReceiptTbl where RId = @Id
	end
GO
/****** Object:  StoredProcedure [dbo].[SP_deleteUser]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_deleteUser]
@Id int
as
 begin
 delete from UserTbl where UId = @Id
  
end
GO
/****** Object:  StoredProcedure [dbo].[SP_displayAuthor]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_displayAuthor]
as
	begin
		select * from AuthorTbl
	end
GO
/****** Object:  StoredProcedure [dbo].[SP_displayBook]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_displayBook]
as
begin
	select * from BookTbl
end
GO
/****** Object:  StoredProcedure [dbo].[SP_displayCate]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_displayCate]
as
	begin
		select * from KindTbl
	end
GO
/****** Object:  StoredProcedure [dbo].[SP_displayReceipt]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_displayReceipt]
as
	begin
		select * from ReceiptTbl
	end
GO
/****** Object:  StoredProcedure [dbo].[SP_displayUser]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_displayUser]
as
begin 
 select * from UserTbl
 end
GO
/****** Object:  StoredProcedure [dbo].[SP_editAuthor]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_editAuthor]
@Id int, @Auth nvarchar(50), @Birth nvarchar(10), @Home nvarchar(50)
as
	begin
		update AuthorTbl
		set AName = @Auth, ABirth = @Birth, AHome = @Home
		where AId = @Id
	end
GO
/****** Object:  StoredProcedure [dbo].[SP_editBook]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_editBook]
@Id int, @Title nvarchar(100), @Author nvarchar(50), @Cat nvarchar(50), @Qty int, @Price int
as
	begin
		update BookTbl
		set BTitle = @Title, BAuthor = @Author, BCat = @Cat, BQty = @Qty, BPrice = @Price
		where BId = @Id
	end
GO
/****** Object:  StoredProcedure [dbo].[SP_editCate]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_editCate]
@Id int, @Kind nvarchar(50)
as 
	begin
		update KindTbl
		set KName = @Kind
		where KindId = @Id
	end
GO
/****** Object:  StoredProcedure [dbo].[SP_editReceipt]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_editReceipt]
@Id int, @User varchar(50), @Title nvarchar(50), @Author nvarchar(50), @Cate nvarchar(50), @Qty int, @Price int
as
	begin 
		update ReceiptTbl
		set RTitle = @Title, RUser = @User, RAuthor = @Author, RCat = @Cate, RQty = @Qty, RPrice = @Price
		where RId = @Id
	end
GO
/****** Object:  StoredProcedure [dbo].[SP_editUser]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_editUser]
@Id int , @Name varchar(50),@Phone varchar(50),@Add varchar(50),@Pass varchar(50)
as
	begin
		update UserTbl
		set UName = @Name, UPhone = @Phone,UAdd = @Add, UPass = @Pass
	where UId = @Id

end 
GO
/****** Object:  StoredProcedure [dbo].[SP_fillBookDGV]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_fillBookDGV]
@Auth nvarchar(50)
as
	begin
		select * from BookTbl
		where BAuthor = @Auth
	end
GO
/****** Object:  StoredProcedure [dbo].[SP_fillBookDGV2]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_fillBookDGV2]
@Kind nvarchar(50)
as
	begin
		select * from BookTbl
		where BCat = @Kind
	end
GO
/****** Object:  StoredProcedure [dbo].[SP_saveUser]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_saveUser]
@Name nvarchar(50), @Phone nvarchar(50), @Add nvarchar(50), @Pass nvarchar(50)
as
	begin
		insert into UserTbl values(@Name, @Phone, @Add, @Pass)
	end
GO
/****** Object:  StoredProcedure [dbo].[SP_searchBook]    Script Date: 1/6/2024 2:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_searchBook]
@Text varchar(50)
as
	begin 
		select * from BookTbl
		where BTitle like '%' + @Text + '%' OR
			BAuthor like '%' + @Text + '%' or
			BCat like '%' + @Text + '%';
	end
GO
USE [master]
GO
ALTER DATABASE [BookShopDb] SET  READ_WRITE 
GO
