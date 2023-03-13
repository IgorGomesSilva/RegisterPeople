GO
PRINT N'Creating [RegisterPeopleDB]...';

GO
CREATE DATABASE [RegisterPeopleDB]

GO

USE [RegisterPeopleDB]

PRINT N'Creating [RegisterPeopleDB].[Person]...';

CREATE TABLE [Person] (
    Id int IDENTITY NOT NULL,
    Nome varchar(50) NOT NULL,
    Sobrenome varchar(100) NOT NULL,
    Email varchar(100) NOT NULL,
    DataCadastro datetime NOT NULL,
    CPF varchar(11) NOT NULL,
    IsAtivo bit NOT NULL,
    PRIMARY KEY (Id)
);

GO
PRINT N'Creating [RegisterPeopleDB].[Address]...';

CREATE TABLE [Address] (
    Id int IDENTITY NOT NULL,
    Logadouro varchar(150) NOT NULL,
    Bairro varchar(100) NOT NULL,
    Numero varchar(15) NOT NULL,
    Complemento varchar(255) NULL,
    Cidade varchar(50) NOT NULL,
    Estado varchar(30) NOT NULL,
    Pais varchar(50) NOT NULL,
    CEP varchar(8) NOT NULL,
    IdPerson int NOT NULL,
    PRIMARY KEY (Id)
);

GO 
PRINT N'Alter [RegisterPeopleDB].[Address]...';

ALTER TABLE
    [Address]
ADD
    CONSTRAINT FKAddress FOREIGN KEY (IdPerson) REFERENCES Person (Id);