const { log } = require("console");
const Car = require("./CarModule");

class FlyingCar extends Car {
    canFly = true;
    constructor (name,model) {
        super(name,model);
    }
}

module.exports = FlyingCar;
