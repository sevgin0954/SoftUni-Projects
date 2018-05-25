function oddOrEven(num) {
    let rest = num % 2

    if (rest === 0) {
        console.log('even')
    }
    else if (Math.abs(rest) === 1) {
        console.log('odd')
    }
    else {
        console.log('invalid')
    }
}