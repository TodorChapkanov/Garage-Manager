USE [GarageManager-TSC]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 07/07/2019 17:16:47 ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 07/07/2019 17:16:47 ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 07/07/2019 17:16:47 ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 07/07/2019 17:16:47 ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 07/07/2019 17:16:47 ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 07/07/2019 17:16:47 ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 07/07/2019 17:16:47 ******/
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
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](40) NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[RecruitedOn] [datetime2](7) NULL,
	[DepartmentId] [nvarchar](450) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 07/07/2019 17:16:47 ******/
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
/****** Object:  Table [dbo].[Cars]    Script Date: 07/07/2019 17:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Id] [nvarchar](450) NOT NULL,
	[Vin] [nvarchar](17) NOT NULL,
	[ManufactureID] [nvarchar](450) NOT NULL,
	[ModelId] [nvarchar](450) NOT NULL,
	[CustomerId] [nvarchar](450) NULL,
	[Кilometers] [int] NOT NULL,
	[YearOfManufacture] [datetime2](7) NOT NULL,
	[EngineModel] [nvarchar](20) NOT NULL,
	[EngineHorsePower] [int] NOT NULL,
	[FuelTypeId] [nvarchar](450) NULL,
	[TransmissionId] [nvarchar](450) NOT NULL,
	[DepartmentId] [nvarchar](450) NULL,
	[ISFinished] [bit] NOT NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 07/07/2019 17:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 07/07/2019 17:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FuelTypes]    Script Date: 07/07/2019 17:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FuelTypes](
	[Id] [nvarchar](450) NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_FuelTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Part]    Script Date: 07/07/2019 17:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Part](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Number] [nvarchar](max) NULL,
	[Price] [float] NOT NULL,
	[CarId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Part] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RepairTypes]    Script Date: 07/07/2019 17:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RepairTypes](
	[Id] [nvarchar](450) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[Hours] [float] NOT NULL,
	[PricePerHour] [float] NOT NULL,
	[CarId] [nvarchar](450) NOT NULL,
	[MechanicId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_RepairTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 07/07/2019 17:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[Id] [nvarchar](450) NOT NULL,
	[CarId] [nvarchar](450) NOT NULL,
	[IsFinished] [bit] NOT NULL,
	[TotalCost] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceParts]    Script Date: 07/07/2019 17:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceParts](
	[ServiceId] [nvarchar](450) NOT NULL,
	[PartId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_ServiceParts] PRIMARY KEY CLUSTERED 
(
	[PartId] ASC,
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceRepairs]    Script Date: 07/07/2019 17:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceRepairs](
	[ServiceId] [nvarchar](450) NOT NULL,
	[RepairId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_ServiceRepairs] PRIMARY KEY CLUSTERED 
(
	[RepairId] ASC,
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransmissionTypes]    Script Date: 07/07/2019 17:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransmissionTypes](
	[Id] [nvarchar](450) NOT NULL,
	[Type] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_TransmissionTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleManufacturers]    Script Date: 07/07/2019 17:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleManufacturers](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_VehicleManufacturers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleModels]    Script Date: 07/07/2019 17:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleModels](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[ManufactirerId] [nvarchar](450) NULL,
 CONSTRAINT [PK_VehicleModels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190630142905_InitialDesign', N'2.2.4-servicing-10062')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190702215738_ServiceTableAndServicePartandServiceRepairTablesAdded', N'2.2.4-servicing-10062')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190704214844_GmUser_Changed', N'2.2.4-servicing-10062')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190705192924_Car_IsFinished_Added', N'2.2.4-servicing-10062')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'3476f025-4d01-4f83-8f89-f52ae60398ac', N'PDM', N'PDM', N'5f9ea754-cd82-4539-83c3-17d683456fec')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'54564c36-282e-4213-bc91-b04d375bcca2', N'TDM', N'TDM', N'8c2154c7-c514-48bb-9783-2a332dfdc17d')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'59267d7e-c365-4c7d-9e1d-0e5805499feb', N'Admin', N'ADMIN', N'10a962e4-c91b-4f5b-a94d-3c01bdabebb9')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'77ec207a-5bb9-45cb-8035-cb9f0c2ee852', N'MDM', N'MDM', N'32b1020f-17d6-4c4a-9740-cd6ec814b444')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'a0165e9e-10d9-41a3-a97c-8c76aafc58ac', N'WDM', N'WDM', N'71696e0b-c850-44ba-842b-265be67e2249')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7ee7b197-e9d8-417b-b986-3fafc7212ff8', N'59267d7e-c365-4c7d-9e1d-0e5805499feb')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [CreatedOn], [RecruitedOn], [DepartmentId]) VALUES (N'7ee7b197-e9d8-417b-b986-3fafc7212ff8', N'todor@abv.bg', N'TODOR@ABV.BG', N'todor@abv.bg', N'TODOR@ABV.BG', 0, N'AQAAAAEAACcQAAAAEB6X9472hyOJ6rCDecZ8fbevXNiZdQWtiUfNHJedcY14pMXzTRVmd3uiSlSTcXgPJg==', N'PCVZYNVWUTBHZ7V2D47TE6X4FQ3PEAT4', N'5da2d3b4-a96c-42d6-84d7-cbdc6cdc9c9c', N'0888630626', 0, 0, NULL, 1, 0, N'Todor', N'Chapkanov', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [CreatedOn], [RecruitedOn], [DepartmentId]) VALUES (N'fecde18d-2070-45d8-b02d-1b77840f00db', N'abv@abv.bg', N'ABV@ABV.BG', N'abv@abv.bg', N'ABV@ABV.BG', 0, N'AQAAAAEAACcQAAAAEJrAyznz596EJpnhrjtrg07XneaFynCUisDgeOXIuue1l2L/yVf+4P9Rkbk1d0a65Q==', N'HS46SQBDXZZLG5CUBXS2BKQR5HFPMSHP', N'7f30cc73-d712-40d8-89d2-59dfddf54656', N'0888630626', 0, 0, NULL, 1, 0, N'Todor', N'Chapkanov', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (N'484a2184-33bf-4b31-af39-047b9aa596da', N'sdfs', N'sdgs', N'fa@dfs', N'c')
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (N'65e5f471-df1c-4141-bc23-e7677b95aec5', N'Ivan', N'Ivanov', N'h@44.bg', N'0885')
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (N'bad6b54a-8ed4-46b6-99dc-c3d8afc07b88', N'iva', N'Marinova', N'h@44ds.bg', N'0885')
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (N'e281ebbb-5c0b-4607-96ee-8faa3ac908a0', N'Martin', N'Chapkanov', N'jh@asc.gbg', N'0885')
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (N'eb0f3f33-f18c-4415-9e6f-6fed43fbd8f6', N'Todor', N'Chapkanov', N'sad@abv.bg', N'0888630626')
INSERT [dbo].[FuelTypes] ([Id], [Type]) VALUES (N'13ffb72c-8d23-458f-89bb-bf3d5d21fd26', N'Diesel')
INSERT [dbo].[FuelTypes] ([Id], [Type]) VALUES (N'17e7283d-36f8-4183-9d53-2557529fe488', N'Vegetable Oil')
INSERT [dbo].[FuelTypes] ([Id], [Type]) VALUES (N'3ecb390d-a06d-4153-ab21-cf4c705f82ce', N'Electricity')
INSERT [dbo].[FuelTypes] ([Id], [Type]) VALUES (N'593ecc9d-9420-488b-9ec4-10464cdf3f0f', N'Hydrogen')
INSERT [dbo].[FuelTypes] ([Id], [Type]) VALUES (N'791eae12-f3f6-4e45-a9fe-544fa616668c', N'CNG')
INSERT [dbo].[FuelTypes] ([Id], [Type]) VALUES (N'8b99b2e0-f360-48c5-b276-26c7d8081e7f', N'Bio Diesel')
INSERT [dbo].[FuelTypes] ([Id], [Type]) VALUES (N'bb2a1ebb-8015-4e54-8299-34439c8c476a', N'Gasoline')
INSERT [dbo].[FuelTypes] ([Id], [Type]) VALUES (N'f978a29d-7e5c-4956-afda-3f33e4002799', N'LPG')
INSERT [dbo].[TransmissionTypes] ([Id], [Type]) VALUES (N'1e808174-e6ee-4e3c-9d07-f3e4628c7f48', N'Manual')
INSERT [dbo].[TransmissionTypes] ([Id], [Type]) VALUES (N'bf82c615-ddc8-4ace-a5ac-c118034b8bdb', N'Semi-automatic')
INSERT [dbo].[TransmissionTypes] ([Id], [Type]) VALUES (N'e63b7b16-0358-4d80-aefd-b587183e3420', N'Direct shift gearbox')
INSERT [dbo].[TransmissionTypes] ([Id], [Type]) VALUES (N'fbba0b25-6d6d-4f34-8706-34a24213195b', N'Automatic')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'00205674-d35a-498a-aee2-5c4bb9f9a8bd', N'IVECO')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'02b02a48-0436-4539-b691-53ade2d22356', N'Toyota')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'06eb49e7-5aba-486c-b84e-37ef8441ae9d', N'Haima')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'07ff5590-8e45-4e10-83e9-95a946838fd3', N'Genesis')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'0c253184-896b-48b3-b169-471e25fd7e33', N'Haval')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'0e45ac5d-f928-4e1f-afd6-b517bbf2021c', N'Ronart')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'10443281-7b3a-4d22-813b-83115e3a0380', N'Chery')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'10481089-df33-4439-b1c0-4e29cbc277d0', N'Lamborghini')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'10fd3d99-dc7b-4084-ac74-c6de68b2bd33', N'Hawtai')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'13185197-b7d2-4bfa-a147-354fffbd910b', N'LTI')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'13722633-e48b-42f9-b7b8-5ee21e241b3e', N'Ariel')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'14c02a8f-81b0-4a5b-b191-d983aec6fab1', N'Fiat')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'155d4648-5e6e-4e72-bae8-07ca283d48bb', N'E-Car')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'17218203-3c59-4c93-a81a-062527fc92c6', N'Fisker')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'177c5afd-4233-4d10-b4ce-64887ca70fed', N'Marussia')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'183e3eb0-fedf-419e-a103-71222e4ffae2', N'Invicta')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'1886d036-7c85-4cb2-b428-63dd6494243f', N'Lucid')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'19bdb5ae-b06b-4de4-a472-35af19deb085', N'MG')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'19c80c17-0c84-484b-9b83-59e5e4bed901', N'Lifan')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'1a651502-8349-4b6c-bccc-ec6a366028ff', N'Ecomotors')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'1c46d435-5577-4523-bc56-37947d08b623', N'Xin Kai')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'1d77749a-b193-44ab-aeb2-a6fc0275ff40', N'Changan')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'1f2c1ee7-e902-4ce5-af78-db989fa87e6b', N'GMC')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'20684ca8-f4b8-4bf9-b2a9-c3a2163eed92', N'Rezvani')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'214eebef-8d1a-4557-9154-60144f656a60', N'Tazzari')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'21dba530-e719-455c-8af1-14b1f75309a8', N'Brilliance')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'23c344a0-d700-41e9-91a5-3cd4a9d9ef0c', N'Volvo')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'256b72ba-6e7d-428b-bced-c5016ee2fea6', N'Hummer')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'2bc1e965-e4a0-4148-ba69-285bb60fb397', N'W Motors')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'2ccadfdd-4823-4132-9942-e216de777f5f', N'Dacia')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'2cd71503-5bcd-4f65-baf1-14e1b01d845b', N'Aston Martin')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'2dec248f-e55c-4600-9684-f82040437771', N'Lotus')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'2e3d2ec9-e633-48c4-9414-02d86f7179bf', N'SsangYong')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'311de51c-da1f-44e2-9ea6-e892736a8ef1', N'Mazda')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'32c777b4-932a-41aa-b733-d7fa0dcc1008', N'Saturn')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'330b2680-a64b-4b8b-b769-27f27749d6ba', N'Rimac')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'34766825-53a8-4663-b280-6a7a8ef4d695', N'Opel')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'34bbe093-f658-4a12-a1ba-b59659436228', N'Smart')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'356e1a07-d2d2-4e49-b14d-7381e3a493e3', N'Datsun')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'35c14e38-3759-4034-8103-17c1d0a3c45e', N'Morgan')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'362f25ad-010a-4ee5-8e60-3a7e0d2a3e03', N'HuangHai')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'3685ab0b-33d1-4903-bc78-1e0051a97beb', N'TATA')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'389c609f-88a4-4cf5-83fa-254494750ef5', N'Infiniti')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'3afbfd78-37b2-4d03-a253-4ecf64e8a7b5', N'Kombat')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'3d95e465-7b8e-47cf-99e8-f2e6f90828a0', N'Proton')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'3e62ca58-2199-4c6b-b3be-e24affe9f916', N'ChangFeng')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'3f6d7226-fac9-4d44-b348-658adbc445a1', N'Bugatti')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'40c5b314-71b6-4f7d-93f3-e445ede15e3b', N'BYD')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'41f521a5-bf5f-44fe-8cb1-1e41ceb3ddef', N'Maybach')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'4391872d-6c69-4727-9016-182f58949458', N'Landwind')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'46cc94c1-96d7-4543-a3c4-d491988363ed', N'Luxgen')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'49d0c5c3-edca-4af4-8f5c-78fd3c8ed045', N'Bentley')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'4a69ad3b-7286-4123-bf65-fcd4d56f07b8', N'Mitsuoka')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'4d85fab3-6e4a-46b8-a76b-b3cb5afbf108', N'Piaggio')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'4ee6c02f-120c-4d13-88f2-e3123e6a7a55', N'Zibar')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'50cf2df6-8aaf-491a-bd63-77d627eb2fb1', N'Tesla')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'5286a8dc-ae0c-45e4-9cca-d1ab9e339b8d', N'Shanghai Maple')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'54ee342d-5260-4e91-a6b3-310715065bb3', N'McLaren')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'5700d1b1-1b35-490e-9055-5dc414f6e24f', N'Wiesmann')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'5848086d-db5d-4dab-938a-ceeb96cff664', N'Bilenkin')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'589f1d95-b874-44c1-9384-84d19e168c2d', N'Alpine')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'58fc5b57-330e-446f-be55-a6a11e237d49', N'Microcar')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'595b3f88-8f37-4c94-8f31-4980a3290456', N'Honda')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'5aa91d17-cb4f-4418-aedc-edb01dae43ac', N'Derways')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'5b74871c-cd56-4264-872e-3cf8a781c40d', N'Ferrari')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'644870e8-4fa8-435f-8239-2ba144a9c168', N'Beijing')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'650dd48c-6055-4ef5-a6ce-fdb2b8004110', N'Pontiac')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'68b81e8d-38c9-4b25-843c-40464738f496', N'Maserati')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'68e7f8c1-ae77-491b-9cdf-bd1ff34a714e', N'Perodua')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'69028d61-d882-4d03-8248-3baa2bbbbe8e', N'Lancia')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'69a0d2b7-7a1c-4b9c-a71a-00c521c9f31d', N'Ultima')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'69e3fd0f-f18c-45a7-9b61-32b2781fd652', N'Subaru')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'6a70676e-0388-4237-86c7-65ba9a31e13b', N'Tramontana')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'6ddef8be-f1d0-4b01-ae04-9aff95e4e0ac', N'UAZ')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'6e115cca-9825-445e-905a-225d0011fff7', N'Daimler')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'6f581d7e-2891-4f4f-bbde-d4a93fea8642', N'Citroen')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'70b89f75-adf7-4e1f-9095-5764bc1a2f74', N'Spyker')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'72cc10f3-daa0-40c6-9f4e-cdad4277b13a', N'Great Wall')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'73f94dd1-9da3-413f-9d2b-2b7f0486d625', N'Scion')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'75849315-0706-4ed8-bea4-2c7fcac21489', N'Suzuki')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'779d9465-ca02-4332-bae3-2815f90ff72a', N'Donkervoort')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'7888c577-b80e-466a-a340-1f1d9b91541b', N'Foton')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'79eb1543-8244-48e1-908a-7778574b4cd7', N'AM General')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'7c37d988-d24e-45d4-aca0-0fdc66615efa', N'Mahindra')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'7f828726-e39d-48ba-b140-cbcffb570f89', N'Cadillac')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'819bf79a-6640-459d-878b-e798edff6b11', N'GAZ')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'8361f87b-18ee-4fac-96e3-5f8fd2c6123d', N'Zotye')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'83d16608-e410-44bc-986e-13ac3e40b61c', N'SEAT')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'84666b05-b003-46f2-8b5b-34cf63496380', N'Iran Khodro')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'88242ad7-6c82-4609-9f14-04f7f7c5ff38', N'Chrysler')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'88629d81-57ca-43ce-a44a-08d351fd95d5', N'Rolls-Royce')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'8a5f841d-f86a-4f7e-9cd2-c5ff5104bac8', N'MINI')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'8adcfe2e-2baf-4545-b88a-d1fd96c97d9e', N'Hafei')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'8d78b1b2-490e-4082-829d-47dc3e93406b', N'Daewoo')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'8e27171b-9aa7-4082-930f-3ae388187d2c', N'Daihatsu')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'8e632fa6-8afd-4c1e-8161-76b5c4257c2a', N'AC')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'8ee43737-d062-4d88-90c1-3a28a6d36632', N'Skoda')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'8f57b136-b51b-4a97-9818-3023ca41ec02', N'Caterham')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'8fae19da-8f72-4fb5-9d40-8ca95caae4ca', N'Borgward')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'905f0904-5f99-4106-8df8-5f7378bbfcfc', N'Buick')
GO
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'9194b953-0558-496d-9ba5-b782c29dd336', N'ZX')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'91a568a5-6cc4-4031-a92f-3f95465820d1', N'Mitsubishi')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'93a8b94d-424e-4dae-b892-9aaf90a32e59', N'Liebao Motor')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'9604dfb1-6583-47e9-9f96-b8a4111e44d2', N'Jinbei')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'963548b9-5235-447e-81ac-ee61c43b7c91', N'Geely')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'9ad726df-3fbe-4dc1-a830-1a48b443f1c4', N'PUCH')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'9d57f8a8-f924-413e-8e8a-dfaa13d7c93d', N'Renault Samsung')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'9f49b15c-e105-49a2-bd71-7607c435f852', N'Peugeot')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'a07e4d1d-0899-41b9-914e-c1aebc003621', N'Tianma')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'a0f006e7-6207-4b14-b6f9-caf0f724a3eb', N'Santana')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'a66c5dc2-f532-41d6-bcee-d5af30599012', N'FAW')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'a90381f4-56aa-4c45-99dc-22346ed3bb1f', N'Lincoln')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'aa311e15-13ec-4310-b437-63e939a7d828', N'Soueast')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'acf4fa9c-78fc-4751-ae5e-58cced695daf', N'Ravon')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'ad8b2b19-84d8-432c-b66f-ca52eed2b297', N'Hyundai')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'b32970fd-c6ff-4b5f-b9ca-1df5ef065c9f', N'Marlin')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'b4231ec5-38f6-49a3-ab06-0cd7d317d319', N'TagAZ')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'b43b29a9-866d-4d88-b02d-1b114bdc6d3a', N'Dodge')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'b5a7ddcd-46af-4470-a0ea-ff57f8aace5e', N'DS')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'b6c521f7-196b-4e8a-ae22-77b8005cfa92', N'BMW')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'b76437ce-50b6-470a-99f2-8aa6af492aa5', N'Alfa Romeo')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'b888e63e-432c-4a41-886a-b0522d63490e', N'Bufori')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'ba930a52-2bcf-45e4-8752-9878caab2ece', N'Pagani')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'bc02b10f-9445-45a2-9895-f480497eefbc', N'Brabus')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'be0f166b-3c26-44be-9bc3-dd8f26954816', N'ShuangHuan')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'bf41e991-1131-4d81-b303-5721dc8ccc85', N'Ford')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'c0c2ed5d-3eb3-446b-a587-c28d9d5247e3', N'Panoz')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'c1a9c207-b6e3-4ecc-a497-5c8cb74e3f9d', N'Jaguar')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'c31d0250-b2a8-40ab-89b6-73d720b6790e', N'Nissan')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'c3971358-82c7-4881-9ecc-eaab0580c476', N'Zastava')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'c49c2b77-4aa9-49b4-a517-62b95953b90e', N'ZAZ')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'c5117863-8cee-4645-b769-714f2f262f9f', N'Bajaj')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'c5fb28b0-9e14-47d8-bd6d-c2c596fbc395', N'Land Rover')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'c71181e3-f0b5-4582-9f55-2136aff9a0ce', N'Zenos')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'c8f02bff-be7e-4c21-a997-a82cade70a28', N'JMC')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'ccadb653-ebb9-4853-aa5e-efe7e7d9ff77', N'Think')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'cd21ca54-8f5a-418b-8a9d-7638db9857f4', N'Noble')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'cdc80d81-3c9e-4f16-abef-fcd466be500c', N'Izh')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'cf259200-2168-44f6-9cbe-a1da81f82c64', N'VAZ (Lada)')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'd187a531-c710-4495-bb5c-d158f7d0aad0', N'Maruti')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'd1bd9996-44d1-4fba-a179-2c064dafb537', N'Coggiola')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'd31cdc50-1d05-476d-9aea-9fe14dd18fcf', N'JAC')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'd58663a8-1a23-4cbd-a1ac-5f11d828f706', N'KTM')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'd81d4572-3d43-4083-81f4-11dcea1fd1d5', N'Mercury')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'daff5fdd-b27e-4c5a-84d8-6f008cdebd9f', N'Gordon')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'dcdcf034-a1c6-4e27-8972-ebb59c9d2b07', N'Gonow')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'ddbbfe66-b3e0-46d8-b692-b4df7406f33c', N'Yo-mobile')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'de3d4ee5-78b5-41f9-8362-086032c1b98a', N'Vauxhall')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'df50fb40-52db-40f2-a20b-8a93dc967e62', N'Porsche')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'e010be8c-1270-4b16-8e46-ca172ad9f83c', N'Audi')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'e324cfc2-ca55-4290-8a98-d614b3301011', N'Hindustan')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'e3a23304-a5f5-4f66-9c3a-ec7490fbc764', N'Vortex')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'e46ed379-206c-461a-87a3-408ca7998273', N'Holden')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'e4a6fc12-599b-491c-9b1b-857a49967138', N'Chevrolet')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'e95bab32-1911-408e-b846-41bed318d406', N'Koenigsegg')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'eae34886-31be-4615-bc01-a80723d8dd56', N'Volkswagen')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'eae3b358-72a7-4142-992c-73d0f7c7b42a', N'Kia')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'eb52a9e5-c2fd-47d2-a12d-d1466153d7e2', N'Bronto')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'ed6ecfd5-9937-4b18-8657-66ff17ba9551', N'Westfield')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'edcae123-7e98-4f7b-bbb0-d76306ea4d2c', N'Acura')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'ee432742-699d-4ffc-af14-4a08786cde99', N'PGO')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'eeb274f8-38af-47c5-8d1e-bce37166c0cd', N'Jeep')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'f05c93a2-86b0-48c2-8f10-e9b83c66435c', N'DongFeng')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'f2070ff6-7dd1-42e3-95c2-d8f992349b17', N'Saab')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'f3113047-cd76-4253-9202-7d61b65aece5', N'Mercedes-Benz')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'f4c9c3ec-be25-4f67-a604-ab5132543458', N'Bristol')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d', N'Renault')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'f77c06ec-9835-49e1-a08c-9fb6b8a8e23e', N'Byvin')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'f9410f25-7b92-4ef3-a44f-d1550773451e', N'Zenvo')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'f9d7aa29-6791-40f0-ab49-03c6378d67b8', N'Qoros')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'fcf4360f-ef5c-4f0c-80da-2d5eb4fc76a3', N'Fuqi')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'fdda3ac0-16db-45de-9950-13429f9971e3', N'Lexus')
INSERT [dbo].[VehicleManufacturers] ([Id], [Name]) VALUES (N'ffed9373-9b26-47d7-82ca-8564db8fbd20', N'Isuzu')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'00006376-5951-4172-bf1e-e45a52149131', N'Torrent', N'650dd48c-6055-4ef5-a6ce-fdb2b8004110')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'00094cfe-8fb7-4a5d-961a-8c68eb78567a', N'One-77', N'2cd71503-5bcd-4f65-baf1-14e1b01d845b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'00152c9b-2109-4a58-9385-df0292a222d7', N'F3', N'40c5b314-71b6-4f7d-93f3-e445ede15e3b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0071cc1a-acd4-42ee-ad01-c2748f30eb38', N'Sportage', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'011744a8-28a1-44c6-945c-7e8e77bd404a', N'Rich', N'f05c93a2-86b0-48c2-8f10-e9b83c66435c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'01484ab4-8988-4489-8c58-b490ae1d7a84', N'CX-7', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'01a2ba86-cdaa-4922-aa41-2d7de8ab8f0d', N'Camaro', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'01a39a23-a1aa-4504-811e-f5b5b356ff05', N'S6', N'40c5b314-71b6-4f7d-93f3-e445ede15e3b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'01dab75c-2b0e-48a2-8ff9-015171af3a40', N'BLS', N'7f828726-e39d-48ba-b140-cbcffb570f89')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'021b91e5-772d-4bb5-9a05-3b2ff8a7ee90', N'Altima', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0273c848-2175-450c-b8b6-2a9341bef1a2', N'Tuscani', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'02d36192-557c-4f09-adac-91cc6d0d0833', N'TL', N'edcae123-7e98-4f7b-bbb0-d76306ea4d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'02e12259-774c-451d-a447-35ddae362005', N'Avante', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'02f2e24a-fd40-4818-8ca0-6ead84ed0eac', N'Nano', N'3685ab0b-33d1-4903-bc78-1e0051a97beb')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0327a9f4-2924-47de-bf2e-fb955d1491b4', N'Mirai', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0342977f-2f85-4861-adf2-c7a2d9eb1585', N'TX', N'13185197-b7d2-4bfa-a147-354fffbd910b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0354d327-03bd-4698-a69d-ffe6e53e2589', N'A6', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'035e0e7e-44b7-446f-84b3-d41d213db5ee', N'Voyager', N'88242ad7-6c82-4609-9f14-04f7f7c5ff38')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'035e98f3-a860-4647-aec2-ef90e281a0ce', N'Kalos', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'037c698a-7e77-4ddc-b606-b7cd39e213e9', N'Mirage', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'03b3cac4-fa76-437c-9a93-b80ff69c3a35', N'10', N'c3971358-82c7-4881-9ecc-eaab0580c476')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'04288333-4313-4c65-b550-cff16785b4b9', N'Sceo', N'be0f166b-3c26-44be-9bc3-dd8f26954816')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0468940d-9d0f-4f2b-bf12-b45c74d1f615', N'C3', N'6f581d7e-2891-4f4f-bbde-d4a93fea8642')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'049e6a74-0c6d-49c2-be17-a9a8bbde02fb', N'Seicento', N'14c02a8f-81b0-4a5b-b191-d983aec6fab1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'04adab2f-6a33-49e1-8313-baebf0b48cc3', N'Sai', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'04b60998-8a48-4293-937b-a89c815b0b8e', N'X-Bow', N'd58663a8-1a23-4cbd-a1ac-5f11d828f706')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'04c3187e-c2bd-4d76-8ae3-56b41c5285d4', N'F-150', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'051579ff-a0c5-4fab-8961-b1e47f0ff2dc', N'Caravan', N'b43b29a9-866d-4d88-b02d-1b114bdc6d3a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0562df53-28ec-4e01-a188-51d45aa53e7e', N'Tundra', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'058a7497-ea24-4f9c-b669-caf4f1576885', N'Baleno', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'05befeec-7135-41ff-8072-de6504d2ca71', N'NV200', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'05dd810f-2fe3-4286-8c87-e12a5937cd21', N'9-3', N'f2070ff6-7dd1-42e3-95c2-d8f992349b17')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'05e0595f-0961-4563-b22f-c1cfe9d971d4', N'Fiesta', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'061ffbed-54da-45ce-bf06-7e0cadbd52f2', N'Kaptur', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0642dd85-af02-4404-862d-de020d09c211', N'Vintage', N'5848086d-db5d-4dab-938a-ceeb96cff664')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'064e1305-cdf4-464c-a589-d3bfb68684b3', N'Tavera', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0659976e-2dd3-4285-bea7-646b84cf6617', N'QX60', N'389c609f-88a4-4cf5-83fa-254494750ef5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'065eb410-cb12-4578-bf52-7e9179e6324f', N'XL1', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0693b782-a7e0-493f-a0d8-17115ea9a7d5', N'Clipper', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'06dc64f3-e847-471f-a0a5-2abf879baefc', N'Ghost', N'88629d81-57ca-43ce-a44a-08d351fd95d5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'072f82ad-7299-4a74-99ef-b73a25478b9a', N'Blenheim', N'f4c9c3ec-be25-4f67-a604-ab5132543458')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0789d6f2-8863-4b9c-b73e-ed07e9bd7f2f', N'Impala', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'079d1034-d11e-43f8-b0e5-bc97895d4c63', N'Pixo', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'07d64425-a957-4de2-9265-452d360bbf31', N'Vida', N'c49c2b77-4aa9-49b4-a517-62b95953b90e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0816a5d5-b1b2-4c71-be9e-c58db09b9122', N'Concept_One', N'330b2680-a64b-4b8b-b769-27f27749d6ba')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'084de027-0c3e-4c0b-9616-bb231316d2c4', N'Lanos', N'8d78b1b2-490e-4082-829d-47dc3e93406b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'08655439-ae0f-4892-b8cf-f6e7bf21ad92', N'Innova', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'08674a28-c28e-4589-9ac4-f7de1e678b1d', N'Haise', N'9604dfb1-6583-47e9-9f96-b8a4111e44d2')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'08714397-3f10-439d-88d0-d99e1791dc32', N'Aveo', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'08748260-41eb-4b58-bd29-9d6dd65018d9', N'Vitz', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0891ec2f-9153-4624-8f21-ba9a0acf040e', N'C190', N'b4231ec5-38f6-49a3-ab06-0cd7d317d319')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'08a17b8f-e79e-44f2-9ea6-e9351a6705bc', N'Estina', N'e3a23304-a5f5-4f66-9c3a-ec7490fbc764')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'08aa551d-1de3-4678-b271-113652e31fea', N'C81', N'5286a8dc-ae0c-45e4-9cca-d1ab9e339b8d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'08fa267c-50c0-4eaf-bdbc-fb8256387d9f', N'P1', N'54ee342d-5260-4e91-a6b3-310715065bb3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'095aea9b-4ef4-4a37-a0b2-edc0216e20b8', N'V12', N'2cd71503-5bcd-4f65-baf1-14e1b01d845b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'09867d16-9bd3-49d5-baa4-70464e779b1b', N'Alphard', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'09b1da77-5245-4a1a-bbc9-40adae6e6005', N'V12', N'2cd71503-5bcd-4f65-baf1-14e1b01d845b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'09cd08bd-d47d-41ee-a8d2-9abd7e6b8e05', N'S5', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'09da5fed-85a8-47db-aab9-ba0b9c8f9d12', N'Ractis', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0a0a59b6-5d2b-4641-b7fb-273efb63bced', N'NX', N'fdda3ac0-16db-45de-9950-13429f9971e3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0a1b481f-9916-413c-a489-f8d9c8f932de', N'Savrin', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0a1d0798-0562-4f02-9069-6de8d730a028', N'Exora', N'3d95e465-7b8e-47cf-99e8-f2e6f90828a0')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0b01bdf0-bdd8-40b5-9ea1-e5aa131703e6', N'Ridgeline', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0b161f41-3925-4ec6-9660-7f5403a9a713', N'Escudo', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0b23a9e7-40c7-4a16-89d8-4279cb681a8f', N'Liana', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0ba1ce30-f93c-4025-921f-236044bd26c7', N'H2', N'256b72ba-6e7d-428b-bced-c5016ee2fea6')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0bb06807-2660-44f6-873a-c7a485ba25ef', N'5er', N'b6c521f7-196b-4e8a-ae22-77b8005cfa92')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0bcc8843-b626-4a7d-ab43-4cf151235f5e', N'i8', N'b6c521f7-196b-4e8a-ae22-77b8005cfa92')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0bdef99c-5424-4da8-bd89-a639a57a6757', N'Pickup', N'1c46d435-5577-4523-bc56-37947d08b623')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0c1620f3-fb53-4e59-8741-4297f5c9e5a5', N'N-One', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0c714884-c5b8-46b2-aadc-70b05b2ba593', N'SM5', N'9d57f8a8-f924-413e-8e8a-dfaa13d7c93d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0cff5212-4db5-4be5-8556-21a7e515a6d1', N'675LT', N'54ee342d-5260-4e91-a6b3-310715065bb3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0d069565-0c95-4947-8f88-822f131e592a', N'Captiva', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0d0e3962-660c-43cb-b218-1949cc4435fb', N'Maxima', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0d12d652-dae8-4a5f-8e3a-6df821fb6a3a', N'Q50', N'389c609f-88a4-4cf5-83fa-254494750ef5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0d2a7a13-a173-4ac3-b80f-6fe1795a7938', N'i-MiEV', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0d791a49-469f-47ec-a266-b298c9ae664a', N'Plutus', N'362f25ad-010a-4ee5-8e60-3a7e0d2a3e03')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0db02279-41c0-4065-85ed-d7cf43577bb9', N'Paceman', N'8a5f841d-f86a-4f7e-9cd2-c5ff5104bac8')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0dbb2466-cd85-4708-b873-07bdd3c54b49', N'Soren', N'84666b05-b003-46f2-8b5b-34cf63496380')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0df07f63-1854-46a8-9175-1943b9f1e820', N'EON', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0e0c9b74-a448-45d1-aaf6-571234613502', N'AZ-Wagon', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0e141ecd-968c-4581-8c84-b1bfea0108d6', N'Sable', N'd81d4572-3d43-4083-81f4-11dcea1fd1d5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0e1dbc04-9aba-4167-8ee7-f973746ad1f5', N'M5', N'b6c521f7-196b-4e8a-ae22-77b8005cfa92')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0e24de1d-6bf2-45c7-894c-0ba875b2bd26', N'Element', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0e337c62-ee88-4a0c-827b-4e1093cd8d7b', N'Vanette', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0e4ff077-3754-4bfc-b367-f4f32d77f206', N'M4', N'b6c521f7-196b-4e8a-ae22-77b8005cfa92')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0e507cc3-4883-4d61-8cd1-1e9e540d006b', N'Porter', N'4d85fab3-6e4a-46b8-a76b-b3cb5afbf108')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0e941958-198b-4cc4-9134-8067dd164c10', N'X3', N'b6c521f7-196b-4e8a-ae22-77b8005cfa92')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0eb29883-0455-4566-a68d-eca87af6f1e0', N'MKX', N'a90381f4-56aa-4c45-99dc-22346ed3bb1f')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0eb42ad4-a168-4e7a-b04d-bdf2e2d6f01e', N'XL7', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0f1d88ab-a964-4417-b64f-6d3c0356681b', N'GS', N'19bdb5ae-b06b-4de4-a472-35af19deb085')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0f5beff1-fd74-49a1-8f59-e7b5fe64bb77', N'Stepwgn', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'0fc9444e-ad8c-4347-8691-4f5edc95a1e4', N'4Runner', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1041294c-8487-4444-ae8e-812a77097c1f', N'Virage', N'2cd71503-5bcd-4f65-baf1-14e1b01d845b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'108dde8d-4b57-498a-8535-873ecb2ba050', N'MPV', N'f05c93a2-86b0-48c2-8f10-e9b83c66435c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'10951bdb-8338-44a5-b857-c9951583f431', N'R1', N'69e3fd0f-f18c-45a7-9b61-32b2781fd652')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'109fc5b4-af62-4888-ac5a-75934a3feaed', N'Crossroad', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'10ee29f4-10ff-4ae8-a377-4760da2d3903', N'Aura', N'32c777b4-932a-41aa-b733-d7fa0dcc1008')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'10eecae0-5fe2-4f0b-aa74-dd0d8adf0849', N'Hover', N'72cc10f3-daa0-40c6-9f4e-cdad4277b13a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1155c2d5-94f5-47ef-b177-339aed30bb85', N'M6', N'40c5b314-71b6-4f7d-93f3-e445ede15e3b')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'118aa3f8-f49d-44f9-93fd-bc1ab335e2e3', N'Blade', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'11ba5a8d-31e4-4439-b1a0-0966e83947ca', N'307', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'11d60fb5-36d5-4649-9696-1acfc2230e41', N'Airwave', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'11f6d7fd-ad75-448c-81cc-b9e1c733f32a', N'LC', N'fdda3ac0-16db-45de-9950-13429f9971e3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'120c05d3-9565-4cd4-a91a-40a555ddf81e', N'Carnival', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'12664bc4-82d1-4db0-aad9-16c9da617bc6', N'Pride', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'12ba825f-373b-4e1c-98dd-14d0126e00d5', N'Territory', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'12e348dc-0430-49ec-a973-00a397122805', N'G6', N'40c5b314-71b6-4f7d-93f3-e445ede15e3b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1315f700-a2d5-4a6a-bcb6-4e8dee56a3d9', N'E-Krossover', N'ddbbfe66-b3e0-46d8-b692-b4df7406f33c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'132f5bf3-9cd7-491b-9fc4-11dca9ceaf78', N'Nomad', N'2e3d2ec9-e633-48c4-9414-02d86f7179bf')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'134a1878-bc68-4226-b1f7-7755b6b1a910', N'500L', N'14c02a8f-81b0-4a5b-b191-d983aec6fab1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1367b80e-f51f-467a-920c-bafc03eb885d', N'Acty', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'13890dbe-d290-4e7d-9040-84493e8dfc18', N'5008', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'13b0a7ca-bf48-44b5-a7b6-9bf4bc8b369f', N'Range', N'c5fb28b0-9e14-47d8-bd6d-c2c596fbc395')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'143b2ddb-f538-4e0e-8f38-0fd8b9a3eea4', N'Mustang', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'14d58eb2-a334-4ffa-902b-9c2118175a2d', N'Excelle', N'905f0904-5f99-4106-8df8-5f7378bbfcfc')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'14d8a755-cd61-4670-bc16-38e0d68b0b8e', N'M600', N'cd21ca54-8f5a-418b-8a9d-7638db9857f4')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'14da0bf6-780d-4b05-a66a-127e456b7331', N'i', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'14e9451a-7879-47e8-afa5-10708d4e4775', N'Eclipse', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'14f42381-0ee6-49ca-9885-339d68480f7a', N'QX30', N'389c609f-88a4-4cf5-83fa-254494750ef5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'15586c4d-671f-4b24-a11b-200323a85311', N'XC90', N'23c344a0-d700-41e9-91a5-3cd4a9d9ef0c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'15a524b2-fef1-444c-b863-e6821c293a91', N'Sienna', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'15d35594-1662-4e3a-859a-9e7192d44dff', N'Life', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'15dc79f9-4265-4832-b021-c3300a2d673d', N'Q2', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'169a8b56-9c76-407e-b91c-dc32fbba1944', N'Flyer', N'40c5b314-71b6-4f7d-93f3-e445ede15e3b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'16d4d5c9-54fa-453d-8ee6-42209c567001', N'Mulsanne', N'49d0c5c3-edca-4af4-8f5c-78fd3c8ed045')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'16f8d059-f133-4ea7-b621-0f67795f1bff', N'Pilot', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'16f9ea7a-3c55-4a0c-b330-768cf2b77746', N'Phedra', N'69028d61-d882-4d03-8248-3baa2bbbbe8e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1758ff7f-9dbc-4d22-bf02-ac8a2897f35d', N'Teramont', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'179c8b99-e17b-4263-a15e-4e83a2a2a0a9', N'G', N'389c609f-88a4-4cf5-83fa-254494750ef5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'17f1a5c6-cd0e-473b-8ad7-3867eff3c7db', N'E-klasse', N'f3113047-cd76-4253-9202-7d61b65aece5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'185ca0f8-e2a7-458d-a1be-0dc759c07976', N'Pegasus', N'72cc10f3-daa0-40c6-9f4e-cdad4277b13a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'18757ec8-d76f-49fd-8970-2d4ebe6c115a', N'Envision', N'905f0904-5f99-4106-8df8-5f7378bbfcfc')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'18968552-6b34-4e73-97d4-0e18fb984a57', N'Aquila', N'b4231ec5-38f6-49a3-ab06-0cd7d317d319')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'18bed6e9-d979-45d8-a24a-5ba2675c499f', N'H6', N'0c253184-896b-48b3-b169-471e25fd7e33')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'19163749-963f-41f1-a5c6-d0ee4d821f51', N'Lacetti', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'192a4b9f-b697-4677-9b45-7d49c0b8d579', N'Tucson', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'193bfc59-3119-47a8-9dcf-a88af09e63ed', N'AD', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'193e7ae1-4be1-406a-9411-63af1b8f40d5', N'405', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'193edd2d-ad7a-41c2-b637-9cbe08c4441d', N'Forester', N'69e3fd0f-f18c-45a7-9b61-32b2781fd652')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'19838448-790a-434f-9acd-da5b8aafd312', N'Vectra', N'34766825-53a8-4663-b280-6a7a8ef4d695')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'19b66166-dd63-406f-94ec-c6cf69119cd2', N'Roadster', N'daff5fdd-b27e-4c5a-84d8-6f008cdebd9f')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'19c885c1-3975-4018-a024-04a097f2294f', N'Dart', N'b43b29a9-866d-4d88-b02d-1b114bdc6d3a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'19d3481a-4b2a-426a-917a-0e8b57e9ae7b', N'Quest', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1a1bb563-e021-49c7-ade1-0450548d51ab', N'M-klasse', N'f3113047-cd76-4253-9202-7d61b65aece5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1ae5f551-018f-41b2-a2b9-b1ec36aa1460', N'Traverse', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1b54f27f-e774-457d-9ce6-fef8c0be6b9f', N'Galant', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1b5ca59a-1e67-4eb1-ac0d-1eba380cbe65', N'C61', N'5286a8dc-ae0c-45e4-9cca-d1ab9e339b8d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1bfac101-6f06-4bf9-a2a6-9a682c2b75bc', N'Visto', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1c299dd9-15ed-4417-9349-1ead438992e4', N'MC', N'58fc5b57-330e-446f-be55-a6a11e237d49')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1c7e3d6f-3047-48f4-a3d0-b0f1e70680f6', N'R4', N'acf4fa9c-78fc-4751-ae5e-58cced695daf')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1c980164-3f97-42f6-804d-cc961736f432', N'Kuga', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1c990c6d-5c94-4667-96c7-e43d6a65aefa', N'Jinn', N'a66c5dc2-f532-41d6-bcee-d5af30599012')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1cb17a2b-eddb-4095-ab27-554b4ba6709e', N'Spark', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1cb6439a-84f4-4860-8303-78bfa9fdb5ca', N'Roadster', N'35c14e38-3759-4034-8103-17c1d0a3c45e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1ce31536-f089-4aaa-8b64-e8085001e130', N'GLC', N'f3113047-cd76-4253-9202-7d61b65aece5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1d05ac01-5c8e-4b14-ac69-89814ef253fe', N'GL8', N'905f0904-5f99-4106-8df8-5f7378bbfcfc')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1d1f5821-5ed2-4d73-8aaa-6ff004e76cd5', N'CSX', N'edcae123-7e98-4f7b-bbb0-d76306ea4d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1d5b9e09-63e8-49d7-b34a-6eb348c94437', N'Sonic', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1de0e5fe-2ee6-481f-81a3-8f8ad21526a6', N'Scudo', N'14c02a8f-81b0-4a5b-b191-d983aec6fab1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1debf410-2ee3-4231-9ff9-2d27c17e945a', N'FR-S', N'73f94dd1-9da3-413f-9d2b-2b7f0486d625')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1e38bd58-6f6a-4eb2-a811-8f4f65cd5061', N'Coupe', N'8a5f841d-f86a-4f7e-9cd2-c5ff5104bac8')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1e678e0f-79b6-4a4c-bc99-6c5d0133eb17', N'XLR', N'7f828726-e39d-48ba-b140-cbcffb570f89')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1e6fdca1-6b1d-4177-b7cd-6a27c9955d47', N'4008', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1e861742-9511-471c-8dc4-3dbd38678c50', N'3', N'f9d7aa29-6791-40f0-ab49-03c6378d67b8')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1ed8d955-91cd-4a40-beb1-db6589083237', N'Lacetti', N'8d78b1b2-490e-4082-829d-47dc3e93406b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1f3e4830-6ab0-49de-9612-40fcf1ea2a29', N'Palio', N'14c02a8f-81b0-4a5b-b191-d983aec6fab1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1f54485c-7a6b-4f2c-bc7b-59549c8bb601', N'X60', N'19c80c17-0c84-484b-9b83-59e5e4bed901')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1f81780a-668f-4ef7-a610-7c9da7bc690d', N'Pajero', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1f864371-db76-4686-8817-24cea7e23f4c', N'Stream', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1fd3c137-5765-4595-8872-8c8c06be7bba', N'Quoris', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'1ffd03cd-ab05-4e2e-8b3d-fa537e220865', N'C-Triomphe', N'6f581d7e-2891-4f4f-bbde-d4a93fea8642')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'202b0072-41a0-48b7-9fce-993908237bc9', N'SL-klasse', N'f3113047-cd76-4253-9202-7d61b65aece5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2039883e-123c-4977-aa99-bdc24d00a7c3', N'Terrain', N'1f2c1ee7-e902-4ce5-af78-db989fa87e6b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'207eba3e-a78a-422b-b441-eab8104101c1', N'Tahoe', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'208a3949-0ef7-429e-b8b3-65354a03fdf7', N'Q30', N'389c609f-88a4-4cf5-83fa-254494750ef5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'21931abd-def7-47f8-bd2b-a438608f2e04', N'Presage', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'21d48f85-1d84-49bb-9d71-c4970086c801', N'Legend', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'21e4f1c5-d57c-472f-83e7-aecae6a61905', N'XLV', N'2e3d2ec9-e633-48c4-9414-02d86f7179bf')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'220ea3c9-2738-4d48-a30e-06855a2c3943', N'HS', N'fdda3ac0-16db-45de-9950-13429f9971e3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'22329316-ec0b-45fc-9f02-9bad4622b399', N'G4', N'650dd48c-6055-4ef5-a6ce-fdb2b8004110')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'227c58de-95e1-432e-b163-345cd93a9e6a', N'AeroMax', N'35c14e38-3759-4034-8103-17c1d0a3c45e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'22a9cdc1-b89f-473b-8ad5-e744837db9f9', N'GranTurismo', N'68b81e8d-38c9-4b25-843c-40464738f496')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'22f193b0-25ce-4e5d-a98d-5fb8d478df20', N'X6', N'4391872d-6c69-4727-9016-182f58949458')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'23084324-c1c1-42b2-a6a8-cc5f61db2535', N'CTS', N'7f828726-e39d-48ba-b140-cbcffb570f89')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'23299e5f-8b0b-4b38-a0e7-0d8b2a62c777', N'MU-7', N'ffed9373-9b26-47d7-82ca-8564db8fbd20')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'23455d9a-fa5c-47b7-bd63-e79774d93c6a', N'Exeo', N'83d16608-e410-44bc-986e-13ac3e40b61c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'234cf1c9-292c-41f8-ba74-6f8e8ddc329e', N'Disco', N'b76437ce-50b6-470a-99f2-8aa6af492aa5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2356be74-d1a2-4712-a8a0-616640b1435b', N'Cygnet', N'2cd71503-5bcd-4f65-baf1-14e1b01d845b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'23cc4d83-f946-4801-b455-468384023c27', N'CSR', N'8f57b136-b51b-4a97-9818-3023ca41ec02')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'23d6dcb3-15a1-4f17-b3d0-ff9d7ee70a6d', N'Carens', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'24599a8f-bad5-4207-bb85-a02dfe774694', N'Flair', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2460d563-244f-4d78-a54f-9443cad38fc9', N'DB9', N'2cd71503-5bcd-4f65-baf1-14e1b01d845b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'24a21e93-71b9-420b-b020-173f1742bc00', N'N-BOX', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'259a9f74-ce4e-44c9-b078-a4291019e018', N'S5', N'06eb49e7-5aba-486c-b84e-37ef8441ae9d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2629b53a-c647-476b-8f74-b7206006e35c', N'Almera', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'269772b8-67ac-4562-94ce-52bb9d6fb112', N'Roadster', N'50cf2df6-8aaf-491a-bd63-77d627eb2fb1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'26b6c784-44f4-49c3-a799-9880148bc28d', N'Megane', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'26bec675-40a7-42d1-beef-c88577b84c8e', N'Vito', N'f3113047-cd76-4253-9202-7d61b65aece5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'26d7aa14-3057-4918-985a-f0cb6903db7a', N'Waja', N'3d95e465-7b8e-47cf-99e8-f2e6f90828a0')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'26d8c564-0314-42d4-b661-d6fde59e16a0', N'Passo', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'26ddd6ea-40c5-4c8a-a3dd-4e9c791350b8', N'Aspen', N'88242ad7-6c82-4609-9f14-04f7f7c5ff38')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'26f74249-1186-46b6-9b09-e1efdd968e15', N'Plutus', N'5aa91d17-cb4f-4418-aedc-edb01dae43ac')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'27497120-ee8e-495a-a35e-b423bae7111f', N'2111', N'cf259200-2168-44f6-9cbe-a1da81f82c64')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'274a5004-1389-43e1-9694-3548508e9712', N'Jimny', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2796562a-d550-485e-91c5-c97aff193b21', N'Magentis', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'27c64059-9ac5-48d1-ba66-6cd1848097ef', N'Verso', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'27c8749b-b9f1-4465-ac27-efb08493d9cc', N'Rapide', N'2cd71503-5bcd-4f65-baf1-14e1b01d845b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2816afaa-7110-4bb9-aab7-70d9f7e23e07', N'Econoline', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'282e88b4-ae59-4a13-9db3-6db6b05a7412', N'H8', N'0c253184-896b-48b3-b169-471e25fd7e33')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'286c872f-f283-493e-9bfd-70e289332d9c', N'Fuga', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'28f14d4e-def4-4c6d-b489-f090b7c44955', N'Fortuner', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2909fe66-4191-4dd1-97eb-431547a4f684', N'XK', N'c1a9c207-b6e3-4ecc-a497-5c8cb74e3f9d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'292a445b-cbfb-4c8f-9cce-ccdd347ea045', N'Egoista', N'10481089-df33-4439-b1c0-4e29cbc277d0')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'29312285-8ffe-46e6-827a-7bf2e5a35112', N'Venza', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2960b2b1-c29c-42cb-8877-fdb973a569e7', N'Cedric', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2969240b-7598-4b82-985e-f7473dcc039a', N'GO+', N'356e1a07-d2d2-4e49-b14d-7381e3a493e3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'29841e27-f6d4-4953-9354-2e9f22e3e72d', N'iQ', N'73f94dd1-9da3-413f-9d2b-2b7f0486d625')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2a5ba9d5-cc99-400f-be03-7a38703a7cc9', N'Discovery', N'c5fb28b0-9e14-47d8-bd6d-c2c596fbc395')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2a96fb7a-57cb-4a78-a409-f284627b57b4', N'Grandeur', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2ba460aa-2c5f-4ab5-a6b1-67fe7a5e4438', N'Nitro', N'b43b29a9-866d-4d88-b02d-1b114bdc6d3a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2bc088cc-a1f6-41fd-a4bc-1505d16cdeee', N'Kei', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2cb604b4-4abb-41e3-80e4-d03e212e9531', N'C12', N'70b89f75-adf7-4e1f-9095-5764bc1a2f74')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2cb63ead-39b7-4918-b41d-f6eaa4519937', N'XTS', N'7f828726-e39d-48ba-b140-cbcffb570f89')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2cbe193d-f942-43df-ba37-dc049b6b6049', N'C32', N'5286a8dc-ae0c-45e4-9cca-d1ab9e339b8d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2ce94cb8-f906-498d-9725-f7f387ca8660', N'6er', N'b6c521f7-196b-4e8a-ae22-77b8005cfa92')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2d4a035a-2d49-4abf-a3ba-616de4805b31', N'GD04B', N'155d4648-5e6e-4e72-bae8-07ca283d48bb')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2d7e5755-0f13-4780-9857-1d53cab0e345', N'eK', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2e0b6d85-5a29-4907-8bcf-59153697d924', N'350Z', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2e327c81-e42d-4e2a-9c71-76e2a3b89088', N'HMMWV', N'79eb1543-8244-48e1-908a-7778574b4cd7')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2e6d9b15-559b-4d43-b168-48dff9fc188f', N'Dakota', N'b43b29a9-866d-4d88-b02d-1b114bdc6d3a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2e75c6fd-34ac-421e-97a3-43b715c4b900', N'Countryman', N'8a5f841d-f86a-4f7e-9cd2-c5ff5104bac8')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2ec209da-fe8a-4920-a031-64bb4586c614', N'Materia', N'8e27171b-9aa7-4082-930f-3ae388187d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2edef36e-047d-430e-a082-96c78cf1b738', N'159', N'b76437ce-50b6-470a-99f2-8aa6af492aa5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2f0ccf4d-1eae-4bf6-8727-ef1567050287', N'Galaxy', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2f551201-212c-4523-a660-25e5093689d6', N'Musa', N'69028d61-d882-4d03-8248-3baa2bbbbe8e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2f553dfd-5615-4f47-b63e-a709d06d67b3', N'ATS-V', N'7f828726-e39d-48ba-b140-cbcffb570f89')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2f626a86-052a-4b4e-83a3-56d52a8e3be8', N'Alza', N'68e7f8c1-ae77-491b-9cdf-bd1ff34a714e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2fa56997-19e2-48eb-8089-110777af3a2f', N'Triton', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2fb3822c-8991-4f65-9f1d-29a7e736b87b', N'4007', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2fd18f87-c669-4c05-a8b1-c2dfdf9f464e', N'California', N'5b74871c-cd56-4264-872e-3cf8a781c40d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'2ffcbbce-5738-4e6e-8d80-da1170414665', N'4er', N'b6c521f7-196b-4e8a-ae22-77b8005cfa92')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'30571623-5a08-4eab-af91-9a9d6a65ff5a', N'Roox', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'30de3b75-ed1a-409c-ae30-fd44d3cf2c2e', N'Touareg', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3106311e-f3f1-431c-85b5-229e5e34e5b2', N'Exiga', N'69e3fd0f-f18c-45a7-9b61-32b2781fd652')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'31494ad7-c323-4249-81ec-0445b65f221a', N'V70', N'23c344a0-d700-41e9-91a5-3cd4a9d9ef0c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'31544d0d-9645-442e-afe4-78e3d2e33680', N'RVR', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'315b0b7d-ba43-479d-9120-56449e1bad0a', N'ix35', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3185f0dd-eecf-46b1-a6a0-8e80b2604d6c', N'Hover', N'72cc10f3-daa0-40c6-9f4e-cdad4277b13a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'31e4b84b-4a96-4910-8708-c846b90c5806', N'Lucra', N'69e3fd0f-f18c-45a7-9b61-32b2781fd652')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'31f5c8c1-9d2d-49a1-8562-69e2b88fa17f', N'Serena', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'322c0a57-a053-4878-8f25-bbc0e4be8dbc', N'800', N'd187a531-c710-4495-bb5c-d158f7d0aad0')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'323f952c-f2c6-4f21-bcf9-30986a645a47', N'Voleex', N'72cc10f3-daa0-40c6-9f4e-cdad4277b13a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3244fc70-ef36-4034-b70f-991952dbad1e', N'Vibe', N'650dd48c-6055-4ef5-a6ce-fdb2b8004110')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'32603780-dd27-4044-ab0d-a39eac645eb7', N'HiAce', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3299fbcc-24c5-450e-be0a-01401e7de63f', N'Priora', N'cf259200-2168-44f6-9cbe-a1da81f82c64')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'33150a6a-cc0b-4c74-8ad4-4d2d5f77a670', N'Scrum', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'337f2911-74e8-4325-9271-4fc40a095379', N'Murcielago', N'10481089-df33-4439-b1c0-4e29cbc277d0')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'338c6237-2209-4971-8f68-65602fadbb6b', N'Aqua', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'33b39f17-534d-420f-931c-e9418c451288', N'SUV', N'1c46d435-5577-4523-bc56-37947d08b623')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'33d26a38-7d33-4fdb-bca2-92302629220f', N'GLK-klasse', N'f3113047-cd76-4253-9202-7d61b65aece5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'33f6e368-7055-4e21-8a8f-ca82cb045008', N'Ascent', N'69e3fd0f-f18c-45a7-9b61-32b2781fd652')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3434393d-bf58-48de-aa23-e78fdbc37816', N'HR-V', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'347309d6-9a42-471a-ad47-dd4856a2f1fa', N'AZ-Offroad', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3481d345-f056-4dee-9a75-502a08b92162', N'CLS-klasse', N'f3113047-cd76-4253-9202-7d61b65aece5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'348ea036-a78f-46c8-9036-49f15337e827', N'9-7X', N'f2070ff6-7dd1-42e3-95c2-d8f992349b17')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'353a11c7-feb7-42e2-bcc6-686ea090905a', N'Avensis', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'353c4e8e-b364-46f7-8d66-fc413c9d9d95', N'Zafira', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3684cb34-30b7-4e1c-a2ed-6e7e1b97a269', N'Milan', N'd81d4572-3d43-4083-81f4-11dcea1fd1d5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'36a01bf5-c3ed-487d-9d6b-df534920ee77', N'S1', N'183e3eb0-fedf-419e-a103-71222e4ffae2')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'36eb4ea8-6cb5-4121-87a5-64f50853cca5', N'Kenari', N'68e7f8c1-ae77-491b-9cdf-bd1ff34a714e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'374eed87-0a88-4e1b-aa8f-d523c4728774', N'Q3', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'374f5a10-e9cc-4814-9efc-f03f5f31b445', N'Beetle', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'376e766e-dbe0-45cd-a479-62028fd2fb03', N'IONIQ', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'379f6d16-3344-4e6e-b605-e0be7582df5a', N'C1', N'6f581d7e-2891-4f4f-bbde-d4a93fea8642')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'37bae5b2-de9b-4a6c-9c99-4e34879e2c0f', N'Ris', N'eb52a9e5-c2fd-47d2-a12d-d1466153d7e2')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'38119398-f8a4-4593-a005-aa32671bf22d', N'Silverado', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'38a1ab2a-f50b-4657-a65e-23d28c3e35dd', N'Belta', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'390eb976-7f23-413a-ac8d-4f086087eb26', N'2110', N'cf259200-2168-44f6-9cbe-a1da81f82c64')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'39fa85be-ab79-4c43-88dc-6753fb0beffa', N'GC9', N'963548b9-5235-447e-81ac-ee61c43b7c91')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3a2ed931-582c-4a73-9cff-ede392ff5e6a', N'S60', N'23c344a0-d700-41e9-91a5-3cd4a9d9ef0c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3a3a40ce-597c-4b4d-ad8e-e4d2953e0db3', N'Mokka', N'34766825-53a8-4663-b280-6a7a8ef4d695')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3a525086-8d72-4fb9-823e-bdd653c2e6ac', N'Equinox', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3a594033-1c2f-40f6-9621-00abf198e290', N'Verisa', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3a76da7f-72f7-40a0-9b8c-4f1d1405d6c7', N'X-Trail', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3ae16890-0ee9-4fe0-8f61-555a2d2f401c', N'Siena', N'14c02a8f-81b0-4a5b-b191-d983aec6fab1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3b63a8e5-1c11-4dcd-97eb-fb4c0d6badab', N'Octavia', N'8ee43737-d062-4d88-90c1-3a28a6d36632')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3b72afd4-d266-40b0-bf66-5c43ca1c06ca', N'C5', N'6f581d7e-2891-4f4f-bbde-d4a93fea8642')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3b76d852-9bd5-4b96-938b-706c48af4097', N'Meriva', N'34766825-53a8-4663-b280-6a7a8ef4d695')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3b9afd10-75f9-4735-bc90-38af5145479d', N'Hover', N'72cc10f3-daa0-40c6-9f4e-cdad4277b13a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3b9b558f-930d-46b0-b80e-cc663ecb11fa', N'Primera', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3b9d720c-cf89-402f-9f1a-9c0e2ee0fe11', N'BT-50', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3bb757de-4ff4-4d1e-b8ec-548fecba3889', N'H2', N'0c253184-896b-48b3-b169-471e25fd7e33')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3bbcfb9e-1cd2-4863-94a8-5e33cbd718ac', N'RDX', N'edcae123-7e98-4f7b-bbb0-d76306ea4d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3bf30131-4b14-4aaf-a524-2fb1b1719a8b', N'Murman', N'19c80c17-0c84-484b-9b83-59e5e4bed901')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3bf51136-dece-4e9f-afbd-8acdb28eac45', N'Tramontana', N'6a70676e-0388-4237-86c7-65ba9a31e13b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3ce64145-4ed6-4b52-978c-806445580e66', N'Range', N'c5fb28b0-9e14-47d8-bd6d-c2c596fbc395')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3d516fa9-cf6b-40d7-9d5f-3463ae957772', N'Trajet', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3dd362ff-e695-4361-babe-36b0dd73e37a', N'A7', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3dd4a02f-4e06-40fb-b5a7-dbf52cf662b8', N'GLS-klasse', N'f3113047-cd76-4253-9202-7d61b65aece5')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3dda41a2-f609-4092-9de6-d702e7b732f5', N'Toppo', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3df5186c-49b5-4594-bf87-495453ae8a09', N'2', N'06eb49e7-5aba-486c-b84e-37ef8441ae9d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3df63def-8799-4906-9e44-05b6a463d278', N'Fluence', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3e3a4a73-8b1f-452c-bde4-ebf96b1b8a7e', N'SLC-klasse', N'f3113047-cd76-4253-9202-7d61b65aece5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3e466dac-1ed4-4617-b12c-c118cee03886', N'Ypsilon', N'69028d61-d882-4d03-8248-3baa2bbbbe8e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3e489508-b74d-4ae5-a0b4-98dbf8fba90a', N'Insignia', N'34766825-53a8-4663-b280-6a7a8ef4d695')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3e639adf-7401-4366-b2e1-6929360c54c0', N'D-Max', N'ffed9373-9b26-47d7-82ca-8564db8fbd20')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3e7821db-ff96-4e2a-afab-51d538e25d43', N'S660', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3ebe2f58-4950-43f3-83b2-38d86da43c92', N'M3', N'b6c521f7-196b-4e8a-ae22-77b8005cfa92')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3f1b2b82-898f-45f8-8152-ebbf9d6991c8', N'370', N'f05c93a2-86b0-48c2-8f10-e9b83c66435c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3f509239-4e6a-466d-8586-66cd99a5a1a1', N'Crown', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3f6d7c81-e1d9-4ef6-a071-5f713deed9c6', N'GT86', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3f850940-bf0c-479a-bc4c-ded06fc3acb3', N'Sigma', N'8adcfe2e-2baf-4545-b88a-d1fd96c97d9e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3fa9ca36-a580-496e-828a-1f1c05e5dbf6', N'MKC', N'a90381f4-56aa-4c45-99dc-22346ed3bb1f')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3fe433cc-4801-473e-a556-4739e52e53ad', N'Hover', N'72cc10f3-daa0-40c6-9f4e-cdad4277b13a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3fe4aaeb-c5c3-42ad-a258-efe4e89c28ba', N'Jumpy', N'6f581d7e-2891-4f4f-bbde-d4a93fea8642')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'3ff9cc59-bc47-4849-ba06-9477d94b2bcb', N'Impreza', N'69e3fd0f-f18c-45a7-9b61-32b2781fd652')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'40072565-b21f-4d15-bb70-17646e4766c9', N'Caddy', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'400a3171-a97c-4238-a403-1347b8ceaa8e', N'Damas', N'8d78b1b2-490e-4082-829d-47dc3e93406b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'400c8ef5-ccdf-4d2b-9c6b-fbba7cf87dff', N'CT', N'fdda3ac0-16db-45de-9950-13429f9971e3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'40186a29-541d-479b-8316-3d417b2df49e', N'Bolt', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'40724f3d-15f4-4241-877a-f200dd9248c5', N'A5', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4075f114-064a-4dd1-adf2-7a88c755a884', N'Nubira', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'408c4dc3-7f14-4126-82df-aaf89d66d625', N'Airtrek', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'40b22fa8-5c39-4f43-87c3-f1ad1b05989a', N'Sandero', N'2ccadfdd-4823-4132-9942-e216de777f5f')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'40b4634f-f046-457b-aecf-74a89d60a34d', N'Zonda', N'ba930a52-2bcf-45e4-8752-9878caab2ece')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'40e597e7-38fb-439e-bd12-0d39fc8883d8', N'469', N'6ddef8be-f1d0-4b01-ae04-9aff95e4e0ac')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'40faafb9-a3e8-49b1-a129-3b893bcd6c40', N'Granta', N'cf259200-2168-44f6-9cbe-a1da81f82c64')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'41597c24-7816-41d9-9a2c-89fefa1b1221', N'Princip', N'8adcfe2e-2baf-4545-b88a-d1fd96c97d9e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4170662c-837f-44bd-82a6-4ec2dc58f50c', N'Tracker', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4174b4c1-694a-4ba7-a7ec-452bd5e9a35f', N'Tager', N'b4231ec5-38f6-49a3-ab06-0cd7d317d319')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'417fcd86-d973-497e-a26a-57dfeaf11846', N'Alto', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4187d110-0bb8-41a5-9611-71f2cf2a32a8', N'Malibu', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'41992052-5ecd-40fe-b8fd-4c3683650d18', N'Gentra', N'acf4fa9c-78fc-4751-ae5e-58cced695daf')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'41b7bd1e-5451-49eb-8961-98b155af9a64', N'CTS-V', N'7f828726-e39d-48ba-b140-cbcffb570f89')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4254ca10-432c-4371-a61d-9b1f3d73a695', N'DBS', N'2cd71503-5bcd-4f65-baf1-14e1b01d845b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'426bf94a-c171-46f2-b27d-939667ae684a', N'Z100', N'8361f87b-18ee-4fac-96e3-5f8fd2c6123d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'42c4a37f-99a5-42cf-93b0-6bba8209b410', N'Vitara', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'42efb63b-d66f-4424-91d3-f85c9efa6f64', N'Wraith', N'88629d81-57ca-43ce-a44a-08d351fd95d5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'42f1adcc-9853-45db-99d6-2f46caac9bfd', N'Qute', N'c5117863-8cee-4645-b769-714f2f262f9f')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4324e443-7492-42d3-95b8-3bd7d4cc9cbb', N'Gen-2', N'3d95e465-7b8e-47cf-99e8-f2e6f90828a0')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'43364dd6-f63b-469e-961b-4a8b35cbf900', N'S30', N'f05c93a2-86b0-48c2-8f10-e9b83c66435c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4341d751-c2c9-486b-934a-f6cf52e6b5ff', N'Kalina', N'cf259200-2168-44f6-9cbe-a1da81f82c64')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4351cd4a-f859-4228-bb69-cb7134fe8e9b', N'Rush', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4364fe9c-28a1-41c2-a248-8dc6a67fb99c', N'Caravan', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'437d5841-3d90-4114-8c95-12129764435f', N'NSX', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'43ad81e9-654c-4492-9a05-e2d40459e330', N'HuracA?n', N'10481089-df33-4439-b1c0-4e29cbc277d0')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'43b6195f-8de9-40ea-ba9b-e62ba1a4af85', N'3', N'19bdb5ae-b06b-4de4-a472-35af19deb085')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'43c0b372-4865-408d-b5d4-3d5c196b0fa9', N'G2X', N'8d78b1b2-490e-4082-829d-47dc3e93406b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'43c6243d-7568-4f8b-be1e-c12c7a0a994e', N'Matiz', N'acf4fa9c-78fc-4751-ae5e-58cced695daf')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'43e76a07-20bc-42be-a047-b3546604e7ad', N'Prius', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'43eb4b8d-e391-4831-aaa9-ec9e1051c18e', N'Aurora', N'5aa91d17-cb4f-4418-aedc-edb01dae43ac')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'43f276ea-f161-4b29-9b57-4f05bd85da8b', N'C70', N'23c344a0-d700-41e9-91a5-3cd4a9d9ef0c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4423c664-9600-4ced-b1f5-2e725444d24f', N'Coupe', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4434ecd2-6c61-403a-ba6e-e464c3d3140c', N'Cerato', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'44602b78-5654-4eda-bf2f-2fed7200c803', N'5EXi', N'b32970fd-c6ff-4b5f-b9ca-1df5ef065c9f')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'450ae8b4-542a-4deb-afbd-3e32158b3371', N'Renegade', N'eeb274f8-38af-47c5-8d1e-bce37166c0cd')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'456f2987-d9e3-4972-be09-a678e6140ce2', N'Yaris', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'45dc51ed-0506-4e63-bd3b-886f41614324', N'Montero', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'45e3b34a-66df-4f5e-a61b-65735b615e21', N'Wind', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'461d3b90-a441-44b9-8be7-42dbbac50c83', N'Matiz', N'8d78b1b2-490e-4082-829d-47dc3e93406b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'47b7e10c-01d2-4959-aeb8-e212ba6218d0', N'AX7', N'f05c93a2-86b0-48c2-8f10-e9b83c66435c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4850db9c-2ad8-4513-b926-3fb8cb544790', N'Ist', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'486f7984-b983-4aef-afd0-3bb5a6da5dc5', N'X5', N'4391872d-6c69-4727-9016-182f58949458')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'486fb6e5-c7d9-496b-98a6-4fa3dc2c2292', N'Trezia', N'69e3fd0f-f18c-45a7-9b61-32b2781fd652')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4891a4b5-18d0-448f-af0d-3660d06a0aba', N'Peri', N'72cc10f3-daa0-40c6-9f4e-cdad4277b13a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'489c7dda-c1c4-45de-9918-b700b49163f7', N'Cobra', N'8e632fa6-8afd-4c1e-8161-76b5c4257c2a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'48aadf9f-1702-4cd8-91d6-631798b3338e', N'G5', N'650dd48c-6055-4ef5-a6ce-fdb2b8004110')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'48c7fbc1-eaf8-4c5f-9239-a94bbe18f99d', N'Crosstour', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'498255dd-5d01-4cd2-9102-2d16601db2eb', N'Spider', N'b76437ce-50b6-470a-99f2-8aa6af492aa5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'49b8227a-36b1-4b6b-a801-95e7186a2327', N'Escalade', N'7f828726-e39d-48ba-b140-cbcffb570f89')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'49ffcf8d-ed10-4927-a17e-8fff2945894f', N'Cherokee', N'eeb274f8-38af-47c5-8d1e-bce37166c0cd')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4a48dc02-8822-45a0-97ee-0282de832253', N'ix55', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4a670a46-5e22-41be-9d01-3627a23f1fd2', N'Forward', N'4391872d-6c69-4727-9016-182f58949458')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4ad83dc0-45dd-40ed-a21e-673776a1d215', N'F6', N'40c5b314-71b6-4f7d-93f3-e445ede15e3b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4b30b723-ffc8-4bcb-872a-05ddaf5cb004', N'Getz', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4b8928e2-6631-4f6a-b90e-35e45e83c36b', N'108', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4bad5fbb-38ce-4282-9ff9-71c0c7a28fa7', N'Xenon', N'3685ab0b-33d1-4903-bc78-1e0051a97beb')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4bbcb1b7-972e-4d35-ad5c-62ecb8beb6d9', N'Eado', N'1d77749a-b193-44ab-aeb2-a6fc0275ff40')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4bef1700-cf20-4605-b231-7326951ddb3b', N'Cabrio', N'8a5f841d-f86a-4f7e-9cd2-c5ff5104bac8')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4c00c79c-c40f-43b9-8b45-f00d4c60bbe3', N'Patriot', N'6ddef8be-f1d0-4b01-ae04-9aff95e4e0ac')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4c019431-1e9c-413a-b398-1a083ea50099', N'RC', N'fdda3ac0-16db-45de-9950-13429f9971e3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4c195d9d-deec-4129-8549-c38d1b137658', N'Sandero', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4c325ef2-792e-4c12-9ef0-3da431b857b7', N'Tiburon', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4c57eacc-9147-44c0-95d1-6b9b4bf4c7cc', N'X50', N'19c80c17-0c84-484b-9b83-59e5e4bed901')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4c84012d-30a3-4e5e-927d-5d49e76e17ab', N'Lafesta', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4cfd4a96-4f7d-4010-9e34-4d81cb39afe2', N'Levante', N'68b81e8d-38c9-4b25-843c-40464738f496')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4d2df7a8-7c09-4b98-b37c-934a46076b74', N'6', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4d3970ad-5b1b-49f4-b5e5-9590e1a346bd', N'Evora', N'2dec248f-e55c-4600-9684-f82040437771')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4d5857eb-0318-471f-b01e-f6b543591dd2', N'Astra', N'32c777b4-932a-41aa-b733-d7fa0dcc1008')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4db7a428-69f4-4a22-9d90-eb30c73e351c', N'Bentayga', N'49d0c5c3-edca-4af4-8f5c-78fd3c8ed045')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4df6b690-69e2-475b-ae79-3526250b0a61', N'Flavia', N'69028d61-d882-4d03-8248-3baa2bbbbe8e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4e2a254a-f149-4193-9858-694a3a48ecd0', N'KA', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4e5201ca-28f7-4959-a541-f963caa01185', N'Shuttle', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4e5c9f16-d59d-493c-b4a3-247b448e96e4', N'C52', N'5286a8dc-ae0c-45e4-9cca-d1ab9e339b8d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4e61a052-7cf5-41b5-aa60-95e2a4906c73', N'Freema', N'06eb49e7-5aba-486c-b84e-37ef8441ae9d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4e7d2031-1350-4f62-99a1-4e2d28541cf1', N'S8', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4e8104da-deb3-4012-806b-096811c28182', N'MiTo', N'b76437ce-50b6-470a-99f2-8aa6af492aa5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4ea64fc2-571f-4d18-b4aa-30b2d198e1a9', N'2717', N'cdc80d81-3c9e-4f16-abef-fcd466be500c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4eb6a793-d60c-4d90-b8ce-45773329e55e', N'Premio', N'02b02a48-0436-4539-b691-53ade2d22356')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4ebd92ab-2e31-4380-bba1-21764c052b53', N'Delica', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4fc1b13a-ec2b-4882-b08c-28a1a42db73a', N'Midi', N'7888c577-b80e-466a-a340-1f1d9b91541b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4fd31f1c-5b76-47f2-8844-2e4c2278d9e9', N'Signum', N'34766825-53a8-4663-b280-6a7a8ef4d695')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'4fe9df22-afc0-4262-9790-fc8c5215ed30', N'Phaeton', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'503af79d-c3d3-4701-828d-0c6fbf934ba3', N'Classic', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'505b8270-df56-4311-bb05-de030a8a8403', N'Latitude', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'508ff961-090f-41c8-aaa7-6843ed9194c3', N'X-Terra', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'50954f27-20af-4c4f-aa84-2241ccea1330', N'Tivoli', N'2e3d2ec9-e633-48c4-9414-02d86f7179bf')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'50a2ec83-f210-4f5f-ac61-6b90cdf8ec2d', N'FR-V', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'50a4e3ab-ffd7-409f-a067-ffa9470cdd9b', N'SR9', N'8361f87b-18ee-4fac-96e3-5f8fd2c6123d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'50dc61ea-eaa6-473c-8b2f-b7cd8cf6d8f3', N'ZOE', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5110011d-6243-4700-8356-0606a3887909', N'Florid', N'72cc10f3-daa0-40c6-9f4e-cdad4277b13a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'51a0c32c-2e3b-4766-bf43-9751ee8ccb04', N'X1', N'b6c521f7-196b-4e8a-ae22-77b8005cfa92')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'51b0fddc-68bb-4ca1-817c-c07ce0454dc6', N'Tribute', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5223c198-b454-4ea7-ae04-73f5164f4874', N'One1', N'e95bab32-1911-408e-b846-41bed318d406')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'52544d5f-0fb2-449e-9297-babb54c0994d', N'Mariner', N'd81d4572-3d43-4083-81f4-11dcea1fd1d5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'525deb88-5353-473f-8ac9-66f10bf704cb', N'Brio', N'8adcfe2e-2baf-4545-b88a-d1fd96c97d9e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'528c4571-9b15-4065-b584-8f30d012de18', N'C-ZERO', N'6f581d7e-2891-4f4f-bbde-d4a93fea8642')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'52bc734d-9fe8-4cb7-bc86-0a435eb92407', N'Arteon', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'52f02dbe-8b25-4a8c-8cc5-373061e8044b', N'S-Type', N'c1a9c207-b6e3-4ecc-a497-5c8cb74e3f9d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5324c194-baf3-44c1-a444-417822b36575', N'Everest', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5384dbe4-18cd-4ed5-b0fa-1a8b8570dfc4', N'Karoq', N'8ee43737-d062-4d88-90c1-3a28a6d36632')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'53a6d14c-597f-4cf1-b3a7-f6924cc0dfa5', N'Nouera', N'4a69ad3b-7286-4123-bf65-fcd4d56f07b8')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'53bff622-ddfc-430c-8c1c-4eca85da9b8c', N'5', N'19bdb5ae-b06b-4de4-a472-35af19deb085')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'541751e1-96f0-4be7-b818-58661fd0e640', N'Koleos', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'546d0804-1891-44e1-b9b2-cc4218d8d882', N'E-Pace', N'c1a9c207-b6e3-4ecc-a497-5c8cb74e3f9d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5472c148-5726-4c1a-b6f6-58d2f2ea2193', N'QM5', N'9d57f8a8-f924-413e-8e8a-dfaa13d7c93d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5485484a-1a5c-41d5-ab19-f3f88839c5dd', N'Benni', N'1d77749a-b193-44ab-aeb2-a6fc0275ff40')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'548ca468-fcc8-43dc-adc9-1415d86b53cc', N'Etios', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'54adb16b-776b-45bd-9def-4aa9ed196634', N'CX-8', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'54b3dd71-032e-476d-b5f8-d8e8b943cb9e', N'Regal', N'905f0904-5f99-4106-8df8-5f7378bbfcfc')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'54b84345-ad65-41dd-a4d7-ed071addbc31', N'G-klasse', N'f3113047-cd76-4253-9202-7d61b65aece5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'54dc4129-09e7-47e5-bbf5-f91b9e1e6977', N'Roadster', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'55c8e339-1416-4e22-9ab2-cf8b6b5806a3', N'Pino', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'55c96c75-ca12-40e7-a15f-f8c4555d0cdc', N'S7', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'55cdc081-7117-4e26-a8eb-a8cb14e75dd4', N'Outlook', N'32c777b4-932a-41aa-b733-d7fa0dcc1008')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'55e2a640-41fc-49c4-b9a1-fa20243cda8b', N'CS35', N'1d77749a-b193-44ab-aeb2-a6fc0275ff40')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'56457c4c-cc27-4d30-b81a-49cd1674ae16', N'Deer', N'72cc10f3-daa0-40c6-9f4e-cdad4277b13a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'567c3226-31bb-484a-80ae-d046512dcfb6', N'Citan', N'f3113047-cd76-4253-9202-7d61b65aece5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'568e5ee3-4499-4b13-b1ff-972a04abda49', N'3', N'06eb49e7-5aba-486c-b84e-37ef8441ae9d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'56fe20e9-cc9e-45c7-ae7c-39407e74ab27', N'DTS', N'7f828726-e39d-48ba-b140-cbcffb570f89')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'578933a1-cd32-4234-87f0-52af9bd66fcf', N'Maxcruz', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'57c2c13c-c868-42a4-bce8-597ead73d71d', N'Punto', N'14c02a8f-81b0-4a5b-b191-d983aec6fab1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'57fc932a-3c27-4007-9d8f-2eb67a6269d2', N'Colorado', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'58279fa4-dda8-4fb9-8b7a-6707f1fa7160', N'Grandis', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5851fa38-9eaa-4da9-aff2-cb419c44de98', N'Avalanche', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'585f8d88-f66f-4869-a59d-e81d1fd77ae7', N'FX', N'389c609f-88a4-4cf5-83fa-254494750ef5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'58a98b74-a20f-4bbf-b566-d9901ed6374e', N'Hunter', N'6ddef8be-f1d0-4b01-ae04-9aff95e4e0ac')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'58b8f1db-2164-433a-95c2-4f9de62cd55b', N'Pathfinder', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'58fc6192-58c6-4888-84c9-e66f8123a893', N'i40', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'593d7d1d-3151-4072-86ab-8d7ce52140cc', N'C-klasse', N'f3113047-cd76-4253-9202-7d61b65aece5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5a2fc45b-e6d6-421d-b66c-4ac49fbc6971', N'Corda', N'e3a23304-a5f5-4f66-9c3a-ec7490fbc764')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5a8a0df0-7609-430c-9a3f-826a906df7f5', N'V-klasse', N'f3113047-cd76-4253-9202-7d61b65aece5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5aa46413-3293-4bce-ba24-ea7a9f264d12', N'G90', N'07ff5590-8e45-4e10-83e9-95a946838fd3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5b25756b-3cb4-4598-a5b6-2f565b330f20', N'408', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5b600617-378f-4524-8232-7930083ede67', N'JX', N'389c609f-88a4-4cf5-83fa-254494750ef5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5b6d3d90-926c-45b9-94c9-93cf16352831', N'Minicab', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5bb74e01-0069-43ce-b6e3-1bbaa7377a5e', N'H530', N'21dba530-e719-455c-8af1-14b1f75309a8')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5be091e7-c1aa-4d3c-8260-10a557f21d7e', N'500X', N'14c02a8f-81b0-4a5b-b191-d983aec6fab1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5c115b4e-fef6-4eb4-beee-8dcc1b10dc2b', N'Viano', N'f3113047-cd76-4253-9202-7d61b65aece5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5c448a5c-728c-463c-9d62-7369b51f1c10', N'Fiorino', N'14c02a8f-81b0-4a5b-b191-d983aec6fab1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5c4c216b-504b-4bc5-b306-16b7726b8e41', N'Matrix', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5c933757-40b2-44df-b1b8-7e8a9c236b51', N'Wingroad', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5ccc4950-ce58-4ab0-ac0f-092173283486', N'Lancer', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5d2d33dd-0af0-4723-a0c8-911a6b06c006', N'up!', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5d53f92c-8ccf-479a-9035-fa7360d8d1a8', N'Tiguan', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5d55bc0f-d602-47db-b04d-b5d0c4301091', N'V90', N'23c344a0-d700-41e9-91a5-3cd4a9d9ef0c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5db9a390-bae7-42e7-828c-a05a59019239', N'MW', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5dcaed61-258a-4cc8-a591-5e8fc2c93d9a', N'C6', N'6f581d7e-2891-4f4f-bbde-d4a93fea8642')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5de58481-c149-4167-b10e-0688fdf51344', N'President', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5e7ad792-3b63-447d-8d0f-271dfb4aa615', N'xB', N'73f94dd1-9da3-413f-9d2b-2b7f0486d625')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5e845541-0345-4e28-a7ea-d35a0e2fe874', N'Latio', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5e9d6e16-af2f-4ebe-ab5f-14a992986fa4', N'570GT', N'54ee342d-5260-4e91-a6b3-310715065bb3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5ebc438a-c2d2-4a2f-a64d-e1f26f90cb62', N'Tacuma', N'8d78b1b2-490e-4082-829d-47dc3e93406b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5eda5537-3b04-47ec-93da-81a02cbb3a95', N'308', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5efbd715-3a88-4e9e-bae8-dab53339c11a', N'Freelander', N'c5fb28b0-9e14-47d8-bd6d-c2c596fbc395')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5f22c40a-ff1e-4e7a-85bc-672d6362a315', N'5', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5f2a1d1f-75ed-4074-a449-4082a8caed50', N'Bongo', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5f7b429c-1057-425a-b0d4-cfc331375222', N'Duster', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5f9933db-6ec3-4f47-9b84-1dec08e17579', N'S3', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5faa3c66-26be-4316-bb8d-05b1e2eadb61', N'CX-5', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5fad90a2-e038-4956-ab11-40bdec0071ca', N'California', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'5ffd111e-63c5-497f-b1a7-3828e992641c', N'T-Roc', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'60015450-4ffe-427c-8521-c140b7aa32d9', N'508', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'60214e2a-c7e0-4e2c-b9bd-4212cc68af7a', N'Scorpio', N'7c37d988-d24e-45d4-aca0-0fdc66615efa')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'605aa93f-c1b8-45cf-8f47-1b79e908e5f1', N'5', N'b5a7ddcd-46af-4470-a0ea-ff57f8aace5e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6072de84-a154-44a6-9fa4-dba5da9e330d', N'147', N'b76437ce-50b6-470a-99f2-8aa6af492aa5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'60be5fef-53c8-47c8-b90a-c23c37fe1b09', N'Polo', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'612b8e3c-382c-4639-9486-3349a327f1d8', N'Allion', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6137a1a3-f85a-435c-b9a0-9e44bc29a8fb', N'57', N'41f521a5-bf5f-44fe-8cb1-1e41ceb3ddef')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6139328f-e614-4854-8626-66ae737e464a', N'Dex', N'69e3fd0f-f18c-45a7-9b61-32b2781fd652')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'614de874-c15d-4247-8c4c-afd67678c4c8', N'Optima', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'618ac53b-9700-4931-b2e6-fc61d79066b5', N'Fusion', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'61d3ba7a-6015-4bac-8052-1cb0d1291eba', N'Avenger', N'b43b29a9-866d-4d88-b02d-1b114bdc6d3a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'61f09a5e-bb57-4e33-a0ed-1688ecfb8398', N'C-Elysee', N'6f581d7e-2891-4f4f-bbde-d4a93fea8642')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6244f8ce-4b77-455a-bddb-4c030342760d', N'Hover', N'72cc10f3-daa0-40c6-9f4e-cdad4277b13a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'62a7046f-de0e-4796-8c44-ab7d91ebb714', N'Enclave', N'905f0904-5f99-4106-8df8-5f7378bbfcfc')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'62c6acf6-8051-437f-bc32-9c904dc6baf2', N'Hover', N'72cc10f3-daa0-40c6-9f4e-cdad4277b13a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'62e6d460-4f70-48d5-9fb0-a8a66d1eb228', N'Roadster', N'8a5f841d-f86a-4f7e-9cd2-c5ff5104bac8')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'633695f9-5fcf-42a3-96e0-f31946dd2ec7', N'Atom', N'13722633-e48b-42f9-b7b8-5ee21e241b3e')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'63bc37c6-3c33-4055-8d00-a5f64253992e', N'Idea', N'14c02a8f-81b0-4a5b-b191-d983aec6fab1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'63d117f0-c743-4a8d-8ced-22cb42659d0c', N'Alaskan', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'63d7c38b-31b8-420d-b898-f65ab893ea30', N'Cordoba', N'83d16608-e410-44bc-986e-13ac3e40b61c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'643be0a5-c8ad-4649-a6df-aa26b0e76d44', N'2121', N'cf259200-2168-44f6-9cbe-a1da81f82c64')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'649427ad-16d9-47f8-8e65-a9d41b84bb6c', N'F430', N'5b74871c-cd56-4264-872e-3cf8a781c40d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'64f53184-81b1-40b4-98bc-498be11f8f89', N'M2', N'b6c521f7-196b-4e8a-ae22-77b8005cfa92')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'64f61817-8d19-4fbe-a06d-f7362634f4b1', N'DB11', N'2cd71503-5bcd-4f65-baf1-14e1b01d845b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'65dfe7bf-36ed-499e-8fb6-dc073b33f34d', N'DS3', N'6f581d7e-2891-4f4f-bbde-d4a93fea8642')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6607771d-2e1a-4a88-bdfc-e9e8b6c6c8a4', N'Fullback', N'14c02a8f-81b0-4a5b-b191-d983aec6fab1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'660b1ee5-be2e-4f1d-b811-f066cfc6ff9d', N'Alpheon', N'8d78b1b2-490e-4082-829d-47dc3e93406b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'663f2bfe-7bbd-43c2-9500-e95b508b3470', N'GLE', N'f3113047-cd76-4253-9202-7d61b65aece5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'66475ba0-d9a1-44ec-b1f2-fe07ab2fe055', N'Rezzo', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'665fc1b9-7139-4723-82f2-a565950f3674', N'Viper', N'b43b29a9-866d-4d88-b02d-1b114bdc6d3a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6672c182-6839-4694-9245-58006cd10663', N'Golf', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'674bc0bd-af14-4879-bb9d-64b20c3b9a67', N'XE', N'c1a9c207-b6e3-4ecc-a497-5c8cb74e3f9d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'67aa9c51-f142-43e5-aad5-879c57a66204', N'44', N'35c14e38-3759-4034-8103-17c1d0a3c45e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'67ca9bee-d909-4696-ab61-0cd3e8380d68', N'L3', N'40c5b314-71b6-4f7d-93f3-e445ede15e3b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'682b81cd-1ba8-4b44-999b-ed0c296f3cd1', N'Parati', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'683dd380-4cbf-4ae9-b9b9-5039a46a3638', N'S-MAX', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'68469ea3-b1fc-4172-9928-c8a099e64a75', N'S2000', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6872a321-2872-4627-bd72-c6bf69b35082', N'TT', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'689cef89-5581-497d-9521-3415f8e97c31', N'Fit', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'68c21b67-52b1-47f1-b7e1-96cebb190492', N'Solaris', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'693df080-5556-4074-ac1a-9f3c5b0ab0d5', N'Beast', N'20684ca8-f4b8-4bf9-b2a9-c3a2163eed92')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'69465d6e-b666-4869-bf21-a6f642e8c9ac', N'H9', N'0c253184-896b-48b3-b169-471e25fd7e33')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6963bbdb-621b-44b0-a781-108eafdd0607', N'XT5', N'7f828726-e39d-48ba-b140-cbcffb570f89')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6983a4cc-4204-4e1b-bd80-7edf2eee91fa', N'Veracruz', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6987178f-5160-40d1-8305-6c191f0ca012', N'Transporter', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6a92bef9-e8af-48d2-a3d6-1b26425eaf74', N'M5', N'd31cdc50-1d05-476d-9aea-9fe14dd18fcf')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6aa59ff0-53c0-4298-8b6f-cbd8cd22c05e', N'Traveller', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6b3924cf-e145-45bc-a0f0-f542c0862d99', N'Montana', N'650dd48c-6055-4ef5-a6ce-fdb2b8004110')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6b710c2c-361b-41f2-b3bc-ece15284791c', N'Q7', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6b99f6ef-0680-4794-aeac-07b9f69bdb7f', N'F8C', N'58fc5b57-330e-446f-be55-a6a11e237d49')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6c279099-203b-41b8-94bc-4c7432208189', N'Swift', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6c371f6b-d209-4ce0-8421-bbdb95322798', N'EX', N'389c609f-88a4-4cf5-83fa-254494750ef5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6c4bcbcc-504f-4eef-a6b8-42411a58851e', N'LS', N'fdda3ac0-16db-45de-9950-13429f9971e3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6c5f82f1-d964-4641-bb32-01a8c3f69a46', N'Creta', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6c9d201a-8e23-42fe-b329-3a3237ce6a48', N'MPV', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6ccf9800-5366-416f-85d7-db01938e11a3', N'UTE', N'e46ed379-206c-461a-87a3-408ca7998273')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6cd54dc1-13df-4446-8a71-03e2ea47b34f', N'Stinger', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6cd90e79-53f1-47d4-ad10-a9784577e506', N'Landscape', N'362f25ad-010a-4ee5-8e60-3a7e0d2a3e03')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6cf1743b-1eb0-434b-8f5b-3135e54dcffe', N'Indigo', N'3685ab0b-33d1-4903-bc78-1e0051a97beb')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6d593354-2f8b-4065-9d56-a82748889157', N'Alhambra', N'83d16608-e410-44bc-986e-13ac3e40b61c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6da2ce42-bf4e-454d-875a-47f057613c45', N'Picnic', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6e1a89f7-1906-40b2-9a3b-c636c4363b3f', N'Flex', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6e88391f-9382-4e5c-923e-753f45c6f9d0', N'Chiron', N'3f6d7226-fac9-4d44-b348-658adbc445a1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6f9bea20-cf11-4476-afdf-4b8f5159ce79', N'iOn', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6fe1be16-b88b-44e7-b8a1-0755fdcb1549', N'EcoSport', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6ff67bd8-7178-4ad2-bbf4-86dfe669aceb', N'612', N'5b74871c-cd56-4264-872e-3cf8a781c40d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'6ff81b63-72f2-4cc6-9479-10c105a8c90c', N'Rexton', N'2e3d2ec9-e633-48c4-9414-02d86f7179bf')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'700b6982-eb2f-428d-b452-ea82c57ff2de', N'370Z', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7065304b-5060-412f-8b31-2ab754d3320c', N'Safari', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'70691214-5e59-45b6-b69f-431cad1ebe80', N'Laguna', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'70dfcef3-0cfc-434c-bf3d-344dac5f02d8', N'LiteAce', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'70ecebd5-4f1a-41a2-8059-2a40f4334da0', N'Challenger', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'71277e15-519d-4c87-8eaf-80f43de4834d', N'X-Type', N'c1a9c207-b6e3-4ecc-a497-5c8cb74e3f9d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7139a1b0-dce6-4730-a18a-c30d09968050', N'Indica', N'3685ab0b-33d1-4903-bc78-1e0051a97beb')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'716361c4-61e6-46f6-a5c2-d665d2eb248b', N'Nubira', N'8d78b1b2-490e-4082-829d-47dc3e93406b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7193597a-ce7a-44c4-a5e5-8198ced809cc', N'Sambar', N'69e3fd0f-f18c-45a7-9b61-32b2781fd652')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'71d3e1c2-e0a2-4bd7-8883-a8171e2dcf09', N'Z-Shine', N'1d77749a-b193-44ab-aeb2-a6fc0275ff40')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'720123a2-12e6-49e8-8427-5a4049013aa6', N'Armada', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'722b069a-5ac9-4911-b119-75b1f2785754', N'Persona', N'3d95e465-7b8e-47cf-99e8-f2e6f90828a0')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7231e6cd-1e2e-4972-97e4-9b3d561379b8', N'S40', N'23c344a0-d700-41e9-91a5-3cd4a9d9ef0c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7234979c-76da-4f20-a80c-26563a0a865d', N'Move', N'8e27171b-9aa7-4082-930f-3ae388187d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'726c251e-993b-42e0-85fe-2b86f384eb3a', N'Charger', N'b43b29a9-866d-4d88-b02d-1b114bdc6d3a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'72916988-1a1f-4fb8-92ad-dc03eb3eec25', N'Verito', N'7c37d988-d24e-45d4-aca0-0fdc66615efa')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7298dcbf-ea86-4a10-ad4f-5ee2436f335e', N'Rogue', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'72dde13e-cc2d-4b2c-b7c4-9093d4ee877a', N'SM3', N'9d57f8a8-f924-413e-8e8a-dfaa13d7c93d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'73279b23-8b4d-4a51-a8dd-e6270d3f5231', N'Kona', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'739ab381-f567-4514-83b0-1dd08dbc75d4', N'SC', N'fdda3ac0-16db-45de-9950-13429f9971e3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'739d2b4c-6ca3-4ecb-9546-3f789aefc082', N'Vios', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'74377ada-7bce-41ea-8d2b-a0dfb39aa6b1', N'Caprice', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'745e9441-0768-4c10-8e4f-76bc897bc178', N'Preve', N'3d95e465-7b8e-47cf-99e8-f2e6f90828a0')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'748966ce-fd93-4ec2-950d-a5d612008330', N'Vita', N'a66c5dc2-f532-41d6-bcee-d5af30599012')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'74abf9c4-4f75-44e2-b04a-e8b9a33a2e8b', N'Touran', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'74b46fed-f849-46d5-8535-bc69c3fde2ba', N'Bolero', N'7c37d988-d24e-45d4-aca0-0fdc66615efa')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'74e61f34-3761-4ff0-a5e2-4060c3881a81', N'Superb', N'8ee43737-d062-4d88-90c1-3a28a6d36632')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'74ff6ef8-5dc2-48d1-887a-02d29bb53273', N'R-klasse', N'f3113047-cd76-4253-9202-7d61b65aece5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7507062d-88aa-4ddb-916a-251664436380', N'Tunland', N'7888c577-b80e-466a-a340-1f1d9b91541b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'753519f5-60c9-4fda-9ec0-6b2943e53a73', N'Equus', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7541352c-2285-469e-ab66-deaed8afbaca', N'Viva', N'68e7f8c1-ae77-491b-9cdf-bd1ff34a714e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7560a870-7c2b-4a2a-b445-b1726d7c36c1', N'Solano', N'19c80c17-0c84-484b-9b83-59e5e4bed901')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7581f90d-a0f4-416f-ae98-b6232cffb0b5', N'Lykan', N'2bc1e965-e4a0-4148-ba69-285bb60fb397')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'75a621e2-3ddb-491f-a3e4-8f4fa07f3013', N'Dokker', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'75aeeac3-5048-4021-9f28-f8a9d72a755b', N'VXR8', N'de3d4ee5-78b5-41f9-8362-086032c1b98a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'75cb1d3d-6dcb-42b3-8ed4-c193f6cc1351', N'Scirocco', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'75f7bc43-4144-404d-b7f0-f81f78f4ca22', N'QX80', N'389c609f-88a4-4cf5-83fa-254494750ef5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'762a0b5e-4614-4b39-b10c-8a72d6a6d2e1', N'Caravelle', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7656a7dc-a4b9-4439-b504-131859dc1618', N'B21', N'10fd3d99-dc7b-4084-ac74-c6de68b2bd33')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'766983ff-bf78-45aa-b67a-f7321efca138', N'on-DO', N'356e1a07-d2d2-4e49-b14d-7381e3a493e3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'76a0e347-429a-4e84-83bb-bd736605e54b', N'RX', N'fdda3ac0-16db-45de-9950-13429f9971e3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'76b00b18-2827-40d1-be8e-681a36a9341a', N'Journey', N'b43b29a9-866d-4d88-b02d-1b114bdc6d3a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7712792c-ae0b-4588-a263-6ea947a4497a', N'Altis', N'8e27171b-9aa7-4082-930f-3ae388187d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'77842d42-b1b3-4b51-b4f5-cd7f13417e5c', N'Explorer', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7795ad7e-02bc-43bc-974e-c22f559867c1', N'Familia', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'77a996d9-b874-49b1-973c-f869f30edce7', N'Leopard', N'93a8b94d-424e-4dae-b892-9aaf90a32e59')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'77b947f9-8525-4a4a-bd4c-4135623e882b', N'QX56', N'389c609f-88a4-4cf5-83fa-254494750ef5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'78466c42-8ff5-4278-8bd4-c3210a15f2bd', N'Saladin', N'5aa91d17-cb4f-4418-aedc-edb01dae43ac')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'785f8223-a817-4e13-99cb-0938bc036471', N'7er', N'b6c521f7-196b-4e8a-ae22-77b8005cfa92')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'787d0bf0-59ed-4577-819d-77a36d71bcba', N'SQ7', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7891dedc-d141-426e-a49c-48fe149614d1', N'Partner', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7969f6cf-2773-4b62-ab15-0a58bd768065', N'301', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'797dd2ad-af6f-4970-a704-d43afaa93d47', N'Versa', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'79829fe3-876a-4ed3-b073-96fa026d2328', N'Vesta', N'cf259200-2168-44f6-9cbe-a1da81f82c64')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'79986169-e6d3-4e5b-b535-2b80d7fe5976', N'911', N'df50fb40-52db-40f2-a20b-8a93dc967e62')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'79b22f3c-ce42-4a77-a069-927d45942bc9', N'Qashqai', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'79eeded8-f1b0-46cc-9b7a-c2a491b1c19c', N'Cima', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'79f0f2f9-666b-459a-847f-a184c1572ff6', N'Chance', N'c49c2b77-4aa9-49b4-a517-62b95953b90e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7a4d8920-9e8b-41f2-be97-9e3d49b3ae6f', N'F8', N'40c5b314-71b6-4f7d-93f3-e445ede15e3b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7a5add54-30b6-4f10-b116-2647cf18a09b', N'Fabia', N'8ee43737-d062-4d88-90c1-3a28a6d36632')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7aeeb571-e4ca-4626-9dc5-02dd8b877cf7', N'Admiral', N'9194b953-0558-496d-9ba5-b782c29dd336')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7b0e1d55-c02b-4df0-8a61-efa606554304', N'TTS', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7b5ecbce-7d21-4c28-b656-0d796d2a0f99', N'Commander', N'7c37d988-d24e-45d4-aca0-0fdc66615efa')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7b649f11-4bb3-4a59-b180-f5f2149a702d', N'550', N'19bdb5ae-b06b-4de4-a472-35af19deb085')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7baec8d7-aec0-4ab6-b28e-20697dbd07f4', N'Freed', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7becbe7b-65be-4fd1-994d-552b214d4795', N'E-Mehari', N'6f581d7e-2891-4f4f-bbde-d4a93fea8642')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7bf98f01-cba6-4195-ae95-e6fca50f17a4', N'F-Pace', N'c1a9c207-b6e3-4ecc-a497-5c8cb74e3f9d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7c8e605e-4299-4498-8cec-6af1c1af2306', N'A1', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7cc3446b-2e43-4171-a819-418148afa0f8', N'M15', N'cd21ca54-8f5a-418b-8a9d-7638db9857f4')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7ce81fd4-6f60-46b6-aa7c-fa9c34d56146', N'MKS', N'a90381f4-56aa-4c45-99dc-22346ed3bb1f')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7d106a9b-4db5-48c8-bf78-e0f7e5e95069', N'Kadjar', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7d20c355-637b-4cae-a774-58e11c9eeb6e', N'Ertiga', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7d5428bf-615c-42f6-98fb-4550e70babfa', N'207', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7dc90096-48c4-44a1-b2fc-63cf564bd39d', N'7', N'06eb49e7-5aba-486c-b84e-37ef8441ae9d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7e1fbc38-0588-4529-afe6-658bb2212c98', N'Range', N'c5fb28b0-9e14-47d8-bd6d-c2c596fbc395')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7e83a62a-e4ec-4059-8cd9-e77ed27323d5', N'Uplander', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7ed5b084-50c5-44a9-b3f1-7a8486244a93', N'Click', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7fa79067-37bd-4cbb-8f3f-10904ea8a257', N'Venga', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'7ff85803-0fb7-4ade-95ae-078b837862e6', N'Bravo', N'14c02a8f-81b0-4a5b-b191-d983aec6fab1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'800d5e18-322d-4d37-aa11-2984ab8c4089', N'Raider', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'804d80fc-c3ad-4d60-9c4d-90f1cc95d172', N'Ray', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'80aa16cf-4a19-4b8d-b7ac-fdcfc2613d81', N'Regera', N'e95bab32-1911-408e-b846-41bed318d406')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'80d7b50d-1090-4c7e-a512-a6201cd1f2fe', N'MDX', N'edcae123-7e98-4f7b-bbb0-d76306ea4d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'80e20656-97cb-4925-b829-ada5fe93e853', N'Accent', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8174b4c5-bbfc-4424-8463-d98d3808da67', N'Kix', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'819a134c-30dd-4db6-ae4f-eab4d5bc4570', N'Doblo', N'14c02a8f-81b0-4a5b-b191-d983aec6fab1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'81c45105-c692-43bc-9902-fe74e22f0188', N'Sentra', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'81c47f66-855f-4235-8943-a0338c183579', N'Troy', N'dcdcf034-a1c6-4e27-8972-ebb59c9d2b07')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'81d22a66-955d-407d-9b88-549691f2523e', N'Tiida', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'81d523f2-03fc-4847-8bf0-f542c6bfa985', N'Rodius', N'2e3d2ec9-e633-48c4-9414-02d86f7179bf')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'823716a0-dc04-4e65-9c6c-628f96b1d74e', N'Continental', N'a90381f4-56aa-4c45-99dc-22346ed3bb1f')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'824ba5e1-6e27-4dec-a244-3312f39b1929', N'Cuore', N'8e27171b-9aa7-4082-930f-3ae388187d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'82d359a2-b4b5-4e01-9977-9ce4318bbb3a', N'Multivan', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'83126383-2696-416e-b9e0-1b4a06da08d8', N'Orochi', N'4a69ad3b-7286-4123-bf65-fcd4d56f07b8')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'83c102bf-80c7-4e63-8306-b2627f37dbc0', N'Commander', N'eeb274f8-38af-47c5-8d1e-bce37166c0cd')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8424ee6d-0a3d-4110-b489-ba51077f81b1', N'Compass', N'eeb274f8-38af-47c5-8d1e-bce37166c0cd')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'842e5160-26ca-4fe2-805d-f5dca84727cf', N'Seven', N'8f57b136-b51b-4a97-9818-3023ca41ec02')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'848bb3b3-9278-44ba-83cf-dea1152ac5f5', N'Niro', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'848cf3e3-99e8-441a-a2a9-01cbd85b68a8', N'Tingo', N'e3a23304-a5f5-4f66-9c3a-ec7490fbc764')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'84cc21ee-f672-434a-ae5b-d8a2241bec4e', N'Outlander', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'84ccb191-d781-4754-915f-8b71b7345eb2', N'Kizashi', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'84e2fa18-4c4e-46e0-a299-cd781df4ac0b', N'GLA-klasse', N'f3113047-cd76-4253-9202-7d61b65aece5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'850d0c3d-3273-425a-bad1-cebe77c9a095', N'Expedition', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8580794d-69d3-4cb0-b8c2-cef21a29a50a', N'Antara', N'34766825-53a8-4663-b280-6a7a8ef4d695')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'85b18e7b-36d0-4fd2-be83-6a6f5ad58519', N'650S', N'54ee342d-5260-4e91-a6b3-310715065bb3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'85ddaaee-ca01-466f-9f00-3d673666605d', N'Ascender', N'ffed9373-9b26-47d7-82ca-8564db8fbd20')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'861bfc4c-e4b7-4381-8f4d-41515bcbfa27', N'Stavic', N'2e3d2ec9-e633-48c4-9414-02d86f7179bf')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'86afb794-4e2a-4ace-972f-46a57a0bf5cf', N'570S', N'54ee342d-5260-4e91-a6b3-310715065bb3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'86b6db4f-08d2-479c-b3a3-f4ff26fc8fdb', N'720S', N'54ee342d-5260-4e91-a6b3-310715065bb3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'86b6f15c-f560-49e8-bc8f-fb294b70e294', N'Expert', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'874f4bbc-63b6-4d5a-a0d5-acb72e5cd16e', N'LaFerrari', N'5b74871c-cd56-4264-872e-3cf8a781c40d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'87e57e9b-1fcf-4dc7-aed5-ff785b897096', N'Cayenne', N'df50fb40-52db-40f2-a20b-8a93dc967e62')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'87ed9edd-7238-4438-804d-8df42cd296b3', N'Veloster', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'883039a2-c613-4e1a-a12c-487217d61606', N'500', N'14c02a8f-81b0-4a5b-b191-d983aec6fab1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'883f600b-7cec-4ad0-b90d-304727db9f79', N'Astra', N'34766825-53a8-4663-b280-6a7a8ef4d695')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'88745e76-3f6d-40c7-a94c-2a9fb812d3ea', N'Zafira', N'34766825-53a8-4663-b280-6a7a8ef4d695')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'887e298d-361f-4116-a3a4-58e3f6e6faab', N'Verna', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'88f8b925-d6f1-45ca-ac9f-2b13d96ca328', N'A110', N'589f1d95-b874-44c1-9384-84d19e168c2d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'890fbf6c-27b1-4786-bc5e-54093510581c', N'B13', N'10443281-7b3a-4d22-813b-83115e3a0380')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'893531b2-948c-4e51-a53b-09e281eb964b', N'Esperante', N'c0c2ed5d-3eb3-446b-a587-c28d9d5247e3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8a13d092-13d9-493c-8d5f-0c94b29f6706', N'BRZ', N'69e3fd0f-f18c-45a7-9b61-32b2781fd652')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8a1ec17a-fd0f-4db4-b646-fe0be18d534d', N'M3', N'06eb49e7-5aba-486c-b84e-37ef8441ae9d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8a74a140-f317-4c26-9b04-86b0a6864b0a', N'GC6', N'963548b9-5235-447e-81ac-ee61c43b7c91')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8a82ee21-0196-4735-8f85-a1bea91bea54', N'Encore', N'905f0904-5f99-4106-8df8-5f7378bbfcfc')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8ac8b448-faf8-499f-9977-92fbc84de0dc', N'206', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8b1471af-13eb-49d8-b075-67c82fc7ee02', N'Niva', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8bd84363-51f4-49f5-9297-c95f69cbf7fb', N'TrailBlazer', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8c378d18-2cd5-4ea5-9a12-2059cd1ab12b', N'2115', N'cf259200-2168-44f6-9cbe-a1da81f82c64')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8c53d33e-41ae-4779-a8c0-e02209809a78', N'Talisman', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8c645dd3-15f8-4ecc-9e3e-d60d6189694a', N'Murano', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8ce81bd7-acb5-4606-903e-24c4d21519cc', N'Dokker', N'2ccadfdd-4823-4132-9942-e216de777f5f')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8cf3ea2b-cb32-4d39-987a-325339c9dad5', N'Landmark', N'9194b953-0558-496d-9ba5-b782c29dd336')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8d0d10a5-4b90-4ed9-b585-2b6fcecabbbf', N'i10', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8d19cab2-3d8e-406b-aea5-3ce3705d5b43', N'F12berlinetta', N'5b74871c-cd56-4264-872e-3cf8a781c40d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8d725614-59ca-4e9b-b620-a3036b95e242', N'Z300', N'8361f87b-18ee-4fac-96e3-5f8fd2c6123d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8d876116-dfad-4d7a-b672-5aa28490febc', N'XC70', N'23c344a0-d700-41e9-91a5-3cd4a9d9ef0c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8dd0da35-4606-46c4-b117-9eba15e67fa4', N'Florida', N'c3971358-82c7-4881-9ecc-eaab0580c476')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8e238a23-aa2e-4ed2-9244-87d62bd0aca6', N'Marshal', N'7c37d988-d24e-45d4-aca0-0fdc66615efa')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8e36df32-6a60-41f0-9af7-4b7fdbe46f1c', N'1111', N'cf259200-2168-44f6-9cbe-a1da81f82c64')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8e5b57a8-09b1-4916-922b-10f68591ed4b', N'F5', N'40c5b314-71b6-4f7d-93f3-e445ede15e3b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8e8b86af-0560-469f-a84c-888c1ecdb09f', N'Previa', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8eacc4c1-b2e1-4ca6-9462-33ed51cd08eb', N'Sky', N'32c777b4-932a-41aa-b733-d7fa0dcc1008')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8f00c9e5-6b56-4d09-ad63-2a6ee42aa8e6', N'V40', N'23c344a0-d700-41e9-91a5-3cd4a9d9ef0c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8f0c1326-e029-4f4e-95d9-569b4ba92ffa', N'XRAY', N'cf259200-2168-44f6-9cbe-a1da81f82c64')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8f83e19e-9ed4-4fd2-9a06-7d60c204f00b', N'Z4', N'b6c521f7-196b-4e8a-ae22-77b8005cfa92')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8f891f06-0e00-4e54-8f52-c5aeeac430a3', N'Sumo', N'3685ab0b-33d1-4903-bc78-1e0051a97beb')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8fae6ece-d305-4e9f-99d7-7f837cb56623', N'Passat', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'8fb3ce87-f189-470b-b6e1-05edc4446d4c', N'Primastar', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'904936bd-5500-4b6a-911d-7aa8302a85d7', N'Qubo', N'14c02a8f-81b0-4a5b-b191-d983aec6fab1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'905a9f4a-bee7-4672-aba4-aacd3e41f745', N'K5', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'905cfd1f-a829-4abc-9c94-7522e2a4ce1a', N'Panamera', N'df50fb40-52db-40f2-a20b-8a93dc967e62')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'90bec57e-acc2-4f93-9cfe-c9cae70afc70', N'A8', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'90f1c18a-fe14-40f5-91c5-dbef6e85a983', N'Voxy', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'911ab5e7-b3cd-45b5-88d7-c9e20a1632a4', N'Freestyle', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'911b2a25-2c80-4c8a-8e47-53b458b1ab2e', N'Q5', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'917ab02b-b09a-47f8-a744-632d736d2546', N'Arnage', N'49d0c5c3-edca-4af4-8f5c-78fd3c8ed045')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'91a03e4e-bae4-4534-a36c-de19d6efa4a4', N'Landy', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'91a85751-7d1c-48c8-974c-5228e4464b0b', N'Savana', N'1f2c1ee7-e902-4ce5-af78-db989fa87e6b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'91b504c0-ed87-4dd4-ada5-0394d035a2e8', N'Giulia', N'b76437ce-50b6-470a-99f2-8aa6af492aa5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'91dae02d-c6ef-4a5e-bfc9-04ac595fc1c2', N'Fenyr', N'2bc1e965-e4a0-4148-ba69-285bb60fb397')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'91e56cde-85eb-4613-acdc-f539e9904eef', N'C8', N'70b89f75-adf7-4e1f-9095-5764bc1a2f74')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'92285408-3d0a-4dff-aa65-c4538e8ade58', N'Wrangler', N'eeb274f8-38af-47c5-8d1e-bce37166c0cd')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9251318f-5f20-4aca-b5f0-d641601bd1d1', N'2008', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'927bff5a-9e2a-4ec2-8e0d-4a1525b2ea9f', N'S-klasse', N'f3113047-cd76-4253-9202-7d61b65aece5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9288d4cc-e0fd-42bb-9dae-f66b2ff7b539', N'Hatch', N'8a5f841d-f86a-4f7e-9cd2-c5ff5104bac8')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'92980321-6584-4dab-ab7b-f0360239525a', N'RX-8', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'929ef3a0-38ae-4099-832a-573ee59172c6', N'Rezzo', N'8d78b1b2-490e-4082-829d-47dc3e93406b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'92f32ba1-f7e9-4f5c-8b4f-1ff260060e63', N'Routan', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'932dda84-4c09-43e7-923b-0b9a3ef9ad37', N'1007', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'933b92f2-37eb-4626-bfc3-57ad49e0803b', N'Tacuma', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9372f214-ba84-4cbc-b6ec-ecf80329281b', N'Sebring', N'88242ad7-6c82-4609-9f14-04f7f7c5ff38')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'93b07f95-736a-4916-835c-f3ae829f6cba', N'V60', N'23c344a0-d700-41e9-91a5-3cd4a9d9ef0c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'93b24cce-7e29-4eea-af9d-7096e6bd644f', N'Himiko', N'4a69ad3b-7286-4123-bf65-fcd4d56f07b8')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'93f9d39e-0e04-40c3-aaf0-936b5eda326b', N'2er', N'b6c521f7-196b-4e8a-ae22-77b8005cfa92')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'93fe659c-ecd7-4828-a078-beb4aeea594e', N'Sens', N'c49c2b77-4aa9-49b4-a517-62b95953b90e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'943bfff8-2808-4ddd-87f2-369decd3332b', N'ASX', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'94638614-97cf-49f5-a8e2-e4d5b9508557', N'K7', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'946e2705-666d-41cb-aa5b-35f2024795b3', N'Huayra', N'ba930a52-2bcf-45e4-8752-9878caab2ece')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'948ed6c6-7a41-4504-ac3f-f1fd54e4663c', N'SX4', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'94b55df9-dd35-4709-b911-e85de9d9f82b', N'B-MAX', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'94b6f7e4-f4ea-4bc7-af9e-7a5a4fe89185', N'Vamos', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9535a13d-9313-457f-bda9-9a752816e949', N'MP4-12C', N'54ee342d-5260-4e91-a6b3-310715065bb3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'956801a9-3695-499b-b28f-4083d7207702', N'A-klasse', N'f3113047-cd76-4253-9202-7d61b65aece5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9578077d-09f5-459f-a4f7-938ff8445160', N'Sharan', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'95ddbcc4-1ea1-4fae-919c-32dc61e0a3b2', N'Chairman', N'2e3d2ec9-e633-48c4-9414-02d86f7179bf')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'95f07241-b7d4-4cff-ae98-9b011ff69864', N'Corvette', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9634a58d-05cf-481c-b197-a507595f7850', N'Roadster', N'5700d1b1-1b35-490e-9055-5dc414f6e24f')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'965ea870-5eb3-44dc-844c-1253abd10fa4', N'Mobilio', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'966a657d-b9b8-4195-9d62-60d4c486d471', N'Logan', N'2ccadfdd-4823-4132-9942-e216de777f5f')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9693240d-e848-4463-bc6d-3c4aefaecaeb', N'Lodgy', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'96ca2d9d-2d03-42d1-8b84-a4469d9c8cc6', N'NSX', N'edcae123-7e98-4f7b-bbb0-d76306ea4d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'96e516cf-1eea-404b-aa9d-56f56c9ca1b4', N'X7', N'4391872d-6c69-4727-9016-182f58949458')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'97087147-4a12-4c67-9c8c-42ddfd882da0', N'Pickup', N'6ddef8be-f1d0-4b01-ae04-9aff95e4e0ac')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9723a98a-e931-4617-bd2d-b89a05b166b9', N'Epica', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'974dd767-f725-4db6-b4c2-e92be5a9cd32', N'MKT', N'a90381f4-56aa-4c45-99dc-22346ed3bb1f')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'974f1464-c9ce-4a29-a9db-c0baea9239e4', N'Altea', N'83d16608-e410-44bc-986e-13ac3e40b61c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9787be08-a2a3-4bee-9aa0-ea99aee6b918', N'RL', N'edcae123-7e98-4f7b-bbb0-d76306ea4d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9796e19d-5ae1-49b6-93c6-c0fb5d1c425a', N'Highlander', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'97bc2ba8-37ec-485c-9857-3069d2899fd1', N'Outback', N'69e3fd0f-f18c-45a7-9b61-32b2781fd652')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'97def761-3168-40ca-84ab-cd4a0ff905d0', N'Portofino', N'5b74871c-cd56-4264-872e-3cf8a781c40d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'97df5689-437c-4224-b1e0-fd4cb63489ba', N'Kyron', N'2e3d2ec9-e633-48c4-9414-02d86f7179bf')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'97e9c0fd-433c-44a8-83b2-9831170b2fcd', N'C10', N'b4231ec5-38f6-49a3-ab06-0cd7d317d319')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'98011780-b9d1-4460-9e2a-c5ef966b5633', N'Sorento', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'99356df5-84b8-4820-8a74-9e271b25c757', N'LFA', N'fdda3ac0-16db-45de-9950-13429f9971e3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'99357d9c-ecb5-4eab-b2fd-031b47fd1ddb', N'Espace', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'99c6c29a-6c7e-4eec-aa76-9f67fb63fe64', N'CLK-klasse', N'f3113047-cd76-4253-9202-7d61b65aece5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9a27cf17-df46-4f6e-8064-0b2cc1cee15d', N'GTC4Lusso', N'5b74871c-cd56-4264-872e-3cf8a781c40d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9a3d74b8-918f-4787-9123-c73609503b1d', N'G8', N'650dd48c-6055-4ef5-a6ce-fdb2b8004110')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9a4aa914-50c4-4c12-bc7f-7cb91e110fcc', N'XJ', N'c1a9c207-b6e3-4ecc-a497-5c8cb74e3f9d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9a52c47b-6e8c-4adc-8290-2520a1137c63', N'Lodgy', N'2ccadfdd-4823-4132-9942-e216de777f5f')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9a61fd44-b88d-4c28-925d-6efb6356b3d6', N'Avanza', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9ac853ef-ae52-4687-a25a-d2e5560e2e05', N'Adam', N'de3d4ee5-78b5-41f9-8362-086032c1b98a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9ac93e2f-55d9-46c4-b1b1-10678dab3eb0', N'STS', N'7f828726-e39d-48ba-b140-cbcffb570f89')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9ae3c2cc-a439-4ab9-8a66-fbcbae69ac29', N'V5', N'21dba530-e719-455c-8af1-14b1f75309a8')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9b18a461-d3b0-4f3d-aea9-2e1c8edadd69', N'Antelope', N'362f25ad-010a-4ee5-8e60-3a7e0d2a3e03')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9b2aeb92-6111-4398-a623-a2bcd28bd3ad', N'Aygo', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9ba92f73-639c-49b6-9c7c-88f349d6c696', N'T98', N'3afbfd78-37b2-4d03-a253-4ecf64e8a7b5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9bb090bc-e854-46be-a4c2-17b5d4794676', N'Citigo', N'8ee43737-d062-4d88-90c1-3a28a6d36632')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9bd04bc8-9e5c-4a9e-abf6-968945cd0377', N'RCZ', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9be4ff8b-fd5f-4bff-b519-c83daa0f798c', N'Q60', N'389c609f-88a4-4cf5-83fa-254494750ef5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9c0916a2-627f-4015-8895-cf6c3ea9d2d9', N'Omni', N'd187a531-c710-4495-bb5c-d158f7d0aad0')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9c12b89a-c16e-4b51-acc9-2e1426f08b3f', N'R8', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9c4cb329-f724-48ec-a615-dc634f9df862', N'Fortwo', N'34bbe093-f658-4a12-a1ba-b59659436228')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9c9cc04c-18e1-4759-9077-eba0869ca8ef', N'Express', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9cd71f0e-e2e9-4665-8ef4-671c4180905c', N'MyVi', N'68e7f8c1-ae77-491b-9cdf-bd1ff34a714e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9ceb2cca-cc8f-4b37-858f-9dbbdc80491c', N'Vivaro', N'34766825-53a8-4663-b280-6a7a8ef4d695')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9cee4421-c823-4240-ad2f-66eefea73094', N'Legacy', N'69e3fd0f-f18c-45a7-9b61-32b2781fd652')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9cf09942-bc4f-42dc-a0ae-4a1b67ce3cf9', N'607', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9d5b4177-281e-4e05-86e0-defb2306d3ff', N'Hilux', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9d834824-28c0-49d3-84d2-094c4e326a61', N'S3', N'd31cdc50-1d05-476d-9aea-9fe14dd18fcf')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9d8dfcd9-c9e4-44fd-aa6e-ac4481486c00', N'Be-go', N'8e27171b-9aa7-4082-930f-3ae388187d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9e023934-a17c-466d-a516-3346d21a4872', N'599', N'5b74871c-cd56-4264-872e-3cf8a781c40d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9ea7d40a-18d3-4bf3-a941-d74b87397dbc', N'Freemont', N'14c02a8f-81b0-4a5b-b191-d983aec6fab1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9ea89ee5-e38f-4249-9a7e-c4dc7d346b0e', N'Lanos', N'c49c2b77-4aa9-49b4-a517-62b95953b90e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9f354810-0be0-4b7d-acba-7da36f28207a', N'Laville', N'10fd3d99-dc7b-4084-ac74-c6de68b2bd33')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'9f78f4f3-02f3-49b2-af00-25fd7b613dcc', N'Mira', N'8e27171b-9aa7-4082-930f-3ae388187d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a06f9ab6-c0c4-4bad-b956-2bf9b383c98f', N'Oley', N'a66c5dc2-f532-41d6-bcee-d5af30599012')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a076aa73-82b1-4c42-ab30-0c67ac02a27a', N'X6', N'b6c521f7-196b-4e8a-ae22-77b8005cfa92')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a076c4c4-262c-42e7-ad57-a4be9e8b0244', N'Thesis', N'69028d61-d882-4d03-8248-3baa2bbbbe8e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a07e0287-2586-4f22-90b1-210f8c25db87', N'Carol', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a08e20df-6fbf-4bd5-906c-9ccc39671201', N'SC7', N'963548b9-5235-447e-81ac-ee61c43b7c91')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a09cc7dd-0c39-429a-972b-d1a82f333ce8', N'SM7', N'9d57f8a8-f924-413e-8e8a-dfaa13d7c93d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a0c41daf-86f3-4f63-8602-dc2412964a85', N'Avalon', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a11c8806-96e6-4694-8127-9a791376c6b3', N'Tipo', N'14c02a8f-81b0-4a5b-b191-d983aec6fab1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a1390be7-2527-426d-a96f-527ee3dec3c5', N'Kangoo', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a1426671-f495-4158-8661-0fdbaa01be04', N'3008', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a16a658a-e8e8-40bb-91fc-491d43721721', N'CL-klasse', N'f3113047-cd76-4253-9202-7d61b65aece5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a1ad639f-2172-4c8f-8730-9e33fbec562f', N'Coolbear', N'72cc10f3-daa0-40c6-9f4e-cdad4277b13a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a1e44a91-f808-49bc-9868-bfeefce10343', N'Terios', N'8e27171b-9aa7-4082-930f-3ae388187d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a2186208-6b07-4c2f-839a-586b394471ca', N'CLA-klasse', N'f3113047-cd76-4253-9202-7d61b65aece5')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a21fd7d5-0e33-420e-a2f8-dcd4392adca3', N'RS4', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a252a657-64ec-4aae-816d-13627be4359f', N'Brio', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a2839735-4c5f-4381-bb59-30d3892bd6da', N'Stelvio', N'b76437ce-50b6-470a-99f2-8aa6af492aa5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a2aac882-b817-48bf-af84-3daeecba39e1', N'Spectra', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a2d2ec7e-135d-48f2-ace2-6bef7a7a2304', N'Quattroporte', N'68b81e8d-38c9-4b25-843c-40464738f496')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a2efd480-6720-4127-b415-d5d06f7730f7', N'Trafic', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a36957f7-e3c5-42f5-a93a-39653ea36387', N'S4', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a3c964e6-8909-49c0-9b90-ac203e5fd08a', N'Coo', N'8e27171b-9aa7-4082-930f-3ae388187d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a3ca7e9c-a42d-4930-ad1e-b2f115bd79e9', N'Berlingo', N'6f581d7e-2891-4f4f-bbde-d4a93fea8642')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a3f7db13-5b53-4d23-9f83-fb7b4be2d622', N'Equator', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a3fefd7b-1d1e-47ba-ae2d-99cc509768c8', N'Camry', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a4395e75-5634-4930-a8ff-fc223e472085', N'EL', N'cf259200-2168-44f6-9cbe-a1da81f82c64')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a4b4f423-49f7-446a-ad99-07d3a874c711', N'1M', N'b6c521f7-196b-4e8a-ae22-77b8005cfa92')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a4ff4d74-aa86-45ca-88e9-ad277fe3cb18', N'Minica', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a5090c13-4c91-4f72-b3cc-8e06d6e284e4', N'Focus', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a57a05a6-04ba-49eb-8795-0eb2fb927b14', N'Panda', N'14c02a8f-81b0-4a5b-b191-d983aec6fab1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a59081ea-c5ec-4695-aade-fc1930edbae0', N'Adam', N'34766825-53a8-4663-b280-6a7a8ef4d695')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a5bce1bc-fc0a-41e3-a79c-6b5271ce83f1', N'Challenger', N'b43b29a9-866d-4d88-b02d-1b114bdc6d3a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a6287b32-efb3-4220-99d2-c97decb7d33a', N'Linea', N'14c02a8f-81b0-4a5b-b191-d983aec6fab1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a63d97da-99a3-4454-8a43-feea79317772', N'CX-3', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a6591f6f-ddc8-4082-8466-bf4a2444755f', N'R2', N'69e3fd0f-f18c-45a7-9b61-32b2781fd652')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a6beb288-e9b9-48df-a4ba-ff82444eace1', N'MK', N'963548b9-5235-447e-81ac-ee61c43b7c91')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a6bfdc9c-dd6a-41e0-ab73-9bce86434bde', N'iQ', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a6c12f26-c2bd-4d10-945d-224ded13375e', N'Nexia', N'8d78b1b2-490e-4082-829d-47dc3e93406b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a6d329fb-4b27-464a-93e3-140f48e05888', N'HHR', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a6f219a4-e93d-4658-9423-19e8684410a7', N'Revolution', N'cf259200-2168-44f6-9cbe-a1da81f82c64')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a6f618f1-f4ab-4d0f-b444-3196ed686f6e', N'LaCrosse', N'905f0904-5f99-4106-8df8-5f7378bbfcfc')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a739628a-ff79-499f-a8c1-e6d802615d33', N'Succeed', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a7a10780-187e-4605-bf6c-02be7bb5ec1e', N'Colt', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a7ab4957-ee04-4652-b96c-1b1ab23d6e76', N'Civic', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a7b57901-c8e3-40ff-8f31-02db7a87791b', N'GT', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a81238af-49c9-48cf-b126-d054581af00f', N'Jazz', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a81e33bd-0ca4-4c49-bbf9-5c89bee44911', N'Xenia', N'8e27171b-9aa7-4082-930f-3ae388187d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a8226a97-deba-46e5-94a4-ca79b3b6eb8e', N'XC40', N'23c344a0-d700-41e9-91a5-3cd4a9d9ef0c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a830a872-f902-43e6-ae01-e24b543bf8ca', N'CCX', N'e95bab32-1911-408e-b846-41bed318d406')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a89f177f-2e4a-401c-b413-6bce1e12879e', N'Trevis', N'8e27171b-9aa7-4082-930f-3ae388187d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a8a7981d-c3dd-4815-b813-1ce7933d1f42', N'Forte', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a96b5145-a6e6-49ae-baae-47238a37b09f', N'Gentra', N'8d78b1b2-490e-4082-829d-47dc3e93406b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a9e5d6cc-c389-4549-b5ff-a970e7595d55', N'C-HR', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'a9fce152-0687-4fc2-836e-8d1ad0a2a91b', N'Ikon', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'aa2f86c2-bb7a-49da-85f1-9fce9822f150', N'Toledo', N'83d16608-e410-44bc-986e-13ac3e40b61c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'aa60f48a-b8f8-487c-b690-388e8f4ed96d', N'Corolla', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'aa8f4fd4-4366-476e-8bb1-c32aeb065b65', N'Leaf', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'aaab3b40-6560-48a9-abb3-0c587e303c02', N'488', N'5b74871c-cd56-4264-872e-3cf8a781c40d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'aab67a9d-7fff-40a4-a684-6db0be445403', N'SEiGHT', N'ed6ecfd5-9937-4b18-8657-66ff17ba9551')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'aac6f9fe-4a03-488f-a16e-d8db8ad16907', N'Cascada', N'34766825-53a8-4663-b280-6a7a8ef4d695')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ab1eb947-21a8-4a3d-a1a1-5a39a8937062', N'Elysion', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ab2bf574-6b98-4fbe-b6f1-83b72d2f1f36', N'F-Type', N'c1a9c207-b6e3-4ecc-a497-5c8cb74e3f9d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ab87da60-e3c1-4041-80a7-0e52c6408d11', N'Geneva', N'b888e63e-432c-4a41-886a-b0522d63490e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'abaaf6e0-c55c-4076-8424-0fd32ca75872', N'Discovery', N'c5fb28b0-9e14-47d8-bd6d-c2c596fbc395')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ac4e35ae-a55e-449d-83ae-bbc6935f3d2a', N'Inspire', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ac9f7466-e142-4b83-8fc8-4fc73fb1aa37', N'Brooklands', N'49d0c5c3-edca-4af4-8f5c-78fd3c8ed045')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'acc7e7b6-64cb-411c-a74a-9746992aa816', N'Strada', N'14c02a8f-81b0-4a5b-b191-d983aec6fab1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ad81c9e1-2cae-4610-9248-29e128f2af7d', N'Gol', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ae1eda7f-191d-4706-9028-2c0c2d12195e', N'V8', N'2cd71503-5bcd-4f65-baf1-14e1b01d845b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ae2f055c-4119-48b2-be34-974c4a32d4ec', N'RS6', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ae76afd1-2f58-43d1-a07b-02d42035c45f', N'Ateca', N'83d16608-e410-44bc-986e-13ac3e40b61c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'aea36ce5-7889-4cc7-8e3c-53a5f2d55b69', N'Noah', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'aed87dcf-f317-41dd-8e96-444c9b5b2ae1', N'Smily', N'19c80c17-0c84-484b-9b83-59e5e4bed901')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'aef66407-6b8c-4f5a-bacc-3c1be640e47c', N'Entourage', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'af4e456b-0705-4c4f-a066-1f30fd95f27a', N'Agera', N'e95bab32-1911-408e-b846-41bed318d406')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'afae6d83-4c6d-4c9d-9279-efbd804d3a9c', N'Palette', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b077fd71-e1fd-484a-8085-e9919756eeaa', N'T600', N'8361f87b-18ee-4fac-96e3-5f8fd2c6123d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b08593ab-2636-4bdc-ab7c-d30054dfa213', N'Arena', N'3d95e465-7b8e-47cf-99e8-f2e6f90828a0')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b08e5098-852a-4438-8de0-2042217ed239', N'Kembara', N'68e7f8c1-ae77-491b-9cdf-bd1ff34a714e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b12bf177-9c95-4823-aa1f-2e010212d230', N'ES', N'fdda3ac0-16db-45de-9950-13429f9971e3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b14bbad1-99c2-4bea-afb6-b590a8cf4299', N'Stonic', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b19aae61-b989-4fee-a5fc-7881c269a1ab', N'Ampera', N'34766825-53a8-4663-b280-6a7a8ef4d695')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b1ab025a-8938-4f00-bd59-d75acc1e89d0', N'Combo', N'34766825-53a8-4663-b280-6a7a8ef4d695')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b1b895c6-cb31-4309-98d4-823fa4e0a9b8', N'Micra', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b1b9eb23-5092-48ca-8268-38ed4a8f5fbd', N'QX70', N'389c609f-88a4-4cf5-83fa-254494750ef5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b1e6c9b9-e5e2-4bac-8eea-4d952ad23d46', N'ILX', N'edcae123-7e98-4f7b-bbb0-d76306ea4d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b1f5c9e3-606d-45b3-9645-0c75df466931', N'3', N'b5a7ddcd-46af-4470-a0ea-ff57f8aace5e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b2172f89-47fa-4409-a6b4-a1ae0052503f', N'B-klasse', N'f3113047-cd76-4253-9202-7d61b65aece5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b238ffc6-1089-426b-ac14-95facbf2c279', N'QQme', N'10443281-7b3a-4d22-813b-83115e3a0380')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b23d6b22-6366-441e-b385-4c5075f77d4c', N'Hijet', N'8e27171b-9aa7-4082-930f-3ae388187d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b2465341-3047-45b5-9116-f5d026a8cbf5', N'tC', N'73f94dd1-9da3-413f-9d2b-2b7f0486d625')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b246e5ff-872d-4ab1-9c8c-5cbfb39a4dcb', N'Soul', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b296975e-2bf2-4241-b364-e17501d2b4a1', N'Azera', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b29b59c3-60a7-4c61-bcd3-48ffa6966197', N'Axela', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b2eb7707-2060-4e66-826a-0d306620b549', N'Giulietta', N'b76437ce-50b6-470a-99f2-8aa6af492aa5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b2f91113-3aaf-4a6a-a7b8-ae9e64bd8b0b', N'CLC-klasse', N'f3113047-cd76-4253-9202-7d61b65aece5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b34e11b3-046c-4d93-9e33-911291716a73', N'Massif', N'00205674-d35a-498a-aee2-5c4bb9f9a8bd')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b3535ab0-d794-475e-86ac-77e687053796', N'107', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b3598c15-43cb-4460-9706-80dfb15c3d70', N'Atos', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b36b29d3-5f77-44c0-8c4f-13516373b1d8', N'Sienta', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b38834fa-237b-4094-a446-aa914ffcf685', N'Cayman', N'df50fb40-52db-40f2-a20b-8a93dc967e62')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b3e69c58-99ad-4006-848e-9acc84078334', N'Vega', N'b4231ec5-38f6-49a3-ab06-0cd7d317d319')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b40131f2-c373-4655-9853-67c3b91f752c', N'Cube', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b4190eb1-105b-4a1c-ac09-a1f9f12e4464', N'LX', N'fdda3ac0-16db-45de-9950-13429f9971e3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b46bd9ed-ed23-4699-ba09-7cea0e19b9fa', N'Astra', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b46f04e9-1ee4-47e2-8618-12606e1b9ee2', N'Edge', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b4a91287-8446-45ac-817a-c7daad283e26', N'M.Go', N'58fc5b57-330e-446f-be55-a6a11e237d49')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b4cc1180-71ed-4b1b-be36-b6b797668ed7', N'i3', N'b6c521f7-196b-4e8a-ae22-77b8005cfa92')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b52cb96c-74b9-461f-b93c-f495e2bc30b9', N'QX50', N'389c609f-88a4-4cf5-83fa-254494750ef5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b536c6b8-da71-4f2d-8588-a65a3f40f79f', N'G3', N'40c5b314-71b6-4f7d-93f3-e445ede15e3b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b589aa71-6708-41f1-b89c-7946335ba74a', N'Roomster', N'8ee43737-d062-4d88-90c1-3a28a6d36632')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b5af79d4-934e-43f5-99fe-2d49bd0b2b17', N'Acadia', N'1f2c1ee7-e902-4ce5-af78-db989fa87e6b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b5bc27b3-cddc-4b7a-8d19-6e2eded3cdbd', N'i20', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b5d604af-76ff-4356-a8ca-02bab18443ca', N'Verano', N'905f0904-5f99-4106-8df8-5f7378bbfcfc')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b6313bf5-f649-4629-9581-525d0d270c2a', N'Sirion', N'8e27171b-9aa7-4082-930f-3ae388187d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b6392fa0-21c5-4353-88dd-0b73374c2567', N'2000', N'8fae19da-8f72-4fb5-9d40-8ca95caae4ca')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b668a874-93df-4f5d-8b09-775c340f22db', N'Gypsy', N'd187a531-c710-4495-bb5c-d158f7d0aad0')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b682504f-bafe-4e42-9e97-bd5f6ea9a11f', N'S90', N'23c344a0-d700-41e9-91a5-3cd4a9d9ef0c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b697003a-c45c-42fe-98e3-e276eded9194', N'DS4', N'6f581d7e-2891-4f4f-bbde-d4a93fea8642')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b6b32087-60bb-4983-af2b-1758af47ac80', N'Leganza', N'8d78b1b2-490e-4082-829d-47dc3e93406b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b6cc160a-9e5a-48b3-b382-4e7e09faa47e', N'Oting', N'f05c93a2-86b0-48c2-8f10-e9b83c66435c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b73c1077-93bc-4ac7-8024-d4f045ec97a7', N'Cruze', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b7706be1-1e6f-4350-9c19-61359a1365e7', N'Accord', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b7ca6398-da29-4bd4-a6db-ac6708459c6e', N'2113', N'cf259200-2168-44f6-9cbe-a1da81f82c64')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b7eb24c8-f161-4cac-a691-8b5af7ce9b8b', N'Sailor', N'72cc10f3-daa0-40c6-9f4e-cdad4277b13a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b80aaa51-4df0-44f6-a60b-9291abb68134', N'Vectra', N'de3d4ee5-78b5-41f9-8362-086032c1b98a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b818b751-2086-4ebe-8e7e-6b1b4cd91517', N'Aurion', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b87860e8-4f8b-49c3-b7bd-7beb45c67504', N'Century', N'a07e4d1d-0899-41b9-914e-c1aebc003621')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b8ed5869-d1ce-4faf-84a1-b89cd4cd3b37', N'ST1', N'f9410f25-7b92-4ef3-a44f-d1550773451e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b8f169d2-1d8a-45d9-8019-cfef55aa1fb8', N'Kodiaq', N'8ee43737-d062-4d88-90c1-3a28a6d36632')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b9251851-24bc-440d-835d-4a9fa6d88435', N'Lioncel', N'aa311e15-13ec-4310-b437-63e939a7d828')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b9294539-1bb8-4181-a3fe-edacaddbe129', N'V5', N'a66c5dc2-f532-41d6-bcee-d5af30599012')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b9c9ef1d-a991-4ce2-a14e-b8d4e336fe15', N'Inspira', N'3d95e465-7b8e-47cf-99e8-f2e6f90828a0')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b9d4d15f-080e-4f9b-833f-4866db06c6cb', N'Largus', N'cf259200-2168-44f6-9cbe-a1da81f82c64')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b9ecc6f6-9370-4039-a0d4-e234f11136be', N'ATS', N'7f828726-e39d-48ba-b140-cbcffb570f89')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'b9f74085-d173-4de0-85aa-088422ec152d', N'Shuttle', N'5aa91d17-cb4f-4418-aedc-edb01dae43ac')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ba3c1530-c03c-44ca-8265-a03b22dcc50e', N'C30', N'23c344a0-d700-41e9-91a5-3cd4a9d9ef0c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ba4d142d-1fa2-4cfa-8f5f-c161abbfc627', N'Veneno', N'10481089-df33-4439-b1c0-4e29cbc277d0')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ba526723-7b79-4a7f-9ab9-590280e48aa0', N'Freeca', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'bac3cffe-9dc8-4a3c-8db6-1a6e26786717', N'March', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'baee0f5a-849a-4f30-8f06-2497d98b6151', N'Hemera', N'ee432742-699d-4ffc-af14-4a08786cde99')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'bba6aa67-1489-4203-ab57-b08a6f3cb5f9', N'Terrano', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'bc2798f5-b8fc-4e79-97d6-038776a194e6', N'Comfort', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'bc3ac2d1-2e7c-413a-a994-347fee2cc654', N'Sing', N'72cc10f3-daa0-40c6-9f4e-cdad4277b13a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'bd00df9b-8cb6-463e-961a-0ffb7008f276', N'Copen', N'8e27171b-9aa7-4082-930f-3ae388187d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'bd3fa6c8-3e3b-4c6c-972e-d8a64986df2e', N'Dawn', N'88629d81-57ca-43ce-a44a-08d351fd95d5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'bd8d6b3e-fbd4-43cc-b134-81ed6b06bfb9', N'Livina', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'bdbb9b7e-b4d2-4678-9f01-75fc42552067', N'C8', N'6f581d7e-2891-4f4f-bbde-d4a93fea8642')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'be1cf25b-eeef-48d4-82ad-6ecb809e63ad', N'A4', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'be9735d3-a243-41b1-89cd-62111a65a464', N'SR-V', N'1c46d435-5577-4523-bc56-37947d08b623')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'be9a354a-7fbe-4813-8b53-12116d1dabcd', N'Justy', N'69e3fd0f-f18c-45a7-9b61-32b2781fd652')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'be9b2a9f-3b16-424b-a7d6-05dc6387e616', N'3er', N'b6c521f7-196b-4e8a-ae22-77b8005cfa92')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'bee31dc2-ab34-46f5-a8b9-28491bc9f3e1', N'Modus', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'bf53133d-288f-4b78-8b13-e125e71ec26a', N'Fox', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'bf5947ac-bdd3-48b0-ba6d-f8edea61b0c7', N'Dualis', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'bf785464-65b7-494e-9758-19ae4531afce', N'Suburban', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'bf8948bb-093e-4b62-93a1-6c6730a81b45', N'CR-Z', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'bfd43d39-32f8-4e7c-843a-8e1fdf7a4c98', N'Canyon', N'1f2c1ee7-e902-4ce5-af78-db989fa87e6b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'bfe8b28e-bb7f-4cab-b8ad-5d3281cad1fa', N'Urvan', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c00dc8ec-086f-4cb5-9c5b-29e24b4fb78d', N'Yeti', N'8ee43737-d062-4d88-90c1-3a28a6d36632')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c06c6ef6-968c-41e6-b8d8-7ca0c4c4ad4c', N'Satria', N'3d95e465-7b8e-47cf-99e8-f2e6f90828a0')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c0779d0d-4932-4ddc-b7ea-83b67c03d633', N'Note', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c0de2a7a-d715-4b15-b646-72a1b7143954', N'Cowry', N'72cc10f3-daa0-40c6-9f4e-cdad4277b13a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c1504dda-a083-41e4-b26f-fd9c9f11e2a5', N'Clubman', N'8a5f841d-f86a-4f7e-9cd2-c5ff5104bac8')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c1574c7d-9bf4-4fdc-9339-13c3452163a3', N'N-WGN', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c187dba9-91f9-485d-a5c3-4c412c5af373', N'QM6', N'9d57f8a8-f924-413e-8e8a-dfaa13d7c93d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c1b1626a-c0b3-45a9-b7e9-43474da41df7', N'GT-R', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c20b6acc-9ae2-498a-a115-ed4782c2f912', N'Patrol', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c26f384d-132c-47ba-9078-a6eb4a953801', N'Elise', N'2dec248f-e55c-4600-9684-f82040437771')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c311d20d-9b45-4874-aab7-feeb589c6356', N'iA', N'73f94dd1-9da3-413f-9d2b-2b7f0486d625')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c31bc560-a863-4b8e-8abc-c625c551cec4', N'Pulsar', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c3506bc1-3a66-493e-9c4d-6b48c293cf93', N'Edix', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c38407f7-bb1a-4de5-9738-56fdab282527', N'2107', N'cf259200-2168-44f6-9cbe-a1da81f82c64')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c39148d7-fec9-4b59-b358-1a72645a11f1', N'Matrix', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c399a027-8139-47ef-a04f-04c71b61eec8', N'2114', N'cf259200-2168-44f6-9cbe-a1da81f82c64')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c3c33b25-272e-4858-9cd5-eb8ef15fd232', N'GS', N'fdda3ac0-16db-45de-9950-13429f9971e3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c3d3580f-038c-4ed6-b276-c427ca62ef9e', N'2112', N'cf259200-2168-44f6-9cbe-a1da81f82c64')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c3d6b203-4a64-44d8-a218-bf68e9a76854', N'Spacetourer', N'6f581d7e-2891-4f4f-bbde-d4a93fea8642')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c41a3ef8-51b8-49a3-bcd7-1185f8afb140', N'2104', N'cf259200-2168-44f6-9cbe-a1da81f82c64')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c48339b9-91b5-4427-ae87-9779be53ae49', N'RS7', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c4ae2393-9cef-4622-8dde-eff538ff541f', N'Mondeo', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c4d32d99-8eaf-444a-8ecc-5e8cc3118a42', N'Pointer', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c4dcc69f-b9ca-43ee-8d5a-8e0faba86ad5', N'V2', N'a66c5dc2-f532-41d6-bcee-d5af30599012')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c5396b77-366a-46ab-9cd9-a89505cfb281', N'M6', N'b6c521f7-196b-4e8a-ae22-77b8005cfa92')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c5895531-4249-4d01-a821-1c454b9b0b6a', N'Cobalt', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c5924817-0af6-444e-9195-f2f9fa1cdaa2', N'SLK-klasse', N'f3113047-cd76-4253-9202-7d61b65aece5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c5adcfd3-dd7d-4c2f-841e-6dd49c0700c9', N'KWID', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c5d4d31c-e3a9-4fa0-8958-ab4640bbff29', N'Cevennes', N'ee432742-699d-4ffc-af14-4a08786cde99')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c6197ad0-d8db-494e-b2be-2f18d164c438', N'350', N'19bdb5ae-b06b-4de4-a472-35af19deb085')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c63404df-df99-4dba-9b80-1d9307fa7c1c', N'300C', N'88242ad7-6c82-4609-9f14-04f7f7c5ff38')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c643fc58-c5e8-4f66-a87e-6108e11e8e0c', N'Morning', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c692d818-cd3b-4d4f-b527-18710f239f5c', N'Zero', N'214eebef-8d1a-4557-9154-60144f656a60')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c6e2fae4-97ca-4eb0-87ec-093fb4c70cce', N'TLX', N'edcae123-7e98-4f7b-bbb0-d76306ea4d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c6fcbcac-93b4-4d09-82d8-44188f14d869', N'F0', N'40c5b314-71b6-4f7d-93f3-e445ede15e3b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c6ff81d7-37bd-4100-84d1-6becc25357fb', N'Centanario', N'10481089-df33-4439-b1c0-4e29cbc277d0')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c7443286-1ec4-40ef-9366-eba7ab1143a1', N'Esquire', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c7708a11-63dc-45f9-9277-4c717e659d7b', N'Cervo', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c7927136-c207-40b8-8a05-90908b90a6b0', N'Genesis', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c7a3917f-7a19-4f01-a41b-247a5dd7798f', N'Pinzgauer', N'9ad726df-3fbe-4dc1-a830-1a48b443f1c4')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c7b885fe-8f76-4eee-bd5f-281916d8ddf2', N'X350', N'6e115cca-9825-445e-905a-225d0011fff7')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c7d6e893-aa55-4100-931e-10b4d8876ac1', N'Duster', N'2ccadfdd-4823-4132-9942-e216de777f5f')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c80159c3-714d-4ce0-a586-d6ff4e60c1bf', N'Defender', N'c5fb28b0-9e14-47d8-bd6d-c2c596fbc395')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c82797d6-cf0e-4ad7-8da0-989715b7721b', N'Saibao', N'8adcfe2e-2baf-4545-b88a-d1fd96c97d9e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c82805bc-ab9c-4944-a4fc-0a31278c5c8c', N'Albea', N'14c02a8f-81b0-4a5b-b191-d983aec6fab1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c82c250c-7c49-4ab4-b74c-61783ee62697', N'RS5', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c83d2516-7abf-426b-853f-ca17f75c7b32', N'Boliger', N'10fd3d99-dc7b-4084-ac74-c6de68b2bd33')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c87d8c68-77be-4cd6-bf35-c18f998bcf2b', N'GTR', N'69a0d2b7-7a1c-4b9c-a71a-00c521c9f31d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c89ea0fe-1834-4eb5-8254-619dca53223f', N'GT', N'b76437ce-50b6-470a-99f2-8aa6af492aa5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c8eddff2-fbf8-437f-9e77-bb43b72adf9a', N'Ranger', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c8f99be7-33f2-4814-8e97-b414a2088844', N'Tacoma', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c90584dd-423d-4cc8-806e-8950b3e71cd0', N'S1', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c98a5071-f827-4678-ad13-bfcd43ef03ef', N'Dayz', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c9c7c8dd-aa84-473c-9771-40932e4d591e', N'Zest', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'c9f24a97-80d4-4366-bf71-f42168b7b6ba', N'IS', N'fdda3ac0-16db-45de-9950-13429f9971e3')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ca0e62d1-538a-43c2-b432-1ce4ba43923b', N'TownAce', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ca24b627-bc1b-4cef-a8fa-1f766185ab7c', N'ELR', N'7f828726-e39d-48ba-b140-cbcffb570f89')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ca40cabc-f780-4722-8e76-544f17e8b59f', N'CS75', N'1d77749a-b193-44ab-aeb2-a6fc0275ff40')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ca8de819-9c73-40a3-96b7-86e1f5300b79', N'Auris', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ca9583e8-1099-4584-8501-5b5bb1e03520', N'2', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cb37bfcf-4313-4c95-a48e-19a082b5285a', N'Ulysse', N'14c02a8f-81b0-4a5b-b191-d983aec6fab1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cb5666ee-cd93-4c4b-8c03-20d43ad461e9', N'Sierra', N'1f2c1ee7-e902-4ce5-af78-db989fa87e6b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cbf5744c-3ddd-490a-a64e-0a5dd3990c47', N'CM-8', N'1d77749a-b193-44ab-aeb2-a6fc0275ff40')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cc153fb5-ccbc-445b-a8cb-c88ff69406ef', N'Porte', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cc3514d3-b483-41d4-903f-7433da5adf36', N'Skala', N'c3971358-82c7-4881-9ecc-eaab0580c476')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cc835e09-0ef7-4a3a-b622-e2b5576b2a4e', N'Century', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cd055fd8-a2d9-4803-a565-26851ba38c5d', N'Eos', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cd2691a4-264c-4d48-8cea-5002cc467432', N'Endeavor', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cd48f78c-11f3-49ff-be0e-de43414fccf5', N'Biante', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cd62da7a-f44a-4f56-bcb5-d1d3db257a46', N'Ibiza', N'83d16608-e410-44bc-986e-13ac3e40b61c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cd645b9e-f828-42d7-86a1-3916894819f5', N'2131', N'cf259200-2168-44f6-9cbe-a1da81f82c64')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cd66a7bb-f739-46c4-9a70-a8f7c27deefd', N'Cefiro', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cd9787fd-60c4-468b-86cc-f237abe8d04a', N'SS', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cdba8120-0368-44de-aa34-36f9f967d4de', N'VUE', N'32c777b4-932a-41aa-b733-d7fa0dcc1008')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cdf6635b-f88d-4d8a-999f-fc06d53c8134', N'9-5', N'f2070ff6-7dd1-42e3-95c2-d8f992349b17')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ce500d72-7322-4c62-ad18-49b553741c3f', N'Simbo', N'8adcfe2e-2baf-4545-b88a-d1fd96c97d9e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ce7291cc-8b48-474d-b43f-15a186750e3a', N'M8', N'58fc5b57-330e-446f-be55-a6a11e237d49')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ce97eeac-682f-47ac-b114-892d5ee6319c', N'C-30', N'b4231ec5-38f6-49a3-ab06-0cd7d317d319')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ce9cae19-7a69-4c65-a71d-5df2f80ab65f', N'C-Crosser', N'6f581d7e-2891-4f4f-bbde-d4a93fea8642')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cea3d2bc-1ce3-4e6c-8266-4b11886f7ddc', N'Q40', N'389c609f-88a4-4cf5-83fa-254494750ef5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cebd3a70-da40-498a-aedd-ec2d58054431', N'Elgrand', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cee0271a-4b96-4930-8d63-58cb75602ef9', N'X5', N'b6c521f7-196b-4e8a-ae22-77b8005cfa92')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cf2b4970-009d-4ebc-b176-a4690e72dff9', N'CR-V', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cf6122a7-9888-461a-8a82-986255b39aa7', N'Xpander', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cf68015f-cd2c-4639-93ac-876d5206af85', N'Tosca', N'8d78b1b2-490e-4082-829d-47dc3e93406b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cf90de4a-1bb6-40b3-91d2-0f11d7f57f26', N'8C', N'b76437ce-50b6-470a-99f2-8aa6af492aa5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cfba1269-f160-4e1c-87e2-3ecbb8161c9e', N'C31', N'5286a8dc-ae0c-45e4-9cca-d1ab9e339b8d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cfbca4ba-bab6-45a5-8a50-dea407f48d99', N'Sportster', N'b32970fd-c6ff-4b5f-b9ca-1df5ef065c9f')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cfd3fa2c-9d07-47c7-bb03-541e376b60c3', N'Delta', N'69028d61-d882-4d03-8248-3baa2bbbbe8e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cfe5b509-c433-40ab-ae27-73283409cb49', N'Xylo', N'7c37d988-d24e-45d4-aca0-0fdc66615efa')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'cfe60d64-a379-4984-94b8-3cf4f0f77f44', N'Ignis', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd0346721-a4b1-4b0b-9c0b-ac8e32be76a8', N'Solstice', N'650dd48c-6055-4ef5-a6ce-fdb2b8004110')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd0586e59-7cc3-4142-ab3a-55af4ca58a70', N'Clio', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd05f9053-766c-4a8d-a5ba-efee35661c60', N'2105', N'cf259200-2168-44f6-9cbe-a1da81f82c64')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd07adb36-72e6-4691-b50f-6813d521678b', N'Forza', N'c49c2b77-4aa9-49b4-a517-62b95953b90e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd0bc1a87-9859-464f-a9b4-aaf6caf19518', N'XF', N'c1a9c207-b6e3-4ecc-a497-5c8cb74e3f9d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd0d38921-4a05-4534-b35d-ac2f3e77a478', N'Corsa', N'34766825-53a8-4663-b280-6a7a8ef4d695')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd105e9bf-4dcc-46c2-9d08-10415dfa8fc9', N'6', N'19bdb5ae-b06b-4de4-a472-35af19deb085')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd1d2a3ee-01cb-4df9-a5ca-cb108e1e7ecc', N'Sarir', N'84666b05-b003-46f2-8b5b-34cf63496380')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd22142a1-05fe-4844-91b6-66f530391bd8', N'Skyline', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd258f102-86ef-4a39-85f0-d1b2508b61d5', N'DS5', N'6f581d7e-2891-4f4f-bbde-d4a93fea8642')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd26847ce-e714-4067-b762-f7cd37d7dedb', N'Leon', N'83d16608-e410-44bc-986e-13ac3e40b61c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd281918b-b082-4a88-bf88-d2b8eeb49670', N'Astra', N'de3d4ee5-78b5-41f9-8362-086032c1b98a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd291ac91-ff53-415b-8229-8367f15f3129', N'C-Quatre', N'6f581d7e-2891-4f4f-bbde-d4a93fea8642')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd30cda97-6038-4af6-b70e-ba72d13aa0ee', N'Safrane', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd30f0c9a-62a8-497b-854c-fabe6811c80d', N'Esse', N'8e27171b-9aa7-4082-930f-3ae388187d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd38f8a67-b38f-4068-8e85-c4f8707f035a', N'H3', N'256b72ba-6e7d-428b-bced-c5016ee2fea6')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd3f45840-c932-41e4-a104-f5a0e386fcd0', N'Nautica', N'68e7f8c1-ae77-491b-9cdf-bd1ff34a714e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd40fcf2a-2042-4351-9d60-c83113bc877c', N'E10', N'c71181e3-f0b5-4582-9f55-2136aff9a0ce')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd44532fc-6ee7-4a60-9686-d14ebed3b0a7', N'MR', N'963548b9-5235-447e-81ac-ee61c43b7c91')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd44b1673-00ac-42e0-abf7-675db11bb96e', N'Lightning', N'0e45ac5d-f928-4e1f-afd6-b517bbf2021c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd4afb3f6-c44c-4942-934b-35b3b1bb4aa9', N'Aslan', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd4d9807e-c817-4154-bf68-ede705047bc8', N'City', N'ccadb653-ebb9-4853-aa5e-efe7e7d9ff77')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd530ba5d-6c30-4420-b5be-f8dba7fd5e95', N'SRX', N'7f828726-e39d-48ba-b140-cbcffb570f89')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd5a9c11b-2836-4d15-b5a7-05f7773d111e', N'Alto', N'd187a531-c710-4495-bb5c-d158f7d0aad0')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd5e17347-aab6-439b-aa65-b9b874d56843', N'Symbol', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd5fc1113-eb14-4af7-88a4-f032fba6625b', N'Solio', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd67ebfeb-5814-4bda-803a-0590127bb5c8', N'R2', N'acf4fa9c-78fc-4751-ae5e-58cced695daf')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd6c49f0a-2fd7-4f10-91b4-898ddfc9a883', N'Twingo', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd7047ab2-0d94-4ae7-aed3-b9a6e411fc56', N'Galue', N'4a69ad3b-7286-4123-bf65-fcd4d56f07b8')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd710d326-179a-4796-abb9-bda22a417950', N'Tigra', N'34766825-53a8-4663-b280-6a7a8ef4d695')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd7366b36-1970-430a-9c6c-cc10560844ad', N'Odyssey', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd74581bb-da25-4ae3-a5b0-30c0296d03e6', N'K3', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd8046c6a-7577-4062-9a79-05d32906db0a', N'Rapid', N'8ee43737-d062-4d88-90c1-3a28a6d36632')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd8528e03-37ff-46a4-8f9f-09ac3f3ec1cf', N'GX', N'fdda3ac0-16db-45de-9950-13429f9971e3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd85d7142-a612-4596-bf95-855891a17999', N'Boon', N'8e27171b-9aa7-4082-930f-3ae388187d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd8780e98-9803-4777-afa0-1b0f5f4741c4', N'Agila', N'34766825-53a8-4663-b280-6a7a8ef4d695')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd87bc85b-dd8a-41ed-84b3-4feec68c4b1d', N'Vanguard', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd8a13798-e5b0-48bc-be6f-4b881283dcf9', N'MU-X', N'ffed9373-9b26-47d7-82ca-8564db8fbd20')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd904b08e-d428-48c4-a1d7-c08a0dc2d11f', N'Lucerne', N'905f0904-5f99-4106-8df8-5f7378bbfcfc')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd9053f7a-df46-475e-8b35-b816689d409b', N'Caliber', N'b43b29a9-866d-4d88-b02d-1b114bdc6d3a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd956c0b9-7a41-4373-a2a8-de743856094b', N'GT', N'5700d1b1-1b35-490e-9055-5dc414f6e24f')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd96931eb-9a3e-4494-9036-451889869a08', N'ISis', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd96aec9b-b616-453b-8da8-d068ddc39fe6', N'ProAce', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'd9bdf625-3060-445a-a3ec-5170aee2b539', N'CX-9', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'da0cb771-52f0-430d-9b1c-6d96af16b2fe', N'Wingle', N'72cc10f3-daa0-40c6-9f4e-cdad4277b13a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'da14a2be-2d27-448d-88e1-e84fc3e84c55', N'Dignity', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'da678adb-279a-4b1a-bb65-72d551b3a56a', N'A3', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'daf97496-1b51-443d-831c-9e4d25837e94', N'Sail', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'db5f4cf8-02a6-4b66-867c-940846fc5744', N'1er', N'b6c521f7-196b-4e8a-ae22-77b8005cfa92')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'db7dfbf4-b182-4488-8f1e-058959e01e4b', N'Savvy', N'3d95e465-7b8e-47cf-99e8-f2e6f90828a0')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'db7f1e8e-fb93-4bf3-80e7-045db0043164', N'Levorg', N'69e3fd0f-f18c-45a7-9b61-32b2781fd652')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'dbbdecc1-7b8d-4b07-9ee6-2c38b0952260', N'APV', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'dbcb7ed8-3502-4e1c-a07c-0f41a1018c6a', N'Runna', N'84666b05-b003-46f2-8b5b-34cf63496380')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'dbe9192d-610d-4e81-8de3-3aaf9eb3fe85', N'SV12', N'bc02b10f-9445-45a2-9895-f480497eefbc')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'dc3066ce-4306-4744-8e50-3ea503fcbd0e', N'Nemo', N'6f581d7e-2891-4f4f-bbde-d4a93fea8642')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'dc3984e7-e66b-44c8-9a89-e1578e5c6c5e', N'Macan', N'df50fb40-52db-40f2-a20b-8a93dc967e62')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'dc92f2b6-8fd7-4db8-8b3c-82c46c71867a', N'C-MAX', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'dcbdada2-dbc1-48be-a199-4da2be63e415', N'Aria', N'3685ab0b-33d1-4903-bc78-1e0051a97beb')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'dcc13f8b-71b8-4937-8922-8ca06e14119f', N'Boxster', N'df50fb40-52db-40f2-a20b-8a93dc967e62')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'dcc71c06-4d18-4973-961e-3f71708b0b13', N'bB', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'dce78320-b5cf-452f-9968-e0102bc97efc', N'Spiano', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'dd558765-36b9-4cc0-b2e2-de76d55ade0d', N'Raeton', N'1d77749a-b193-44ab-aeb2-a6fc0275ff40')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ddad0370-9d11-44a1-aebb-7a1c163c02b4', N'Arona', N'83d16608-e410-44bc-986e-13ac3e40b61c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ddb08a4a-852e-47af-af53-d8547b57988e', N'9-4X', N'f2070ff6-7dd1-42e3-95c2-d8f992349b17')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ddc8ca85-1ee8-4c4d-b8b0-2fd9f9485504', N'Q70', N'389c609f-88a4-4cf5-83fa-254494750ef5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ddf9ff75-370b-4d0e-af29-0371b4ae90bd', N'Thema', N'69028d61-d882-4d03-8248-3baa2bbbbe8e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'de36a49d-c1fe-48b9-a1bb-1b4db2c455f0', N'62', N'41f521a5-bf5f-44fe-8cb1-1e41ceb3ddef')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'de4021cf-d0e9-4924-9624-4c284972c7ca', N'TSX', N'edcae123-7e98-4f7b-bbb0-d76306ea4d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'de4f193b-6eb3-4c99-b62e-049d6fb4bb33', N'Taurus', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'df364f2e-ef90-4b47-96c2-96b8b6eb2d3e', N'4', N'b5a7ddcd-46af-4470-a0ea-ff57f8aace5e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'dfda97df-4fc3-4852-a5a1-e4445c5b0d0e', N'Kancil', N'68e7f8c1-ae77-491b-9cdf-bd1ff34a714e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'dfea77d1-b3fa-4063-b0c3-883ec4555313', N'Yukon', N'1f2c1ee7-e902-4ce5-af78-db989fa87e6b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'dfef37bd-12b0-4bff-8f79-f3df21e0af39', N'Probox', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e04628b5-dd4f-435c-a03f-7cd95aae521b', N'Verso-S', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e0616842-7647-46f9-8afd-8841267ca78f', N'750', N'19bdb5ae-b06b-4de4-a472-35af19deb085')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e0775812-e7f1-4205-a66c-064530a9df7e', N'Premacy', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e0b4f2cf-6415-4a14-8a4f-abc394121b0d', N'Atlas', N'963548b9-5235-447e-81ac-ee61c43b7c91')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e0eeff83-656c-414e-b5f8-e5aa5e322b46', N'Juke', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e0f3c04a-7e39-41b9-ae47-53490fc260f5', N'2329', N'cf259200-2168-44f6-9cbe-a1da81f82c64')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e119b6a0-3f5c-4f28-92f7-0308948877fa', N'PS-10', N'a0f006e7-6207-4b14-b6f9-caf0f724a3eb')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e18e21d7-49f7-43e6-9c8d-d8f4dc2c2baa', N'Korando', N'2e3d2ec9-e633-48c4-9414-02d86f7179bf')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e1b4b0c1-d3b4-4dc3-9789-185cb99bb070', N'Noble', N'be0f166b-3c26-44be-9bc3-dd8f26954816')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e1cbe9e8-aa49-44b5-9e22-d58cd33a5f43', N'i30', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e1e6d12c-d6b3-4f1a-ae4a-91697c2e811b', N'V12', N'2cd71503-5bcd-4f65-baf1-14e1b01d845b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e1f7227d-3bde-4de3-9994-14a7c7c7621a', N'Opirus', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e233775a-ef64-43e6-8036-cb8a3ff854c0', N'M', N'389c609f-88a4-4cf5-83fa-254494750ef5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e267dee6-00ed-4f7b-9427-13e2412a36b2', N'Moco', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e2cdeee2-a342-4552-a4f9-e2868a48405c', N'807', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e3267706-307d-4da6-a921-8fa2d891c8ae', N'Twizy', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e3e1dbdc-d5f5-49a9-b665-48affff7ef88', N'Celerio', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e4165ebf-627e-4e16-86a4-a18f15e29732', N'MKZ', N'a90381f4-56aa-4c45-99dc-22346ed3bb1f')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e42568c9-24a6-4503-a786-6a5e407728ca', N'Cee''d', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e44be69e-d9e8-4365-aec8-3b21617f4acd', N'WRX', N'69e3fd0f-f18c-45a7-9b61-32b2781fd652')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e4633473-05b3-4080-aa75-dc9dace11b27', N'Samand', N'84666b05-b003-46f2-8b5b-34cf63496380')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e4ae6407-a458-4f14-ac9d-a6a0eecab71a', N'Attrage', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e4ceb5bf-d2e0-4b54-887a-74605dec79ac', N'XV', N'69e3fd0f-f18c-45a7-9b61-32b2781fd652')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e4d1eb6e-dec3-4c05-86df-644e59a79539', N'4C', N'b76437ce-50b6-470a-99f2-8aa6af492aa5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e51375df-4ae0-4289-a053-44440be78d70', N'Lotze', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e53d1b52-f011-4c0b-a112-412a54a474e4', N'RS3', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e58acf8b-c54b-4e5a-9cef-94dbc45abe48', N'XFR', N'c1a9c207-b6e3-4ecc-a497-5c8cb74e3f9d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e59224dc-4638-4047-9f0b-a8ff20cb5afb', N'Actyon', N'2e3d2ec9-e633-48c4-9414-02d86f7179bf')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e64eeab4-c1f8-4db9-af1b-61c83d81b2bc', N'Azure', N'49d0c5c3-edca-4af4-8f5c-78fd3c8ed045')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e66343ea-32a1-4860-89f2-eec9573a4cb3', N'Forenza', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e69ec34d-fc9c-4246-9e1f-1d35c16d7170', N'Crew', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e7309f35-2e7b-451c-ab97-ff525b694a93', N'Centennial', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e7435007-d294-4605-9c47-2664ab7da248', N'XKR', N'c1a9c207-b6e3-4ecc-a497-5c8cb74e3f9d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e7d75ae3-dee2-45a3-885a-a65a6ee79000', N'Ipsum', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e7dee17e-d39b-4e04-aab4-741f09a4a6b1', N'iM', N'73f94dd1-9da3-413f-9d2b-2b7f0486d625')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e804e45f-b82f-4753-a698-3c770533a995', N'Scenic', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e80ad22c-16da-4afa-bf0b-795bbaf61897', N'Winstorm', N'8d78b1b2-490e-4082-829d-47dc3e93406b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e83ef6d2-0f64-4a24-b857-3c4f1a841d21', N'Rio', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e8528dab-9cc5-4ebd-a4ab-c885121b8466', N'B1', N'177c5afd-4233-4d10-b4ce-64887ca70fed')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e87e072f-2266-47c0-a262-0b46b8650fbc', N'City', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e8b16096-da68-45cc-b529-f542e393ab2e', N'200', N'88242ad7-6c82-4609-9f14-04f7f7c5ff38')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e8f81364-0cae-44dc-b639-453af3e216f6', N'Raum', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e97c0af1-e11d-4cc0-b8cc-265917c00b6b', N'xD', N'73f94dd1-9da3-413f-9d2b-2b7f0486d625')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e9c36a96-e712-42b2-a237-b35ff4d2baab', N'G6', N'650dd48c-6055-4ef5-a6ce-fdb2b8004110')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'e9f7da8f-c7fe-451f-9db0-a83b7926c6ad', N'Tanto', N'8e27171b-9aa7-4082-930f-3ae388187d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ea0b6760-560a-4976-96a5-2decaa09e446', N'Brera', N'b76437ce-50b6-470a-99f2-8aa6af492aa5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'eb296083-1ef5-49be-a7d6-1ed657c71782', N'Karl', N'34766825-53a8-4663-b280-6a7a8ef4d695')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'eb52531b-76f2-47ce-8aad-6bb25fe99b24', N'Mii', N'83d16608-e410-44bc-986e-13ac3e40b61c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ec103eff-dcf7-41ca-94b9-cfb9cada934b', N'Reventon', N'10481089-df33-4439-b1c0-4e29cbc277d0')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ec2fe044-d9a3-42e9-a9fe-86884a21c08f', N'L200', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ec805218-db49-4b2f-a6cf-505765dc86e2', N'Ambassador', N'e324cfc2-ca55-4290-8a98-d614b3301011')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ecdf864b-d265-4270-a539-ab791e6c3b06', N'Elantra', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ed3e0532-86f4-411d-b676-d3b590218c27', N'XC60', N'23c344a0-d700-41e9-91a5-3cd4a9d9ef0c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ed45bb42-dd4c-4953-9644-80884dea8226', N'Forfour', N'34bbe093-f658-4a12-a1ba-b59659436228')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ed6b3a29-b307-4928-ae56-8e418cadb42b', N'Magnum', N'b43b29a9-866d-4d88-b02d-1b114bdc6d3a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ed6c8992-4cbc-4bf2-9e7e-a335cab2a4bd', N'Amarok', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ed841d6f-5d70-4911-8db3-ea0f63adbd73', N'Dena', N'84666b05-b003-46f2-8b5b-34cf63496380')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'edb61316-5cf7-45ee-a85e-ecd582ac2e70', N'Sedona', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ee51974f-07c4-4f03-bfb7-b7ed49767117', N'Pleo', N'69e3fd0f-f18c-45a7-9b61-32b2781fd652')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ee75a55d-c849-4b2a-ac37-4e075c0f3e3d', N'407', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ee853863-a7a4-461e-ad9a-bcecd993e3cb', N'FF', N'5b74871c-cd56-4264-872e-3cf8a781c40d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ee988343-8a79-4746-b6f2-06664a39a673', N'Spacia', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'eebb6e5b-833b-4b1a-8210-16360c7d452d', N'458', N'5b74871c-cd56-4264-872e-3cf8a781c40d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ef0e0432-9917-45f6-a9b5-f484316a7261', N'Sens', N'8d78b1b2-490e-4082-829d-47dc3e93406b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ef3e17cb-96c5-4eeb-a461-ce4c37a575dc', N'Hover', N'72cc10f3-daa0-40c6-9f4e-cdad4277b13a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ef5b5307-3356-4c79-8f2c-0ebd6b40504c', N'208', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'efda05c9-6e28-44fa-b78a-b53640041620', N'Orlando', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f007325e-6ae0-4faf-917d-949c877a76ec', N'Durango', N'b43b29a9-866d-4d88-b02d-1b114bdc6d3a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f0107bd6-b818-4955-a00d-783d9c2df235', N'Grace', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f0319165-ebd2-4315-a69e-3af2d07d8e13', N'Cadenza', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f04992b8-f2ef-4ad1-89d4-79e7019aaafa', N'Sauvana', N'7888c577-b80e-466a-a340-1f1d9b91541b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f049ba30-eabf-4719-a5f8-4f07f3b2628a', N'Navigator', N'a90381f4-56aa-4c45-99dc-22346ed3bb1f')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f059b73a-eba7-4b21-8b5d-6134c53ed66b', N'Partner', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f05d195c-d20c-40b7-a9e4-44c963c7ce8e', N'C2', N'6f581d7e-2891-4f4f-bbde-d4a93fea8642')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f0635126-e38f-4b2f-badf-34c4d866bebd', N'Kluger', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f14fe0c9-16ed-4eb0-a927-fd5a3812c3fd', N'Insight', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f15d5592-12d0-472f-b1c8-fd4ce6267e6a', N'Vellfire', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f173d17a-e6ee-4c02-b1ca-7f391789bfc5', N'Sedici', N'14c02a8f-81b0-4a5b-b191-d983aec6fab1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f174ed14-ed6c-4af1-9912-1c033a3508db', N'Splash', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f1d68314-1e6e-4cf4-af2f-2806618a3df9', N'Multipla', N'14c02a8f-81b0-4a5b-b191-d983aec6fab1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f1dbf38c-7b6d-4da4-8da2-dc1b0d904cff', N'ix20', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f1fa8ccd-f0c3-4d08-bddc-9a157440ab4e', N'H230', N'21dba530-e719-455c-8af1-14b1f75309a8')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f2758c16-bf6a-429b-a7e5-6cc654ee01bc', N'Atrai', N'8e27171b-9aa7-4082-930f-3ae388187d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f288800a-e024-4323-a8f1-8576bf19daf6', N'3', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f28ce689-1620-438b-b2a9-53c82e15505b', N'Safe', N'72cc10f3-daa0-40c6-9f4e-cdad4277b13a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f296341b-393c-402f-ae20-4c820c13226e', N'Bipper', N'9f49b15c-e105-49a2-bd71-7607c435f852')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f2a71693-c4bb-4e0b-92af-195c1e161684', N'Lanos', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f305eb48-2bda-41ba-8dd4-17c2dcebc3f5', N'Logan', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f3192917-a7f5-4856-b8bd-76f4b50b5ea2', N'Demio', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f3781d88-34f8-4fac-a966-dab56e07f770', N'Sonica', N'8e27171b-9aa7-4082-930f-3ae388187d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f38f5efa-33af-4e39-902f-05771c5b6819', N'X4', N'b6c521f7-196b-4e8a-ae22-77b8005cfa92')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f3a3873d-1821-40c2-b01f-2b6832f4cbd5', N'Viva', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f42c7d36-ed50-4dfb-b9c2-dc0b097887fe', N'Wish', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f43da560-1ede-4c51-b7fc-aa6ecbee50ea', N'V50', N'23c344a0-d700-41e9-91a5-3cd4a9d9ef0c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f46a89c8-c370-4bda-b829-59d991f49dc9', N'GO', N'356e1a07-d2d2-4e49-b14d-7381e3a493e3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f484c27d-dcc3-486d-8d6e-b27c5c001ed2', N'Mountaineer', N'd81d4572-3d43-4083-81f4-11dcea1fd1d5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f4b0ad8f-c0ee-4497-af0b-661309201b31', N'Gallardo', N'10481089-df33-4439-b1c0-4e29cbc277d0')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f4d00a5d-6d7f-46f4-a2a4-3de6772c64c6', N'Sequoia', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f5079a52-2cb3-4445-9e25-464aa410f7ac', N'S80', N'23c344a0-d700-41e9-91a5-3cd4a9d9ef0c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f50f9171-dc66-40aa-9cc1-b94403a84331', N'Croma', N'14c02a8f-81b0-4a5b-b191-d983aec6fab1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f5467180-e845-4f08-8624-e4baedc90b42', N'Jetta', N'eae34886-31be-4615-bc01-a80723d8dd56')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f5f43be4-61df-465f-b279-052572212dc4', N'Tribeca', N'69e3fd0f-f18c-45a7-9b61-32b2781fd652')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f611e6e6-ac32-4189-9b14-9642ae875179', N'C4', N'6f581d7e-2891-4f4f-bbde-d4a93fea8642')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f61e58bd-4218-4fad-9fb6-d88da9c8dd8d', N'Viewt', N'4a69ad3b-7286-4123-bf65-fcd4d56f07b8')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f6954c93-31e2-42d1-861f-cb1e0ab8c95f', N'Titan', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f6d508bd-4f35-4c9e-9722-85bc18c0f42b', N'RLX', N'edcae123-7e98-4f7b-bbb0-d76306ea4d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f6edb053-5fd8-4b50-a9ec-07c515904c04', N'MK2', N'4ee6c02f-120c-4d13-88f2-e3123e6a7a55')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f72f842f-f749-429b-8ebd-568a984ac88e', N'Perdana', N'3d95e465-7b8e-47cf-99e8-f2e6f90828a0')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f75d8b2a-2453-435a-99a2-1449cd261441', N'Sonata', N'ad8b2b19-84d8-432c-b66f-ca52eed2b297')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f766570f-bdc9-47c1-b47e-3e3c496a8688', N'B2', N'177c5afd-4233-4d10-b4ce-64887ca70fed')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f7878e7b-8973-43b9-bf31-4ab097cb8c3f', N'Versa', N'd187a531-c710-4495-bb5c-d158f7d0aad0')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f78ec943-ec07-421b-a767-e8814476875f', N'Range', N'c5fb28b0-9e14-47d8-bd6d-c2c596fbc395')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f7a77e55-e630-404c-abc3-171edb840498', N'Every', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f80a673e-de43-4bad-bb30-1392a5db5285', N'Avancier', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f83f84f6-23b1-4b82-8f1b-430e3745788d', N'GT', N'34766825-53a8-4663-b280-6a7a8ef4d695')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f8514b96-220c-44ac-9a93-8fb862e308a6', N'G80', N'07ff5590-8e45-4e10-83e9-95a946838fd3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f86ac51b-db25-44e7-9d30-ab186c216e05', N'Estima', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f87b8b0c-8d24-4973-95de-32fe6f9f53e1', N'A9', N'f05c93a2-86b0-48c2-8f10-e9b83c66435c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f88ad89a-cb24-43ad-8c36-d797d4ae66ff', N'21099', N'cf259200-2168-44f6-9cbe-a1da81f82c64')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f891694b-ca48-4e73-9480-2ae9daa27609', N'Harrier', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f8a2cad7-9832-46c7-b0f9-8459f4a32ad9', N'ZDX', N'edcae123-7e98-4f7b-bbb0-d76306ea4d2c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f8ba22b9-90f7-4cca-af7c-b27dd17f01e1', N'Saga', N'3d95e465-7b8e-47cf-99e8-f2e6f90828a0')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f8bf61fd-ed54-4239-9b6d-37bbb41cd1c9', N'Envoy', N'1f2c1ee7-e902-4ce5-af78-db989fa87e6b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f8f95090-a7fa-4745-8a2d-3b2714ea938f', N'BJ2020', N'644870e8-4fa8-435f-8239-2ba144a9c168')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f9059beb-686a-4d04-8423-346838cb6ef9', N'Voleex', N'72cc10f3-daa0-40c6-9f4e-cdad4277b13a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f9835316-3126-4d55-9046-5230de68caf3', N'Captur', N'f5c1d901-9164-453f-a0eb-f31ad5ab7a6d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'f993cd75-f4f3-4bda-bcbb-c3b3e06438de', N'540C', N'54ee342d-5260-4e91-a6b3-310715065bb3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fa050cdb-f615-42aa-af35-4a51f7879c2f', N'X9', N'4391872d-6c69-4727-9016-182f58949458')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fa3b98d9-ea3b-4a0e-8311-aab771d36b43', N'Aventador', N'10481089-df33-4439-b1c0-4e29cbc277d0')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fa9fa719-7dac-4907-8fbb-c23595a54dec', N'Voyager', N'69028d61-d882-4d03-8248-3baa2bbbbe8e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'faac5673-a83f-4006-9653-8b2c6782b234', N'S6', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fab8d7c3-eb30-432c-8991-e1b8d1049ba8', N'Phantom', N'88629d81-57ca-43ce-a44a-08d351fd95d5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fab955c9-2a33-4702-b239-081c68e748ee', N'Exige', N'2dec248f-e55c-4600-9684-f82040437771')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'faf1372b-68f4-444e-b2f9-7c02a65b1edf', N'Yugo', N'c3971358-82c7-4881-9ecc-eaab0580c476')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fafc7338-a5c1-4f8e-a117-b471edd41c7f', N'Vezel', N'595b3f88-8f37-4c94-8f31-4980a3290456')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fb039e29-5354-44fc-8207-90fcc6e890f6', N'Luxgen5', N'46cc94c1-96d7-4543-a3c4-d491988363ed')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fb173641-2810-47b8-a662-c6dfd7800a26', N'GL-klasse', N'f3113047-cd76-4253-9202-7d61b65aece5')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fb37facb-063f-41fa-818a-9c88d8b4f98f', N'MX-5', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fb5676d9-8c5d-42ca-aa5c-9c23cb8be166', N'Fighter', N'f4c9c3ec-be25-4f67-a604-ab5132543458')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fb5ff875-8463-408f-ab4b-3d14b3848ead', N'Myway', N'19c80c17-0c84-484b-9b83-59e5e4bed901')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fb8ed851-104b-476b-b551-b81a8241d920', N'Like', N'4a69ad3b-7286-4123-bf65-fcd4d56f07b8')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fba5e527-6ad3-4279-99a2-ffa3b3f53805', N'E6', N'40c5b314-71b6-4f7d-93f3-e445ede15e3b')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fbb90654-b438-453d-acc8-b56ea8c4da75', N'XJR', N'c1a9c207-b6e3-4ecc-a497-5c8cb74e3f9d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fc1f9d8e-3c9d-45d2-9078-b4954f79f4f3', N'Volt', N'e4a6fc12-599b-491c-9b1b-857a49967138')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fc4e09cb-4b20-4a44-98b4-af6f78ab893a', N'600', N'14c02a8f-81b0-4a5b-b191-d983aec6fab1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fc4ef036-b69f-4b94-bada-4d8d36b0f5db', N'Hustler', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fc7912f7-b24e-4461-9fb5-71023c0a1ed0', N'Stella', N'69e3fd0f-f18c-45a7-9b61-32b2781fd652')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fcfe4c93-180d-4ad2-b173-7318ecfb8e1f', N'Ghibli', N'68b81e8d-38c9-4b25-843c-40464738f496')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fd1f2418-35cd-4f62-ad82-62c38e666b8a', N'Escape', N'bf41e991-1131-4d81-b303-5721dc8ccc85')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fd47bf2a-dd13-4de9-8980-208ca64f8827', N'SQ5', N'e010be8c-1270-4b16-8e46-ca172ad9f83c')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fd957846-1f48-4052-8369-d04b0072c0e5', N'Atenza', N'311de51c-da1f-44e2-9ea6-e892736a8ef1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fdd87def-90dc-4b5b-a421-bf222167fde2', N'Safari', N'3685ab0b-33d1-4903-bc78-1e0051a97beb')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fdfda0c6-2df0-4674-853f-140457986d8f', N'Pacifica', N'88242ad7-6c82-4609-9f14-04f7f7c5ff38')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fe09d29b-904e-4532-be9d-9fcdfff7399b', N'K9', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fe1fcada-6931-499e-80ea-b5bb08da5794', N'Proudia', N'91a568a5-6cc4-4031-a92f-3f95465820d1')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fe2032c3-db36-43fd-9ea8-c9ec8a1a96c4', N'Picanto', N'eae3b358-72a7-4142-992c-73d0f7c7b42a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fe6670b0-b297-4ad8-9ab3-c91ec3163450', N'Teana', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fe722069-e255-412a-8871-369f9d7a82a0', N'mi-DO', N'356e1a07-d2d2-4e49-b14d-7381e3a493e3')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fe9a2300-3261-4144-a0eb-d3dfe95b8461', N'Qashqai+2', N'c31d0250-b2a8-40ab-89b6-73d720b6790e')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fea13972-30a5-4166-9667-84e5a927df9e', N'C51', N'5286a8dc-ae0c-45e4-9cca-d1ab9e339b8d')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'fea45d02-bd11-47ca-94fb-312d82957c54', N'RAM', N'b43b29a9-866d-4d88-b02d-1b114bdc6d3a')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'feb6ffd4-48d9-4833-ab0c-431a9f2594de', N'Spade', N'02b02a48-0436-4539-b691-53ade2d22356')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ff04d959-1b46-423d-ab39-753d3606c1e6', N'Karma', N'17218203-3c59-4c93-a81a-062527fc92c6')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ff1281d8-8942-4022-a0a1-fa1b15d82ba6', N'Reno', N'75849315-0706-4ed8-bea4-2c7fcac21489')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ff6890c6-e992-44d6-abde-705c865c082b', N'Baodian', N'c8f02bff-be7e-4c21-a997-a82cade70a28')
INSERT [dbo].[VehicleModels] ([Id], [Name], [ManufactirerId]) VALUES (N'ffb97a36-92c4-423d-94ae-ba4e431ba95b', N'CT6', N'7f828726-e39d-48ba-b140-cbcffb570f89')
ALTER TABLE [dbo].[Cars] ADD  DEFAULT ((0)) FOR [ISFinished]
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
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_Departments_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_Departments_DepartmentId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_Customers_CustomerId]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Departments_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_Departments_DepartmentId]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_FuelTypes_FuelTypeId] FOREIGN KEY([FuelTypeId])
REFERENCES [dbo].[FuelTypes] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_FuelTypes_FuelTypeId]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_TransmissionTypes_TransmissionId] FOREIGN KEY([TransmissionId])
REFERENCES [dbo].[TransmissionTypes] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_TransmissionTypes_TransmissionId]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_VehicleManufacturers_ManufactureID] FOREIGN KEY([ManufactureID])
REFERENCES [dbo].[VehicleManufacturers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_VehicleManufacturers_ManufactureID]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_VehicleModels_ModelId] FOREIGN KEY([ModelId])
REFERENCES [dbo].[VehicleModels] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_VehicleModels_ModelId]
GO
ALTER TABLE [dbo].[Part]  WITH CHECK ADD  CONSTRAINT [FK_Part_Cars_CarId] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([Id])
GO
ALTER TABLE [dbo].[Part] CHECK CONSTRAINT [FK_Part_Cars_CarId]
GO
ALTER TABLE [dbo].[RepairTypes]  WITH CHECK ADD  CONSTRAINT [FK_RepairTypes_AspNetUsers_MechanicId] FOREIGN KEY([MechanicId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RepairTypes] CHECK CONSTRAINT [FK_RepairTypes_AspNetUsers_MechanicId]
GO
ALTER TABLE [dbo].[RepairTypes]  WITH CHECK ADD  CONSTRAINT [FK_RepairTypes_Cars_CarId] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RepairTypes] CHECK CONSTRAINT [FK_RepairTypes_Cars_CarId]
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FK_Service_Cars_CarId] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FK_Service_Cars_CarId]
GO
ALTER TABLE [dbo].[ServiceParts]  WITH CHECK ADD  CONSTRAINT [FK_ServiceParts_Part_PartId] FOREIGN KEY([PartId])
REFERENCES [dbo].[Part] ([Id])
GO
ALTER TABLE [dbo].[ServiceParts] CHECK CONSTRAINT [FK_ServiceParts_Part_PartId]
GO
ALTER TABLE [dbo].[ServiceParts]  WITH CHECK ADD  CONSTRAINT [FK_ServiceParts_Service_ServiceId] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([Id])
GO
ALTER TABLE [dbo].[ServiceParts] CHECK CONSTRAINT [FK_ServiceParts_Service_ServiceId]
GO
ALTER TABLE [dbo].[ServiceRepairs]  WITH CHECK ADD  CONSTRAINT [FK_ServiceRepairs_RepairTypes_RepairId] FOREIGN KEY([RepairId])
REFERENCES [dbo].[RepairTypes] ([Id])
GO
ALTER TABLE [dbo].[ServiceRepairs] CHECK CONSTRAINT [FK_ServiceRepairs_RepairTypes_RepairId]
GO
ALTER TABLE [dbo].[ServiceRepairs]  WITH CHECK ADD  CONSTRAINT [FK_ServiceRepairs_Service_ServiceId] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([Id])
GO
ALTER TABLE [dbo].[ServiceRepairs] CHECK CONSTRAINT [FK_ServiceRepairs_Service_ServiceId]
GO
ALTER TABLE [dbo].[VehicleModels]  WITH CHECK ADD  CONSTRAINT [FK_VehicleModels_VehicleManufacturers_ManufactirerId] FOREIGN KEY([ManufactirerId])
REFERENCES [dbo].[VehicleManufacturers] ([Id])
GO
ALTER TABLE [dbo].[VehicleModels] CHECK CONSTRAINT [FK_VehicleModels_VehicleManufacturers_ManufactirerId]
GO
