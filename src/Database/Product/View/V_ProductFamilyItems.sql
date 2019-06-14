CREATE VIEW [dbo].[V_ProductFamilyItems]
AS
SELECT t1.[Name]
,t1.[Brand]
,t1.[Room]
,t2.*
FROM [ProductFamilies] t1
INNER JOIN [V_ProductItems] t2 ON t2.Family_ID = t1.ID