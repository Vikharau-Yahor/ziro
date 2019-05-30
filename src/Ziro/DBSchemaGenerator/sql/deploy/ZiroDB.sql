create table Ziro_Avatar (Id UNIQUEIDENTIFIER not null, ContentType NVARCHAR(100) not null, ImageData VARBINARY(MAX) not null, UserId UNIQUEIDENTIFIER not null, primary key (Id))
create table Ziro_Comment (Id UNIQUEIDENTIFIER not null, Text NVARCHAR(4000) null, Date DATETIME2 not null, AuthorId UNIQUEIDENTIFIER null, TaskId UNIQUEIDENTIFIER null, primary key (Id))
create table Ziro_LogWork (Id UNIQUEIDENTIFIER not null, Text NVARCHAR(4000) null, SpentTimeHours FLOAT(53) not null, Date DATETIME2 not null, AuthorId UNIQUEIDENTIFIER null, TaskId UNIQUEIDENTIFIER null, primary key (Id))
create table Ziro_Position (Id UNIQUEIDENTIFIER not null, Name NVARCHAR(400) not null, primary key (Id))
create table Ziro_ProjectDocument (Id UNIQUEIDENTIFIER not null, FileName NVARCHAR(100) not null, Description NVARCHAR(4000) not null, ContentType NVARCHAR(100) not null, ContentData VARBINARY(MAX) not null, UploadDate DATETIME2 not null, ProjectId UNIQUEIDENTIFIER not null, primary key (Id))
create table Ziro_Project (Id UNIQUEIDENTIFIER not null, Name NVARCHAR(255) not null, ShortName NVARCHAR(5) not null, Description NVARCHAR(4000) not null, primary key (Id))
create table Ziro_Project_User (ProjectId UNIQUEIDENTIFIER not null, UserId UNIQUEIDENTIFIER not null, primary key (UserId, ProjectId))
create table Ziro_Task (Id UNIQUEIDENTIFIER not null, Number INT not null, Type TINYINT not null, Status TINYINT not null, Title NVARCHAR(400) not null, Description NVARCHAR(MAX) null, Priority TINYINT not null, EstimatedTime FLOAT(53) null, SpentTime FLOAT(53) null, CreationDate DATETIME2 not null, LastUpdateDate DATETIME2 not null, ProjectId UNIQUEIDENTIFIER null, AssigneeId UNIQUEIDENTIFIER null, OwnerId UNIQUEIDENTIFIER null, primary key (Id))
create table Ziro_User (Id UNIQUEIDENTIFIER not null, Email NVARCHAR(50) not null, PasswordHash NVARCHAR(255) not null, Role TINYINT not null, Name NVARCHAR(250) null, LastName NVARCHAR(250) null, Skype NVARCHAR(150) null, PhoneNumber NVARCHAR(20) null, DateOfBirth DATETIME2 null, PositionId UNIQUEIDENTIFIER null, primary key (Id))
alter table Ziro_Avatar add constraint FK_40692529 foreign key (UserId) references Ziro_User
alter table Ziro_Comment add constraint FK_E1D32329 foreign key (AuthorId) references Ziro_User
alter table Ziro_Comment add constraint FK_4BEF0DEF foreign key (TaskId) references Ziro_Task
alter table Ziro_LogWork add constraint FK_68853563 foreign key (AuthorId) references Ziro_User
alter table Ziro_LogWork add constraint FK_DBE31971 foreign key (TaskId) references Ziro_Task
alter table Ziro_ProjectDocument add constraint FK_D4CF9670 foreign key (ProjectId) references Ziro_Project
alter table Ziro_Project_User add constraint FK_BB2FA862 foreign key (UserId) references Ziro_User
alter table Ziro_Project_User add constraint FK_2AB040CF foreign key (ProjectId) references Ziro_Project
alter table Ziro_Task add constraint FK_43C0502B foreign key (ProjectId) references Ziro_Project
alter table Ziro_Task add constraint FK_BF4B4A66 foreign key (AssigneeId) references Ziro_User
alter table Ziro_Task add constraint FK_40F2FE29 foreign key (OwnerId) references Ziro_User
alter table Ziro_User add constraint FK_ED0A9737 foreign key (PositionId) references Ziro_Position
