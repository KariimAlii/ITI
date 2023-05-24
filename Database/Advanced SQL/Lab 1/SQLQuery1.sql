-- Lab 1
-- Part 1
-- Point 1

-- Creating a User-Defined Datatype
sp_addtype loc,'nchar(2)' ;

-- Creating a Rule
create rule r1 as @x in ('NY','DS','KW');

-- Creating a Default
create default def1 as 'NY';

-- Binding Rule to Datatype
sp_bindrule r1,loc;

-- Binding Default to Datatype

sp_bindefault def1,loc

-- Creating Department Table

create table Department
(
Dept_No varchar(5) Primary Key,
DeptName varchar(20),
Location loc
);

-- Insert Department Table Rows

Insert into Department values ('D1','Research','NY');
Insert into Department values ('D2','Accounting','DS');
Insert into Department values ('D3','Marketing','KW');



-- creating rule 2

create rule r2 as @x < 6000;

-- Creating Employee Table

create table Employee
(
EmpNo int,
Fname varchar(20) not null,
Lname varchar(20) not null,
DeptNo varchar(5),
Salary int,
constraint c1 Primary Key (EmpNo),
constraint c2 Foreign Key (DeptNo) references Department(Dept_No)
	on delete set null
	on update cascade,
constraint c3 UNIQUE (Salary),
);

-- Binding a Rule to Column (Salary) in Table (Employee)

sp_bindrule r2,'Employee.Salary';

-- Inserting Data to Table Employee
Insert into Employee values (25348,'Mathew','Smith','d3',2500);
Insert into Employee values (10102,'Ann','Jones','d3',3000);
Insert into Employee values (18316,'John','Barrimore','d1',2400);
Insert into Employee values (29346,'James','James','d2',2800);
Insert into Employee values (9031,'Lisa','Bertoni','d2',4000);
Insert into Employee values (2581,'Elisa','Hansel','d2',3600);
Insert into Employee values (28559,'Sybl','Moser','d1',2900);


-- Table Modification
--1.Add Column TelephoneNumber to Employee Table
Alter Table Employee
Add TelephoneNumber int;

--2.Drop this Column
Alter Table Employee
Drop Column TelephoneNumber;


------------------------------------------------

--Point 2
----------------
--Creating Schema

create schema Company

alter schema Company transfer Department


create schema "Human Resource"
alter schema "Human Resource" transfer Employee

-- Point 3
-- View Constraints of table Employee

SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE TABLE_NAME='Employee'

select * from Employee
select * from [Human Resource].Employee

--Point 4
-- Create synonym Emp for Table Employee
alter synonym Emp for [Human Resource].Employee;
create synonym Empl for [Human Resource].Employee;

select * from Employee;
select * from [Human Resource].Employee;

select * from Emp;

select * from Empl;

--Point 5
UPDATE Company.Project
SET Budget = 1.1 * Budget
FROM Works_On W , [Human Resource].Employee E , Company.Project P
WHERE W.EmpNo = E.EmpNo
AND W.ProjectNo = P.Project_No
AND W.Job = 'Manager'

--Point 6
UPDATE Company.Department
SET DeptName = 'Sales'
FROM Company.Department D , [Human Resource].Employee E
WHERE E.DeptNo = D.Dept_No AND E.Fname = 'James'



-- Point 7
UPDATE W
SET W.Enter_Date = '12/12/2007'
FROM Company.Project P , [Human Resource].Employee E , Company.Department D , Works_On W
WHERE W.EmpNo = E.EmpNo AND W.ProjectNo = P.Project_No AND E.DeptNo = D.Dept_No AND D.DeptName = 'Sales'



-- Point 8
DELETE FROM W
FROM Works_On as W INNER JOIN [Human Resource].Employee as E ON W.EmpNo=E.EmpNo INNER JOIN
Company.Department as D ON E.DeptNo = D.Dept_No
WHERE D.Location = 'KW'




--CHECK
--------
--select * from Works_On
--select * from [Human Resource].Employee
--select * from Company.Department