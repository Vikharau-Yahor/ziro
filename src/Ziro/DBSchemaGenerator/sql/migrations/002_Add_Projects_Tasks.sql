DECLARE @MigrationNumber int = 2;
DECLARE @MigrationName varchar(255) = '002_Add_Projects_Tasks.sql'; 

IF(NOT EXISTS(SELECT * FROM Ziro_DbMigrations WHERE MigrationNumer >= @MigrationNumber))
BEGIN
	CREATE TABLE Ziro_Project (Id UNIQUEIDENTIFIER not null, Name NVARCHAR(255) not null, Description NVARCHAR(4000) not null, primary key (Id))
	CREATE TABLE Ziro_Project_User (ProjectId UNIQUEIDENTIFIER not null, UserId UNIQUEIDENTIFIER not null, primary key (UserId, ProjectId))
	CREATE TABLE Ziro_Task (Id UNIQUEIDENTIFIER not null, Title NVARCHAR(400) not null, ProjectId UNIQUEIDENTIFIER null, primary key (Id))
	ALTER TABLE Ziro_Project_User ADD CONSTRAINT FK_BB2FA862 FOREIGN KEY (UserId) REFERENCES Ziro_User
	ALTER TABLE Ziro_Project_User ADD CONSTRAINT FK_2AB040CF FOREIGN KEY (ProjectId) REFERENCES Ziro_Project
	ALTER TABLE Ziro_Task ADD CONSTRAINT FK_43C0502B FOREIGN KEY (ProjectId) REFERENCES Ziro_Project
	
	-- update dbVersion
	INSERT INTO Ziro_DbMigrations VALUES(@MigrationNumber, @MigrationName)
END
ELSE 
      PRINT N'Migration ' + @MigrationName + N' was skipped';