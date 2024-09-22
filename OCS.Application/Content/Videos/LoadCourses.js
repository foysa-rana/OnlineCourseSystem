//load courses
let loadCourses = async () => {
    let p = await fetch("/api/Course");
    let data = await p.json();
    let tableBody = document.querySelector('.table-body');
    let storeData = "";
    const coursesId = [];
    data.forEach((item, index) => {
        storeData +=
            `<a class="view-videos" href="VideoList?id=${item.id}">
                <div class="table-row">
                    <div class="d-flex course">
                        <img src="../../images/Course-img/${item.photo}" alt="" />
                        <p class="course-name">
                            <span class="name d-block">${item.name}</span>
                            <span class="trainer d-block small">${item.trainer.fName} ${item.trainer.lName}</span>
                        </p>
                    </div>
                    <div class="video-count" data-id=${item.id}>0 Videos</div>
                </div>
            </a>`;
        coursesId.push(item.id);
    });
    tableBody.innerHTML = storeData;
    
    let videoCount = document.querySelectorAll('.video-count');
    videoCount.forEach(async value => {
        let id = value.getAttribute("data-id");
        let videosApi = await fetch("/api/Course/Videos/" + id);
        let videosData = await videosApi.json();
        value.innerHTML = videosData + "&nbspVideos";
    })
}
loadCourses();