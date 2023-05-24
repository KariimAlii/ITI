-- Part 1
--Note: Use ITI DB
USE ITI;
GO
CREATE SCHEMA Lab3;
--1. Create a view that displays student full name, course name if the
--student has a grade more than 50.
CREATE VIEW V_Std_Course AS
	SELECT CONCAT(S.St_Fname,' ',S.St_Lname) as [Full Name] , C.Crs_Name as [Course Name]
	FROM Student as S , Course as C , Stud_Course as SC
	WHERE S.St_Id = SC.St_Id AND C.Crs_Id = SC.Crs_Id;

ALTER SCHEMA Lab3 TRANSFER V_Std_Course;
select * from Lab3.V_Std_Course;
EXEC sp_helptext 'Lab3.V_Std_Course';    -- allowed

--==============================================================================--
--https://www.geeksforgeeks.org/sql-views/
--https://databasefaqs.com/view-stored-procedure-in-sql-server/
--https://learn.microsoft.com/en-us/sql/relational-databases/system-stored-procedures/sp-help-transact-sql?source=recommendations&view=sql-server-ver16
--==============================================================================--

--2. Create an Encrypted view that displays manager names and the topics
--they teach.
CREATE VIEW V_Manager_Topics
WITH ENCRYPTION AS
	SELECT I.Ins_Name as [Manager Name],T.Top_Name as [Topic Name]
	FROM Instructor I , Course C , Ins_Course IC , Topic T
	WHERE I.Ins_Id = IC.Ins_Id AND C.Crs_Id = IC.Crs_Id AND C.Top_Id = T.Top_Id;

Alter Schema Lab3 Transfer V_Manager_Topics
select * from Lab3.V_Manager_Topics
EXEC sp_helptext 'Lab3.V_Manager_Topics';  -- The text for object 'Lab3.V_Manager_Topics' is encrypted.

--==============================================================================--
--https://database.guide/how-to-encrypt-a-view-in-sql-server/
--==============================================================================--


--3. Create a view that will display Instructor Name, Department Name for
--the ‘SD’ or ‘Java’ Department

CREATE VIEW Lab3.V_Instructor_SD_Java AS
	SELECT I.Ins_Name as [Instructor Name] , D.Dept_Name as [Department Name]
	FROM Instructor I , Department D
	WHERE I.Dept_Id = D.Dept_Id AND D.Dept_Name IN ('SD','Java');

select * from Department
select * from Lab3.V_Instructor_SD_Java
--==============================================================================--
--https://www.w3schools.com/sql/sql_ref_in.asp
--==============================================================================--


--4. Create a view “V1” that displays student data for student who lives in
--Alex or Cairo.
--Note: Prevent the users to run the following query
--Update V1 set st_address=’tanta’
--Where st_address=’alex’;

CREATE VIEW Lab3.V1 AS
	SELECT *
	FROM Student S
	WHERE S.St_Address in ( 'Alex' , 'Cairo')
	With Check Option;

-- Update Lab3.V1 set st_address='tanta' Where st_address='alex';
-- The attempted insert or update failed because the target view either specifies WITH CHECK OPTION or spans a view that specifies WITH CHECK OPTION and one or more rows resulting from the operation did not qualify under the CHECK OPTION constraint.

select * from Lab3.V1

--==============================================================================--
--https://simplesqltutorials.com/updateable-view/
--https://www.sqlshack.com/sql-view-a-complete-introduction-and-walk-through/
--==============================================================================--

--5. Create a view that will display the project name and the number of
--employees work on it. “Use SD database”

USE SD;
CREATE SCHEMA Lab3
GO
CREATE VIEW Lab3.Project_EmployeesNumber AS
	SELECT P.Project_No as [Project Number] , COUNT(E.EmpNo) as [Employees Number]
	FROM Company.Project P , [Human Resource].Employee E , dbo.Works_On W
	WHERE P.Project_No = W.ProjectNo AND W.EmpNo = E.EmpNo
	GROUP BY P.Project_No

select * from SD.Lab3.Project_EmployeesNumber
--==============================================================================--
--Index--
-----------
--https://hasura.io/learn/database/microsoft-sql-server/indexes/
--https://www.sqlshack.com/using-sql-create-index-to-create-clustered-and-non-clustered-indexes/
--==============================================================================--

--6. Create index on column (Hiredate) that allow u to cluster the data in
--table Department. What will happen?
select * from Company.Department
--==============================================================================--
--7. Create index that allow u to enter unique ages in student table. What will
--happen?
--==============================================================================--
create unique index index1
on Student(St_Age)

---------------------------------------------
--TRY
----------
INSERT INTO Student
VALUES (15,'Karim','Ali','Alex',26,20,12)
--Cannot insert duplicate key row in object 'dbo.Student' 
--with unique index 'index1'.
--The duplicate key value is (26).
----------------------------------------------
sp_helpconstraint 'Student'
--=============================================================================================================--
--https://learn.microsoft.com/en-us/sql/relational-databases/indexes/create-unique-indexes?view=sql-server-ver16
--=============================================================================================================--
--8. Using Merge statement between the following two tables [User ID,
--Transaction Amount]
MERGE INTO [Daily Transaction] as T
USING [Last Transaction] as S
ON T.UserID = S.UserID
When Matched Then
	Update
	Set T.Transaction_Amount = S.Transaction_Amount
When Not Matched Then
	INSERT (T.UserID,T.Transaction_Amount)
	Values(S.UserID,S.Transaction_Amount)
--==============================================================================--
--https://www.sqlshack.com/understanding-the-sql-merge-statement/
--https://www.geeksforgeeks.org/merge-statement-sql-explained/
--==============================================================================--
--9. Write a query to select the highest two salaries in Each Department for
--instructors who have salaries. “using one of Ranking Functions”

SELECT * from (SELECT Dept_id, Salary , Dense_Rank() over (partition by Dept_id order by Salary desc) as DR
FROM Instructor) as newTable
WHERE DR <= 2


select * from Instructor
--==============================================================================--
--https://www.javatpoint.com/rank-function-in-sql-server
--https://www.sqlshack.com/overview-of-sql-rank-functions/
--https://towardsdatascience.com/sql-ranking-window-function-guide-b9aee35d5931
--==============================================================================--
--10. Write a query to select a random student from each department. “using one
--of Ranking Functions”
SELECT * from (SELECT Dept_id, Salary , Dense_Rank() over (partition by Dept_id order by Salary desc) as DR
FROM Instructor) as newTable
WHERE DR = FLOOR(Rand() * (5-1) + 1)

--i.e  DR = a Random Number from 1 ~ 5
--==============================================================================--

--==============================================================================--

--Part2: use SD_DB


--1) Create view named “v_clerk” that will display employee#,project#, the date of hiring of
--all the jobs of the type 'Clerk'.

CREATE VIEW Lab3.V_Clerk AS
	SELECT W.EmpNo as [#Employee] , W.ProjectNo as [#Project] , W.Enter_Date as [Hiring Date]
	FROM Works_On W
	WHERE W.Job = 'Clerk';

select * from Lab3.V_Clerk
--------------------------------------------------------------------------------------------------
--2) Create view named “v_without_budget” that will display all the projects data
--without budget

CREATE VIEW Lab3.V_Without_Budget AS
	SELECT *
	FROM Company.Project
	WHERE Budget is NULL;

select * from Lab3.V_Without_Budget
select * from Company.Project
--------------------------------------------------------------------------------------------------
--3) Create view named “v_count “ that will display the project name and the # of jobs in it

CREATE VIEW Lab3.V_Count AS
	SELECT  ProjectNo , COUNT(Job) as [Number of Jobs]
	FROM Works_On
	GROUP BY ProjectNo
select * from Works_On
select * from Lab3.V_Count
--------------------------------------------------------------------------------------------------
--4) Create view named ” v_project_p2” that will display the emp# for the project# ‘p2’
--use the previously created view “v_clerk”

CREATE VIEW Lab3.V_Project_P2 AS
	SELECT ProjectNo , COUNT(EmpNo) as [Employees#]
	FROM Works_On
	WHERE Job is not null AND ProjectNo = 'p2'
	GROUP BY ProjectNo

select * from Lab3.V_Project_P2
--------------------------------------------------------------------------------------------------
--5) modifey the view named “v_without_budget” to display all DATA in project p1 and p2
ALTER VIEW Lab3.V_Without_Budget AS
	SELECT *
	FROM Company.Project
	WHERE Project_No in ('p1','p2');

select * from Lab3.V_Without_Budget;

--------------------------------------------------------------------------------------------------
--6) Delete the views “v_ clerk” and “v_count”

Drop VIEW Lab3.V_Clerk 
Drop VIEW Lab3.V_Count
-----------------------------------------------------------------------------------
--7) Create view that will display the emp# and emp lastname who works on dept# is ‘d2’

CREATE VIEW Lab3.V_Emp_Dept AS
	SELECT E.EmpNo , E.Lname
	FROM [Human Resource].Employee E , Company.Department D
	WHERE E.DeptNo = D.Dept_No AND D.Dept_No = 'd2'

select * from Lab3.V_Emp_Dept
---------------------------------------------------------------------
--8) Display the employee lastname that contains letter “J”
--Use the previous view created in Q#7

SELECT Lname
FROM Lab3.V_Emp_Dept
WHERE Lname like '%J%'

----------------------------------------------------------------------------------------
--9) Create view named “v_dept” that will display the department# and department name.

CREATE VIEW Lab3.V_Dept AS
	SELECT Dept_No , DeptName
	FROM Company.Department
	
select * from Lab3.V_Dept
--------------------------------------------------------------------------------------
--10) using the previous view try enter new department data where dept# is ’d4’ and dept name
--is ‘Development’

INSERT INTO Lab3.V_Clerk 
values 'D4','Development';
-- ERROR : You have to insert Department Location

select * from Lab3.V_Dept
select * from Company.Department
----------------------------------------------------------------------------------
--11) Create view name “v_2006_check” that will display employee#, the project #where he
--works and the date of joining the project which must be from the first of January and the
--last of December 2006.

CREATE VIEW Lab3.V_2006_Check AS
	SELECT E.EmpNo , P.Project_No , P.Project_Name , W.Enter_Date
	FROM [Human Resource].Employee E,Works_On W , Company.Project P
	WHERE (P.Project_No = W.ProjectNo) AND 
		  (W.EmpNo = E.EmpNo) AND 
		  (W.Enter_Date BETWEEN '1/1/2006' AND '12/30/2006');


select * from Lab3.V_2006_Check
