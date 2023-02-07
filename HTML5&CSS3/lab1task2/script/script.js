document.querySelectorAll('.color-input').forEach((input,index) => {
    input.addEventListener("change",() => {
        const red = document.querySelector("#red").value;
        const green = document.querySelector("#green").value;
        const blue = document.querySelector("#blue").value;
        document.querySelectorAll('label')[index].textContent = input.value;
        document.querySelector('.changing-color-text').style.color = `rgb(${red},${green},${blue})`;
    })

})