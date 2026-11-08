Use SqlExerciseDB

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