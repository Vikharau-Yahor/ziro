create table Ziro_Project (Id UNIQUEIDENTIFIER not null, Name NVARCHAR(255) not null, Description NVARCHAR(4000) not null, primary key (Id))
create table Ziro_Project_User (ProjectId UNIQUEIDENTIFIER not null, UserId UNIQUEIDENTIFIER not null, primary key (UserId, ProjectId))
create table Ziro_Task (Id UNIQUEIDENTIFIER not null, Title NVARCHAR(400) not null, ProjectId UNIQUEIDENTIFIER null, primary key (Id))
create table Ziro_User (Id UNIQUEIDENTIFIER not null, Email NVARCHAR(50) not null, PasswordHash NVARCHAR(255) not null, Role TINYINT not null, primary key (Id))
alter table Ziro_Project_User add constraint FK_BB2FA862 foreign key (UserId) references Ziro_User
alter table Ziro_Project_User add constraint FK_2AB040CF foreign key (ProjectId) references Ziro_Project
alter table Ziro_Task add constraint FK_43C0502B foreign key (ProjectId) references Ziro_Project
