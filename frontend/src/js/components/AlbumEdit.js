export default function AlbumEdit(album){
    return `
        <section class="album-content">
            <h3>${album.title}</h3>
        </section>
        <section class="update-album">
            <input class="update-album__title" type="text" value="${album.title}">
            <input class="update-album__recordLabel" type="text" value="${album.recordLabel}">
            <input class="update-album__id" type="hidden" value="${album.id}">
            <button class="update-album__submit">Save Changes</button>
        </section>
    `
}