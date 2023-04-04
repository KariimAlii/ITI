// Use fetch method with url https://jsonplaceholder.typicode.com/users
// To get data asynchronously from the API and display the Result on HTML table
// a- You don't know columns' names in code so keep your code generic
// b- Display the following Coulmns in table
//     1- UserName
//     2- email
//     3- Company Name
//     4- Address geo (address GeoLocation)
//     5- show users posts' titles as ul list in this column
const getUsers = async function () {
    try {
        let responce = await fetch(
            "https://jsonplaceholder.typicode.com/users"
        );
        let data = await responce.json();
        return data;
    } catch (error) {}
};
const getUserPosts = async function (userId) {
    try {
        let responce = await fetch(
            `https://jsonplaceholder.typicode.com/users/${userId}/posts`
        );
        let data = await responce.json();
        return data;
    } catch (error) {}
};
const btn = document.querySelector("a");
const table = document.querySelector(".mytable");
btn.addEventListener("click", async () => {
    const users = await getUsers();
    for (const user of users) {
        const posts = await getUserPosts(user.id);
        // console.log(posts) // ==> post.body , post.title
        for (const post of posts) {
            table.innerHTML += `<tr>
                    <td>${user.username}</td>
                    <td>${user.email}</td>
                    <td>${user.company.name}</td>
                    <td>lat : ${user.address.geo.lat} , long : ${user.address.geo.lng}</td>
                    <td>${post.id}</td>
                    <td>${post.title}</td>
                </tr>`;
        }
    }
});
