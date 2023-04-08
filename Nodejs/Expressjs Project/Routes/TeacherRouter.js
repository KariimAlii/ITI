const express = require("express");
const router = express.Router();
const controller = require("../Controllers/TeacherController");
router
    .route("/teachers")
    .get(
        controller.dataValidation,
        controller.authorization,
        controller.getAllTeachers
    )
    .post(
        controller.dataValidation,
        controller.authorization,
        controller.addTeacher
    )
    .patch(
        controller.dataValidation,
        controller.authorization,
        controller.updateTeacher
    )
    .put(
        controller.dataValidation,
        controller.authorization,
        controller.updateTeacher
    );

router
    .route("/teachers/:id")
    .get(controller.getTeacher)
    .delete(controller.deleteTeacher);

module.exports = router;
