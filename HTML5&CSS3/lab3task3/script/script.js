const userName = document.querySelector("#name");
const password = document.querySelector("#password");
const welcomeHeader = document.querySelector(".welcome-header");
const info = document.querySelector(".info");

document.querySelector("form").addEventListener("submit", function (e) {
    e.preventDefault();
    localStorage.setItem("userName", userName.value);
    console.log("localStorage:", localStorage);
    sessionStorage.setItem("password", password.value);
    console.log("sessionStorage:", sessionStorage);

    welcomeHeader.textContent = `Hi ${localStorage.getItem("userName")}`;
    info.textContent = `Your Password is ${sessionStorage.getItem("password")}`;

    document.querySelector(".container").style.display = "block";
});
