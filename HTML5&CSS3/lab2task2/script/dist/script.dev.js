"use strict";

var can = document.getElementById("can");
var ctx = can.getContext("2d");
var x = 0;
var y = 0;
ctx.beginPath();
ctx.lineWidth = 5;
ctx.strokeStyle = "black";
ctx.moveTo(x, y);
var timerID = setInterval(function () {
  ctx.lineTo(x, y);
  ctx.stroke();
  x++;
  y++;

  if (x === 400) {
    clearInterval(timerID);
    document.querySelector(".popup").style.display = "flex";
  }
}, 5);
ctx.closePath();