function sumTable() {
    const sum = Array.from(document.querySelectorAll("table:first-of-type td:nth-child(2):not(#sum)"))
    .map((e) => Number(e.textContent))
    .reduce((acc, curr) => {
        console.log(`${acc} + ${curr}`)
        return acc + curr;
    }, 0);

    document.querySelector("#sum").textContent = sum;
}