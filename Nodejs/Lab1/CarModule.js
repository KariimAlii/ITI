class Car {
    name;
    model;
    constructor(name, model) {
        this.name = name;
        this.model = model;
    }
    carData() {
        return `Car Name: ${this.name} , Car Model: ${this.model}`;
    }
}
module.exports = Car;
