-- projects
INSERT INTO [dbo].[Ziro_Project]
VALUES('15A09976-6A3C-4AF8-A9CC-D0921741CE87',
           'Twitter','TWIT','Социальная сеть для публичного обмена сообщениями при помощи веб-интерфейса, SMS, средств мгновенного обмена сообщениями или сторонних программ-клиентов для пользователей интернета любого возраста')

INSERT INTO [dbo].[Ziro_Project]
VALUES('15F09976-6A3C-4AF8-A9CC-D0921741CE87',
           'Facebook','FB','Популярная социальная сеть в качестве продвижения товаров или услуг компаний. Facebook предоставляет пользователям возможность оставлять отзывы, так как подписчики могут комментировать публикации, выставлять оценки страницам брендов, чтобы их могли видеть другие. Facebook может ссылаться на страницу продукта в Twitter, а также отправлять напоминания о событиях')

-- tasks
INSERT INTO [dbo].[Ziro_Task]
VALUES('22F09976-6A3C-4AF8-A9CC-D0921741CE87',
			1, --number
			1, --type
           'Исправление порядка сортировки комментариев',
		   'Комментарии должны быть отсортированы по возрастанию в профиле пользователя',
		   2, --priority
		   2, --estimated Time
		   1, --spentTime
		   '2019-05-05',
		   '2019-05-05',
		   '15A09976-6A3C-4AF8-A9CC-D0921741CE87', --project
		   '93A09976-6A3C-4AF8-A9CC-D0921741CE87', --assignee
		   'A32F9976-6A3C-4AF8-A9CC-D0921741CE87' -- owner
		   )

INSERT INTO [dbo].[Ziro_Task]
VALUES('A5F39976-6A3C-4AF8-A9CC-D0921741CE87',
			2, --number
			0, --type
           '[Администрирование] Улучшение производительности загрузки страницы с пользователями',
		   '- Оптимизация запросов в базу, 
		   - Оптимизация код на веб-сервере
		   ',
		   1, --priority
		   8, --estimated Time
		   0, --spentTime
		   '2019-05-04',
		   '2019-05-04',
		   '15A09976-6A3C-4AF8-A9CC-D0921741CE87', --project
		   '93A09976-6A3C-4AF8-A9CC-D0921741CE87', --assignee
		   '93A09976-6A3C-4AF8-A9CC-D0921741CE87' -- owner
		   )

INSERT INTO [dbo].[Ziro_Task]
VALUES('F8839976-6A3C-4AF8-A9CC-D0921741CE87',
			1, --number
			2, --type
           '[Документация] Подготовить документы для заказчика',
		   '- Описать проблемы, 
		   - Описать предложения
		   - Описать разработанный функционал
		   - Подготовить видео-презентацию
		   ',
		   3, --priority
		   40, --estimated Time
		   65, --spentTime
		   '2019-05-01',
		   '2019-05-05',
		   '15F09976-6A3C-4AF8-A9CC-D0921741CE87', --project
		   'A32F9976-6A3C-4AF8-A9CC-D0921741CE87', --assignee
		   'A32F9976-6A3C-4AF8-A9CC-D0921741CE87' -- owner
		   )

-- project to users
INSERT INTO [dbo].[Ziro_Project_User]
VALUES('15A09976-6A3C-4AF8-A9CC-D0921741CE87',
           '93A09976-6A3C-4AF8-A9CC-D0921741CE87')
INSERT INTO [dbo].[Ziro_Project_User]
VALUES('15A09976-6A3C-4AF8-A9CC-D0921741CE87',
           'A32F9976-6A3C-4AF8-A9CC-D0921741CE87')
INSERT INTO [dbo].[Ziro_Project_User]
VALUES('15F09976-6A3C-4AF8-A9CC-D0921741CE87',
           'A32F9976-6A3C-4AF8-A9CC-D0921741CE87')