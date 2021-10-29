CREATE DATABASE OneToOneDB

USE OneToOneDB

CREATE TABLE Countries(
[CountryId] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Capitals(
[CapitalId] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(30) NOT NULL,
CountryId INT FOREIGN KEY REFERENCES Countries(CountryId),
UNIQUE(CountryId)
)

INSERT INTO Countries([Name])
VALUES('Norway'),('Azerbaijan'),('Turkey')

INSERT INTO Capitals([Name],[CountryId])
VALUES('Oslo',1),('Baku',2),('Ankara',3)