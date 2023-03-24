select * from Employee , Department
where Department.Dept_id = Employee.Dept_id

select * from Department
select * from Employee
SELECT Employee.*, Department.Dept_Name
FROM   Department INNER JOIN  Employee
ON Department.Dept_id = Employee.Dept_id
AND Department.Dept_Name = 'IT'

Insert into [Employee] ([Emp_id],[Emp_Name],[Dept_id]) 
values (10,'Samia',1) 

UPDATE [Employee] SET  [Emp_Name] = 'Krkr' WHERE [Emp_id] = 10

DELETE FROM [Employee] WHERE [Emp_id] = 13
DELETE FROM [Department] WHERE [Dept_id] = 6