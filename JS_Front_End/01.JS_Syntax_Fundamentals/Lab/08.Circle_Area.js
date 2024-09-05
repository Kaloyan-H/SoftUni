function calculateCircleArea(radius) {
    let result;
    let inputType = typeof(radius);

    if (inputType === "number") {
        result = radius ** 2 * Math.PI;
        console.log(result.toFixed(2));
    } else {
        console.log(`We can not calculate the circle area, because we receive a ${inputType}.`);
    }
}

calculateCircleArea(5);
calculateCircleArea("name");