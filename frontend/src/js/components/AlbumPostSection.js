export default function AlbumPostSection(artists){
    return `
    <input class="add-album__album-title" type="text" placeholder="Add an album title">
    <input class="add-album__album-record-label" type="text" placeholder="Add a record label">
    <select class="add-album__artist-id" type="dropdown">
    ${artists.map(artist => {
        return `
            <option value=${artist.id}>${artist.name}</option>
            `
        })}
        </select>
    <button class="add-album__submit">Save changes</button>
    `
}