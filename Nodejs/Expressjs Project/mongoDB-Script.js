db.employees.find()

db.employees.remove({})

let instructorsArray = [
    {
        _id: 6,
        firstName: "noha",
        lastName: "hesham",
        age: 21,
        salary: 3500,
        address: { city: "cairo", street: 10, building: 8 },
        courses: ["js", "mvc", "signalR", "expressjs"],
    },

    {
        _id: 7,
        firstName: "mona",
        lastName: "ahmed",
        age: 21,
        salary: 3600,
        address: { city: "cairo", street: 20, building: 8 },
        courses: ["es6", "mvc", "signalR", "expressjs"],
    },

    {
        _id: 8,
        firstName: "mazen",
        lastName: "mohammed",
        age: 21,
        salary: 7040,
        address: { city: "Ismailia", street: 10, building: 8 },
        courses: ["asp.net", "mvc", "EF"],
    },

    {
        _id: 9,
        firstName: "ebtesam",
        lastName: "hesham",
        age: 21,
        salary: 7500,
        address: { city: "mansoura", street: 14, building: 3 },
        courses: ["js", "html5", "signalR", "expressjs", "bootstrap"],
    },
    {
        _id: 10,
        firstName: "badr",
        lastName: "ahmed",
        age: 22.0,
        salary: 5550.0,
        address: {
            city: "cairo",
            street: 10.0,
            building: 8.0,
        },
        courses: ["sqlserver", "mvc", "signalR", "asp.net"],
    },
    {
        _id: 2,
        firstName: "mona",
        lastName: "mohammed",
        age: 21.0,
        salary: 3600.0,
        address: {
            city: "mansoura",
            street: 20.0,
            building: 18.0,
        },
        courses: ["es6", "js", "mongodb", "expressjs"],
    },
    {
        _id: 3,
        firstName: "mazen",
        lastName: "ali",
        age: 30.0,
        salary: 7010.0,
        address: {
            city: "cairo",
            street: 10.0,
            building: 5.0,
        },
        courses: ["asp.net", "mvc", "EF"],
    },
    {
        _id: 4,
        firstName: "ebtesam",
        lastName: "ahmed",
        age: 28.0,
        salary: 6200.0,
        address: {
            city: "mansoura",
            street: 14.0,
            building: 7.0,
        },
        courses: ["js", "html5", "signalR", "expressjs", "bootstrap", "es6"],
    },
];

instructorsArray

db.employees.insertMany(instructorsArray)

db.employees.find()

db.employees.find({firstName:"badr",lastName:"ahmed"})

db.employees.find({},{firstName:1,lastName:1})

db.employees.find({},{firstName:1,lastName:1,_id:0})

db.employees.find({},{age:0})

db.employees.findOne({},{age:0})

db.employees.find({age:{$gt:21}})

db.employees.find({age: {$in:[28,30]} })


// AND
db.employees.find({firstName:"badr",lastName:"ahmed"})
db.employees.find({lastName:"badr",lastName:"ahmed"})  // ====> override "ahmed"
// OR (Logical Operator) ==> Top Level Operator
db.employees.find({ $or: [ {lastName:"ahmed"},{lastName:"hesham"} ] })

// Array Operators
db.employees.find({},{courses:1})

db.employees.find({courses:"mvc"},{courses:1})

db.employees.find({courses:"EF",courses:"mvc"},{courses:1}) // ==> override "mvc"
db.employees.find({courses:"mvc",courses:"EF"},{courses:1}) // ==> override "EF"

db.employees.find({courses:{$all:["mvc","EF"]}},{courses:1})
db.employees.find({courses:{$size:3}},{courses:1})

// Element Operators: $esists , $type


db.employees.insertOne({_id:100,firstName:"karim"})
db.employees.insertOne({_id:101,lastName:"karim"})

// $exists

db.employees.find({})
db.employees.find({ firstName:{$exists:true} , lastName:{$exists:true} })

db.employees.find({},{firstName:1,lastName:1})
db.employees.find( { firstName:{$exists:true} , lastName:{$exists:true} } , {firstName:1,lastName:1} )


// $type

db.employees.insertOne({_id:102,salary:"2000"})

db.employees.find({_id:102})

db.employees.find({ salary:{$type:"number"} })

db.employees.find({ salary:{$type:"string"} })

// Embedded Object

db.employees.find({"address.city":"mansoura"},{address:1})

/**********************************************************************************************************
                                            UPDATE COMMANDS
                                            updateOne , updateMany
 db.collection.updateMany( {condition} , {update statements} , {options} )

**********************************************************************************************************/
db.employees.find({})

db.employees.updateMany(
    // condition
    {
         _id : 3  
         // $or:[{_id:6},{_id:7 }]
        
    },
    // update statements
    {
        // 1- Change Value for Existing Field
        // $set:{age:37,lastName:"Honosh"}
        // $set:{Gender:"F"}
        
        // 2- Adding New Field
        // $set:{Gender:"M"}
        
        // 3- Rename Field Name
        // $rename:{Gender:"F"}
        
        // 4- Remove Field
        // $unset:{F:""}
        
        // 5-Array
        //========
        // Adding even if existing
        // $push:{courses:"Javascript"}
        
        // Adding if not existing
        // $addToSet:{courses:"MongoDB"}
        
        // Removing all matched items
        // $pull:{courses:"Javascript"}
        
        // Setting Value at a Specified Index
        // $set:{"courses.3":"Javascript"}
    }
)
/**********************************************************************************************************
                                            DELETE COMMANDS
                                            deleteOne , deleteMany
 db.collection.deleteMany( {condition} )

**********************************************************************************************************/
