
# Node.js Lab1


- Create your project Folder and start adding project package.json file
``npm init or npm init -y``
- add express package from npm as dependancies.
- add morgan package from npm as devDependancies.
- add a start script to your json fail with “node baseModule”
- now remove your node_modules folder and try npm install
- Note : try ``npm install --production``
- Create carModule.js file that contains Car class with the following properties

    a- Model (“pmw”,”picanto” and so on)

    b- Year

    c- carData Function that’s print car’s data(model,year)

    Export the class as default module export

- Create FlyCar.js that contains FlyingCar clas sthat inherits from car and has property canFly(TRUE)

    FlyigCar Class has CarData Function that call parent function and print “I can Fly”

    Export it

- Create FlyinCar object and calling carData function inside base.js Module

- Finally: run base file using npm start

