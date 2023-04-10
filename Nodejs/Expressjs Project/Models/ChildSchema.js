//! Child Data: _id(Number), fullName, age , level (PreKG,KG1,KG2), address (city,street and building)
const mongoose = require("mongoose");

//* 1- Defining Schema

const childSchema = new mongoose.Schema(
    {
        _id: Number,
        fullName: { type: String, required: true },
        age: {
            type: Number,
            min: [4, "Must be at least 4 , got {VALUE}"],
            max: [6, "Must be at most 6 , got {VALUE}"],
        },
        level: {
            type: String,
            enum: {
                values: ["PreKG", "KG1", "KG2"],
                message:
                    "{VALUE} is not supported ! We only Support PreKG , KG1 , KG2",
            }
        },
        address: {
            // _id: {id:false}, //! to disable auto-generation of ObjectID [Embedded Document]
            street: { type: String, required: true },
            building: { type: Number, required: true },
        },
    },
    { collection: "children" }
)

//* 2- Mapping (Setter)

module.exports = mongoose.model("Child", childSchema);
