CREATE TABLE [dbo].[ProductFamilies]
(
    [ID] NVARCHAR(50) NOT NULL,
    [Name] NVARCHAR(200) NOT NULL,
    [Brand] NVARCHAR(200) NOT NULL, 
    [Room] NVARCHAR(200) NOT NULL, 
    [Flags] INT NULL, 
    CONSTRAINT [PK_ProductFamilies] PRIMARY KEY CLUSTERED ([ID] ASC)
)
