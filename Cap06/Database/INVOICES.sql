CREATE TYPE ListOfInts AS
TABLE 
(
	Id INT NOT NULL
)

GO


CREATE PROCEDURE [dbo].[GetInvoicesByIds](@Ids ListOfInts readonly)
AS 
BEGIN

	SELECT * FROM dbo.Invoice WHERE InvoiceId IN (SELECT Id FROM @Ids)

	SELECT * FROM dbo.InvoiceLine WHERE InvoiceId IN (SELECT Id FROM @Ids)

END

GO

DECLARE @IdList ListOfInts;

INSERT INTO @IdList
VALUES (1),(2),(3)

EXEC dbo.GetInvoicesByIds @Ids = @IdList



