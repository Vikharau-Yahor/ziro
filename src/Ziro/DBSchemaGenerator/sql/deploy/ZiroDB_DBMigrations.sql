DECLARE @MigrationNumber int = 3;
DECLARE @MigrationName varchar(255) = '003_Update_All_Add_Position.sql'; 

CREATE TABLE Ziro_DbMigrations (MigrationNumer INT not null, MigrationName NVARCHAR(255) not null, PRIMARY KEY (MigrationNumer))

-- update dbVersion
INSERT INTO Ziro_DbMigrations VALUES(@MigrationNumber, @MigrationName)