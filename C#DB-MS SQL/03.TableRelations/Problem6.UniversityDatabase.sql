CREATE DATABASE [University]

USE [University]

CREATE TABLE [Majors](
	MajorID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL
	)

CREATE TABLE [Students](
	StudentID INT PRIMARY KEY IDENTITY,
	StudentNumber INT UNIQUE NOT NULL,
	StudentName NVARCHAR(100) NOT NULL,
	MajorID INT FOREIGN KEY REFERENCES [Majors](MajorID) NOT NULL
	)

CREATE TABLE [Payments](
	PaymentID INT PRIMARY KEY NOT NULL,
	PaymentDate DATE NOT NULL,
	PaymentAmount DECIMAL(10,2) NOT NULL,
	StudentID INT FOREIGN KEY REFERENCES [Students](StudentID) NOT NULL
	)

CREATE TABLE [Subjects](
	SubjectID INT PRIMARY KEY IDENTITY,
	SubjectName NVARCHAR(100) NOT NULL
	)

CREATE TABLE [Agenda](
	StudentID INT FOREIGN KEY REFERENCES [Students](StudentID) NOT NULL,
	SubjectID INT FOREIGN KEY REFERENCES [Subjects](SubjectID) NOT NULL,
	PRIMARY KEY (StudentID, SubjectID)
	)