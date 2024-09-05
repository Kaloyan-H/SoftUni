function printPeoplePhoneNumbers(peoplePhoneNumbersInfo) {
    const phoneBook = peoplePhoneNumbersInfo.reduce((acc, curr) => {
        const [name, phone] = curr.split(" ");
        acc[name] = phone;

        return acc;
    }, {});

    Object.entries(phoneBook).forEach(([key, value]) => {
        console.log(`${key} -> ${value}`);
    })
}