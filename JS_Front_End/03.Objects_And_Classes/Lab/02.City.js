function printCity(city) {
    Object.entries(city).forEach(([key, value]) => {
        console.log(`${key} -> ${value}`);
    })
}