function rotateArray(arrayRotateCount) {
    let rotateCount = arrayRotateCount.pop();

    if (rotateCount > arrayRotateCount.length) {
        rotateCount = rotateCount % arrayRotateCount.length;
    }

    for (let a = 0; a < rotateCount; a++) {
        let lastElement = arrayRotateCount.pop();
        arrayRotateCount.unshift(lastElement);
    }

    console.log(arrayRotateCount.join(' '));
}