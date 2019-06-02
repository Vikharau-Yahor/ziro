-- projects
INSERT INTO [dbo].[Ziro_Project]           
			([Id]
           ,[Name]
           ,[ShortName]
           ,[Description])
VALUES('17A09976-6A3C-4AF8-A9CC-D0921741CE87',
           'Vkontakte','VK','Универсальное средство для общения и поиска друзей и одноклассников, которым ежедневно пользуются десятки миллионов человек')

INSERT INTO [dbo].[Ziro_Project]           
			([Id]
           ,[Name]
           ,[ShortName]
           ,[Description])
VALUES('18A09976-6A3C-4AF8-A9CC-D0921741CE37',
           'Winamp','WP','Мощный аудиопроигрыватель пользующийся большой популярностью с 1996')

INSERT INTO [dbo].[Ziro_Project]           
			([Id]
           ,[Name]
           ,[ShortName]
           ,[Description])
VALUES('19A09976-633C-4AF8-A9CC-D0921741CE87',
           'Audacity','AUD','Аудиоредактор с возможностью замедления, совмещения треков и наложения большого количества аудио-эффектов')

		   INSERT INTO [dbo].[Ziro_Project]           
			([Id]
           ,[Name]
           ,[ShortName]
           ,[Description])
VALUES('21A0F976-633C-4AF8-A9CC-D0921741CE87',
           'Github','GITH','Система контроля версий для программных проектов')

INSERT INTO [dbo].[Ziro_Project]           
			([Id]
           ,[Name]
           ,[ShortName]
           ,[Description])
VALUES('22A03976-633C-4AF8-A9CC-D0921741CE87',
           'MS Visual Studio','VS','Среда разработки приложения различного типа под платформу .Net Framework')

INSERT INTO [dbo].[Ziro_Project]           
			([Id]
           ,[Name]
           ,[ShortName]
           ,[Description])
VALUES('23A03976-633C-4AF8-A9CC-D0921741CE87',
           'ЕРИП','ERIP','Единое расчётное и информационная система для соверешния платежей')

-- users

INSERT INTO [dbo].[Ziro_User]
           ([Id],[Email],[PasswordHash],[Role],[Name],[LastName],[Skype],[PhoneNumber],[DateOfBirth],[PositionId])
     VALUES
           ('F4CC4300-7DDC-4CB9-B09E-1E6879F48CF3',
           'qa2@mail.com',
           'qa2'
           ,1
           ,'Олег'
           ,'Воробьев'
           ,'live:oleg342'
           ,'8029-344-33-15'
           ,'1996-12-21'
           ,'E42DA2A1-AB5D-48D9-BAEE-65A5A7FC4307')

INSERT INTO [dbo].[Ziro_User]
           ([Id],[Email],[PasswordHash],[Role],[Name],[LastName],[Skype],[PhoneNumber],[DateOfBirth],[PositionId])
     VALUES
           ('F42C4000-7DDC-4CB9-B09E-1E6879F48CF3',
           'ba@mail.com',
           'ba'
           ,1
           ,'Алена'
           ,'Гладько'
           ,'live:alena324'
           ,'8029-565-33-15'
           ,'1998-05-21'
           ,'B4BB4000-7DDC-4CB9-B09E-1E6879F48CF3')

INSERT INTO [dbo].[Ziro_User]
           ([Id],[Email],[PasswordHash],[Role],[Name],[LastName],[Skype],[PhoneNumber],[DateOfBirth],[PositionId])
     VALUES
           ('22CC4090-7DDC-4CB9-B09E-1E6899F48CF3',
           'se@mail.com',
           'se'
           ,1
           ,'Сергей'
           ,'Розманов'
           ,'live:darya1234'
           ,'8029-365-33-15'
           ,'1996-05-21'
           ,'93409976-6A3C-4AF8-A9CC-D0921741CE87')

INSERT INTO [dbo].[Ziro_User]
           ([Id],[Email],[PasswordHash],[Role],[Name],[LastName],[Skype],[PhoneNumber],[DateOfBirth],[PositionId])
     VALUES
           ('33CC4000-7DDC-4CB9-B09E-1E6879F48CF3',
           'se2@mail.com',
           'se2'
           ,1
           ,'Радион'
           ,'Назаров'
           ,'live:rad1234'
           ,'8349-311-33-15'
           ,'1990-01-21'
           ,'93409976-6A3C-4AF8-A9CC-D0921741CE87')

INSERT INTO [dbo].[Ziro_User]
           ([Id],[Email],[PasswordHash],[Role],[Name],[LastName],[Skype],[PhoneNumber],[DateOfBirth],[PositionId])
     VALUES
           ('354C4000-7DDC-4CB9-B09E-1E6879F48CF3',
           'pm2@mail.com',
           'pm2'
           ,1
           ,'Назар'
           ,'Гарионов'
           ,'live:naz1234'
           ,'8029-311-33-15'
           ,'1990-01-21'
           ,'77409976-AA3C-4AF8-A9CC-D0921741CE87')


INSERT INTO [dbo].[Ziro_User]
           ([Id],[Email],[PasswordHash],[Role],[Name],[LastName],[Skype],[PhoneNumber],[DateOfBirth],[PositionId])
     VALUES
           ('645C4000-7DDC-4CB9-B09E-1E6879F48CF3',
           'se3@mail.com',
           'se3'
           ,1
           ,'Татьяна'
           ,'Самойлова'
           ,'live:ntd234'
           ,'8029-311-33-15'
           ,'1993-02-11'
           ,'93409976-6A3C-4AF8-A9CC-D0921741CE87')

INSERT INTO [dbo].[Ziro_User]
           ([Id],[Email],[PasswordHash],[Role],[Name],[LastName],[Skype],[PhoneNumber],[DateOfBirth],[PositionId])
     VALUES
           ('64554000-7DDC-4CB9-B09E-1E6879F48CF3',
           'ba2@mail.com',
           'ba2'
           ,1
           ,'Светлана'
           ,'Хотченко'
           ,'live:dfdd234'
           ,'8029-321-33-15'
           ,'1997-05-11'
           ,'B4BB4000-7DDC-4CB9-B09E-1E6879F48CF3')

-- projs to users

INSERT INTO [dbo].[Ziro_Project_User]
([ProjectId],[UserId])
VALUES ('17A09976-6A3C-4AF8-A9CC-D0921741CE87','A32F9976-6A3C-4AF8-A9CC-D0921741CE87'),
	('18A09976-6A3C-4AF8-A9CC-D0921741CE37','A32F9976-6A3C-4AF8-A9CC-D0921741CE87'),
	('19A09976-633C-4AF8-A9CC-D0921741CE87','A32F9976-6A3C-4AF8-A9CC-D0921741CE87'),
	('21A0F976-633C-4AF8-A9CC-D0921741CE87','A32F9976-6A3C-4AF8-A9CC-D0921741CE87'),
	('22A03976-633C-4AF8-A9CC-D0921741CE87','A32F9976-6A3C-4AF8-A9CC-D0921741CE87'),
	('23A03976-633C-4AF8-A9CC-D0921741CE87','A32F9976-6A3C-4AF8-A9CC-D0921741CE87'),

	('18A09976-6A3C-4AF8-A9CC-D0921741CE37','93A09976-6A3C-4AF8-A9CC-D0921741CE87'),
	('19A09976-633C-4AF8-A9CC-D0921741CE87','93A09976-6A3C-4AF8-A9CC-D0921741CE87'),

	('22A03976-633C-4AF8-A9CC-D0921741CE87','354C4000-7DDC-4CB9-B09E-1E6879F48CF3'),
	('23A03976-633C-4AF8-A9CC-D0921741CE87','354C4000-7DDC-4CB9-B09E-1E6879F48CF3'),
	('21A0F976-633C-4AF8-A9CC-D0921741CE87','354C4000-7DDC-4CB9-B09E-1E6879F48CF3'),

	('18A09976-6A3C-4AF8-A9CC-D0921741CE37','F4CC4000-7DDC-4CB9-B09E-1E6879F48CF3'),
	('19A09976-633C-4AF8-A9CC-D0921741CE87','F4CC4000-7DDC-4CB9-B09E-1E6879F48CF3'),
	('22A03976-633C-4AF8-A9CC-D0921741CE87','F4CC4000-7DDC-4CB9-B09E-1E6879F48CF3'),

	('15F09976-6A3C-4AF8-A9CC-D0921741CE87','F4CC4300-7DDC-4CB9-B09E-1E6879F48CF3'),
	('17A09976-6A3C-4AF8-A9CC-D0921741CE87','F4CC4300-7DDC-4CB9-B09E-1E6879F48CF3'),
	('21A0F976-633C-4AF8-A9CC-D0921741CE87','F4CC4300-7DDC-4CB9-B09E-1E6879F48CF3'),

	('15A09976-6A3C-4AF8-A9CC-D0921741CE87','F42C4000-7DDC-4CB9-B09E-1E6879F48CF3'),
	('15F09976-6A3C-4AF8-A9CC-D0921741CE87','F42C4000-7DDC-4CB9-B09E-1E6879F48CF3'),
	('17A09976-6A3C-4AF8-A9CC-D0921741CE87','F42C4000-7DDC-4CB9-B09E-1E6879F48CF3'),

	('18A09976-6A3C-4AF8-A9CC-D0921741CE37','64554000-7DDC-4CB9-B09E-1E6879F48CF3'),
	('21A0F976-633C-4AF8-A9CC-D0921741CE87','64554000-7DDC-4CB9-B09E-1E6879F48CF3'),
	('23A03976-633C-4AF8-A9CC-D0921741CE87','64554000-7DDC-4CB9-B09E-1E6879F48CF3'),

	('22A03976-633C-4AF8-A9CC-D0921741CE87','22CC4090-7DDC-4CB9-B09E-1E6899F48CF3'),
	('15A09976-6A3C-4AF8-A9CC-D0921741CE87','22CC4090-7DDC-4CB9-B09E-1E6899F48CF3'),
	('18A09976-6A3C-4AF8-A9CC-D0921741CE37','22CC4090-7DDC-4CB9-B09E-1E6899F48CF3'),

	('19A09976-633C-4AF8-A9CC-D0921741CE87','33CC4000-7DDC-4CB9-B09E-1E6879F48CF3'),
	('23A03976-633C-4AF8-A9CC-D0921741CE87','33CC4000-7DDC-4CB9-B09E-1E6879F48CF3'),
	('15F09976-6A3C-4AF8-A9CC-D0921741CE87','33CC4000-7DDC-4CB9-B09E-1E6879F48CF3'),

	('15A09976-6A3C-4AF8-A9CC-D0921741CE87','645C4000-7DDC-4CB9-B09E-1E6879F48CF3'),
	('21A0F976-633C-4AF8-A9CC-D0921741CE87','645C4000-7DDC-4CB9-B09E-1E6879F48CF3'),
	('22A03976-633C-4AF8-A9CC-D0921741CE87','645C4000-7DDC-4CB9-B09E-1E6879F48CF3')


-- tasks
INSERT INTO [dbo].[Ziro_Task]
([Id],
[Number],[Type],[Status],[Title],[Description],[Priority]
,[EstimatedTime],[SpentTime],[CreationDate],[LastUpdateDate]
,[ProjectId],[AssigneeId],[OwnerId])
VALUES('99839976-6A3C-4AF8-A9CC-D0921741CE87',
			3, --number
			2, --type
			1, --status
           '[Twitter] Создание страницы статистики твитов',
		   ' Необходимо создать страницу для просмотра статистики оставленных твитов для определенных постов',
		   3, --priority
		   12, --estimated Time
		   6, --spentTime
		   '2019-05-01',
		   '2019-05-05',
		   '15A09976-6A3C-4AF8-A9CC-D0921741CE87', --project
		   '93A09976-6A3C-4AF8-A9CC-D0921741CE87', --assignee
		   'A32F9976-6A3C-4AF8-A9CC-D0921741CE87' -- owner
		   ),
('95539976-6A3C-4AF8-A9CC-D0921741CE87',
			4, --number
			0, --type
			1, --status
           'Миграция данных',
		   'Необходимо мигрировать данные из старых таблиц постов в новые',
		   2, --priority
		   24, --estimated Time
		   18, --spentTime
		   '2019-05-05',
		   '2019-05-09',
		   '15A09976-6A3C-4AF8-A9CC-D0921741CE87', --project
		   '93A09976-6A3C-4AF8-A9CC-D0921741CE87', --assignee
		   '93A09976-6A3C-4AF8-A9CC-D0921741CE87' -- owner
		   ),
('96669976-6A3C-4AF8-A9CC-D0921741CE87',
			1, --number
			1, --type
			4, --status
           'Неверная сортировка треков',
		   'Сортировка треков должна быть по возрастанию в плейлистах',
		   2, --priority
		   4, --estimated Time
		   4, --spentTime
		   '2019-05-04',
		   '2019-05-04',
		   '18A09976-6A3C-4AF8-A9CC-D0921741CE37', --project
		   '93A09976-6A3C-4AF8-A9CC-D0921741CE87', --assignee
		   'F4CC4000-7DDC-4CB9-B09E-1E6879F48CF3' -- owner
		   ),
('A6669976-6A3C-4AF8-A9CC-D0921741CE87',
			2, --number
			1, --type
			4, --status
           'Не проигрывается трек',
		   'Не проигрывается трек, в имени файла которого используется кириллица',
		   4, --priority
		   3, --estimated Time
		   4, --spentTime
		   '2019-05-05',
		   '2019-05-05',
		   '18A09976-6A3C-4AF8-A9CC-D0921741CE37', --project
		   '93A09976-6A3C-4AF8-A9CC-D0921741CE87', --assignee
		   'F4CC4000-7DDC-4CB9-B09E-1E6879F48CF3' -- owner
		   ),
('F0669976-6A3C-4AF8-A9CC-D0921741CE87',
			1, --number
			0, --type
			0, --status
           'Оптимизация эффекта <Шум>',
		   'Необходимо оптимизировать алгоритмы наложения эффекта Шум',
		   2, --priority
		   15, --estimated Time
		   0, --spentTime
		   '2019-05-05',
		   '2019-05-05',
		   '19A09976-633C-4AF8-A9CC-D0921741CE87', --project
		   '93A09976-6A3C-4AF8-A9CC-D0921741CE87', --assignee
		   '93A09976-6A3C-4AF8-A9CC-D0921741CE87' -- owner
		   ),
('70769976-6A3C-4AF8-A9CC-D0921741CE87',
			2, --number
			0, --type
			0, --status
           'Оптимизация эффекта <Эхо>',
		   'Необходимо оптимизировать алгоритмы наложения эффекта Эхо',
		   1, --priority
		   16, --estimated Time
		   0, --spentTime
		   '2019-05-06',
		   '2019-05-06',
		   '19A09976-633C-4AF8-A9CC-D0921741CE87', --project
		   '93A09976-6A3C-4AF8-A9CC-D0921741CE87', --assignee
		   '93A09976-6A3C-4AF8-A9CC-D0921741CE87' -- owner
		   ),
('99769976-6A3C-4AF8-A9CC-D0921741CE87',
			6, --number
			1, --type
			0, --status
           'Неверный цвет кнопки добавления комментария',
		   'Кнопка с добавлением комментария должна быть синего цвета',
		   0, --priority
		   2, --estimated Time
		   0, --spentTime
		   '2019-05-05',
		   '2019-05-05',
		   '19A09976-633C-4AF8-A9CC-D0921741CE87', --project
		   '93A09976-6A3C-4AF8-A9CC-D0921741CE87', --assignee
		   'F4CC4000-7DDC-4CB9-B09E-1E6879F48CF3' -- owner
		   ),
('98769976-6A3C-4AF8-A9CC-D0921741CE87',
			1, --number
			1, --type
			3, --status
           'Не подсвечивается имя пользователя',
		   'Имя пользователя не подсвечивается при наведении указателем мышки',
		   1, --priority
		   2, --estimated Time
		   2, --spentTime
		   '2019-05-05',
		   '2019-05-05',
		   '21A0F976-633C-4AF8-A9CC-D0921741CE87', --project
		   'F4CC4300-7DDC-4CB9-B09E-1E6879F48CF3', --assignee
		   'F4CC4300-7DDC-4CB9-B09E-1E6879F48CF3' -- owner
		   ),
('93769976-6A3C-4AF8-A9CC-D0921741CE87',
			1, --number
			0, --type
			2, --status
           'Оптимизация построения проекта',
		   'Необходимо увеличить скорость построения веб-проектов',
		   2, --priority
		   4, --estimated Time
		   4, --spentTime
		   '2019-05-05',
		   '2019-05-05',
		   '22A03976-633C-4AF8-A9CC-D0921741CE87', --project
		   '645C4000-7DDC-4CB9-B09E-1E6879F48CF3', --assignee
		   '22CC4090-7DDC-4CB9-B09E-1E6899F48CF3' -- owner
		   ),
('99763976-6A3C-4AF8-A9CC-D0921741CE87',
			2, --number
			2, --type
			4, --status
           'Добавить расширение <Решарпер>',
		   'Необходимо реаизовать интеграцию с решарпером',
		   3, --priority
		   16, --estimated Time
		   32, --spentTime
		   '2019-05-05',
		   '2019-05-15',
		   '22A03976-633C-4AF8-A9CC-D0921741CE87', --project
		   '645C4000-7DDC-4CB9-B09E-1E6879F48CF3', --assignee
		   '354C4000-7DDC-4CB9-B09E-1E6879F48CF3' -- owner
		   ),
('83769976-2A3C-4AF8-A9CC-D0921741CE87',
			1, --number
			1, --type
			1, --status
           'Совершения платежа заблокировано',
		   'Невозможно совершить платеж по коммунальным услугам',
		   4, --priority
		   7, --estimated Time
		   2, --spentTime
		   '2019-05-04',
		   '2019-05-15',
		   '23A03976-633C-4AF8-A9CC-D0921741CE87', --project
		   '33CC4000-7DDC-4CB9-B09E-1E6879F48CF3', --assignee
		   '354C4000-7DDC-4CB9-B09E-1E6879F48CF3' -- owner
		   ),
('83469976-2A3C-4AF8-A9CC-D0921741CE87',
			2, --number
			0, --type
			1, --status
           'Проработка требований по новому функционалу',
		   'Проработать требования по интеграции системы с Jira',
		   2, --priority
		   24, --estimated Time
		   12, --spentTime
		   '2019-05-08',
		   '2019-06-01',
		   '21A0F976-633C-4AF8-A9CC-D0921741CE87', --project
		   '64554000-7DDC-4CB9-B09E-1E6879F48CF3', --assignee
		   '64554000-7DDC-4CB9-B09E-1E6879F48CF3' -- owner
		   ),
('16469976-2A3C-4AF8-A9CC-D0921741CE87',
			3, --number
			1, --type
			0, --status
           'Неверное расположение логотипа',
		   'Необходимо расположить логотип приложения в верхнем правом углу приложения',
		   2, --priority
		   12, --estimated Time
		   8, --spentTime
		   '2019-05-08',
		   '2019-05-26',
		   '19A09976-633C-4AF8-A9CC-D0921741CE87', --project
		   'F4CC4000-7DDC-4CB9-B09E-1E6879F48CF3', --assignee
		   'F4CC4000-7DDC-4CB9-B09E-1E6879F48CF3' -- owner
		   ),
('37469976-2A3C-4AF8-A9CC-D0921741CE87',
			1, --number
			1, --type
			4, --status
           'Отображение случайного количества человек в группа',
		   'По неизвестным причинам в группах, созданных в Казахстане, отображается случайное количество человек',
		   2, --priority
		   8, --estimated Time
		   8, --spentTime
		   '2019-05-08',
		   '2019-05-26',
		   '17A09976-6A3C-4AF8-A9CC-D0921741CE87', --project
		   'F42C4000-7DDC-4CB9-B09E-1E6879F48CF3', --assignee
		   'F42C4000-7DDC-4CB9-B09E-1E6879F48CF3' -- owner
		   ),
('30A69976-2A3C-4AF8-A9CC-D0921741CE87',
			3, --number
			2, --type
			4, --status
           'Обновление эквалайзера',
		   'Необходимо обновить внешний вид эквалайзера, а также добавить туда дополнительную настройку',
		   2, --priority
		   12, --estimated Time
		   12, --spentTime
		   '2019-05-08',
		   '2019-05-24',
		   '18A09976-6A3C-4AF8-A9CC-D0921741CE37', --project
		   '93A09976-6A3C-4AF8-A9CC-D0921741CE87', --assignee
		   'A32F9976-6A3C-4AF8-A9CC-D0921741CE87' -- owner
		   )

