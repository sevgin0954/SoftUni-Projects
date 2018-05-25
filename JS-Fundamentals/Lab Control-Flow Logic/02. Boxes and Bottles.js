function printRequiredBoxes(bottlesCount, boxSize) {
    let requiredBoxesCount = 0

    while (bottlesCount > 0) {
        requiredBoxesCount++
        bottlesCount -= boxSize
    }

    console.log(requiredBoxesCount)
}