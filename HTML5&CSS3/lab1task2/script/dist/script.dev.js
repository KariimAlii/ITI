"use strict";

document.querySelectorAll('.color-input').forEach(function (input, index) {
  input.addEventListener("change", function () {
    var red = document.querySelector("#red").value;
    var green = document.querySelector("#green").value;
    var blue = document.querySelector("#blue").value;
    document.querySelectorAll('label')[index].textContent = input.value;
    document.querySelector('.changing-color-text').style.color = "rgb(".concat(red, ",").concat(green, ",").concat(blue, ")");
  });
});