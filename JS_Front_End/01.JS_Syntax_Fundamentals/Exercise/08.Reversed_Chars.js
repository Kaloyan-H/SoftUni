function reverseCharacters(charOne, charTwo, charThree) {
    let charArr = [charThree, charTwo, charOne];
    let result = charArr.join(" ");

    console.log(result);
}

reverseCharacters('a', 'b', 'c');