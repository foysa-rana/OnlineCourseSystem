//refresh form
let refresh = () => {
    document.querySelector('.video-here').style.border = "block";
    document.querySelector('.change').style.display = "none";
    let videoContainer = $('.video-container');
    $("#Id").val("");
    $("#video-select").remove();
    let videoElement = document.createElement("video");
    videoElement.setAttribute("id", "video-select");
    videoContainer.append(videoElement);
    document.querySelector('.video-here').style.border = "dashed";
    //$("#CourseId").val("select course").change();
    let CourseId = document.querySelector('#CourseId');
    CourseId.value = "select course";
    CourseId.dispatchEvent(new Event('change', { bubbles: true }));
    $("#Name").val("");
    $("#Extension").val("");
}

//get data
let getData = () => {
    let queryValue = getUrlVars();
    let queryId = queryValue.id;
    let url = "/api/Videos?id=" + queryId;
    if (queryId) {
        $.get(url)
            .done((data) => {
                $("#Id").val(data.id);
                $("#Name").val(data.name);
                $("#video-select").attr({ src: `../../Content Media/Videos/${data.course.name}/` + data.video, controls: "controls"});
                let CourseId = document.querySelector('#CourseId');
                CourseId.value = data.courseId;
                CourseId.dispatchEvent(new Event('change', { bubbles: true }));
                let extensionVal = data.video.slice(data.video.indexOf("."));
                $("#Extension").val(extensionVal);
            })
    }
}

//update or post
let formValue = () => {
    // get id from url ==> array
    getData();

    $("#Submit").on('click', () => {
        let file = document.querySelector("#Video").files[0];
        let vm = {};

        //upload video
        let uploadVideo = async (validation, value, id, file) => {
            let validate = validation;
            if (validate === "post") {
                let file = value;
                let courseIdValue = document.querySelector('#CourseId').value;
                let videoName = document.querySelector('#Name').value;

                let courseApi = await fetch("/api/Course");
                let courseRes = await courseApi.json();

                let courseName;

                courseRes.forEach(item => {
                    if (item.id == courseIdValue) {
                        courseName = item.name;
                    }
                });

                let data = new FormData();
                data.append("video", file);
                data.append("videoName", videoName);
                data.append("courseName", courseName);
                data.append("id", 0);
                let p = await fetch("/Videos/CreateVideo", {
                    method: "POST",
                    body: data,
                });
                let response = await p.json();

                if (response) {
                    vm.Video = response;
                    //post formdata
                    if (id == 0 || id == null || id == '' || id == undefined) {
                        let apiUrl = "/api/Videos";
                        postData(vm, apiUrl, refresh);
                    }
                    else {
                        vm.id = id;
                        let apiUrl = "/api/Videos/" + id;
                        updateData(vm, apiUrl, refresh);
                    }
                }
                else {
                    console.log("video Save faild");
                }
            }
            if (validate === "update") {
                let courseIdValue = document.querySelector('#CourseId').value;

                let courseApi = await fetch("/api/Course");
                let courseRes = await courseApi.json();

                let courseName;

                courseRes.forEach(item => {
                    if (item.id == courseIdValue) {
                        courseName = item.name;
                    }
                });

                if (file) {
                    let videoName = document.querySelector('#Name').value;
                    let data = new FormData();
                    data.append("video", file);
                    data.append("videoName", videoName);
                    data.append("courseName", courseName);
                    data.append("id", id);
                    let p = await fetch("/Videos/CreateVideo", {
                        method: "POST",
                        body: data,
                    });
                    let response = await p.json();
                    if (response) {
                        vm.Video = response;
                        //post formdata
                        if (id == 0 || id == null || id == '' || id == undefined) {
                            let apiUrl = "/api/Videos";
                            postData(vm, apiUrl, refresh);
                        }
                        else {
                            vm.id = id;
                            let apiUrl = "/api/Videos/" + id;
                            updateData(vm, apiUrl, refresh);
                        }
                    }
                    else {
                        console.log("video update faild");
                    }
                }
                else {
                    let videoName = value;
                    let data = new FormData();
                    data.append("videoName", videoName);
                    data.append("courseName", courseName);
                    data.append("id", id);
                    let p = await fetch("/Videos/CreateVideo", {
                        method: "POST",
                        body: data,
                    });
                    let response = await p.json();
                    console.log(response)
                    if (response) {
                        vm.Video = response;
                        //post formdata
                        if (id == 0 || id == null || id == '' || id == undefined) {
                            let apiUrl = "/api/Videos";
                            postData(vm, apiUrl, refresh);
                        }
                        else {
                            vm.id = id;
                            let apiUrl = "/api/Videos/" + id;
                            updateData(vm, apiUrl, refresh);
                        }
                    }
                    else {
                        console.log("video update faild");
                    }
                }

            }
        }

        let id = $("#Id").val();
        if (!id) {
            uploadVideo("post", file);
        }
        else {
            let VideoExtension = $("#Extension").val();
            if (VideoExtension) {
                let updatedName = $("#Name").val() + VideoExtension;
                //vm.Video = updatedName;
                uploadVideo("update", updatedName, id, file);
            }
        }


        let CourseId = $("#CourseId").val();
        if (CourseId == "select course") {
            toastr.success("Please fill all the field", "Warning!!!");
        }
        else {
            vm.CourseId = CourseId;
        }
        vm.Name = $("#Name").val();
       
        
    });
}




//load course info
let loadCourseInfo = async (callBackFormValue) => {
    let courseId = document.querySelector('#CourseId');
    let p = await fetch("/api/Course");

    let data = await p.json();

    data.forEach((val) => {
        let option = document.createElement('option');
        courseId.append(option);
        option.append(val.name);
        option.setAttribute('value', val.id);
    })

    callBackFormValue();
}
loadCourseInfo(formValue);



