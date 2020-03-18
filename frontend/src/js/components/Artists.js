export default function Artists(artists) {
    return `
        <ul>
            ${artists.map(artist => {
                return `
                    <h4>${artist}</h4>
                `
            }).join("")}
        </ul>
    `
}