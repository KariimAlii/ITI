USE Company_SD;
GO
SELECT E.*
FROM Employee E , Departments D
WHERE E.Dno = D.Dnum AND (E.Salary BETWEEN 1000 AND 2000)
