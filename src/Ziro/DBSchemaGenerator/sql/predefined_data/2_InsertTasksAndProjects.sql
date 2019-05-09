-- projects
INSERT INTO [dbo].[Ziro_Project]           
			([Id]
           ,[Name]
           ,[ShortName]
           ,[Description])
VALUES('15A09976-6A3C-4AF8-A9CC-D0921741CE87',
           'Twitter','TWIT','���������� ���� ��� ���������� ������ ����������� ��� ������ ���-����������, SMS, ������� ����������� ������ ����������� ��� ��������� ��������-�������� ��� ������������� ��������� ������ ��������')

INSERT INTO [dbo].[Ziro_Project]
			([Id]
           ,[Name]
           ,[ShortName]
           ,[Description])
VALUES('15F09976-6A3C-4AF8-A9CC-D0921741CE87',
           'Facebook','FB','���������� ���������� ���� � �������� ����������� ������� ��� ����� ��������. Facebook ������������� ������������� ����������� ��������� ������, ��� ��� ���������� ����� �������������� ����������, ���������� ������ ��������� �������, ����� �� ����� ������ ������. Facebook ����� ��������� �� �������� �������� � Twitter, � ����� ���������� ����������� � ��������')

-- tasks
INSERT INTO [dbo].[Ziro_Task]([Id]
           ,[Number]
           ,[Type]
           ,[Status]
           ,[Title]
           ,[Description]
           ,[Priority]
           ,[EstimatedTime]
           ,[SpentTime]
           ,[CreationDate]
           ,[LastUpdateDate]
           ,[ProjectId]
           ,[AssigneeId]
           ,[OwnerId])
VALUES('22F09976-6A3C-4AF8-A9CC-D0921741CE87',
			1, --number
			1, --type
			0, --status
           '����������� ������� ���������� ������������',
		   '����������� ������ ���� ������������� �� ����������� � ������� ������������',
		   2, --priority
		   2, --estimated Time
		   1, --spentTime
		   '2019-05-05',
		   '2019-05-05',
		   '15A09976-6A3C-4AF8-A9CC-D0921741CE87', --project
		   '93A09976-6A3C-4AF8-A9CC-D0921741CE87', --assignee
		   'A32F9976-6A3C-4AF8-A9CC-D0921741CE87' -- owner
		   )

INSERT INTO [dbo].[Ziro_Task] ([Id]
           ,[Number]
           ,[Type]
           ,[Status]
           ,[Title]
           ,[Description]
           ,[Priority]
           ,[EstimatedTime]
           ,[SpentTime]
           ,[CreationDate]
           ,[LastUpdateDate]
           ,[ProjectId]
           ,[AssigneeId]
           ,[OwnerId])
VALUES('A5F39976-6A3C-4AF8-A9CC-D0921741CE87',
			2, --number
			0, --type
			1, --status
           '[�����������������] ��������� ������������������ �������� �������� � ��������������',
		   '- ����������� �������� � ����, 
		   - ����������� ��� �� ���-�������
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

INSERT INTO [dbo].[Ziro_Task]([Id]
           ,[Number]
           ,[Type]
           ,[Status]
           ,[Title]
           ,[Description]
           ,[Priority]
           ,[EstimatedTime]
           ,[SpentTime]
           ,[CreationDate]
           ,[LastUpdateDate]
           ,[ProjectId]
           ,[AssigneeId]
           ,[OwnerId])
VALUES('F8839976-6A3C-4AF8-A9CC-D0921741CE87',
			1, --number
			2, --type
			0, --status
           '[������������] ����������� ��������� ��� ���������',
		   '- ������� ��������, 
		   - ������� �����������
		   - ������� ������������� ����������
		   - ����������� �����-�����������
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
INSERT INTO [dbo].[Ziro_Project_User]([ProjectId]
           ,[UserId])
VALUES('15A09976-6A3C-4AF8-A9CC-D0921741CE87',
           '93A09976-6A3C-4AF8-A9CC-D0921741CE87')
INSERT INTO [dbo].[Ziro_Project_User]([ProjectId]
           ,[UserId])
VALUES('15A09976-6A3C-4AF8-A9CC-D0921741CE87',
           'F4CC4000-7DDC-4CB9-B09E-1E6879F48CF3')
INSERT INTO [dbo].[Ziro_Project_User]([ProjectId]
           ,[UserId])
VALUES('15A09976-6A3C-4AF8-A9CC-D0921741CE87',
           'A32F9976-6A3C-4AF8-A9CC-D0921741CE87')
INSERT INTO [dbo].[Ziro_Project_User]([ProjectId]
           ,[UserId])
VALUES('15F09976-6A3C-4AF8-A9CC-D0921741CE87',
           'A32F9976-6A3C-4AF8-A9CC-D0921741CE87')