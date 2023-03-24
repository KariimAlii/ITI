//! 2. Create your own custom object that has getSetGen as function
// value, this function should generate setters and getters for the
// properties of the caller object
// This object may have description property of string value if
// needed
// Let any other created object can use this function property to
// generate getters and setters for his own properties
// Avoid generating getters or setters for property of function value
// Hint:
// if getSetGen() applied on any other object it should generate
// getters and setters for all of the applied object properties
// i.e. if you have the following object
// obj = {id:”SD-10”,location:”SV”, addr:”123 st.”, getSetGen:
// function(){/*should be implemented*/}}
// using of getSetGen() will generate the following getId(), setId(),
// getLocation(), setLocation(), getAddr(), setAddr().
// If you created the following object
// var user = { name:”Ali”,age:10}
// When applying getSetGen() on user object (you can use call or
// bind or apply as long as getSetGen() is not a member for user
// object), it will result in creating the following : getName(),
// getAge(),setName(),setAge().

const obj = {
    name:'Karim Ali',
    age:9,
    display:function() {
        return `Hello from ${this.name}! My Age is ${this.age}`;
    }
}
function getSenGen (Obj) {
    Object.values(Obj).forEach((value,i) => {
        if (typeof(value) !== 'function') {
            var key = Object.keys(obj)[i];
            Obj[`get${key}`] = function () {return Obj[key];}
            Obj[`set${key}`] = function (x) {Obj[key] = x}
            // delete Obj[key];
        }
    })
    return Obj;
}
const modifiedObject = getSenGen(obj);
console.log(modifiedObject)

console.log(modifiedObject.getname())
console.log(modifiedObject.getage())
console.log(modifiedObject.display())


modifiedObject.setname('Mohamed Ashraf')
modifiedObject.setage(26)

console.log(modifiedObject.getname())
console.log(modifiedObject.getage())
console.log(modifiedObject.display())






// Object.values(obj).forEach((value) => {
//     // if (typeof(value) === 'string') console.log(`hey from string:${value}`)
//     // if (typeof(value) === 'function') console.log(`hey from function:${value}`)
//     // if (typeof(value) === 'number') console.log(`hey from number:${value}`)
    
    
//     if (typeof(value) !== 'function') console.log(`hey from type:${value}`)


// });




