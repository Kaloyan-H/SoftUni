function printPeople(peopleNamesArray) {
    class Person {
        constructor(name) {
            this.name = name;
            this.personalNumber = name.length;
        }
    }

    const peopleArray = peopleNamesArray.map((personName) => {
        return new Person(personName);
    });

    peopleArray.forEach((person) => {
        console.log(`Name: ${person.name} -- Personal Number: ${person.personalNumber}`);
    });
}