function printHeroes(heroesInfoArray) {
    class Hero {
        constructor(name, level, items) {
            this.name = name;
            this.level = level;
            this.items = items;
        }
    }

    const heroes = [];

    heroesInfoArray.forEach((heroInfo) => {
        const [name, level, itemsString] = heroInfo.split(" / ");
        heroes.push(new Hero(name, level, itemsString.split(", ")));
    });

    const heroesSorted = heroes.sort((a, b) => {
        return a.level - b.level;
    });

    heroesSorted.forEach((hero) => {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items.join(", ")}`);
    });
}

printHeroes([
    'Batman / 2 / Banana, Gun',
'Superman / 18 / Sword',
'Poppy / 28 / Sentinel, Antara'
    ]);