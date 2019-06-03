USE [CompanyDB]
GO

/****** Object: Table [dbo].[Status] Script Date: 6/3/2019 5:33:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Status] (
    [PK_StatusID] INT           IDENTITY (1, 1) NOT NULL,
    [Status]      NVARCHAR (50) NOT NULL
);


