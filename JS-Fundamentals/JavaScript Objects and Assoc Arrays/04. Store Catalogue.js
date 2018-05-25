function storeCatalogue(arr) {
    let catalogue = {};

    for (let a = 0; a < arr.length; a++) {
        let product = arr[a].split(' : ');
        let name = product[0];
        let price = Number(product[1]);

        catalogue[name] = price;
    }

    let catalogueKeys = Object.keys(catalogue).sort();
    let catalogueLetter = undefined;

    for (let a = 0; a < catalogueKeys.length; a++) {
        let key = catalogueKeys[a];
        let currentLetter = key[0];
        if (currentLetter !== catalogueLetter) {
            catalogueLetter = currentLetter;
            console.log(catalogueLetter);
        }

        console.log('  ' + key + ': ' + catalogue[key]);
    }
}