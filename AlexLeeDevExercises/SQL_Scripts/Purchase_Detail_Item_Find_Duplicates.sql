Use SqlExerciseDB

SELECT COUNT(*) AS Duplicate_Records_Count, 
	PurchaseOrderNumber,
	ItemNumber,
	PurchasePrice,
	PurchaseQuantity
FROM PurchaseDetailItem
GROUP BY PurchaseOrderNumber,
	ItemNumber,
	PurchasePrice,
	PurchaseQuantity
HAVING COUNT(*) > 1