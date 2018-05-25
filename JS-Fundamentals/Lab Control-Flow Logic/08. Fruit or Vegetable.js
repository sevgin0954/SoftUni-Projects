function printTypeOfFood(food) {
    let frutis = ['banana', 'apple', 'kiwi', 'cherry', 'lemon', 'grapes', 'peach']
    let vegetables = ['tomato', 'cucumber', 'pepper', 'onion', 'garlic', 'parsley']
    let foodType = 'unknown'
    
    if (isExistInArr(frutis, food)) {
        foodType = 'fruit'
    }
    else if (isExistInArr(vegetables, food)) {
        foodType = 'vegetable'
    }

    console.log(foodType)
}

function isExistInArr(arr, searched) {
    for (let a = 0; a < arr.length; a++) {
        if (arr[a] === searched) {
            return true
        }
    }

    return false
}

printTypeOfFood('banana')