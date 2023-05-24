USE Company_SD;
GO
SELECT E.fname , P.Pname
FROM Employee E , Project P , Works_for W
WHERE E.SSN = W.ESSn AND P.Pnumber = W.Pno
ORDER BY Pname