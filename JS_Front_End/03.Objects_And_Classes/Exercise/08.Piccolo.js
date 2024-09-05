function printParkingLot(input) {
    const parking = input.reduce((acc, curr) => {
        const [status, carNumber] = curr.split(", ");
        acc[carNumber] = status;
        return acc;
    }, {});

    const carsInParking = Object.entries(parking).sort((a, b) => {
        let firstNumber = Number(a[0].substring(2, a[0].length - 2));
        let secondNumber = Number(b[0].substring(2, b[0].length - 2));
        return firstNumber - secondNumber;
    }).filter(([key, value]) => value === "IN").map(([key, value]) => key);

    if (carsInParking.length) {
        carsInParking.forEach((number) => console.log(number));
    } else {
        console.log("Parking Lot is Empty");
    }
} // Sorts only by the 4-digit substring

function printParkingLotTwo(input) {
    const parking = input.reduce((acc, curr) => {
        const [status, carNumber] = curr.split(", ");
        acc[carNumber] = status;
        return acc;
    }, {});

    const carsInParking = Object.entries(parking).sort().filter(([key, value]) => value === "IN").map(([key, value]) => key);

    if (carsInParking.length) {
        carsInParking.forEach((number) => console.log(number));
    } else {
        console.log("Parking Lot is Empty");
    }
} // Sorts by the whole license plate number