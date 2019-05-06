INSERT INTO [dbo].[Ziro_Position]
           ([Id]
           ,[Name])
     VALUES
           ('93409976-6A3C-4AF8-A9CC-D0921741CE87'
           ,'Software Engineeer')

INSERT INTO [dbo].[Ziro_Position]
           ([Id]
           ,[Name])
     VALUES
           ('77409976-AA3C-4AF8-A9CC-D0921741CE87'
           ,'Project Manager')

INSERT INTO [dbo].[Ziro_User]
           ([Id]
           ,[Email]
           ,[PasswordHash]
           ,[Role]
           ,[Name]
           ,[LastName]
           ,[Skype]
           ,[PhoneNumber]
           ,[DateOfBirth]
           ,[PositionId])
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
           ([Id]
           ,[Email]
           ,[PasswordHash]
           ,[Role]
           ,[Name]
           ,[LastName]
           ,[Skype]
           ,[PhoneNumber]
           ,[DateOfBirth]
           ,[PositionId])
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
           ([Id]
           ,[Email]
           ,[PasswordHash]
           ,[Role]
           ,[Name]
           ,[LastName]
           ,[Skype]
           ,[PhoneNumber]
           ,[DateOfBirth]
           ,[PositionId])
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
