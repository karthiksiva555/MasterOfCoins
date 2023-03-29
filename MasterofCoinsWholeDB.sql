---------------------------------------------------------------------------------------------------------
-- Create Master of Coins Database and its objects
---------------------------------------------------------------------------------------------------------

-- Create Database - only if doesn't exist already
IF DB_ID('MasterOfCoins') IS NULL
CREATE DATABASE MasterOfCoins;
GO

USE MasterOfCoins;
GO

--drop table Buddy
--drop table GroupDetails

IF (NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'GroupDetails'))
CREATE TABLE GroupDetails
(	Id INT IDENTITY NOT NULL,
	Name NVARCHAR(100) NOT NULL,
	Description NVARCHAR(100) NOT NULL,
	CreatedDate DATETIME DEFAULT(GETDATE()),
	ModifiedDate DATETIME,
	CreatedById INT,
	ModifiedById INT,
	Inactive BIT DEFAULT(0),
	PRIMARY KEY(Id)
)
GO

IF (NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Buddy'))
CREATE TABLE Buddy
(	Id INT IDENTITY NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	FirstName NVARCHAR(100) NOT NULL,
	BirthDate DATETIME,
	Email NVARCHAR(100),
	PhoneNumber NVARCHAR(15),
	CreatedDate DATETIME DEFAULT (GETDATE()),
	ModifiedDate DATETIME,
	CreatedById INT,
	ModifiedById INT,
	Inactive BIT DEFAULT(0),
	PRIMARY KEY(Id)
)
GO








