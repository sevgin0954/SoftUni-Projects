function addRemove(operations) {
    let arr = [];

    for (let a = 0; a < operations.length; a++) {
        let operation = operations[a];
        if (operation === 'add') {
            arr.push(a + 1);
        }
        else if (operation === 'remove') {
            arr.pop();
        }
    }

    if (arr.length === 0) {
        console.log('Empty')
    }
    else {
        console.log(arr.join('\n'));
    }
}