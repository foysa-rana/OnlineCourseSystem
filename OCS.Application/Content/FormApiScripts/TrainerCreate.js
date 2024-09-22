$(document).ready(() => {
    formValue();

});
//refresh form
let refresh = () => {
    $("#Id").val("");
    $("#Photo").val("");
    $("#profile-select").attr("src", "../../Profile_image/blank-profile-picture.jpg");
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
    $("#About").val("");
}

let newFile = '';

//update or post
let formValue = () => {
    // get id from url ==> array
    getData();

    $("#Submit").on('click', () => {
        let file = document.querySelector("#Photo").files[0];
        if (file) {
            let d = new Date,
                dformat = [(d.getMonth() + 1),
                d.getDate(),
                d.getFullYear()].join('-') + '_' +
                    [d.getHours(),
                    d.getMinutes(),
                    d.getSeconds()].join('-');
            let blob = file.slice(0, file.size, 'image/jpeg/png/jpg');
            newFile = new File([blob], dformat + '_' + file.name, { type: 'image/jpeg/png/jpg' });
            uploadPhoto();
        }
        
        let vm = {};

        let id = $("#Id").val();
        if (newFile == "" || newFile == null || newFile == undefined) {
            vm.Photo = $("#imgName").val();
        }
        else {
            vm.Photo = newFile.name;
        }
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
        vm.About = $("#About").val();
        //post formdata
        if (id == 0 || id == null || id == '' || id == undefined) {
            let apiUrl = "/api/Trainer";
            postData(vm, apiUrl, refresh);
        }
        //update
        else {
            vm.id = id;
            let apiUrl = "/api/Trainer/" + id;
            updateData(vm, apiUrl, refresh);
        }
    });
}

//post photo
let uploadPhoto = async () => {
    let file = document.querySelector('#Photo');
    let data = new FormData();
    data.append("photo", newFile);
    let p = await fetch("/Trainer/CreateTrainers", {
        method: "POST",
        body: data,
    });
    let response = await p.json();

    if (response) {
        console.log("Image Save Successful");
    }
    else {
        console.log("Image Save faild");
    }
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
                $("#imgName").val(data.photo);
                $("#profile-select").attr("src", "../../images/TrainerProfile-img/" + data.photo);
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
                $("#About").val(data.about);
            })
    }
}

