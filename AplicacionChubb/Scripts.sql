USE [db_seguros]
GO
/****** Object:  Table [dbo].[persona]    Script Date: 12/6/2022 20:14:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[persona](
	[id_persona] [int] IDENTITY(1,1) NOT NULL,
	[nombre_persona] [varchar](50) NULL,
	[apellido_persona] [varchar](50) NULL,
	[cedula_persona] [varchar](50) NULL,
	[telefono_persona] [varchar](50) NULL,
	[estado_persona] [int] NOT NULL,
 CONSTRAINT [PK_personas] PRIMARY KEY CLUSTERED 
(
	[id_persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[porcentaje]    Script Date: 12/6/2022 20:14:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[porcentaje](
	[id_porcentaje] [int] IDENTITY(1,1) NOT NULL,
	[porcentaje] [varchar](10) NULL,
 CONSTRAINT [PK_porcentajes] PRIMARY KEY CLUSTERED 
(
	[id_porcentaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rangos]    Script Date: 12/6/2022 20:14:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rangos](
	[id_rango] [int] IDENTITY(1,1) NOT NULL,
	[inicio] [numeric](18, 0) NULL,
	[fin] [numeric](18, 0) NULL,
	[porcentaje] [decimal](18, 2) NULL,
 CONSTRAINT [PK_rengos] PRIMARY KEY CLUSTERED 
(
	[id_rango] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[seguros]    Script Date: 12/6/2022 20:14:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[seguros](
	[nombre_seguro] [nchar](100) NOT NULL,
	[id_seguro] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[codigo_seguro] [nchar](20) NOT NULL,
	[valor_seguro] [decimal](18, 2) NOT NULL,
	[prima] [numeric](18, 0) NOT NULL,
	[fecha_creacion_seguro] [datetime] NOT NULL,
	[fecha_modificacion_seguro] [datetime] NOT NULL,
	[rango_edad_seguro] [nchar](50) NOT NULL,
	[porcentaje_seguro] [nchar](50) NOT NULL,
	[id_tipo_seguro] [int] NULL,
	[estado_seguro] [int] NULL,
 CONSTRAINT [PK_seguros] PRIMARY KEY CLUSTERED 
(
	[id_seguro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[seguros_persona]    Script Date: 12/6/2022 20:14:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[seguros_persona](
	[id_seguro] [numeric](18, 0) NOT NULL,
	[id_persona] [int] NOT NULL,
	[id_seguro_persona] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_seguros_persona] PRIMARY KEY CLUSTERED 
(
	[id_seguro_persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_seguros]    Script Date: 12/6/2022 20:14:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_seguros](
	[id_tipo_seguro] [int] IDENTITY(1,1) NOT NULL,
	[tipo_seguro] [varchar](50) NULL,
	[estado_seguro] [int] NULL,
 CONSTRAINT [PK_tipo_seguros] PRIMARY KEY CLUSTERED 
(
	[id_tipo_seguro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ventas]    Script Date: 12/6/2022 20:14:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ventas](
	[id_venta] [int] IDENTITY(1,1) NOT NULL,
	[id_seguro_venta] [int] NULL,
	[id_persona] [int] NULL,
	[fecha_creacion] [datetime] NULL,
	[id_rango_venta] [int] NULL,
	[valor_venta] [decimal](18, 2) NULL,
	[id_porcentaje_venta] [int] NULL,
	[prima] [decimal](18, 2) NULL,
 CONSTRAINT [PK_ventas] PRIMARY KEY CLUSTERED 
(
	[id_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[persona] ON 

INSERT [dbo].[persona] ([id_persona], [nombre_persona], [apellido_persona], [cedula_persona], [telefono_persona], [estado_persona]) VALUES (6, N'Darwin s', N'Guaman', N'0109222111', N'22665252', 1)
INSERT [dbo].[persona] ([id_persona], [nombre_persona], [apellido_persona], [cedula_persona], [telefono_persona], [estado_persona]) VALUES (7, N'Darwin OG', N'Guaman', N'0109222112', N'25396100222', 1)
SET IDENTITY_INSERT [dbo].[persona] OFF
GO
SET IDENTITY_INSERT [dbo].[seguros] ON 

INSERT [dbo].[seguros] ([nombre_seguro], [id_seguro], [codigo_seguro], [valor_seguro], [prima], [fecha_creacion_seguro], [fecha_modificacion_seguro], [rango_edad_seguro], [porcentaje_seguro], [id_tipo_seguro], [estado_seguro]) VALUES (N'Seguro 11                                                                                           ', CAST(1 AS Numeric(18, 0)), N'2121aa              ', CAST(20.00 AS Decimal(18, 2)), CAST(22 AS Numeric(18, 0)), CAST(N'2022-06-12T19:37:00.000' AS DateTime), CAST(N'2022-06-12T19:37:59.300' AS DateTime), N'12-20                                             ', N'2                                                 ', 1, 1)
SET IDENTITY_INSERT [dbo].[seguros] OFF
GO
SET IDENTITY_INSERT [dbo].[tipo_seguros] ON 

INSERT [dbo].[tipo_seguros] ([id_tipo_seguro], [tipo_seguro], [estado_seguro]) VALUES (1, N'Seguro 1 ', 1)
INSERT [dbo].[tipo_seguros] ([id_tipo_seguro], [tipo_seguro], [estado_seguro]) VALUES (2, N'Seguro 2', 1)
SET IDENTITY_INSERT [dbo].[tipo_seguros] OFF
GO
ALTER TABLE [dbo].[seguros_persona]  WITH CHECK ADD  CONSTRAINT [FK_seguros_clientes_cliente] FOREIGN KEY([id_persona])
REFERENCES [dbo].[persona] ([id_persona])
GO
ALTER TABLE [dbo].[seguros_persona] CHECK CONSTRAINT [FK_seguros_clientes_cliente]
GO
ALTER TABLE [dbo].[seguros_persona]  WITH CHECK ADD  CONSTRAINT [FK_seguros_clientes_seguros] FOREIGN KEY([id_seguro])
REFERENCES [dbo].[seguros] ([id_seguro])
GO
ALTER TABLE [dbo].[seguros_persona] CHECK CONSTRAINT [FK_seguros_clientes_seguros]
GO
