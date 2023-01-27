CREATE TABLE [dbo].[Facturas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](max) NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[Total] [numeric](18, 2) NOT NULL,
	[Subtotal] [numeric](18, 2) NOT NULL,
	[Vendedor] [varchar](max) NOT NULL,
	[MetodoPago] [varchar](max) NOT NULL,
	[Pagado] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]