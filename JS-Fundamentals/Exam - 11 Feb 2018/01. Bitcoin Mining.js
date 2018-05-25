function calculatePurchasedBitcoins(shiftsMinedGold) {
    const bitcoinPrice = 11949.16;
    const goldPrice = 67.51;

    let totalMoney = 0;
    let firstBitcoinBuyDay = 0;
    let isFirstBicoinBuyed = false;
    let boughtBitcoins = 0;

    for (let a = 0; a < shiftsMinedGold.length; a++) {
        let currentDayGoldMined = Number(shiftsMinedGold[a]);

        if ((a + 1) % 3 === 0) {
            currentDayGoldMined *= 0.7;
        }

        totalMoney += currentDayGoldMined * goldPrice;

        while (totalMoney >= bitcoinPrice) {
            totalMoney -= bitcoinPrice;
            boughtBitcoins++;

            if (isFirstBicoinBuyed === false) {
                firstBitcoinBuyDay = a + 1;
                isFirstBicoinBuyed = true;
            }
        }
    }

    console.log(`Bought bitcoins: ${boughtBitcoins}`);
    if (boughtBitcoins > 0) {
        console.log(`Day of the first purchased bitcoin: ${firstBitcoinBuyDay}`);
    }
    console.log(`Left money: ${totalMoney.toFixed(2)} lv.`);
}