
//! Importing NPM Packages

const express = require("express");
const morgan = require("morgan");
const mongoose = require("mongoose");

//! Importing Routes

const TeacherRouter = require("./Routes/TeacherRouter");
const ChildRouter = require("./Routes/ChildRouter");
const ClassRouter = require("./Routes/ClassRouter");
const LoginRouter = require("./Routes/AuthenticationRouter");

//! Importing Middlewares
const authMW = require("./Middlewares/authMW")

const app = express();
const authorized = true;

//! 1 - Logging Middleware
app.use(morgan(":method :url :response-time"));

//! 2 - Authorization Middleware
app.use((request, response, next) => {
    if (authorized) next();
    // else throw new Error("Not Authorized");
    else next(new Error("Not Authorized"));
});

//! 3- Body Parser
app.use(express.json());
// app.use(require("body-parser").json());

//! 4- Routes
app.use(LoginRouter);
app.use(TeacherRouter);
app.use(ChildRouter);
app.use(ClassRouter);

//! 5 - Not Found Middleware
app.use((request, response, next) => {
    response.status(404).json({ message: "Not Found" });
});

//! 6 - Error Middleware
app.use((error, request, response, next) => {
    // console.log(error)
    response.status(500).json({ message: `Exception Occured: ${error}` });
});

//! 7- server listening
mongoose
    .connect("mongodb://127.0.0.1:27017/NurserySystem")
    .then(() => {
        console.log("DB Connected ..");
        app.listen(process.env.PORT || 8080, () => {
            console.log("Listening on Port 8080");
        });
    })
    .catch((error) => console.log(`DB ERROR: ${error}`));

// try {
//     await mongoose.connect("mongodb://127.0.0.1:27017/ITI");
//     app.listen(process.env.PORT || 8080, () => {
//         console.log("Listening on Port 8080");
//     })
// } catch (error) {
//     console.log(`DB ERROR: ${error}`);
// }
