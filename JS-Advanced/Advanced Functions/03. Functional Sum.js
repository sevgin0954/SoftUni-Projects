function result(num1) {
    let total = num1

    function add(num2) {
        total += num2

        return add
    }
    add.toString = () => total
    return add
}