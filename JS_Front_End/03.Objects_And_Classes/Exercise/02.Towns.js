function printTowns(townInfoArray) {
    townInfoArray.map((townInfo) => {
        const [name, latitude, longitude] = townInfo.split(" | ");
        return {
            town: name,
            latitude: Number(latitude).toFixed(2),
            longitude: Number(longitude).toFixed(2),
        };
    }).forEach((town) => {
        console.log(town);
    });
}