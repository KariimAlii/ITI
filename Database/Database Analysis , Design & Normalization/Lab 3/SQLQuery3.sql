USE Company_SD;
GO
SELECT D.* , (E.fname + ' ' + E.Lname) as [Employee Name]
FROM Dependent D , Employee E
WHERE D.ESSN = E.SSN