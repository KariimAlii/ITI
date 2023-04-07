
# Expressjs Project



You will build part of small Nursery, 

the system will have only one administrator with static username and password.

Teachers should register, and administrator will add children to the system. 

Back end will be created as RESTFUL API with json responses with correct status code.



Requirements :

1- Create nurserySystem project folder

2- Create package.json file for your project npm init –y

![image](https://user-images.githubusercontent.com/101140331/230521144-863f3903-b8c6-43f9-851e-e09744c45b8a.png)


3- Create MVC folders models,controllers and routes

![image](https://user-images.githubusercontent.com/101140331/230521160-a71cbddb-16b6-4f14-bb93-6b8f88a9286c.png)


4- install express npm i express –save

![image](https://user-images.githubusercontent.com/101140331/230521175-44e9e49a-da19-4a3d-913e-cc4109305959.png)


5- install nodemon globally npm i nodemon –g

![image](https://user-images.githubusercontent.com/101140331/230521199-93031794-4e01-4220-9d32-9ddb2d124999.png)

6- create app.js file and create express server, then open the server on port
number 8080

![image](https://user-images.githubusercontent.com/101140331/230521213-3a9182e8-586d-48eb-ad56-0405098b8e9e.png)

7- Add script to json file start:”nodemon app” , then run the server using this
script.

![image](https://user-images.githubusercontent.com/101140331/230521224-c2632858-fd9c-4f9b-a3a3-dc560acb0301.png)
![image](https://user-images.githubusercontent.com/101140331/230521230-66181883-3344-4b54-acb8-51829be6e565.png)


8- Create 3 middlewares on server

- Middleware to write request url and method using morgan package
    (search for morgan on npm )
`` 
const morgan = require("morgan");
app.use(morgan(":method :url :response-time"));
``

![image](https://user-images.githubusercontent.com/101140331/230521260-4d91f0b3-23b4-4ea4-acb4-b82de722526e.png)


- General middleware for not Found url pathes with 404 status code.

    ``app.use((request,response,next) => {
        response.status(404).json({message:"Not Found"})
    }) ``

- One Error handling middleware that will catch all system Errors with 500 status code.
    ``app.use((error,request,response,next) => {
    response.status(500).json({message:`Exception Occured: ${error}`})
    })``

Users: administrator(static) and teacher

## Now start create your routes

- Teacher Data: _id(objectID), fullname,password, email , image (which is string)

- Child Data: _id(Number), fullName, age , level (PreKG,KG1,KG2), address (city,street and building)

- Class Data:_id(Number), name, supervisor (teacher id number), children which is array of children ids

1- Create teacherRoute that contains

- /teachers - get, to get all teachers.
- /teachers post , to add new teacher.
- /teachers put, to update teacher user DataEman Fathi Intake43
- /teahers delete, to delete specified teacher.
- check your router using postman

<a href="./Routes/TeacherRouter.js" target="_blank">
<img src="https://img.shields.io/badge/Routes-Teacher%20Router-brightgreen"/>
</a>

2-Create childRouter that contains

- /child - get, to get all children.
- /child/id get to get child by Id
- /child post , to add new child.
- /child put, to update child user Data
- /child delete, to delete specified child.
- check your router using postman

<a href="./Routes/ChildRouter.js" target="_blank">
<img src="https://img.shields.io/badge/Routes-Child%20Router-brightgreen"/>
</a>

3- Create classRouter that contains
- /class - get, to get all classes.
- /class/id – get to get class by Id.
- /class post , to add new class Data
- /class put, to update class user
- /class delete, to delete specified class.
- /classchildern/id get , to get class children.
- /classTeacher/id get, to get class supervisor
- check your router using postman

<a href="./Routes/ClassRouter.js" target="_blank">
<img src="https://img.shields.io/badge/Routes-Class%20Router-brightgreen"/>
</a>
