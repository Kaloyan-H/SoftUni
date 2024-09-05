function createCats(catsArray) {
    let cats = [];
    
    function createCat(name, age) {
        this.name = name,
        this.age = age,
        this.meow = function() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    for (let i = 0; i < catsArray.length; i++) {
        let catInfo = catsArray[i].split(" ");
        let [name, age] = [catInfo[0], catInfo[1]];
        cats.push(new createCat(name, age));
    }
    
    cats.forEach((cat) => {
        cat.meow();
    });
}

createCats(['Candy 1', 'Poppy 3', 'Nyx 2']);