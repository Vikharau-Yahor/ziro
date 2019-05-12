DECLARE @MigrationNumber int = 6;
DECLARE @MigrationName varchar(255) = '006_Add_User_Avatar.sql'; 

CREATE TABLE Ziro_DbMigrations (MigrationNumer INT not null, MigrationName NVARCHAR(255) not null, PRIMARY KEY (MigrationNumer))

-- update dbVersion
INSERT INTO Ziro_DbMigrations VALUES(@MigrationNumber, @MigrationName)