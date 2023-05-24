USE Company_SD;
GO
SELECT D.Dependent_name , D.Sex as [Dependent Gender] , E.Sex as [Employee Gender]
FROM Dependent D INNER JOIN Employee E
ON D.ESSN = E.SSN AND D.Sex = 'F' AND E.Sex = 'F'

UNION

SELECT D.Dependent_name , D.Sex as [Dependent Gender] , E.Sex as [Employee Gender]
FROM Dependent D INNER JOIN Employee E
ON D.ESSN = E.SSN AND  D.Sex = 'M' AND E.Sex = 'M'