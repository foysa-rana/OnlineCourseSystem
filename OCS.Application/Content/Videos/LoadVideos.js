//get url  id
let getUrlVars = () => {
    let vars = [], hash;
    let hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (let i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}

let videoLength = () => {
    let duration = document.querySelectorAll('.duration');
    let videoContent = document.querySelectorAll('.video-duration');

    videoContent.forEach((content, index) => {
        content.onloadedmetadata = function () {
            let videoDuration = Number(Math.ceil(content.duration));
            let hour = Math.floor(videoDuration / 3600);
            let min = Math.floor((videoDuration % 3600) / 60);
            let sec = ((videoDuration % 3600) % 60)
            let time = `${hour}:${min}:${sec}`;
            let timeArr = time.split(":");
            let hourTime = timeArr[0];
            let minTime = timeArr[1];
            let secTime = timeArr[2];
            if (hourTime.length == 1) {
                hour = "0" + timeArr[0];
            }
            if (minTime.length == 1) {
                min = "0" + timeArr[1];
            }
            if (secTime.length == 1) {
                sec = "0" + timeArr[2];
            }
            if (hour == 0) {
                duration[index].innerHTML = `${min}:${sec}`;
            }
            else {
                duration[index].innerHTML = `${hour}:${min}:${sec}`;
            }
        };
        
    })
}

//load videos
let loadVideos = async (callBack) => {
    let queryValue = getUrlVars();
    let queryId = queryValue.id;
    let p = await fetch("/api/AllVideos/" + queryId);
    let data = await p.json();
    let tableBody = document.querySelector('.table-body');
    let storeData = "";
    data.forEach((item, index) => {
        storeData +=
            `<div class="table-row">
                <div class="d-flex show-video position-relative">
                    <div class="position-relative">
                        <video src="../../Content Media/Videos/${item.course.name}/${item.video}" class="video-duration"></video>
                        <span class="duration">10:30</span>
                    </div>
                    <p class="course-name">
                        <span class="name d-block">${item.name}</span>
                        <span class="trainer d-block small"></span>
                    </p>
                </div>
                <div class="video-action">
                    <span class="video-icon">
                        <div class="d-inline-flex">
                            <a class="edit-btn" href="CreateVideo?id=${item.id}"><i class="fa-solid fa-pen"></i></a>
                            <a class="delete-btn" data-id="${item.id}"><i class="fa-solid fa-trash"></i></a>
                        </div>
                    </span>
                    <span class="views">15k&nbsp;Views</span>
                </div>
            </div>`;
    });
    tableBody.innerHTML = storeData;
    callBack();
}
loadVideos(videoLength);

$(document.body).on("click", ".delete-btn", function () {
    let id = $(this).attr("data-id");
    bootbox.confirm("Are You Sure Want to Delete This Data?",
        function (result) {
            if (result) {
                $.ajax({
                    url: "/api/Videos/" + id,
                    method: "DELETE",
                    success: function () {
                        toastr.success("Video has been deleted successfully");
                        loadVideos();
                    },
                    error: function (request, status, error) {
                        var response = jQuery.parseJSON(request.responseText);
                        toastr.error(response.message, "Error");
                    }
                });
            }
        });
})