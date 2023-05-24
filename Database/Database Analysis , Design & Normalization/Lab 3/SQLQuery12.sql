USE Company_SD;
GO
--12
SELECT D.* 
FROM Departments D , Employee E
WHERE D.Dnum = E.Dno
AND E.SSN = (SELECT MIN(SSN) FROM Employee)
--13
SELECT D.Dname , Max(E.Salary) as Max , Min(E.Salary) as Min , AVG(E.Salary) as Avg
FROM Employee E , Departments D
WHERE E.Dno = D.Dnum
GROUP BY D.Dname;

--14
SELECT E.Lname as [Manager Last Name] 
FROM Employee E , Departments D 
WHERE D.MGRSSN = E.SSN AND D.MGRSSN NOT IN (select ESSN from Dependent)

--SELECT E.Lname as [Manager Last Name] 
--FROM Employee E , Departments D , Dependent DE
--WHERE D.MGRSSN = E.SSN AND NOT (E.SSN = DE.ESSN)

--15
SELECT D.Dnum , D.Dname , COUNT(E.SSN) as [Number OF EMPLOYEES]
FROM Departments D , Employee E
WHERE E.Dno = D.Dnum 
GROUP BY D.Dname , D.Dnum
HAVING AVG(Salary)  < (SELECT AVG(Salary) FROM Employee)
--16
--Retrieve a list of employees 
--and the projects they are working on 
--ordered by department 
--and within each department, 
--ordered alphabetically by last name, first name.
SELECT E.Fname , P.Pname , E.Lname, D.Dname
FROM Employee E , Project P , Departments D , Works_for W
WHERE E.SSN = W.ESSn AND W.Pno = P.Pnumber AND E.Dno = D.Dnum
ORDER BY D.Dname , E.Lname , E.Fname

--17
--For each project located in Cairo City , 
--find the project number, 
--the controlling department name ,
--the department manager last name ,
--address and birthdate.
SELECT P.Pnumber ,  D.Dname , E.Lname as [Manager Last Name] , E.Address , E.Bdate , P.City
FROM Project P , Departments D , Employee E
WHERE P.City = 'Cairo' AND P.Dnum = D.Dnum AND D.MGRSSN = E.SSN