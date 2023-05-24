USE Company_SD;
GO
SELECT P.Pname , Sum (W.Hours) as [Total Working Hours]
FROM Project P , Works_for W , Employee E
WHERE P.Pnumber = W.Pno AND E.SSN = W.ESSn
GROUP BY Pname

