module.exports.dataValidation = (request, response, next) => {
    console.log("Data Validation");
    next();
};
module.exports.authorization = (request, response, next) => {
    console.log("Authorization");
    next();
};
module.exports.getAllClasses = (request, response) => {
    response.status(200).json({ message: "Get ~ All Classes" });
};
module.exports.addClass = (request, response) => {
    response.status(201).json({ message: "Post ~ Class" });
};
module.exports.updateClass = (request, response) => {
    response.status(201).json({ message: "Update ~ Class" });
};
module.exports.deleteClass = (request, response) => {
    response.status(201).json({ message: "Delete ~ Class" });
};