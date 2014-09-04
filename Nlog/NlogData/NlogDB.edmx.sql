
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/04/2014 10:56:07
-- Generated from EDMX file: D:\git\Nlog\NlogData\NlogDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [NLogDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[NLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NLog];
GO
IF OBJECT_ID(N'[dbo].[NLogConfirm]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NLogConfirm];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'NLog'
CREATE TABLE [dbo].[NLog] (
    [ID] bigint  NOT NULL,
    [VisitDate] datetime  NULL,
    [ItemText] nvarchar(2000)  NULL,
    [SpendTime] nvarchar(500)  NULL,
    [Tag] nvarchar(500)  NULL
);
GO

-- Creating table 'NLogConfirm'
CREATE TABLE [dbo].[NLogConfirm] (
    [ID] bigint  NOT NULL,
    [VisitDate] datetime  NULL,
    [ItemText] nvarchar(2000)  NULL,
    [SpendTime] nvarchar(500)  NULL,
    [Tag] nvarchar(500)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'NLog'
ALTER TABLE [dbo].[NLog]
ADD CONSTRAINT [PK_NLog]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'NLogConfirm'
ALTER TABLE [dbo].[NLogConfirm]
ADD CONSTRAINT [PK_NLogConfirm]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------