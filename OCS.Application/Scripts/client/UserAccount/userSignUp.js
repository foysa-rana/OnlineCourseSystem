$(document).ready(() => {
    formValue();

});

//global variable
let validation;
let passwordCon;

//refresh form
let refresh = () => {
    $("#Id").val("");
    $("#UserName").val("");
    $("#FName").val("");
    $("#LName").val("");
    $("#BirthDate").val("");
    $("#Gender").val("");
    $("#Email").val("");
    $("#Password").val("");
    $("#confirm-password-SignUp").val("");
}

//update or post
let formValue = () => {
    // get id from url ==> array
    getData();

    //username validation event
    let userName = document.querySelector('#UserName');
    userName.addEventListener("keyup", (event) => {
        if (event.isComposing || event.keyCode === 229) {
            return;
        }
        validateUserName();
    });

    //passowrd confirmation method
    let confirmPassword = document.querySelector('#confirm-password-SignUp');
    confirmPassword.addEventListener("keyup", (event) => {
        if (event.isComposing || event.keyCode === 229) {
            return;
        }
        Password();
    })

    $("#signUp").on('click', () => {
        let vm = {};
        let id = $("#Id").val();
        vm.UserName = $("#UserName").val();
        vm.FName = $("#FName").val();
        vm.LName = $("#LName").val();
        vm.BirthDate = $("#BirthDate").val();
        vm.Gender = $("#Gender").val();
        vm.Email = $("#Email").val();
        vm.Password = $("#Password").val();
        //post formdata
        if (id == 0 || id == null || id == '' || id == undefined) {
            let apiUrl = "/api/User";
            if (validation) {
                if (passwordCon) {
                    postData(vm, apiUrl, refresh);
                }
                else {
                    Swal.fire("Confirm password did not matched.");
                }
            }
            else {
                Swal.fire("Username already Exist.");
            }
        }
        else {
            vm.id = id;
            let apiUrl = "/api/User" + id;
            updateData(vm, apiUrl, refresh);
        }
    });
}
//username validation 
let validateUserName = async () => {
    let UserName = document.querySelector('#UserName').value;
    let userNameValidation = document.querySelector('.user-name-validation');
    let vm = {};
    vm.UserName = UserName;
    let p = await fetch("/api/UserNameValidation", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(vm),
    })
    let data = await p.json();

    if (data == "exist") {
        userNameValidation.classList.remove('d-none');
        validation = false;
    }
    else {
        userNameValidation.classList.add('d-none');
        validation = true;
    }
}

//password confirmation 
let Password = () => {
    let password = document.querySelector('#Password').value;
    let confirmPassword = document.querySelector('#confirm-password-SignUp');
    let passwordConfirmation = document.querySelector('.password-confirmation');

    if (password != confirmPassword.value) {
        passwordConfirmation.classList.remove("d-none")
        passwordCon = false;
    }
    else {
        passwordConfirmation.classList.add("d-none")
        passwordCon = true;
    }
}

//get data
let getData = () => {
    let queryValue = getUrlVars();
    let queryId = queryValue.id;
    let url = "/api/User?id=" + queryId;
    if (queryId) {
        $.get(url)
            .done((data) => {
                $("#Id").val(data.id);
                $("#FName").val(data.fName);
                $("#UserName").val(data.userName);
                $("#LName").val(data.lName);
                $("#Birthdate").val(data.birthDate);
                $("#Gender").val(data.gender);
                $("#Email").val(data.email);
                $("#Password").val(data.salary);
            })
    }
}

