const Class = require("../Models/ClassSchema");
const Teacher = require("../Models/TeacherSchema");
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
module.exports.getAllClasses = async (request, response,next) => {
    try {
        const data = await Class
                            .find({})
                            .populate({path:"supervisor",select:{_id:0,fullName:1}})
                            .populate({path:"childrenIds",select:{fullName:1,age:1}});
        response.status(200).json({ data });
    } catch (error) {
        next (error)
    }
};
module.exports.addClass = async (request, response,next) => {
    try {
        const {name,supervisorFullName,childrenIds} = request.body;
        const supervisor = await Teacher.findOne({fullName:supervisorFullName});
        console.log('supervisor: ', supervisor);
        let childrenObjects = [];
        for (let i = 0;i < childrenIds.length;i++) {
            let childObject = await Child.findById(childrenIds[i]);
            childrenObjects.push(childObject);
        }
        console.log('childrenObjects:',childrenObjects)
        let sequenceValue = await findSequence("Class Counter");
        const newClass = new Class({
            _id:sequenceValue,
            name,
            supervisor,
            childrenIds : childrenObjects
        })
        const data = await newClass.save();
        response.status(201).json({ newClass: data });
    } catch (error) {
        console.log(error);
        next(error)
    }
    
};
module.exports.updateClass = (request, response) => {
    response.status(201).json({ message: "Update ~ Class" });
};
module.exports.deleteClass = (request, response) => {
    response.status(201).json({ message: "Delete ~ Class" });
};