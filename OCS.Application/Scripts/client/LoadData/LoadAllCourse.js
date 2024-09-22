let loadCourses = async () => {
    let p = await fetch("/api/Course");
    let data = await p.json();

    let course = document.querySelector('#load-course');
    let storeData = "";

    data.forEach(item => {
        storeData += 
            `<div class="item card">
                <img src="../../images/Course-img/${item.photo}"
                        alt="" />
                <div class="card-body text-center">
                    <h5 class="title">${item.name}</h5>
                    <h5 class="fee">$${item.fee}</h5>
                    <p class="trainer">
                        Trainer :
                        <a href="#" class="nav-link d-inline-block">${item.trainer.fName} ${item.trainer.lName}</a>
                    </p>
                    <p class="duration">Duration : ${item.duration}</p>
                    <a href="/CourseView/Course?id=${item.id}" class="btn custom-btn">Read More</a>
                </div>
            </div>`
    });
    console.log(course)
    course.innerHTML = storeData;
}
loadCourses();