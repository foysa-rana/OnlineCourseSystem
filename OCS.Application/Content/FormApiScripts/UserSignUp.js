$(document).ready(() => {
    formValue();

});
//refresh form
let refresh = () => {
    $("#Id").val("");
    $("#UserName").val("");
    $("#FName").val("");
    $("#LName").val("");
    $("#Email").val("");
    $("#Password").val("");
    $("#confirm-password-SignUp").val("");
}

//update or post
let formValue = () => {
    // get id from url ==> array
    getData();

    $("#signUp").on('click', () => {
        let vm = {};
        let id = $("#Id").val();
        vm.UserName = $("#UserName").val();
        vm.FName = $("#FName").val();
        vm.LName = $("#LName").val();
        vm.Email = $("#Email").val();
        vm.Password = $("#Password").val();
        //post formdata
        if (id == 0 || id == null || id == '' || id == undefined) {
            let apiUrl = "/api/User";
            postData(vm, apiUrl, refresh);
        }
        else {
            vm.id = id;
            let apiUrl = "/api/User" + id;
            updateData(vm, apiUrl, refresh);
        }
    });
}

//get data
let getData = () => {
    let queryValue = getUrlVars();
    let queryId = queryValue.id;
    let url = "/aapi/User?id=" + queryId;
    if (queryId) {
        $.get(url)
            .done((data) => {
                $("#Id").val(data.id);
                $("#FName").val(data.fName);
                $("#UserName").val(data.userName);
                $("#LName").val(data.lName);
                $("#Email").val(data.email);
                $("#Password").val(data.salary);
            })
    }
}

