function printSpiralMatrix(rows, cols) {
    let rowsCols = [rows, cols];
    let matrix = getMatrixWithZeros(rowsCols);
    let currentRow = 0;
    let currentCol = 0;
    let currentNum = 1;
    let targetNum = rowsCols[0] * rowsCols[1];

    while (targetNum >= currentNum) {
        fillRight();
        fillDown();
        fillLeft();
        fillUp();
    }

    printMatrix(matrix);

    function getMatrixWithZeros() {
        let tempMatrix = [];

        for (let row = 0; row < rowsCols[0]; row++) {
            tempMatrix[row] = [];
            for (let col = 0; col < rowsCols[1]; col++) {
                tempMatrix[row].push(0);
            }
        }

        return tempMatrix;
    }

    function fillRight() {
        while (targetNum >= currentNum && currentCol < matrix[0].length && matrix[currentRow][currentCol] === 0) {
            matrix[currentRow][currentCol++] = currentNum++;
        }

        currentCol--;
        currentRow++;
    }

    function fillDown() {
        while (targetNum >= currentNum && currentRow < matrix.length && matrix[currentRow][currentCol] === 0) {
            matrix[currentRow++][currentCol] = currentNum++;
        }

        currentRow--;
        currentCol--;
    }

    function fillLeft() {
        while (targetNum >= currentNum && currentCol >= 0 && matrix[currentRow][currentCol] === 0) {
            matrix[currentRow][currentCol--] = currentNum++;
        }

        currentCol++;
        currentRow--;
    }

    function fillUp() {
        while (targetNum >= currentNum && currentCol >= 0 && matrix[currentRow][currentCol] === 0) {
            matrix[currentRow--][currentCol] = currentNum++;
        }

        currentRow++;
        currentCol++;
    }

    function printMatrix(matrix) {
        for (let row = 0; row < matrix.length; row++) {
            console.log(matrix[row].join(' '));
        }
    }
}