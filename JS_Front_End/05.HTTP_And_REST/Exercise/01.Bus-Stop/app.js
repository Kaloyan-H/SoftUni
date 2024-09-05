function getInfo() {
    const busStopID = document.querySelector("#stopId").value;
    const stopNameDiv = document.querySelector("#stopName");
    const busList = document.querySelector("#buses");
    busList.innerHTML = "";

    const url = `http://localhost:3030/jsonstore/bus/businfo/${busStopID}`;

    fetch(url)
        .then((res) => {
            if (!res.ok) {
                throw new Error("Error");
            }
            return res.json();
        })
        .then((busStopObject) => {
            try {
                stopNameDiv.textContent = busStopObject.name;

                const busObjects = [];

                Object.entries(busStopObject.buses).forEach((busEntry) => {
                    const [busId, time] = busEntry;
                    const bus = {
                        busId,
                        time,
                    };

                    busObjects.push(bus);
                }); // Turning the buses object into an array of bus objects with properties "busId" and "time"

                busObjects.forEach((bus) => {
                    const listItem = document.createElement("li");
                    listItem.textContent = `Bus ${bus.busId} arrives in ${bus.time} minutes`;

                    busList.appendChild(listItem);
                });
            } catch {
                throw new Error();
            }
        })
        .catch((err) => {
            stopNameDiv.textContent = "Error";
        });
}
