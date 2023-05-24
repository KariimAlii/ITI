--1. Create a cursor for Employee table that increases Employee
--salary by 10% if Salary <3000 and increases it by 20% if
--Salary >=3000. Use company DB

DECLARE C1 CURSOR
for
	SELECT Salary
	FROM [Human Resource].Employee E
for update
DECLARE @sal int
OPEN C1
FETCH C1 into @sal
WHILE @@FETCH_STATUS = 0
	BEGIN
		
		IF (@sal < 3000)
			UPDATE [Human Resource].Employee
				SET Salary = @sal * 1.1
			WHERE CURRENT OF C1
		ELSE
			UPDATE [Human Resource].Employee
				SET Salary = @sal * 1.2
			WHERE CURRENT OF C1
		FETCH C1 into @sal
	END
CLOSE C1
DEALLOCATE C1
------------------------------------------------------------------
--2. Display Department name with its manager name using
--cursor. Use ITI DB

DECLARE C2 CURSOR
FOR
	SELECT D.Dept_Name , I.Ins_Name
	FROM Instructor I , Department D
	WHERE I.Ins_Id = D.Dept_Manager
FOR read only

DECLARE @depName varchar(50) , @managerName varchar(50)
OPEN C2
FETCH C2 into @depName , @managerName
WHILE @@FETCH_STATUS = 0
	BEGIN
		SELECT @depName as [Department Name], @managerName as [Manager Name]
		FETCH C2 into @depName , @managerName
	END
CLOSE C2
DEALLOCATE C2

------------------------------------------------------------------
--3. Try to display all students first name in one cell separated
--by comma. Using Cursor

DECLARE C3 CURSOR
FOR
	SELECT St_Fname from Student
FOR READ ONLY

DECLARE @Name varchar(50) , @AllNames varchar(max) = ''
OPEN C3
FETCH C3 into @Name
WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @AllNames = concat(@AllNames , ' , ',@Name)
		FETCH C3 INTO @Name
	END
SELECT @AllNames
CLOSE C3
Deallocate C3


------------------------------------------------------------------
--4. Create full, differential Backup for SD DB.

-- FULL BACKUP
BACKUP DATABASE SD
to Disk = 'D:\SD.bak'

-- Differential Backup
BACKUP DATABASE SD
to Disk = 'D:/SD-Differential.bak'
WITH DIFFERENTIAL


------------------------------------------------------------------
--7. Create a sequence object that allow values from 1 to 10
--without cycling in a specific column and test it.

CREATE SCHEMA Lab5


CREATE SEQUENCE Lab5.S1
AS INT
START WITH 1
INCREMENT BY 1
MINVALUE 1
MAXVALUE 10
CYCLE

CREATE TABLE Lab5.Instructors(
Ins_id int Primary Key,
Fname varchar(20),
Lname varchar(20)
)

DECLARE @index int = 1
WHILE @index < 10
	BEGIN
		Insert into Lab5.Instructors values(NEXT VALUE FOR Lab5.S1,'Karim','Ali')
		set @index = @index + 1
	END

select * from Lab5.Instructors
delete from Lab5.Instructors

