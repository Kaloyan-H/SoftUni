function solve(input) {
    const numberOfRiders = input.shift();
    const ridersInfo = input.slice(0, numberOfRiders);
    const commands = input.slice(numberOfRiders);

    const ridersObject = ridersInfo.reduce((acc, curr) => {
        [rider, fuelCapacity, position] = curr.split("|");

        acc[rider] = {
            fuelCapacity: Number(fuelCapacity),
            position: Number(position),
        };

        return acc;
    }, {});

    // const commandRunner = {
    //     StopForFuel: stopForFuel,
    //     Overtaking: overtaking,
    //     EngineFail: engineFail,
    //     Finish: finish,
    // };

    commands.forEach((command) => {
        const commandTokens = command.split(" - ");
        const commandType = commandTokens.shift();

        // commandRunner[commandType](commandTokens);

        switch (commandType) {
            case "StopForFuel":
                stopForFuel(commandTokens);
                break;
            case "Overtaking":
                overtaking(commandTokens);
                break;
            case "EngineFail":
                engineFail(commandTokens);
                break;
            case "Finish":
                finish(commandTokens);
                break;
        }
    });

    function stopForFuel(commandTokens) {
        [rider, minimumFuel, changedPosition] = commandTokens;

        if (ridersObject[rider]["fuelCapacity"] >= minimumFuel) {
            console.log(`${rider} does not need to stop for fuel!`);
            return;
        }

        // const currentRiderPosition = ridersObject[rider]["position"];

        ridersObject[rider]["position"] = changedPosition;
        // ridersObject[rider]["fuelCapacity"] = minimumFuel;

        // Object.values(ridersObject).forEach((rider) => {
        //     if (
        //         rider["position"] < currentRiderPosition &&
        //         rider["position"] >= changedPosition
        //     ) {
        //         rider["position"]++;
        //     }
        // });

        console.log(
            `${rider} stopped to refuel but lost his position, now he is ${changedPosition}.`
        );
    }

    function overtaking(commandTokens) {
        [riderOne, riderTwo] = commandTokens;
        if (
            ridersObject[riderOne]["position"] <
            ridersObject[riderTwo]["position"]
        ) {
            riderOnePosition = ridersObject[riderOne]["position"];
            ridersObject[riderOne]["position"] =
                ridersObject[riderTwo]["position"];
            ridersObject[riderTwo]["position"] = riderOnePosition;
            console.log(`${riderOne} overtook ${riderTwo}!`);
        }
    }

    function engineFail(commandTokens) {
        [rider, lapsLeft] = commandTokens;

        delete ridersObject[rider];

        console.log(
            `${rider} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`
        );
    }

    function finish(commandTokens) {
        Object.entries(ridersObject).forEach((riderEntry) => {
            [riderName, riderInfoObject] = riderEntry;

            console.log(
                `${riderName}\n  Final position: ${riderInfoObject["position"]}`
            );
        });
    }
}

solve([
    "4",
    "Valentino Rossi|100|1",
    "Marc Marquez|90|3",
    "Jorge Lorenzo|80|4",
    "Johann Zarco|80|2",
    "StopForFuel - Johann Zarco - 90 - 5",
    "Overtaking - Marc Marquez - Jorge Lorenzo",
    "EngineFail - Marc Marquez - 10",
    "Finish",
]);
