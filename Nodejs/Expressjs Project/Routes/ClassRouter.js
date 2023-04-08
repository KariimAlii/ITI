const express = require("express");
const router = express.Router();
const controller = require("../Controllers/ClassController");

router
    .route("/classes")
    .get(
        controller.dataValidation,
        controller.authorization,
        controller.getAllClasses
    )
    .post(
        controller.dataValidation,
        controller.authorization,
        controller.addClass
    )
    .patch(
        controller.dataValidation,
        controller.authorization,
        controller.updateClass
    )
    .put(
        controller.dataValidation,
        controller.authorization,
        controller.updateClass
    )
    .delete(
        controller.dataValidation,
        controller.authorization,
        controller.deleteClass
    );

module.exports = router;
