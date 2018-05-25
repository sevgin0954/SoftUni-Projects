function extractLinks(arr) {
    let links = [];
    let regx = /www\.[a-zA-Z-\d]+(\.[a-z]+)+/g;

    for (let a = 0; a < arr.length; a++) {
        while (true) {
            let link = regx.exec(arr[a]);
            if (link === null) {
                break;
            }

            links.push(link[0]);
        }
    }

    console.log(links.join('\r\n'));
}