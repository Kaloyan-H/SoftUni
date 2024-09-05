function printSongs(songArray) {
    class Song {
        constructor(typeList, name, time) {
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }
    
    let songs = [];

    const songsCount = songArray.shift();
    const typeList = songArray.pop();

    for (let i = 0; i < songsCount; i++) {
        let songInfo = songArray[i].split("_");
        let [typeList, name, time] = [songInfo[0], songInfo[1], songInfo[2]];

        songs.push(new Song(typeList, name, time));
    }

    if (typeList === "all") {
        songs.forEach((song) => {
            console.log(song.name);
        });
    } else {
        songs.forEach((song) => {
            if (song.typeList === typeList) {
                console.log(song.name);
            }
        })
    }
}

printSongs([4,
    'favourite_DownTown_3:14',
    'listenLater_Andalouse_3:24',
    'favourite_In To The Night_3:58',
    'favourite_Live It Up_3:48',
    'listenLater']);

printSongs([3,
    'favourite_DownTown_3:14',
    'favourite_Kiss_4:16',
    'favourite_Smooth Criminal_4:01',
    'favourite']);