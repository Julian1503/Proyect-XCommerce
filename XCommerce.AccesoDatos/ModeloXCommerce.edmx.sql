
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/22/2019 20:11:13
-- Generated from EDMX file: C:\Users\cliente\Desktop\Commerce\XCommerce.AccesoDatos\ModeloXCommerce.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [XCommerceDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProvinciaLocalidad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Localidades] DROP CONSTRAINT [FK_ProvinciaLocalidad];
GO
IF OBJECT_ID(N'[dbo].[FK_LocalidadDireccion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Direcciones] DROP CONSTRAINT [FK_LocalidadDireccion];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonaUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK_PersonaUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_MarcaArticulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Articulos] DROP CONSTRAINT [FK_MarcaArticulo];
GO
IF OBJECT_ID(N'[dbo].[FK_RubroArticulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Articulos] DROP CONSTRAINT [FK_RubroArticulo];
GO
IF OBJECT_ID(N'[dbo].[FK_MotivoBajaBajaArticulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BajaArticulos] DROP CONSTRAINT [FK_MotivoBajaBajaArticulo];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticuloBajaArticulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BajaArticulos] DROP CONSTRAINT [FK_ArticuloBajaArticulo];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioCaja]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cajas] DROP CONSTRAINT [FK_UsuarioCaja];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioCaja1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cajas] DROP CONSTRAINT [FK_UsuarioCaja1];
GO
IF OBJECT_ID(N'[dbo].[FK_CajaDetalleCaja]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleCajas] DROP CONSTRAINT [FK_CajaDetalleCaja];
GO
IF OBJECT_ID(N'[dbo].[FK_ListaPrecioPrecio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Precios] DROP CONSTRAINT [FK_ListaPrecioPrecio];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticuloPrecio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Precios] DROP CONSTRAINT [FK_ArticuloPrecio];
GO
IF OBJECT_ID(N'[dbo].[FK_CondicionIvaEmpresa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Empresas] DROP CONSTRAINT [FK_CondicionIvaEmpresa];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpresaDireccion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Empresas] DROP CONSTRAINT [FK_EmpresaDireccion];
GO
IF OBJECT_ID(N'[dbo].[FK_SalonMesa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Mesas] DROP CONSTRAINT [FK_SalonMesa];
GO
IF OBJECT_ID(N'[dbo].[FK_MesaReserva]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservas] DROP CONSTRAINT [FK_MesaReserva];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteReserva]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservas] DROP CONSTRAINT [FK_ClienteReserva];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioReserva]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservas] DROP CONSTRAINT [FK_UsuarioReserva];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioComprobante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes] DROP CONSTRAINT [FK_UsuarioComprobante];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteComprobante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes] DROP CONSTRAINT [FK_ClienteComprobante];
GO
IF OBJECT_ID(N'[dbo].[FK_ComprobanteDetalleComprobante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleComprobantes] DROP CONSTRAINT [FK_ComprobanteDetalleComprobante];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticuloDetalleComprobante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleComprobantes] DROP CONSTRAINT [FK_ArticuloDetalleComprobante];
GO
IF OBJECT_ID(N'[dbo].[FK_CajaMovimiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Movimientos] DROP CONSTRAINT [FK_CajaMovimiento];
GO
IF OBJECT_ID(N'[dbo].[FK_ComprobanteMovimiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Movimientos] DROP CONSTRAINT [FK_ComprobanteMovimiento];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioMovimiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Movimientos] DROP CONSTRAINT [FK_UsuarioMovimiento];
GO
IF OBJECT_ID(N'[dbo].[FK_ComprobanteFormaPago]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormasPagos] DROP CONSTRAINT [FK_ComprobanteFormaPago];
GO
IF OBJECT_ID(N'[dbo].[FK_BancoCheque]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormasPagos_FormaPagoCheque] DROP CONSTRAINT [FK_BancoCheque];
GO
IF OBJECT_ID(N'[dbo].[FK_MesaComprobanteSalon]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes_ComprobanteSalon] DROP CONSTRAINT [FK_MesaComprobanteSalon];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteFormaPagoCtaCte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormasPagos_FormaPagoCtaCte] DROP CONSTRAINT [FK_ClienteFormaPagoCtaCte];
GO
IF OBJECT_ID(N'[dbo].[FK_TarjetaPlanTarjeta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanesTarjetas] DROP CONSTRAINT [FK_TarjetaPlanTarjeta];
GO
IF OBJECT_ID(N'[dbo].[FK_PlanTarjetaFormaPagoTarjeta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormasPagos_FormaPagoTarjeta] DROP CONSTRAINT [FK_PlanTarjetaFormaPagoTarjeta];
GO
IF OBJECT_ID(N'[dbo].[FK_CondicionIvaProveedor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proveedores] DROP CONSTRAINT [FK_CondicionIvaProveedor];
GO
IF OBJECT_ID(N'[dbo].[FK_ProveedorComprobanteCompra]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes_ComprobanteCompra] DROP CONSTRAINT [FK_ProveedorComprobanteCompra];
GO
IF OBJECT_ID(N'[dbo].[FK_MotivoReservaReserva]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservas] DROP CONSTRAINT [FK_MotivoReservaReserva];
GO
IF OBJECT_ID(N'[dbo].[FK_SalonListaPrecio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Salones] DROP CONSTRAINT [FK_SalonListaPrecio];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpleadoComprobanteSalon]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes_ComprobanteSalon] DROP CONSTRAINT [FK_EmpleadoComprobanteSalon];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonaDireccion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personas] DROP CONSTRAINT [FK_PersonaDireccion];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteCuentaCorriente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CuentaCorrienteSet] DROP CONSTRAINT [FK_ClienteCuentaCorriente];
GO
IF OBJECT_ID(N'[dbo].[FK_CuentaCorrienteOperacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operaciones] DROP CONSTRAINT [FK_CuentaCorrienteOperacion];
GO
IF OBJECT_ID(N'[dbo].[FK_OperacionComprobante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes] DROP CONSTRAINT [FK_OperacionComprobante];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoriaEmpleado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personas_Empleado] DROP CONSTRAINT [FK_CategoriaEmpleado];
GO
IF OBJECT_ID(N'[dbo].[FK_ComprobanteDeliveryDireccion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes_ComprobanteDelivery] DROP CONSTRAINT [FK_ComprobanteDeliveryDireccion];
GO
IF OBJECT_ID(N'[dbo].[FK_ConfiguracionListaPrecioDelivery]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Configuraciones] DROP CONSTRAINT [FK_ConfiguracionListaPrecioDelivery];
GO
IF OBJECT_ID(N'[dbo].[FK_ConfiguracionListaPrecio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Configuraciones] DROP CONSTRAINT [FK_ConfiguracionListaPrecio];
GO
IF OBJECT_ID(N'[dbo].[FK_ConfiguracionCategoria]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Configuraciones] DROP CONSTRAINT [FK_ConfiguracionCategoria];
GO
IF OBJECT_ID(N'[dbo].[FK_ConfiguracionCadete]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Configuraciones] DROP CONSTRAINT [FK_ConfiguracionCadete];
GO
IF OBJECT_ID(N'[dbo].[FK_ComprobanteDeliveryCadete]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes_ComprobanteDelivery] DROP CONSTRAINT [FK_ComprobanteDeliveryCadete];
GO
IF OBJECT_ID(N'[dbo].[FK_Cliente_inherits_Persona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personas_Cliente] DROP CONSTRAINT [FK_Cliente_inherits_Persona];
GO
IF OBJECT_ID(N'[dbo].[FK_FormaPagoCheque_inherits_FormaPago]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormasPagos_FormaPagoCheque] DROP CONSTRAINT [FK_FormaPagoCheque_inherits_FormaPago];
GO
IF OBJECT_ID(N'[dbo].[FK_ComprobanteSalon_inherits_Comprobante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes_ComprobanteSalon] DROP CONSTRAINT [FK_ComprobanteSalon_inherits_Comprobante];
GO
IF OBJECT_ID(N'[dbo].[FK_FormaPagoCtaCte_inherits_FormaPago]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormasPagos_FormaPagoCtaCte] DROP CONSTRAINT [FK_FormaPagoCtaCte_inherits_FormaPago];
GO
IF OBJECT_ID(N'[dbo].[FK_FormaPagoTarjeta_inherits_FormaPago]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormasPagos_FormaPagoTarjeta] DROP CONSTRAINT [FK_FormaPagoTarjeta_inherits_FormaPago];
GO
IF OBJECT_ID(N'[dbo].[FK_ComprobanteCompra_inherits_Comprobante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes_ComprobanteCompra] DROP CONSTRAINT [FK_ComprobanteCompra_inherits_Comprobante];
GO
IF OBJECT_ID(N'[dbo].[FK_Empleado_inherits_Persona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personas_Empleado] DROP CONSTRAINT [FK_Empleado_inherits_Persona];
GO
IF OBJECT_ID(N'[dbo].[FK_ComprobanteDelivery_inherits_Comprobante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes_ComprobanteDelivery] DROP CONSTRAINT [FK_ComprobanteDelivery_inherits_Comprobante];
GO
IF OBJECT_ID(N'[dbo].[FK_ComprobanteFactura_inherits_Comprobante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes_ComprobanteFactura] DROP CONSTRAINT [FK_ComprobanteFactura_inherits_Comprobante];
GO
IF OBJECT_ID(N'[dbo].[FK_FormaPagoEfectivo_inherits_FormaPago]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormasPagos_FormaPagoEfectivo] DROP CONSTRAINT [FK_FormaPagoEfectivo_inherits_FormaPago];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Personas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personas];
GO
IF OBJECT_ID(N'[dbo].[Direcciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Direcciones];
GO
IF OBJECT_ID(N'[dbo].[Localidades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Localidades];
GO
IF OBJECT_ID(N'[dbo].[Provincias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Provincias];
GO
IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO
IF OBJECT_ID(N'[dbo].[Marcas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Marcas];
GO
IF OBJECT_ID(N'[dbo].[Rubros]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rubros];
GO
IF OBJECT_ID(N'[dbo].[Articulos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Articulos];
GO
IF OBJECT_ID(N'[dbo].[MotivosBajas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MotivosBajas];
GO
IF OBJECT_ID(N'[dbo].[BajaArticulos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BajaArticulos];
GO
IF OBJECT_ID(N'[dbo].[Cajas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cajas];
GO
IF OBJECT_ID(N'[dbo].[DetalleCajas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleCajas];
GO
IF OBJECT_ID(N'[dbo].[ListaPrecios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ListaPrecios];
GO
IF OBJECT_ID(N'[dbo].[Precios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Precios];
GO
IF OBJECT_ID(N'[dbo].[Empresas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Empresas];
GO
IF OBJECT_ID(N'[dbo].[CondicionIvas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CondicionIvas];
GO
IF OBJECT_ID(N'[dbo].[Salones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Salones];
GO
IF OBJECT_ID(N'[dbo].[Mesas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mesas];
GO
IF OBJECT_ID(N'[dbo].[Reservas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reservas];
GO
IF OBJECT_ID(N'[dbo].[Comprobantes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comprobantes];
GO
IF OBJECT_ID(N'[dbo].[DetalleComprobantes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleComprobantes];
GO
IF OBJECT_ID(N'[dbo].[Movimientos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Movimientos];
GO
IF OBJECT_ID(N'[dbo].[FormasPagos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormasPagos];
GO
IF OBJECT_ID(N'[dbo].[Bancos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bancos];
GO
IF OBJECT_ID(N'[dbo].[TarjetaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TarjetaSet];
GO
IF OBJECT_ID(N'[dbo].[PlanesTarjetas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlanesTarjetas];
GO
IF OBJECT_ID(N'[dbo].[Proveedores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proveedores];
GO
IF OBJECT_ID(N'[dbo].[MotivoReservas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MotivoReservas];
GO
IF OBJECT_ID(N'[dbo].[CuentaCorrienteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CuentaCorrienteSet];
GO
IF OBJECT_ID(N'[dbo].[Operaciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Operaciones];
GO
IF OBJECT_ID(N'[dbo].[Categorias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categorias];
GO
IF OBJECT_ID(N'[dbo].[Configuraciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Configuraciones];
GO
IF OBJECT_ID(N'[dbo].[Personas_Cliente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personas_Cliente];
GO
IF OBJECT_ID(N'[dbo].[FormasPagos_FormaPagoCheque]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormasPagos_FormaPagoCheque];
GO
IF OBJECT_ID(N'[dbo].[Comprobantes_ComprobanteSalon]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comprobantes_ComprobanteSalon];
GO
IF OBJECT_ID(N'[dbo].[FormasPagos_FormaPagoCtaCte]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormasPagos_FormaPagoCtaCte];
GO
IF OBJECT_ID(N'[dbo].[FormasPagos_FormaPagoTarjeta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormasPagos_FormaPagoTarjeta];
GO
IF OBJECT_ID(N'[dbo].[Comprobantes_ComprobanteCompra]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comprobantes_ComprobanteCompra];
GO
IF OBJECT_ID(N'[dbo].[Personas_Empleado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personas_Empleado];
GO
IF OBJECT_ID(N'[dbo].[Comprobantes_ComprobanteDelivery]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comprobantes_ComprobanteDelivery];
GO
IF OBJECT_ID(N'[dbo].[Comprobantes_ComprobanteFactura]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comprobantes_ComprobanteFactura];
GO
IF OBJECT_ID(N'[dbo].[FormasPagos_FormaPagoEfectivo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormasPagos_FormaPagoEfectivo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Personas'
CREATE TABLE [dbo].[Personas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Apellido] nvarchar(250)  NOT NULL,
    [Nombre] nvarchar(250)  NOT NULL,
    [Dni] nvarchar(9)  NOT NULL,
    [Telefono] nvarchar(25)  NOT NULL,
    [Celular] nvarchar(25)  NOT NULL,
    [Email] nvarchar(250)  NOT NULL,
    [Cuil] nvarchar(11)  NOT NULL,
    [FechaNacimiento] datetime  NOT NULL,
    [Foto] varbinary(max)  NOT NULL,
    [EstaEliminado] bit  NOT NULL,
    [Direccion_Id] bigint  NOT NULL
);
GO

-- Creating table 'Direcciones'
CREATE TABLE [dbo].[Direcciones] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Calle] nvarchar(400)  NOT NULL,
    [Numero] int  NOT NULL,
    [Piso] nvarchar(2)  NOT NULL,
    [Dpto] nvarchar(2)  NOT NULL,
    [Casa] nvarchar(5)  NOT NULL,
    [Lote] nvarchar(5)  NOT NULL,
    [Mza] nvarchar(5)  NOT NULL,
    [Barrio] nvarchar(250)  NOT NULL,
    [LocalidadId] bigint  NOT NULL
);
GO

-- Creating table 'Localidades'
CREATE TABLE [dbo].[Localidades] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [ProvinciaId] bigint  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'Provincias'
CREATE TABLE [dbo].[Provincias] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(100)  NOT NULL,
    [Password] nvarchar(400)  NOT NULL,
    [EstaBloqueado] bit  NOT NULL,
    [PersonaId] bigint  NOT NULL
);
GO

-- Creating table 'Marcas'
CREATE TABLE [dbo].[Marcas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'Rubros'
CREATE TABLE [dbo].[Rubros] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'Articulos'
CREATE TABLE [dbo].[Articulos] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(100)  NOT NULL,
    [CodigoBarra] nvarchar(100)  NOT NULL,
    [Abreviatura] nvarchar(20)  NOT NULL,
    [Descripcion] nvarchar(400)  NOT NULL,
    [Detalle] nvarchar(max)  NOT NULL,
    [Foto] varbinary(max)  NOT NULL,
    [ActivarLimiteVenta] bit  NOT NULL,
    [LimiteVenta] decimal(18,2)  NOT NULL,
    [PermiteStockNegativo] bit  NOT NULL,
    [EstaDiscontinuado] bit  NOT NULL,
    [StockMaximo] decimal(18,2)  NOT NULL,
    [StockMinimo] decimal(18,2)  NOT NULL,
    [DescuentaStock] bit  NOT NULL,
    [EstaEliminado] bit  NOT NULL,
    [MarcaId] bigint  NOT NULL,
    [RubroId] bigint  NOT NULL,
    [Stock] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'MotivosBajas'
CREATE TABLE [dbo].[MotivosBajas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'BajaArticulos'
CREATE TABLE [dbo].[BajaArticulos] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Cantidad] decimal(18,2)  NOT NULL,
    [Observacion] nvarchar(max)  NOT NULL,
    [MotivoBajaId] bigint  NOT NULL,
    [ArticuloId] bigint  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'Cajas'
CREATE TABLE [dbo].[Cajas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [MontoApertura] decimal(18,2)  NOT NULL,
    [MontoCierre] decimal(18,2)  NOT NULL,
    [FechaApertura] datetime  NOT NULL,
    [FechaCierre] datetime  NOT NULL,
    [MontoSistema] decimal(18,2)  NOT NULL,
    [Diferencia] decimal(18,2)  NOT NULL,
    [UsuarioAperturaId] bigint  NOT NULL,
    [UsuarioCierreId] bigint  NOT NULL
);
GO

-- Creating table 'DetalleCajas'
CREATE TABLE [dbo].[DetalleCajas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [CajaId] bigint  NOT NULL,
    [Monto] decimal(18,2)  NOT NULL,
    [TipoPago] int  NOT NULL
);
GO

-- Creating table 'ListaPrecios'
CREATE TABLE [dbo].[ListaPrecios] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [Rentabilidad] decimal(18,2)  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'Precios'
CREATE TABLE [dbo].[Precios] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [PrecioCosto] decimal(18,2)  NOT NULL,
    [PrecioPublico] decimal(18,2)  NOT NULL,
    [FechaActualizacion] datetime  NOT NULL,
    [ListaPrecioId] bigint  NOT NULL,
    [ArticuloId] bigint  NOT NULL,
    [ActivarHoraVenta] bit  NOT NULL,
    [HoraVenta] datetime  NOT NULL
);
GO

-- Creating table 'Empresas'
CREATE TABLE [dbo].[Empresas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [CondicionIvaId] bigint  NOT NULL,
    [RazonSocial] nvarchar(250)  NOT NULL,
    [NombreFantasia] nvarchar(250)  NOT NULL,
    [Cuit] nvarchar(11)  NOT NULL,
    [Telefono] nvarchar(25)  NOT NULL,
    [Mail] nvarchar(250)  NOT NULL,
    [Sucursal] nvarchar(10)  NOT NULL,
    [Logo] varbinary(max)  NOT NULL,
    [ProductoBruto] nvarchar(max)  NOT NULL,
    [Direccion_Id] bigint  NOT NULL
);
GO

-- Creating table 'CondicionIvas'
CREATE TABLE [dbo].[CondicionIvas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'Salones'
CREATE TABLE [dbo].[Salones] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [EstaEliminado] bit  NOT NULL,
    [ListaPrecioId] bigint  NOT NULL
);
GO

-- Creating table 'Mesas'
CREATE TABLE [dbo].[Mesas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Numero] int  NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [EstaEliminado] bit  NOT NULL,
    [SalonId] bigint  NOT NULL,
    [EstadoMesa] int  NOT NULL,
    [TipoMesa] int  NOT NULL
);
GO

-- Creating table 'Reservas'
CREATE TABLE [dbo].[Reservas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Senia] decimal(18,2)  NOT NULL,
    [EstadoReserva] int  NOT NULL,
    [MesaId] bigint  NOT NULL,
    [ClienteId] bigint  NOT NULL,
    [UsuarioId] bigint  NOT NULL,
    [MotivoReservaId] bigint  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'Comprobantes'
CREATE TABLE [dbo].[Comprobantes] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Numero] int  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [SubTotal] decimal(18,0)  NOT NULL,
    [Descuento] decimal(18,0)  NOT NULL,
    [Total] decimal(18,0)  NOT NULL,
    [UsuarioId] bigint  NOT NULL,
    [ClienteId] bigint  NOT NULL,
    [TipoComprobante] int  NOT NULL,
    [Operacion_Id] bigint  NULL
);
GO

-- Creating table 'DetalleComprobantes'
CREATE TABLE [dbo].[DetalleComprobantes] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [ComprobanteId] bigint  NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [PrecioUnitario] decimal(18,2)  NOT NULL,
    [Cantidad] decimal(18,2)  NOT NULL,
    [SubTotal] decimal(18,2)  NOT NULL,
    [ArticuloId] bigint  NOT NULL
);
GO

-- Creating table 'Movimientos'
CREATE TABLE [dbo].[Movimientos] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [CajaId] bigint  NOT NULL,
    [ComprobanteId] bigint  NOT NULL,
    [TipoMovimento] int  NOT NULL,
    [UsuarioId] bigint  NOT NULL,
    [Monto] decimal(18,2)  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Descripcion] nvarchar(400)  NOT NULL
);
GO

-- Creating table 'FormasPagos'
CREATE TABLE [dbo].[FormasPagos] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [ComprobanteId] bigint  NOT NULL,
    [TipoFormaPago] int  NOT NULL,
    [Monto] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'Bancos'
CREATE TABLE [dbo].[Bancos] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'TarjetaSet'
CREATE TABLE [dbo].[TarjetaSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'PlanesTarjetas'
CREATE TABLE [dbo].[PlanesTarjetas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Alicuota] decimal(18,2)  NOT NULL,
    [TarjetaId] bigint  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'Proveedores'
CREATE TABLE [dbo].[Proveedores] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [RazonSocial] nvarchar(max)  NOT NULL,
    [Telefono] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Contacto] nvarchar(max)  NOT NULL,
    [CondicionIvaId] bigint  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'MotivoReservas'
CREATE TABLE [dbo].[MotivoReservas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'CuentaCorrienteSet'
CREATE TABLE [dbo].[CuentaCorrienteSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Saldo] decimal(18,0)  NOT NULL,
    [Limite] decimal(18,0)  NOT NULL,
    [EstaEliminada] bit  NOT NULL,
    [NumeroCuenta] int  NOT NULL,
    [ClienteId] bigint  NOT NULL
);
GO

-- Creating table 'Operaciones'
CREATE TABLE [dbo].[Operaciones] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [CuentaCorrienteId] bigint  NOT NULL,
    [TipoOperacion] int  NOT NULL,
    [Monto] decimal(18,0)  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [SubSaldo] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Categorias'
CREATE TABLE [dbo].[Categorias] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [SalarioCategoria] decimal(18,0)  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'Configuraciones'
CREATE TABLE [dbo].[Configuraciones] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [ListaDeliveryId] bigint  NULL,
    [ListaKioscoId] bigint  NULL,
    [MozoId] bigint  NULL,
    [CadeteId] bigint  NULL
);
GO

-- Creating table 'Personas_Cliente'
CREATE TABLE [dbo].[Personas_Cliente] (
    [MontoMaximoCtaCte] decimal(18,2)  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'FormasPagos_FormaPagoCheque'
CREATE TABLE [dbo].[FormasPagos_FormaPagoCheque] (
    [BancoId] bigint  NOT NULL,
    [Numero] nvarchar(250)  NOT NULL,
    [EnteEmisor] nvarchar(250)  NOT NULL,
    [FechaEmision] datetime  NOT NULL,
    [Dias] int  NOT NULL,
    [EstadoCheque] int  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'Comprobantes_ComprobanteSalon'
CREATE TABLE [dbo].[Comprobantes_ComprobanteSalon] (
    [Comensal] int  NOT NULL,
    [MesaId] bigint  NOT NULL,
    [EstadoComprobante] int  NOT NULL,
    [MozoId] bigint  NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'FormasPagos_FormaPagoCtaCte'
CREATE TABLE [dbo].[FormasPagos_FormaPagoCtaCte] (
    [ClienteId] bigint  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'FormasPagos_FormaPagoTarjeta'
CREATE TABLE [dbo].[FormasPagos_FormaPagoTarjeta] (
    [PlanTarjetaId] bigint  NOT NULL,
    [Cupon] nvarchar(250)  NOT NULL,
    [Numero] nvarchar(250)  NOT NULL,
    [NumeroTarjeta] nvarchar(250)  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'Comprobantes_ComprobanteCompra'
CREATE TABLE [dbo].[Comprobantes_ComprobanteCompra] (
    [ProveedorId] bigint  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'Personas_Empleado'
CREATE TABLE [dbo].[Personas_Empleado] (
    [Legajo] int  NOT NULL,
    [FechaIngreso] datetime  NOT NULL,
    [CategoriaId] bigint  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'Comprobantes_ComprobanteDelivery'
CREATE TABLE [dbo].[Comprobantes_ComprobanteDelivery] (
    [TipoPedido] int  NOT NULL,
    [EstadoPedido] int  NOT NULL,
    [DireccionId] bigint  NOT NULL,
    [CadeteId] bigint  NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'Comprobantes_ComprobanteFactura'
CREATE TABLE [dbo].[Comprobantes_ComprobanteFactura] (
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'FormasPagos_FormaPagoEfectivo'
CREATE TABLE [dbo].[FormasPagos_FormaPagoEfectivo] (
    [Id] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Personas'
ALTER TABLE [dbo].[Personas]
ADD CONSTRAINT [PK_Personas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Direcciones'
ALTER TABLE [dbo].[Direcciones]
ADD CONSTRAINT [PK_Direcciones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Localidades'
ALTER TABLE [dbo].[Localidades]
ADD CONSTRAINT [PK_Localidades]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Provincias'
ALTER TABLE [dbo].[Provincias]
ADD CONSTRAINT [PK_Provincias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Marcas'
ALTER TABLE [dbo].[Marcas]
ADD CONSTRAINT [PK_Marcas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Rubros'
ALTER TABLE [dbo].[Rubros]
ADD CONSTRAINT [PK_Rubros]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Articulos'
ALTER TABLE [dbo].[Articulos]
ADD CONSTRAINT [PK_Articulos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MotivosBajas'
ALTER TABLE [dbo].[MotivosBajas]
ADD CONSTRAINT [PK_MotivosBajas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BajaArticulos'
ALTER TABLE [dbo].[BajaArticulos]
ADD CONSTRAINT [PK_BajaArticulos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cajas'
ALTER TABLE [dbo].[Cajas]
ADD CONSTRAINT [PK_Cajas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DetalleCajas'
ALTER TABLE [dbo].[DetalleCajas]
ADD CONSTRAINT [PK_DetalleCajas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ListaPrecios'
ALTER TABLE [dbo].[ListaPrecios]
ADD CONSTRAINT [PK_ListaPrecios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Precios'
ALTER TABLE [dbo].[Precios]
ADD CONSTRAINT [PK_Precios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Empresas'
ALTER TABLE [dbo].[Empresas]
ADD CONSTRAINT [PK_Empresas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CondicionIvas'
ALTER TABLE [dbo].[CondicionIvas]
ADD CONSTRAINT [PK_CondicionIvas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Salones'
ALTER TABLE [dbo].[Salones]
ADD CONSTRAINT [PK_Salones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Mesas'
ALTER TABLE [dbo].[Mesas]
ADD CONSTRAINT [PK_Mesas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Reservas'
ALTER TABLE [dbo].[Reservas]
ADD CONSTRAINT [PK_Reservas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comprobantes'
ALTER TABLE [dbo].[Comprobantes]
ADD CONSTRAINT [PK_Comprobantes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DetalleComprobantes'
ALTER TABLE [dbo].[DetalleComprobantes]
ADD CONSTRAINT [PK_DetalleComprobantes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Movimientos'
ALTER TABLE [dbo].[Movimientos]
ADD CONSTRAINT [PK_Movimientos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FormasPagos'
ALTER TABLE [dbo].[FormasPagos]
ADD CONSTRAINT [PK_FormasPagos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Bancos'
ALTER TABLE [dbo].[Bancos]
ADD CONSTRAINT [PK_Bancos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TarjetaSet'
ALTER TABLE [dbo].[TarjetaSet]
ADD CONSTRAINT [PK_TarjetaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlanesTarjetas'
ALTER TABLE [dbo].[PlanesTarjetas]
ADD CONSTRAINT [PK_PlanesTarjetas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Proveedores'
ALTER TABLE [dbo].[Proveedores]
ADD CONSTRAINT [PK_Proveedores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MotivoReservas'
ALTER TABLE [dbo].[MotivoReservas]
ADD CONSTRAINT [PK_MotivoReservas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CuentaCorrienteSet'
ALTER TABLE [dbo].[CuentaCorrienteSet]
ADD CONSTRAINT [PK_CuentaCorrienteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Operaciones'
ALTER TABLE [dbo].[Operaciones]
ADD CONSTRAINT [PK_Operaciones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Categorias'
ALTER TABLE [dbo].[Categorias]
ADD CONSTRAINT [PK_Categorias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Configuraciones'
ALTER TABLE [dbo].[Configuraciones]
ADD CONSTRAINT [PK_Configuraciones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Personas_Cliente'
ALTER TABLE [dbo].[Personas_Cliente]
ADD CONSTRAINT [PK_Personas_Cliente]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FormasPagos_FormaPagoCheque'
ALTER TABLE [dbo].[FormasPagos_FormaPagoCheque]
ADD CONSTRAINT [PK_FormasPagos_FormaPagoCheque]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comprobantes_ComprobanteSalon'
ALTER TABLE [dbo].[Comprobantes_ComprobanteSalon]
ADD CONSTRAINT [PK_Comprobantes_ComprobanteSalon]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FormasPagos_FormaPagoCtaCte'
ALTER TABLE [dbo].[FormasPagos_FormaPagoCtaCte]
ADD CONSTRAINT [PK_FormasPagos_FormaPagoCtaCte]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FormasPagos_FormaPagoTarjeta'
ALTER TABLE [dbo].[FormasPagos_FormaPagoTarjeta]
ADD CONSTRAINT [PK_FormasPagos_FormaPagoTarjeta]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comprobantes_ComprobanteCompra'
ALTER TABLE [dbo].[Comprobantes_ComprobanteCompra]
ADD CONSTRAINT [PK_Comprobantes_ComprobanteCompra]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Personas_Empleado'
ALTER TABLE [dbo].[Personas_Empleado]
ADD CONSTRAINT [PK_Personas_Empleado]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comprobantes_ComprobanteDelivery'
ALTER TABLE [dbo].[Comprobantes_ComprobanteDelivery]
ADD CONSTRAINT [PK_Comprobantes_ComprobanteDelivery]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comprobantes_ComprobanteFactura'
ALTER TABLE [dbo].[Comprobantes_ComprobanteFactura]
ADD CONSTRAINT [PK_Comprobantes_ComprobanteFactura]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FormasPagos_FormaPagoEfectivo'
ALTER TABLE [dbo].[FormasPagos_FormaPagoEfectivo]
ADD CONSTRAINT [PK_FormasPagos_FormaPagoEfectivo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProvinciaId] in table 'Localidades'
ALTER TABLE [dbo].[Localidades]
ADD CONSTRAINT [FK_ProvinciaLocalidad]
    FOREIGN KEY ([ProvinciaId])
    REFERENCES [dbo].[Provincias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProvinciaLocalidad'
CREATE INDEX [IX_FK_ProvinciaLocalidad]
ON [dbo].[Localidades]
    ([ProvinciaId]);
GO

-- Creating foreign key on [LocalidadId] in table 'Direcciones'
ALTER TABLE [dbo].[Direcciones]
ADD CONSTRAINT [FK_LocalidadDireccion]
    FOREIGN KEY ([LocalidadId])
    REFERENCES [dbo].[Localidades]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LocalidadDireccion'
CREATE INDEX [IX_FK_LocalidadDireccion]
ON [dbo].[Direcciones]
    ([LocalidadId]);
GO

-- Creating foreign key on [PersonaId] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [FK_PersonaUsuario]
    FOREIGN KEY ([PersonaId])
    REFERENCES [dbo].[Personas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonaUsuario'
CREATE INDEX [IX_FK_PersonaUsuario]
ON [dbo].[Usuarios]
    ([PersonaId]);
GO

-- Creating foreign key on [MarcaId] in table 'Articulos'
ALTER TABLE [dbo].[Articulos]
ADD CONSTRAINT [FK_MarcaArticulo]
    FOREIGN KEY ([MarcaId])
    REFERENCES [dbo].[Marcas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MarcaArticulo'
CREATE INDEX [IX_FK_MarcaArticulo]
ON [dbo].[Articulos]
    ([MarcaId]);
GO

-- Creating foreign key on [RubroId] in table 'Articulos'
ALTER TABLE [dbo].[Articulos]
ADD CONSTRAINT [FK_RubroArticulo]
    FOREIGN KEY ([RubroId])
    REFERENCES [dbo].[Rubros]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RubroArticulo'
CREATE INDEX [IX_FK_RubroArticulo]
ON [dbo].[Articulos]
    ([RubroId]);
GO

-- Creating foreign key on [MotivoBajaId] in table 'BajaArticulos'
ALTER TABLE [dbo].[BajaArticulos]
ADD CONSTRAINT [FK_MotivoBajaBajaArticulo]
    FOREIGN KEY ([MotivoBajaId])
    REFERENCES [dbo].[MotivosBajas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MotivoBajaBajaArticulo'
CREATE INDEX [IX_FK_MotivoBajaBajaArticulo]
ON [dbo].[BajaArticulos]
    ([MotivoBajaId]);
GO

-- Creating foreign key on [ArticuloId] in table 'BajaArticulos'
ALTER TABLE [dbo].[BajaArticulos]
ADD CONSTRAINT [FK_ArticuloBajaArticulo]
    FOREIGN KEY ([ArticuloId])
    REFERENCES [dbo].[Articulos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticuloBajaArticulo'
CREATE INDEX [IX_FK_ArticuloBajaArticulo]
ON [dbo].[BajaArticulos]
    ([ArticuloId]);
GO

-- Creating foreign key on [UsuarioAperturaId] in table 'Cajas'
ALTER TABLE [dbo].[Cajas]
ADD CONSTRAINT [FK_UsuarioCaja]
    FOREIGN KEY ([UsuarioAperturaId])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioCaja'
CREATE INDEX [IX_FK_UsuarioCaja]
ON [dbo].[Cajas]
    ([UsuarioAperturaId]);
GO

-- Creating foreign key on [UsuarioCierreId] in table 'Cajas'
ALTER TABLE [dbo].[Cajas]
ADD CONSTRAINT [FK_UsuarioCaja1]
    FOREIGN KEY ([UsuarioCierreId])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioCaja1'
CREATE INDEX [IX_FK_UsuarioCaja1]
ON [dbo].[Cajas]
    ([UsuarioCierreId]);
GO

-- Creating foreign key on [CajaId] in table 'DetalleCajas'
ALTER TABLE [dbo].[DetalleCajas]
ADD CONSTRAINT [FK_CajaDetalleCaja]
    FOREIGN KEY ([CajaId])
    REFERENCES [dbo].[Cajas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CajaDetalleCaja'
CREATE INDEX [IX_FK_CajaDetalleCaja]
ON [dbo].[DetalleCajas]
    ([CajaId]);
GO

-- Creating foreign key on [ListaPrecioId] in table 'Precios'
ALTER TABLE [dbo].[Precios]
ADD CONSTRAINT [FK_ListaPrecioPrecio]
    FOREIGN KEY ([ListaPrecioId])
    REFERENCES [dbo].[ListaPrecios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ListaPrecioPrecio'
CREATE INDEX [IX_FK_ListaPrecioPrecio]
ON [dbo].[Precios]
    ([ListaPrecioId]);
GO

-- Creating foreign key on [ArticuloId] in table 'Precios'
ALTER TABLE [dbo].[Precios]
ADD CONSTRAINT [FK_ArticuloPrecio]
    FOREIGN KEY ([ArticuloId])
    REFERENCES [dbo].[Articulos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticuloPrecio'
CREATE INDEX [IX_FK_ArticuloPrecio]
ON [dbo].[Precios]
    ([ArticuloId]);
GO

-- Creating foreign key on [CondicionIvaId] in table 'Empresas'
ALTER TABLE [dbo].[Empresas]
ADD CONSTRAINT [FK_CondicionIvaEmpresa]
    FOREIGN KEY ([CondicionIvaId])
    REFERENCES [dbo].[CondicionIvas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CondicionIvaEmpresa'
CREATE INDEX [IX_FK_CondicionIvaEmpresa]
ON [dbo].[Empresas]
    ([CondicionIvaId]);
GO

-- Creating foreign key on [Direccion_Id] in table 'Empresas'
ALTER TABLE [dbo].[Empresas]
ADD CONSTRAINT [FK_EmpresaDireccion]
    FOREIGN KEY ([Direccion_Id])
    REFERENCES [dbo].[Direcciones]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpresaDireccion'
CREATE INDEX [IX_FK_EmpresaDireccion]
ON [dbo].[Empresas]
    ([Direccion_Id]);
GO

-- Creating foreign key on [SalonId] in table 'Mesas'
ALTER TABLE [dbo].[Mesas]
ADD CONSTRAINT [FK_SalonMesa]
    FOREIGN KEY ([SalonId])
    REFERENCES [dbo].[Salones]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SalonMesa'
CREATE INDEX [IX_FK_SalonMesa]
ON [dbo].[Mesas]
    ([SalonId]);
GO

-- Creating foreign key on [MesaId] in table 'Reservas'
ALTER TABLE [dbo].[Reservas]
ADD CONSTRAINT [FK_MesaReserva]
    FOREIGN KEY ([MesaId])
    REFERENCES [dbo].[Mesas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MesaReserva'
CREATE INDEX [IX_FK_MesaReserva]
ON [dbo].[Reservas]
    ([MesaId]);
GO

-- Creating foreign key on [ClienteId] in table 'Reservas'
ALTER TABLE [dbo].[Reservas]
ADD CONSTRAINT [FK_ClienteReserva]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Personas_Cliente]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteReserva'
CREATE INDEX [IX_FK_ClienteReserva]
ON [dbo].[Reservas]
    ([ClienteId]);
GO

-- Creating foreign key on [UsuarioId] in table 'Reservas'
ALTER TABLE [dbo].[Reservas]
ADD CONSTRAINT [FK_UsuarioReserva]
    FOREIGN KEY ([UsuarioId])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioReserva'
CREATE INDEX [IX_FK_UsuarioReserva]
ON [dbo].[Reservas]
    ([UsuarioId]);
GO

-- Creating foreign key on [UsuarioId] in table 'Comprobantes'
ALTER TABLE [dbo].[Comprobantes]
ADD CONSTRAINT [FK_UsuarioComprobante]
    FOREIGN KEY ([UsuarioId])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioComprobante'
CREATE INDEX [IX_FK_UsuarioComprobante]
ON [dbo].[Comprobantes]
    ([UsuarioId]);
GO

-- Creating foreign key on [ClienteId] in table 'Comprobantes'
ALTER TABLE [dbo].[Comprobantes]
ADD CONSTRAINT [FK_ClienteComprobante]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Personas_Cliente]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteComprobante'
CREATE INDEX [IX_FK_ClienteComprobante]
ON [dbo].[Comprobantes]
    ([ClienteId]);
GO

-- Creating foreign key on [ComprobanteId] in table 'DetalleComprobantes'
ALTER TABLE [dbo].[DetalleComprobantes]
ADD CONSTRAINT [FK_ComprobanteDetalleComprobante]
    FOREIGN KEY ([ComprobanteId])
    REFERENCES [dbo].[Comprobantes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComprobanteDetalleComprobante'
CREATE INDEX [IX_FK_ComprobanteDetalleComprobante]
ON [dbo].[DetalleComprobantes]
    ([ComprobanteId]);
GO

-- Creating foreign key on [ArticuloId] in table 'DetalleComprobantes'
ALTER TABLE [dbo].[DetalleComprobantes]
ADD CONSTRAINT [FK_ArticuloDetalleComprobante]
    FOREIGN KEY ([ArticuloId])
    REFERENCES [dbo].[Articulos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticuloDetalleComprobante'
CREATE INDEX [IX_FK_ArticuloDetalleComprobante]
ON [dbo].[DetalleComprobantes]
    ([ArticuloId]);
GO

-- Creating foreign key on [CajaId] in table 'Movimientos'
ALTER TABLE [dbo].[Movimientos]
ADD CONSTRAINT [FK_CajaMovimiento]
    FOREIGN KEY ([CajaId])
    REFERENCES [dbo].[Cajas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CajaMovimiento'
CREATE INDEX [IX_FK_CajaMovimiento]
ON [dbo].[Movimientos]
    ([CajaId]);
GO

-- Creating foreign key on [ComprobanteId] in table 'Movimientos'
ALTER TABLE [dbo].[Movimientos]
ADD CONSTRAINT [FK_ComprobanteMovimiento]
    FOREIGN KEY ([ComprobanteId])
    REFERENCES [dbo].[Comprobantes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComprobanteMovimiento'
CREATE INDEX [IX_FK_ComprobanteMovimiento]
ON [dbo].[Movimientos]
    ([ComprobanteId]);
GO

-- Creating foreign key on [UsuarioId] in table 'Movimientos'
ALTER TABLE [dbo].[Movimientos]
ADD CONSTRAINT [FK_UsuarioMovimiento]
    FOREIGN KEY ([UsuarioId])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioMovimiento'
CREATE INDEX [IX_FK_UsuarioMovimiento]
ON [dbo].[Movimientos]
    ([UsuarioId]);
GO

-- Creating foreign key on [ComprobanteId] in table 'FormasPagos'
ALTER TABLE [dbo].[FormasPagos]
ADD CONSTRAINT [FK_ComprobanteFormaPago]
    FOREIGN KEY ([ComprobanteId])
    REFERENCES [dbo].[Comprobantes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComprobanteFormaPago'
CREATE INDEX [IX_FK_ComprobanteFormaPago]
ON [dbo].[FormasPagos]
    ([ComprobanteId]);
GO

-- Creating foreign key on [BancoId] in table 'FormasPagos_FormaPagoCheque'
ALTER TABLE [dbo].[FormasPagos_FormaPagoCheque]
ADD CONSTRAINT [FK_BancoCheque]
    FOREIGN KEY ([BancoId])
    REFERENCES [dbo].[Bancos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BancoCheque'
CREATE INDEX [IX_FK_BancoCheque]
ON [dbo].[FormasPagos_FormaPagoCheque]
    ([BancoId]);
GO

-- Creating foreign key on [MesaId] in table 'Comprobantes_ComprobanteSalon'
ALTER TABLE [dbo].[Comprobantes_ComprobanteSalon]
ADD CONSTRAINT [FK_MesaComprobanteSalon]
    FOREIGN KEY ([MesaId])
    REFERENCES [dbo].[Mesas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MesaComprobanteSalon'
CREATE INDEX [IX_FK_MesaComprobanteSalon]
ON [dbo].[Comprobantes_ComprobanteSalon]
    ([MesaId]);
GO

-- Creating foreign key on [ClienteId] in table 'FormasPagos_FormaPagoCtaCte'
ALTER TABLE [dbo].[FormasPagos_FormaPagoCtaCte]
ADD CONSTRAINT [FK_ClienteFormaPagoCtaCte]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Personas_Cliente]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteFormaPagoCtaCte'
CREATE INDEX [IX_FK_ClienteFormaPagoCtaCte]
ON [dbo].[FormasPagos_FormaPagoCtaCte]
    ([ClienteId]);
GO

-- Creating foreign key on [TarjetaId] in table 'PlanesTarjetas'
ALTER TABLE [dbo].[PlanesTarjetas]
ADD CONSTRAINT [FK_TarjetaPlanTarjeta]
    FOREIGN KEY ([TarjetaId])
    REFERENCES [dbo].[TarjetaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TarjetaPlanTarjeta'
CREATE INDEX [IX_FK_TarjetaPlanTarjeta]
ON [dbo].[PlanesTarjetas]
    ([TarjetaId]);
GO

-- Creating foreign key on [PlanTarjetaId] in table 'FormasPagos_FormaPagoTarjeta'
ALTER TABLE [dbo].[FormasPagos_FormaPagoTarjeta]
ADD CONSTRAINT [FK_PlanTarjetaFormaPagoTarjeta]
    FOREIGN KEY ([PlanTarjetaId])
    REFERENCES [dbo].[PlanesTarjetas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlanTarjetaFormaPagoTarjeta'
CREATE INDEX [IX_FK_PlanTarjetaFormaPagoTarjeta]
ON [dbo].[FormasPagos_FormaPagoTarjeta]
    ([PlanTarjetaId]);
GO

-- Creating foreign key on [CondicionIvaId] in table 'Proveedores'
ALTER TABLE [dbo].[Proveedores]
ADD CONSTRAINT [FK_CondicionIvaProveedor]
    FOREIGN KEY ([CondicionIvaId])
    REFERENCES [dbo].[CondicionIvas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CondicionIvaProveedor'
CREATE INDEX [IX_FK_CondicionIvaProveedor]
ON [dbo].[Proveedores]
    ([CondicionIvaId]);
GO

-- Creating foreign key on [ProveedorId] in table 'Comprobantes_ComprobanteCompra'
ALTER TABLE [dbo].[Comprobantes_ComprobanteCompra]
ADD CONSTRAINT [FK_ProveedorComprobanteCompra]
    FOREIGN KEY ([ProveedorId])
    REFERENCES [dbo].[Proveedores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProveedorComprobanteCompra'
CREATE INDEX [IX_FK_ProveedorComprobanteCompra]
ON [dbo].[Comprobantes_ComprobanteCompra]
    ([ProveedorId]);
GO

-- Creating foreign key on [MotivoReservaId] in table 'Reservas'
ALTER TABLE [dbo].[Reservas]
ADD CONSTRAINT [FK_MotivoReservaReserva]
    FOREIGN KEY ([MotivoReservaId])
    REFERENCES [dbo].[MotivoReservas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MotivoReservaReserva'
CREATE INDEX [IX_FK_MotivoReservaReserva]
ON [dbo].[Reservas]
    ([MotivoReservaId]);
GO

-- Creating foreign key on [ListaPrecioId] in table 'Salones'
ALTER TABLE [dbo].[Salones]
ADD CONSTRAINT [FK_SalonListaPrecio]
    FOREIGN KEY ([ListaPrecioId])
    REFERENCES [dbo].[ListaPrecios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SalonListaPrecio'
CREATE INDEX [IX_FK_SalonListaPrecio]
ON [dbo].[Salones]
    ([ListaPrecioId]);
GO

-- Creating foreign key on [MozoId] in table 'Comprobantes_ComprobanteSalon'
ALTER TABLE [dbo].[Comprobantes_ComprobanteSalon]
ADD CONSTRAINT [FK_EmpleadoComprobanteSalon]
    FOREIGN KEY ([MozoId])
    REFERENCES [dbo].[Personas_Empleado]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpleadoComprobanteSalon'
CREATE INDEX [IX_FK_EmpleadoComprobanteSalon]
ON [dbo].[Comprobantes_ComprobanteSalon]
    ([MozoId]);
GO

-- Creating foreign key on [Direccion_Id] in table 'Personas'
ALTER TABLE [dbo].[Personas]
ADD CONSTRAINT [FK_PersonaDireccion]
    FOREIGN KEY ([Direccion_Id])
    REFERENCES [dbo].[Direcciones]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonaDireccion'
CREATE INDEX [IX_FK_PersonaDireccion]
ON [dbo].[Personas]
    ([Direccion_Id]);
GO

-- Creating foreign key on [ClienteId] in table 'CuentaCorrienteSet'
ALTER TABLE [dbo].[CuentaCorrienteSet]
ADD CONSTRAINT [FK_ClienteCuentaCorriente]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Personas_Cliente]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteCuentaCorriente'
CREATE INDEX [IX_FK_ClienteCuentaCorriente]
ON [dbo].[CuentaCorrienteSet]
    ([ClienteId]);
GO

-- Creating foreign key on [CuentaCorrienteId] in table 'Operaciones'
ALTER TABLE [dbo].[Operaciones]
ADD CONSTRAINT [FK_CuentaCorrienteOperacion]
    FOREIGN KEY ([CuentaCorrienteId])
    REFERENCES [dbo].[CuentaCorrienteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CuentaCorrienteOperacion'
CREATE INDEX [IX_FK_CuentaCorrienteOperacion]
ON [dbo].[Operaciones]
    ([CuentaCorrienteId]);
GO

-- Creating foreign key on [Operacion_Id] in table 'Comprobantes'
ALTER TABLE [dbo].[Comprobantes]
ADD CONSTRAINT [FK_OperacionComprobante]
    FOREIGN KEY ([Operacion_Id])
    REFERENCES [dbo].[Operaciones]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OperacionComprobante'
CREATE INDEX [IX_FK_OperacionComprobante]
ON [dbo].[Comprobantes]
    ([Operacion_Id]);
GO

-- Creating foreign key on [CategoriaId] in table 'Personas_Empleado'
ALTER TABLE [dbo].[Personas_Empleado]
ADD CONSTRAINT [FK_CategoriaEmpleado]
    FOREIGN KEY ([CategoriaId])
    REFERENCES [dbo].[Categorias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriaEmpleado'
CREATE INDEX [IX_FK_CategoriaEmpleado]
ON [dbo].[Personas_Empleado]
    ([CategoriaId]);
GO

-- Creating foreign key on [DireccionId] in table 'Comprobantes_ComprobanteDelivery'
ALTER TABLE [dbo].[Comprobantes_ComprobanteDelivery]
ADD CONSTRAINT [FK_ComprobanteDeliveryDireccion]
    FOREIGN KEY ([DireccionId])
    REFERENCES [dbo].[Direcciones]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComprobanteDeliveryDireccion'
CREATE INDEX [IX_FK_ComprobanteDeliveryDireccion]
ON [dbo].[Comprobantes_ComprobanteDelivery]
    ([DireccionId]);
GO

-- Creating foreign key on [ListaDeliveryId] in table 'Configuraciones'
ALTER TABLE [dbo].[Configuraciones]
ADD CONSTRAINT [FK_ConfiguracionListaPrecioDelivery]
    FOREIGN KEY ([ListaDeliveryId])
    REFERENCES [dbo].[ListaPrecios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ConfiguracionListaPrecioDelivery'
CREATE INDEX [IX_FK_ConfiguracionListaPrecioDelivery]
ON [dbo].[Configuraciones]
    ([ListaDeliveryId]);
GO

-- Creating foreign key on [ListaKioscoId] in table 'Configuraciones'
ALTER TABLE [dbo].[Configuraciones]
ADD CONSTRAINT [FK_ConfiguracionListaPrecio]
    FOREIGN KEY ([ListaKioscoId])
    REFERENCES [dbo].[ListaPrecios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ConfiguracionListaPrecio'
CREATE INDEX [IX_FK_ConfiguracionListaPrecio]
ON [dbo].[Configuraciones]
    ([ListaKioscoId]);
GO

-- Creating foreign key on [MozoId] in table 'Configuraciones'
ALTER TABLE [dbo].[Configuraciones]
ADD CONSTRAINT [FK_ConfiguracionCategoria]
    FOREIGN KEY ([MozoId])
    REFERENCES [dbo].[Categorias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ConfiguracionCategoria'
CREATE INDEX [IX_FK_ConfiguracionCategoria]
ON [dbo].[Configuraciones]
    ([MozoId]);
GO

-- Creating foreign key on [CadeteId] in table 'Configuraciones'
ALTER TABLE [dbo].[Configuraciones]
ADD CONSTRAINT [FK_ConfiguracionCadete]
    FOREIGN KEY ([CadeteId])
    REFERENCES [dbo].[Categorias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ConfiguracionCadete'
CREATE INDEX [IX_FK_ConfiguracionCadete]
ON [dbo].[Configuraciones]
    ([CadeteId]);
GO

-- Creating foreign key on [CadeteId] in table 'Comprobantes_ComprobanteDelivery'
ALTER TABLE [dbo].[Comprobantes_ComprobanteDelivery]
ADD CONSTRAINT [FK_ComprobanteDeliveryCadete]
    FOREIGN KEY ([CadeteId])
    REFERENCES [dbo].[Personas_Empleado]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComprobanteDeliveryCadete'
CREATE INDEX [IX_FK_ComprobanteDeliveryCadete]
ON [dbo].[Comprobantes_ComprobanteDelivery]
    ([CadeteId]);
GO

-- Creating foreign key on [Id] in table 'Personas_Cliente'
ALTER TABLE [dbo].[Personas_Cliente]
ADD CONSTRAINT [FK_Cliente_inherits_Persona]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Personas]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'FormasPagos_FormaPagoCheque'
ALTER TABLE [dbo].[FormasPagos_FormaPagoCheque]
ADD CONSTRAINT [FK_FormaPagoCheque_inherits_FormaPago]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[FormasPagos]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Comprobantes_ComprobanteSalon'
ALTER TABLE [dbo].[Comprobantes_ComprobanteSalon]
ADD CONSTRAINT [FK_ComprobanteSalon_inherits_Comprobante]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Comprobantes]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'FormasPagos_FormaPagoCtaCte'
ALTER TABLE [dbo].[FormasPagos_FormaPagoCtaCte]
ADD CONSTRAINT [FK_FormaPagoCtaCte_inherits_FormaPago]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[FormasPagos]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'FormasPagos_FormaPagoTarjeta'
ALTER TABLE [dbo].[FormasPagos_FormaPagoTarjeta]
ADD CONSTRAINT [FK_FormaPagoTarjeta_inherits_FormaPago]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[FormasPagos]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Comprobantes_ComprobanteCompra'
ALTER TABLE [dbo].[Comprobantes_ComprobanteCompra]
ADD CONSTRAINT [FK_ComprobanteCompra_inherits_Comprobante]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Comprobantes]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Personas_Empleado'
ALTER TABLE [dbo].[Personas_Empleado]
ADD CONSTRAINT [FK_Empleado_inherits_Persona]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Personas]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Comprobantes_ComprobanteDelivery'
ALTER TABLE [dbo].[Comprobantes_ComprobanteDelivery]
ADD CONSTRAINT [FK_ComprobanteDelivery_inherits_Comprobante]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Comprobantes]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Comprobantes_ComprobanteFactura'
ALTER TABLE [dbo].[Comprobantes_ComprobanteFactura]
ADD CONSTRAINT [FK_ComprobanteFactura_inherits_Comprobante]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Comprobantes]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'FormasPagos_FormaPagoEfectivo'
ALTER TABLE [dbo].[FormasPagos_FormaPagoEfectivo]
ADD CONSTRAINT [FK_FormaPagoEfectivo_inherits_FormaPago]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[FormasPagos]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------