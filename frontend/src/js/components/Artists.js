export default function Artists(artists) {
    return `
        <ul>
            ${artists.map(artist => {
                return `
                    <h4>${artist.name}</h4>
                `
            }).join("")}
        </ul>
    `
}