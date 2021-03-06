create dabase aerolinea
go
USE [aerolinea]
GO
/****** Object:  StoredProcedure [dbo].[ListarBoletos]    Script Date: 25/06/2015 05:41:33 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListarBoletos]
@fec1 date,
@fec2 date
as
begin
Select Boleto.IdBoleto, Boleto.idVuelo, Boleto.Asiento,
 Boleto.Costo, Boleto.IdPersona,Persona.Nombres,
 Persona.Apellidos,Persona.DNI,Destino.Destino,Vuelo.Salida 
 From Boleto INNER JOIN Vuelo ON Boleto.IdVuelo = Vuelo.IdVuelo
 INNER JOIN Persona ON Boleto.IdPersona = Persona.IdPersona
 INNER JOIN Destino on Vuelo.IdDestino=Destino.IdDestino
 where Vuelo.Salida>=@fec1 and Vuelo.Salida<=@fec2
 end

GO
/****** Object:  StoredProcedure [dbo].[pMaxIdPasajero]    Script Date: 25/06/2015 05:41:33 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[pMaxIdPasajero]
as
begin
select max(Persona.IdPersona) from Persona
inner join TipoPersona on Persona.IdTipoPersona =TipoPersona.IdTipoPersona
where TipoPersona.Tipo like 'pasajero' or TipoPersona.Tipo like 'pasajeros'
end



GO
/****** Object:  StoredProcedure [dbo].[pMaxIdUsuario]    Script Date: 25/06/2015 05:41:33 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[pMaxIdUsuario]
as
select Count(*) from Usuario

GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Vuelo]    Script Date: 25/06/2015 05:41:33 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Obtener_Vuelo]
@id int
as
begin
select Asiento from Boleto where idVuelo =@id
end

GO
/****** Object:  Table [dbo].[Aeropuerto]    Script Date: 25/06/2015 05:41:33 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aeropuerto](
	[IdAeropuerto] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Procedencia] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Aeropuerto] PRIMARY KEY CLUSTERED 
(
	[IdAeropuerto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Avion]    Script Date: 25/06/2015 05:41:33 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Avion](
	[IdAvion] [int] IDENTITY(1,1) NOT NULL,
	[Aerolinea] [nvarchar](50) NOT NULL,
	[Modelo] [nchar](10) NOT NULL,
	[Capacidad] [int] NOT NULL,
	[Longitud] [float] NULL,
	[Envergadura] [float] NULL,
	[Despliegue] [float] NULL,
	[Salida] [int] NULL,
	[Sanitarios] [int] NULL,
 CONSTRAINT [PK_Avion] PRIMARY KEY CLUSTERED 
(
	[IdAvion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Boleto]    Script Date: 25/06/2015 05:41:33 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Boleto](
	[IdBoleto] [int] IDENTITY(1,1) NOT NULL,
	[idVuelo] [int] NOT NULL,
	[Asiento] [int] NOT NULL,
	[Costo] [float] NOT NULL,
	[IdPersona] [int] NOT NULL,
 CONSTRAINT [PK_Boleto_1] PRIMARY KEY CLUSTERED 
(
	[IdBoleto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Destino]    Script Date: 25/06/2015 05:41:33 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Destino](
	[IdDestino] [int] IDENTITY(1,1) NOT NULL,
	[Destino] [nvarchar](50) NOT NULL,
	[Costo1] [float] NULL,
	[Costo2] [float] NULL,
 CONSTRAINT [PK_Destino] PRIMARY KEY CLUSTERED 
(
	[IdDestino] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persona]    Script Date: 25/06/2015 05:41:33 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Persona](
	[IdPersona] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](50) NOT NULL,
	[Apellidos] [nvarchar](50) NOT NULL,
	[DNI] [char](8) NOT NULL,
	[FecNac] [date] NULL,
	[Celular] [char](9) NULL,
	[Email] [nvarchar](50) NULL,
	[IdTipoPersona] [int] NOT NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[IdPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoPersona]    Script Date: 25/06/2015 05:41:33 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPersona](
	[IdTipoPersona] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TipoPersona] PRIMARY KEY CLUSTERED 
(
	[IdTipoPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 25/06/2015 05:41:33 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [nvarchar](50) NOT NULL,
	[Pass] [nvarchar](max) NOT NULL,
	[Privilegios] [bit] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vuelo]    Script Date: 25/06/2015 05:41:33 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vuelo](
	[IdVuelo] [int] IDENTITY(1,1) NOT NULL,
	[idAvion] [int] NOT NULL,
	[Salida] [datetime] NOT NULL,
	[IdDestino] [int] NOT NULL,
 CONSTRAINT [PK_Vuelo_1] PRIMARY KEY CLUSTERED 
(
	[IdVuelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Boleto]  WITH CHECK ADD  CONSTRAINT [FK_Boleto_Persona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Persona] ([IdPersona])
GO
ALTER TABLE [dbo].[Boleto] CHECK CONSTRAINT [FK_Boleto_Persona]
GO
ALTER TABLE [dbo].[Boleto]  WITH CHECK ADD  CONSTRAINT [FK_Boleto_Vuelo] FOREIGN KEY([idVuelo])
REFERENCES [dbo].[Vuelo] ([IdVuelo])
GO
ALTER TABLE [dbo].[Boleto] CHECK CONSTRAINT [FK_Boleto_Vuelo]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_TipoPersona] FOREIGN KEY([IdTipoPersona])
REFERENCES [dbo].[TipoPersona] ([IdTipoPersona])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Persona_TipoPersona]
GO
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK_Vuelo_Destino] FOREIGN KEY([IdDestino])
REFERENCES [dbo].[Destino] ([IdDestino])
GO
ALTER TABLE [dbo].[Vuelo] CHECK CONSTRAINT [FK_Vuelo_Destino]
GO
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK_Vuelos_Avion] FOREIGN KEY([idAvion])
REFERENCES [dbo].[Avion] ([IdAvion])
GO
ALTER TABLE [dbo].[Vuelo] CHECK CONSTRAINT [FK_Vuelos_Avion]
GO
