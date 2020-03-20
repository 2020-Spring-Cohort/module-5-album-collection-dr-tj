export default function Artists(artists) {
    return `
        <ul>
            ${artists.map(artist => {
                return `
                    <h5>${artist.name}</h5>
                `
            }).join("")}
        </ul>
    `
}