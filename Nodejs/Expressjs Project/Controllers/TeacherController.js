const bcrypt = require("bcrypt");
const mongoose = require("mongoose");
const Teacher = require("../Models/TeacherSchema");

module.exports.dataValidation = (request, response, next) => {
    console.log("Data Validation");
    next();
};
module.exports.authorization = (request, response, next) => {
    console.log("Authorization");
    next();
};
module.exports.getAllTeachers = async (request, response, next) => {
    try {
        const data = await Teacher.find({});
        response.status(200).json({ data });
    } catch (error) {
        next(error);
    }
};
module.exports.addTeacher = async (request, response, next) => {
    try {
        // console.log("request.params: ", request.params);
        // console.log("request.query: ", request.query);
        console.log("request.body: ", request.body);

        const { fullName, email, password, image } = request.body;
        const saltRounds = 13;
        const salt = await bcrypt.genSalt(saltRounds);
        const hash = await bcrypt.hash(password, salt);

        let newTeacher = new Teacher({
            fullName,
            email,
            password: hash,
            image,
        });
        const data = await newTeacher.save();
        response.status(201).json({ newTeacher: data });
    } catch (error) {
        next(error);
    }
};
module.exports.updateTeacher = async (request, response, next) => {
    try {
        let { _id, fullName, email } = request.body;
        _id = new mongoose.Types.ObjectId(_id);
        const data = await Teacher.updateOne(
            { _id },
            { fullName, email }
        );
        response.status(201).json({ message:`Updated ${data.modifiedCount} Records` });
    } catch (error) {
        next(error);
    }
};
module.exports.deleteTeacher = async (request, response,next) => {
    try {
        let { id } = request.params;
        _id = new mongoose.Types.ObjectId(id);
        const data = await Teacher.deleteOne({ _id });
        response.status(201).json({ message:`Deleted ${data.deletedCount} Records` });
    } catch (error) {
        next(error);
    }

};
module.exports.getTeacher = async (request, response, next) => {
    try {
        // const data = await Teacher.findById(id); // you can use the string id directly
        const id = new mongoose.Types.ObjectId(request.params.id);
        const data = await Teacher.findOne({ _id: id }); //  you have to convert the string id to object id
        if (!data) throw new Error("Teacher doesn't exist.."); // if (data == null) === if (!data)
        response.status(200).json({ data });
    } catch (error) {
        next(error);
    }
};
