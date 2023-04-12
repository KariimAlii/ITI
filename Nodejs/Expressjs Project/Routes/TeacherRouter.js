const express = require("express");
const router = express.Router();
const controller = require("../Controllers/TeacherController");
const {checkAdmin , checkTeacher} = require("../Middlewares/authMW")
router
    .route("/teachers")
    .all(checkAdmin)
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
    .all(checkTeacher)
    .get(controller.getTeacher)
    .delete(controller.deleteTeacher);

module.exports = router;
