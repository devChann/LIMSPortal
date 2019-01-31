USE [master]
GO
/****** Object:  Database [LIMSCoreDb]    Script Date: 1/30/2019 5:29:00 PM ******/
CREATE DATABASE [LIMSCoreDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LIMSCoreDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\LIMSCoreDb.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LIMSCoreDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\LIMSCoreDb_log.ldf' , SIZE = 1600KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [LIMSCoreDb] SET COMPATIBILITY_LEVEL = 110
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
ALTER DATABASE [LIMSCoreDb] SET  ENABLE_BROKER 
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
ALTER DATABASE [LIMSCoreDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [LIMSCoreDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LIMSCoreDb] SET RECOVERY FULL 
GO
ALTER DATABASE [LIMSCoreDb] SET  MULTI_USER 
GO
ALTER DATABASE [LIMSCoreDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LIMSCoreDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LIMSCoreDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LIMSCoreDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [LIMSCoreDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/30/2019 5:29:01 PM ******/
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
/****** Object:  Table [dbo].[Administration]    Script Date: 1/30/2019 5:29:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administration](
	[AdministrationId] [int] IDENTITY(1,1) NOT NULL,
	[BlockName] [nvarchar](max) NULL,
	[DistrictName] [nvarchar](max) NULL,
	[LocationName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Administration] PRIMARY KEY CLUSTERED 
(
	[AdministrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Apartment]    Script Date: 1/30/2019 5:29:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apartment](
	[ApartmentId] [int] IDENTITY(1,1) NOT NULL,
	[ApartmentName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Apartment] PRIMARY KEY CLUSTERED 
(
	[ApartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 1/30/2019 5:29:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 1/30/2019 5:29:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[IPAddress] [nvarchar](max) NULL,
	[Users] [int] NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 1/30/2019 5:29:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 1/30/2019 5:29:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 1/30/2019 5:29:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 1/30/2019 5:29:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[Photo] [varbinary](max) NULL,
	[KRAPIN] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[MiddleName] [nvarchar](max) NULL,
	[IDNumber] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 1/30/2019 5:29:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Beacon]    Script Date: 1/30/2019 5:29:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beacon](
	[BeaconId] [int] IDENTITY(1,1) NOT NULL,
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
	[BeaconId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Boundary]    Script Date: 1/30/2019 5:29:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Boundary](
	[BoundaryId] [int] IDENTITY(1,1) NOT NULL,
	[BoundaryType] [nvarchar](max) NULL,
 CONSTRAINT [PK_Boundary] PRIMARY KEY CLUSTERED 
(
	[BoundaryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BoundaryBeacon]    Script Date: 1/30/2019 5:29:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoundaryBeacon](
	[BeaconId] [int] NOT NULL,
	[BoundaryId] [int] NOT NULL,
 CONSTRAINT [PK_BoundaryBeacon] PRIMARY KEY CLUSTERED 
(
	[BoundaryId] ASC,
	[BeaconId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Building]    Script Date: 1/30/2019 5:29:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Building](
	[BuildingId] [int] IDENTITY(1,1) NOT NULL,
	[StreetAddress] [nvarchar](max) NULL,
	[ApartmentId] [int] NOT NULL,
	[SpatialUnitId] [int] NOT NULL,
 CONSTRAINT [PK_Building] PRIMARY KEY CLUSTERED 
(
	[BuildingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BuildingRegulation]    Script Date: 1/30/2019 5:29:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuildingRegulation](
	[BuildingRegulationId] [int] IDENTITY(1,1) NOT NULL,
	[GCR] [float] NOT NULL,
	[PCR] [float] NOT NULL,
	[PlotFrontage] [float] NOT NULL,
 CONSTRAINT [PK_BuildingRegulation] PRIMARY KEY CLUSTERED 
(
	[BuildingRegulationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Charge]    Script Date: 1/30/2019 5:29:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Charge](
	[ChargeId] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [float] NOT NULL,
	[InterestRate] [float] NOT NULL,
	[lender] [nvarchar](max) NULL,
	[Ranking] [int] NOT NULL,
	[RepaymentTerm] [int] NOT NULL,
 CONSTRAINT [PK_Charge] PRIMARY KEY CLUSTERED 
(
	[ChargeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Checkout]    Script Date: 1/30/2019 5:29:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Checkout](
	[CheckoutId] [uniqueidentifier] NOT NULL,
	[CheckoutDate] [datetime2](7) NOT NULL,
	[CheckoutRequest] [nvarchar](max) NULL,
	[InvoiceId] [uniqueidentifier] NOT NULL,
	[AmountPaid] [float] NOT NULL,
 CONSTRAINT [PK_Checkout] PRIMARY KEY CLUSTERED 
(
	[CheckoutId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Freehold]    Script Date: 1/30/2019 5:29:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Freehold](
	[FreeholdId] [int] IDENTITY(1,1) NOT NULL,
	[TenureId] [int] NOT NULL,
 CONSTRAINT [PK_Freehold] PRIMARY KEY CLUSTERED 
(
	[FreeholdId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 1/30/2019 5:29:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[GroupId] [int] IDENTITY(1,1) NOT NULL,
	[County] [nvarchar](max) NULL,
	[GroupType] [nvarchar](max) NULL,
	[OwnerId] [int] NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupGroupLeadership]    Script Date: 1/30/2019 5:29:04 PM ******/
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
/****** Object:  Table [dbo].[GroupGroupMembership]    Script Date: 1/30/2019 5:29:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupGroupMembership](
	[GroupId] [int] NOT NULL,
	[GroupMembershipId] [int] NOT NULL,
 CONSTRAINT [PK_GroupGroupMembership] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC,
	[GroupMembershipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupLeadership]    Script Date: 1/30/2019 5:29:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupLeadership](
	[GroupLeadershipId] [int] IDENTITY(1,1) NOT NULL,
	[LeadershipRole] [nvarchar](max) NULL,
	[LeadershipSince] [datetime2](7) NOT NULL,
	[LeadershipStatus] [nvarchar](max) NULL,
	[LeadershipUntil] [datetime2](7) NOT NULL,
	[PersonId] [int] NOT NULL,
 CONSTRAINT [PK_GroupLeadership] PRIMARY KEY CLUSTERED 
(
	[GroupLeadershipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupMembership]    Script Date: 1/30/2019 5:29:04 PM ******/
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
/****** Object:  Table [dbo].[InsitutionLeadership]    Script Date: 1/30/2019 5:29:04 PM ******/
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
/****** Object:  Table [dbo].[Institution]    Script Date: 1/30/2019 5:29:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Institution](
	[InstitutionId] [int] IDENTITY(1,1) NOT NULL,
	[InstitutionType] [nvarchar](max) NULL,
 CONSTRAINT [PK_Institution] PRIMARY KEY CLUSTERED 
(
	[InstitutionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InstitutionInstitutionLeadership]    Script Date: 1/30/2019 5:29:04 PM ******/
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
/****** Object:  Table [dbo].[Invoice]    Script Date: 1/30/2019 5:29:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[InvoiceId] [uniqueidentifier] NOT NULL,
	[InvoiceNumber] [nvarchar](max) NULL,
	[InvoiceAmount] [float] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateDue] [datetime2](7) NOT NULL,
	[ParcelId] [int] NOT NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LandUse]    Script Date: 1/30/2019 5:29:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LandUse](
	[LandUseId] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [datetime2](7) NULL,
	[EndDate] [datetime2](7) NULL,
	[LandUseStatus] [nvarchar](max) NULL,
	[LandUseType] [nvarchar](max) NULL,
	[RegulationAgency] [nvarchar](max) NULL,
	[BuildingRegulationId] [int] NOT NULL,
	[ZoneId] [int] NOT NULL,
 CONSTRAINT [PK_LandUse] PRIMARY KEY CLUSTERED 
(
	[LandUseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leasehold]    Script Date: 1/30/2019 5:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leasehold](
	[LeaseholdId] [int] IDENTITY(1,1) NOT NULL,
	[LeasePeriod] [datetime2](7) NOT NULL,
	[Lessor] [nvarchar](max) NULL,
	[TenureId] [int] NOT NULL,
 CONSTRAINT [PK_Leasehold] PRIMARY KEY CLUSTERED 
(
	[LeaseholdId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MapIndex]    Script Date: 1/30/2019 5:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MapIndex](
	[MapIndexId] [int] IDENTITY(1,1) NOT NULL,
	[MapSheetNum] [nvarchar](max) NULL,
 CONSTRAINT [PK_MapIndex] PRIMARY KEY CLUSTERED 
(
	[MapIndexId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mortgage]    Script Date: 1/30/2019 5:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mortgage](
	[MortgageId] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [float] NOT NULL,
	[InterestRate] [float] NOT NULL,
	[Lender] [nvarchar](max) NULL,
	[Ranking] [int] NOT NULL,
	[RepaymentTerm] [int] NOT NULL,
 CONSTRAINT [PK_Mortgage] PRIMARY KEY CLUSTERED 
(
	[MortgageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MpesaTransaction]    Script Date: 1/30/2019 5:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MpesaTransaction](
	[Id] [uniqueidentifier] NOT NULL,
	[Amount] [nvarchar](max) NULL,
	[TransactionDate] [datetime2](7) NOT NULL,
	[CheckoutRequestID] [nvarchar](max) NULL,
	[MerchantRequestId] [nvarchar](max) NULL,
	[ReceiptNumber] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
 CONSTRAINT [PK_MpesaTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operation]    Script Date: 1/30/2019 5:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operation](
	[OperationId] [int] NOT NULL,
	[OperationName] [nvarchar](max) NULL,
	[ParcelId] [int] NULL,
 CONSTRAINT [PK_Operation] PRIMARY KEY CLUSTERED 
(
	[OperationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Owner]    Script Date: 1/30/2019 5:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Owner](
	[OwnerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[OwnerType] [nvarchar](max) NULL,
	[PIN] [nvarchar](max) NULL,
	[PostalAddress] [nvarchar](max) NULL,
	[TelephoneAddress] [nvarchar](max) NULL,
 CONSTRAINT [PK_Owner] PRIMARY KEY CLUSTERED 
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OwnershipRight]    Script Date: 1/30/2019 5:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OwnershipRight](
	[OwnershipRightId] [int] IDENTITY(1,1) NOT NULL,
	[RightType] [nvarchar](max) NULL,
 CONSTRAINT [PK_OwnershipRight] PRIMARY KEY CLUSTERED 
(
	[OwnershipRightId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parcel]    Script Date: 1/30/2019 5:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parcel](
	[ParcelId] [int] IDENTITY(1,1) NOT NULL,
	[Area] [float] NULL,
	[ParcelNum] [nvarchar](max) NOT NULL,
	[AdministrationId] [int] NOT NULL,
	[LandUseId] [int] NOT NULL,
	[OwnerId] [int] NOT NULL,
	[OwnershipRightId] [int] NOT NULL,
	[RateId] [int] NULL,
	[RegistrationId] [int] NOT NULL,
	[ResponsibilityId] [int] NOT NULL,
	[RestrictionId] [int] NOT NULL,
	[SpatialUnitId] [int] NOT NULL,
	[TenureId] [int] NOT NULL,
	[ValuationId] [int] NOT NULL,
 CONSTRAINT [PK_Parcel] PRIMARY KEY CLUSTERED 
(
	[ParcelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 1/30/2019 5:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [decimal](9, 2) NULL,
	[ModeOfPayment] [nvarchar](max) NULL,
	[PaymentDate] [datetime2](7) NULL,
	[ReceiptNo] [nvarchar](max) NULL,
	[InvoiceId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 1/30/2019 5:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Mobile] [nvarchar](max) NULL,
	[PersonType] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[PIN] [nvarchar](max) NULL,
	[OwnerId] [int] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonGroupLeadership]    Script Date: 1/30/2019 5:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonGroupLeadership](
	[GroupLeadershipId] [int] NOT NULL,
	[PersonId] [int] NOT NULL,
 CONSTRAINT [PK_PersonGroupLeadership] PRIMARY KEY CLUSTERED 
(
	[GroupLeadershipId] ASC,
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonGroupMembership]    Script Date: 1/30/2019 5:29:05 PM ******/
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
/****** Object:  Table [dbo].[PersonInstitutionLeadership]    Script Date: 1/30/2019 5:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonInstitutionLeadership](
	[InstitutionLeadershipId] [int] NOT NULL,
	[PersonId] [int] NOT NULL,
 CONSTRAINT [PK_PersonInstitutionLeadership] PRIMARY KEY CLUSTERED 
(
	[InstitutionLeadershipId] ASC,
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rate]    Script Date: 1/30/2019 5:29:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rate](
	[RateId] [int] NOT NULL,
	[Amount] [money] NULL,
 CONSTRAINT [PK_Rate] PRIMARY KEY CLUSTERED 
(
	[RateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 1/30/2019 5:29:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[RegistrationId] [int] IDENTITY(1,1) NOT NULL,
	[Jurisdiction] [nvarchar](max) NULL,
	[RegistrationDate] [datetime2](7) NOT NULL,
	[RegistrationSection] [nvarchar](max) NULL,
	[RegistrationType] [nvarchar](max) NULL,
	[TitleNo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[RegistrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserve]    Script Date: 1/30/2019 5:29:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserve](
	[ReserveId] [int] IDENTITY(1,1) NOT NULL,
	[ComplianceStatus] [nvarchar](max) NULL,
	[EnforcingAuthority] [nvarchar](max) NULL,
	[ReserveType] [nvarchar](max) NULL,
 CONSTRAINT [PK_Reserve] PRIMARY KEY CLUSTERED 
(
	[ReserveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Responsibility]    Script Date: 1/30/2019 5:29:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Responsibility](
	[ResponsibilityId] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceRequirement] [nvarchar](max) NULL,
	[ResponsibilityType] [nvarchar](max) NULL,
 CONSTRAINT [PK_Responsibility] PRIMARY KEY CLUSTERED 
(
	[ResponsibilityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Restriction]    Script Date: 1/30/2019 5:29:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restriction](
	[RestrictionId] [int] IDENTITY(1,1) NOT NULL,
	[RestrictionType] [nvarchar](max) NULL,
	[ChargeId] [int] NULL,
	[MortgageId] [int] NULL,
	[ReserveId] [int] NULL,
	[StatutoryRestrictionId] [int] NULL,
 CONSTRAINT [PK_Restriction] PRIMARY KEY CLUSTERED 
(
	[RestrictionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 1/30/2019 5:29:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[ServiceId] [int] NOT NULL,
	[DateCreated] [datetime] NULL,
	[IsComplete] [bit] NOT NULL,
	[Progress] [int] NULL,
	[OperationId] [int] NOT NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpatialUnit]    Script Date: 1/30/2019 5:29:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpatialUnit](
	[SpatialUnitId] [int] IDENTITY(1,1) NOT NULL,
	[Area] [float] NULL,
	[Label] [nvarchar](max) NULL,
	[Layer] [nvarchar](max) NULL,
	[Length] [float] NULL,
	[PreliminaryUnitId] [int] NOT NULL,
	[ReferencePoint] [nvarchar](max) NULL,
	[SpatialUnitType] [nvarchar](max) NULL,
	[Volume] [float] NULL,
	[BoundaryId] [int] NOT NULL,
	[MapIndexId] [int] NOT NULL,
	[SpatialUnitSetId] [int] NOT NULL,
	[SurveyId] [int] NOT NULL,
 CONSTRAINT [PK_SpatialUnit] PRIMARY KEY CLUSTERED 
(
	[SpatialUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpatialUnitSet]    Script Date: 1/30/2019 5:29:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpatialUnitSet](
	[SpatialUnitSetId] [int] IDENTITY(1,1) NOT NULL,
	[Label] [nvarchar](max) NULL,
 CONSTRAINT [PK_SpatialUnitSet] PRIMARY KEY CLUSTERED 
(
	[SpatialUnitSetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpatialUnitSetRegistration]    Script Date: 1/30/2019 5:29:06 PM ******/
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
/****** Object:  Table [dbo].[StatutoryRestriction]    Script Date: 1/30/2019 5:29:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatutoryRestriction](
	[StatutoryRestrictionId] [int] IDENTITY(1,1) NOT NULL,
	[NatureOfRestriction] [nvarchar](max) NULL,
	[RestrictingAuthority] [nvarchar](max) NULL,
 CONSTRAINT [PK_StatutoryRestriction] PRIMARY KEY CLUSTERED 
(
	[StatutoryRestrictionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Survey]    Script Date: 1/30/2019 5:29:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Survey](
	[SurveyId] [int] IDENTITY(1,1) NOT NULL,
	[CompsNo] [nvarchar](max) NULL,
	[DateOfEntry] [datetime2](7) NULL,
	[ParcelId] [int] NOT NULL,
	[PDPRefNo] [int] NOT NULL,
	[PlansNo] [nvarchar](max) NULL,
	[SurveyorsName] [nvarchar](max) NULL,
	[TypeOfSurvey] [nvarchar](max) NULL,
 CONSTRAINT [PK_Survey] PRIMARY KEY CLUSTERED 
(
	[SurveyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tenure]    Script Date: 1/30/2019 5:29:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tenure](
	[TenureId] [int] IDENTITY(1,1) NOT NULL,
	[TenureType] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tenure] PRIMARY KEY CLUSTERED 
(
	[TenureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Valuation]    Script Date: 1/30/2019 5:29:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Valuation](
	[ValuationId] [int] IDENTITY(1,1) NOT NULL,
	[Remarks] [nvarchar](max) NULL,
	[SerialNo] [nvarchar](max) NULL,
	[ValuationBookNo] [nvarchar](max) NULL,
	[ValuationDate] [datetime2](7) NULL,
	[Value] [float] NULL,
	[Valuer] [nvarchar](max) NULL,
 CONSTRAINT [PK_Valuation] PRIMARY KEY CLUSTERED 
(
	[ValuationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zone]    Script Date: 1/30/2019 5:29:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zone](
	[ZoneId] [int] IDENTITY(1,1) NOT NULL,
	[ZoneType] [nvarchar](max) NULL,
 CONSTRAINT [PK_Zone] PRIMARY KEY CLUSTERED 
(
	[ZoneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BoundaryBeacon_BeaconId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_BoundaryBeacon_BeaconId] ON [dbo].[BoundaryBeacon]
(
	[BeaconId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Building_ApartmentId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Building_ApartmentId] ON [dbo].[Building]
(
	[ApartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Building_SpatialUnitId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Building_SpatialUnitId] ON [dbo].[Building]
(
	[SpatialUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Checkout_InvoiceId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Checkout_InvoiceId] ON [dbo].[Checkout]
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Freehold_TenureId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Freehold_TenureId] ON [dbo].[Freehold]
(
	[TenureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Group_OwnerId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Group_OwnerId] ON [dbo].[Group]
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroupGroupLeadership_GroupLeadershipId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_GroupGroupLeadership_GroupLeadershipId] ON [dbo].[GroupGroupLeadership]
(
	[GroupLeadershipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroupGroupMembership_GroupMembershipId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_GroupGroupMembership_GroupMembershipId] ON [dbo].[GroupGroupMembership]
(
	[GroupMembershipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_InstitutionInstitutionLeadership_InstitutionId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_InstitutionInstitutionLeadership_InstitutionId] ON [dbo].[InstitutionInstitutionLeadership]
(
	[InstitutionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Invoice_ParcelId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Invoice_ParcelId] ON [dbo].[Invoice]
(
	[ParcelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LandUse_BuildingRegulationId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_LandUse_BuildingRegulationId] ON [dbo].[LandUse]
(
	[BuildingRegulationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LandUse_ZoneId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_LandUse_ZoneId] ON [dbo].[LandUse]
(
	[ZoneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Leasehold_TenureId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Leasehold_TenureId] ON [dbo].[Leasehold]
(
	[TenureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Operation_ParcelId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Operation_ParcelId] ON [dbo].[Operation]
(
	[ParcelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Parcel_AdministrationId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Parcel_AdministrationId] ON [dbo].[Parcel]
(
	[AdministrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Parcel_LandUseId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Parcel_LandUseId] ON [dbo].[Parcel]
(
	[LandUseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Parcel_OwnerId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Parcel_OwnerId] ON [dbo].[Parcel]
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Parcel_OwnershipRightId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Parcel_OwnershipRightId] ON [dbo].[Parcel]
(
	[OwnershipRightId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Parcel_RateId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Parcel_RateId] ON [dbo].[Parcel]
(
	[RateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Parcel_RegistrationId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Parcel_RegistrationId] ON [dbo].[Parcel]
(
	[RegistrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Parcel_ResponsibilityId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Parcel_ResponsibilityId] ON [dbo].[Parcel]
(
	[ResponsibilityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Parcel_RestrictionId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Parcel_RestrictionId] ON [dbo].[Parcel]
(
	[RestrictionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Parcel_SpatialUnitId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Parcel_SpatialUnitId] ON [dbo].[Parcel]
(
	[SpatialUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Parcel_TenureId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Parcel_TenureId] ON [dbo].[Parcel]
(
	[TenureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Parcel_ValuationId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Parcel_ValuationId] ON [dbo].[Parcel]
(
	[ValuationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Payment_InvoiceId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Payment_InvoiceId] ON [dbo].[Payment]
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Person_OwnerId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Person_OwnerId] ON [dbo].[Person]
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersonGroupLeadership_PersonId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_PersonGroupLeadership_PersonId] ON [dbo].[PersonGroupLeadership]
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersonGroupMembership_PersonId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_PersonGroupMembership_PersonId] ON [dbo].[PersonGroupMembership]
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersonInstitutionLeadership_PersonId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_PersonInstitutionLeadership_PersonId] ON [dbo].[PersonInstitutionLeadership]
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Restriction_ChargeId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Restriction_ChargeId] ON [dbo].[Restriction]
(
	[ChargeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Restriction_MortgageId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Restriction_MortgageId] ON [dbo].[Restriction]
(
	[MortgageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Restriction_ReserveId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Restriction_ReserveId] ON [dbo].[Restriction]
(
	[ReserveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Restriction_StatutoryRestrictionId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Restriction_StatutoryRestrictionId] ON [dbo].[Restriction]
(
	[StatutoryRestrictionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Service_OperationId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Service_OperationId] ON [dbo].[Service]
(
	[OperationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SpatialUnit_BoundaryId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_SpatialUnit_BoundaryId] ON [dbo].[SpatialUnit]
(
	[BoundaryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SpatialUnit_MapIndexId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_SpatialUnit_MapIndexId] ON [dbo].[SpatialUnit]
(
	[MapIndexId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SpatialUnit_SpatialUnitSetId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_SpatialUnit_SpatialUnitSetId] ON [dbo].[SpatialUnit]
(
	[SpatialUnitSetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SpatialUnit_SurveyId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_SpatialUnit_SurveyId] ON [dbo].[SpatialUnit]
(
	[SurveyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SpatialUnitSetRegistration_SpatialUnitSetId]    Script Date: 1/30/2019 5:29:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_SpatialUnitSetRegistration_SpatialUnitSetId] ON [dbo].[SpatialUnitSetRegistration]
(
	[SpatialUnitSetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Beacon] ADD  DEFAULT (getdate()) FOR [DateSet]
GO
ALTER TABLE [dbo].[Checkout] ADD  DEFAULT ((0.000000000000000e+000)) FOR [AmountPaid]
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
ALTER TABLE [dbo].[LandUse] ADD  DEFAULT (getdate()) FOR [StartDate]
GO
ALTER TABLE [dbo].[LandUse] ADD  DEFAULT (getdate()) FOR [EndDate]
GO
ALTER TABLE [dbo].[Leasehold] ADD  DEFAULT (getdate()) FOR [LeasePeriod]
GO
ALTER TABLE [dbo].[Registration] ADD  DEFAULT (getdate()) FOR [RegistrationDate]
GO
ALTER TABLE [dbo].[Survey] ADD  DEFAULT (getdate()) FOR [DateOfEntry]
GO
ALTER TABLE [dbo].[Valuation] ADD  DEFAULT (getdate()) FOR [ValuationDate]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[BoundaryBeacon]  WITH CHECK ADD  CONSTRAINT [FK_BoundaryBeacon_Beacon_BeaconId] FOREIGN KEY([BeaconId])
REFERENCES [dbo].[Beacon] ([BeaconId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BoundaryBeacon] CHECK CONSTRAINT [FK_BoundaryBeacon_Beacon_BeaconId]
GO
ALTER TABLE [dbo].[BoundaryBeacon]  WITH CHECK ADD  CONSTRAINT [FK_BoundaryBeacon_Boundary_BoundaryId] FOREIGN KEY([BoundaryId])
REFERENCES [dbo].[Boundary] ([BoundaryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BoundaryBeacon] CHECK CONSTRAINT [FK_BoundaryBeacon_Boundary_BoundaryId]
GO
ALTER TABLE [dbo].[Building]  WITH CHECK ADD  CONSTRAINT [FK_Building_Apartment_ApartmentId] FOREIGN KEY([ApartmentId])
REFERENCES [dbo].[Apartment] ([ApartmentId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Building] CHECK CONSTRAINT [FK_Building_Apartment_ApartmentId]
GO
ALTER TABLE [dbo].[Building]  WITH CHECK ADD  CONSTRAINT [FK_Building_SpatialUnit_SpatialUnitId] FOREIGN KEY([SpatialUnitId])
REFERENCES [dbo].[SpatialUnit] ([SpatialUnitId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Building] CHECK CONSTRAINT [FK_Building_SpatialUnit_SpatialUnitId]
GO
ALTER TABLE [dbo].[Checkout]  WITH CHECK ADD  CONSTRAINT [FK_Checkout_Invoice_InvoiceId] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoice] ([InvoiceId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Checkout] CHECK CONSTRAINT [FK_Checkout_Invoice_InvoiceId]
GO
ALTER TABLE [dbo].[Freehold]  WITH CHECK ADD  CONSTRAINT [FK_Freehold_Tenure_TenureId] FOREIGN KEY([TenureId])
REFERENCES [dbo].[Tenure] ([TenureId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Freehold] CHECK CONSTRAINT [FK_Freehold_Tenure_TenureId]
GO
ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Group_Owner_OwnerId] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Owner] ([OwnerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Group_Owner_OwnerId]
GO
ALTER TABLE [dbo].[GroupGroupLeadership]  WITH CHECK ADD  CONSTRAINT [FK_GroupGroupLeadership_Group_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([GroupId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GroupGroupLeadership] CHECK CONSTRAINT [FK_GroupGroupLeadership_Group_GroupId]
GO
ALTER TABLE [dbo].[GroupGroupLeadership]  WITH CHECK ADD  CONSTRAINT [FK_GroupGroupLeadership_GroupLeadership_GroupLeadershipId] FOREIGN KEY([GroupLeadershipId])
REFERENCES [dbo].[GroupLeadership] ([GroupLeadershipId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GroupGroupLeadership] CHECK CONSTRAINT [FK_GroupGroupLeadership_GroupLeadership_GroupLeadershipId]
GO
ALTER TABLE [dbo].[GroupGroupMembership]  WITH CHECK ADD  CONSTRAINT [FK_GroupGroupMembership_Group_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([GroupId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GroupGroupMembership] CHECK CONSTRAINT [FK_GroupGroupMembership_Group_GroupId]
GO
ALTER TABLE [dbo].[GroupGroupMembership]  WITH CHECK ADD  CONSTRAINT [FK_GroupGroupMembership_GroupMembership_GroupMembershipId] FOREIGN KEY([GroupMembershipId])
REFERENCES [dbo].[GroupMembership] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GroupGroupMembership] CHECK CONSTRAINT [FK_GroupGroupMembership_GroupMembership_GroupMembershipId]
GO
ALTER TABLE [dbo].[InstitutionInstitutionLeadership]  WITH CHECK ADD  CONSTRAINT [FK_InstitutionInstitutionLeadership_InsitutionLeadership_InstitutionLeadershipId] FOREIGN KEY([InstitutionLeadershipId])
REFERENCES [dbo].[InsitutionLeadership] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InstitutionInstitutionLeadership] CHECK CONSTRAINT [FK_InstitutionInstitutionLeadership_InsitutionLeadership_InstitutionLeadershipId]
GO
ALTER TABLE [dbo].[InstitutionInstitutionLeadership]  WITH CHECK ADD  CONSTRAINT [FK_InstitutionInstitutionLeadership_Institution_InstitutionId] FOREIGN KEY([InstitutionId])
REFERENCES [dbo].[Institution] ([InstitutionId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InstitutionInstitutionLeadership] CHECK CONSTRAINT [FK_InstitutionInstitutionLeadership_Institution_InstitutionId]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Parcel_ParcelId] FOREIGN KEY([ParcelId])
REFERENCES [dbo].[Parcel] ([ParcelId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Parcel_ParcelId]
GO
ALTER TABLE [dbo].[LandUse]  WITH CHECK ADD  CONSTRAINT [FK_LandUse_BuildingRegulation_BuildingRegulationId] FOREIGN KEY([BuildingRegulationId])
REFERENCES [dbo].[BuildingRegulation] ([BuildingRegulationId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LandUse] CHECK CONSTRAINT [FK_LandUse_BuildingRegulation_BuildingRegulationId]
GO
ALTER TABLE [dbo].[LandUse]  WITH CHECK ADD  CONSTRAINT [FK_LandUse_Zone_ZoneId] FOREIGN KEY([ZoneId])
REFERENCES [dbo].[Zone] ([ZoneId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LandUse] CHECK CONSTRAINT [FK_LandUse_Zone_ZoneId]
GO
ALTER TABLE [dbo].[Leasehold]  WITH CHECK ADD  CONSTRAINT [FK_Leasehold_Tenure_TenureId] FOREIGN KEY([TenureId])
REFERENCES [dbo].[Tenure] ([TenureId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Leasehold] CHECK CONSTRAINT [FK_Leasehold_Tenure_TenureId]
GO
ALTER TABLE [dbo].[Operation]  WITH CHECK ADD  CONSTRAINT [FK_Operation_Parcel] FOREIGN KEY([ParcelId])
REFERENCES [dbo].[Parcel] ([ParcelId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Operation] CHECK CONSTRAINT [FK_Operation_Parcel]
GO
ALTER TABLE [dbo].[Parcel]  WITH CHECK ADD  CONSTRAINT [FK_Parcel_Administration_AdministrationId] FOREIGN KEY([AdministrationId])
REFERENCES [dbo].[Administration] ([AdministrationId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parcel] CHECK CONSTRAINT [FK_Parcel_Administration_AdministrationId]
GO
ALTER TABLE [dbo].[Parcel]  WITH CHECK ADD  CONSTRAINT [FK_Parcel_LandUse_LandUseId] FOREIGN KEY([LandUseId])
REFERENCES [dbo].[LandUse] ([LandUseId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parcel] CHECK CONSTRAINT [FK_Parcel_LandUse_LandUseId]
GO
ALTER TABLE [dbo].[Parcel]  WITH CHECK ADD  CONSTRAINT [FK_Parcel_Owner_OwnerId] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Owner] ([OwnerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parcel] CHECK CONSTRAINT [FK_Parcel_Owner_OwnerId]
GO
ALTER TABLE [dbo].[Parcel]  WITH CHECK ADD  CONSTRAINT [FK_Parcel_OwnershipRight_OwnershipRightId] FOREIGN KEY([OwnershipRightId])
REFERENCES [dbo].[OwnershipRight] ([OwnershipRightId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parcel] CHECK CONSTRAINT [FK_Parcel_OwnershipRight_OwnershipRightId]
GO
ALTER TABLE [dbo].[Parcel]  WITH CHECK ADD  CONSTRAINT [FK_Parcel_Rate_RateId] FOREIGN KEY([RateId])
REFERENCES [dbo].[Rate] ([RateId])
GO
ALTER TABLE [dbo].[Parcel] CHECK CONSTRAINT [FK_Parcel_Rate_RateId]
GO
ALTER TABLE [dbo].[Parcel]  WITH CHECK ADD  CONSTRAINT [FK_Parcel_Registration_RegistrationId] FOREIGN KEY([RegistrationId])
REFERENCES [dbo].[Registration] ([RegistrationId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parcel] CHECK CONSTRAINT [FK_Parcel_Registration_RegistrationId]
GO
ALTER TABLE [dbo].[Parcel]  WITH CHECK ADD  CONSTRAINT [FK_Parcel_Responsibility_ResponsibilityId] FOREIGN KEY([ResponsibilityId])
REFERENCES [dbo].[Responsibility] ([ResponsibilityId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parcel] CHECK CONSTRAINT [FK_Parcel_Responsibility_ResponsibilityId]
GO
ALTER TABLE [dbo].[Parcel]  WITH CHECK ADD  CONSTRAINT [FK_Parcel_Restriction_RestrictionId] FOREIGN KEY([RestrictionId])
REFERENCES [dbo].[Restriction] ([RestrictionId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parcel] CHECK CONSTRAINT [FK_Parcel_Restriction_RestrictionId]
GO
ALTER TABLE [dbo].[Parcel]  WITH CHECK ADD  CONSTRAINT [FK_Parcel_SpatialUnit_SpatialUnitId] FOREIGN KEY([SpatialUnitId])
REFERENCES [dbo].[SpatialUnit] ([SpatialUnitId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parcel] CHECK CONSTRAINT [FK_Parcel_SpatialUnit_SpatialUnitId]
GO
ALTER TABLE [dbo].[Parcel]  WITH CHECK ADD  CONSTRAINT [FK_Parcel_Tenure_TenureId] FOREIGN KEY([TenureId])
REFERENCES [dbo].[Tenure] ([TenureId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parcel] CHECK CONSTRAINT [FK_Parcel_Tenure_TenureId]
GO
ALTER TABLE [dbo].[Parcel]  WITH CHECK ADD  CONSTRAINT [FK_Parcel_Valuation_ValuationId] FOREIGN KEY([ValuationId])
REFERENCES [dbo].[Valuation] ([ValuationId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parcel] CHECK CONSTRAINT [FK_Parcel_Valuation_ValuationId]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Invoice_InvoiceId] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoice] ([InvoiceId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Invoice_InvoiceId]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Owner_OwnerId] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Owner] ([OwnerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Owner_OwnerId]
GO
ALTER TABLE [dbo].[PersonGroupLeadership]  WITH CHECK ADD  CONSTRAINT [FK_PersonGroupLeadership_GroupLeadership_GroupLeadershipId] FOREIGN KEY([GroupLeadershipId])
REFERENCES [dbo].[GroupLeadership] ([GroupLeadershipId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PersonGroupLeadership] CHECK CONSTRAINT [FK_PersonGroupLeadership_GroupLeadership_GroupLeadershipId]
GO
ALTER TABLE [dbo].[PersonGroupLeadership]  WITH CHECK ADD  CONSTRAINT [FK_PersonGroupLeadership_Person_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PersonGroupLeadership] CHECK CONSTRAINT [FK_PersonGroupLeadership_Person_PersonId]
GO
ALTER TABLE [dbo].[PersonGroupMembership]  WITH CHECK ADD  CONSTRAINT [FK_PersonGroupMembership_GroupMembership_GroupMembershipId] FOREIGN KEY([GroupMembershipId])
REFERENCES [dbo].[GroupMembership] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PersonGroupMembership] CHECK CONSTRAINT [FK_PersonGroupMembership_GroupMembership_GroupMembershipId]
GO
ALTER TABLE [dbo].[PersonGroupMembership]  WITH CHECK ADD  CONSTRAINT [FK_PersonGroupMembership_Person_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PersonGroupMembership] CHECK CONSTRAINT [FK_PersonGroupMembership_Person_PersonId]
GO
ALTER TABLE [dbo].[PersonInstitutionLeadership]  WITH CHECK ADD  CONSTRAINT [FK_PersonInstitutionLeadership_InsitutionLeadership_InstitutionLeadershipId] FOREIGN KEY([InstitutionLeadershipId])
REFERENCES [dbo].[InsitutionLeadership] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PersonInstitutionLeadership] CHECK CONSTRAINT [FK_PersonInstitutionLeadership_InsitutionLeadership_InstitutionLeadershipId]
GO
ALTER TABLE [dbo].[PersonInstitutionLeadership]  WITH CHECK ADD  CONSTRAINT [FK_PersonInstitutionLeadership_Person_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PersonInstitutionLeadership] CHECK CONSTRAINT [FK_PersonInstitutionLeadership_Person_PersonId]
GO
ALTER TABLE [dbo].[Restriction]  WITH CHECK ADD  CONSTRAINT [FK_Restriction_Charge] FOREIGN KEY([ChargeId])
REFERENCES [dbo].[Charge] ([ChargeId])
GO
ALTER TABLE [dbo].[Restriction] CHECK CONSTRAINT [FK_Restriction_Charge]
GO
ALTER TABLE [dbo].[Restriction]  WITH CHECK ADD  CONSTRAINT [FK_Restriction_Mortgage] FOREIGN KEY([MortgageId])
REFERENCES [dbo].[Mortgage] ([MortgageId])
GO
ALTER TABLE [dbo].[Restriction] CHECK CONSTRAINT [FK_Restriction_Mortgage]
GO
ALTER TABLE [dbo].[Restriction]  WITH CHECK ADD  CONSTRAINT [FK_Restriction_Reserve] FOREIGN KEY([ReserveId])
REFERENCES [dbo].[Reserve] ([ReserveId])
GO
ALTER TABLE [dbo].[Restriction] CHECK CONSTRAINT [FK_Restriction_Reserve]
GO
ALTER TABLE [dbo].[Restriction]  WITH CHECK ADD  CONSTRAINT [FK_Restriction_StatutoryRestriction] FOREIGN KEY([StatutoryRestrictionId])
REFERENCES [dbo].[StatutoryRestriction] ([StatutoryRestrictionId])
GO
ALTER TABLE [dbo].[Restriction] CHECK CONSTRAINT [FK_Restriction_StatutoryRestriction]
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FK_Service_Operation] FOREIGN KEY([OperationId])
REFERENCES [dbo].[Operation] ([OperationId])
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FK_Service_Operation]
GO
ALTER TABLE [dbo].[SpatialUnit]  WITH CHECK ADD  CONSTRAINT [FK_SpatialUnit_Boundary_BoundaryId] FOREIGN KEY([BoundaryId])
REFERENCES [dbo].[Boundary] ([BoundaryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SpatialUnit] CHECK CONSTRAINT [FK_SpatialUnit_Boundary_BoundaryId]
GO
ALTER TABLE [dbo].[SpatialUnit]  WITH CHECK ADD  CONSTRAINT [FK_SpatialUnit_MapIndex_MapIndexId] FOREIGN KEY([MapIndexId])
REFERENCES [dbo].[MapIndex] ([MapIndexId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SpatialUnit] CHECK CONSTRAINT [FK_SpatialUnit_MapIndex_MapIndexId]
GO
ALTER TABLE [dbo].[SpatialUnit]  WITH CHECK ADD  CONSTRAINT [FK_SpatialUnit_SpatialUnitSet_SpatialUnitSetId] FOREIGN KEY([SpatialUnitSetId])
REFERENCES [dbo].[SpatialUnitSet] ([SpatialUnitSetId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SpatialUnit] CHECK CONSTRAINT [FK_SpatialUnit_SpatialUnitSet_SpatialUnitSetId]
GO
ALTER TABLE [dbo].[SpatialUnit]  WITH CHECK ADD  CONSTRAINT [FK_SpatialUnit_Survey_SurveyId] FOREIGN KEY([SurveyId])
REFERENCES [dbo].[Survey] ([SurveyId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SpatialUnit] CHECK CONSTRAINT [FK_SpatialUnit_Survey_SurveyId]
GO
ALTER TABLE [dbo].[SpatialUnitSetRegistration]  WITH CHECK ADD  CONSTRAINT [FK_SpatialUnitSetRegistration_Registration_RegistrationId] FOREIGN KEY([RegistrationId])
REFERENCES [dbo].[Registration] ([RegistrationId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SpatialUnitSetRegistration] CHECK CONSTRAINT [FK_SpatialUnitSetRegistration_Registration_RegistrationId]
GO
ALTER TABLE [dbo].[SpatialUnitSetRegistration]  WITH CHECK ADD  CONSTRAINT [FK_SpatialUnitSetRegistration_SpatialUnitSet_SpatialUnitSetId] FOREIGN KEY([SpatialUnitSetId])
REFERENCES [dbo].[SpatialUnitSet] ([SpatialUnitSetId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SpatialUnitSetRegistration] CHECK CONSTRAINT [FK_SpatialUnitSetRegistration_SpatialUnitSet_SpatialUnitSetId]
GO
USE [master]
GO
ALTER DATABASE [LIMSCoreDb] SET  READ_WRITE 
GO
