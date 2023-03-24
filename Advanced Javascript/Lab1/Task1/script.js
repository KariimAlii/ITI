//! 1. Using Constructor method for creating Objects, write a script
// that allows you to create a rectangle object that
// Should have width and height properties.
// Implement method for calculating its area
// Implement method for calculating its perimeter.
// Implement displayInfo() function to display a message
// declaring the width, height, area and perimeter of the
// created object.

const Rectangle = function(width , height) {
    this.width = width;
    this.height = height;
    this.getArea = function () {
        return (this.width * this.height) ;
    }
    this.getPerimeter = function () {
        return 2 * (width + height);
    }
    this.displayInfo = () => {
        console.log(`Width = ${this.width},Height = ${this.height}`);
        console.log(`Area = ${r1.getArea()}`);
        console.log(`Perimeter = ${r1.getPerimeter()}`);
        console.log(`Area = ${r1.getArea()}`);
    }
}
const r1 = new Rectangle(3,4);
console.log(r1);
r1.displayInfo();