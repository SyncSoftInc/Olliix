CREATE VIEW [dbo].[V_ProductItems]
AS
SELECT * FROM [ProductItems]
WHERE [Flags] IS NULL       -- 没有标记
OR    ([Flags] & 2) <> 2    -- 或者没有标记为Inactive