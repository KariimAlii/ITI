
# Node.js Lab1


- Create your project Folder and start adding project package.json file
``npm init or npm init -y``
![image](https://user-images.githubusercontent.com/101140331/230519087-53d3da04-9aa4-44ca-a7e5-1181acb7e9a6.png)
![image](https://user-images.githubusercontent.com/101140331/230519100-a367302d-dfd6-4ceb-b37e-25a34ade9d54.png)

- add express package from npm as dependancies.
- add morgan package from npm as devDependancies.
![image](https://user-images.githubusercontent.com/101140331/230519112-166b1084-6d7e-4822-9758-293a5f247cb2.png)

- add a start script to your json fail with “node baseModule”
-
![image](https://user-images.githubusercontent.com/101140331/230519120-1aae8ee7-4d22-4e42-b17d-9d95a56cfe28.png)
![image](https://user-images.githubusercontent.com/101140331/230519132-dfff4223-0101-47f9-95d6-a9d9195ec8df.png)

- now remove your node_modules folder and try npm install

![image](https://user-images.githubusercontent.com/101140331/230519155-414ffd68-026b-41d4-ad89-29e26c023272.png)
![image](https://user-images.githubusercontent.com/101140331/230519169-29738a97-35cd-4bcc-a187-d4f9cf7a7795.png)
![image](https://user-images.githubusercontent.com/101140331/230519176-04c50ec5-520f-4f33-8839-91769d57466f.png)

- Note : try ``npm install --production``
- Create carModule.js file that contains Car class with the following properties

    a- Model (“pmw”,”picanto” and so on)

    b- Year

    c- carData Function that’s print car’s data(model,year)

    Export the class as default module export
    
    [Car Module File](./CarModule.js)

- Create FlyCar.js that contains FlyingCar clas sthat inherits from car and has property canFly(TRUE)

    FlyigCar Class has CarData Function that call parent function and print “I can Fly”

    Export it
    [Fly Car Class File](./FlyCar.js)

- Create FlyinCar object and calling carData function inside base.js Module

- Finally: run base file using npm start
- 
![image](https://user-images.githubusercontent.com/101140331/230519193-d47fbe8f-8341-46a6-b5ff-2069e1a2c5d0.png)

