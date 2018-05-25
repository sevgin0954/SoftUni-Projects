function performOperation(numOperations) {
    let num = numOperations[0];

    for (let a = 1; a <= 5; a++) {
        switch (numOperations[a]) {
            case 'chop':
                num /= 2;
                break;
            case 'dice':
                num = Math.sqrt(num);
                break;
            case 'spice':
                num++;
                break;
            case 'bake':
                num *= 3;
                break;
            case 'fillet':
                num -= num * 0.2;
                break;
        }

        console.log(num)
    }
}