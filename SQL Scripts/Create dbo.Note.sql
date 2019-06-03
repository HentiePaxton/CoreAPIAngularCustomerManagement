USE [CompanyDB]
GO

/****** Object: Table [dbo].[Note] Script Date: 6/3/2019 5:33:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Note] (
    [PK_NoteID]     INT            IDENTITY (1, 1) NOT NULL,
    [Note]          NVARCHAR (500) NULL,
    [FK_CustomerID] INT            NULL
);


