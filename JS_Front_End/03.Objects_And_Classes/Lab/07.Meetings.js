function manageMeetings(meetingsInfo) {
    const meetings = meetingsInfo.reduce((acc, curr) => {
        const [day, name] = curr.split(" ");
        if (acc[day]) {
            console.log(`Conflict on ${day}!`);
        } else {
            acc[day] = name;
            console.log(`Scheduled for ${day}`);
        }

        return acc;
    }, {});

    Object.entries(meetings).forEach(([day, name]) => {
        console.log(`${day} -> ${name}`);
    })
}

manageMeetings(['Friday Bob',
'Saturday Ted',
'Monday Bill',
'Monday John',
'Wednesday George']);