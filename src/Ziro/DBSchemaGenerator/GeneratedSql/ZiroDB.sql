create table Ziro_User (Id UNIQUEIDENTIFIER not null, Email NVARCHAR(50) not null, PasswordHash NVARCHAR(255) not null, Role TINYINT not null, primary key (Id))
