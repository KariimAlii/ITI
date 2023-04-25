/**************************************************************************************************
                                                Part 1

**************************************************************************************************/
// 1 – open mongo shell and view the help

mongosh

help

// 2 – identify your current working database and show list of available databases

show dbs

// 3 – create a new database called iti and create a collection named “students”. Insert whatever data you want about yourself (include name and age in your details).

use ITI

db.createCollection("students")

db.students.insertOne({_id:1,name:"Cristiano Ronaldo",age:37})

db.students.insertMany({_id:2,name:"Sergio Ramos",age:38},{_id:3,name:"Vinisious Junior",age:24})

db.students.find({})

// 4– show list of available databases. What did you notice? 

show dbs

// Database ITI added

// 5 – Insert un-structured or semi-structured data for 10 of your friends 
// (include name and age in your details. 
// The documents should have different types of data i.e. arrays, strings, documents, integers).

db.students.insertMany( [
    {_id:4,name:"Karim Ali",age:26},
    {_id:5,name:"Mohamed Ahmed",age:26},
    {_id:6,name:"Hesham Abden",age:25},
    {_id:7,name:"Ahmed Hassanin",age:23},
    {_id:8,name:"Mohamed Moustafa",age:24}
] )

// Inserting Date
// var yourVariableName= new Date(year,month, day, hour, minute);

db.students.insertMany( [
    { _id:9,
      name:"Ashraf Mohamed",
      age:30,
      Subjects:[{name:"Javascript",date:new Date(2022,11, 25, 3, 0)},
                {name:"Asp.Net MVC",date:new Date(2021,10, 13, 4, 0)}
      ]
    },
    { _id:10,
      name:"Ahmed Hamza",
      age:24,
      Subjects:[{name:"MongoDB",date:new Date(2023,4, 7, 1, 0)},
                {name:"XML",date:new Date(2022,12, 11, 4, 0)}
      ]
    },
] )
db.students.find({})

// 6 – Search for your object by name.
db.students.find({name:"Ahmed Hamza"})

// 7– Search for your friend(s) by age.
db.students.find({age:24})

// 8 – Search for all of your friends whose age is older than yours. 
db.students.find({age:{$gt:26}})

// 9 – delete any of your friends by id.
db.students.deleteOne({_id:3})

// 10 – view all documents in students’ collection in a prettified format.
db.students.find({}).pretty()

// 11 – count all documents in students’ collection. 
db.students.count({})
db.students.countDocuments({})
db.students.countDocuments({age:{$gt:26}})


/**************************************************************************************************
                                                Part 2

**************************************************************************************************/

// 1-	Create database with name ems
use ems
/* 2- Insert the following data into "faculty" collection
{ "name":"Krish", "age":35,"gender":"M","exp":10,subjects:["DS","C","OS"],"type":"Full Time","qualification":"M.Tech" },
 	{ "name":"Manoj", "age":38,"gender":"M","exp":12,subjects:["JAVA","DBMS"],"type":"Full Time", "qualification":"Ph.D"},
	{ "name":"Anush", "age":32,"gender":"F","exp":8,subjects:["C","CPP"],"type":"Part Time","qualification":"M.Tech" },
	{ "name":"Suresh", "age":40,"gender":"M","exp":9,subjects:["JAVA","DBMS","NETWORKING"],"type":"Full Time", "qualification":"Ph.D"},
	{ "name":"Rajesh", "age":35,"gender":"M","exp":7,subjects:["DS","C","OS"],"type":"Full Time","qualification":"M.Tech" },
	{ "name":"Mani", "age":38,"gender":"F","exp":10,subjects:["JAVA","DBMS","OS"],"type":"Part Time", "qualification":"Ph.D"},
	 { "name":"Sivani", "age":32,"gender":"F","exp":8,subjects:["C","CPP","MATHS"],"type":"Part Time","qualification":"M.Tech" },
	 { "name":"Nagesh", "age":39,"gender":"M","exp":11,subjects:["JAVA","DBMS","NETWORKING"],"type":"Full Time", "qualification":"Ph.D"},
	 { "name":"Nagesh", "age":35,"gender":"M","exp":9,subjects:["JAVA",".Net","NETWORKING"],"type":"Full Time", "qualification":"Ph.D"},
	 { "name":"Latha", "age":40,"gender":"F","exp":13,subjects:["MATHS"],"type":"Full Time", "qualification":"Ph.D"}
*/
let facultyArray = [
    { "name":"Krish", "age":35,"gender":"M","exp":10,subjects:["DS","C","OS"],"type":"Full Time","qualification":"M.Tech" },
 	{ "name":"Manoj", "age":38,"gender":"M","exp":12,subjects:["JAVA","DBMS"],"type":"Full Time", "qualification":"Ph.D"},
	{ "name":"Anush", "age":32,"gender":"F","exp":8,subjects:["C","CPP"],"type":"Part Time","qualification":"M.Tech" },
	{ "name":"Suresh", "age":40,"gender":"M","exp":9,subjects:["JAVA","DBMS","NETWORKING"],"type":"Full Time", "qualification":"Ph.D"},
	{ "name":"Rajesh", "age":35,"gender":"M","exp":7,subjects:["DS","C","OS"],"type":"Full Time","qualification":"M.Tech" },
	{ "name":"Mani", "age":38,"gender":"F","exp":10,subjects:["JAVA","DBMS","OS"],"type":"Part Time", "qualification":"Ph.D"},
	{ "name":"Sivani", "age":32,"gender":"F","exp":8,subjects:["C","CPP","MATHS"],"type":"Part Time","qualification":"M.Tech" },
	{ "name":"Nagesh", "age":39,"gender":"M","exp":11,subjects:["JAVA","DBMS","NETWORKING"],"type":"Full Time", "qualification":"Ph.D"},
	{ "name":"Nagesh", "age":35,"gender":"M","exp":9,subjects:["JAVA",".Net","NETWORKING"],"type":"Full Time", "qualification":"Ph.D"},
	{ "name":"Latha", "age":40,"gender":"F","exp":13,subjects:["MATHS"],"type":"Full Time", "qualification":"Ph.D"}
]

db.faculty.insertMany(facultyArray)


// 1.	Get the details of all the faculty.
db.faculty.find({})

// 2.	Get the count of all faculty members. 
db.faculty.countDocuments({})

// 3.	Get all the faculty members whose qualification is “Ph.D”.    
db.faculty.find({qualification:"Ph.D"}) 

// 4.	Get all the faculty members whose experience is between 8 to 12 years.
db.faculty.find( { $and:[ {exp:{$gte:8}} , {exp:{$lte:12}} ] } )
db.faculty.find( { exp:{$gte:8} , exp:{$lte:12}  } )

// 5.	Get all the faculty members who teach “MATHS” or “NETWORKING”.  
db.faculty.find({ $or: [ {subjects:'MATHS'},{subjects:'NETWORKING'} ] })


// 6.	Get all the faculty members who teach “MATHS” and whose age is more than 30 years and qualification must be “Ph.D”.
db.faculty.find({ subjects:'MATHS' , age:{$gt:30} , qualification:'Ph.D' })

// 7.	Get all the faculty members who are working part-time or who teach “JAVA”.
db.faculty.find({$or : [{type:'Part Time'},{subjects:'JAVA'}]})


// 8. Add the following new faculty members:
// { "name":"Suresh Babu", "age":55,"gender":"M","exp":25,subjects:	["MATHS","DE"],"type":"Full Time", "qualification":"Ph.D"}  
db.faculty.insertOne({
    name:"Suresh Babu",
    age:55,
    gender:"M",
    exp:25,
    subjects:["MATHS","DE"],
    type:"Full Time",
    qualification:"Ph.D"  
})

db.faculty.findOne({name:"Suresh Babu"})
// 9. Update the data of all faculty members 
// by incrementing their age 
// and exp by 	one year.
db.faculty.find()
db.faculty.updateMany(
    {},
    {$inc:{exp:1 , age:1}}
)
// 10. Update the faculty “Sivani” with the following data: 
// update qualification to “Ph.D” 
// and type to “Full Time”.
db.faculty.updateOne(
    {name:'Sivani'},
    {$set:{qualification:'Ph.D' , type:'Full Time'}}
)

// 11. Update all faculty members 
// who are teaching “MATHS” such that 
// they should 	now also teach “PSK”.
db.faculty.updateMany(
    {subjects:'MATHS'},
    {$push:{subjects:'PSK'}}
)

// 12. Delete all faculty members whose age is more than 55 years.
db.faculty.deleteMany({age:{$gt:55}})
db.faculty.find()
// 13. Get only the name and qualification of all faculty members.
db.faculty.find(
    {},  // criteria
    { name:1 , qualification:1 }   // projection
)

// 14. Get the name, qualification and exp of all faculty members
// and display the 	same in ascending order of exp.
db.faculty.find(
    {},  // criteria
    { name:1 , qualification:1 , exp:1 },   // projection
).sort({exp:1})

// 15. Sort the faculty details by their age (descending order)
// and get the details of the first five faculty members only.
db.faculty.find().sort({age:-1})
db.faculty.find().sort({age:-1}).limit(5)
