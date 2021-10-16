--Select the user's username and category name in all reports 
--in which users have submitted a report on their birthday. 
--Order them by username (ascending) and then by category name (ascending).

SELECT u.Username,
	   c.[Name] AS CategoryName
FROM Reports AS r
LEFT JOIN Categories AS c ON r.CategoryId=c.Id
LEFT JOIN Users AS u ON r.UserId=u.Id
WHERE DAY(u.Birthdate)=DAY(r.OpenDate)
ORDER BY u.Username,c.Name
