const express = require("express");
const router = express.Router();

router.route("/teachers")
    .get((request,response) => {
        response.json({message:"Get ~ All Teachers"});
    })
    .post((request,response) => {
        response.json({message:"Post ~ Teacher"});
    })
    .patch((request,response) => {
        response.json({message:"Patch ~ Teacher"});
    })
    .put((request,response) => {
        response.json({message:"Put ~ Teacher"});
    })
    .delete((request,response) => {
        response.json({message:"Delete ~ Teacher"});
    })

module.exports = router;