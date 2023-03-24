//! 1.a. Make proper updates in (lab#1 task#5) your previous code of
//! generating Rectangle objects,
//  Rectangle Constructor should inherit from Shape
// Constructor
//  Create your Square constructor that inherits from
// Rectangle.
//  Create a Class Property that counts number of generated
// Square objects.
//  Prevent creating any object from shape, allow creation of
// only rectangles and square (make shape abstract class)
//  All of the properties should be defined using accessor
// and/or data descriptor, prevent them from being deleted,
// iterated or being modified.
//  Use .toString() to display each instance’s dimensions, its
// area and perimeter.
//  Implement .valueof() so that if there is more than one
// rectangle object we can run arithmetic operation as follows
// : if we have rectangle1 of area 60m2 and rectangle2 of
// 37m2 then rectangle1 + rectangle2 should return 97 and
// rectangle1 - rectangle2 should return 23.
//  you can add any property you need.
// 1.b Bonus: allow creation of only one square and one rectangle

function Shape(length, width) {
    this.length = length;
    this.width = width;
    if (this.constructor === Shape)
        throw "You cannot initiate an object from Abstract Class!";
}
function Rectangle(length, width) {
    if (Rectangle.createdRectanglesNum >= 1 && this.constructor === Rectangle)
        throw "You have created a rectangle ! You cannot create more!";
    Shape.call(this, length, width);
    this.calculateArea = function () {
        return length * width;
    };
    this.calculatePerimeter = function () {
        return 2 * (length + width);
    };
    if (this.constructor === Rectangle) Rectangle.createdRectanglesNum++;
}
Rectangle.prototype = Object.create(Shape.prototype);
Rectangle.prototype.constructor = Rectangle;
Rectangle.prototype.toString = function () {
    return `Dimensions are ${this.length} & ${
        this.width
    } , Area = ${this.calculateArea()} , Perimeter = ${this.calculatePerimeter()}`;
};
Rectangle.prototype.valueOf = function () {
    return this.calculateArea();
};
Rectangle.createdRectanglesNum = 0;
Rectangle.countCreatedRectangles = function () {
    return this.createdRectanglesNum;
};
function Square(length) {
    if (Square.createdSquaresNum >= 1)
        throw "You have created a square ! You cannot create more!";
    Rectangle.call(this, length, length);
    Square.createdSquaresNum++;
}
Square.createdSquaresNum = 0;
Square.countCreatedSquares = function () {
    return this.createdSquaresNum;
};
Square.prototype = Object.create(Rectangle.prototype);
Square.prototype.constructor = Square;

// Object.freeze(Shape);
// Object.freeze(Rectangle);
// Object.freeze(Square);

Object.defineProperties(Shape, {
    length: {
        writable: false,
        configurable: false,
        enumerable: false,
    },
    width: {
        writable: false,
        configurable: false,
        enumerable: false,
    },
});

//=========Trial============//
// let s1 = new Shape(10,5); //!You cannot initiate an object from Abstract Class!
let r1 = new Rectangle(10, 5);
console.log("r1.calculateArea(): ", r1.calculateArea());
console.log("r1.calculatePerimeter(): ", r1.calculatePerimeter());
console.log("r1.toString(): ", r1.toString());

let r2 = new Rectangle(7, 8);
console.log("r2.calculateArea(): ", r2.calculateArea());
console.log("r2.calculatePerimeter(): ", r2.calculatePerimeter());
console.log("r2.toString(): ", r2.toString());

const x = r1 + r2;
console.log("r1+r2: ", x);

let sq1 = new Square(8); //! You have created a rectangle ! You cannot create more!
console.log("sq1.calculateArea(): ", sq1.calculateArea());
console.log("sq1.calculatePerimeter(): ", sq1.calculatePerimeter());
// let sq2 = new Square(6); //!You have created a square ! You cannot create more!

