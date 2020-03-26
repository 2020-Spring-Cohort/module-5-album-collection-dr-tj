export default function Songs(songs) {
    return `
        <div class="song-grid-container">
            ${songs.map(song => {
                return `
                    <div class="song-item-container">
                        <h6 class="specific-song">${song.title} on ${song.album.title}. Duration: ${song.duration}</h6>
                        <button class="edit-song__submit">Edit</button>
                        <button class="delete-song__submit">Delete</button>
                        <input class="song-id" type="hidden" value="${song.id}">
                    </div>
                `
            }).join("")}
        </div>

    <section class="add-song">
        <button class="add-song__button">Click to add song</button>


    </section>
    `
}