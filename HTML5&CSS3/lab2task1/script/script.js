const can = document.getElementById("can");
const ctx = can.getContext("2d");


ctx.beginPath();
ctx.moveTo(100,500);
ctx.lineTo(300,500);
ctx.lineTo(300,100);
ctx.lineTo(100,500);
ctx.lineWidth = 5;
ctx.strokeStyle = "black";
ctx.fillStyle = "red";
ctx.fill();
ctx.stroke();
ctx.closePath();


ctx.font = "italic 3rem Arial ";
ctx.fillText("a", 200,530);
ctx.fillText("b", 320,300);
ctx.fillText("c", 170,300);
