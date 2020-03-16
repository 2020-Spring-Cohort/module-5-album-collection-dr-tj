//import things
import Header from "./components/Header";
import Footer from "./components/Footer";
import Artists from "./components/Artists";
import apiActions from "./api/apiActions";


export default pageBuild();

function pageBuild(){
    header();
    footer();
    navArtists();
}

function header() {
    const header = document.querySelector("#header");
    header.innerHTML = Header();
}

function footer(){
    const footer = document.querySelector("#footer");
    footer.innerHTML = Footer();
}

function navArtists(){
    const artistsNavButton = document.querySelector(".nav_artists");
    const app = document.querySelector("#app");
    
    artistsNavButton.addEventListener("click", function(){
        apiActions.getRequest("https://localhost:44313/api/Artist",
        artists => {
            console.log(artists);
            app.innerHTML = Artists(artists);
        }
        )
    });
}