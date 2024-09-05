function printLoadingBar(progress) {
    console.log(progress === 100 ?
        `${progress}% Complete!\n[${"%".repeat(progress / 10)}]` :
        `${progress}% [${"%".repeat(progress / 10)}${".".repeat(10 - (progress / 10))}]\nStill loading...`);
}

printLoadingBar(30);