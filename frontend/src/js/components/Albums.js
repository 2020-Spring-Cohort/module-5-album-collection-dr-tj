export default function Albums(albums) {
    return `
        <div class="album-grid-container">
            ${albums.map(album => {
                return `
                    <div class="album-item-container">
                        <h4 class="specific-album">${album.title} by ${album.artist.name}</h4>
                        <p>Label: ${album.recordLabel} </p>
                        <div>
                            <img class="album-image" src=${album.image}></img>
                        </div>
                        <button class="edit-album__submit">Edit</button>
                        <button class="delete-album__submit">Delete</button>
                        <input class="album-id" type="hidden" value="${album.id}">
                    </div>
                    <br>
                `
            }).join("")}
        </div>

    <section class="add-album">
        <button class="add-album__button">Click to add album</button>


    </section>
    `
}