//! teacher Data: _id(objectID), fullname,password, email , image (which is string)

const mongoose = require("mongoose");
const ObjectId = mongoose.Schema.Types.ObjectId;
const emailValidator = function (email) {
    const emailRegex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    return emailRegex.test(email);
};

//* 1- Generate Schema for Teacher

const teacherSchema = new mongoose.Schema({
    _id: {
        type: ObjectId,
        required: true,
        auto: true,
    },
    fullName: { type: String, required: true , unique:true},
    email: {
        type: String,
        unique: true,
        required: "Email Address is required",
        validate: [emailValidator, "Please Fill a Valid Email Address"],
    },
    password: { type: String, required: true },
    image: { type: String, required: true },
});

//* 2- Mapping
//* Setter
mongoose.model("Teacher", teacherSchema);

//* 3- Export the Getter
module.exports = mongoose.model("Teacher");

//! you can set & export in one step
// module.exports = mongoose.model("Teacher",teacherSchema);
