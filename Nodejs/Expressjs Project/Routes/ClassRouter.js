const express = require("express");
const router = express.Router();

router
    .route("/classes")
    .get((request, response) => {
        response.json({ message: "Get ~ All Classes" });
    })
    .post((request, response) => {
        response.json({ message: "Post ~ Class" });
    })
    .patch((request, response) => {
        response.json({ message: "Patch ~ Class" });
    })
    .put((request, response) => {
        response.json({ message: "Put ~ Class" });
    })
    .delete((request, response) => {
        response.json({ message: "Delete ~ Class" });
    });

module.exports = router;
