export default function Artists(artists) {
    return `
        <div class="artist-grid-container">
            ${artists.map(artist => {
                return `
                    <div class="artist-item-container">
                        <h4 class="specific-artist">${artist.name}</h4>
                        <p>Genre: ${artist.genre}<p>
                        <div>
                            <img class="artist-image" src=${artist.image}></img>
                        </div>    
                        <button class="edit-artist__submit">Edit</button>
                        <button class="delete-artist__submit">Delete</button>
                        <input class="artist-id" type="hidden" value="${artist.id}">
                    </div>
                    <br>
                `
            }).join("")}
        </div>

    <section class="add-artist">
        <input class="add-artist__artist-name" type="text" placeholder="Add an artist name">
        <input class="add-artist__artist-genre" type="text" placeholder="Add a genre">
        <button class="add-artist__submit">Add an artist</button>
    </section>
    `
}