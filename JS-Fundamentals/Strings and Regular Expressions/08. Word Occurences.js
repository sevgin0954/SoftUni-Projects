function countOccurences(string, substring){
    let count = 0;
    let regx = new RegExp('\\b' + substring + '\\b', 'gi');

    while (regx.exec(string) !== null) {
        count++;
    }

    console.log(count);
}