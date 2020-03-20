export default function Artists(artists) {
    return `
        <ul>
            ${artists.map(artist => {
                return `
                    <h5>${artist.name}</h5>
                    
                `
            }).join("")}
        </ul>

    <section class="add-artist">
        <input class="add-artist__artist-name" type="text" placeholder="Add an artist name">
        <input class="add-artist__artist-genre" type="text" placeholder="Add a genre">
        <button class="add-artist__submit">Add an artist</button>
    </section>
    `
}