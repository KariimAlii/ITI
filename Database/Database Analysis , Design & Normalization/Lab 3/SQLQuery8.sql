USE Company_SD;
GO
SELECT E.*
FROM Employee E  , Project P , Works_for W
WHERE E.Dno = 10 AND E.SSN = W.ESSn AND P.Pnumber = W.Pno AND W.Hours >= 10 AND P.Pname = 'AL Solimaniah';
