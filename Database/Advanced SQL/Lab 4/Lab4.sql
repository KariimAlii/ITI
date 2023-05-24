--Lab4
------------
CREATE SCHEMA Lab4
--1. Create a stored procedure without parameters to show the number of
--students per department name.[use ITI DB]
CREATE PROC Lab4.GetNumStudPerDept
as
	SELECT D.Dept_Name , COUNT(S.St_Id) as [Students Number]
	FROM Student S , Department D
	WHERE S.Dept_Id = D.Dept_Id
	GROUP BY D.Dept_Name

exec sp_helptext 'Lab4.GetNumStudPerDept'
exec Lab4.GetNumStudPerDept
--------------------------------------------------------------------------------------
--2. Create a stored procedure 
	--that will check for the # of employees in the project p1
	--** if they are more than 3 print 
		 --message to the user “'The number of employees in the project p1 is 3 or more'”
	--** if they are less 
		--display a message to the user “'The following employees work for the project p1'” in
		--addition to the first name and last name of each one. [Company DB]
CREATE FUNCTION Lab4.F_GetP1Employees()
returns table as return
(
	Select E.Fname,E.Lname
	FROM [Human Resource].Employee E , Company.Project P , Works_On W 
	WHERE W.ProjectNo = P.Project_No AND W.EmpNo = E.EmpNo AND P.Project_No = 'p1'
)
select * from Lab4.F_GetP1Employees()



CREATE PROC Lab4.SP_CheckP1Employees
as	
	BEGIN
		Declare @EmpNum int
		Select @EmpNum = COUNT(*) from Lab4.F_GetP1Employees()
		IF @EmpNum > 3
			SELECT 'The number of employees in the project p1 is 3 or more'
		ELSE
			Select 'The following employees work for the project p1'
			Declare @index int = 0
			WHILE @index < @EmpNum
					BEGIN
						SELECT * FROM Lab4.F_GetP1Employees()
						ORDER BY Fname
						OFFSET @index ROWS
						FETCH NEXT 1 ROWS ONLY
						SET @index = @index + 1
					END
	END

exec sp_helptext 'Lab4.SP_CheckP1Employees'
exec Lab4.SP_CheckP1Employees
select * from Works_On
--=============================================================================--
--https://www.sqlservertutorial.net/sql-server-basics/sql-server-offset-fetch/
--=============================================================================--
--3. Create a stored procedure that will be used in case there is an old
--employee has left the project and a new one become instead of him. The
--procedure should take 3 parameters (old Emp. number, new Emp. number
--and the project number) and it will be used to update works_on table.
--[Company DB]

CREATE PROC Lab4.UpdateEmpInfo (@OldEmpNum int , @NewEmpNum int , @ProjNum varchar(5))
as
	Begin
		INSERT INTO [Human Resource].Employee
		VALUES (@NewEmpNum,'NA','NA',NULL,NULL)
		
		INSERT INTO Works_On
		VALUES (@NewEmpNum,@ProjNum,NULL,GETDATE())

		DELETE FROM  [Human Resource].Employee
		WHERE EmpNo = @OldEmpNum
	End

select * from [Human Resource].Employee
select * from Works_On


exec Lab4.UpdateEmpInfo 18316,1333,'p1'
--------------------------------------------------------------------------------------
--4. add column budget in project table and insert any draft values in it then
--then Create an Audit table with the following structure
--ProjectNo UserName ModifiedDate Budget_Old Budget_New
--p2 Dbo 2008-01-31 95000 200000
--This table will be used to audit the update trials on the Budget column
--(Project table, Company DB)
--Example:
--If a user updated the budget column then the project number, user name
--that made that update, the date of the modification and the value of the
--old and the new budget will be inserted into the Audit table
--Note: This process will take place only if the user updated the budget
--column
CREATE TABLE Company.Project_Audit(
ProjectNo varchar(5),
UserName varchar(max),
ModifiedDate date,
Budget_Old int,
Budget_New int
)
ALTER TRIGGER Company.Tr_0
on Company.Project
after update
as
	if update(Budget)
		BEGIN
		declare @Old int , @New int
		declare @ProjectNo varchar(5)
		select @Old = Budget from deleted
		select @New = Budget from inserted
		select @ProjectNo = Project_No from inserted
		insert into Company.Project_Audit
		values ( @ProjectNo , SUSER_NAME() , GETDATE() , @Old , @New) 
		END


update Company.Project
set Budget = 4000 Where Project_Name = 'Apollo'


select * from Company.Project
select * from Company.Project_Audit
--------------------------------------------------------------------------------------
--5. Create a trigger to prevent anyone from inserting a new record in the
--Department table [ITI DB]
--“Print a message for user to tell him that he can’t insert a new record in
--that table”
CREATE TRIGGER Tr_1
on Student
instead of insert 
as
	select 'User ' + SUSER_NAME() + ' not allowed to insert a new record in this table'

INSERT INTO STUDENT (St_Id) Values (100)
-- =====> User DESKTOP-STJ40C2\Arabtech not allowed to insert a new record in this table
--------------------------------------------------------------------------------------
--6. Create a trigger that prevents the insertion Process for Employee table in
--March [Company DB].

CREATE TRIGGER Tr_2
on [Human Resource].Employee
instead of insert
as
	if format(getdate(),'MMMM') = 'March'
		select 'Not Allowed to Insert an Employee in March'
	else
		INSERT INTO [Human Resource].Employee
		SELECT * FROM inserted

INSERT INTO [Human Resource].Employee values(112,'Marawan','Ahmed','d1',2200)
sp_helptext r2
--------------------------------------------------------------------------------------
--7. Create a trigger on student table after insert to add Row in Student Audit
--table (Server User Name , Date, Note) where note will be “[username]
--Insert New Row with Key=[Key Value] in table [table name]”
--Server User Name Date Note
CREATE TABLE Student_Audit (
Server_User_Name varchar(max) ,
Date date,
Note varchar(max)
)


CREATE TRIGGER Tr_3
on Student
after insert
as
	BEGIN
	DECLARE @id int
	select @id = St_Id from inserted;
	insert into Student_Audit
	values (SUSER_NAME(),getdate(),concat(SUSER_NAME(),' Inserted New Row with Key=',@id,' in table Student'))
	END	

insert into Student values (16,'Karim','Ali','Alex',32,10,9)
select * from Student_Audit
--------------------------------------------------------------------------------------
--8. Create a trigger on student table instead of delete to add Row in Student
--Audit table (Server User Name, Date, Note) where note will be“ try to
--delete Row with Key=[Key Value]”
CREATE TRIGGER TR_4
on Student
instead of delete
as
	BEGIN
	DECLARE @id int
	select @id = St_Id from deleted
	insert into Student_Audit
	values (SUSER_NAME(),getdate(),concat('Try to delete Row with Key=',@id,' from table Student'))
	END

delete from student where st_id = 16
select * from student
select * from Student_Audit
--------------------------------------------------------------------------------------
