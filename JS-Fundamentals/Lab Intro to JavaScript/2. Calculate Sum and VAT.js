function calcSumAndVAT(arr) {
    let totalSum = 0

    for (let a = 0; a < arr.length; a++){
        totalSum += arr[a]
    }

    let totalVAT = totalSum * 0.2
    let total = totalSum + totalVAT

    console.log(`sum = ${totalSum}`)
    console.log(`VAT = ${totalVAT}`)
    console.log(`total = ${total}`)
}

calcSumAndVAT([1,2,3])