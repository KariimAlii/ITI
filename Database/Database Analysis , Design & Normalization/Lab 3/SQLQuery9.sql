USE Company_SD;
GO
SELECT (E.Fname + E.Lname) as [Employee Name]
FROM Employee E , Employee S
WHERE E.Superssn = S.SSN AND S.Fname = 'Jovany'
