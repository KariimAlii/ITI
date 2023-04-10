const express = require("express");
const controller = require("../Controllers/AuthenticationController");
const router = express.Router();

router.post("/login", controller.login);

module.exports = router;