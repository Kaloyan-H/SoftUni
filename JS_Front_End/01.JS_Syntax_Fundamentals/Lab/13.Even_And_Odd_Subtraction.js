function subtractEvenSumFromOddSum(array) {
    let evenSum = 0;
    let oddSum = 0;

    for(let element of array) {
        if (element % 2 == 0) {
            evenSum += element;
        } else {
            oddSum += element;
        }
    }

    let result = evenSum - oddSum;

    console.log(result);
}

subtractEvenSumFromOddSum([1,2,3,4,5,6]);