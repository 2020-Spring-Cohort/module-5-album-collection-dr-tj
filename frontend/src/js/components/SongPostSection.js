export default function SongPostSection(albums){
    return `
    <input class="add-song__song-title" type="text" placeholder="Add a song title">
    <input class="add-song__song-duration" type="text" placeholder="Duration of Song">
    <select class="add-song__album-id" type="dropdown">
    ${albums.map(album => {
        return `
            <option value=${album.id}>${album.title}</option>
            `
        })}
        </select>
    <button class="add-song__submit">Save changes</button>
    `
}