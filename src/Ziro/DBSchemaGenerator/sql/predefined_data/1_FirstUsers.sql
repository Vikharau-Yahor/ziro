INSERT INTO [dbo].[Ziro_Position]
           ([Id]
           ,[Name])
     VALUES
           ('93409976-6A3C-4AF8-A9CC-D0921741CE87'
           ,'Инженер-программист')

INSERT INTO [dbo].[Ziro_Position]
           ([Id]
           ,[Name])
     VALUES
           ('E42DA2A1-AB5D-48D9-BAEE-65A5A7FC4307'
           ,'Тестировщик')

INSERT INTO [dbo].[Ziro_Position]
           ([Id]
           ,[Name])
     VALUES
           ('B4BB4000-7DDC-4CB9-B09E-1E6879F48CF3'
           ,'Бизнес-аналитик')

INSERT INTO [dbo].[Ziro_Position]
           ([Id]
           ,[Name])
     VALUES
           ('77409976-AA3C-4AF8-A9CC-D0921741CE87'
           ,'Менеджер проекта')

INSERT INTO [dbo].[Ziro_User]
           ([Id],[Email],[PasswordHash],[Role],[Name],[LastName],[Skype],[PhoneNumber],[DateOfBirth],[PositionId])
     VALUES
           ('93A09976-6A3C-4AF8-A9CC-D0921741CE87'
           ,'testUser@mail.com'
           ,'523'
           ,1
           ,'Сергей'
           ,'Шикайло'
           ,null
           ,null
           ,'1994-03-11'
           ,'93409976-6A3C-4AF8-A9CC-D0921741CE87')

INSERT INTO [dbo].[Ziro_User]
           ([Id],[Email],[PasswordHash],[Role],[Name],[LastName],[Skype],[PhoneNumber],[DateOfBirth],[PositionId])
     VALUES
           ('A32F9976-6A3C-4AF8-A9CC-D0921741CE87',
           'testUser2@mail.com',
           '1111'
           ,1
           ,'Максим'
           ,'Ургант'
           ,'live:maks4234'
           ,'8029-325-53-23'
           ,'1994-03-11'
           ,'77409976-AA3C-4AF8-A9CC-D0921741CE87')

INSERT INTO [dbo].[Ziro_User]
           ([Id],[Email],[PasswordHash],[Role],[Name],[LastName],[Skype],[PhoneNumber],[DateOfBirth],[PositionId])
     VALUES
           ('F4CC4000-7DDC-4CB9-B09E-1E6879F48CF3',
           'qa@mail.com',
           'qa'
           ,1
           ,'Дарья'
           ,'Шевченко'
           ,'live:darya1234'
           ,'8029-365-33-15'
           ,'1996-05-21'
           ,'E42DA2A1-AB5D-48D9-BAEE-65A5A7FC4307')

INSERT INTO [dbo].[Ziro_User]
           ([Id],[Email],[PasswordHash],[Role],[Name],[LastName],[Skype],[PhoneNumber],[DateOfBirth],[PositionId])
     VALUES
           ('6B2F9976-6A3C-4AF8-A9CC-D0921741CE87',
           'admin@mail.com',
           'admin'
           ,0
           ,null
           ,null
           ,null
           ,null
           ,null
           ,null)
