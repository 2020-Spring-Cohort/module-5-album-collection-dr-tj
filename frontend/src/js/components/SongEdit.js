export default function SongEdit(song){
    return `
        <section class="song-content">
            <h3>${song.title}</h3>
        </section>
        <section class="update-song">
            <input class="update-song__title" type="text" value="${song.title}">
            <input class="update-song__duration" type="text" value="${song.duration}">
            <input class="update-song__id" type="hidden" value="${song.id}">
            <input class="update-song__album-id" type="hidden" value="${song.albumId}">
            <button class="update-song__submit">Save Changes</button>
        </section>
    `
}