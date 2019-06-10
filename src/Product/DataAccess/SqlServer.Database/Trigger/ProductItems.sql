CREATE TRIGGER [TRG_ProductItems]
ON [ProductItems]
FOR INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ItemNo NVARCHAR(50);

    SELECT @ItemNo = ItemNo FROM inserted;

    UPDATE ProductItems SET Flags = (Flags | 1) WHERE ItemNo = @ItemNo
END
