USE Company_SD;
GO
SELECT D.Dname , P.Pname
FROM Departments D , Project P
WHERE D.Dnum = P.Dnum