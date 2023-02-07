
let latitude;
let longitude


function showLoc(e) {
    console.log(e.coords.latitude);
    console.log(e.coords.longitude);
    latitude = e.coords.latitude;
    longitude = e.coords.longitude;
    // location.assign(`https://www.google.com/maps/@${latitude},${longitude},60z`);
    // location.assign(`https://maps.google.com/maps?q=${latitude},${longitude}`);

    mapboxgl.accessToken = 'pk.eyJ1Ijoia2FyaWltYWxpaSIsImEiOiJjbDVuZWd4a3IwOGZ4M2lvZTh5d3dkZ2ZmIn0.qyluLvWLbQ_5BTySRzTRDg';
    const map = new mapboxgl.Map({
    container: 'map', // container ID
    style: 'mapbox://styles/mapbox/streets-v12',
    center: [longitude, latitude],
    zoom: 9,
    });
    const marker = new mapboxgl.Marker({color:"rgb(255,0,0)"})
    .setLngLat([longitude, latitude])
    .addTo(map);
}
function showError(x) {
    switch(x.key) {
        case 0:
            console.log(x.message);
            console.log("Unknown Error!");
            break;
        case 1:
            console.log(x.message);
            console.log("Position Unavailable!");
            break;
        case 2:
            console.log(x.message);
            console.log("Permission Denied!");
            break;
        case 3:
            console.log(x.message);
            console.log("Timeout!");
            break;
    }
}
const options = {
    timeout:0,
    enableHighAccuracy:true
}
document.querySelector(".location-btn").addEventListener("click",getLocation);
function getLocation() {
    navigator.geolocation.getCurrentPosition(showLoc)
    // navigator.geolocation.getCurrentPosition(showLoc,showError,options)
}





