export default function Albums(albums) {
    return `
        <div class="album-grid-container">
            ${albums.map(album => {
                return `
                    <div class="album-item-container">
                        <h6 class="specific-album">${album.title} by ${album.artist.name}</h6>
                        <button class="edit-album__submit">Edit</button>
                        <button class="delete-album__submit">Delete</button>
                        <input class="album-id" type="hidden" value="${album.id}">
                    </div>
                `
            }).join("")}
        </div>

    <section class="add-album">
        <button class="add-album__button">Click to add album</button>


    </section>
    `
}