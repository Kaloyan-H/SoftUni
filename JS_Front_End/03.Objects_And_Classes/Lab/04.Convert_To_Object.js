function createObjectFromJSON(jsonObject) {
    const object = JSON.parse(jsonObject);

    Object.entries(object).forEach(([key, value]) => {
        console.log(`${key}: ${value}`);
    })
}