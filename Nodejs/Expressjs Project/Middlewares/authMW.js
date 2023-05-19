const jwt = require("jsonwebtoken");
module.exports = (request , response , next) => {
    try {
        //! search for the token
        const token = request.get("authorization").split(" ")[1];
        const decodedToken = jwt.verify(token,"Tamatem")
        request.decodedToken = decodedToken;
        next();
    }
    catch (error) {
        next (new Error ("Not Authenticated"))
    }
}
module.exports.checkAdmin = (request,responce,next) => {
    if (request.decodedToken.role === "admin") {
        next();
    } else {
        next(new Error("Not Authorized"));
    }
}
module.exports.checkTeacher = (request,responce,next) => {
    if (request.decodedToken.role === "teacher") {
        next();
    } else {
        next(new Error("Not Authorized"))
    }
}