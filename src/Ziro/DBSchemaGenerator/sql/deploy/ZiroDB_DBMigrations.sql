DECLARE @MigrationNumber int = 5;
DECLARE @MigrationName varchar(255) = '005_Add_Comments_And_LogWork.sql'; 

CREATE TABLE Ziro_DbMigrations (MigrationNumer INT not null, MigrationName NVARCHAR(255) not null, PRIMARY KEY (MigrationNumer))

-- update dbVersion
INSERT INTO Ziro_DbMigrations VALUES(@MigrationNumber, @MigrationName)