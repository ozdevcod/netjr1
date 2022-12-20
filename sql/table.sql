USE [DATABASENAME]
GO

/****** Object:  Table [dbo].[Libros]    Script Date: 12/20/2022 14:29:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Libros](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](70) NULL,
	[autor] [varchar](70) NULL,
	[paginas] [smallint] NULL,
	[genero] [varchar](70) NULL,
	[year] [varchar](4) NULL,
	[fechaCreacion] [datetime] NULL,
 CONSTRAINT [PK_Libros] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Libros] ADD  CONSTRAINT [DF_Libros_createdate]  DEFAULT (getdate()) FOR [fechaCreacion]
GO


