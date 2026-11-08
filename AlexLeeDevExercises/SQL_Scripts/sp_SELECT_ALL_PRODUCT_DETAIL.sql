SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Benjamin Pack
-- Create date: 11/5/2026
-- Description:	Select and return a list of purchase detail records with the line number per item, per purchase order number
-- =============================================
CREATE PROCEDURE sp_SELECT_ALL_PRODUCT_DETAIL
AS
BEGIN
	SET NOCOUNT ON;

   SELECT PurchaseDetailItemAutoId,
		PurchaseOrderNumber,
		ROW_NUMBER() OVER (PARTITION BY PurchaseOrderNumber, ItemNumber ORDER BY PurchaseOrderNumber, ItemNumber) AS LineNumber,
		ItemNumber,
		ItemName,
		ItemDescription,
		PurchasePrice,
		PurchaseQuantity,
		LastModifiedByUser,
		LastModifiedDateTime
	FROM PurchaseDetailItem
	ORDER BY PurchaseOrderNumber, ItemNumber, LineNumber ASC

END
GO
