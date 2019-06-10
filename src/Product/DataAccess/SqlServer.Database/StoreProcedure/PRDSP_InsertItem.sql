CREATE PROCEDURE [dbo].[PRDSP_InsertItem]
      @ItemNo NVARCHAR(50)
    , @Family_ID NVARCHAR(50)
    , @Size NVARCHAR(50)
    , @Color NVARCHAR(50)
    , @ImageHash NVARCHAR(50)
    , @ImageUrl NVARCHAR(50)
    , @UPC NVARCHAR(50)
    , @Description NVARCHAR(50)
    , @ProductDetails NVARCHAR(50)
    , @MaterialDetails NVARCHAR(50)
    , @CareInstructions NVARCHAR(50)
    , @MSRPrice DECIMAL(18,2)
    , @Price DECIMAL(18,2)
    , @Length DECIMAL(18,2)
    , @Width DECIMAL(18,2)
    , @Height DECIMAL(18,2)
    , @Flags INT
AS
BEGIN
    SET NOCOUNT ON;

INSERT INTO ProductItems(
      ItemNo
    , Family_ID
    , Size
    , Color
    , ImageHash
    , ImageUrl
    , UPC
    , Description
    , ProductDetails
    , MaterialDetails
    , CareInstructions
    , MSRPrice
    , Price
    , Length
    , Width
    , Height
    , Flags
) VALUES(
      @ItemNo
    , @Family_ID
    , @Size
    , @Color
    , @ImageHash
    , @ImageUrl
    , @UPC
    , @Description
    , @ProductDetails
    , @MaterialDetails
    , @CareInstructions
    , @MSRPrice
    , @Price
    , @Length
    , @Width
    , @Height
    , @Flags
)
END