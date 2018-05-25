function isPrime(num) {
    if (num === 0) {
        return false
    }
    else if (num === 1) {
        return false
    }
    else if (num < 0) {
        return false
    }

    for (let a = 2; a < num; a++) {
        if (num % a === 0) {
            return false
        }
    }

    return true
}