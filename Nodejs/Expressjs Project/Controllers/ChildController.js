module.exports.dataValidation = (request, response, next) => {
    console.log("Data Validation");
    next();
};
module.exports.authorization = (request, response, next) => {
    console.log("Authorization");
    next();
};
module.exports.getAllChilds = (request, response) => {
    response.status(200).json({ message: "Get ~ All Childs" });
};
module.exports.addChild = (request, response) => {
    response.status(201).json({ message: "Post ~ Child" });
};
module.exports.updateChild = (request, response) => {
    response.status(201).json({ message: "Update ~ Child" });
};
module.exports.deleteChild = (request, response) => {
    response.status(201).json({ message: "Delete ~ Child" });
};