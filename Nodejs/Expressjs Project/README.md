
# Expressjs Project



You will build part of small Nursery, 

the system will have only one administrator with static username and password.

Teachers should register, and administrator will add children to the system. 

Back end will be created as RESTFUL API with json responses with correct status code.



Requirements :

1- Create nurserySystem project folder

2- Create package.json file for your project npm init –y

3- Create MVC folders models,controllers and routes

4- install express npm i express –save

5- install nodemon globally npm i nodemon –g

6- create app.js file and create express server, then open the server on port
number 8080

7- Add script to json file start:”nodemon app” , then run the server using this
script.

8- Create 3 middlewares on server

- Middleware to write request url and method using morgan package
    (search for morgan on npm )
`` 
const morgan = require("morgan");
app.use(morgan(":method :url :response-time"));
``
- General middleware for not Found url pathes with 404 status code.

- One Error handling middleware that will catch all system Errors with 500 status code.


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

2-Create childRouter that contains

- /child - get, to get all children.
- /child/id get to get child by Id
- /child post , to add new child.
- /child put, to update child user Data
- /child delete, to delete specified child.
- check your router using postman


3- Create classRouter that contains
- /class - get, to get all classes.
- /class/id – get to get class by Id.
- /class post , to add new class Data
- /class put, to update class user
- /class delete, to delete specified class.
- /classchildern/id get , to get class children.
- /classTeacher/id get, to get class supervisor
- check your router using postman