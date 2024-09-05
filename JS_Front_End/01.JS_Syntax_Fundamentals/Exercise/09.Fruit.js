function calculateFruitPrice (fruitType, weightInGrams, priceForKilogram) {
    let weightInKilograms = weightInGrams / 1000;
    let totalPrice = priceForKilogram * weightInKilograms;

    console.log(`I need $${totalPrice.toFixed(2)} to buy ${weightInKilograms.toFixed(2)} kilograms ${fruitType}.`);
}