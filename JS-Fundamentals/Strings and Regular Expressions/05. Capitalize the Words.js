function capitalizeWords(string) {
    string = string.toLowerCase()
    let capitalizedString = string.replace(/\b\w/g, (ch) => {return ch.toUpperCase()});

    console.log(capitalizedString)
}