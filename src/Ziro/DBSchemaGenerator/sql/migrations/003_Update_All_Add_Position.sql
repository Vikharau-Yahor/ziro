DECLARE @MigrationNumber int = 3;
DECLARE @MigrationName varchar(255) = '003_Update_All_Add_Position.sql'; 

IF(NOT EXISTS(SELECT * FROM Ziro_DbMigrations WHERE MigrationNumer >= @MigrationNumber))
BEGIN
	DELETE FROM Ziro_Project_User
	DELETE FROM Ziro_Task
	DELETE FROM Ziro_Project
	DELETE FROM Ziro_User

	CREATE TABLE Ziro_Position (Id UNIQUEIDENTIFIER NOT NULL, [Name] NVARCHAR(400) NOT NULL, PRIMARY KEY (Id)) 
	
	ALTER TABLE Ziro_Project 
	ADD ShortName NVARCHAR(5) NOT NULL CONSTRAINT DC_Ziro_Project_ShortName_Temp DEFAULT 'XXXX';
	ALTER TABLE Ziro_Project DROP CONSTRAINT DC_Ziro_Project_ShortName_Temp

	ALTER TABLE Ziro_Task 
	ADD Number INT NOT NULL CONSTRAINT DC_Ziro_Task_Number_Temp DEFAULT 1111,
		[Type] TINYINT NOT NULL CONSTRAINT DC_Ziro_Task_Type_Temp DEFAULT 0,
		[Status] TINYINT NOT NULL CONSTRAINT DC_Ziro_Task_Status_Temp DEFAULT 0,
		[Description] NVARCHAR(MAX) NULL, 
		[Priority] TINYINT NOT NULL CONSTRAINT DC_Ziro_Task_Priority_Temp DEFAULT 0,
		EstimatedTime FLOAT(53) NULL, 
		SpentTime FLOAT(53) NULL, 
		CreationDate DATETIME2 NOT NULL CONSTRAINT DC_Ziro_Task_CreationDate_Temp DEFAULT '2019-01-01',
		LastUpdateDate DATETIME2 NOT NULL CONSTRAINT DC_Ziro_Task_LastUpdateDate_Temp DEFAULT '2019-01-01', 
		AssigneeId UNIQUEIDENTIFIER NULL, 
		OwnerId UNIQUEIDENTIFIER NULL;
	ALTER TABLE Ziro_Task DROP CONSTRAINT DC_Ziro_Task_Number_Temp
	ALTER TABLE Ziro_Task DROP CONSTRAINT DC_Ziro_Task_Type_Temp
	ALTER TABLE Ziro_Task DROP CONSTRAINT DC_Ziro_Task_Status_Temp
	ALTER TABLE Ziro_Task DROP CONSTRAINT DC_Ziro_Task_Priority_Temp
	ALTER TABLE Ziro_Task DROP CONSTRAINT DC_Ziro_Task_CreationDate_Temp
	ALTER TABLE Ziro_Task DROP CONSTRAINT DC_Ziro_Task_LastUpdateDate_Temp

	ALTER TABLE Ziro_User 
	ADD [Name] NVARCHAR(250) NULL,
		LastName NVARCHAR(250) NULL, 
		Skype NVARCHAR(150) NULL, 
		PhoneNumber NVARCHAR(20) NULL, 
		DateOfBirth DATETIME2 NULL, 
		PositionId UNIQUEIDENTIFIER NULL;

	ALTER TABLE Ziro_Task ADD CONSTRAINT FK_BF4B4A66 FOREIGN KEY (AssigneeId) REFERENCES Ziro_User 
	ALTER TABLE Ziro_Task ADD CONSTRAINT FK_40F2FE29 FOREIGN KEY (OwnerId) REFERENCES Ziro_User 
    ALTER TABLE Ziro_User add constraint FK_ED0A9737 FOREIGN KEY (PositionId) REFERENCES Ziro_Position
	-- update dbVersion
	INSERT INTO Ziro_DbMigrations VALUES(@MigrationNumber, @MigrationName)
END
ELSE 
      PRINT N'Migration ' + @MigrationName + N' was skipped';