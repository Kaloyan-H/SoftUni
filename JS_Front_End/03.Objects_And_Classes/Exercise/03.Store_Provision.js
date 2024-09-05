function printStoreProvision(currentStockArray, orderedProductsArray) {
    const storeStock = {};

    for (let i = 0; i < currentStockArray.length; i += 2) {
        storeStock[currentStockArray[i]] = Number(currentStockArray[i + 1]);
    }

    for (let i = 0; i < orderedProductsArray.length; i += 2) {
        if (storeStock[orderedProductsArray[i]]) {
            storeStock[orderedProductsArray[i]] += Number(orderedProductsArray[i + 1]);
        } else {
            storeStock[orderedProductsArray[i]] = Number(orderedProductsArray[i + 1]);
        }
    }

    Object.entries(storeStock).forEach(([key, value]) => {
        console.log(`${key} -> ${value}`);
    });
}

printStoreProvision([
    'Chips', '5', 'CocaCola', '9', 'Bananas',
    '14', 'Pasta', '4', 'Beer', '2'
    ],
    [
    'Flour', '44', 'Oil', '12', 'Pasta', '7',
    'Tomatoes', '70', 'Bananas', '30'
    ]);