function validatePassword(password) {
    let passwordValidityFlag = true;

    if (password.length < 6 || password.length > 10) {
        console.log("Password must be between 6 and 10 characters");
        passwordValidityFlag = false;
    } if (!/^[A-Za-z0-9]+$/.test(password)) {
        console.log("Password must consist only of letters and digits");
        passwordValidityFlag = false;
    }

    let digitsCount = 0;

    for (let i = 0; i < password.length; i++) {
        if (/^[0-9]$/.test(password[i])) {
            digitsCount++;
        }
    }
    
    if (digitsCount < 2) {
        console.log("Password must have at least 2 digits");
        passwordValidityFlag = false;
    }

    if (passwordValidityFlag) {
        console.log("Password is valid");
    }
}