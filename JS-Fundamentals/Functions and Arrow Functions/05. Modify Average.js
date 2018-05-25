function modifyNumber(number) {
    while (true) {
        if (calculateAverageValue(number) > 5) {
            break;
        }

        number += '9';
    }

    console.log(number);
    
    function calculateAverageValue(number) {
        let sum = 0;
        number = number.toString();
        for (let a = 0; a < number.length; a++) {
            sum += Number(number[a]);
        }

        return sum / number.length;
    }
}

modifyNumber(101);