const can = document.getElementById("can");
const ctx = can.getContext("2d");
let x = 0;
let y = 0;
ctx.beginPath();
ctx.lineWidth = 5;
ctx.strokeStyle = "black";
ctx.moveTo(x,y);
const timerID = setInterval(() => {
    ctx.lineTo(x,y);
    ctx.stroke();
    x++;
    y++;
    if (x === 400) {
        clearInterval(timerID);
        document.querySelector(".popup").style.display = "flex";
    }
},5)
ctx.closePath();


