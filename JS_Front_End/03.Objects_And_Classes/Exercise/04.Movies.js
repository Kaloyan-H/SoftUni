function printMovies(moviesInfoArray) {
    class Movie {
        constructor(name, date, director) {
            this.name = name;
            this.director = director;
            this.date = date;
        }
    }

    const movies = [];

    moviesInfoArray.forEach((movieInfo) => {
        let tokens = movieInfo.split(" ");

        if (tokens[0] === "addMovie") {
            tokens.shift();
            movies.push(new Movie(tokens.join(" "), null, null));
        } else {
            const tokensLength = tokens.length;
            let foundCommandFlag = false;
            let movieNameArray = [];
            let propertyValueArray = [];
            let propertyName;

            for (let i = 0; i < tokensLength; i++) {

                if (foundCommandFlag) {
                    propertyValueArray.push(tokens.shift());
                } else if (tokens[0] === "onDate" || tokens[0] === "directedBy") {
                    propertyName = tokens.shift();
                    foundCommandFlag = true;
                } else {
                    movieNameArray.push(tokens.shift());
                }
            }

            const movie = movies.find((movie) => {
                return movie.name === movieNameArray.join(" ");
            });

            if (movie) {
                switch (propertyName) {
                    case "onDate":
                        movie.date = propertyValueArray.join(" ");
                        break;
                    case "directedBy":
                        movie.director = propertyValueArray.join(" ");
                        break;
                }
            }
        }
    });

    movies.forEach((movie) => {
        if (movie.name && movie.director && movie.date) {
            console.log(JSON.stringify(movie));
        }
    });
}

printMovies([ 'addMovie Fast and Furious', 'addMovie Godfather', 'Inception directedBy Christopher Nolan', 'Godfather directedBy Francis Ford Coppola', 'Godfather onDate 29.07.2018', 'Fast and Furious onDate 30.07.2018', 'Batman onDate 01.08.2018', 'Fast and Furious directedBy Rob Cohen' ]);