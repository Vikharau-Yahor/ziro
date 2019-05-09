-- task исправление сортировки
-- comments
INSERT INTO [dbo].[Ziro_Comment]
           ([Id],[Text],[Date],[AuthorId],[TaskId])
     VALUES
           ('3575EB07-EC2F-4FEF-AEB3-70E9E5868F41','Необходимо обсудить детали','2019-04-11 11:00','93A09976-6A3C-4AF8-A9CC-D0921741CE87','22F09976-6A3C-4AF8-A9CC-D0921741CE87')

INSERT INTO [dbo].[Ziro_Comment]
           ([Id],[Text],[Date],[AuthorId],[TaskId])
     VALUES
           ('1275EB07-EC2F-4FEF-AEB3-70E9E5868F41','Можем созвониться завтра после 12 часов','2019-04-11 11:15','A32F9976-6A3C-4AF8-A9CC-D0921741CE87','22F09976-6A3C-4AF8-A9CC-D0921741CE87')

INSERT INTO [dbo].[Ziro_Comment]
           ([Id],[Text],[Date],[AuthorId],[TaskId])
     VALUES
           ('2574EB07-EC2F-4FEF-AEB3-70E9E5868F41','Было бы удобно в 13:00 ','2019-04-11 11:25','93A09976-6A3C-4AF8-A9CC-D0921741CE87','22F09976-6A3C-4AF8-A9CC-D0921741CE87')

INSERT INTO [dbo].[Ziro_Comment]
           ([Id],[Text],[Date],[AuthorId],[TaskId])
     VALUES
           ('3675EB07-EC2F-4FEF-AEB3-70E9E5868F41','Договорились','2019-04-11 11:35','A32F9976-6A3C-4AF8-A9CC-D0921741CE87','22F09976-6A3C-4AF8-A9CC-D0921741CE87')

INSERT INTO [dbo].[Ziro_Comment]
           ([Id],[Text],[Date],[AuthorId],[TaskId])
     VALUES
           ('3577EB07-EC2F-4FEF-AEB3-7034E5868F41','Работы над задачей завершены','2019-04-13 14:05','93A09976-6A3C-4AF8-A9CC-D0921741CE87','22F09976-6A3C-4AF8-A9CC-D0921741CE87')

INSERT INTO [dbo].[Ziro_Comment]
           ([Id],[Text],[Date],[AuthorId],[TaskId])
     VALUES
           ('5575EB07-EC2F-4FEF-AEB3-70E9E5868F41','Задача проверена, дефектов не найдено','2019-04-14 16:05','F4CC4000-7DDC-4CB9-B09E-1E6879F48CF3','22F09976-6A3C-4AF8-A9CC-D0921741CE87')

-- log works		   
INSERT INTO [dbo].[Ziro_LogWork]([Id],[Text],[SpentTimeHours],[Date],[AuthorId],[TaskId])
VALUES('3575EB07-EC2F-4FEF-AEB3-70E9E5868F41','Обсуждение задачи','1.5','2019-04-12 11:05','93A09976-6A3C-4AF8-A9CC-D0921741CE87','22F09976-6A3C-4AF8-A9CC-D0921741CE87')

INSERT INTO [dbo].[Ziro_LogWork]([Id],[Text],[SpentTimeHours],[Date],[AuthorId],[TaskId])
VALUES('1575EB07-EC2F-4FEF-AEB3-70E9E5868F41','Исследование проблемы','3','2019-04-12 12:35','93A09976-6A3C-4AF8-A9CC-D0921741CE87','22F09976-6A3C-4AF8-A9CC-D0921741CE87')

INSERT INTO [dbo].[Ziro_LogWork]([Id],[Text],[SpentTimeHours],[Date],[AuthorId],[TaskId])
VALUES('3775EB07-EC2F-4FEF-AEB3-70E9E5868F41','Написание кода','6','2019-04-13 08:05','93A09976-6A3C-4AF8-A9CC-D0921741CE87','22F09976-6A3C-4AF8-A9CC-D0921741CE87')

INSERT INTO [dbo].[Ziro_LogWork]([Id],[Text],[SpentTimeHours],[Date],[AuthorId],[TaskId])
VALUES('A575EB07-EC2F-4FEF-AEB3-70E9E5868F41','Тестирование','4','2019-04-13 14:05','F4CC4000-7DDC-4CB9-B09E-1E6879F48CF3','22F09976-6A3C-4AF8-A9CC-D0921741CE87')