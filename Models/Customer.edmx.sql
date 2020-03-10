
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/08/2020 23:20:50
-- Generated from EDMX file: C:\Users\NAWAB\Desktop\CsharpAssignment\CsharpAssignment\Models\Customer.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CSharpAssignment];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Customer__CityId__3A81B327]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Customers] DROP CONSTRAINT [FK__Customer__CityId__3A81B327];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Cities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cities];
GO
IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Cities'
CREATE TABLE [dbo].[Cities] (
    [CityId] int IDENTITY(1,1) NOT NULL,
    [CityName] varchar(50)  NULL,
    [CreatedDate] datetime  NULL,
    [UpdatedDate] datetime  NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [CustomerId] int IDENTITY(1,1) NOT NULL,
    [CustomerName] varchar(50)  NULL,
    [Address1] varchar(50)  NULL,
    [Address2] varchar(50)  NULL,
    [CityId] int  NULL,
    [Country] varchar(50)  NULL,
    [PostCode] varchar(12)  NULL,
    [Email] varchar(50)  NULL,
    [Mobile] varchar(10)  NULL,
    [BirthDate] datetime  NULL,
    [Active] bit  NULL,
    [CreatedDate] datetime  NULL,
    [UpadatedDate] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CityId] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [PK_Cities]
    PRIMARY KEY CLUSTERED ([CityId] ASC);
GO

-- Creating primary key on [CustomerId] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([CustomerId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CityId] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [FK__Customer__CityId__3A81B327]
    FOREIGN KEY ([CityId])
    REFERENCES [dbo].[Cities]
        ([CityId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Customer__CityId__3A81B327'
CREATE INDEX [IX_FK__Customer__CityId__3A81B327]
ON [dbo].[Customers]
    ([CityId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------