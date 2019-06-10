﻿CREATE TABLE [dbo].[ProductItems] (
    [ItemNo]           NVARCHAR (50)   NOT NULL,
    [Family_ID]        NVARCHAR (50)   NOT NULL,
    [Size]             NVARCHAR (50)   NOT NULL,
    [Color]            NVARCHAR (50)   NOT NULL,
    [ImageHash]        NVARCHAR (50)   NOT NULL,
    [ImageUrl]         NVARCHAR (300)  NOT NULL,
    [UPC]              NVARCHAR (50)   NOT NULL,
    [Description]      NVARCHAR (2000) DEFAULT (NULL) NULL,
    [ProductDetails]   NVARCHAR (2000) DEFAULT (NULL) NULL,
    [MaterialDetails]  NVARCHAR (2000) DEFAULT (NULL) NULL,
    [CareInstructions] NVARCHAR (2000) DEFAULT (NULL) NULL,
    [MSRPrice]         DECIMAL (18, 2) NOT NULL,
    [Price]            DECIMAL (18, 2) NOT NULL,
    [Length]           DECIMAL (18, 2) DEFAULT (NULL) NULL,
    [Width]            DECIMAL (18, 2) DEFAULT (NULL) NULL,
    [Height]           DECIMAL (18, 2) DEFAULT (NULL) NULL,
    [Status]           INT             NOT NULL,
    CONSTRAINT [PK_ProductItems] PRIMARY KEY CLUSTERED ([ItemNo] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_ProductItems_FamilyID]
    ON [dbo].[ProductItems]([Family_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProductItems_FamilyID_ImageHash]
    ON [dbo].[ProductItems]([Family_ID] ASC, [ImageHash] ASC);

