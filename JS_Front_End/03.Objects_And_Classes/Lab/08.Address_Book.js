function printPeopleInfo(peopleInfoArray) {
    const peopleInfo = peopleInfoArray.reduce((acc, curr) => {
        const [name, address] = curr.split(":");
        acc[name] = address;

        return acc;
    }, {});

    Object.entries(peopleInfo).sort((a, b) => {
        if (a[0] > b[0]) {
            return 1;
        } if (a[0] < b[0]) {
            return -1;
        }
        return 0;
    }).forEach(([name, address]) => {
        console.log(`${name} -> ${address}`);
    });
}

printPeopleInfo(['Tim:Doe Crossing',
'Bill:Nelson Place',
'Peter:Carlyle Ave',
'Bill:Ornery Rd']);