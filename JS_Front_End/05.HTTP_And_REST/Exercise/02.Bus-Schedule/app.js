function solve() {
    const departButton = document.querySelector("#depart");
    const arriveButton = document.querySelector("#arrive");
    const infoSpan = document.querySelector("#info .info");
    let nextStopID = "depot";
    let stopName;

    function depart() {
        fetch(`http://localhost:3030/jsonstore/bus/schedule/${nextStopID}`)
            .then((res) => res.json())
            .then((res) => {
                stopName = res.name;
                nextStopID = res.next;
                infoSpan.textContent = `Next stop ${stopName}`;
            })
            .catch((err) => {
                infoSpan.textContent = "Error";

                departButton.disabled = false;
                arriveButton.disabled = false;
            });
        departButton.disabled = true;
        arriveButton.disabled = false;
    }

    async function arrive() {
        infoSpan.textContent = `Arriving at ${stopName}`;
        departButton.disabled = false;
        arriveButton.disabled = true;
    }

    return {
        depart,
        arrive,
    };
}

let result = solve();
