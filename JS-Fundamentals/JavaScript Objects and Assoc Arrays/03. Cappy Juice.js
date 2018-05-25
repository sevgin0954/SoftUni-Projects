function bottleJuices(arr) {
    let dict = {};
    let bottles = {};

    for (let a = 0; a < arr.length; a++) {
        let keyValue = arr[a].split(' => ');
        let key = keyValue[0];
        let count = Number(keyValue[1]);

        if (dict.hasOwnProperty(key) === false) {
            dict[key] = 0;
        }

        dict[key] += count;

        while (dict[key] >= 1000) {
            dict[key] -= 1000;

            if (bottles.hasOwnProperty(key) == false) {
                bottles[key] = 0;
            }

            bottles[key]++;
        }
    }

    let bottlesKeys = Object.keys(bottles);

    for (let a = 0; a < bottlesKeys.length; a++) {
        let key = bottlesKeys[a];

        console.log(key + ' => ' + bottles[key]);
    }
}