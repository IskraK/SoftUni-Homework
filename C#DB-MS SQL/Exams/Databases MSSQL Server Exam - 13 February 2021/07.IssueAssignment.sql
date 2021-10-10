--Select all of the issues, and the users that are assigned to them, 
--so that they end up in the following format: {username} : {issueTitle}. 
--Order them by issue id (descending) and issue assignee (ascending).

SELECT i.Id,
	   CONCAT(u.Username,' : ',i.Title) AS IssueAssignee
FROM Issues AS i
LEFT JOIN Users AS u ON i.AssigneeId=u.Id
ORDER BY i.Id DESC,i.AssigneeId