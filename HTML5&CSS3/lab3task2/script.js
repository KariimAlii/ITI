function random(x, y) {
    return x + Math.floor(Math.random() * (y - x));
}
let worker = new Worker("worker.js");
const workerBtn = document.querySelector(".worker-btn");
const backgroundBtn = document.querySelector(".background-btn");
workerBtn.onclick = function () {
    worker.postMessage("");
};

backgroundBtn.onclick = function () {
    let red = random(0,255);
    let green = random(0,255);
    let blue = random(0,255);
    document.querySelector('body').style.backgroundColor = `rgb(${red},${green},${blue})`;
}
worker.onmessage = function (message) {
    alert(message.data);
};

