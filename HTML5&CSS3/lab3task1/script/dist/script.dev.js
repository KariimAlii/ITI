"use strict";

document.querySelector(".location-btn").addEventListener("click", getLocation);

function getLocation() {
  navigator.geolocation.getCurrentPosition(showLoc);
}

function showLoc(e) {
  console.log(e.coords.latitude);
  console.log(e.coords.longitude);
  var latitude = e.coords.latitude;
  var longitude = e.coords.longitude; // location.assign(`https://www.google.com/maps/@${latitude},${longitude},60z`);

  location.assign("https://maps.google.com/maps?q=".concat(latitude, ",").concat(longitude));
}