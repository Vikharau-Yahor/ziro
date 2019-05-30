DECLARE @MigrationNumber int = 7;
DECLARE @MigrationName varchar(255) = '007_ProjectInfoView_And_Documents.sql'; 

IF(NOT EXISTS(SELECT * FROM Ziro_DbMigrations WHERE MigrationNumer >= @MigrationNumber))
BEGIN
	EXECUTE (N'
		CREATE VIEW Ziro_ProjectInfoView
		AS
		SELECT p.Id as ProjectId, p.Name as ProjectName, p.ShortName AS ProjectShortName, p.Description as ProjectDescription, subNonClosed.NonClosedTasksCount, subUsers.TotalUsersCount
		FROM Ziro_Project p 
		LEFT JOIN (SELECT Count(*) AS NonClosedTasksCount, t.ProjectId FROM Ziro_Task t WHERE t.Status <> 4 GROUP BY(t.ProjectId)) subNonClosed ON subNonClosed.ProjectId = p.Id
		LEFT JOIN (SELECT Count(*) AS TotalUsersCount, pu.ProjectId FROM Ziro_Project_User pu GROUP BY(pu.ProjectId)) subUsers ON subUsers.ProjectId = p.Id
	')
	CREATE TABLE Ziro_ProjectDocument (Id UNIQUEIDENTIFIER NOT NULL, [FileName] NVARCHAR(100) NOT NULL, Description NVARCHAR(4000) NOT NULL, ContentType NVARCHAR(100) NOT NULL, ContentData VARBINARY(MAX) NOT NULL, UploadDate DATETIME2 NOT NULL, ProjectId UNIQUEIDENTIFIER NOT NULL, PRIMARY KEY(Id)) 
	ALTER TABLE Ziro_ProjectDocument ADD CONSTRAINT FK_D4CF9670 FOREIGN KEY(ProjectId) REFERENCES Ziro_Project 
	-- update dbVersion
	INSERT INTO Ziro_DbMigrations VALUES(@MigrationNumber, @MigrationName)
END
ELSE 
      PRINT N'Migration ' + @MigrationName + N' was skipped';