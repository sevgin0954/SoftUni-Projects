function countCharOccurence(input, searchedChar) {
    let count = 0;

    for (let a = 0; a < input.length; a++) {
        if (input[a] === searchedChar) {
            count++
        }
    }

    console.log(count)
}