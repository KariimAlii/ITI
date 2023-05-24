USE Company_SD;
GO
SELECT D.Dnum , D.Dname , E.SSN as [Manager ID] , (E.Fname + E.Lname) as [Manager Name]
FROM Employee E , Departments D
WHERE E.Dno = D.Dnum