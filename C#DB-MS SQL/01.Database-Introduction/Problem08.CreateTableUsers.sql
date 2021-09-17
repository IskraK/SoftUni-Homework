
CREATE TABLE [Users](
Id BIGINT PRIMARY KEY IDENTITY,
Username VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX)
CHECK(DATALENGTH(ProfilePicture) <= 900000),
LastLoginTime DATETIME2,
IsDeleted BIT NOT NULL
)

INSERT INTO Users (Username,[Password],ProfilePicture,LastLoginTime,IsDeleted) VALUES
	('Pesho1', 'Pass1', 1, '2021-09-15', 0),
	('Gosho', 'Pass2', 5, '2021-09-14',0),
	('Ivan', 'Pass3', 24, '2021-08-09', 0),
	('Mimi', 'Pass4', 44, '2020-10-01', 0),
	('Ani', 'Pass5', 5, '2020-12-12', 0)