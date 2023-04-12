const mongoose = require("mongoose");
const jwt = require("jsonwebtoken");
const bcrypt = require("bcrypt");
require("dotenv").config();
const Teacher = require("../Models/TeacherSchema");

module.exports.login = async function (request,response,next) {
    try {
        const {email , password} = request.body;
        const user = await Teacher.findOne({email});
        if (!user) throw new Error("Email Not Found!")
        const hash = user.password;
        console.log(hash)
        const isPasswordValid = await bcrypt.compare(`${password}`,hash);
        if (!isPasswordValid) throw new Error ("Password Wrong!!")
        if (email === "k@gmail.com") {
            const token = jwt.sign({
                id:user._id,
                role:"admin",
                userName:user.fullName
            },process.env.Token_Encryption_Key,{expiresIn:"1h"})
            response.status(200).json({token})
        } 
        else {
            const token = jwt.sign({
                id:user._id,
                role:"teacher",
                userName:user.fullName
            },process.env.Token_Encryption_Key,{expiresIn:"1h"})
            response.status(200).json({token})
        }
    }
    catch (error) {
        console.log(error)
        next(error)
    }
}

//! password in DB 123456