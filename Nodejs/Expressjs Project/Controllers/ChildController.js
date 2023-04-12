const Child = require("../Models/ChildSchema");
const findSequence = require("../Utils/Sequence");

module.exports.dataValidation = (request, response, next) => {
    console.log("Data Validation");
    next();
};
module.exports.authorization = (request, response, next) => {
    console.log("Authorization");
    next();
};
module.exports.getAllChilds = async (request, response, next) => {
    try {
        const data = await Child.find({});
        response.status(200).json({ Childs: data });
    } catch (error) {
        next(error);
    }
};
module.exports.addChild = async (request, response,next) => {
    try {
        const {fullName,age,level,address} = request.body;
        let sequenceValue = await findSequence("Child Counter");
        const newChild = new Child({
            _id:sequenceValue,
            fullName,
            age,
            level,
            address
        })
        const data = await newChild.save();
        response.status(201).json({ data });
    } catch (error) {
        next(error);
    }
};
module.exports.updateChild = (request, response) => {
    response.status(201).json({ message: "Update ~ Child" });
};
module.exports.deleteChild = (request, response) => {
    response.status(201).json({ message: "Delete ~ Child" });
};
