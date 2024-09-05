function calculateVacationPrice(peopleCount, groupType, weekDay) {
    let totalPrice = 0;

    switch (groupType) {
        case "Students":
            switch (weekDay) {
                case "Friday":
                    totalPrice = peopleCount * 8.45;
                    break;
                case "Saturday":
                    totalPrice = peopleCount * 9.80;
                    break;
                case "Sunday":
                    totalPrice = peopleCount * 10.46;
                    break;
            }

            if (peopleCount >= 30) {
                totalPrice *= 0.85;
            }
            break;
        case "Business":
            switch (weekDay) {
                case "Friday":
                    totalPrice = peopleCount * 10.90;
                    break;
                case "Saturday":
                    totalPrice = peopleCount * 15.60;
                    break;
                case "Sunday":
                    totalPrice = peopleCount * 16;
                    break;
            }

            if (peopleCount >= 100) {
                totalPrice *= (peopleCount - 10)/peopleCount;
            }
            break;
        case "Regular":
            switch (weekDay) {
                case "Friday":
                    totalPrice = peopleCount * 15;
                    break;
                case "Saturday":
                    totalPrice = peopleCount * 20;
                    break;
                case "Sunday":
                    totalPrice = peopleCount * 22.50;
                    break;
            }

            if (peopleCount >= 10 && peopleCount <= 20) {
                totalPrice *= 0.95;
            }
            break;
    }

    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

calculateVacationPrice(30,
    "Students",
    "Sunday");

calculateVacationPrice(40,
    "Regular",
    "Saturday");