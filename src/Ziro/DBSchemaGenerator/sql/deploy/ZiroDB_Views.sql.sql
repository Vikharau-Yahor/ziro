CREATE VIEW Ziro_ProjectView
AS
SELECT up.UserId, up.ProjectId, p.Name as ProjectName, p.ShortName AS ProjectShortName, p.Description as ProjectDescription, subTotal.TotalTasksCount, subOpen.OpenTasksCount, subInProgress.TasksInProgressCount FROM Ziro_Project_User up 
INNER JOIN Ziro_Project p on p.Id = up.ProjectId
LEFT JOIN (SELECT Count(*) AS TotalTasksCount, t.ProjectId, t.AssigneeId FROM Ziro_Task t GROUP BY t.ProjectId, t.AssigneeId) subTotal ON subTotal.AssigneeId = up.UserId AND subTotal.ProjectId = up.ProjectId
LEFT JOIN (SELECT Count(*) AS OpenTasksCount, t.ProjectId, t.AssigneeId FROM Ziro_Task t WHERE t.[Status] = 0 GROUP BY t.ProjectId, t.AssigneeId) subOpen ON subOpen.AssigneeId = up.UserId AND subOpen.ProjectId = up.ProjectId
LEFT JOIN (SELECT Count(*) AS TasksInProgressCount, t.ProjectId, t.AssigneeId FROM Ziro_Task t WHERE t.[Status] = 1 GROUP BY t.ProjectId, t.AssigneeId) subInProgress ON subInProgress.AssigneeId = up.UserId AND subInProgress.ProjectId = up.ProjectId
GO

CREATE VIEW Ziro_ProjectInfoView
AS
SELECT p.Id as ProjectId, p.Name as ProjectName, p.ShortName AS ProjectShortName, p.Description as ProjectDescription, subNonClosed.NonClosedTasksCount, subUsers.TotalUsersCount
FROM Ziro_Project p 
LEFT JOIN (SELECT Count(*) AS NonClosedTasksCount, t.ProjectId FROM Ziro_Task t WHERE t.Status <> 4 GROUP BY(t.ProjectId)) subNonClosed ON subNonClosed.ProjectId = p.Id
LEFT JOIN (SELECT Count(*) AS TotalUsersCount, pu.ProjectId FROM Ziro_Project_User pu GROUP BY(pu.ProjectId)) subUsers ON subUsers.ProjectId = p.Id
GO