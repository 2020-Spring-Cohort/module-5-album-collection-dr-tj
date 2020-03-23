//import things
import Sidebar from "./components/Sidebar";
import Header from "./components/Header";
import Footer from "./components/Footer";
import Artists from "./components/Artists";
import ArtistEdit from "./components/ArtistEdit";
import Albums from "./components/Albums";
import apiActions from "./api/apiActions";


export default pageBuild;

function pageBuild() {
    sidebar();
    footer();
    header();
    navArtists();
    navAlbums();
}

function header() {
    const header = document.querySelector("#header");
    header.innerHTML = Header();
}

function sidebar() {
    const sidebar = document.querySelector(".sidebar-div");
    sidebar.innerHTML = Sidebar();
}

function footer() {
    const footer = document.querySelector("#footer");
    footer.innerHTML = Footer();
}

function navArtists() {
    const artistsNavButton = document.querySelector(".nav_artists");
    const mainDiv = document.querySelector(".main-div");

    artistsNavButton.addEventListener("click", function () {
        apiActions.getRequest("https://localhost:44313/api/Artist",
            artists => {
                console.log(artists);
                mainDiv.innerHTML = Artists(artists);
            }
        )
    });

    mainDiv.addEventListener("click", function () {
        if (event.target.classList.contains("add-artist__submit")) {
            const artistName = event.target.parentElement.querySelector(".add-artist__artist-name").value;
            const artistGenre = event.target.parentElement.querySelector(".add-artist__artist-genre").value;
            console.log(artistName);

            var requestBody = {
                Name: artistName,
                Genre: artistGenre
            }

            apiActions.postRequest(
                "https://localhost:44313/api/Artist",
                requestBody,
                artists => {
                    console.log(artists);
                    mainDiv.innerHTML = Artists(artists);
                }
            )
        }
    });

    mainDiv.addEventListener("click", function () {
        if (event.target.classList.contains("delete-artist__submit")) {
            const artistId = event.target.parentElement.querySelector(".artist-id").value;
            console.log(artistId);

            apiActions.deleteRequest(
                `https://localhost:44313/api/Artist/${artistId}`,
                artists => {
                    mainDiv.innerHTML = Artists(artists);
                }
            )
        }
    });

    mainDiv.addEventListener("click", function () {
        if (event.target.classList.contains("edit-artist__submit")) {
            const artistId = event.target.parentElement.querySelector(".artist-id").value;
            console.log(artistId);

            apiActions.getRequest(
                `https://localhost:44313/api/Artist/${artistId}`,
                artistEdit => {
                    mainDiv.innerHTML = ArtistEdit(artistEdit);
                }
            )
        }
    });

    mainDiv.addEventListener("click", function () {
        if (event.target.classList.contains("update-artist__submit")) {
            const artistId = event.target.parentElement.querySelector(".update-artist__id").value;
            const artistName = event.target.parentElement.querySelector(".update-artist__name").value;
            const artistGenre = event.target.parentElement.querySelector(".update-artist__genre").value;

            const artistData = {
                Id: artistId,
                Name: artistName,
                Genre: artistGenre
            }
            console.log(artistData);
            apiActions.putRequest(
                `https://localhost:44313/api/Artist/${artistId}`,
                artistData,
                artists => {
                    mainDiv.innerHTML = Artists(artists);
                }
            )
        }
    });
}

function navAlbums(){
    const albumsNavButton = document.querySelector(".nav_albums");
    const mainDiv = document.querySelector(".main-div");

    albumsNavButton.addEventListener("click", function () {
        apiActions.getRequest("https://localhost:44313/api/Album",
            albums => {
                console.log(albums);
                mainDiv.innerHTML = Albums(albums);
            }
        )
    });

    mainDiv.addEventListener("click", function(){
        if(event.target.classList.contains("add-album__submit")){
            const albumTitle = event.target.parentElement.querySelector(".add-album__album-title").value;
            const albumRecordLabel = event.target.parentElement.querySelector(".add-album__album-record-label").value;
            const albumArtistId = event.target.parentElement.querySelector(".add-album__artist-id").value;

            console.log(albumArtistId);

            var requestBody = {
                Title: albumTitle,
                RecordLabel: albumRecordLabel,
                ArtistId: albumArtistId
            }
            apiActions.postRequest(
                "https://localhost:44313/api/Album",
                requestBody,
                albums => {
                    console.log(albums);
                    mainDiv.innerHTML = Albums(albums);
                }
            )
        }
    });

    mainDiv.addEventListener("click", function () {
        if (event.target.classList.contains("delete-album__submit")) {
            const albumId = event.target.parentElement.querySelector(".album-id").value;
            console.log(albumId);

            apiActions.deleteRequest(
                `https://localhost:44313/api/Album/${albumId}`,
                albums => {
                    mainDiv.innerHTML = Albums(albums);
                }
            )
        }
    });
}