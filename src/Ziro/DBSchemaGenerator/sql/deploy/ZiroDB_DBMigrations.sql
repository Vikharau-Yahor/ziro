DECLARE @MigrationNumber int = 4;
DECLARE @MigrationName varchar(255) = '004_Add_ProjectView.sql'; 

CREATE TABLE Ziro_DbMigrations (MigrationNumer INT not null, MigrationName NVARCHAR(255) not null, PRIMARY KEY (MigrationNumer))

-- update dbVersion
INSERT INTO Ziro_DbMigrations VALUES(@MigrationNumber, @MigrationName)