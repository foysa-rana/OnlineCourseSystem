$(document).ready(() => {
    formValue();

});
//refresh form
let refresh = () => {
    $("#Id").val("");
    $("#Photo").val("");
    $("#TrainerId").val("");
    $("#FName").val("");
    $("#LName").val("");
    $("#BirthDate").val("");
    $("#Gender").val("");
    $("#Phone").val("");
    $("#Email").val("");
    $("#JobTitle").val("");
    $("#Position").val("");
    $("#JoiningDate").val("");
    $("#PresentAddress").val("");
    $("#PermanentAddress").val("");
    $("#Salary").val("");
}

//update or post
let formValue = () => {
    // get id from url ==> array
    getData();

    $("#Submit").on('click', () => {
        let vm = {};
        let id = $("#Id").val();
        vm.Photo = $("#Photo").val();
        vm.TrainerId = $("#TrainerId").val();
        vm.FName = $("#FName").val();
        vm.LName = $("#LName").val();
        vm.BirthDate = $("#BirthDate").val();
        vm.Gender = $("#Gender").val();
        vm.Phone = $("#Phone").val();
        vm.Email = $("#Email").val();
        vm.JobTitle = $("#JobTitle").val();
        vm.Position = $("#Position").val();
        vm.JoiningDate = $("#JoiningDate").val();
        vm.PresentAddress = $("#PresentAddress").val();
        vm.PermanentAddress = $("#PermanentAddress").val();
        vm.Salary = $("#Salary").val();
        //post formdata
        if (id == 0 || id == null || id == '' || id == undefined) {
            let apiUrl = "/api/Trainer";
            postData(vm, apiUrl, refresh);
        }
        else {
            vm.id = id;
            let apiUrl = "/api/Trainer/" + id;
            updateData(vm, apiUrl, refresh);
        }
    });
}

//get data
let getData = () => {
    let queryValue = getUrlVars();
    let queryId = queryValue.id;
    let url = "/api/Trainer?id=" + queryId;
    if (queryId) {
        $.get(url)
            .done((data) => {
                $("#Id").val(data.id);
                $("#Photo").val(data.photo);
                $("#TrainerId").val(data.trainerId);
                $("#FName").val(data.fName);
                $("#LName").val(data.lName);
                $("#BirthDate").val(data.birthDate);
                $("#Gender").val(data.gender);
                $("#Phone").val(data.phone);
                $("#Email").val(data.email);
                $("#JobTitle").val(data.jobTitle);
                $("#Position").val(data.position);
                $("#JoiningDate").val(data.joiningDate);
                $("#PresentAddress").val(data.presentAddress);
                $("#PermanentAddress").val(data.permanentAddress);
                $("#Salary").val(data.salary);
            })
    }
}

