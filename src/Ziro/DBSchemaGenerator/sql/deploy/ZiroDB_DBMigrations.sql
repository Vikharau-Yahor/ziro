DECLARE @MigrationNumber int = 7;
DECLARE @MigrationName varchar(255) = '007_ProjectInfoView_And_Documents.sql';

CREATE TABLE Ziro_DbMigrations (MigrationNumer INT not null, MigrationName NVARCHAR(255) not null, PRIMARY KEY (MigrationNumer))

-- update dbVersion
INSERT INTO Ziro_DbMigrations VALUES(@MigrationNumber, @MigrationName)