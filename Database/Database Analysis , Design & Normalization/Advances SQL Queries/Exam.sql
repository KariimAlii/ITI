USE Exam;
GO

-- Add Dnum as foreign key from department to project
ALTER TABLE Project ADD FOREIGN Key (Dnum) References Departments(Dnum)

---------------------- Lab2 ----------------------------


--Try to create the following Queries:

--1.	Display all the employees Data.
SELECT * FROM Employee
--2.	Display the employee First name, last name, Salary and Department number.
SELECT Fname , Lname , Salary , Dno
FROM Employee;
--3.	Display all the projects names, locations and the department which is responsible about it.
SELECT P.Pname , P.Plocation , D.Dname
FROM Project P , Departments D
WHERE P.Dnum = D.Dnum;
--4.	If you know that the company policy is to pay
--an annual commission for each employee with specific percent equals 10% of his/her annual salary.
-- Display each employee full name 
--and his annual commission in an ANNUAL COMM column (alias).
SELECT (Fname + Lname) as [Employee Name] , 0.1 *Salary * 12 as [Annual Commision] 
FROM Employee;
--5.	Display the employees Id, name who earns more than 1000 LE monthly.
SELECT SSN , Fname , Salary
FROM Employee
WHERE Salary > 1000;
--6.	Display the employees Id, name who earns more than 10000 LE annually.
SELECT SSN , Fname , Salary*12 as [Annual Salary]
FROM Employee
WHERE Salary * 12 > 10000;
--7.	Display the names and salaries of the female employees 
SELECT Fname , Salary , Sex
FROM Employee
WHERE Sex = 'F';
--8.	Display each department id, name which managed by a manager with id equals 968574.
Select D.Dnum,D.Dname , (E.Fname+E.Lname) as [Manager Name] , E.SSN as [Manager ID]
FROM Employee E INNER JOIN Departments D
ON E.SSN = D.MGRSSN AND E.SSN = 968574 ;
--FROM Employee E , Departments D
--WHERE E.SSN = D.MGRSSN AND E.SSN = 968574 ;
--9.	Display the IDs, names and locations of the pojects which controlled with department 10.
SELECT P.Pnumber , P.Pname , P.Plocation , D.Dnum
FROM Project P , Departments D
WHERE P.Dnum = D.Dnum AND D.Dnum = 10;
--Data Manipulating Language:

--1.	Insert your personal data to the employee table as a new employee 
-- in department number 30, SSN = 102672, Superssn = 112233.
select * from employee
select * from Departments
INSERT INTO Employee values ('Karim','Ali',102672,'1996-10-20','23 Cairo St. Alex','M',3700,112233,30);
--2.	Insert another employee with, personal data your friend as new employee
-- in department number 30, SSN = 102660, 
-- but don’t enter any value for salary or supervisor number to him.
INSERT INTO Employee values ('Jovany','Sami',102660,'1997/09/09','24 St.SidiBeshr Alex','M',NULL,NULL,30);
--3.	In the department table insert new department called "DEPT IT",
-- with id 100, employee with SSN = 112233 as a manager for this department.
-- The start date for this manager is '1-11-2006'
SELECT * from Departments
INSERT INTO Departments values ('DEPT IT',100,112233,'2006-01-11');
--4.	Do what is required if you know that:
--Mrs.Noha Mohamed(SSN=968574) moved to be the manager of the new department (id = 100),
--and they give you (use your SSN from question1) her position (Dept. 20 manager) 

--a.	First try to update her record in the department table
UPDATE Departments
SET MGRSSN = 968574
WHERE Dnum = 100;

--b.	Update your record to be department 20 manager.
UPDATE Departments
SET MGRSSN = 102672
WHERE Dnum = 20;

--c.	Update your friend data (entered in question2) to be in your teamwork (supervised by you)
UPDATE Employee
SET Superssn = 102672
WHERE Fname='Jovany';
--5.	Unfortunately, the company ended the contract with Mr. Kamel Mohamed (SSN=223344) 
-- so try to delete his data from your database 
-- in case you know that your friend will be temporarily in his position.// SSN(Kamel) = 223344 -----> SSN(Jovany) = 102660
--Hint: (Check if Mr. Kamel has dependents,
--works as a department manager,
--supervises any employees 
--or works in any projects 
--and handle these cases).

UPDATE Departments SET MGRSSN = 102660 WHERE MGRSSN = 223344 ;
UPDATE Employee SET Superssn = 102660 WHERE Superssn = 223344 ;

DELETE FROM Dependent WHERE ESSN = 223344;
DELETE FROM Works_for WHERE ESSn = 223344;
DELETE FROM Employee WHERE SSN = 223344;
--6.	And your salary has been upgraded by 20 percent of its last value.
SELECT * from Employee
UPDATE Employee
SET Salary = 1.2 * Salary
WHERE Fname = 'Karim';

-------------------------LAB 3------------------------------------

--1.	Display the Department id, name and id and the name of its manager.
--2.	Display the name of the departments and the name of the projects under its control.
--3.	Display the full data about all the dependence associated with the name of the employee they depend on him/her.
--4.	Display (Using Union Function)
--a.	 The name and the gender of the dependence that's gender is Female and depending on Female Employee.
--b.	 And the male dependence that depends on Male Employee.
--5.	Display the Id, name and location of the projects in Cairo or Alex city.
--6.	Display the Projects full data of the projects with a name starts with "a" letter.
--7.	display all the employees in department 30 whose salary from 1000 to 2000 LE monthly
--8.	Retrieve the names of all employees in department 10 who works more than or equal10 hours per week on "AL Rabwah" project.
--9.	Find the names of the employees who directly supervised with Kamel Mohamed.


--10.	For each project, list the project name and the total hours per week (for all employees) spent on that project.
SELECT SUM(Hours) as [Total Hours] , Pnumber
FROM Employee E , Works_for W , Project P
WHERE E.SSN = W.ESSn AND W.Pno = P.Pnumber
GROUP BY Pnumber
--11.	Retrieve the names of all employees and the names of the projects they are working on, sorted by the project name.
SELECT Fname , Pname
FROM Employee E , Works_for W , Project P
WHERE E.SSN = W.ESSn AND W.Pno = P.Pnumber
ORDER BY Pname;
--12.	Display the data of the department which has the smallest employee ID over all employees' ID.
-- SUBQUERY : SELECT MIN(SSN) FROM Employee
SELECT D.*
FROM Employee E , Departments D
WHERE E.Dno = D.Dnum AND E.SSN IN (SELECT MIN(SSN) FROM Employee)
-- WRONG ANSWER : WHERE E.Dno = D.Dnum AND E.SSN < ALL (SELECT SSN FROM Employee)


--13.	For each department, 
--retrieve the department name 
--and the maximum, minimum and average salary of its employees.
SELECT D.Dnum ,D.Dname , MAX(SALARY) as Max_Salary , MIN(SALARY) as Min_SALARY , AVG(Salary) as Average_Salary
FROM Employee E , Departments D
WHERE E.Dno = D.Dnum
GROUP BY D.Dname , D.Dnum
--14.	List the last name of all managers who have no dependents.
SELECT E.Lname
FROM Employee E , Departments D
WHERE E.SSN = D.MGRSSN
--15.	For each department
-- if its average salary is less than the average salary of all employees
-- display its number, name and number of its employees.
SELECT D.Dnum , D.Dname , COUNT(E.SSN) as NumEmployees
FROM Employee E , Departments D
WHERE E.Dno = D.Dnum
GROUP BY D.Dnum , D.Dname
HAVING AVG(E.Salary) < (SELECT AVG(Salary) FROM Employee)
--16. Retrieve a list of employees
--and the projects they are working on
--ordered by department 
--and within each department, 
--ordered alphabetically by last name, first name.
SELECT E.Fname , E.Dno , P.Pname
FROM Employee E ,  Project P , Works_for W
WHERE E.SSN = W.ESSn AND W.Pno = P.Pnumber
-- GROUP BY E.Dno , E.Lname , E.Fname , P.Pname [NOT USEFUL - Malhash lazma]
ORDER BY E.Dno , E.Lname , E.Fname
--17.	For each project located in Cairo City , 
--find the project number, 
--the controlling department name ,
--the department manager last name ,address and birthdate.
SELECT P.Pnumber , D.Dname , E.Lname , E.Address , E.Bdate
FROM Employee E , Departments D , Project P
WHERE P.Dnum = D.Dnum AND E.SSN = D.MGRSSN AND P.City = 'Cairo'