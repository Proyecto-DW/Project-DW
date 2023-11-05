USE [beneficiariosdb]
GO
/****** Object:  Table [dbo].[AsignacionBeneficios]    Script Date: 03/11/2023 19:43:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsignacionBeneficios](
	[IdAsignacion] [int] IDENTITY(1,1) NOT NULL,
	[IdBeneficiario] [int] NULL,
	[IdBeneficio] [int] NULL,
	[DescripcionBeneficio] [varchar](250) NULL,
	[FechaAsignacion] [date] NULL,
	[Monto] [decimal](20, 0) NULL,
	[DPI] [nchar](16) NULL,
	[Parentesco] [varchar](250) NULL,
	[Comentarios] [text] NULL,
 CONSTRAINT [PK__Asignaci__A7235DFF8A358FB8] PRIMARY KEY CLUSTERED 
(
	[IdAsignacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Beneficiario]    Script Date: 03/11/2023 19:43:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beneficiario](
	[IdBeneficiario] [int] IDENTITY(1,1) NOT NULL,
	[NombreCompleto] [varchar](80) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Edad] [int] NOT NULL,
	[Genero] [varchar](50) NOT NULL,
	[Direccion] [varchar](120) NOT NULL,
	[TelefonoBeneficiario] [varchar](9) NULL,
	[CodigoBeneficiario] [varchar](11) NOT NULL,
	[Nivel] [varchar](20) NOT NULL,
	[NombrePadre] [varchar](50) NULL,
	[DPIPadre] [varchar](16) NULL,
	[TelefonoPadre] [varchar](9) NULL,
	[DireccionPadre] [varchar](50) NULL,
	[NombreMadre] [varchar](50) NULL,
	[DPIMadre] [varchar](16) NULL,
	[TelefonoMadre] [varchar](9) NULL,
	[DireccionMadre] [varchar](50) NULL,
	[TelefonoPrincipal] [varchar](9) NULL,
	[TelefonoSecundario] [varchar](9) NULL,
	[IdColaborador] [int] NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_Beneficiario2] PRIMARY KEY CLUSTERED 
(
	[IdBeneficiario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Beneficio]    Script Date: 03/11/2023 19:43:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beneficio](
	[IdBeneficio] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nchar](50) NULL,
	[DetalleBeneficio] [nchar](120) NULL,
	[Soporte] [nchar](50) NULL,
	[IdPatrocinador] [int] NULL,
 CONSTRAINT [PK_Beneficio] PRIMARY KEY CLUSTERED 
(
	[IdBeneficio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colaboradores]    Script Date: 03/11/2023 19:43:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colaboradores](
	[IdColaborador] [int] IDENTITY(1,1) NOT NULL,
	[NombreCompleto] [nchar](255) NULL,
	[Profesion] [nchar](120) NULL,
	[DPI] [nchar](15) NULL,
	[Correo] [nchar](255) NULL,
	[Direccion] [nchar](255) NULL,
	[Telefono] [nchar](15) NULL,
	[FechaNacimiento] [date] NULL,
	[Genero] [nchar](10) NULL,
	[IdPuesto] [int] NULL,
 CONSTRAINT [PK__Colabora__3D2CA512B04CA523] PRIMARY KEY CLUSTERED 
(
	[IdColaborador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modulo]    Script Date: 03/11/2023 19:43:56 ******/
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
/****** Object:  Table [dbo].[Operacion]    Script Date: 03/11/2023 19:43:56 ******/
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
/****** Object:  Table [dbo].[Patrocinadores]    Script Date: 03/11/2023 19:43:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patrocinadores](
	[IdPatrocinador] [int] IDENTITY(1,1) NOT NULL,
	[CodigoReferencia] [nchar](50) NULL,
	[CodigoPais] [varchar](50) NULL,
	[Estado] [bit] NULL,
	[FechaRegistro] [date] NULL,
 CONSTRAINT [PK__Patrocin__FCC34B4F45E077C3] PRIMARY KEY CLUSTERED 
(
	[IdPatrocinador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puestos]    Script Date: 03/11/2023 19:43:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puestos](
	[IdPuesto] [int] IDENTITY(1,1) NOT NULL,
	[NombrePuesto] [varchar](50) NOT NULL,
	[FechaCreacion] [date] NOT NULL,
 CONSTRAINT [PK_Puestos] PRIMARY KEY CLUSTERED 
(
	[IdPuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol_operacion]    Script Date: 03/11/2023 19:43:56 ******/
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
/****** Object:  Table [dbo].[Roles]    Script Date: 03/11/2023 19:43:56 ******/
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
/****** Object:  Table [dbo].[Usuarios]    Script Date: 03/11/2023 19:43:56 ******/
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
ALTER TABLE [dbo].[Modulo] ADD  CONSTRAINT [DF__Modulo__FechaCre__6D0D32F4]  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[AsignacionBeneficios]  WITH CHECK ADD  CONSTRAINT [FK_AsignacionBeneficios_Beneficiario] FOREIGN KEY([IdBeneficiario])
REFERENCES [dbo].[Beneficiario] ([IdBeneficiario])
GO
ALTER TABLE [dbo].[AsignacionBeneficios] CHECK CONSTRAINT [FK_AsignacionBeneficios_Beneficiario]
GO
ALTER TABLE [dbo].[AsignacionBeneficios]  WITH CHECK ADD  CONSTRAINT [FK_AsignacionBeneficios_Beneficio] FOREIGN KEY([IdBeneficio])
REFERENCES [dbo].[Beneficio] ([IdBeneficio])
GO
ALTER TABLE [dbo].[AsignacionBeneficios] CHECK CONSTRAINT [FK_AsignacionBeneficios_Beneficio]
GO
ALTER TABLE [dbo].[Beneficiario]  WITH CHECK ADD  CONSTRAINT [FK_Beneficiario_Colaboradores] FOREIGN KEY([IdColaborador])
REFERENCES [dbo].[Colaboradores] ([IdColaborador])
GO
ALTER TABLE [dbo].[Beneficiario] CHECK CONSTRAINT [FK_Beneficiario_Colaboradores]
GO
ALTER TABLE [dbo].[Beneficio]  WITH CHECK ADD  CONSTRAINT [FK_Beneficio_Patrocinadores] FOREIGN KEY([IdPatrocinador])
REFERENCES [dbo].[Patrocinadores] ([IdPatrocinador])
GO
ALTER TABLE [dbo].[Beneficio] CHECK CONSTRAINT [FK_Beneficio_Patrocinadores]
GO
ALTER TABLE [dbo].[Colaboradores]  WITH CHECK ADD  CONSTRAINT [FK_Colaboradores_Puestos] FOREIGN KEY([IdPuesto])
REFERENCES [dbo].[Puestos] ([IdPuesto])
GO
ALTER TABLE [dbo].[Colaboradores] CHECK CONSTRAINT [FK_Colaboradores_Puestos]
GO
ALTER TABLE [dbo].[Operacion]  WITH CHECK ADD  CONSTRAINT [FK_Operacion_Modulo] FOREIGN KEY([IdModulo])
REFERENCES [dbo].[Modulo] ([IdModulo])
GO
ALTER TABLE [dbo].[Operacion] CHECK CONSTRAINT [FK_Operacion_Modulo]
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id Asignación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AsignacionBeneficios', @level2type=N'COLUMN',@level2name=N'IdAsignacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id Beneficiario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AsignacionBeneficios', @level2type=N'COLUMN',@level2name=N'IdBeneficiario'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id Beneficio' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AsignacionBeneficios', @level2type=N'COLUMN',@level2name=N'IdBeneficio'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripcion Beneficio' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AsignacionBeneficios', @level2type=N'COLUMN',@level2name=N'DescripcionBeneficio'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha Asignación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AsignacionBeneficios', @level2type=N'COLUMN',@level2name=N'FechaAsignacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DPI Recibe' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AsignacionBeneficios', @level2type=N'COLUMN',@level2name=N'DPI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parentesco' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AsignacionBeneficios', @level2type=N'COLUMN',@level2name=N'Parentesco'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id Colaborador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Colaboradores', @level2type=N'COLUMN',@level2name=N'IdColaborador'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre Completo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Colaboradores', @level2type=N'COLUMN',@level2name=N'NombreCompleto'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DPI Colaborador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Colaboradores', @level2type=N'COLUMN',@level2name=N'DPI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Correo Electrónico' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Colaboradores', @level2type=N'COLUMN',@level2name=N'Correo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dirección' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Colaboradores', @level2type=N'COLUMN',@level2name=N'Direccion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Teléfono' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Colaboradores', @level2type=N'COLUMN',@level2name=N'Telefono'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha Nacimiento' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Colaboradores', @level2type=N'COLUMN',@level2name=N'FechaNacimiento'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Género' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Colaboradores', @level2type=N'COLUMN',@level2name=N'Genero'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id Puesto' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Colaboradores', @level2type=N'COLUMN',@level2name=N'IdPuesto'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código Referencia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Patrocinadores', @level2type=N'COLUMN',@level2name=N'CodigoReferencia'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código Pais' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Patrocinadores', @level2type=N'COLUMN',@level2name=N'CodigoPais'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Patrocinadores', @level2type=N'COLUMN',@level2name=N'Estado'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha Registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Patrocinadores', @level2type=N'COLUMN',@level2name=N'FechaRegistro'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id Puesto' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Puestos', @level2type=N'COLUMN',@level2name=N'IdPuesto'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre Puesto' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Puestos', @level2type=N'COLUMN',@level2name=N'NombrePuesto'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha Creación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Puestos', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
