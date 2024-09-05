function  detectSpeeding(speed, area) {
    let allowedSpeed;

    switch (area) {
        case "motorway":
            allowedSpeed = 130;
            break;
        case "interstate":
            allowedSpeed = 90;
            break;
        case "city":
            allowedSpeed = 50;
            break;
        case "residential":
            allowedSpeed = 20;
            break;
    }

    let speedingStatus;

    if (speed > allowedSpeed) {
        if (speed - allowedSpeed <= 20) {
            speedingStatus = "speeding";
        } else if (speed - allowedSpeed <= 40) {
            speedingStatus = "excessive speeding";
        } else {
            speedingStatus = "reckless driving";
        }
    } else {
        console.log(`Driving ${speed} km/h in a ${allowedSpeed} zone`);
        return;
    }

    console.log(`The speed is ${speed - allowedSpeed} km/h faster than the allowed speed of ${allowedSpeed} - ${speedingStatus}`);
}

detectSpeeding(40, "city");
detectSpeeding(21, "residential");
detectSpeeding(120, "interstate");