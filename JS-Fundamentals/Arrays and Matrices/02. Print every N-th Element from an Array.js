function printEveryNElement(array) {
    let n = Number(array.pop());

    for (let a = 0; a < array.length; a += n) {
        console.log(array[a]);
    }
}