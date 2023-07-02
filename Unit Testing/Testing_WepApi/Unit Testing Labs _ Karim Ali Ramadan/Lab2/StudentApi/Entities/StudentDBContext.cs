﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentApi.Entities
{
    public class StudentDBContext // : DbContext
    {
        public virtual List<Course> Courses { get; set; }
        public virtual List<Student> Students { get; set; }
        public StudentDBContext()
        {
            SeedData();
        }

        public void SeedData()
        {
            Course oop = new Course() { Id = 1, Name = "Object Oriented" };
            Course db = new Course() { Id = 2, Name = "Database" };
            Course cSharp = new Course() { Id = 3, Name = "C#" };

            Student student1 = new Student()
            {
                Id = 1,
                Name = "Mohamed",
                Email = "m@iti.com",
                Password = "123",
                Courses = new List<Course>
                {
                    oop , db, cSharp
                }
            };
            Student student2 = new Student()
            {
                Id = 2,
                Name = "Zeyad",
                Email = "z@iti.com",
                Password = "abc",
                Courses = new List<Course>
                {
                    oop,db
                }
            };
            Student student3 = new Student()
            {
                Id = 3,
                Name = "Hossam",
                Email = "h@iti.com",
                Password = "pass",
                Courses = new List<Course>
                {
                    cSharp
                }
            };
            oop.Students = new List<Student> { student1, student2 };
            db.Students = new List<Student> { student1, student2 };
            cSharp.Students = new List<Student> { student1, student3 };

            Courses = new List<Course> { oop, db, cSharp };
            Students = new List<Student> { student1, student2, student3 };
        }
    }
}