module.exports.dataValidation = (request, response, next) => {
    console.log("Data Validation");
    next();
};
module.exports.authorization = (request, response, next) => {
    console.log("Authorization");
    next();
};
module.exports.getAllTeachers = (request, response) => {
    response.status(200).json({ message: "Get ~ All Teachers" });
};
module.exports.addTeacher = (request, response) => {
    console.log("request.params: ", request.params);
    console.log("request.query: ", request.query);
    console.log('request.body: ', request.body);
    response.status(201).json({ message: "Post ~ Teacher" });
};
module.exports.updateTeacher = (request, response) => {
    response.status(201).json({ message: "Update ~ Teacher" });
};
module.exports.deleteTeacher = (request, response) => {
    response.status(201).json({ message: "Delete ~ Teacher" });
};
module.exports.getTeacher = (request, response) => {
    console.log("request.params: ", request.params);
    console.log("request.query.id: ", request.query.id);
    response.status(201).json({ message: "one Teacher" });
};
