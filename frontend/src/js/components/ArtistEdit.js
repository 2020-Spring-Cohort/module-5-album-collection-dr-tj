export default function ArtistEdit(artist) {
    return `
        <section class="artist-content">
            <h3>${artist.name}</h3>
        </section>
    
        <section class="update-artist">
            <input class="update-artist__name" type="text" value="${artist.name}">
            <input class="update-artist__genre" type="text" value="${artist.genre}">
            <input class="update-artist__id" type="hidden" value="${artist.id}">
            <button class="update-artist__submit">Save Changes</button>
        </section>
    `;
}