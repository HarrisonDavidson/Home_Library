const url = "https://localhost:7270/api/movies/";

const button = document.querySelector("#run-button");
button.addEventListener("click", () => {
    getAllMovies()
        .then(movies => {
            console.log(movies);
        })
});

function getAllMovies() {
    return fetch(url).then(resp => resp.json());
}