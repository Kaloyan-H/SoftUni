function solve(input) {
    const ticketLines = Number(input.shift());
    const tickets = input.slice(0, ticketLines);
    const commands = input.slice(ticketLines);

    const board = tickets.reduce((acc, curr) => {
        const [assignee, taskId, title, status, points] = curr.split(":");

        if (!acc.hasOwnProperty(assignee)) {
            acc[assignee] = {};
        }

        acc[assignee][taskId] = { title, status, points: Number(points) };

        return acc;
    }, {});

    const commandRunner = {
        "Add New": addNewTask,
        "Change Status": changeTaskStatus,
        "Remove Task": removeTask,
    };

    commands.forEach((command) => {
        const commandTokens = command.split(":");
        const commandType = commandTokens.shift();

        commandRunner[commandType](commandTokens);
    });

    function addNewTask(commandInfo) {
        const [assignee, taskId, title, status, points] = commandInfo;

        if (!board.hasOwnProperty(assignee)) {
            console.log(`Assignee ${assignee} does not exist on the board!`);
            return;
        }

        board[assignee][taskId] = { title, status, points: Number(points) };
    }

    function changeTaskStatus(commandInfo) {
        const [assignee, taskId, newStatus] = commandInfo;

        if (!board.hasOwnProperty(assignee)) {
            console.log(`Assignee ${assignee} does not exist on the board!`);
            return;
        }

        if (!board[assignee].hasOwnProperty(taskId)) {
            console.log(
                `Task with ID ${taskId} does not exist for ${assignee}!`
            );
            return;
        }

        board[assignee][taskId]["status"] = newStatus;
    }

    function removeTask(commandInfo) {
        const [assignee, index] = commandInfo;

        if (!board.hasOwnProperty(assignee)) {
            console.log(`Assignee ${assignee} does not exist on the board!`);
            return;
        }

        const assigneeTaskIds = Object.keys(board[assignee]);

        if (assigneeTaskIds.length <= index) {
            console.log(`Index is out of range!`);
            return;
        }

        delete board[assignee][assigneeTaskIds[index]];
    }

    let toDoTasksTotalPoints = 0;
    let inProgressTasksTotalPoints = 0;
    let codeReviewTasksTotalPoints = 0;
    let doneTasksTotalPoints = 0;

    Object.values(board).forEach((assigneeObject) => {
        Object.values(assigneeObject).forEach((taskObject) => {
            switch (taskObject["status"]) {
                case "ToDo":
                    toDoTasksTotalPoints += taskObject["points"];
                    break;
                case "In Progress":
                    inProgressTasksTotalPoints += taskObject["points"];
                    break;
                case "Code Review":
                    codeReviewTasksTotalPoints += taskObject["points"];
                    break;
                case "Done":
                    doneTasksTotalPoints += taskObject["points"];
                    break;
            }
        });
    });

    console.log(
        `ToDo: ${toDoTasksTotalPoints}pts\n` +
            `In Progress: ${inProgressTasksTotalPoints}pts\n` +
            `Code Review: ${codeReviewTasksTotalPoints}pts\n` +
            `Done Points: ${doneTasksTotalPoints}pts`
    );

    if (
        doneTasksTotalPoints >=
        toDoTasksTotalPoints +
            inProgressTasksTotalPoints +
            codeReviewTasksTotalPoints
    ) {
        console.log("Sprint was successful!");
    } else {
        console.log("Sprint was unsuccessful...");
    }
}

solve([
    "5",
    "Kiril:BOP-1209:Fix MinorBug:ToDo:3",
    "Mariya:BOP-1210:Fix MajorBug:In Progress:3",
    "Peter:BOP-1211:POC:CodeReview:5",
    "Georgi:BOP-1212:InvestigationTask:Done:2",
    "Mariya:BOP-1213:New AccountPage:In Progress:13",
    "Add New:Kiril:BOP-1217:AddInfo Page:In Progress:5",
    "Change Status:Peter:BOP-1290:ToDo",
    "Remove Task:Mariya:1",
    "Remove Task:Joro:1",
]);
