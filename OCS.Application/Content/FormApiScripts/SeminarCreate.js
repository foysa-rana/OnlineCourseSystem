$(document).ready(() => {
    formValue();
    loadTrainerInfo();
});
//refresh form
let refresh = () => {
    $("#Id").val("");
    $("#Photo").val("");
    $("#profile-select").attr("src", "../../Profile_image/blank-profile-picture.jpg");
    $("#TrainerId").val("");
    $("#Name").val("");
    $("#Time").val("");
    $("#Description").val("");
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

        if (newFile == "" || newFile == null || newFile == undefined) {
            vm.Photo = $("#imgName").val();
        }
        else {
            vm.Photo = newFile.name;
        }

        let id = $("#Id").val();
        vm.TrainerId = $("#TrainerId").val();
        vm.Name = $("#Name").val();
        vm.Time = $("#Time").val();
        vm.Description = $("#Description").val();
        //post formdata
        if (id == 0 || id == null || id == '' || id == undefined) {
            let apiUrl = "/api/Seminar";
            postData(vm, apiUrl, refresh);
        }
        else {
            vm.id = id;
            let apiUrl = "/api/Seminar/" + id;
            updateData(vm, apiUrl, refresh);
        }
    });
}

//post photo
let uploadPhoto = async () => {
    let file = document.querySelector('#Photo');
    let data = new FormData();
    data.append("photo", newFile);
    let p = await fetch("/Seminar/CreateSeminar", {
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

//load trainer info
let loadTrainerInfo = async () => {
    let trainerId = document.querySelector('#TrainerId');
    let p = await fetch("/api/Trainer");

    let data = await p.json();

    data.forEach((val) => {
        let option = document.createElement('option');
        trainerId.append(option);
        option.append(val.fName + " " + val.lName);
        option.setAttribute('value', val.id);
    })
}

//get data
let getData = () => {
    let queryValue = getUrlVars();
    let queryId = queryValue.id;
    let url = "/api/Seminar?id=" + queryId;
    if (queryId) {
        $.get(url)
            .done((data) => {
                $("#Id").val(data.id);
                $("#imgName").val(data.photo);
                $("#profile-select").attr("src", "../../images/Seminar-img/" + data.photo);
                $("#TrainerId").val(data.TrainerId);
                $("#Name").val(data.Name);
                $("#Time").val(data.Time);
                $("#Description").val(data.Description);
            })
    }
}