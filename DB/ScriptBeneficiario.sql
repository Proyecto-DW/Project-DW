USE [master]
GO
/****** Object:  Database [beneficiariosdb]    Script Date: 10/10/2023 20:57:25 ******/
CREATE DATABASE [beneficiariosdb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'beneficiariosdb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\beneficiariosdb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'beneficiariosdb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\beneficiariosdb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [beneficiariosdb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [beneficiariosdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [beneficiariosdb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [beneficiariosdb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [beneficiariosdb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [beneficiariosdb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [beneficiariosdb] SET ARITHABORT OFF 
GO
ALTER DATABASE [beneficiariosdb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [beneficiariosdb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [beneficiariosdb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [beneficiariosdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [beneficiariosdb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [beneficiariosdb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [beneficiariosdb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [beneficiariosdb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [beneficiariosdb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [beneficiariosdb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [beneficiariosdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [beneficiariosdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [beneficiariosdb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [beneficiariosdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [beneficiariosdb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [beneficiariosdb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [beneficiariosdb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [beneficiariosdb] SET RECOVERY FULL 
GO
ALTER DATABASE [beneficiariosdb] SET  MULTI_USER 
GO
ALTER DATABASE [beneficiariosdb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [beneficiariosdb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [beneficiariosdb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [beneficiariosdb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [beneficiariosdb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [beneficiariosdb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'beneficiariosdb', N'ON'
GO
ALTER DATABASE [beneficiariosdb] SET QUERY_STORE = ON
GO
ALTER DATABASE [beneficiariosdb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [beneficiariosdb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/10/2023 20:57:26 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AsignacionBeneficios]    Script Date: 10/10/2023 20:57:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsignacionBeneficios](
	[IdAsignacion] [int] IDENTITY(1,1) NOT NULL,
	[IdBeneficiario] [int] NULL,
	[IdBeneficio] [int] NULL,
	[FechaAsignacion] [date] NULL,
 CONSTRAINT [PK__Asignaci__A7235DFF8A358FB8] PRIMARY KEY CLUSTERED 
(
	[IdAsignacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Beneficiarios]    Script Date: 10/10/2023 20:57:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beneficiarios](
	[IdBeneficiario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NULL,
	[Apellidos] [varchar](255) NULL,
	[FechaNacimiento] [date] NULL,
	[Direccion] [varchar](255) NULL,
	[Telefono] [varchar](15) NULL,
	[IdPadre] [int] NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK__Benefici__3D23355FCE2D3011] PRIMARY KEY CLUSTERED 
(
	[IdBeneficiario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Beneficios]    Script Date: 10/10/2023 20:57:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beneficios](
	[IdBeneficio] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NULL,
	[Descripcion] [text] NULL,
 CONSTRAINT [PK__Benefici__14B7CA0CCD1E7583] PRIMARY KEY CLUSTERED 
(
	[IdBeneficio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colaboradores]    Script Date: 10/10/2023 20:57:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colaboradores](
	[IdColaborador] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NULL,
	[Apellidos] [varchar](255) NULL,
	[DPI] [varchar](15) NULL,
	[Correo] [varchar](255) NULL,
	[Direccion] [varchar](255) NULL,
	[Telefono] [varchar](15) NULL,
	[FechaNacimiento] [date] NULL,
	[Genero] [varchar](10) NULL,
	[IdPuesto] [int] NULL,
 CONSTRAINT [PK__Colabora__3D2CA512B04CA523] PRIMARY KEY CLUSTERED 
(
	[IdColaborador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modulo]    Script Date: 10/10/2023 20:57:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modulo](
	[IdModulo] [int] IDENTITY(1,1) NOT NULL,
	[Modulo] [varchar](50) NULL,
	[FechaCreacion] [datetime2](7) NULL,
 CONSTRAINT [PK_Modulo] PRIMARY KEY CLUSTERED 
(
	[IdModulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operacion]    Script Date: 10/10/2023 20:57:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operacion](
	[IdOperacion] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[IdModulo] [int] NULL,
 CONSTRAINT [PK_Operacion] PRIMARY KEY CLUSTERED 
(
	[IdOperacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PadresDeFamilia]    Script Date: 10/10/2023 20:57:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PadresDeFamilia](
	[IdPadre] [int] IDENTITY(1,1) NOT NULL,
	[NombrePadre] [varchar](255) NULL,
	[ApellidoPadre] [varchar](255) NULL,
	[TelefonoPadre] [varchar](15) NULL,
	[NombreMadre] [varchar](255) NULL,
	[ApellidosMadre] [varchar](255) NULL,
	[TelefonoMadre] [varchar](15) NULL,
	[DireccionPadre] [varchar](255) NULL,
	[DireccionMadre] [varchar](255) NULL,
 CONSTRAINT [PK__PadresDe__045356902EEAB2E3] PRIMARY KEY CLUSTERED 
(
	[IdPadre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patrocinadores]    Script Date: 10/10/2023 20:57:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patrocinadores](
	[IdPatrocinador] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NULL,
	[Descripcion] [text] NULL,
	[Contacto] [varchar](255) NULL,
	[Telefono] [varchar](15) NULL,
	[Correo] [varchar](255) NULL,
	[Estado] [bit] NOT NULL,
	[IdBeneficiario] [int] NULL,
 CONSTRAINT [PK__Patrocin__FCC34B4F45E077C3] PRIMARY KEY CLUSTERED 
(
	[IdPatrocinador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patrocinio]    Script Date: 10/10/2023 20:57:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patrocinio](
	[IdPatrocinio] [int] IDENTITY(1,1) NOT NULL,
	[IdPatrocinador] [int] NULL,
	[IdBeneficiario] [int] NULL,
 CONSTRAINT [PK__Patrocin__C2F5DE5E7D4509C1] PRIMARY KEY CLUSTERED 
(
	[IdPatrocinio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puestos]    Script Date: 10/10/2023 20:57:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puestos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombrePuesto] [varchar](50) NULL,
	[FechaCreaciom] [datetime] NULL,
 CONSTRAINT [PK_Puestos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol_operacion]    Script Date: 10/10/2023 20:57:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol_operacion](
	[IdAsignacionRol] [int] IDENTITY(1,1) NOT NULL,
	[IdRol] [int] NULL,
	[IdOperacion] [int] NULL,
 CONSTRAINT [PK_Rol_operacion] PRIMARY KEY CLUSTERED 
(
	[IdAsignacionRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 10/10/2023 20:57:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK__Roles__2A49584C9A0BFE90] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 10/10/2023 20:57:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [varchar](255) NULL,
	[Correo] [varchar](255) NULL,
	[Clave] [varchar](255) NULL,
	[Estado] [bit] NOT NULL,
	[IdRol] [int] NULL,
 CONSTRAINT [PK__Usuarios__5B65BF97B476837D] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_AsignacionBeneficios_IdBeneficiario]    Script Date: 10/10/2023 20:57:26 ******/
CREATE NONCLUSTERED INDEX [IX_AsignacionBeneficios_IdBeneficiario] ON [dbo].[AsignacionBeneficios]
(
	[IdBeneficiario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AsignacionBeneficios_IdBeneficio]    Script Date: 10/10/2023 20:57:26 ******/
CREATE NONCLUSTERED INDEX [IX_AsignacionBeneficios_IdBeneficio] ON [dbo].[AsignacionBeneficios]
(
	[IdBeneficio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Beneficiarios_IdPadre]    Script Date: 10/10/2023 20:57:26 ******/
CREATE NONCLUSTERED INDEX [IX_Beneficiarios_IdPadre] ON [dbo].[Beneficiarios]
(
	[IdPadre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Colaboradores_IdPuesto]    Script Date: 10/10/2023 20:57:26 ******/
CREATE NONCLUSTERED INDEX [IX_Colaboradores_IdPuesto] ON [dbo].[Colaboradores]
(
	[IdPuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Operacion_IdModulo]    Script Date: 10/10/2023 20:57:26 ******/
CREATE NONCLUSTERED INDEX [IX_Operacion_IdModulo] ON [dbo].[Operacion]
(
	[IdModulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Patrocinadores_IdBeneficiario]    Script Date: 10/10/2023 20:57:26 ******/
CREATE NONCLUSTERED INDEX [IX_Patrocinadores_IdBeneficiario] ON [dbo].[Patrocinadores]
(
	[IdBeneficiario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Patrocinio_IdBeneficiario]    Script Date: 10/10/2023 20:57:26 ******/
CREATE NONCLUSTERED INDEX [IX_Patrocinio_IdBeneficiario] ON [dbo].[Patrocinio]
(
	[IdBeneficiario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Patrocinio_IdPatrocinador]    Script Date: 10/10/2023 20:57:26 ******/
CREATE NONCLUSTERED INDEX [IX_Patrocinio_IdPatrocinador] ON [dbo].[Patrocinio]
(
	[IdPatrocinador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Rol_operacion_IdOperacion]    Script Date: 10/10/2023 20:57:26 ******/
CREATE NONCLUSTERED INDEX [IX_Rol_operacion_IdOperacion] ON [dbo].[Rol_operacion]
(
	[IdOperacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Rol_operacion_IdRol]    Script Date: 10/10/2023 20:57:26 ******/
CREATE NONCLUSTERED INDEX [IX_Rol_operacion_IdRol] ON [dbo].[Rol_operacion]
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Usuarios_IdRol]    Script Date: 10/10/2023 20:57:26 ******/
CREATE NONCLUSTERED INDEX [IX_Usuarios_IdRol] ON [dbo].[Usuarios]
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Modulo] ADD  CONSTRAINT [DF__Modulo__FechaCre__6D0D32F4]  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[AsignacionBeneficios]  WITH CHECK ADD  CONSTRAINT [FK__Asignacio__IdBen__3B40CD36] FOREIGN KEY([IdBeneficiario])
REFERENCES [dbo].[Beneficiarios] ([IdBeneficiario])
GO
ALTER TABLE [dbo].[AsignacionBeneficios] CHECK CONSTRAINT [FK__Asignacio__IdBen__3B40CD36]
GO
ALTER TABLE [dbo].[AsignacionBeneficios]  WITH CHECK ADD  CONSTRAINT [FK__Asignacio__IdBen__3C34F16F] FOREIGN KEY([IdBeneficio])
REFERENCES [dbo].[Beneficios] ([IdBeneficio])
GO
ALTER TABLE [dbo].[AsignacionBeneficios] CHECK CONSTRAINT [FK__Asignacio__IdBen__3C34F16F]
GO
ALTER TABLE [dbo].[Beneficiarios]  WITH CHECK ADD  CONSTRAINT [FK__Beneficia__IdPad__30C33EC3] FOREIGN KEY([IdPadre])
REFERENCES [dbo].[PadresDeFamilia] ([IdPadre])
GO
ALTER TABLE [dbo].[Beneficiarios] CHECK CONSTRAINT [FK__Beneficia__IdPad__30C33EC3]
GO
ALTER TABLE [dbo].[Colaboradores]  WITH CHECK ADD  CONSTRAINT [FK_Colaboradores_Puestos] FOREIGN KEY([IdPuesto])
REFERENCES [dbo].[Puestos] ([Id])
GO
ALTER TABLE [dbo].[Colaboradores] CHECK CONSTRAINT [FK_Colaboradores_Puestos]
GO
ALTER TABLE [dbo].[Operacion]  WITH CHECK ADD  CONSTRAINT [FK_Operacion_Modulo] FOREIGN KEY([IdModulo])
REFERENCES [dbo].[Modulo] ([IdModulo])
GO
ALTER TABLE [dbo].[Operacion] CHECK CONSTRAINT [FK_Operacion_Modulo]
GO
ALTER TABLE [dbo].[Patrocinadores]  WITH CHECK ADD  CONSTRAINT [FK_Patrocinadores_Beneficiarios] FOREIGN KEY([IdBeneficiario])
REFERENCES [dbo].[Beneficiarios] ([IdBeneficiario])
GO
ALTER TABLE [dbo].[Patrocinadores] CHECK CONSTRAINT [FK_Patrocinadores_Beneficiarios]
GO
ALTER TABLE [dbo].[Patrocinio]  WITH CHECK ADD  CONSTRAINT [FK__Patrocini__IdBen__367C1819] FOREIGN KEY([IdBeneficiario])
REFERENCES [dbo].[Beneficiarios] ([IdBeneficiario])
GO
ALTER TABLE [dbo].[Patrocinio] CHECK CONSTRAINT [FK__Patrocini__IdBen__367C1819]
GO
ALTER TABLE [dbo].[Patrocinio]  WITH CHECK ADD  CONSTRAINT [FK__Patrocini__IdPat__3587F3E0] FOREIGN KEY([IdPatrocinador])
REFERENCES [dbo].[Patrocinadores] ([IdPatrocinador])
GO
ALTER TABLE [dbo].[Patrocinio] CHECK CONSTRAINT [FK__Patrocini__IdPat__3587F3E0]
GO
ALTER TABLE [dbo].[Rol_operacion]  WITH CHECK ADD  CONSTRAINT [FK_Rol_operacion_Operacion] FOREIGN KEY([IdOperacion])
REFERENCES [dbo].[Operacion] ([IdOperacion])
GO
ALTER TABLE [dbo].[Rol_operacion] CHECK CONSTRAINT [FK_Rol_operacion_Operacion]
GO
ALTER TABLE [dbo].[Rol_operacion]  WITH CHECK ADD  CONSTRAINT [FK_Rol_operacion_Roles] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Roles] ([IdRol])
GO
ALTER TABLE [dbo].[Rol_operacion] CHECK CONSTRAINT [FK_Rol_operacion_Roles]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Roles] ([IdRol])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Roles]
GO
USE [master]
GO
ALTER DATABASE [beneficiariosdb] SET  READ_WRITE 
GO
