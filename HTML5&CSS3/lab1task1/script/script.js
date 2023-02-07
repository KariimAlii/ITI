const video = document.querySelector("video");
const videoRange = document.querySelector(".video-range");
const volumeRange = document.querySelector(".volume-range");
const speedRange = document.querySelector(".speed-range");
const volumeIcon = document.querySelector(".volume");
const playerIcon = document.querySelector(".player")
let actualSeconds = 0;
let actualSecondsElement = document.querySelector('.actual-seconds');
let actualMinutes = 0;
let actualMinutesElement = document.querySelector('.actual-minutes');
playerIcon.addEventListener("click", () => {
    if (video.paused) {
        video.play();
        playerIcon.classList.remove("fa-circle-play");
        playerIcon.classList.add("fa-circle-pause");
    } else {
        video.pause();
        playerIcon.classList.remove("fa-circle-pause");
        playerIcon.classList.add("fa-circle-play");
    }
});

video.addEventListener("timeupdate", () => {
    adjustTime();
});
function adjustTime() {
    let ratio = video.currentTime / video.duration;
    actualMinutes = Math.floor((video.currentTime / 60)).toFixed();
    actualMinutesElement.textContent = actualMinutes;
    actualSeconds = (video.currentTime % 60).toFixed();
    actualSecondsElement.textContent = actualSeconds;
    document.querySelector(".video-range").value = ratio;
}

document.querySelector(".backward").addEventListener("click", () => {
    video.currentTime -= 5;
});
document.querySelector(".forward").addEventListener("click", () => {
    video.currentTime += 5;
});
document.querySelector(".repeat").addEventListener("click", () => {
    video.currentTime = 0;
});
document.querySelector(".faster-speed").addEventListener("click", () => {
    video.playbackRate += 0.25;
    speedRange.value = video.playbackRate;
    document.getElementById("speed-label").textContent = video.playbackRate;
});
document.querySelector(".slower-speed").addEventListener("click", () => {
    if (video.playbackRate >= 0.5) video.playbackRate -= 0.25;
    speedRange.value = video.playbackRate;
    document.getElementById("speed-label").textContent = video.playbackRate;
});
document.querySelector(".expand").addEventListener("click", () => {
    document.querySelector(".video-container").classList.toggle("fullscreen");
    document.querySelector(".expand").classList.toggle("fa-expand");
    document.querySelector(".expand").classList.toggle("fa-compress");

});

document.querySelector(".sliders").addEventListener("click", () => {
    speedRange.classList.toggle("display-block");
    document.getElementById("speed-label").classList.toggle("display-inline");
});
videoRange.addEventListener("change", () => {
    video.currentTime = videoRange.value * video.duration;
    adjustTime();
});
volumeRange.addEventListener("change", () => {
    adjustVolume();
});
speedRange.addEventListener("change", () => {
    video.playbackRate = speedRange.value;
    document.getElementById("speed-label").textContent = video.playbackRate;
});

document.querySelector(".volume-mute").addEventListener("click", () => {
    if (video.volume == 0) volumeRange.value = 1;
    else volumeRange.value = 0;
    adjustVolume();
    document.getElementById("volume-label").textContent =
        video.volume * 100 + "%";
    
});
document.querySelector(".volume").addEventListener("click", () => {
    volumeRange.classList.toggle("display-inline");
    document.getElementById("volume-label").classList.toggle("display-inline");
});
function adjustVolume()  {
    video.volume = volumeRange.value;
    document.getElementById("volume-label").textContent =
        video.volume * 100 + "%";
    if (video.volume > 0 && video.volume < 0.4) {
        volumeIcon.classList.remove("fa-volume-high");
        volumeIcon.classList.remove("fa-volume-off");
        volumeIcon.classList.add("fa-volume-low");
    } else if (video.volume == 0) {
        volumeIcon.classList.remove("fa-volume-high");
        volumeIcon.classList.remove("fa-volume-low");
        volumeIcon.classList.add("fa-volume-off");
    } else {
        volumeIcon.classList.remove("fa-volume-low");
        volumeIcon.classList.remove("fa-volume-off");
        volumeIcon.classList.add("fa-volume-high");
    }
}
