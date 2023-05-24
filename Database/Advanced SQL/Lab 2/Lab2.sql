--Lab 2 - Advanced SQL
---------------------------
create schema Lab2Functions;

--1. Create a scalar function that takes date and returns Month name of that date.
Create function GetMonth(@d date)
returns varchar(20)
	begin
		declare @Month varchar(20)
		SET @Month = MONTH(@d)
		return @Month
	end

alter schema Lab2Functions transfer dbo.GetMonth

select Lab2Functions.GetMonth('2002/1/2') as Month
select Lab2Functions.GetMonth(GETDATE()) as Month
--------------------------------------------------------------------------
--2. Create a multi-statements table-valued function that takes 2 integers
--and returns the values between them.
create function Lab2Functions.GetValuesBetween(@First int , @Second int)
returns @t table
			(
				Number int
			)
as
	begin
		DECLARE @counter INT
		SET @counter = @First
		WHILE @counter >= @First
			BEGIN
				if @counter > @Second
					break
				insert into @t values (@counter)
				SET @counter = @counter + 1
			END
		return
	end
select * from Lab2Functions.GetValuesBetween(1,5);
select * from Lab2Functions.GetValuesBetween(21,27);
---------------------------------------------------------------------------
--3. Create inline function that takes Student No and returns Department
--Name with Student full name.
create function Lab2Functions.GetStudent_Department(@StdNo int)
returns table
as
	return 
	(
		Select 
			(S.St_Fname + ' ' + S.St_Lname) as [Student Full Name] 
			, D.Dept_Name as [Department Name]
		From Student S , Department D
		Where S.Dept_Id = D.Dept_Id AND S.St_Id = @StdNo
	
	)

select * from Lab2Functions.GetStudent_Department(1)
select * from Lab2Functions.GetStudent_Department(6)
select * from Student
select * from Department


---------------------------------------------------------------------------
--4. Create a scalar function that takes Student ID and returns a message to
--user
--a. If first name and Last name are null then display 'First name &
--last name are null'
--b. If First name is null then display 'first name is null'
--c. If Last name is null then display 'last name is null'
--d. Else display 'First name & last name are not null'


create function Lab2Functions.FindStudentNameById(@id int)
returns varchar(40) as
	begin
		Declare @FirstName varchar(20)
		SELECT @FirstName =  St_Fname FROM Student WHERE St_Id = @id
		Declare @LastName varchar(20)
		SELECT @LastName =  St_Lname FROM Student WHERE St_Id = @id
		Declare @message varchar(40)
		IF (@FirstName is NULL AND @LastName is NULL)
				SET @message = 'First name & last name are  null'
		ELSE IF( @LastName is NULL )
				SET @message =' last name is null'
		ELSE IF ( @FirstName is NULL )	
				SET @message =' first name is null'
		ELSE 
				SET @message ='Both first name & last name are not null'

	return @message
	end


SELECT * from Student
SELECT Lab2Functions.FindStudentNameById(11)
SELECT Lab2Functions.FindStudentNameById(13)
SELECT Lab2Functions.FindStudentNameById(14)
SELECT Lab2Functions.FindStudentNameById(7)
---------------------------------------------------------------------------
--5. Create inline function that takes integer which represents manager ID
--and displays department name, Manager Name and hiring date
create function Lab2Functions.GetDepartmentInfo(@ManagerId int)
returns table
as	
	return
	(
		SELECT D.Dept_Name , I.Ins_Name , D.Manager_hiredate
		FROM Department D , Instructor I
		WHERE D.Dept_Manager = I.Ins_Id
	
	)
select * from Department
select * from Instructor
select * from Lab2Functions.GetDepartmentInfo(10)
---------------------------------------------------------------------------
--6. Create multi-statements table-valued function that takes a string
--If string='first name' returns student first name
--If string='last name' returns student last name
--If string='full name' returns Full Name from student table
--Note: Use “ISNULL” function

create function Lab2Functions.GetName(@format varchar(20))
returns @t table
		(
			StudentName varchar(20)
		)
as
	begin
		IF (@format = 'first name') 
			insert into @t
			select St_Fname from Student
		ELSE IF (@format = 'last name')
			insert into @t
			select St_Lname from Student
		ELSE IF (@format = 'full name')
			insert into @t
			select concat(St_Fname, ' ' ,St_Lname) from Student
	return
	end

select * from Student
select * from Lab2Functions.GetName('first name')
select * from Lab2Functions.GetName('last name')
select * from Lab2Functions.GetName('full name')
---------------------------------------------------------------------------
--7. Write a query that returns the Student No and Student first name
--without the last char
Select St_Id , SUBSTRING(St_Fname,1,LEN(St_Fname)-1)
FROM Student

---------------------------------------------------------------------------
--8. Wirte query to delete all grades for the students Located in SD
--Department

DELETE FROM Stud_Course
FROM Stud_Course C 
	inner join Student S ON C.St_Id = S.St_Id
	inner join Department D ON S.Dept_Id = D.Dept_Id
WHERE D.Dept_Name = 'SD'

select * from Student
select * from Stud_Course
select * from Department

--Bonus:
--1. Give an example for hierarchyid Data type

--2. Create a batch that inserts 3000 rows in the student table(ITI database).
--The values of the st_id column should be unique and between 3000 and
--6000. All values of the columns st_fname, st_lname, should be set to 'Jane',
--' Smith' respectively.