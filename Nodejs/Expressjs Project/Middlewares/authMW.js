const jwt = require("jsonwebtoken");
module.exports = (request , response , next) => {
    try {
        //! search for the token
        // console.log('request: ', request);
        // console.log(request.get("authorization"))
        const token = request.get("authorization").split(" ")[1];
        // console.log('token:',token)
        const decodedToken = jwt.verify(token,"Tamatem")
        console.log('decodedToken: ', decodedToken);
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