USE [master]
GO
/****** Object:  Database [ITI]    Script Date: 2/24/2023 5:46:42 PM ******/
CREATE DATABASE [ITI]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ITI', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ITI.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ITI_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ITI_log.ldf' , SIZE = 7616KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ITI] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ITI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ITI] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ITI] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ITI] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ITI] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ITI] SET ARITHABORT OFF 
GO
ALTER DATABASE [ITI] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ITI] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ITI] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ITI] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ITI] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ITI] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ITI] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ITI] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ITI] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ITI] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ITI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ITI] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ITI] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ITI] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ITI] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ITI] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ITI] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ITI] SET RECOVERY FULL 
GO
ALTER DATABASE [ITI] SET  MULTI_USER 
GO
ALTER DATABASE [ITI] SET PAGE_VERIFY NONE  
GO
ALTER DATABASE [ITI] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ITI] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ITI] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ITI] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ITI] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ITI', N'ON'
GO
ALTER DATABASE [ITI] SET QUERY_STORE = OFF
GO
USE [ITI]
GO
/****** Object:  User [koko]    Script Date: 2/24/2023 5:46:42 PM ******/
CREATE USER [koko] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [iti]    Script Date: 2/24/2023 5:46:42 PM ******/
CREATE USER [iti] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Schema [iti]    Script Date: 2/24/2023 5:46:42 PM ******/
CREATE SCHEMA [iti]
GO
/****** Object:  Schema [Lab2Functions]    Script Date: 2/24/2023 5:46:42 PM ******/
CREATE SCHEMA [Lab2Functions]
GO
/****** Object:  Schema [Lab3]    Script Date: 2/24/2023 5:46:42 PM ******/
CREATE SCHEMA [Lab3]
GO
/****** Object:  Schema [Lab4]    Script Date: 2/24/2023 5:46:42 PM ******/
CREATE SCHEMA [Lab4]
GO
/****** Object:  UserDefinedFunction [Lab2Functions].[FindStudentNameById]    Script Date: 2/24/2023 5:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE function [Lab2Functions].[FindStudentNameById](@id int)
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
GO
/****** Object:  UserDefinedFunction [Lab2Functions].[GetMonth]    Script Date: 2/24/2023 5:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create function [Lab2Functions].[GetMonth](@d date)
returns varchar(20)
	begin
		declare @Month varchar(20)
		SET @Month = MONTH(@d)
		return @Month
	end
GO
/****** Object:  UserDefinedFunction [Lab2Functions].[GetName]    Script Date: 2/24/2023 5:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [Lab2Functions].[GetName](@format varchar(20))
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
GO
/****** Object:  UserDefinedFunction [Lab2Functions].[GetValuesBetween]    Script Date: 2/24/2023 5:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [Lab2Functions].[GetValuesBetween](@First int , @Second int)
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
GO
/****** Object:  Table [dbo].[Student]    Script Date: 2/24/2023 5:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[St_Id] [int] NOT NULL,
	[St_Fname] [nvarchar](50) NULL,
	[St_Lname] [nchar](10) NULL,
	[St_Address] [nvarchar](100) NULL,
	[St_Age] [int] NULL,
	[Dept_Id] [int] NULL,
	[St_super] [int] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[St_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 2/24/2023 5:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Dept_Id] [int] NOT NULL,
	[Dept_Name] [nvarchar](50) NULL,
	[Dept_Desc] [nvarchar](100) NULL,
	[Dept_Location] [nvarchar](50) NULL,
	[Dept_Manager] [int] NULL,
	[Manager_hiredate] [date] NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Dept_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [Lab2Functions].[GetStudent_Department]    Script Date: 2/24/2023 5:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [Lab2Functions].[GetStudent_Department](@StdNo int)
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
GO
/****** Object:  Table [dbo].[Instructor]    Script Date: 2/24/2023 5:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instructor](
	[Ins_Id] [int] NOT NULL,
	[Ins_Name] [nvarchar](50) NULL,
	[Ins_Degree] [nvarchar](50) NULL,
	[Salary] [money] NULL,
	[Dept_Id] [int] NULL,
 CONSTRAINT [PK_Instructor] PRIMARY KEY CLUSTERED 
(
	[Ins_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [Lab2Functions].[GetDepartmentInfo]    Script Date: 2/24/2023 5:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [Lab2Functions].[GetDepartmentInfo](@ManagerId int)
returns table
as	
	return
	(
		SELECT D.Dept_Name , I.Ins_Name , D.Manager_hiredate
		FROM Department D , Instructor I
		WHERE D.Dept_Manager = I.Ins_Id
	
	)
GO
/****** Object:  Table [dbo].[Course]    Script Date: 2/24/2023 5:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[Crs_Id] [int] NOT NULL,
	[Crs_Name] [nvarchar](50) NULL,
	[Crs_Duration] [int] NULL,
	[Top_Id] [int] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Crs_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stud_Course]    Script Date: 2/24/2023 5:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stud_Course](
	[Crs_Id] [int] NOT NULL,
	[St_Id] [int] NOT NULL,
	[Grade] [int] NULL,
 CONSTRAINT [PK_Stud_Course] PRIMARY KEY CLUSTERED 
(
	[Crs_Id] ASC,
	[St_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [Lab3].[V_Std_Course]    Script Date: 2/24/2023 5:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [Lab3].[V_Std_Course] AS
SELECT CONCAT(S.St_Fname,' ',S.St_Lname) as [Full Name] , C.Crs_Name as [Course Name]
FROM Student as S , Course as C , Stud_Course as SC
WHERE S.St_Id = SC.St_Id AND C.Crs_Id = SC.Crs_Id
GO
/****** Object:  View [Lab3].[V_Instructor_SD_Java]    Script Date: 2/24/2023 5:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [Lab3].[V_Instructor_SD_Java] AS
	SELECT I.Ins_Name as [Instructor Name] , D.Dept_Name as [Department Name]
	FROM Instructor I , Department D
	WHERE I.Dept_Id = D.Dept_Id AND D.Dept_Name IN ('SD','Java');
GO
/****** Object:  View [Lab3].[V1]    Script Date: 2/24/2023 5:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [Lab3].[V1] AS
	SELECT *
	FROM Student S
	WHERE S.St_Address in ( 'Alex' , 'Cairo')
	With Check Option
GO
/****** Object:  Table [dbo].[Ins_Course]    Script Date: 2/24/2023 5:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ins_Course](
	[Ins_Id] [int] NOT NULL,
	[Crs_Id] [int] NOT NULL,
	[Evaluation] [nvarchar](50) NULL,
 CONSTRAINT [PK_Ins_Course] PRIMARY KEY CLUSTERED 
(
	[Ins_Id] ASC,
	[Crs_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Audit]    Script Date: 2/24/2023 5:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Audit](
	[Server_User_Name] [varchar](max) NULL,
	[Date] [date] NULL,
	[Note] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topic]    Script Date: 2/24/2023 5:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topic](
	[Top_Id] [int] NOT NULL,
	[Top_Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Topic] PRIMARY KEY CLUSTERED 
(
	[Top_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [index1]    Script Date: 2/24/2023 5:46:42 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [index1] ON [dbo].[Student]
(
	[St_Age] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Topic] FOREIGN KEY([Top_Id])
REFERENCES [dbo].[Topic] ([Top_Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Topic]
GO
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_Department_Instructor] FOREIGN KEY([Dept_Manager])
REFERENCES [dbo].[Instructor] ([Ins_Id])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_Department_Instructor]
GO
ALTER TABLE [dbo].[Ins_Course]  WITH CHECK ADD  CONSTRAINT [FK_Ins_Course_Course] FOREIGN KEY([Crs_Id])
REFERENCES [dbo].[Course] ([Crs_Id])
GO
ALTER TABLE [dbo].[Ins_Course] CHECK CONSTRAINT [FK_Ins_Course_Course]
GO
ALTER TABLE [dbo].[Ins_Course]  WITH CHECK ADD  CONSTRAINT [FK_Ins_Course_Instructor] FOREIGN KEY([Ins_Id])
REFERENCES [dbo].[Instructor] ([Ins_Id])
GO
ALTER TABLE [dbo].[Ins_Course] CHECK CONSTRAINT [FK_Ins_Course_Instructor]
GO
ALTER TABLE [dbo].[Instructor]  WITH CHECK ADD  CONSTRAINT [FK_Instructor_Department] FOREIGN KEY([Dept_Id])
REFERENCES [dbo].[Department] ([Dept_Id])
GO
ALTER TABLE [dbo].[Instructor] CHECK CONSTRAINT [FK_Instructor_Department]
GO
ALTER TABLE [dbo].[Stud_Course]  WITH CHECK ADD  CONSTRAINT [FK_Stud_Course_Course] FOREIGN KEY([Crs_Id])
REFERENCES [dbo].[Course] ([Crs_Id])
GO
ALTER TABLE [dbo].[Stud_Course] CHECK CONSTRAINT [FK_Stud_Course_Course]
GO
ALTER TABLE [dbo].[Stud_Course]  WITH CHECK ADD  CONSTRAINT [FK_Stud_Course_Student] FOREIGN KEY([St_Id])
REFERENCES [dbo].[Student] ([St_Id])
GO
ALTER TABLE [dbo].[Stud_Course] CHECK CONSTRAINT [FK_Stud_Course_Student]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Department] FOREIGN KEY([Dept_Id])
REFERENCES [dbo].[Department] ([Dept_Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Department]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Student] FOREIGN KEY([St_super])
REFERENCES [dbo].[Student] ([St_Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Student]
GO
/****** Object:  StoredProcedure [Lab4].[GetNumStudPerDept]    Script Date: 2/24/2023 5:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [Lab4].[GetNumStudPerDept]
as
	SELECT D.Dept_Name , COUNT(S.St_Id) as [Students Number]
	FROM Student S , Department D
	WHERE S.Dept_Id = D.Dept_Id
	GROUP BY D.Dept_Name
GO
USE [master]
GO
ALTER DATABASE [ITI] SET  READ_WRITE 
GO
