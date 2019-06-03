USE [CompanyDB]
GO

/****** Object: Table [dbo].[Customer] Script Date: 6/3/2019 5:33:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer] (
    [PK_CustomerID] INT              IDENTITY (1, 1) NOT NULL,
    [Firstname]     VARCHAR (255)    NULL,
    [Lastname]      VARCHAR (255)    NULL,
    [Email]         VARCHAR (255)    NULL,
    [CellNo]        VARCHAR (100)    NULL,
    [Address]       VARCHAR (255)    NULL,
    [City]          VARCHAR (255)    NULL,
    [Region]        VARCHAR (50)     NULL,
    [Country]       VARCHAR (100)    NULL,
    [Postal Code]   VARCHAR (10)     NULL,
    [CustomerID]    UNIQUEIDENTIFIER NULL,
    [Status]        VARCHAR (255)    NULL,
    [CreateDate]    VARCHAR (255)    NULL,
    [PassportNo]    VARCHAR (13)     NULL,
    [FK_StatusID]   INT              NULL
);


