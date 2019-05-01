DECLARE @MigrationNumber int = 1;
DECLARE @MigrationName varchar(255) = '001_Initial.sql'; 

CREATE TABLE Ziro_User (Id UNIQUEIDENTIFIER not null, Email NVARCHAR(50) not null, PasswordHash NVARCHAR(255) not null, Role TINYINT not null, PRIMARY KEY (Id))
CREATE TABLE Ziro_DbMigrations (MigrationNumer INT not null, MigrationName NVARCHAR(255) not null, PRIMARY KEY (MigrationNumer))

-- update dbVersion
INSERT INTO Ziro_DbMigrations VALUES(@MigrationNumber, @MigrationName)