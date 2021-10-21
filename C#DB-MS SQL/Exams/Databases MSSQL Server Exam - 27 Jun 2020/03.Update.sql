--Assign all Pending jobs to the mechanic Ryan Harnos (look up his ID manually, 
--there is no need to use table joins) and change their status to 'In Progress'.

SELECT * FROM Mechanics
WHERE FirstName='Ryan'

--MechanicId=3

SELECT * FROM Jobs
WHERE [Status]='Pending'

UPDATE Jobs
SET MechanicId=3
WHERE [Status]='Pending'

UPDATE Jobs
SET [Status]='In Progress'
WHERE [Status]='Pending'