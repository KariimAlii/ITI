//==========================================================================================
//! 2. Build your own custom constructors that implement the given
//! simple class diagram
//*  each class should have the following
//* o public and private properties and method;
//* o You should ensure that properties are set with the
//* required data type state in the above diagram
//* otherwise throw an exception.
//* o All of the properties should be defined using accessor
//* and/or data descriptor, prevent them from being
//* deleted, iterated or being modified.
//* o Override both .toString() and valueOf()
//* o Make sure you are implementing inheritance properly.
//* o You can add any property you need.

function Vehicle(speed, color) {
    this.speed = speed;
    this.color = color;
}
Vehicle.prototype.turnLeft = function () {
    console.log("Turn Left!");
};
Vehicle.prototype.turnRight = function () {
    console.log("Turn Right!");
};
Vehicle.prototype.start = function () {
    console.log("Start!");
};
Vehicle.prototype.stop = function () {
    console.log("Stop!");
};
Vehicle.prototype.goBackward = function () {
    console.log("Go Backward!");
};
Vehicle.prototype.goForward = function () {
    console.log("Go Forward!");
};
//====================================================
function Bicycle(speed, color) {
    Vehicle.call(this, speed, color);
}
Bicycle.prototype = Object.create(Vehicle.prototype);
Bicycle.prototype.constructor = Bicycle;
Bicycle.prototype.ringBell = function () {
    console.log("trntrntrnrtn");
};

//==============================================

function MotorVehicle(speed, color, sizeOfEngine, licencePlate) {
    Vehicle.call(this, speed, color);
    this.sizeOfEngine = sizeOfEngine;
    this.licencePlate = licencePlate;
}
MotorVehicle.prototype = Object.create(Vehicle.prototype);
MotorVehicle.prototype.constructor = MotorVehicle;
MotorVehicle.prototype.getSizeOfEngine = function () {
    return this.sizeOfEngine;
};
MotorVehicle.prototype.getLicencePlate = function () {
    return this.licencePlate;
};

//=================================================
function Car(
    speed,
    color,
    sizeOfEngine,
    licencePlate,
    numOfDoors,
    numWheels,
    weight
) {
    MotorVehicle.call(this, speed, color, sizeOfEngine, licencePlate);
    this.numOfDoors = numOfDoors;
    this.numWheels = numWheels;
    this.weight = weight;
}
Car.prototype = Object.create(MotorVehicle.prototype);
Car.prototype.constructor = Car;
Car.prototype.switchOnAirCon = function () {
    console.log("Ok Switched On!");
};
Car.prototype.getNumOfDoors = function () {
    return this.numOfDoors;
};
//================================================
function DumpTruck(
    speed,
    color,
    sizeOfEngine,
    licencePlate,
    loadCapacity,
    numWheels,
    weight
) {
    MotorVehicle.call(this, speed, color, sizeOfEngine, licencePlate);
    this.loadCapacity = loadCapacity;
    this.numWheels = numWheels;
    this.weight = weight;
}
DumpTruck.prototype = Object.create(MotorVehicle.prototype);
DumpTruck.prototype.constructor = DumpTruck;
DumpTruck.prototype.lowerLoad = function () {
    console.log("Ok done!");
};
DumpTruck.prototype.raiseLoad = function () {
    console.log("Ok done!");
};
