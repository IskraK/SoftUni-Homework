CREATE TABLE Planets(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL)

CREATE TABLE Spaceports(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	PlanetId INT FOREIGN KEY REFERENCES Planets(Id) NOT NULL)

CREATE TABLE Spaceships(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	Manufacturer NVARCHAR(30) NOT NULL,
	LightSpeedRate INT DEFAULT(0))

CREATE TABLE Colonists(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Ucn NVARCHAR(10) UNIQUE NOT NULL,
	BirthDate DATE NOT NULL)

CREATE TABLE Journeys(
	Id INT PRIMARY KEY IDENTITY,
	JourneyStart DATETIME NOT NULL,
	JourneyEnd DATETIME NOT NULL,
	Purpose NVARCHAR(11) CHECK(Purpose IN('Medical', 'Technical', 'Educational', 'Military')),
	DestinationSpaceportId INT FOREIGN KEY REFERENCES Spaceports(Id) NOT NULL,
	SpaceshipId INT FOREIGN KEY REFERENCES Spaceships(Id) NOT NULL)


CREATE TABLE TravelCards(
	Id INT PRIMARY KEY IDENTITY,
	CardNumber NCHAR(10) UNIQUE NOT NULL,
	JobDuringJourney NVARCHAR(8) CHECK(JobDuringJourney IN('Pilot', 'Engineer', 'Trooper', 'Cleaner','Cook')),
	ColonistId INT FOREIGN KEY REFERENCES Colonists(Id) NOT NULL,
	JourneyId INT FOREIGN KEY REFERENCES Journeys(Id) NOT NULL)


	CREATE DATABASE ColonialJourney 

	DROP DATABASE ColonialJourney 