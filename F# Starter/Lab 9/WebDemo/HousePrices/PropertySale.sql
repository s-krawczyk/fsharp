CREATE TABLE [dbo].[PropertySale]
(
	[Transaction unique identifier] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Price] INT NOT NULL, 
    [DateOfTransfer] DATETIME2 NOT NULL, 
    [Postcode] VARCHAR(16) NOT NULL, 
    [PropertyType] NCHAR(10) NOT NULL, 
    [OldNew] VARCHAR(8) NOT NULL, 
    [Duration] VARCHAR(8) NOT NULL, 
    [PAON] VARCHAR(128) NOT NULL, 
    [SAON] VARCHAR(128) NOT NULL, 
    [Street] VARCHAR(128) NOT NULL, 
    [Locality] VARCHAR(128) NOT NULL, 
    [TownCity] VARCHAR(128) NOT NULL, 
    [District] VARCHAR(64) NOT NULL, 
    [County] VARCHAR(64) NOT NULL, 
    [PpdCategoryType] VARCHAR(64) NOT NULL, 
    [RecordStatus] VARCHAR(8) NULL
)
