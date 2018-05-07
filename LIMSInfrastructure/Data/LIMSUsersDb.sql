USE [master]
GO
/****** Object:  Database [LIMSUsersDb]    Script Date: 5/2/2018 11:18:51 AM ******/
CREATE DATABASE [LIMSUsersDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LIMSUsersDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\LIMSUsersDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LIMSUsersDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\LIMSUsersDb.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LIMSUsersDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LIMSUsersDb] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [LIMSUsersDb] SET ANSI_NULLS ON 
GO
ALTER DATABASE [LIMSUsersDb] SET ANSI_PADDING ON 
GO
ALTER DATABASE [LIMSUsersDb] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [LIMSUsersDb] SET ARITHABORT ON 
GO
ALTER DATABASE [LIMSUsersDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [LIMSUsersDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LIMSUsersDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LIMSUsersDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LIMSUsersDb] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [LIMSUsersDb] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [LIMSUsersDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LIMSUsersDb] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [LIMSUsersDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LIMSUsersDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LIMSUsersDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LIMSUsersDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LIMSUsersDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LIMSUsersDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LIMSUsersDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LIMSUsersDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LIMSUsersDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LIMSUsersDb] SET RECOVERY FULL 
GO
ALTER DATABASE [LIMSUsersDb] SET  MULTI_USER 
GO
ALTER DATABASE [LIMSUsersDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LIMSUsersDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LIMSUsersDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LIMSUsersDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
USE [LIMSUsersDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/2/2018 11:18:52 AM ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 5/2/2018 11:18:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 5/2/2018 11:18:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IPAddress] [nvarchar](max) NULL,
	[Users] [int] NOT NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 5/2/2018 11:18:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 5/2/2018 11:18:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 5/2/2018 11:18:52 AM ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 5/2/2018 11:18:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 5/2/2018 11:18:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180105053858_V1', N'2.0.1-rtm-125')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180208070616_IdentityUpdates', N'2.0.1-rtm-125')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180208185547_Rbac', N'2.0.1-rtm-125')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName], [CreatedDate], [Description], [IPAddress], [Users]) VALUES (N'78bce290-e199-4cee-961d-0b076a9ccd0f', N'358b8403-e2aa-40f5-993f-98db6535bff4', N'Admin', N'ADMIN', CAST(N'2018-02-09T05:54:41.6423407' AS DateTime2), N'manages application functionalities', N'::1', 0)
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName], [CreatedDate], [Description], [IPAddress], [Users]) VALUES (N'f550bbae-0f07-4e39-a570-9b9dd9abf1b1', N'c5340632-85b8-4116-bdc2-14e74fb2a856', N'Surveyor', N'SURVEYOR', CAST(N'2018-02-09T05:56:39.5250862' AS DateTime2), N'initiates and Submits survey measurement ', N'::1', 0)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'361ba613-c4bf-4df3-a8f2-5dd6a6a19790', N'78bce290-e199-4cee-961d-0b076a9ccd0f')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a1793179-a0d1-40ca-9cbd-7d1cd73f9ac7', N'78bce290-e199-4cee-961d-0b076a9ccd0f')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'65d6ceda-7a33-4dd5-b6a3-f8ed9bf2f93a', N'f550bbae-0f07-4e39-a570-9b9dd9abf1b1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'870bcc0c-de5d-4443-b16c-4d6ac288ab98', N'f550bbae-0f07-4e39-a570-9b9dd9abf1b1')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [Name]) VALUES (N'0aeef19c-3dab-4d07-8617-6c6911f00f32', 0, N'19450fff-0f1d-469f-9dfb-ae1ec52b3b3f', N'user1@osl.co.ke', 0, 1, NULL, N'USER1@OSL.CO.KE', N'USER1', N'AQAAAAEAACcQAAAAEIKa1HSgyqrumLTJxfKVu6EHoSodXrv5HMnnSduxplN9mEj/ZER/XMl8aH8WzbvTHw==', NULL, 0, N'f6888a27-14fc-4983-b622-9389449c3d79', 0, N'user1', NULL)
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [Name]) VALUES (N'29dc7978-d949-4244-8db8-b1c8dd305057', 0, N'28b25812-b23d-4379-adfc-8fe551113f8f', N'juniorkachann@gmail.com', 0, 1, NULL, N'JUNIORKACHANN@GMAIL.COM', N'USER4', N'AQAAAAEAACcQAAAAEKA1GEMndI+ELaM/RqbRs2gahw1XswAJWyq81qHgPgVRvaMXXE2gMrnZJ0ef9atMOA==', NULL, 0, N'e0b7c0b3-ea04-4d4a-bdc2-c03b19a3a414', 0, N'user4', NULL)
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [Name]) VALUES (N'2d0af78d-04cd-4ebd-9932-6747944965e0', 0, N'3b647d82-405d-440c-af63-9c42edfd5e56', N'princechanns@gmail.com', 0, 1, NULL, N'PRINCECHANNS@GMAIL.COM', N'USER2', N'AQAAAAEAACcQAAAAELiGaP0VTSYJyfIA2bxJhUexm2dllZjr/qEtIUs8fJAuvYoPuP/3ECKwHDvQtjMsHw==', NULL, 0, N'271a8b55-1fcb-43cf-97d4-8d35b1033991', 0, N'user2', NULL)
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [Name]) VALUES (N'361ba613-c4bf-4df3-a8f2-5dd6a6a19790', 0, N'bf4f3424-66c6-45df-93ff-9e7b6f7fbc96', N'channsia@yahoo.com', 0, 1, NULL, N'CHANNSIA@YAHOO.COM', N'ADMIN', N'AQAAAAEAACcQAAAAEGbWiNdO8f5eI+tiVDsoyjJ+4B0XBARl3/NLHoxAftDasYOrTI2ef/8G60rvvgKgdw==', N'0713928142', 0, N'6930a502-e649-40ea-9bc3-69e2619f69f8', 0, N'admin', N'admin')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [Name]) VALUES (N'39c1507c-72a6-4ba2-8bb5-5a8b455812df', 0, N'7c82ccb1-e0e5-441f-a216-281154933a7a', N'channsia@yahoo.com', 0, 1, NULL, N'CHANNSIA@YAHOO.COM', N'ISAAC', N'AQAAAAEAACcQAAAAEJ6Bxc2BE7fG+sRdN/nXrc2v0/01mFz1s9F5cxgD1zmbKw3fLH3S2+M7XVPJqw7kpw==', NULL, 0, N'97ffd740-2369-43da-bdb9-1d7a0166008b', 0, N'isaac', NULL)
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [Name]) VALUES (N'65d6ceda-7a33-4dd5-b6a3-f8ed9bf2f93a', 0, N'dc4aa31b-9618-4e88-9f6e-32ed67595408', N'fred@gmail.com', 0, 1, NULL, N'FRED@GMAIL.COM', N'FRED1', N'AQAAAAEAACcQAAAAEDh1Lb078l4Y3qTLy+IS7sX8n1wOI/R2XqKG8MmjWv9WLP3L4wSnaFXFfpbUy7CeXw==', NULL, 0, N'0548c8da-f98b-4acc-a4db-214f45c56558', 0, N'fred1', N'fred')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [Name]) VALUES (N'870bcc0c-de5d-4443-b16c-4d6ac288ab98', 0, N'87243d48-2973-4354-b53b-20a8ac46cc21', N'iChann@ols.co.ke', 0, 1, NULL, N'ICHANN@OLS.CO.KE', N'CHANN', N'AQAAAAEAACcQAAAAEC7AE6e18bM+ziJssYnWsWKkEgDpI0f8NjH6T3bwvT2tsfSQF6zw7sbYGsLNZmrSww==', NULL, 0, N'9fa989af-1854-4933-b4df-efa2f7640a89', 0, N'chann', N'chann saac')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [Name]) VALUES (N'9bfc6a75-ee32-4e23-bdd3-d3ca84060d44', 0, N'dd56007b-4895-4c4a-a097-efc19ae60cfa', N'channsia@yahoo.com', 0, 1, NULL, N'CHANNSIA@YAHOO.COM', N'USER3', N'AQAAAAEAACcQAAAAEEObygscQEGxlwNPvP9lAb7fazJLoXuelaUJ0Ppq6CV8sph1iecnqz5avPfoLRG9YQ==', NULL, 0, N'77c674b2-8a58-4064-a74a-2072f67c207b', 0, N'user3', NULL)
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [Name]) VALUES (N'a1793179-a0d1-40ca-9cbd-7d1cd73f9ac7', 0, N'aa32b1ba-b2cd-476e-b440-e98ef8fcb8ec', N'elvis@ols.co.ke', 0, 1, NULL, N'ELVIS@OLS.CO.KE', N'ELVIS', N'AQAAAAEAACcQAAAAECDcHDR/tjDwf5J9Xu9Eu1EPsLw7jHP7o5vUYXHjJASpg5jS6ItVFRJ92ZtjhetkoA==', NULL, 0, N'1280834d-62be-43a8-bb88-d11c7714e210', 0, N'elvis', N'elvis')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [Name]) VALUES (N'a904ceac-7a02-45a6-aa28-8bf1b5a20ffb', 0, N'27f5e84d-b4dd-414c-9c8d-1a2e2eafaca6', N'juniorkachann@gmail.com', 0, 1, NULL, N'JUNIORKACHANN@GMAIL.COM', N'CHANNSIA', N'AQAAAAEAACcQAAAAEIt19+trDV+QKSfAT8gklLbsD5/IjrNVj5bxPouEHiJooxW2wUmVBwZUF8M2yXtNrQ==', NULL, 0, N'6661b84b-2136-44ee-bb62-cef469b3a908', 0, N'channsia', NULL)
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [Name]) VALUES (N'ec630609-f9b2-4200-b1d2-0865b5a4d23e', 0, N'ac3c3406-efbc-4956-b739-fac98c4057a6', N'ols@yahoo.com', 0, 1, NULL, N'OLS@YAHOO.COM', N'USER10', N'AQAAAAEAACcQAAAAELh5bwwuc78b/npvsFYvZChgsczZZTHA4h+VJNmPD5fC2TS1uhZUFckwAxsf5UKPhw==', NULL, 0, N'c01eca58-4725-4245-825b-7d80e7b399c8', 0, N'user10', NULL)
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 5/2/2018 11:18:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 5/2/2018 11:18:53 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 5/2/2018 11:18:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 5/2/2018 11:18:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 5/2/2018 11:18:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 5/2/2018 11:18:53 AM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 5/2/2018 11:18:53 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoles] ADD  DEFAULT ('0001-01-01T00:00:00.000') FOR [CreatedDate]
GO
ALTER TABLE [dbo].[AspNetRoles] ADD  DEFAULT ((0)) FOR [Users]
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
USE [master]
GO
ALTER DATABASE [LIMSUsersDb] SET  READ_WRITE 
GO
