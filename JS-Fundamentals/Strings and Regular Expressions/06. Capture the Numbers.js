function getDigits(arr) {
    let output = [];
    let regx = /\d+/g;

    for (let a = 0; a < arr.length; a++) {
        let digits = regx.exec(arr[a]);

        while (digits !== null) {
            output = output.concat(digits);
            digits = regx.exec(arr[a]);
        }
    }

    console.log(output.join(' '))
}