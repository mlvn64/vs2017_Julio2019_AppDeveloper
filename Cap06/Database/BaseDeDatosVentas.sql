USE Tienda
GO

/****** Object:  Table [dbo].[Invoice]    Script Date: 2/08/2019 20:19:12 ******/
CREATE TABLE Venta
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Cliente NVARCHAR(MAX) NOT NULL,
	Total FLOAT NOT NULL,
	Fecha DateTime
)


CREATE TABLE VentaDetalle
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	VentaId INT NOT NULL,
	Producto NVARCHAR(MAX) NOT NULL, 
	Monto FLOAT NOT NULL,
	Foreign key (VentaId) REFERENCES Venta(Id)
)

GO

CREATE TYPE DatosDelDetalle AS
TABLE
(
	Producto NVARCHAR(MAX) NOT NULL, 
	Monto FLOAT NOT NULL
)


GO

ALTER PROCEDURE RegistrarVenta(@Cliente NVARCHAR(MAX), @Detalles DatosDelDetalle READONLY)
AS
BEGIN
	DECLARE @TotalCalculado FLOAT = (SELECT SUM(Monto) FROM @Detalles)

	BEGIN TRAN T1;  

	INSERT INTO Venta(Cliente,Total,Fecha)
	VALUES (@Cliente, @TotalCalculado , GETDATE())

	DECLARE @NewId INT = scope_identity();

	INSERT INTO VentaDetalle(VentaId,Producto,Monto)
	SELECT	@NewId,
			Producto,
			Monto
	FROM    @Detalles

	COMMIT TRAN T1;

	SELECT * FROM Venta Where Id = @NewId

	SELECT * FROM VentaDetalle WHERE VentaId = @NewId

END