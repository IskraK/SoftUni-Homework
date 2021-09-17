TRUNCATE TABLE Employees

UPDATE Towns
SET Name='Burgas'
WHERE Id=4

INSERT INTO Departments VALUES
('Quality Assurance')


INSERT INTO Employees VALUES
	('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-03', 3500.00, 1),
	('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00, 4),
	('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25, 2),
	('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00, 3),
	('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88, 1)
