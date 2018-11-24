USE [master]
GO
/****** Object:  Database [LIMSCoreDb]    Script Date: 5/2/2018 9:46:05 AM ******/
CREATE DATABASE [LIMSCoreDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LIMSCoreDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\LIMSCoreDb.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LIMSCoreDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\LIMSCoreDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LIMSCoreDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LIMSCoreDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LIMSCoreDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LIMSCoreDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LIMSCoreDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LIMSCoreDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [LIMSCoreDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LIMSCoreDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LIMSCoreDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LIMSCoreDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LIMSCoreDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LIMSCoreDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LIMSCoreDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LIMSCoreDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LIMSCoreDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LIMSCoreDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LIMSCoreDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LIMSCoreDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LIMSCoreDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LIMSCoreDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LIMSCoreDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LIMSCoreDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LIMSCoreDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LIMSCoreDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LIMSCoreDb] SET  MULTI_USER 
GO
ALTER DATABASE [LIMSCoreDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LIMSCoreDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LIMSCoreDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LIMSCoreDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
USE [LIMSCoreDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Administration]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BlockName] [nvarchar](max) NULL,
	[DistrictName] [nvarchar](max) NULL,
	[LocationName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Administration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Apartment]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apartment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApartmentName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Apartment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Beacon]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beacon](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BeaconNum] [nvarchar](max) NULL,
	[BeaconType] [nvarchar](max) NULL,
	[DateSet] [datetime2](7) NOT NULL,
	[Hcoordinate] [float] NOT NULL,
	[HorizontalDatum] [nvarchar](max) NULL,
	[VerticalDatum] [nvarchar](max) NULL,
	[Xcoordinate] [float] NOT NULL,
	[Ycoordinate] [float] NOT NULL,
 CONSTRAINT [PK_Beacon] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Boundary]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Boundary](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BoundaryType] [nvarchar](max) NULL,
 CONSTRAINT [PK_Boundary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BoundaryBeacon]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoundaryBeacon](
	[BoundaryId] [int] NOT NULL,
	[BeaconId] [int] NOT NULL,
 CONSTRAINT [PK_BoundaryBeacon] PRIMARY KEY CLUSTERED 
(
	[BoundaryId] ASC,
	[BeaconId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Building]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Building](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApartmentId] [int] NOT NULL,
	[SpatialUnitId] [int] NOT NULL,
	[StreetAddress] [nvarchar](max) NULL,
 CONSTRAINT [PK_Building] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BuildingRegulations]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuildingRegulations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GCR] [float] NOT NULL,
	[PCR] [float] NOT NULL,
	[PlotFrontage] [float] NOT NULL,
 CONSTRAINT [PK_BuildingRegulations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BuruParcels]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuruParcels](
	[Id] [int] NULL,
	[Parcel_Num] [int] NULL,
	[Area2] [float] NULL,
	[Boundary] [nvarchar](30) NULL,
	[Shape_Leng] [float] NULL,
	[Shape_Area] [float] NULL,
	[Amount_Pai] [int] NULL,
	[Parcel_Own] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[Geometry] [varbinary](max) NULL,
	[ID1] [int] NOT NULL,
	[Geometry_SPA] [geometry] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Charge]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Charge](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [float] NOT NULL,
	[InterestRate] [float] NOT NULL,
	[lender] [nvarchar](max) NULL,
	[Ranking] [int] NOT NULL,
	[RepaymentTerm] [int] NOT NULL,
 CONSTRAINT [PK_Charge] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Freehold]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Freehold](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenureId] [int] NOT NULL,
 CONSTRAINT [PK_Freehold] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupGroupLeadership]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupGroupLeadership](
	[GroupId] [int] NOT NULL,
	[GroupLeadershipId] [int] NOT NULL,
 CONSTRAINT [PK_GroupGroupLeadership] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC,
	[GroupLeadershipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupGroupMembership]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupGroupMembership](
	[GroupMembershipId] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
 CONSTRAINT [PK_GroupGroupMembership] PRIMARY KEY CLUSTERED 
(
	[GroupMembershipId] ASC,
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupLeadership]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupLeadership](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LeadershipRole] [nvarchar](max) NULL,
	[LeadershipSince] [datetime2](7) NOT NULL,
	[LeadershipStatus] [nvarchar](max) NULL,
	[LeadershipUntil] [datetime2](7) NOT NULL,
	[PersonID] [int] NOT NULL,
 CONSTRAINT [PK_GroupLeadership] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupLeadershipPerson]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupLeadershipPerson](
	[GroupLeadershipId] [int] NOT NULL,
	[PersonId] [int] NOT NULL,
 CONSTRAINT [PK_GroupLeadershipPerson] PRIMARY KEY CLUSTERED 
(
	[GroupLeadershipId] ASC,
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupMembership]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupMembership](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MembershipShare] [float] NOT NULL,
	[MembershipSince] [datetime2](7) NOT NULL,
	[MembershipStatus] [nvarchar](max) NULL,
	[MembershipUntil] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_GroupMembership] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupOW]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupOW](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[County] [nvarchar](max) NULL,
	[GroupType] [nvarchar](max) NULL,
	[OwnerId] [int] NOT NULL,
 CONSTRAINT [PK_GroupOW] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InsitutionLeadership]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InsitutionLeadership](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberSince] [datetime2](7) NOT NULL,
	[MemberUntil] [datetime2](7) NOT NULL,
	[MembershipRole] [nvarchar](max) NULL,
	[MembershipStatus] [nvarchar](max) NULL,
 CONSTRAINT [PK_InsitutionLeadership] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Institution]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Institution](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InstitutionType] [nvarchar](max) NULL,
 CONSTRAINT [PK_Institution] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InstitutionInstitutionLeadership]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InstitutionInstitutionLeadership](
	[InstitutionLeadershipId] [int] NOT NULL,
	[InstitutionId] [int] NOT NULL,
 CONSTRAINT [PK_InstitutionInstitutionLeadership] PRIMARY KEY CLUSTERED 
(
	[InstitutionLeadershipId] ASC,
	[InstitutionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InstitutionLeadershipPerson]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InstitutionLeadershipPerson](
	[InstitutionLeadershipId] [int] NOT NULL,
	[PersonId] [int] NOT NULL,
 CONSTRAINT [PK_InstitutionLeadershipPerson] PRIMARY KEY CLUSTERED 
(
	[InstitutionLeadershipId] ASC,
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LandUse]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LandUse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BuildingRegulationsId] [int] NOT NULL,
	[EndDate] [datetime2](7) NULL,
	[LandUseStatus] [nvarchar](max) NULL,
	[LandUseType] [nvarchar](max) NULL,
	[RegulationAgency] [nvarchar](max) NULL,
	[StartDate] [datetime2](7) NULL,
	[ZoneId] [int] NOT NULL,
 CONSTRAINT [PK_LandUse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leasehold]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leasehold](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LeasePeriod] [datetime2](7) NOT NULL,
	[Lessor] [nvarchar](max) NULL,
	[TenureId] [int] NOT NULL,
 CONSTRAINT [PK_Leasehold] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MapIndex]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MapIndex](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MapSheetNum] [nvarchar](max) NULL,
	[ParcelId] [int] NOT NULL,
 CONSTRAINT [PK_MapIndex] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mortgage]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mortgage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [float] NOT NULL,
	[BuildingId] [nvarchar](max) NULL,
	[InterestRate] [float] NOT NULL,
	[Lender] [nvarchar](max) NULL,
	[Ranking] [int] NOT NULL,
	[RepaymentTerm] [int] NOT NULL,
 CONSTRAINT [PK_Mortgage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operation]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operation](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Parcelid] [int] NULL,
 CONSTRAINT [PK_Operation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Owner]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Owner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[OwnerType] [nvarchar](max) NULL,
	[PIN] [nvarchar](max) NULL,
	[PostalAddress] [nvarchar](max) NULL,
	[TelephoneAddress] [nvarchar](max) NULL,
 CONSTRAINT [PK_Owner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OwnershiRights]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OwnershiRights](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RightType] [nvarchar](max) NULL,
 CONSTRAINT [PK_OwnershiRights] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parcel]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parcel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Administrationid] [int] NOT NULL,
	[Area] [float] NULL,
	[LandUseId] [int] NOT NULL,
	[OwnerId] [int] NOT NULL,
	[OwnershipRights] [int] NOT NULL,
	[ParcelNum] [nvarchar](max) NOT NULL,
	[RegistrationId] [int] NOT NULL,
	[Responsibilities] [int] NOT NULL,
	[Restrictions] [int] NOT NULL,
	[SpatialUnitId] [int] NOT NULL,
	[TenureId] [int] NOT NULL,
	[ValuationId] [int] NOT NULL,
 CONSTRAINT [PK_Parcel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [money] NULL,
	[ModeOfPayment] [nchar](10) NULL,
	[PaymentDate] [datetime] NULL,
	[rateid] [int] NOT NULL,
	[ReceiptNo] [text] NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Mobile] [nvarchar](max) NULL,
	[OwnerId] [int] NOT NULL,
	[PersonType] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[PIN] [nvarchar](max) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonGroupMembership]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonGroupMembership](
	[GroupMembershipId] [int] NOT NULL,
	[PersonId] [int] NOT NULL,
 CONSTRAINT [PK_PersonGroupMembership] PRIMARY KEY CLUSTERED 
(
	[GroupMembershipId] ASC,
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rates]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rates](
	[id] [int] NOT NULL,
	[Amount] [money] NULL,
 CONSTRAINT [PK_Rates] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Jurisdiction] [nvarchar](max) NULL,
	[RegistrationDate] [datetime2](7) NULL,
	[RegistrationSection] [nvarchar](max) NULL,
	[RegistrationType] [nvarchar](max) NULL,
	[TitleNo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserve]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserve](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ComplianceStatus] [nvarchar](max) NULL,
	[EnforcingAuthority] [nvarchar](max) NULL,
	[ReserveType] [nvarchar](max) NULL,
 CONSTRAINT [PK_Reserve] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Responsibility]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Responsibility](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceRequirement] [nvarchar](max) NULL,
	[ResponsibilityType] [nvarchar](max) NULL,
 CONSTRAINT [PK_Responsibility] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Restriction]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restriction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[chrageId] [int] NULL,
	[landUseId] [int] NULL,
	[morgageid] [int] NULL,
	[ReserveID] [int] NULL,
	[RestrictionType] [nvarchar](max) NULL,
	[Statutoryid] [int] NULL,
 CONSTRAINT [PK_Restriction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[Id] [int] NOT NULL,
	[Date] [datetime] NULL,
	[IsComplete] [bit] NOT NULL,
	[OPid] [int] NOT NULL,
	[Progress] [int] NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpatialUnit]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpatialUnit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Area] [float] NULL,
	[BoundaryId] [int] NOT NULL,
	[Label] [nvarchar](max) NULL,
	[Layer] [nvarchar](max) NULL,
	[Length] [float] NULL,
	[MapIndexId] [int] NOT NULL,
	[PreliminaryUnitId] [int] NOT NULL,
	[ReferencePoint] [nvarchar](max) NULL,
	[SpatialUnitSetId] [int] NOT NULL,
	[SpatialUnitType] [nvarchar](max) NULL,
	[SurveyClassId] [int] NOT NULL,
	[Volume] [float] NULL,
 CONSTRAINT [PK_SpatialUnit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpatialUnitSet]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpatialUnitSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Label] [nvarchar](max) NULL,
 CONSTRAINT [PK_SpatialUnitSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpatialUnitSetRegistration]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpatialUnitSetRegistration](
	[RegistrationId] [int] NOT NULL,
	[SpatialUnitSetId] [int] NOT NULL,
 CONSTRAINT [PK_SpatialUnitSetRegistration] PRIMARY KEY CLUSTERED 
(
	[RegistrationId] ASC,
	[SpatialUnitSetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaturtoryRestriction]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaturtoryRestriction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NatureOfRestriction] [nvarchar](max) NULL,
	[RestrictingAuthority] [nvarchar](max) NULL,
 CONSTRAINT [PK_StaturtoryRestriction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Survey]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Survey](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompsNo] [nvarchar](max) NULL,
	[DateOfEntry] [datetime2](7) NULL,
	[ParcelId] [int] NOT NULL,
	[PDPRefNo] [int] NOT NULL,
	[PlansNo] [nvarchar](max) NULL,
	[SurveyorsName] [nvarchar](max) NULL,
	[TypeOfSurvey] [nvarchar](max) NULL,
 CONSTRAINT [PK_Survey] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tenure]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tenure](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenureType] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tenure] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Valution]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Valution](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Remarks] [nvarchar](max) NULL,
	[SerialNo] [nvarchar](max) NULL,
	[ValuationBookNo] [nvarchar](max) NULL,
	[ValuationDate] [datetime2](7) NULL,
	[Value] [float] NULL,
	[Valuer] [nvarchar](max) NULL,
 CONSTRAINT [PK_Valution] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zone]    Script Date: 5/2/2018 9:46:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zone](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RegulationId] [int] NOT NULL,
	[ZoneType] [nvarchar](max) NULL,
 CONSTRAINT [PK_Zone] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180420062117_InitialCreate', N'2.0.1-rtm-125')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180420063022_FirstMigration', N'2.0.1-rtm-125')
SET IDENTITY_INSERT [dbo].[Administration] ON 

INSERT [dbo].[Administration] ([Id], [BlockName], [DistrictName], [LocationName]) VALUES (1, N'Block 14', N'Kajiado', N'Ngong')
INSERT [dbo].[Administration] ([Id], [BlockName], [DistrictName], [LocationName]) VALUES (2, N'Block 15', N'Nairobi', N'Embakasi')
INSERT [dbo].[Administration] ([Id], [BlockName], [DistrictName], [LocationName]) VALUES (3, N'Block 16', N'Baringo', N'Kabarnet')
INSERT [dbo].[Administration] ([Id], [BlockName], [DistrictName], [LocationName]) VALUES (4, N'Block 17', N'Kisii', N'Masaba')
INSERT [dbo].[Administration] ([Id], [BlockName], [DistrictName], [LocationName]) VALUES (5, N'Block 18', N'Laikipia', N'Central Laikipia')
SET IDENTITY_INSERT [dbo].[Administration] OFF
SET IDENTITY_INSERT [dbo].[Apartment] ON 

INSERT [dbo].[Apartment] ([Id], [ApartmentName]) VALUES (1, N'New Apartment')
INSERT [dbo].[Apartment] ([Id], [ApartmentName]) VALUES (2, N'Old Apartment')
INSERT [dbo].[Apartment] ([Id], [ApartmentName]) VALUES (3, N'Current Apartment')
INSERT [dbo].[Apartment] ([Id], [ApartmentName]) VALUES (4, N'Apartment Complex')
INSERT [dbo].[Apartment] ([Id], [ApartmentName]) VALUES (5, N'Apartment Y')
SET IDENTITY_INSERT [dbo].[Apartment] OFF
SET IDENTITY_INSERT [dbo].[Beacon] ON 

INSERT [dbo].[Beacon] ([Id], [BeaconNum], [BeaconType], [DateSet], [Hcoordinate], [HorizontalDatum], [VerticalDatum], [Xcoordinate], [Ycoordinate]) VALUES (1, N'b25', NULL, CAST(N'2018-04-20T09:43:44.7966667' AS DateTime2), 0, N'Arc60-UTM-Zone37s', N'Arbitrary Local', 263435.7038, 9858042.189)
INSERT [dbo].[Beacon] ([Id], [BeaconNum], [BeaconType], [DateSet], [Hcoordinate], [HorizontalDatum], [VerticalDatum], [Xcoordinate], [Ycoordinate]) VALUES (2, N'b23', NULL, CAST(N'2018-04-20T09:43:44.7966667' AS DateTime2), 0, N'Arc60-UTM-Zone37s', N'Arbitrary Local', 263469.4335, 9857998.173)
INSERT [dbo].[Beacon] ([Id], [BeaconNum], [BeaconType], [DateSet], [Hcoordinate], [HorizontalDatum], [VerticalDatum], [Xcoordinate], [Ycoordinate]) VALUES (3, N'b27', NULL, CAST(N'2018-04-20T09:43:44.7966667' AS DateTime2), 0, N'Arc60-UTM-Zone37s', N'Arbitrary Local', 263435.7038, 9858042.189)
INSERT [dbo].[Beacon] ([Id], [BeaconNum], [BeaconType], [DateSet], [Hcoordinate], [HorizontalDatum], [VerticalDatum], [Xcoordinate], [Ycoordinate]) VALUES (4, N'bx', NULL, CAST(N'2018-04-20T09:43:44.7966667' AS DateTime2), 0, N'Arc60-UTM-Zone37s', N'Arbitrary Local', 263443.0679, 9858043.611)
INSERT [dbo].[Beacon] ([Id], [BeaconNum], [BeaconType], [DateSet], [Hcoordinate], [HorizontalDatum], [VerticalDatum], [Xcoordinate], [Ycoordinate]) VALUES (5, N'jy', NULL, CAST(N'2018-04-20T09:43:44.7966667' AS DateTime2), 0, N'Arc60-UTM-Zone37s', N'Arbitrary Local', 263450.7167, 9858045.087)
INSERT [dbo].[Beacon] ([Id], [BeaconNum], [BeaconType], [DateSet], [Hcoordinate], [HorizontalDatum], [VerticalDatum], [Xcoordinate], [Ycoordinate]) VALUES (6, N'a20', NULL, CAST(N'2018-04-20T09:43:44.7966667' AS DateTime2), 0, N'Arc60-UTM-Zone37s', N'Arbitrary Local', 263460.9107, 9858019.536)
INSERT [dbo].[Beacon] ([Id], [BeaconNum], [BeaconType], [DateSet], [Hcoordinate], [HorizontalDatum], [VerticalDatum], [Xcoordinate], [Ycoordinate]) VALUES (7, N'c23', NULL, CAST(N'2018-04-20T09:43:44.7966667' AS DateTime2), 0, N'Arc60-UTM-Zone37s', N'Arbitrary Local', 263463.8752, 9858012.105)
INSERT [dbo].[Beacon] ([Id], [BeaconNum], [BeaconType], [DateSet], [Hcoordinate], [HorizontalDatum], [VerticalDatum], [Xcoordinate], [Ycoordinate]) VALUES (8, N'c21', NULL, CAST(N'2018-04-20T09:43:44.7966667' AS DateTime2), 0, N'Arc60-UTM-Zone37s', N'Arbitrary Local', 263466.6543, 9858005.139)
INSERT [dbo].[Beacon] ([Id], [BeaconNum], [BeaconType], [DateSet], [Hcoordinate], [HorizontalDatum], [VerticalDatum], [Xcoordinate], [Ycoordinate]) VALUES (9, N'c19', NULL, CAST(N'2018-04-20T09:43:44.7966667' AS DateTime2), 0, N'Arc60-UTM-Zone37s', N'Arbitrary Local', 263469.4335, 9857998.173)
SET IDENTITY_INSERT [dbo].[Beacon] OFF
SET IDENTITY_INSERT [dbo].[Boundary] ON 

INSERT [dbo].[Boundary] ([Id], [BoundaryType]) VALUES (1, N'General')
INSERT [dbo].[Boundary] ([Id], [BoundaryType]) VALUES (2, N'Fixed')
INSERT [dbo].[Boundary] ([Id], [BoundaryType]) VALUES (3, N'Fixed')
INSERT [dbo].[Boundary] ([Id], [BoundaryType]) VALUES (4, N'General')
INSERT [dbo].[Boundary] ([Id], [BoundaryType]) VALUES (5, N'Fixed')
SET IDENTITY_INSERT [dbo].[Boundary] OFF
INSERT [dbo].[BoundaryBeacon] ([BoundaryId], [BeaconId]) VALUES (1, 1)
INSERT [dbo].[BoundaryBeacon] ([BoundaryId], [BeaconId]) VALUES (1, 2)
INSERT [dbo].[BoundaryBeacon] ([BoundaryId], [BeaconId]) VALUES (2, 3)
INSERT [dbo].[BoundaryBeacon] ([BoundaryId], [BeaconId]) VALUES (2, 4)
INSERT [dbo].[BoundaryBeacon] ([BoundaryId], [BeaconId]) VALUES (2, 5)
INSERT [dbo].[BoundaryBeacon] ([BoundaryId], [BeaconId]) VALUES (2, 6)
INSERT [dbo].[BoundaryBeacon] ([BoundaryId], [BeaconId]) VALUES (2, 7)
INSERT [dbo].[BoundaryBeacon] ([BoundaryId], [BeaconId]) VALUES (1, 8)
SET IDENTITY_INSERT [dbo].[Building] ON 

INSERT [dbo].[Building] ([Id], [ApartmentId], [SpatialUnitId], [StreetAddress]) VALUES (6, 1, 1, N'Utengano St.')
INSERT [dbo].[Building] ([Id], [ApartmentId], [SpatialUnitId], [StreetAddress]) VALUES (7, 2, 2, N'Mfangano St.')
INSERT [dbo].[Building] ([Id], [ApartmentId], [SpatialUnitId], [StreetAddress]) VALUES (8, 3, 3, N'Professional Way St.')
INSERT [dbo].[Building] ([Id], [ApartmentId], [SpatialUnitId], [StreetAddress]) VALUES (9, 4, 4, N'Professional Way St.')
INSERT [dbo].[Building] ([Id], [ApartmentId], [SpatialUnitId], [StreetAddress]) VALUES (10, 5, 5, N'Professional Way St.')
SET IDENTITY_INSERT [dbo].[Building] OFF
SET IDENTITY_INSERT [dbo].[BuildingRegulations] ON 

INSERT [dbo].[BuildingRegulations] ([Id], [GCR], [PCR], [PlotFrontage]) VALUES (1, 50, 100, 20)
INSERT [dbo].[BuildingRegulations] ([Id], [GCR], [PCR], [PlotFrontage]) VALUES (2, 60, 200, 25)
INSERT [dbo].[BuildingRegulations] ([Id], [GCR], [PCR], [PlotFrontage]) VALUES (3, 70, 200, 30)
INSERT [dbo].[BuildingRegulations] ([Id], [GCR], [PCR], [PlotFrontage]) VALUES (4, 80, 200, 25)
INSERT [dbo].[BuildingRegulations] ([Id], [GCR], [PCR], [PlotFrontage]) VALUES (5, 90, 300, 20)
INSERT [dbo].[BuildingRegulations] ([Id], [GCR], [PCR], [PlotFrontage]) VALUES (6, 100, 400, 35)
INSERT [dbo].[BuildingRegulations] ([Id], [GCR], [PCR], [PlotFrontage]) VALUES (7, 110, 500, 20)
INSERT [dbo].[BuildingRegulations] ([Id], [GCR], [PCR], [PlotFrontage]) VALUES (8, 120, 600, 25)
SET IDENTITY_INSERT [dbo].[BuildingRegulations] OFF
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (31, 954, 0.017519, N'b21,b22,A11b,A11a,A2a,A2b,b21', 56.1685649436, 175.189797198, 2500, N'James Karisa', N'Paid', NULL, 1, 0x0000000002050700000075EF595BF36F4240BD3CD88E8494F4BF9892B2C5F46F424000C13FE24194F4BF27906FC9F56F424065C14B9B3B94F4BFEBB01F02F76F4240405755690895F4BFFF970FF1F56F4240590BDF040F95F4BF5ACC70E3F36F42403415E8CCE194F4BF75EF595BF36F4240BD3CD88E8494F4BF000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (30, 953, 0.0164991, N'b23,b24,b22,b21,b23', 58.9976372902, 164.990325413, 3000, N'Michael Shume', N'Paid', NULL, 2, 0x0000000002050500000027906FC9F56F424065C14B9B3B94F4BFF3A46CF4F76F42406401102F2E94F4BF0BC61C2DF96F4240576087FFFA94F4BFEBB01F02F76F4240405755690895F4BF27906FC9F56F424065C14B9B3B94F4BF0000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (29, 952, 0.0164995, N'b25,b26,b24,b23,b25', 58.998663914, 164.99422582, 1600, N'Jopseph Kioko', N'Paid', NULL, 3, 0x00000000020505000000F3A46CF4F76F42406401102F2E94F4BFC8B6691FFA6F4240B65A41C52094F4BFF9B71D58FB6F42401552B995ED94F4BF0BC61C2DF96F4240576087FFFA94F4BFF3A46CF4F76F42406401102F2E94F4BF0000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (28, 951, 0.0164993, N'b27,b28,b26,b25,b27', 58.9978715546, 164.992627599, 0, N'Kevin Wamalwa', N'Not Paid', NULL, 4, 0x00000000020505000000C8B6691FFA6F4240B65A41C52094F4BF70A56A4AFC6F4240039D725B1394F4BF7FD31A83FD6F424075AC7D29E094F4BFF9B71D58FB6F42401552B995ED94F4BFC8B6691FFA6F4240B65A41C52094F4BF0000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (27, 950, 0.0164989, N'bx,A16,b28,b27,bx', 58.9976372869, 164.9903254, 690, N'John Kimeu', N'Paid', NULL, 5, 0x0000000002050500000070A56A4AFC6F4240039D725B1394F4BFADBD6775FE6F4240A54736EF0594F4BF10EC17AEFF6F42403020AFBFD294F4BF7FD31A83FD6F424075AC7D29E094F4BF70A56A4AFC6F4240039D725B1394F4BF0000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (26, 949, 0.0296378, N'bx,Jy,A20,A17,A16,bx', 77.9920018521, 296.377659983, 550, N'Stephen Ombati', N'Paid', NULL, 6, 0x00000000020506000000ADBD6775FE6F4240A54736EF0594F4BF9A9ADBB500704240E9F87E00F893F4BF22FA67B4037042404F2E7E4FEA94F4BF2606C1180070424090A472921895F4BF10EC17AEFF6F42403020AFBFD294F4BFADBD6775FE6F4240A54736EF0594F4BF00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (25, 966, 0.0166979, N'A18b,A19,A17,A20,C23,C24,A18a', 57.3153675631, 166.97947899, 2000, N'John Williams', N'Paid', NULL, 7, 0x000000000205070000002606C1180070424090A472921895F4BF22FA67B4037042404F2E7E4FEA94F4BFD80F5593047042401AA4F9C73095F4BF058EA89CFE6F42407728ED227F95F4BF73E0D535FE6F4240E2CCA8A05E95F4BFA4FF61F3FE6F42408AD92F412795F4BF2606C1180070424090A472921895F4BF000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (24, 967, 0.0164101, N'C24,C23,C21,C22,C24', 58.7622422973, 164.100993999, 3500, N'Faith Kasichana', N'Paid', NULL, 8, 0x00000000020505000000D80F5593047042401AA4F9C73095F4BFC04E4D64057042401EDF8FD77295F4BF42A3A46DFF6F4240972E8332C195F4BF058EA89CFE6F42407728ED227F95F4BFD80F5593047042401AA4F9C73095F4BF0000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (23, 968, 0.0164101, N'C22,C21,C19,C20,C22', 58.7621312868, 164.101125599, 1500, N'Doughlas Mutua', N'Paid', NULL, 9, 0x00000000020505000000C04E4D64057042401EDF8FD77295F4BFD268493506704240B25326E7B495F4BFF9B7A03E00704240D55319420396F4BF42A3A46DFF6F4240972E8332C195F4BFC04E4D64057042401EDF8FD77295F4BF0000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (22, 969, 0.0164101, N'C20,C19,C17,C18,C20', 58.7621312873, 164.101125598, 4000, N'Martin Nyasau', N'Paid', NULL, 10, 0x00000000020505000000D268493506704240B25326E7B495F4BF608245060770424062E7BCF6F695F4BF31CC9C0F017042403098AF514596F4BFF9B7A03E00704240D55319420396F4BFD268493506704240B25326E7B495F4BF0000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (21, 970, 0.0222867, N'C18,C17,A5,A8,A19b,A19a,C18', 63.8141560318, 222.866715001, 1200, N'Hilton Muema', N'Paid', NULL, 11, 0x00000000020507000000608245060770424062E7BCF6F695F4BFFD3AA17E0870424078C247976D96F4BF3954DB2C067042400BC1EC937796F4BFA4C0063903704240F6BA094C8496F4BFFD9A4A6B017042409569D64C6296F4BF31CC9C0F017042403098AF514596F4BF608245060770424062E7BCF6F695F4BF000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (20, 959, 0.0368068, N'A5,A4,NLA4,A9,A8,A5', 86.6391496771, 368.065478817, 3900, N'Eunice Kizito', N'Paid', NULL, 12, 0x0000000002050600000079132DF90B70424023C51D188797F4BFE6FD536207704240B5DD0BDE9A97F4BFC738AE7F06704240BA4DF551CA96F4BF3954DB2C067042400BC1EC937796F4BFFD3AA17E0870424078C247976D96F4BF79132DF90B70424023C51D188797F4BF00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (19, 960, 0.0166523, N'A9,NLA4,C15,C16,A9', 59.4059534765, 166.520657172, 700, N'Mike Shujaa', N'Paid', NULL, 13, 0x00000000020505000000E6FD536207704240B5DD0BDE9A97F4BF28782C32057042402127B34AA497F4BF7ECA844F04704240DFAFE2BDD396F4BFC738AE7F06704240BA4DF551CA96F4BFE6FD536207704240B5DD0BDE9A97F4BF0000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (18, 961, 0.0166521, N'C16,C15,C13,C14,C16', 59.4059420263, 166.520575898, 0, N'Eve Kamusi', N'Not Paid', NULL, 14, 0x0000000002050500000028782C32057042402127B34AA497F4BF12F20402037042407CC852B8AD97F4BF16355F1F02704240EC4A3D2CDD96F4BF7ECA844F04704240DFAFE2BDD396F4BF28782C32057042402127B34AA497F4BF0000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (17, 962, 0.0166523, N'C14,C13,C11,C12,C14', 59.4059534765, 166.520657172, 0, N'Dorris Mbetha', N'Not Paid', NULL, 15, 0x0000000002050500000012F20402037042407CC852B8AD97F4BFF46EDDD1007042407EB8F924B797F4BF6DC935EFFF6F4240A7532A98E696F4BF16355F1F02704240EC4A3D2CDD96F4BF12F20402037042407CC852B8AD97F4BF0000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (16, 963, 0.0166525, N'C12,C11,C9,C10,C12', 59.4063384491, 166.524975071, 150, N'Dismas Victor', N'Paid', NULL, 16, 0x00000000020505000000F46EDDD1007042407EB8F924B797F4BFD30FB2A1FE6F4240FAE59892C097F4BFF95A0CBFFD6F4240DC7A8406F096F4BF6DC935EFFF6F4240A7532A98E696F4BFF46EDDD1007042407EB8F924B797F4BF0000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (15, 964, 0.0166523, N'C10,C9,C7,C8,C10', 59.4059534776, 166.520657183, 0, N'Tom Kioko', N'Not Paid', NULL, 17, 0x00000000020505000000D30FB2A1FE6F4240FAE59892C097F4BF548F8A71FC6F4240927C3FFFC997F4BFF1F1E28EFB6F4240312A7172F996F4BFF95A0CBFFD6F4240DC7A8406F096F4BFD30FB2A1FE6F4240FAE59892C097F4BF0000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (14, 965, 0.0166526, N'C8,C7,C5,C6,C8', 59.4063653827, 166.524448282, 0, N'John Mutua', N'Not Paid', NULL, 18, 0x00000000020505000000548F8A71FC6F4240927C3FFFC997F4BF40206141FA6F4240F47E1C6DD397F4BF1C86B95EF96F4240F8F7CAE00297F4BFF1F1E28EFB6F4240312A7172F996F4BF548F8A71FC6F4240927C3FFFC997F4BF0000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (13, 958, 0.0218554, N'C6,C5,NLA3,A7,A10a,A10b,C6', 62.2732471236, 218.554709596, 2100, N'Benard Charles', N'Paid', NULL, 19, 0x0000000002050700000040206141FA6F4240F47E1C6DD397F4BF25663560F76F4240076EEDD3DF97F4BF3848A5DEF66F4240D8FD60828297F4BFF0B20079F66F42406D9A6FDB3C97F4BF81DABC7DF76F4240ECD9A3F80A97F4BF1C86B95EF96F4240F8F7CAE00297F4BF40206141FA6F4240F47E1C6DD397F4BF000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (12, 948, 0.0295882, N'A7,NLA3,A3,b1,A6,A7', 82.5411998832, 295.883370221, 1700, N'Dennis Munyoki', N'Paid', NULL, 20, 0x0000000002050600000025663560F76F4240076EEDD3DF97F4BF5CF5310AEE6F424058DE330C0898F4BFC0388A96ED6F4240127F68CAB897F4BF84997143F46F424078C220CC9197F4BF3848A5DEF66F4240D8FD60828297F4BF25663560F76F4240076EEDD3DF97F4BF00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (11, 947, 0.0172864, N'b20,A6,b1,b2,b20', 61.0972837913, 172.8636171, 0, N'Tevin Otieno', N'Not Paid', NULL, 21, 0x0000000002050500000084997143F46F424078C220CC9197F4BFC0388A96ED6F4240127F68CAB897F4BF461A7A30ED6F4240996E13DD7297F4BF937A61DDF36F42401DE15DDC4B97F4BF84997143F46F424078C220CC9197F4BF0000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (10, 946, 0.0172864, N'b19,b20,b2,b3,b19', 61.0974442693, 172.863941404, 800, N'Nelson Kyalo', N'Paid', NULL, 22, 0x0000000002050500000003325577F36F42404A7608EF0597F4BF937A61DDF36F42401DE15DDC4B97F4BF461A7A30ED6F4240996E13DD7297F4BFBAFE69CAEC6F4240F82351ED2C97F4BF03325577F36F42404A7608EF0597F4BF0000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (9, 945, 0.0172877, N'b18,b19,b3,b4,b18', 61.098481424, 172.875749604, 500, N'Job Charo', N'Paid', NULL, 23, 0x0000000002050500000003E25964EC6F42404FEA8EFDE696F4BFB8104511F36F4240D5B645FFBF96F4BF03325577F36F42404A7608EF0597F4BFBAFE69CAEC6F4240F82351ED2C97F4BF03E25964EC6F42404FEA8EFDE696F4BF0000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (8, 944, 0.0172852, N'b17,b18,b4,b5,b17', 61.0962815677, 172.851923499, 2300, N'Clinton Kaluma', N'Paid', NULL, 24, 0x00000000020505000000AF9B4DFEEB6F424025273A10A196F4BF27EA34ABF26F42407053F0117A96F4BFB8104511F36F4240D5B645FFBF96F4BF03E25964EC6F42404FEA8EFDE696F4BFAF9B4DFEEB6F424025273A10A196F4BF0000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (7, 943, 0.0172874, N'b16,b17,b5,b6,b16', 61.0982483851, 172.874598786, 4000, N'Beatrice Shungu', N'Paid', NULL, 25, 0x000000000205050000009E7C3D98EB6F4240AD0F78205B96F4BF2CA22845F26F424057D02D223496F4BF27EA34ABF26F42407053F0117A96F4BFAF9B4DFEEB6F424025273A10A196F4BF9E7C3D98EB6F4240AD0F78205B96F4BF0000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (6, 942, 0.0172853, N'b15,b16,b6,b7,b15', 61.0965146106, 172.853074199, 2300, N'Joyce Kiptoo', N'Paid', NULL, 26, 0x0000000002050500000047582D32EB6F4240F55323331596F4BF417918DFF16F4240D48ED834EE95F4BF2CA22845F26F424057D02D223496F4BF9E7C3D98EB6F4240AD0F78205B96F4BF47582D32EB6F4240F55323331596F4BF0000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (5, 941, 0.0172876, N'b14,b15,b7,b8,b14', 61.0984814247, 172.875749607, 1800, N'Winnie Nyasuguta', N'Paid', NULL, 27, 0x00000000020505000000DD361DCCEA6F4240155E6143CF95F4BF46530879F16F42402E131645A895F4BF417918DFF16F4240D48ED834EE95F4BF47582D32EB6F4240F55323331596F4BFDD361DCCEA6F4240155E6143CF95F4BF0000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (4, 940, 0.0172865, N'b13,b14,b8,b9,b13', 61.0974442689, 172.863941402, 0, N'Joan Moraa', N'Not Paid', NULL, 28, 0x00000000020505000000DD361DCCEA6F4240155E6143CF95F4BFD8EB1066EA6F4240B8DE0C568995F4BF1C2CF812F16F424076A853556295F4BF46530879F16F42402E131645A895F4BFDD361DCCEA6F4240155E6143CF95F4BF0000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (3, 939, 0.0172864, N'b12,b13,b9,b10,b12', 61.0974442689, 172.863941402, 0, N'Titus Owino', N'Not Paid', NULL, 29, 0x00000000020505000000D8EB1066EA6F4240B8DE0C568995F4BF15C80000EA6F4240C10A4B664395F4BF56DBEBACF06F424043B4FE671C95F4BF1C2CF812F16F424076A853556295F4BFD8EB1066EA6F4240B8DE0C568995F4BF0000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (2, 938, 0.0172865, N'b11x,b12,b10,b11,b11x', 61.0976773106, 172.865092205, 0, N'Fredrick Chobo', N'Not Paid', NULL, 30, 0x0000000002050500000015C80000EA6F4240C10A4B664395F4BF0B9FF099E96F4240D492F678FD94F4BFD4B1DB46F06F4240736B3C78D694F4BF56DBEBACF06F424043B4FE671C95F4BF15C80000EA6F4240C10A4B664395F4BF0000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (1, 937, 0.0242892, N'A1a,A1b,b11x,b11,J4a,J4b,A1a', 63.2691315546, 242.892200596, 0, N'Patrick Webo', N'Not Paid', NULL, 31, 0x000000000205070000000B9FF099E96F4240D492F678FD94F4BF3BF2E347E96F4240A4B3143FC594F4BF47F296B6EA6F4240F5DE41F18294F4BFFDE893E4ED6F4240F1FBE8426F94F4BFB68A36F2EF6F4240B9B3DF7A9C94F4BFD4B1DB46F06F4240736B3C78D694F4BF0B9FF099E96F4240D492F678FD94F4BF000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (33, 956, 0.0204476, N'C1,C2,C4,C3,C1', 67.3120923544, 204.476354567, 3100, N'Josphine Kamau', N'Paid', NULL, 32, 0x00000000020505000000611DBB4FF56F4240DBEC50601796F4BF9566077DFC6F42407EDC9FEFEC95F4BF95E71E60FD6F424052838FB93496F4BF3E8CFBBCF56F4240BBAC0CE26196F4BF611DBB4FF56F4240DBEC50601796F4BF0000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (32, 955, 0.0225726, N'A12b,A14a,A14b,C2,C1A12a', 63.4896099073, 225.725892122, 2000, N'George Wanyama', N'Paid', NULL, 33, 0x00000000020507000000611DBB4FF56F4240DBEC50601796F4BFD00A3C0FF56F4240EA0D3F2CEB95F4BF4D54757BF66F4240632BAD79A995F4BFE3AF34FFF96F424071D3ACB19495F4BFC516DAC9FB6F42402771344DB495F4BF9566077DFC6F42407EDC9FEFEC95F4BF611DBB4FF56F4240DBEC50601796F4BF000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (34, 957, 0.0276356, N'C3,C4,A15b,A15a,A13b,A13a,C3', 70.3188242945, 276.355904516, 1500, N'Simon Makana', N'Paid', NULL, 34, 0x000000000205070000003E8CFBBCF56F4240BBAC0CE26196F4BF95E71E60FD6F424052838FB93496F4BFA6CCEE1EFE6F4240B96F8FFD6A96F4BFC3150A06FD6F42405E1C6E5EA796F4BF95550E1AF86F4240A5AAB293BC96F4BF537D7EFDF56F4240356DB1138E96F4BF3E8CFBBCF56F4240BBAC0CE26196F4BF000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
INSERT [dbo].[BuruParcels] ([Id], [Parcel_Num], [Area2], [Boundary], [Shape_Leng], [Shape_Area], [Amount_Pai], [Parcel_Own], [Status], [Geometry], [ID1], [Geometry_SPA]) VALUES (35, 971, 1.11474, N'A3,A4,JX,J1,SEX,A3', 425.906906063, 11147.3713787, 2000, N'Elius Mulley', N'Paid', NULL, 35, 0x0000000002050E0000005CF5310AEE6F424058DE330C0898F4BF25663560F76F4240076EEDD3DF97F4BF40206141FA6F4240F47E1C6DD397F4BF548F8A71FC6F4240927C3FFFC997F4BFD30FB2A1FE6F4240FAE59892C097F4BFF46EDDD1007042407EB8F924B797F4BF12F20402037042407CC852B8AD97F4BF28782C32057042402127B34AA497F4BFE6FD536207704240B5DD0BDE9A97F4BF79132DF90B70424023C51D188797F4BF1BBFF15517704240541503971E9BF4BF158D631EFF6F4240EE0AAF03559CF4BFCD0E6EB4EE6F4240664382B37C98F4BF5CF5310AEE6F424058DE330C0898F4BF0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000001000000FFFFFFFF0000000003)
SET IDENTITY_INSERT [dbo].[Charge] ON 

INSERT [dbo].[Charge] ([Id], [Amount], [InterestRate], [lender], [Ranking], [RepaymentTerm]) VALUES (1, 2000000, 30, N'Standard Chartered Bank, Kenya Limited', 2, 20)
INSERT [dbo].[Charge] ([Id], [Amount], [InterestRate], [lender], [Ranking], [RepaymentTerm]) VALUES (2, 2000000, 30, N'Family Bank', 2, 20)
INSERT [dbo].[Charge] ([Id], [Amount], [InterestRate], [lender], [Ranking], [RepaymentTerm]) VALUES (3, 2000000, 30, N'CfC Life', 2, 20)
INSERT [dbo].[Charge] ([Id], [Amount], [InterestRate], [lender], [Ranking], [RepaymentTerm]) VALUES (4, 2000000, 25, N'Ndatani Enterprises Co. Limited', 2, 20)
INSERT [dbo].[Charge] ([Id], [Amount], [InterestRate], [lender], [Ranking], [RepaymentTerm]) VALUES (5, 2000000, 20, N'KCB', 2, 20)
INSERT [dbo].[Charge] ([Id], [Amount], [InterestRate], [lender], [Ranking], [RepaymentTerm]) VALUES (6, 2000000, 20, N'KCB', 2, 20)
INSERT [dbo].[Charge] ([Id], [Amount], [InterestRate], [lender], [Ranking], [RepaymentTerm]) VALUES (7, 2000000, 25, N'Commercial Bank of Africa', 2, 20)
INSERT [dbo].[Charge] ([Id], [Amount], [InterestRate], [lender], [Ranking], [RepaymentTerm]) VALUES (8, 2000000, 30, N'KCB', 2, 20)
SET IDENTITY_INSERT [dbo].[Charge] OFF
SET IDENTITY_INSERT [dbo].[GroupLeadership] ON 

INSERT [dbo].[GroupLeadership] ([Id], [LeadershipRole], [LeadershipSince], [LeadershipStatus], [LeadershipUntil], [PersonID]) VALUES (1, N'Chairperson', CAST(N'2018-04-20T10:07:11.0966667' AS DateTime2), N'Active', CAST(N'2018-04-20T10:07:11.0966667' AS DateTime2), 1)
INSERT [dbo].[GroupLeadership] ([Id], [LeadershipRole], [LeadershipSince], [LeadershipStatus], [LeadershipUntil], [PersonID]) VALUES (2, N'Chairperson', CAST(N'2018-04-20T10:07:11.0966667' AS DateTime2), N'Active', CAST(N'2018-04-20T10:07:11.0966667' AS DateTime2), 2)
INSERT [dbo].[GroupLeadership] ([Id], [LeadershipRole], [LeadershipSince], [LeadershipStatus], [LeadershipUntil], [PersonID]) VALUES (3, N'Secretary', CAST(N'2018-04-20T10:07:11.0966667' AS DateTime2), N'Active', CAST(N'2018-04-20T10:07:11.0966667' AS DateTime2), 3)
INSERT [dbo].[GroupLeadership] ([Id], [LeadershipRole], [LeadershipSince], [LeadershipStatus], [LeadershipUntil], [PersonID]) VALUES (4, N'Chairperson', CAST(N'2018-04-20T10:07:11.0966667' AS DateTime2), N'Active', CAST(N'2018-04-20T10:07:11.0966667' AS DateTime2), 4)
INSERT [dbo].[GroupLeadership] ([Id], [LeadershipRole], [LeadershipSince], [LeadershipStatus], [LeadershipUntil], [PersonID]) VALUES (5, N'Treasurer', CAST(N'2018-04-20T10:07:11.0966667' AS DateTime2), N'Active', CAST(N'2018-04-20T10:07:11.0966667' AS DateTime2), 5)
SET IDENTITY_INSERT [dbo].[GroupLeadership] OFF
SET IDENTITY_INSERT [dbo].[GroupMembership] ON 

INSERT [dbo].[GroupMembership] ([Id], [MembershipShare], [MembershipSince], [MembershipStatus], [MembershipUntil]) VALUES (1, 0.4, CAST(N'2018-04-20T10:07:20.6566667' AS DateTime2), N'Active', CAST(N'2018-04-20T10:07:20.6566667' AS DateTime2))
INSERT [dbo].[GroupMembership] ([Id], [MembershipShare], [MembershipSince], [MembershipStatus], [MembershipUntil]) VALUES (2, 0.3, CAST(N'2018-04-20T10:07:20.6566667' AS DateTime2), N'Active', CAST(N'2018-04-20T10:07:20.6566667' AS DateTime2))
INSERT [dbo].[GroupMembership] ([Id], [MembershipShare], [MembershipSince], [MembershipStatus], [MembershipUntil]) VALUES (3, 0.05, CAST(N'2018-04-20T10:07:20.6566667' AS DateTime2), N'Active', CAST(N'2018-04-20T10:07:20.6566667' AS DateTime2))
INSERT [dbo].[GroupMembership] ([Id], [MembershipShare], [MembershipSince], [MembershipStatus], [MembershipUntil]) VALUES (4, 0.5, CAST(N'2018-04-20T10:07:20.6566667' AS DateTime2), N'Active', CAST(N'2018-04-20T10:07:20.6566667' AS DateTime2))
SET IDENTITY_INSERT [dbo].[GroupMembership] OFF
SET IDENTITY_INSERT [dbo].[InsitutionLeadership] ON 

INSERT [dbo].[InsitutionLeadership] ([Id], [MemberSince], [MemberUntil], [MembershipRole], [MembershipStatus]) VALUES (1, CAST(N'2018-04-20T10:07:25.7133333' AS DateTime2), CAST(N'2018-04-20T10:07:25.7133333' AS DateTime2), N'Chairperson', N'Active')
INSERT [dbo].[InsitutionLeadership] ([Id], [MemberSince], [MemberUntil], [MembershipRole], [MembershipStatus]) VALUES (2, CAST(N'2018-04-20T10:07:25.7133333' AS DateTime2), CAST(N'2018-04-20T10:07:25.7133333' AS DateTime2), N'Secretary', N'Active')
INSERT [dbo].[InsitutionLeadership] ([Id], [MemberSince], [MemberUntil], [MembershipRole], [MembershipStatus]) VALUES (3, CAST(N'2018-04-20T10:07:25.7133333' AS DateTime2), CAST(N'2018-04-20T10:07:25.7133333' AS DateTime2), N'Treasurer', N'Active')
INSERT [dbo].[InsitutionLeadership] ([Id], [MemberSince], [MemberUntil], [MembershipRole], [MembershipStatus]) VALUES (4, CAST(N'2018-04-20T10:07:25.7133333' AS DateTime2), CAST(N'2018-04-20T10:07:25.7133333' AS DateTime2), N'Member', N'Inactive')
INSERT [dbo].[InsitutionLeadership] ([Id], [MemberSince], [MemberUntil], [MembershipRole], [MembershipStatus]) VALUES (5, CAST(N'2018-04-20T10:07:25.7133333' AS DateTime2), CAST(N'2018-04-20T10:07:25.7133333' AS DateTime2), N'Chairperson', N'Active')
SET IDENTITY_INSERT [dbo].[InsitutionLeadership] OFF
SET IDENTITY_INSERT [dbo].[Institution] ON 

INSERT [dbo].[Institution] ([Id], [InstitutionType]) VALUES (1, N'Primary School')
INSERT [dbo].[Institution] ([Id], [InstitutionType]) VALUES (2, N'Nationa Forest Reserve')
INSERT [dbo].[Institution] ([Id], [InstitutionType]) VALUES (3, N'Shrine')
INSERT [dbo].[Institution] ([Id], [InstitutionType]) VALUES (4, N'Childrens Playground')
INSERT [dbo].[Institution] ([Id], [InstitutionType]) VALUES (5, N'Primary School')
INSERT [dbo].[Institution] ([Id], [InstitutionType]) VALUES (6, N'Primary School')
SET IDENTITY_INSERT [dbo].[Institution] OFF
SET IDENTITY_INSERT [dbo].[LandUse] ON 

INSERT [dbo].[LandUse] ([Id], [BuildingRegulationsId], [EndDate], [LandUseStatus], [LandUseType], [RegulationAgency], [StartDate], [ZoneId]) VALUES (1, 1, CAST(N'2018-04-20T09:43:33.2500000' AS DateTime2), N'Active', N'Agricultural', N'Agency X', CAST(N'2018-04-20T09:43:33.2500000' AS DateTime2), 1)
INSERT [dbo].[LandUse] ([Id], [BuildingRegulationsId], [EndDate], [LandUseStatus], [LandUseType], [RegulationAgency], [StartDate], [ZoneId]) VALUES (2, 5, CAST(N'2018-04-20T09:43:33.2500000' AS DateTime2), N'Active', N'Commercial', N'Agency X', CAST(N'2018-04-20T09:43:33.2500000' AS DateTime2), 6)
INSERT [dbo].[LandUse] ([Id], [BuildingRegulationsId], [EndDate], [LandUseStatus], [LandUseType], [RegulationAgency], [StartDate], [ZoneId]) VALUES (3, 7, CAST(N'2018-04-20T09:43:33.2500000' AS DateTime2), N'Inactive', N'Agricultural', N'Agency Z', CAST(N'2018-04-20T09:43:33.2500000' AS DateTime2), 3)
INSERT [dbo].[LandUse] ([Id], [BuildingRegulationsId], [EndDate], [LandUseStatus], [LandUseType], [RegulationAgency], [StartDate], [ZoneId]) VALUES (4, 2, CAST(N'2018-04-20T09:43:33.2500000' AS DateTime2), N'Inactive', N'Agricultural', N'Agency X', CAST(N'2018-04-20T09:43:33.2500000' AS DateTime2), 1)
INSERT [dbo].[LandUse] ([Id], [BuildingRegulationsId], [EndDate], [LandUseStatus], [LandUseType], [RegulationAgency], [StartDate], [ZoneId]) VALUES (5, 1, CAST(N'2018-04-20T09:43:33.2500000' AS DateTime2), N'Active', N'Commercial', N'Agency y', CAST(N'2018-04-20T09:43:33.2500000' AS DateTime2), 2)
SET IDENTITY_INSERT [dbo].[LandUse] OFF
SET IDENTITY_INSERT [dbo].[MapIndex] ON 

INSERT [dbo].[MapIndex] ([Id], [MapSheetNum], [ParcelId]) VALUES (1, N'7/201', 1)
INSERT [dbo].[MapIndex] ([Id], [MapSheetNum], [ParcelId]) VALUES (2, N'27/120', 2)
INSERT [dbo].[MapIndex] ([Id], [MapSheetNum], [ParcelId]) VALUES (3, N'00/125', 3)
INSERT [dbo].[MapIndex] ([Id], [MapSheetNum], [ParcelId]) VALUES (4, N'1/789', 4)
INSERT [dbo].[MapIndex] ([Id], [MapSheetNum], [ParcelId]) VALUES (5, N'42/7', 5)
INSERT [dbo].[MapIndex] ([Id], [MapSheetNum], [ParcelId]) VALUES (6, N'28/96', 6)
INSERT [dbo].[MapIndex] ([Id], [MapSheetNum], [ParcelId]) VALUES (7, N'06/012', 7)
SET IDENTITY_INSERT [dbo].[MapIndex] OFF
SET IDENTITY_INSERT [dbo].[Mortgage] ON 

INSERT [dbo].[Mortgage] ([Id], [Amount], [BuildingId], [InterestRate], [Lender], [Ranking], [RepaymentTerm]) VALUES (1, 16000000, NULL, 20, N'CfC Life', 2, 24)
INSERT [dbo].[Mortgage] ([Id], [Amount], [BuildingId], [InterestRate], [Lender], [Ranking], [RepaymentTerm]) VALUES (2, 19000000, NULL, 25, N'Commercial Bank of Africa', 2, 20)
INSERT [dbo].[Mortgage] ([Id], [Amount], [BuildingId], [InterestRate], [Lender], [Ranking], [RepaymentTerm]) VALUES (3, 15000000, NULL, 25, N'Family Bank', 2, 20)
INSERT [dbo].[Mortgage] ([Id], [Amount], [BuildingId], [InterestRate], [Lender], [Ranking], [RepaymentTerm]) VALUES (4, 17000000, NULL, 20, N'Good Home Mortgage', 2, 25)
INSERT [dbo].[Mortgage] ([Id], [Amount], [BuildingId], [InterestRate], [Lender], [Ranking], [RepaymentTerm]) VALUES (5, 6000000, NULL, 25, N'National Bank of Kenya', 2, 20)
INSERT [dbo].[Mortgage] ([Id], [Amount], [BuildingId], [InterestRate], [Lender], [Ranking], [RepaymentTerm]) VALUES (6, 26000000, NULL, 25, N'Ndatani Enterprises Co. Limited', 2, 28)
INSERT [dbo].[Mortgage] ([Id], [Amount], [BuildingId], [InterestRate], [Lender], [Ranking], [RepaymentTerm]) VALUES (7, 12000000, NULL, 25, N'CfC Life', 2, 20)
SET IDENTITY_INSERT [dbo].[Mortgage] OFF
SET IDENTITY_INSERT [dbo].[Owner] ON 

INSERT [dbo].[Owner] ([Id], [Name], [OwnerType], [PIN], [PostalAddress], [TelephoneAddress]) VALUES (1, N'Jerosa Sipantoi', N'Individual', N'A051164895K', N'P.O BOX, 987-00106', N'0727-825-567')
INSERT [dbo].[Owner] ([Id], [Name], [OwnerType], [PIN], [PostalAddress], [TelephoneAddress]) VALUES (2, N'Elvis Ayiemba', N'Individual', N'A051116417Z', N'P.O BOX, 0087-30400', N'0724-825-598')
INSERT [dbo].[Owner] ([Id], [Name], [OwnerType], [PIN], [PostalAddress], [TelephoneAddress]) VALUES (3, N'Betsy Mugo', N'Individual', N'A051098084N', N'P.O BOX, 8957-0006', N'0727-755-567')
INSERT [dbo].[Owner] ([Id], [Name], [OwnerType], [PIN], [PostalAddress], [TelephoneAddress]) VALUES (4, N'Janet Muiruri', N'Individual', N'A051166413P', N'P.O BOX, 987-00106', N'0722-824-515')
INSERT [dbo].[Owner] ([Id], [Name], [OwnerType], [PIN], [PostalAddress], [TelephoneAddress]) VALUES (5, N'Zelipa Muchiri', N'Individual', N'A001121237F', N'P.O BOX, 7-00100', N'0727-865-567')
INSERT [dbo].[Owner] ([Id], [Name], [OwnerType], [PIN], [PostalAddress], [TelephoneAddress]) VALUES (6, N'Janet Mbula', N'Individual', N'A051163895K', N'P.O BOX, 87-00206', N'0727-825-567')
INSERT [dbo].[Owner] ([Id], [Name], [OwnerType], [PIN], [PostalAddress], [TelephoneAddress]) VALUES (7, N'Kevin Sewe', N'Individual', N'A051164895K', N'P.O BOX, 97-00206', N'0727-825-567')
INSERT [dbo].[Owner] ([Id], [Name], [OwnerType], [PIN], [PostalAddress], [TelephoneAddress]) VALUES (8, N'Sebastian Omondi', N'Individual', N'A051164856H', N'P.O BOX, 911-00200', N'0727-825-567')
INSERT [dbo].[Owner] ([Id], [Name], [OwnerType], [PIN], [PostalAddress], [TelephoneAddress]) VALUES (9, N'Lillian Waithaka', N'Individual', N'A051164895T', N'P.O BOX, 387-00106', N'0727-825-567')
SET IDENTITY_INSERT [dbo].[Owner] OFF
SET IDENTITY_INSERT [dbo].[OwnershiRights] ON 

INSERT [dbo].[OwnershiRights] ([Id], [RightType]) VALUES (1, N'freehold')
INSERT [dbo].[OwnershiRights] ([Id], [RightType]) VALUES (2, N'Tenure')
SET IDENTITY_INSERT [dbo].[OwnershiRights] OFF
SET IDENTITY_INSERT [dbo].[Parcel] ON 

INSERT [dbo].[Parcel] ([Id], [Administrationid], [Area], [LandUseId], [OwnerId], [OwnershipRights], [ParcelNum], [RegistrationId], [Responsibilities], [Restrictions], [SpatialUnitId], [TenureId], [ValuationId]) VALUES (19, 1, 2, 1, 1, 1, N'001/NR/4547', 2, 1, 1, 1, 1, 1)
INSERT [dbo].[Parcel] ([Id], [Administrationid], [Area], [LandUseId], [OwnerId], [OwnershipRights], [ParcelNum], [RegistrationId], [Responsibilities], [Restrictions], [SpatialUnitId], [TenureId], [ValuationId]) VALUES (20, 2, 4, 2, 2, 2, N'001/CD/6777', 2, 2, 4, 3, 1, 1)
INSERT [dbo].[Parcel] ([Id], [Administrationid], [Area], [LandUseId], [OwnerId], [OwnershipRights], [ParcelNum], [RegistrationId], [Responsibilities], [Restrictions], [SpatialUnitId], [TenureId], [ValuationId]) VALUES (21, 2, 3, 2, 3, 1, N'001/VF/2097', 4, 3, 2, 3, 2, 1)
INSERT [dbo].[Parcel] ([Id], [Administrationid], [Area], [LandUseId], [OwnerId], [OwnershipRights], [ParcelNum], [RegistrationId], [Responsibilities], [Restrictions], [SpatialUnitId], [TenureId], [ValuationId]) VALUES (22, 2, 3, 1, 4, 1, N'001/BT/2066', 3, 1, 3, 4, 2, 1)
INSERT [dbo].[Parcel] ([Id], [Administrationid], [Area], [LandUseId], [OwnerId], [OwnershipRights], [ParcelNum], [RegistrationId], [Responsibilities], [Restrictions], [SpatialUnitId], [TenureId], [ValuationId]) VALUES (23, 3, 5, 2, 5, 2, N'001/BR/3039', 7, 2, 4, 4, 1, 1)
INSERT [dbo].[Parcel] ([Id], [Administrationid], [Area], [LandUseId], [OwnerId], [OwnershipRights], [ParcelNum], [RegistrationId], [Responsibilities], [Restrictions], [SpatialUnitId], [TenureId], [ValuationId]) VALUES (24, 2, 3, 2, 6, 2, N'001/BT/4840', 3, 2, 5, 2, 1, 1)
INSERT [dbo].[Parcel] ([Id], [Administrationid], [Area], [LandUseId], [OwnerId], [OwnershipRights], [ParcelNum], [RegistrationId], [Responsibilities], [Restrictions], [SpatialUnitId], [TenureId], [ValuationId]) VALUES (25, 2, 2, 1, 7, 1, N'001/VF/2329', 6, 1, 6, 3, 2, 1)
INSERT [dbo].[Parcel] ([Id], [Administrationid], [Area], [LandUseId], [OwnerId], [OwnershipRights], [ParcelNum], [RegistrationId], [Responsibilities], [Restrictions], [SpatialUnitId], [TenureId], [ValuationId]) VALUES (26, 3, 3, 3, 1, 1, N'001/NR/2343', 5, 1, 8, 4, 1, 1)
INSERT [dbo].[Parcel] ([Id], [Administrationid], [Area], [LandUseId], [OwnerId], [OwnershipRights], [ParcelNum], [RegistrationId], [Responsibilities], [Restrictions], [SpatialUnitId], [TenureId], [ValuationId]) VALUES (27, 3, 3, 1, 2, 2, N'001/BY/4546', 3, 2, 4, 1, 2, 1)
INSERT [dbo].[Parcel] ([Id], [Administrationid], [Area], [LandUseId], [OwnerId], [OwnershipRights], [ParcelNum], [RegistrationId], [Responsibilities], [Restrictions], [SpatialUnitId], [TenureId], [ValuationId]) VALUES (28, 2, 4, 4, 8, 1, N'001/NR/4567', 8, 3, 1, 2, 1, 1)
INSERT [dbo].[Parcel] ([Id], [Administrationid], [Area], [LandUseId], [OwnerId], [OwnershipRights], [ParcelNum], [RegistrationId], [Responsibilities], [Restrictions], [SpatialUnitId], [TenureId], [ValuationId]) VALUES (29, 3, 1, 1, 9, 1, N'001/KR/7897', 2, 3, 3, 4, 2, 1)
INSERT [dbo].[Parcel] ([Id], [Administrationid], [Area], [LandUseId], [OwnerId], [OwnershipRights], [ParcelNum], [RegistrationId], [Responsibilities], [Restrictions], [SpatialUnitId], [TenureId], [ValuationId]) VALUES (30, 3, 3, 1, 5, 1, N'001/NR/1237', 3, 1, 8, 2, 1, 1)
SET IDENTITY_INSERT [dbo].[Parcel] OFF
SET IDENTITY_INSERT [dbo].[Payments] ON 

INSERT [dbo].[Payments] ([id], [Amount], [ModeOfPayment], [PaymentDate], [rateid], [ReceiptNo]) VALUES (1, 10000.0000, N'MPESA     ', CAST(N'2018-05-01T17:15:08.713' AS DateTime), 1, N'0019MR')
INSERT [dbo].[Payments] ([id], [Amount], [ModeOfPayment], [PaymentDate], [rateid], [ReceiptNo]) VALUES (2, 10000.0000, N'MPESA     ', CAST(N'2018-05-01T17:15:08.713' AS DateTime), 1, N'0020MR')
INSERT [dbo].[Payments] ([id], [Amount], [ModeOfPayment], [PaymentDate], [rateid], [ReceiptNo]) VALUES (3, 10000.0000, N'MPESA     ', CAST(N'2018-05-01T17:15:08.713' AS DateTime), 2, N'0021MR')
INSERT [dbo].[Payments] ([id], [Amount], [ModeOfPayment], [PaymentDate], [rateid], [ReceiptNo]) VALUES (4, 5000.0000, N'MPESA     ', CAST(N'2018-05-01T17:15:08.713' AS DateTime), 3, N'0022MR')
INSERT [dbo].[Payments] ([id], [Amount], [ModeOfPayment], [PaymentDate], [rateid], [ReceiptNo]) VALUES (5, 5000.0000, N'MPESA     ', CAST(N'2018-05-01T17:15:08.713' AS DateTime), 3, N'0023MR')
INSERT [dbo].[Payments] ([id], [Amount], [ModeOfPayment], [PaymentDate], [rateid], [ReceiptNo]) VALUES (6, 5000.0000, N'MPESA     ', CAST(N'2018-05-01T17:15:08.713' AS DateTime), 3, N'0024MR')
INSERT [dbo].[Payments] ([id], [Amount], [ModeOfPayment], [PaymentDate], [rateid], [ReceiptNo]) VALUES (7, 20000.0000, N'MPESA     ', CAST(N'2018-05-01T17:15:08.713' AS DateTime), 4, N'0025MR')
INSERT [dbo].[Payments] ([id], [Amount], [ModeOfPayment], [PaymentDate], [rateid], [ReceiptNo]) VALUES (8, 60000.0000, N'MPESA     ', CAST(N'2018-05-01T17:15:08.713' AS DateTime), 4, N'0026MR')
INSERT [dbo].[Payments] ([id], [Amount], [ModeOfPayment], [PaymentDate], [rateid], [ReceiptNo]) VALUES (9, 20000.0000, N'MPESA     ', CAST(N'2018-05-01T17:15:08.713' AS DateTime), 5, N'0027MR')
INSERT [dbo].[Payments] ([id], [Amount], [ModeOfPayment], [PaymentDate], [rateid], [ReceiptNo]) VALUES (10, 20000.0000, N'MPESA     ', CAST(N'2018-05-01T17:15:08.713' AS DateTime), 6, N'0028MR')
INSERT [dbo].[Payments] ([id], [Amount], [ModeOfPayment], [PaymentDate], [rateid], [ReceiptNo]) VALUES (11, 20000.0000, N'MPESA     ', CAST(N'2018-05-01T17:15:08.713' AS DateTime), 7, N'0029MR')
INSERT [dbo].[Payments] ([id], [Amount], [ModeOfPayment], [PaymentDate], [rateid], [ReceiptNo]) VALUES (12, 20000.0000, N'MPESA     ', CAST(N'2018-05-01T17:15:08.713' AS DateTime), 8, N'0030MR')
INSERT [dbo].[Payments] ([id], [Amount], [ModeOfPayment], [PaymentDate], [rateid], [ReceiptNo]) VALUES (13, 20000.0000, N'MPESA     ', CAST(N'2018-05-01T17:15:08.713' AS DateTime), 8, N'0031MR')
INSERT [dbo].[Payments] ([id], [Amount], [ModeOfPayment], [PaymentDate], [rateid], [ReceiptNo]) VALUES (14, 20000.0000, N'MPESA     ', CAST(N'2018-05-01T17:15:08.713' AS DateTime), 8, N'0032MR')
INSERT [dbo].[Payments] ([id], [Amount], [ModeOfPayment], [PaymentDate], [rateid], [ReceiptNo]) VALUES (15, 20000.0000, N'MPESA     ', CAST(N'2018-05-01T17:15:08.713' AS DateTime), 8, N'0032MR')
SET IDENTITY_INSERT [dbo].[Payments] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([Id], [Email], [Mobile], [OwnerId], [PersonType], [Phone], [PIN]) VALUES (1, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[Person] ([Id], [Email], [Mobile], [OwnerId], [PersonType], [Phone], [PIN]) VALUES (2, NULL, NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[Person] ([Id], [Email], [Mobile], [OwnerId], [PersonType], [Phone], [PIN]) VALUES (3, NULL, NULL, 3, NULL, NULL, NULL)
INSERT [dbo].[Person] ([Id], [Email], [Mobile], [OwnerId], [PersonType], [Phone], [PIN]) VALUES (4, NULL, NULL, 4, NULL, NULL, NULL)
INSERT [dbo].[Person] ([Id], [Email], [Mobile], [OwnerId], [PersonType], [Phone], [PIN]) VALUES (5, NULL, NULL, 5, NULL, NULL, NULL)
INSERT [dbo].[Person] ([Id], [Email], [Mobile], [OwnerId], [PersonType], [Phone], [PIN]) VALUES (6, NULL, NULL, 6, NULL, NULL, NULL)
INSERT [dbo].[Person] ([Id], [Email], [Mobile], [OwnerId], [PersonType], [Phone], [PIN]) VALUES (7, NULL, NULL, 7, NULL, NULL, NULL)
INSERT [dbo].[Person] ([Id], [Email], [Mobile], [OwnerId], [PersonType], [Phone], [PIN]) VALUES (8, NULL, NULL, 8, NULL, NULL, NULL)
INSERT [dbo].[Person] ([Id], [Email], [Mobile], [OwnerId], [PersonType], [Phone], [PIN]) VALUES (9, NULL, NULL, 9, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Person] OFF
INSERT [dbo].[Rates] ([id], [Amount]) VALUES (1, 20000.0000)
INSERT [dbo].[Rates] ([id], [Amount]) VALUES (2, 15000.0000)
INSERT [dbo].[Rates] ([id], [Amount]) VALUES (3, 20000.0000)
INSERT [dbo].[Rates] ([id], [Amount]) VALUES (4, 150000.0000)
INSERT [dbo].[Rates] ([id], [Amount]) VALUES (5, 70000.0000)
INSERT [dbo].[Rates] ([id], [Amount]) VALUES (6, 60000.0000)
INSERT [dbo].[Rates] ([id], [Amount]) VALUES (7, 40000.0000)
INSERT [dbo].[Rates] ([id], [Amount]) VALUES (8, 30000.0000)
SET IDENTITY_INSERT [dbo].[Registration] ON 

INSERT [dbo].[Registration] ([Id], [Jurisdiction], [RegistrationDate], [RegistrationSection], [RegistrationType], [TitleNo]) VALUES (1, N'Nairobi', CAST(N'2018-04-20T09:47:32.8966667' AS DateTime2), N'BuruBuru', N'RLA', N'1/Buruburu')
INSERT [dbo].[Registration] ([Id], [Jurisdiction], [RegistrationDate], [RegistrationSection], [RegistrationType], [TitleNo]) VALUES (2, N'Nairobi', CAST(N'2018-04-20T09:47:32.8966667' AS DateTime2), N'BuruBuru', N'GLA', N'2/Buruburu')
INSERT [dbo].[Registration] ([Id], [Jurisdiction], [RegistrationDate], [RegistrationSection], [RegistrationType], [TitleNo]) VALUES (3, N'Nairobi', CAST(N'2018-04-20T09:47:32.8966667' AS DateTime2), N'BuruBuru', N'LTA', N'3/Buruburu')
INSERT [dbo].[Registration] ([Id], [Jurisdiction], [RegistrationDate], [RegistrationSection], [RegistrationType], [TitleNo]) VALUES (4, N'Nairobi', CAST(N'2018-04-20T09:47:32.8966667' AS DateTime2), N'BuruBuru', N'RLA', N'4/Buruburu')
INSERT [dbo].[Registration] ([Id], [Jurisdiction], [RegistrationDate], [RegistrationSection], [RegistrationType], [TitleNo]) VALUES (5, N'Nairobi', CAST(N'2018-04-20T09:47:32.8966667' AS DateTime2), N'BuruBuru', N'GLA', N'5/Buruburu')
INSERT [dbo].[Registration] ([Id], [Jurisdiction], [RegistrationDate], [RegistrationSection], [RegistrationType], [TitleNo]) VALUES (6, N'Nairobi', CAST(N'2018-04-20T09:47:32.8966667' AS DateTime2), N'BuruBuru', N'RLA', N'6/Buruburu')
INSERT [dbo].[Registration] ([Id], [Jurisdiction], [RegistrationDate], [RegistrationSection], [RegistrationType], [TitleNo]) VALUES (7, N'Nairobi', CAST(N'2018-04-20T09:47:32.8966667' AS DateTime2), N'BuruBuru', N'RLA', N'7/Buruburu')
INSERT [dbo].[Registration] ([Id], [Jurisdiction], [RegistrationDate], [RegistrationSection], [RegistrationType], [TitleNo]) VALUES (8, N'Nairobi', CAST(N'2018-04-20T09:47:32.8966667' AS DateTime2), N'BuruBuru', N'RLA', N'8/Buruburu')
SET IDENTITY_INSERT [dbo].[Registration] OFF
SET IDENTITY_INSERT [dbo].[Reserve] ON 

INSERT [dbo].[Reserve] ([Id], [ComplianceStatus], [EnforcingAuthority], [ReserveType]) VALUES (1, N'Active', N'KWS', N'National Park')
INSERT [dbo].[Reserve] ([Id], [ComplianceStatus], [EnforcingAuthority], [ReserveType]) VALUES (2, N'Active', N'KWS', N'Conservancy')
INSERT [dbo].[Reserve] ([Id], [ComplianceStatus], [EnforcingAuthority], [ReserveType]) VALUES (3, N'Active', N'KWS', N'Game Reserve')
INSERT [dbo].[Reserve] ([Id], [ComplianceStatus], [EnforcingAuthority], [ReserveType]) VALUES (4, N'Active', N'KWS', N'National Park')
INSERT [dbo].[Reserve] ([Id], [ComplianceStatus], [EnforcingAuthority], [ReserveType]) VALUES (5, N'Active', N'KWS', N'Conservancy')
INSERT [dbo].[Reserve] ([Id], [ComplianceStatus], [EnforcingAuthority], [ReserveType]) VALUES (6, N'Active', N'KWS', N'National Park')
INSERT [dbo].[Reserve] ([Id], [ComplianceStatus], [EnforcingAuthority], [ReserveType]) VALUES (7, N'Active', N'KWS', N'Game Reserve')
INSERT [dbo].[Reserve] ([Id], [ComplianceStatus], [EnforcingAuthority], [ReserveType]) VALUES (8, N'Active', N'KWS', N'Game Reserve')
INSERT [dbo].[Reserve] ([Id], [ComplianceStatus], [EnforcingAuthority], [ReserveType]) VALUES (9, N'Active', N'KWS', N'National Park')
SET IDENTITY_INSERT [dbo].[Reserve] OFF
SET IDENTITY_INSERT [dbo].[Responsibility] ON 

INSERT [dbo].[Responsibility] ([Id], [PerformanceRequirement], [ResponsibilityType]) VALUES (1, N'Always plant trees', NULL)
INSERT [dbo].[Responsibility] ([Id], [PerformanceRequirement], [ResponsibilityType]) VALUES (2, N'Get it fenced', NULL)
INSERT [dbo].[Responsibility] ([Id], [PerformanceRequirement], [ResponsibilityType]) VALUES (3, N'Always plant trees', NULL)
INSERT [dbo].[Responsibility] ([Id], [PerformanceRequirement], [ResponsibilityType]) VALUES (4, N'dig a waterhole', NULL)
INSERT [dbo].[Responsibility] ([Id], [PerformanceRequirement], [ResponsibilityType]) VALUES (5, N'protect wildlife', NULL)
INSERT [dbo].[Responsibility] ([Id], [PerformanceRequirement], [ResponsibilityType]) VALUES (6, N'Get it fenced', NULL)
SET IDENTITY_INSERT [dbo].[Responsibility] OFF
SET IDENTITY_INSERT [dbo].[Restriction] ON 

INSERT [dbo].[Restriction] ([Id], [chrageId], [landUseId], [morgageid], [ReserveID], [RestrictionType], [Statutoryid]) VALUES (1, 1, 1, 1, 1, N'Planning', 1)
INSERT [dbo].[Restriction] ([Id], [chrageId], [landUseId], [morgageid], [ReserveID], [RestrictionType], [Statutoryid]) VALUES (2, 2, 2, 2, 2, N'Group', 2)
INSERT [dbo].[Restriction] ([Id], [chrageId], [landUseId], [morgageid], [ReserveID], [RestrictionType], [Statutoryid]) VALUES (3, 3, 3, 3, 3, N'Natural', 3)
INSERT [dbo].[Restriction] ([Id], [chrageId], [landUseId], [morgageid], [ReserveID], [RestrictionType], [Statutoryid]) VALUES (4, 4, 3, 4, 4, N'Individual', 3)
INSERT [dbo].[Restriction] ([Id], [chrageId], [landUseId], [morgageid], [ReserveID], [RestrictionType], [Statutoryid]) VALUES (5, 5, 4, 5, 5, N'Planning', 3)
INSERT [dbo].[Restriction] ([Id], [chrageId], [landUseId], [morgageid], [ReserveID], [RestrictionType], [Statutoryid]) VALUES (6, 5, 4, 5, 5, N'Group', 3)
INSERT [dbo].[Restriction] ([Id], [chrageId], [landUseId], [morgageid], [ReserveID], [RestrictionType], [Statutoryid]) VALUES (7, 5, 5, 6, 5, N'Natural', 4)
INSERT [dbo].[Restriction] ([Id], [chrageId], [landUseId], [morgageid], [ReserveID], [RestrictionType], [Statutoryid]) VALUES (8, 5, 5, 6, 5, N'Individual', 4)
SET IDENTITY_INSERT [dbo].[Restriction] OFF
SET IDENTITY_INSERT [dbo].[SpatialUnit] ON 

INSERT [dbo].[SpatialUnit] ([Id], [Area], [BoundaryId], [Label], [Layer], [Length], [MapIndexId], [PreliminaryUnitId], [ReferencePoint], [SpatialUnitSetId], [SpatialUnitType], [SurveyClassId], [Volume]) VALUES (1, 0.017519, 1, N'Parcel-954', N'Parcels', 0.001554814, 2, 1, NULL, 1, N'Type1', 5, 0)
INSERT [dbo].[SpatialUnit] ([Id], [Area], [BoundaryId], [Label], [Layer], [Length], [MapIndexId], [PreliminaryUnitId], [ReferencePoint], [SpatialUnitSetId], [SpatialUnitType], [SurveyClassId], [Volume]) VALUES (2, 0.0164991, 2, N'Parcel-953', N'Parcels', 0.0015814, 3, 2, NULL, 2, N'Type2', 3, 0)
INSERT [dbo].[SpatialUnit] ([Id], [Area], [BoundaryId], [Label], [Layer], [Length], [MapIndexId], [PreliminaryUnitId], [ReferencePoint], [SpatialUnitSetId], [SpatialUnitType], [SurveyClassId], [Volume]) VALUES (3, 0.07519, 3, N'Parcel-952', N'Parcels', 0.054814, 4, 3, NULL, 3, N'Type3', 4, 0)
INSERT [dbo].[SpatialUnit] ([Id], [Area], [BoundaryId], [Label], [Layer], [Length], [MapIndexId], [PreliminaryUnitId], [ReferencePoint], [SpatialUnitSetId], [SpatialUnitType], [SurveyClassId], [Volume]) VALUES (4, 0.01519, 4, N'Parcel-951', N'Parcels', 0.021554814, 5, 4, NULL, 4, N'Type1', 2, 0)
INSERT [dbo].[SpatialUnit] ([Id], [Area], [BoundaryId], [Label], [Layer], [Length], [MapIndexId], [PreliminaryUnitId], [ReferencePoint], [SpatialUnitSetId], [SpatialUnitType], [SurveyClassId], [Volume]) VALUES (5, 0.026519, 5, N'Parcel-950', N'Parcels', 0.001954814, 6, 5, NULL, 5, N'Type3', 1, 0)
SET IDENTITY_INSERT [dbo].[SpatialUnit] OFF
SET IDENTITY_INSERT [dbo].[SpatialUnitSet] ON 

INSERT [dbo].[SpatialUnitSet] ([Id], [Label]) VALUES (1, N'Parcel/954')
INSERT [dbo].[SpatialUnitSet] ([Id], [Label]) VALUES (2, N'Parcel/953')
INSERT [dbo].[SpatialUnitSet] ([Id], [Label]) VALUES (3, N'Parcel/952')
INSERT [dbo].[SpatialUnitSet] ([Id], [Label]) VALUES (4, N'Parcel/951')
INSERT [dbo].[SpatialUnitSet] ([Id], [Label]) VALUES (5, N'Parcel/950')
INSERT [dbo].[SpatialUnitSet] ([Id], [Label]) VALUES (6, N'Parcel/949')
INSERT [dbo].[SpatialUnitSet] ([Id], [Label]) VALUES (7, N'Parcel/966')
INSERT [dbo].[SpatialUnitSet] ([Id], [Label]) VALUES (8, N'Parcel/967')
INSERT [dbo].[SpatialUnitSet] ([Id], [Label]) VALUES (9, N'Parcel/968')
SET IDENTITY_INSERT [dbo].[SpatialUnitSet] OFF
INSERT [dbo].[SpatialUnitSetRegistration] ([RegistrationId], [SpatialUnitSetId]) VALUES (1, 1)
INSERT [dbo].[SpatialUnitSetRegistration] ([RegistrationId], [SpatialUnitSetId]) VALUES (2, 2)
INSERT [dbo].[SpatialUnitSetRegistration] ([RegistrationId], [SpatialUnitSetId]) VALUES (8, 3)
INSERT [dbo].[SpatialUnitSetRegistration] ([RegistrationId], [SpatialUnitSetId]) VALUES (3, 4)
INSERT [dbo].[SpatialUnitSetRegistration] ([RegistrationId], [SpatialUnitSetId]) VALUES (4, 5)
INSERT [dbo].[SpatialUnitSetRegistration] ([RegistrationId], [SpatialUnitSetId]) VALUES (5, 6)
INSERT [dbo].[SpatialUnitSetRegistration] ([RegistrationId], [SpatialUnitSetId]) VALUES (6, 7)
INSERT [dbo].[SpatialUnitSetRegistration] ([RegistrationId], [SpatialUnitSetId]) VALUES (7, 8)
SET IDENTITY_INSERT [dbo].[StaturtoryRestriction] ON 

INSERT [dbo].[StaturtoryRestriction] ([Id], [NatureOfRestriction], [RestrictingAuthority]) VALUES (1, N'Planning: Frontage=10m, PCR=200%, GCR=80%', N'County Government Nairobi')
INSERT [dbo].[StaturtoryRestriction] ([Id], [NatureOfRestriction], [RestrictingAuthority]) VALUES (2, N'Group', N'County Government Nairobi')
INSERT [dbo].[StaturtoryRestriction] ([Id], [NatureOfRestriction], [RestrictingAuthority]) VALUES (3, N'Natural', N'County Government Nairobi')
INSERT [dbo].[StaturtoryRestriction] ([Id], [NatureOfRestriction], [RestrictingAuthority]) VALUES (4, N'Simple individual', N'County Government Nairobi')
SET IDENTITY_INSERT [dbo].[StaturtoryRestriction] OFF
SET IDENTITY_INSERT [dbo].[Survey] ON 

INSERT [dbo].[Survey] ([Id], [CompsNo], [DateOfEntry], [ParcelId], [PDPRefNo], [PlansNo], [SurveyorsName], [TypeOfSurvey]) VALUES (1, N'SOK/2017/123', CAST(N'2018-04-20T09:44:10.8366667' AS DateTime2), 1, 12, N'23/17', N'Johson Kaikai', N'Mutation')
INSERT [dbo].[Survey] ([Id], [CompsNo], [DateOfEntry], [ParcelId], [PDPRefNo], [PlansNo], [SurveyorsName], [TypeOfSurvey]) VALUES (2, N'SOK/2017/50', CAST(N'2018-04-20T09:44:10.8366667' AS DateTime2), 2, 20, N'23/16', N'Heather Helmi', N'Amulgamation')
INSERT [dbo].[Survey] ([Id], [CompsNo], [DateOfEntry], [ParcelId], [PDPRefNo], [PlansNo], [SurveyorsName], [TypeOfSurvey]) VALUES (3, N'SOK/2016/10', CAST(N'2018-04-20T09:44:10.8366667' AS DateTime2), 3, 40, N'00/16', N'Alison Karai', N'Amulgamation')
INSERT [dbo].[Survey] ([Id], [CompsNo], [DateOfEntry], [ParcelId], [PDPRefNo], [PlansNo], [SurveyorsName], [TypeOfSurvey]) VALUES (4, N'SOK/2016/30', CAST(N'2018-04-20T09:44:10.8366667' AS DateTime2), 4, 80, N'23/00', N'Oajia AtKilson', N'Mutation')
INSERT [dbo].[Survey] ([Id], [CompsNo], [DateOfEntry], [ParcelId], [PDPRefNo], [PlansNo], [SurveyorsName], [TypeOfSurvey]) VALUES (5, N'SOK/2016/43', CAST(N'2018-04-20T09:44:10.8366667' AS DateTime2), 5, 4, N'233/4', N'Mcdonald Yusup', N'Mutation')
SET IDENTITY_INSERT [dbo].[Survey] OFF
SET IDENTITY_INSERT [dbo].[Tenure] ON 

INSERT [dbo].[Tenure] ([Id], [TenureType]) VALUES (1, N'freehold')
INSERT [dbo].[Tenure] ([Id], [TenureType]) VALUES (2, N'Leasehold')
SET IDENTITY_INSERT [dbo].[Tenure] OFF
SET IDENTITY_INSERT [dbo].[Valution] ON 

INSERT [dbo].[Valution] ([Id], [Remarks], [SerialNo], [ValuationBookNo], [ValuationDate], [Value], [Valuer]) VALUES (1, N'Good price', N'2/234', N'3', CAST(N'2018-04-20T09:47:06.0000000' AS DateTime2), 1400, N'NLC')
INSERT [dbo].[Valution] ([Id], [Remarks], [SerialNo], [ValuationBookNo], [ValuationDate], [Value], [Valuer]) VALUES (2, N'Under review', N'2/235', N'2', CAST(N'2018-04-20T09:47:06.0000000' AS DateTime2), 1400, N'NLC')
INSERT [dbo].[Valution] ([Id], [Remarks], [SerialNo], [ValuationBookNo], [ValuationDate], [Value], [Valuer]) VALUES (3, N'Good price', N'2/234', N'3', CAST(N'2018-04-20T09:47:06.0000000' AS DateTime2), 1400, N'NLC')
INSERT [dbo].[Valution] ([Id], [Remarks], [SerialNo], [ValuationBookNo], [ValuationDate], [Value], [Valuer]) VALUES (4, N'Under review', N'2/234', N'4', CAST(N'2018-04-20T09:47:06.0000000' AS DateTime2), 1400, N'NLC')
INSERT [dbo].[Valution] ([Id], [Remarks], [SerialNo], [ValuationBookNo], [ValuationDate], [Value], [Valuer]) VALUES (5, N'Good price', N'2/234', N'5', CAST(N'2018-04-20T09:47:06.0000000' AS DateTime2), 1400, N'NLC')
INSERT [dbo].[Valution] ([Id], [Remarks], [SerialNo], [ValuationBookNo], [ValuationDate], [Value], [Valuer]) VALUES (6, N'Under review', N'2/234', N'6', CAST(N'2018-04-20T09:47:06.0000000' AS DateTime2), 1400, N'NLC')
INSERT [dbo].[Valution] ([Id], [Remarks], [SerialNo], [ValuationBookNo], [ValuationDate], [Value], [Valuer]) VALUES (7, N'Good price', N'2/234', N'5', CAST(N'2018-04-20T09:47:06.0000000' AS DateTime2), 1400, N'NLC')
SET IDENTITY_INSERT [dbo].[Valution] OFF
SET IDENTITY_INSERT [dbo].[Zone] ON 

INSERT [dbo].[Zone] ([Id], [RegulationId], [ZoneType]) VALUES (1, 1, N'Commercial')
INSERT [dbo].[Zone] ([Id], [RegulationId], [ZoneType]) VALUES (2, 3, N'Educational')
INSERT [dbo].[Zone] ([Id], [RegulationId], [ZoneType]) VALUES (3, 2, N'Agricultural')
INSERT [dbo].[Zone] ([Id], [RegulationId], [ZoneType]) VALUES (4, 5, N'Industrial')
INSERT [dbo].[Zone] ([Id], [RegulationId], [ZoneType]) VALUES (5, 6, N'Public')
INSERT [dbo].[Zone] ([Id], [RegulationId], [ZoneType]) VALUES (6, 4, N'Recreational')
INSERT [dbo].[Zone] ([Id], [RegulationId], [ZoneType]) VALUES (7, 7, N'Residential')
SET IDENTITY_INSERT [dbo].[Zone] OFF
/****** Object:  Index [IX_BoundaryBeacon_BeaconId]    Script Date: 5/2/2018 9:46:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_BoundaryBeacon_BeaconId] ON [dbo].[BoundaryBeacon]
(
	[BeaconId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Building_ApartmentId]    Script Date: 5/2/2018 9:46:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_Building_ApartmentId] ON [dbo].[Building]
(
	[ApartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Building_SpatialUnitId]    Script Date: 5/2/2018 9:46:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_Building_SpatialUnitId] ON [dbo].[Building]
(
	[SpatialUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Freehold_TenureId]    Script Date: 5/2/2018 9:46:11 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Freehold_TenureId] ON [dbo].[Freehold]
(
	[TenureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroupGroupLeadership_GroupLeadershipId]    Script Date: 5/2/2018 9:46:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_GroupGroupLeadership_GroupLeadershipId] ON [dbo].[GroupGroupLeadership]
(
	[GroupLeadershipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroupGroupMembership_GroupId]    Script Date: 5/2/2018 9:46:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_GroupGroupMembership_GroupId] ON [dbo].[GroupGroupMembership]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroupLeadershipPerson_PersonId]    Script Date: 5/2/2018 9:46:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_GroupLeadershipPerson_PersonId] ON [dbo].[GroupLeadershipPerson]
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroupOW_OwnerId]    Script Date: 5/2/2018 9:46:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_GroupOW_OwnerId] ON [dbo].[GroupOW]
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_InstitutionInstitutionLeadership_InstitutionId]    Script Date: 5/2/2018 9:46:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_InstitutionInstitutionLeadership_InstitutionId] ON [dbo].[InstitutionInstitutionLeadership]
(
	[InstitutionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_InstitutionLeadershipPerson_PersonId]    Script Date: 5/2/2018 9:46:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_InstitutionLeadershipPerson_PersonId] ON [dbo].[InstitutionLeadershipPerson]
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LandUse_BuildingRegulationsId]    Script Date: 5/2/2018 9:46:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_LandUse_BuildingRegulationsId] ON [dbo].[LandUse]
(
	[BuildingRegulationsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LandUse_ZoneId]    Script Date: 5/2/2018 9:46:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_LandUse_ZoneId] ON [dbo].[LandUse]
(
	[ZoneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Leasehold_TenureId]    Script Date: 5/2/2018 9:46:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_Leasehold_TenureId] ON [dbo].[Leasehold]
(
	[TenureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Operation_Parcelid]    Script Date: 5/2/2018 9:46:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_Operation_Parcelid] ON [dbo].[Operation]
(
	[Parcelid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Parcel_Administrationid]    Script Date: 5/2/2018 9:46:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_Parcel_Administrationid] ON [dbo].[Parcel]
(
	[Administrationid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Parcel_LandUseId]    Script Date: 5/2/2018 9:46:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_Parcel_LandUseId] ON [dbo].[Parcel]
(
	[LandUseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Parcel_OwnerId]    Script Date: 5/2/2018 9:46:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_Parcel_OwnerId] ON [dbo].[Parcel]
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Parcel_OwnershipRights]    Script Date: 5/2/2018 9:46:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_Parcel_OwnershipRights] ON [dbo].[Parcel]
(
	[OwnershipRights] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Parcel_RegistrationId]    Script Date: 5/2/2018 9:46:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_Parcel_RegistrationId] ON [dbo].[Parcel]
(
	[RegistrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Parcel_Responsibilities]    Script Date: 5/2/2018 9:46:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_Parcel_Responsibilities] ON [dbo].[Parcel]
(
	[Responsibilities] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Parcel_Restrictions]    Script Date: 5/2/2018 9:46:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_Parcel_Restrictions] ON [dbo].[Parcel]
(
	[Restrictions] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Parcel_SpatialUnitId]    Script Date: 5/2/2018 9:46:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_Parcel_SpatialUnitId] ON [dbo].[Parcel]
(
	[SpatialUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Parcel_TenureId]    Script Date: 5/2/2018 9:46:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_Parcel_TenureId] ON [dbo].[Parcel]
(
	[TenureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Parcel_ValuationId]    Script Date: 5/2/2018 9:46:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_Parcel_ValuationId] ON [dbo].[Parcel]
(
	[ValuationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Payments_rateid]    Script Date: 5/2/2018 9:46:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_Payments_rateid] ON [dbo].[Payments]
(
	[rateid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Person_OwnerId]    Script Date: 5/2/2018 9:46:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_Person_OwnerId] ON [dbo].[Person]
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersonGroupMembership_PersonId]    Script Date: 5/2/2018 9:46:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_PersonGroupMembership_PersonId] ON [dbo].[PersonGroupMembership]
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Restriction_chrageId]    Script Date: 5/2/2018 9:46:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_Restriction_chrageId] ON [dbo].[Restriction]
(
	[chrageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Restriction_morgageid]    Script Date: 5/2/2018 9:46:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_Restriction_morgageid] ON [dbo].[Restriction]
(
	[morgageid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Restriction_ReserveID]    Script Date: 5/2/2018 9:46:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_Restriction_ReserveID] ON [dbo].[Restriction]
(
	[ReserveID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Restriction_Statutoryid]    Script Date: 5/2/2018 9:46:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_Restriction_Statutoryid] ON [dbo].[Restriction]
(
	[Statutoryid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Service_OPid]    Script Date: 5/2/2018 9:46:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_Service_OPid] ON [dbo].[Service]
(
	[OPid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SpatialUnit_BoundaryId]    Script Date: 5/2/2018 9:46:12 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_SpatialUnit_BoundaryId] ON [dbo].[SpatialUnit]
(
	[BoundaryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SpatialUnit_MapIndexId]    Script Date: 5/2/2018 9:46:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_SpatialUnit_MapIndexId] ON [dbo].[SpatialUnit]
(
	[MapIndexId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SpatialUnit_SpatialUnitSetId]    Script Date: 5/2/2018 9:46:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_SpatialUnit_SpatialUnitSetId] ON [dbo].[SpatialUnit]
(
	[SpatialUnitSetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SpatialUnit_SurveyClassId]    Script Date: 5/2/2018 9:46:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_SpatialUnit_SurveyClassId] ON [dbo].[SpatialUnit]
(
	[SurveyClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SpatialUnitSetRegistration_SpatialUnitSetId]    Script Date: 5/2/2018 9:46:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_SpatialUnitSetRegistration_SpatialUnitSetId] ON [dbo].[SpatialUnitSetRegistration]
(
	[SpatialUnitSetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Beacon] ADD  DEFAULT (getdate()) FOR [DateSet]
GO
ALTER TABLE [dbo].[GroupLeadership] ADD  DEFAULT (getdate()) FOR [LeadershipSince]
GO
ALTER TABLE [dbo].[GroupLeadership] ADD  DEFAULT (getdate()) FOR [LeadershipUntil]
GO
ALTER TABLE [dbo].[GroupMembership] ADD  DEFAULT (getdate()) FOR [MembershipSince]
GO
ALTER TABLE [dbo].[GroupMembership] ADD  DEFAULT (getdate()) FOR [MembershipUntil]
GO
ALTER TABLE [dbo].[InsitutionLeadership] ADD  DEFAULT (getdate()) FOR [MemberSince]
GO
ALTER TABLE [dbo].[InsitutionLeadership] ADD  DEFAULT (getdate()) FOR [MemberUntil]
GO
ALTER TABLE [dbo].[LandUse] ADD  DEFAULT (getdate()) FOR [EndDate]
GO
ALTER TABLE [dbo].[LandUse] ADD  DEFAULT (getdate()) FOR [StartDate]
GO
ALTER TABLE [dbo].[Leasehold] ADD  DEFAULT (getdate()) FOR [LeasePeriod]
GO
ALTER TABLE [dbo].[Payments] ADD  DEFAULT (getdate()) FOR [PaymentDate]
GO
ALTER TABLE [dbo].[Registration] ADD  DEFAULT (getdate()) FOR [RegistrationDate]
GO
ALTER TABLE [dbo].[Survey] ADD  DEFAULT (getdate()) FOR [DateOfEntry]
GO
ALTER TABLE [dbo].[Valution] ADD  DEFAULT (getdate()) FOR [ValuationDate]
GO
ALTER TABLE [dbo].[BoundaryBeacon]  WITH CHECK ADD  CONSTRAINT [FK_BoundaryBeacon_Beacon_BeaconId] FOREIGN KEY([BeaconId])
REFERENCES [dbo].[Beacon] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BoundaryBeacon] CHECK CONSTRAINT [FK_BoundaryBeacon_Beacon_BeaconId]
GO
ALTER TABLE [dbo].[BoundaryBeacon]  WITH CHECK ADD  CONSTRAINT [FK_BoundaryBeacon_Boundary_BoundaryId] FOREIGN KEY([BoundaryId])
REFERENCES [dbo].[Boundary] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BoundaryBeacon] CHECK CONSTRAINT [FK_BoundaryBeacon_Boundary_BoundaryId]
GO
ALTER TABLE [dbo].[Building]  WITH CHECK ADD  CONSTRAINT [FK_Building_Apartment_ApartmentId] FOREIGN KEY([ApartmentId])
REFERENCES [dbo].[Apartment] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Building] CHECK CONSTRAINT [FK_Building_Apartment_ApartmentId]
GO
ALTER TABLE [dbo].[Building]  WITH CHECK ADD  CONSTRAINT [FK_Building_SpatialUnit_SpatialUnitId] FOREIGN KEY([SpatialUnitId])
REFERENCES [dbo].[SpatialUnit] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Building] CHECK CONSTRAINT [FK_Building_SpatialUnit_SpatialUnitId]
GO
ALTER TABLE [dbo].[Freehold]  WITH CHECK ADD  CONSTRAINT [FK_Freehold_Tenure_TenureId] FOREIGN KEY([TenureId])
REFERENCES [dbo].[Tenure] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Freehold] CHECK CONSTRAINT [FK_Freehold_Tenure_TenureId]
GO
ALTER TABLE [dbo].[GroupGroupLeadership]  WITH CHECK ADD  CONSTRAINT [FK_GroupGroupLeadership_GroupLeadership_GroupLeadershipId] FOREIGN KEY([GroupLeadershipId])
REFERENCES [dbo].[GroupLeadership] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GroupGroupLeadership] CHECK CONSTRAINT [FK_GroupGroupLeadership_GroupLeadership_GroupLeadershipId]
GO
ALTER TABLE [dbo].[GroupGroupMembership]  WITH CHECK ADD  CONSTRAINT [FK_GroupGroupMembership_GroupMembership_GroupMembershipId] FOREIGN KEY([GroupMembershipId])
REFERENCES [dbo].[GroupMembership] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GroupGroupMembership] CHECK CONSTRAINT [FK_GroupGroupMembership_GroupMembership_GroupMembershipId]
GO
ALTER TABLE [dbo].[GroupLeadershipPerson]  WITH CHECK ADD  CONSTRAINT [FK_GroupLeadershipPerson_GroupLeadership_GroupLeadershipId] FOREIGN KEY([GroupLeadershipId])
REFERENCES [dbo].[GroupLeadership] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GroupLeadershipPerson] CHECK CONSTRAINT [FK_GroupLeadershipPerson_GroupLeadership_GroupLeadershipId]
GO
ALTER TABLE [dbo].[GroupLeadershipPerson]  WITH CHECK ADD  CONSTRAINT [FK_GroupLeadershipPerson_Person_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GroupLeadershipPerson] CHECK CONSTRAINT [FK_GroupLeadershipPerson_Person_PersonId]
GO
ALTER TABLE [dbo].[GroupOW]  WITH CHECK ADD  CONSTRAINT [FK_GroupOW_Owner_OwnerId] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Owner] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GroupOW] CHECK CONSTRAINT [FK_GroupOW_Owner_OwnerId]
GO
ALTER TABLE [dbo].[InstitutionInstitutionLeadership]  WITH CHECK ADD  CONSTRAINT [FK_InstitutionInstitutionLeadership_InsitutionLeadership_InstitutionLeadershipId] FOREIGN KEY([InstitutionLeadershipId])
REFERENCES [dbo].[InsitutionLeadership] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InstitutionInstitutionLeadership] CHECK CONSTRAINT [FK_InstitutionInstitutionLeadership_InsitutionLeadership_InstitutionLeadershipId]
GO
ALTER TABLE [dbo].[InstitutionInstitutionLeadership]  WITH CHECK ADD  CONSTRAINT [FK_InstitutionInstitutionLeadership_Institution_InstitutionId] FOREIGN KEY([InstitutionId])
REFERENCES [dbo].[Institution] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InstitutionInstitutionLeadership] CHECK CONSTRAINT [FK_InstitutionInstitutionLeadership_Institution_InstitutionId]
GO
ALTER TABLE [dbo].[InstitutionLeadershipPerson]  WITH CHECK ADD  CONSTRAINT [FK_InstitutionLeadershipPerson_InsitutionLeadership_InstitutionLeadershipId] FOREIGN KEY([InstitutionLeadershipId])
REFERENCES [dbo].[InsitutionLeadership] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InstitutionLeadershipPerson] CHECK CONSTRAINT [FK_InstitutionLeadershipPerson_InsitutionLeadership_InstitutionLeadershipId]
GO
ALTER TABLE [dbo].[InstitutionLeadershipPerson]  WITH CHECK ADD  CONSTRAINT [FK_InstitutionLeadershipPerson_Person_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InstitutionLeadershipPerson] CHECK CONSTRAINT [FK_InstitutionLeadershipPerson_Person_PersonId]
GO
ALTER TABLE [dbo].[LandUse]  WITH CHECK ADD  CONSTRAINT [FK_LandUse_BuildingRegulations_BuildingRegulationsId] FOREIGN KEY([BuildingRegulationsId])
REFERENCES [dbo].[BuildingRegulations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LandUse] CHECK CONSTRAINT [FK_LandUse_BuildingRegulations_BuildingRegulationsId]
GO
ALTER TABLE [dbo].[LandUse]  WITH CHECK ADD  CONSTRAINT [FK_LandUse_Zone_ZoneId] FOREIGN KEY([ZoneId])
REFERENCES [dbo].[Zone] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LandUse] CHECK CONSTRAINT [FK_LandUse_Zone_ZoneId]
GO
ALTER TABLE [dbo].[Leasehold]  WITH CHECK ADD  CONSTRAINT [FK_Leasehold_Tenure_TenureId] FOREIGN KEY([TenureId])
REFERENCES [dbo].[Tenure] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Leasehold] CHECK CONSTRAINT [FK_Leasehold_Tenure_TenureId]
GO
ALTER TABLE [dbo].[Operation]  WITH CHECK ADD  CONSTRAINT [FK_Operation_Parcel] FOREIGN KEY([Parcelid])
REFERENCES [dbo].[Parcel] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Operation] CHECK CONSTRAINT [FK_Operation_Parcel]
GO
ALTER TABLE [dbo].[Parcel]  WITH CHECK ADD  CONSTRAINT [FK_Parcel_Administration] FOREIGN KEY([Administrationid])
REFERENCES [dbo].[Administration] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parcel] CHECK CONSTRAINT [FK_Parcel_Administration]
GO
ALTER TABLE [dbo].[Parcel]  WITH CHECK ADD  CONSTRAINT [FK_Parcel_LandUse_LandUseId] FOREIGN KEY([LandUseId])
REFERENCES [dbo].[LandUse] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parcel] CHECK CONSTRAINT [FK_Parcel_LandUse_LandUseId]
GO
ALTER TABLE [dbo].[Parcel]  WITH CHECK ADD  CONSTRAINT [FK_Parcel_Owners] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Owner] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parcel] CHECK CONSTRAINT [FK_Parcel_Owners]
GO
ALTER TABLE [dbo].[Parcel]  WITH CHECK ADD  CONSTRAINT [FK_Parcel_OwnershiRights] FOREIGN KEY([OwnershipRights])
REFERENCES [dbo].[OwnershiRights] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parcel] CHECK CONSTRAINT [FK_Parcel_OwnershiRights]
GO
ALTER TABLE [dbo].[Parcel]  WITH CHECK ADD  CONSTRAINT [FK_Parcel_Registration_RegistrationId] FOREIGN KEY([RegistrationId])
REFERENCES [dbo].[Registration] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parcel] CHECK CONSTRAINT [FK_Parcel_Registration_RegistrationId]
GO
ALTER TABLE [dbo].[Parcel]  WITH CHECK ADD  CONSTRAINT [FK_Parcel_Responsibility] FOREIGN KEY([Responsibilities])
REFERENCES [dbo].[Responsibility] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parcel] CHECK CONSTRAINT [FK_Parcel_Responsibility]
GO
ALTER TABLE [dbo].[Parcel]  WITH CHECK ADD  CONSTRAINT [FK_Parcel_Restriction] FOREIGN KEY([Restrictions])
REFERENCES [dbo].[Restriction] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parcel] CHECK CONSTRAINT [FK_Parcel_Restriction]
GO
ALTER TABLE [dbo].[Parcel]  WITH CHECK ADD  CONSTRAINT [FK_Parcel_SpatialUnit_SpatialUnitId] FOREIGN KEY([SpatialUnitId])
REFERENCES [dbo].[SpatialUnit] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parcel] CHECK CONSTRAINT [FK_Parcel_SpatialUnit_SpatialUnitId]
GO
ALTER TABLE [dbo].[Parcel]  WITH CHECK ADD  CONSTRAINT [FK_Parcel_Tenure_TenureId] FOREIGN KEY([TenureId])
REFERENCES [dbo].[Tenure] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parcel] CHECK CONSTRAINT [FK_Parcel_Tenure_TenureId]
GO
ALTER TABLE [dbo].[Parcel]  WITH CHECK ADD  CONSTRAINT [FK_Parcel_Valution_ValuationId] FOREIGN KEY([ValuationId])
REFERENCES [dbo].[Valution] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parcel] CHECK CONSTRAINT [FK_Parcel_Valution_ValuationId]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_To_Rates] FOREIGN KEY([rateid])
REFERENCES [dbo].[Rates] ([id])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_To_Rates]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Owner_OwnerId] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Owner] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Owner_OwnerId]
GO
ALTER TABLE [dbo].[PersonGroupMembership]  WITH CHECK ADD  CONSTRAINT [FK_PersonGroupMembership_GroupMembership_GroupMembershipId] FOREIGN KEY([GroupMembershipId])
REFERENCES [dbo].[GroupMembership] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PersonGroupMembership] CHECK CONSTRAINT [FK_PersonGroupMembership_GroupMembership_GroupMembershipId]
GO
ALTER TABLE [dbo].[PersonGroupMembership]  WITH CHECK ADD  CONSTRAINT [FK_PersonGroupMembership_Person_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PersonGroupMembership] CHECK CONSTRAINT [FK_PersonGroupMembership_Person_PersonId]
GO
ALTER TABLE [dbo].[Restriction]  WITH CHECK ADD  CONSTRAINT [FK_Restriction_Charge] FOREIGN KEY([chrageId])
REFERENCES [dbo].[Charge] ([Id])
GO
ALTER TABLE [dbo].[Restriction] CHECK CONSTRAINT [FK_Restriction_Charge]
GO
ALTER TABLE [dbo].[Restriction]  WITH CHECK ADD  CONSTRAINT [FK_Restriction_Mortgage] FOREIGN KEY([morgageid])
REFERENCES [dbo].[Mortgage] ([Id])
GO
ALTER TABLE [dbo].[Restriction] CHECK CONSTRAINT [FK_Restriction_Mortgage]
GO
ALTER TABLE [dbo].[Restriction]  WITH CHECK ADD  CONSTRAINT [FK_Restriction_Reserve] FOREIGN KEY([ReserveID])
REFERENCES [dbo].[Reserve] ([Id])
GO
ALTER TABLE [dbo].[Restriction] CHECK CONSTRAINT [FK_Restriction_Reserve]
GO
ALTER TABLE [dbo].[Restriction]  WITH CHECK ADD  CONSTRAINT [FK_Restriction_StaturtoryRestriction] FOREIGN KEY([Statutoryid])
REFERENCES [dbo].[StaturtoryRestriction] ([Id])
GO
ALTER TABLE [dbo].[Restriction] CHECK CONSTRAINT [FK_Restriction_StaturtoryRestriction]
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FK_Service_Operation] FOREIGN KEY([OPid])
REFERENCES [dbo].[Operation] ([Id])
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FK_Service_Operation]
GO
ALTER TABLE [dbo].[SpatialUnit]  WITH CHECK ADD  CONSTRAINT [FK_SpatialUnit_Boundary_BoundaryId] FOREIGN KEY([BoundaryId])
REFERENCES [dbo].[Boundary] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SpatialUnit] CHECK CONSTRAINT [FK_SpatialUnit_Boundary_BoundaryId]
GO
ALTER TABLE [dbo].[SpatialUnit]  WITH CHECK ADD  CONSTRAINT [FK_SpatialUnit_MapIndex_MapIndexId] FOREIGN KEY([MapIndexId])
REFERENCES [dbo].[MapIndex] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SpatialUnit] CHECK CONSTRAINT [FK_SpatialUnit_MapIndex_MapIndexId]
GO
ALTER TABLE [dbo].[SpatialUnit]  WITH CHECK ADD  CONSTRAINT [FK_SpatialUnit_SpatialUnitSet_SpatialUnitSetId] FOREIGN KEY([SpatialUnitSetId])
REFERENCES [dbo].[SpatialUnitSet] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SpatialUnit] CHECK CONSTRAINT [FK_SpatialUnit_SpatialUnitSet_SpatialUnitSetId]
GO
ALTER TABLE [dbo].[SpatialUnit]  WITH CHECK ADD  CONSTRAINT [FK_SpatialUnit_Survey_SurveyClassId] FOREIGN KEY([SurveyClassId])
REFERENCES [dbo].[Survey] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SpatialUnit] CHECK CONSTRAINT [FK_SpatialUnit_Survey_SurveyClassId]
GO
ALTER TABLE [dbo].[SpatialUnitSetRegistration]  WITH CHECK ADD  CONSTRAINT [FK_SpatialUnitSetRegistration_Registration_RegistrationId] FOREIGN KEY([RegistrationId])
REFERENCES [dbo].[Registration] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SpatialUnitSetRegistration] CHECK CONSTRAINT [FK_SpatialUnitSetRegistration_Registration_RegistrationId]
GO
ALTER TABLE [dbo].[SpatialUnitSetRegistration]  WITH CHECK ADD  CONSTRAINT [FK_SpatialUnitSetRegistration_SpatialUnitSet_SpatialUnitSetId] FOREIGN KEY([SpatialUnitSetId])
REFERENCES [dbo].[SpatialUnitSet] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SpatialUnitSetRegistration] CHECK CONSTRAINT [FK_SpatialUnitSetRegistration_SpatialUnitSet_SpatialUnitSetId]
GO
USE [master]
GO
ALTER DATABASE [LIMSCoreDb] SET  READ_WRITE 
GO
