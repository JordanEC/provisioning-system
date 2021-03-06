USE [master]
GO
/****** Object:  Database [SistemaDeAprovisionamiento]    Script Date: 12/11/2014 11:24:50 ******/
CREATE DATABASE [SistemaDeAprovisionamiento]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SistemaDeAprovisionamiento', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\SistemaDeAprovisionamiento.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SistemaDeAprovisionamiento_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\SistemaDeAprovisionamiento_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SistemaDeAprovisionamiento].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET ARITHABORT OFF 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET  MULTI_USER 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET DELAYED_DURABILITY = DISABLED 
GO
USE [SistemaDeAprovisionamiento]
GO
/****** Object:  Table [dbo].[PRODUCTO]    Script Date: 12/11/2014 11:24:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PRODUCTO](
	[iDProducto] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[fabricante] [varchar](50) NOT NULL,
	[cantidad] [int] NULL CONSTRAINT [DF_PRODUCTO_cantidad]  DEFAULT ((0)),
	[precio] [decimal](18, 2) NOT NULL,
	[descripcionDetallada] [varchar](100) NOT NULL,
 CONSTRAINT [PK_PRODUCTO] PRIMARY KEY CLUSTERED 
(
	[iDProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PROVEEDOR]    Script Date: 12/11/2014 11:24:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PROVEEDOR](
	[iDProveedor] [int] IDENTITY(1,1) NOT NULL,
	[nombreUsuario] [varchar](50) NOT NULL,
	[empresa] [varchar](50) NULL,
	[correo] [varchar](50) NOT NULL,
	[habilitado] [bit] NULL CONSTRAINT [DF_PROVEEDOR_habilitado]  DEFAULT ((0)),
	[contrasena] [varchar](100) NOT NULL,
 CONSTRAINT [PK_PROVEEDOR] PRIMARY KEY CLUSTERED 
(
	[iDProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [SK1_PROVEEDOR] UNIQUE NONCLUSTERED 
(
	[nombreUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [SK2_PROVEEDOR] UNIQUE NONCLUSTERED 
(
	[correo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PROVEEDOR_PRODUCTO]    Script Date: 12/11/2014 11:24:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PROVEEDOR_PRODUCTO](
	[iDProveedor] [int] NOT NULL,
	[iDProducto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
 CONSTRAINT [PK_PROVEEDOR_PRODUCTO] PRIMARY KEY CLUSTERED 
(
	[iDProveedor] ASC,
	[iDProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [SK1_PRODUCTO]    Script Date: 12/11/2014 11:24:50 ******/
CREATE UNIQUE NONCLUSTERED INDEX [SK1_PRODUCTO] ON [dbo].[PRODUCTO]
(
	[descripcion] ASC,
	[fabricante] ASC,
	[precio] ASC,
	[descripcionDetallada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PROVEEDOR_PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTO] FOREIGN KEY([iDProducto])
REFERENCES [dbo].[PRODUCTO] ([iDProducto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PROVEEDOR_PRODUCTO] CHECK CONSTRAINT [FK_PRODUCTO]
GO
ALTER TABLE [dbo].[PROVEEDOR_PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_PROVEEDOR] FOREIGN KEY([iDProveedor])
REFERENCES [dbo].[PROVEEDOR] ([iDProveedor])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PROVEEDOR_PRODUCTO] CHECK CONSTRAINT [FK_PROVEEDOR]
GO
/****** Object:  StoredProcedure [dbo].[Insertar_Producto]    Script Date: 12/11/2014 11:24:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:	Jordan Espinoza Calderón
-- =============================================
CREATE PROCEDURE [dbo].[Insertar_Producto]
	@Descripcion varchar(50), @Fabricante varchar(50), @Cantidad int,
	@Precio decimal(18, 2), @DescripcionDetallada varchar(100), @IDProveedor int
AS
	DECLARE @IDProducto as int
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON

		if	EXISTS (SELECT PRODUCTO.iDProducto			--Si el producto se encuentra registrado
				FROM PRODUCTO
				WHERE descripcion = @Descripcion AND
				fabricante = @Fabricante AND
				descripcionDetallada= @DescripcionDetallada)
		BEGIN
		    SET @IDProducto = (SELECT PRODUCTO.iDProducto --obtiene el id del producto
							   FROM PRODUCTO
							   WHERE descripcion = @Descripcion AND
							   fabricante = @Fabricante AND
							   descripcionDetallada= @DescripcionDetallada)

			IF EXISTS (SELECT iDProveedor				--si el proveedor ya tenia el producto
					   FROM PROVEEDOR_PRODUCTO			
					   WHERE iDProveedor = @IDProveedor AND @IDProducto = iDProducto)
				BEGIN
					UPDATE PROVEEDOR_PRODUCTO			--suma la cantidad ingresada a la anterior
					SET Cantidad = @Cantidad + (SELECT cantidad FROM PROVEEDOR_PRODUCTO WHERE iDProveedor = @IDProveedor AND iDProducto = @IDProducto)
					WHERE iDProveedor = @IDProveedor AND iDProducto = @IDProducto
				END
			ELSE										
				BEGIN
					INSERT INTO PROVEEDOR_PRODUCTO					--inserta en la provee_produ
					VALUES (@IDProveedor, @IDProducto, @Cantidad)
				END
		END
	ELSE								--Si el producto no estaba en la BD
		BEGIN
			INSERT INTO PRODUCTO		--Lo inserta
			VALUES (@Descripcion, @Fabricante, @Cantidad, @Precio, @DescripcionDetallada)
			SET @IDProducto = (SELECT PRODUCTO.iDProducto 
						   FROM PRODUCTO
						   WHERE descripcion = @Descripcion AND
						   fabricante = @Fabricante AND
				           descripcionDetallada= @DescripcionDetallada)
			INSERT INTO PROVEEDOR_PRODUCTO
			VALUES (@IDProveedor, @IDProducto, @Cantidad)
		END
END

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valor unico de descripcion, fabricante, precio y descripcionDetallada' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PRODUCTO', @level2type=N'INDEX',@level2name=N'SK1_PRODUCTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unico IDProveedor' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PROVEEDOR', @level2type=N'CONSTRAINT',@level2name=N'PK_PROVEEDOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unico nombreUsuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PROVEEDOR', @level2type=N'CONSTRAINT',@level2name=N'SK1_PROVEEDOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unico correo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PROVEEDOR', @level2type=N'CONSTRAINT',@level2name=N'SK2_PROVEEDOR'
GO
USE [master]
GO
ALTER DATABASE [SistemaDeAprovisionamiento] SET  READ_WRITE 
GO

-- =============================================
-- Author:	Jordan Espinoza
-- =============================================
USE [SistemaDeAprovisionamiento]
GO
CREATE TRIGGER ActualizarCantidadProducto
   ON SistemaDeAprovisionamiento.dbo.PROVEEDOR_PRODUCTO
   FOR INSERT, UPDATE, DELETE
AS
	DECLARE @ProdID as int, @CantidadTotal as int, @Count as int
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT @Count = COUNT(*) FROM inserted
	IF (@Count > 0)
		BEGIN
			SELECT @ProdID = inserted.iDProducto
			FROM inserted
		END

	SELECT @Count = COUNT(*) FROM deleted
	IF (@Count > 0)
		BEGIN
			SELECT @ProdID = deleted.iDProducto
			FROM deleted
	END
	
	SELECT @CantidadTotal = SUM(PROVEEDOR_PRODUCTO.cantidad)
	FROM PROVEEDOR_PRODUCTO
	WHERE PROVEEDOR_PRODUCTO.iDProducto = @ProdID
	
	UPDATE PRODUCTO
	SET cantidad = @CantidadTotal
	WHERE PRODUCTO.iDProducto = @ProdID
    
END
GO

USE [SistemaDeAprovisionamiento]
GO

INSERT INTO [dbo].[PROVEEDOR]
VALUES	('CMora', 'FLPK', 'carlos.mora@flpk.com', 1, '1000:NnofubzGPowHWUD1XqZPO5WvEgjNSsvu:tttKHWL2yapdQoFC0QvBMBlTVG+cxedd'),
		('Mario58', 'ACWK S.A', 'mario8558@acwk.com', 1, '1000:CjIUhoA6hMpFa456k0HgSzSre78cpkpy:g0eVcvPK2BtquPLWMf1DipG0RioNCk6o'),
        ('Juan Carlos', 'CCZZ', 'jcarlos@cczz.com', 1, '1000:978LZxmH8v2lnt5wGf9ELDkY/e637n7I:lgD1rPBw95vJ7hh5PLKpFZuTM52wtCAH'),
		('Ana Vargas', 'Impo-Vargas S.A', 'avargas90@impovargas.com', 0, '1000:lSPRTKAkqmTdQu5hNSKABAsLi1/45ury:4rH6+Zh3CLNBr6GCjrkzvm8fE7H9bWl3'),
		('Luis.Aguilar.92', 'HG & MH S.A','laguilar@hgymh.com', 0, '1000:GyLXNEAO1n0RG2ooCmM2cT8LWUVI3wq/:WtJGORj0yasjLFi0tbRYEtS/qzXUUZDi');

INSERT INTO PRODUCTO
VALUES	('Coca Cola', 'Coca-Cola Company', 0, 950,'Envase de 2.5 litros'),
		('Camisetas hombre', 'El SOL', 0, 2500,'Talla M'),
		('Telefono celular', 'Sony', 0, 180000,'Procesador 1.5 GHZ, Memoria RAM 2 GB, Memoria Interna 32 GB, Camara 8 Mpx'),
		('Balon de futbol', 'Adidas', 0, 35000,'Brazuca 2014'),
		('Gafas', 'Electric', 0, 25000,'Gafas de sol'),
		('Disco duro externo', 'Western Digital', 0, 80000,'Capacidad 2 TB');

INSERT INTO PROVEEDOR_PRODUCTO
VALUES (1, 5, 45);

INSERT INTO PROVEEDOR_PRODUCTO
VALUES (1, 3, 10);

INSERT INTO PROVEEDOR_PRODUCTO
VALUES (2, 6, 20);

INSERT INTO PROVEEDOR_PRODUCTO
VALUES (2, 4, 5);

INSERT INTO PROVEEDOR_PRODUCTO
VALUES (2, 1, 150);

INSERT INTO PROVEEDOR_PRODUCTO
VALUES (3, 2, 50);

INSERT INTO PROVEEDOR_PRODUCTO
VALUES (3, 1, 350);
