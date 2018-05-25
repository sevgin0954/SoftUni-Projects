function isMatrixMagical(matrix) {
    let isRowSumEqual = true;
    let isFirst = true;
    let firstRowSum = 0;

    for (let col = 0; col < matrix[0].length; col++) {
        let currentSum = 0;

        for (let row = 0; row < matrix.length; row++) {
            if (isFirst) {
                firstRowSum += matrix[row][col];
            }
            else {
                currentSum += matrix[row][col];
            }
        }

        if (isFirst === false) {
            if (currentSum !== firstRowSum) {
                isRowSumEqual = false;
                console.log(false);
                return;
            }
        }

        isFirst = false;
    }

    let isColsSumEqual = true;
    isFirst = true;
    let firstColSum = 0;

    for (let row = 0; row < matrix.length; row++) {
        let currentSum = 0;

        for (let col = 0; col < matrix[0].length; col++) {
            if (isFirst) {
                firstColSum += matrix[row][col];
            }
            else {
                currentSum += matrix[row][col];
            }
        }

        if (isFirst === false) {
            if (currentSum !== firstColSum) {
                isColsSumEqual = false;
                console.log(false);
                return;
            }
        }

        isFirst = false;
    }

    if (firstRowSum === firstColSum) {
        console.log(true);
    }
    else {
        console.log(false);
    }
}