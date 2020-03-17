export default function Artists(artists) {
    return `
        <ul>
            ${artists.map(artist => {
                return `
                <li>
                    <h4>${artist}</h4>
                </li>
                `
            }).join("")}
        </ul>
    `
}