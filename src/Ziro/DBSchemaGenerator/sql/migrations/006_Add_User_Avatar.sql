DECLARE @MigrationNumber int = 6;
DECLARE @MigrationName varchar(255) = '006_Add_User_Avatar.sql'; 

IF(NOT EXISTS(SELECT * FROM Ziro_DbMigrations WHERE MigrationNumer >= @MigrationNumber))
BEGIN
	CREATE TABLE Ziro_Avatar (Id UNIQUEIDENTIFIER NOT NULL, ContentType NVARCHAR(100) NOT NULL, ImageData VARBINARY(MAX) NOT NULL, UserId UNIQUEIDENTIFIER NOT NULL, PRIMARY KEY(Id))
	
	ALTER TABLE Ziro_Avatar ADD CONSTRAINT FK_40692529 FOREIGN KEY (UserId) REFERENCES Ziro_User 
	-- update dbVersion
	INSERT INTO Ziro_DbMigrations VALUES(@MigrationNumber, @MigrationName)
END
ELSE 
      PRINT N'Migration ' + @MigrationName + N' was skipped';