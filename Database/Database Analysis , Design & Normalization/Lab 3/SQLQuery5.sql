USE Company_SD;
GO
SELECT P.Pnumber , P.Pname , P.City
FROM Project P
WHERE P.City IN('Alex','Cairo');