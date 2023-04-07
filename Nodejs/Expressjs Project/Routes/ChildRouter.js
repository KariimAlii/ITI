const express = require("express");
const router = express.Router();

router.route("/childs")
    .get((request,response) => {
        response.json({message:"Get ~ All Childs"});
    })
    .post((request,response) => {
        response.json({message:"Post ~ Child"});
    })
    .patch((request,response) => {
        response.json({message:"Patch ~ Child"});
    })
    .put((request,response) => {
        response.json({message:"Put ~ Child"});
    })
    .delete((request,response) => {
        response.json({message:"Delete ~ Child"});
    })

module.exports = router;