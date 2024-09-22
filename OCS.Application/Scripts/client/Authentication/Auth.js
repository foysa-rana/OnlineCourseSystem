let logInAuth = () => {
    let logOut = document.querySelector('#logOut');
    let signIn = document.querySelector('#signIn');
    if (!logOut) {
        signIn.addEventListener("click", async () => {
            let data = {};
            data.User = document.querySelector('#User').value;
            data.PasswordSignIn = document.querySelector('#PasswordSignIn').value;
            data.Remember = document.querySelector('#Remember').checked;
            let p = await fetch("/api/Auth/LogIn", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(data),
            });
            let response = await p.json();
            if (response == 1) {
                location.reload();
            }
            if (response == 0) {
                Swal.fire("Wrong Username or Password");
            }
        });
    }
}
logInAuth();

//log out
let logOutAuth = () => {
    let logOut = document.querySelector('#logOut');
    if (logOut) {
        logOut.addEventListener("click", async () => {
            let p = await fetch("/api/Auth/LogOut");
            let response = await p.json();
            if (response == 1) {
                location.reload();
            }
        })
    }
}
logOutAuth();