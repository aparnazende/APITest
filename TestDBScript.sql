USE [master]
GO
/****** Object:  Database [MusicDB]    Script Date: 2/8/2020 5:26:41 PM ******/
CREATE DATABASE [MusicDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MusicDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MusicDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MusicDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MusicDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MusicDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MusicDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MusicDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MusicDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MusicDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MusicDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MusicDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MusicDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MusicDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MusicDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MusicDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MusicDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MusicDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MusicDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MusicDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MusicDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MusicDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MusicDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MusicDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MusicDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MusicDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MusicDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MusicDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MusicDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MusicDB] SET RECOVERY FULL 
GO
ALTER DATABASE [MusicDB] SET  MULTI_USER 
GO
ALTER DATABASE [MusicDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MusicDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MusicDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MusicDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MusicDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MusicDB', N'ON'
GO
ALTER DATABASE [MusicDB] SET QUERY_STORE = OFF
GO
USE [MusicDB]
GO
/****** Object:  Table [dbo].[tAlbumRatings]    Script Date: 2/8/2020 5:26:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tAlbumRatings](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Rating] [tinyint] NOT NULL,
	[AlbumId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [date] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [date] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tAlbums]    Script Date: 2/8/2020 5:26:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tAlbums](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Review] [nvarchar](max) NOT NULL,
	[ArtistId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [date] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [date] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tArtists]    Script Date: 2/8/2020 5:26:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tArtists](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[GenreId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [date] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [date] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tCategory]    Script Date: 2/8/2020 5:26:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [date] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [date] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tGenres]    Script Date: 2/8/2020 5:26:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tGenres](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [date] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [date] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tSongRatings]    Script Date: 2/8/2020 5:26:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tSongRatings](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Rating] [tinyint] NOT NULL,
	[SongId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [date] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [date] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tSongs]    Script Date: 2/8/2020 5:26:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tSongs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Time] [varchar](50) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[AlbumId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [date] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [date] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tAlbumRatings]  WITH CHECK ADD  CONSTRAINT [FK_AlbumRatings_Albums] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[tAlbums] ([ID])
GO
ALTER TABLE [dbo].[tAlbumRatings] CHECK CONSTRAINT [FK_AlbumRatings_Albums]
GO
ALTER TABLE [dbo].[tAlbums]  WITH CHECK ADD  CONSTRAINT [FK_Albums_Artists] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[tArtists] ([ID])
GO
ALTER TABLE [dbo].[tAlbums] CHECK CONSTRAINT [FK_Albums_Artists]
GO
ALTER TABLE [dbo].[tArtists]  WITH CHECK ADD  CONSTRAINT [FK_Artists_Genres] FOREIGN KEY([GenreId])
REFERENCES [dbo].[tGenres] ([ID])
GO
ALTER TABLE [dbo].[tArtists] CHECK CONSTRAINT [FK_Artists_Genres]
GO
ALTER TABLE [dbo].[tGenres]  WITH CHECK ADD  CONSTRAINT [FK_Genres_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[tCategory] ([ID])
GO
ALTER TABLE [dbo].[tGenres] CHECK CONSTRAINT [FK_Genres_Category]
GO
ALTER TABLE [dbo].[tSongRatings]  WITH CHECK ADD  CONSTRAINT [FK_SongRatings_Songs] FOREIGN KEY([SongId])
REFERENCES [dbo].[tSongs] ([ID])
GO
ALTER TABLE [dbo].[tSongRatings] CHECK CONSTRAINT [FK_SongRatings_Songs]
GO
ALTER TABLE [dbo].[tSongs]  WITH CHECK ADD  CONSTRAINT [FK_Songs_Albums] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[tAlbums] ([ID])
GO
ALTER TABLE [dbo].[tSongs] CHECK CONSTRAINT [FK_Songs_Albums]
GO
USE [master]
GO
ALTER DATABASE [MusicDB] SET  READ_WRITE 
GO
