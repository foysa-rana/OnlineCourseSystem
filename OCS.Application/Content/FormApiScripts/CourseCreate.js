$(document).ready(() => {
    formValue();

});
//refresh form
let refresh = () => {
    $("#Id").val("");
    $("#Photo").val("");
    $("#TrainerId").val("");
    $("#Name").val("");
    $("#Duration").val("");
    $("#Description").val("");
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
        vm.Name = $("#Name").val();
        vm.Duration = $("#Duration").val();
        vm.Description = $("#Description").val();
        //post formdata
        if (id == 0 || id == null || id == '' || id == undefined) {
            let apiUrl = "/api/Course";
            postData(vm, apiUrl, refresh);
        }
        else {
            vm.id = id;
            let apiUrl = "/api/Course/" + id;
            updateData(vm, apiUrl, refresh);
        }
    });
}

//get data
let getData = () => {
    let queryValue = getUrlVars();
    let queryId = queryValue.id;
    let url = "/api/Course?id=" + queryId;
    if (queryId) {
        $.get(url)
            .done((data) => {
                $("#Id").val(data.id);
                $("#Photo").val(data.Photo);
                $("#TrainerId").val(data.TrainerId);
                $("#Name").val(data.Name);
                $("#Duration").val(data.Duration);
                $("#Description").val(data.Description);
            })
    }
}

