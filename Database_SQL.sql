CREATE DATABASE ADOTASK;

USE ADOTASK;

CREATE  TABLE Departments(
	DepId INT primary KEY,
	DepName varchar(20) Not NUll
);

INSERT INTO Departments
Values
(1,'DP1'),
(2,'DP2'),
(3,'DP3'),
(4,'DP4'),
(5,'DP5'),
(6,'DP6');

SELECT * FROM Departments