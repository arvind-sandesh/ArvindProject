USE [master]
GO
/****** Object:  Database [ArvindProject_DB2]    Script Date: 08-Oct-2021 12:25:28 PM ******/
CREATE DATABASE [ArvindProject_DB2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ArvindProject_DB2', FILENAME = N'C:\Users\HP-Arvind\ArvindProject_DB2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ArvindProject_DB2_log', FILENAME = N'C:\Users\HP-Arvind\ArvindProject_DB2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ArvindProject_DB2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ArvindProject_DB2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ArvindProject_DB2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ArvindProject_DB2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ArvindProject_DB2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ArvindProject_DB2] SET ARITHABORT OFF 
GO
ALTER DATABASE [ArvindProject_DB2] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ArvindProject_DB2] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ArvindProject_DB2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ArvindProject_DB2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ArvindProject_DB2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ArvindProject_DB2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ArvindProject_DB2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ArvindProject_DB2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ArvindProject_DB2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ArvindProject_DB2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ArvindProject_DB2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ArvindProject_DB2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ArvindProject_DB2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ArvindProject_DB2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ArvindProject_DB2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ArvindProject_DB2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ArvindProject_DB2] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ArvindProject_DB2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ArvindProject_DB2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ArvindProject_DB2] SET  MULTI_USER 
GO
ALTER DATABASE [ArvindProject_DB2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ArvindProject_DB2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ArvindProject_DB2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ArvindProject_DB2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
USE [ArvindProject_DB2]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 08-Oct-2021 12:25:28 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 08-Oct-2021 12:25:28 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 08-Oct-2021 12:25:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 08-Oct-2021 12:25:28 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 08-Oct-2021 12:25:28 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 08-Oct-2021 12:25:28 PM ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 08-Oct-2021 12:25:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[FullName] [nvarchar](150) NOT NULL,
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
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 08-Oct-2021 12:25:28 PM ******/
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
/****** Object:  Table [dbo].[Employees]    Script Date: 08-Oct-2021 12:25:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](100) NOT NULL,
	[Gender] [nvarchar](10) NOT NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[InstituteId] [bigint] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Institutes]    Script Date: 08-Oct-2021 12:25:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Institutes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[InstituteName] [nvarchar](150) NOT NULL,
	[ContactPerson] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[ContactNumber] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Institutes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210125053458_start', N'5.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210203055112_fksetnoAction', N'5.0.2')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'7185294a-9a1f-4b28-87f8-39bde4af691b', N'Staff', N'STAFF', N'7080ec34-5d6b-400c-9aad-0738fa996232')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'b48d9521-dc99-4287-94ea-6b9cebc4949a', N'Admin', N'ADMIN', N'50592aaa-2979-4227-8f55-ee6f17e678ea')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'c574acd9-4950-4bac-b087-9e14065d2522', N'SuperAdmin', N'SUPERADMIN', N'0f6b5334-71a8-4f0e-abe2-2d68d123f31c')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'33029a72-43d9-4ceb-992a-ac37e604c938', N'7185294a-9a1f-4b28-87f8-39bde4af691b')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'33975cf9-2ccd-49c3-9e29-ad44c9d50526', N'7185294a-9a1f-4b28-87f8-39bde4af691b')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3a91887c-43b1-4170-9ba3-d1ad284b9f7f', N'7185294a-9a1f-4b28-87f8-39bde4af691b')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'33975cf9-2ccd-49c3-9e29-ad44c9d50526', N'b48d9521-dc99-4287-94ea-6b9cebc4949a')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3a91887c-43b1-4170-9ba3-d1ad284b9f7f', N'b48d9521-dc99-4287-94ea-6b9cebc4949a')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3a91887c-43b1-4170-9ba3-d1ad284b9f7f', N'c574acd9-4950-4bac-b087-9e14065d2522')
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'33029a72-43d9-4ceb-992a-ac37e604c938', N'Arvind Sandesh', N'arvind@sandeshbharat.com', N'ARVIND@SANDESHBHARAT.COM', N'arvind@sandeshbharat.com', N'ARVIND@SANDESHBHARAT.COM', 1, N'AQAAAAEAACcQAAAAEKoir//gTxW13jpuHAoe7dbAAk1bXWbrItbp735ptTIcvFk5NsGp7QG0PEXRoPvJsQ==', N'USWAGKKBJECUE4XBKEDH6VETCGDQERO6', N'738d20b8-91f4-4927-9a44-574f19855760', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'33975cf9-2ccd-49c3-9e29-ad44c9d50526', N'Arvind Coolhunk', N'arvind.coolhunk@gmail.com', N'ARVIND.COOLHUNK@GMAIL.COM', N'arvind.coolhunk@gmail.com', N'ARVIND.COOLHUNK@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEAPMG078Sjoegg2/ctprYhLkmoOydYNiaddMZyfwVVKcB0DKQi54+AU7/pK4HqaOYQ==', N'3VXY353FREEIG3XSFHQOALTK4VJXZKBJ', N'6308799c-29c2-4972-9595-a1dee8b4ec1d', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3a91887c-43b1-4170-9ba3-d1ad284b9f7f', N'Arvind Kumar', N'arvind.monu@gmail.com', N'ARVIND.MONU@GMAIL.COM', N'arvind.monu@gmail.com', N'ARVIND.MONU@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEADJEzqIdU/TK+DaQg7YJN6Nypyd4aTtuytydEd/QTF6ZAsYGqFZ/5XSK4WbJ9JGqA==', N'BSRAFNKYUJMZ7RK4EW4VUFJHLIPR3RGD', N'0c64c417-f6d8-4125-9722-fe9840b326d0', NULL, 0, 0, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([Id], [EmployeeName], [Gender], [DateOfBirth], [Email], [InstituteId]) VALUES (1, N'ARVIND KUMAR CHAUDHARY', N'1', CAST(0x07000000000044090B AS DateTime2), N'arvind.monu@gmail.com', 1)
INSERT [dbo].[Employees] ([Id], [EmployeeName], [Gender], [DateOfBirth], [Email], [InstituteId]) VALUES (2, N'ARVIND COOLHUNK', N'1', CAST(0x070000000000D10E0B AS DateTime2), N'arvind.coolhunk@gmail.com', 1)
SET IDENTITY_INSERT [dbo].[Employees] OFF
SET IDENTITY_INSERT [dbo].[Institutes] ON 

INSERT [dbo].[Institutes] ([Id], [InstituteName], [ContactPerson], [Email], [ContactNumber]) VALUES (1, N'SANDESH TECH SOFT', N'Abhai Srivastava', N'abhaideep@gmail.com', N'9919819824')
SET IDENTITY_INSERT [dbo].[Institutes] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 08-Oct-2021 12:25:28 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 08-Oct-2021 12:25:28 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 08-Oct-2021 12:25:28 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 08-Oct-2021 12:25:28 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 08-Oct-2021 12:25:28 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [EmailIndex]    Script Date: 08-Oct-2021 12:25:28 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 08-Oct-2021 12:25:28 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Employees_InstituteId]    Script Date: 08-Oct-2021 12:25:28 PM ******/
CREATE NONCLUSTERED INDEX [IX_Employees_InstituteId] ON [dbo].[Employees]
(
	[InstituteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Institutes_InstituteId] FOREIGN KEY([InstituteId])
REFERENCES [dbo].[Institutes] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Institutes_InstituteId]
GO
USE [master]
GO
ALTER DATABASE [ArvindProject_DB2] SET  READ_WRITE 
GO
