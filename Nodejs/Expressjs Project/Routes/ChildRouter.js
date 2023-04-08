const express = require("express");
const router = express.Router();
const controller = require("../Controllers/ChildController");

router
    .route("/childs")
    .get(
        controller.dataValidation,
        controller.authorization,
        controller.getAllChilds
    )
    .post(
        controller.dataValidation,
        controller.authorization,
        controller.addChild
    )
    .patch(
        controller.dataValidation,
        controller.authorization,
        controller.updateChild
    )
    .put(
        controller.dataValidation,
        controller.authorization,
        controller.updateChild
    )
    .delete(
        controller.dataValidation,
        controller.authorization,
        controller.deleteChild
    );

module.exports = router;
