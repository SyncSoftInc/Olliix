CREATE TRIGGER [TRG_ProductItems]
ON [ProductItems]
FOR INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ItemNo NVARCHAR(50);
    DECLARE @Family_ID NVARCHAR(50);

    SELECT @Family_ID = Family_ID FROM inserted;

    UPDATE ProductFamilies SET Flags = ISNULL((Flags | 1), 1) WHERE ID = @Family_ID    -- 将指定Family标记为有更新
END
