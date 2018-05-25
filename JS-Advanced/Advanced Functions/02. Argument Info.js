function displayArgumentsInfo() {
    let argsCount = {}
    for (let a = 0; a < arguments.length; a++) {
        let arg = arguments[a]
        let type = typeof arg

        console.log(type + ': ' + arg)

        if (!argsCount[type]) {
            argsCount[type] = 1
        }
        else {
            argsCount[type]++
        }
    }

    let array = []

    for (let argCount in argsCount) {
        let key = argsCount[argCount]
        array.push([argCount, key])
    }

    array = array.sort(sortByKey)

    printKeyValueArr(array)

    function sortByKey(a, b) {
        return b[1] - a[1]
    }

    function printKeyValueArr(arr) {
        for (let unit in arr) {
            console.log(arr[unit][0] + ' = ' + arr[unit][1])
        }
    }
}