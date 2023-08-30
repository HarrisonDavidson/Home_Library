USE [master]
GO

IF db_id('HomeLibrary') IS NULL
  CREATE DATABASE [HomeLibrary]
GO

USE [HomeLibrary]
GO

DROP TABLE IF EXISTS Movies;
DROP TABLE IF EXISTS Shows;
DROP TABLE IF EXISTS Music;
DROP TABLE IF EXISTS VideoGames;
DROP TABLE IF EXISTS Books;

CREATE TABLE Movies (
    [Id]           INTEGER NOT NULL PRIMARY KEY IDENTITY,
    [Name]         VARCHAR (50)  NOT NULL,
    [YearReleased] VARCHAR (50) NOT NULL,
    [Director]     VARCHAR (50) NOT NULL,
    [Image]        VARCHAR (50)  NULL,
    [Format]       VARCHAR (50)  NULL,
    [Notes]        TEXT          NULL,
);

CREATE TABLE Shows (
    [Id]           INTEGER NOT NULL PRIMARY KEY IDENTITY,
    [Name]         VARCHAR (50)  NOT NULL,
    [YearReleased] VARCHAR (255) NOT NULL,
    [Image]        VARCHAR (50)  NULL,
    [Format]       VARCHAR (50)  NULL,
    [Notes]        TEXT          NULL,
);

CREATE TABLE Music (
    [Id]           INTEGER NOT NULL PRIMARY KEY IDENTITY,
    [Name]         VARCHAR (50)  NOT NULL,
    [Artist]       VARCHAR (50)  NOT NULL,
    [YearReleased] VARCHAR (255) NOT NULL,
    [Image]        VARCHAR (50)  NULL,
    [Format]       VARCHAR (50)  NULL,
    [Notes]        TEXT          NULL,
);

CREATE TABLE VideoGames (
    [Id]           INTEGER NOT NULL PRIMARY KEY IDENTITY,
    [Name]         VARCHAR (50) NOT NULL,
    [Studio]       VARCHAR (50) NOT NULL,
    [YearReleased] VARCHAR (50) NOT NULL,
    [Image]        VARCHAR (50)  NULL,
    [Format]       VARCHAR (50)  NOT NULL,
    [Notes]        TEXT          NULL,
);

CREATE TABLE Books (
    [Id]           INTEGER NOT NULL PRIMARY KEY IDENTITY,
    [Name]         VARCHAR (50) NOT NULL,
    [Author]       VARCHAR (50) NOT NULL,
    [YearReleased] VARCHAR (50) NOT NULL,
    [Image]        VARCHAR (50)  NULL,
    [Format]       VARCHAR (50)  NOT NULL,
    [Notes]        TEXT          NULL,
);
