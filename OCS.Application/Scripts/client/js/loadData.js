//load recent courses
let recentCourses = async () => {
    let p = await fetch("/api/Course/GetAllOrderByDescendingRecent");
    let data = await p.json();
    let recentCourseItem = document.querySelector('#recent-course-item');
    let storeData = "";
    let count = 0;
    data.forEach((item, index) => {
        count++;
        if (count <= 10) {
            storeData +=
                `<div class="item card swiper-slide">
                    <img src="../../images/Course-img/${item.photo}"
                            alt="front-end development" />
                    <div class="card-body text-center">
                        <h5 class="title">${item.name}</h5>
                        <p class="trainer">Trainer : ${item.trainer.fName} ${item.trainer.lName}</p>
                        <h5 class="fee">$${item.fee}</h5>
                        <a href="/CourseView/Course?id=${item.id}" class="btn custom-btn">Read More</a>
                    </div>
                </div>`;
        }
    });
    recentCourseItem.innerHTML = storeData;
}
recentCourses();

//load popular courses
let popularCourses = async () => {
    let p = await fetch("/api/Course/GetAllOrderByDescending");
    let data = await p.json();
    let popularCourseItem = document.querySelector('#popular-course-item');
    let storeData = "";
    let count = 0;
    data.forEach((item, index) => {
        count++;
        if (count <= 10) {
            storeData +=
                `<div class="item card swiper-slide">
                    <img src="../../images/Course-img/${item.photo}"
                            alt="front-end development" />
                    <div class="card-body text-center">
                        <h5 class="title">${item.name}</h5>
                        <p class="trainer">Trainer : ${item.trainer.fName} ${item.trainer.lName}</p>
                        <h5 class="fee">$${item.fee}</h5>
                        <a href="/CourseView/Course?id=${item.id}" class="btn custom-btn">Read More</a>
                    </div>
                </div>`;
        }
        
    });
    popularCourseItem.innerHTML = storeData;
}
popularCourses();

//load seminar
let loadSeminar = async () => {
    let p = await fetch("/api/Seminar");
    let data = await p.json();
    let seminarItem = document.querySelector('#seminar-item');
    let storeData = "";
    data.forEach((item, index) => {
        storeData +=
            `<div class="swiper-slide">
                <div class="card">
                    <div class="row-custom position-relative">
                        <div class="text-content bg-svg text-white">
                            <div class="card-body text-center">
                                <h4 class="card-title">${item.name}</h4>
                                <p class="schedule">
                                    Schedule at : ${item.time}
                                </p>
                                <p class="card-text">
                                    ${item.description}
                                </p>
                                <a class="btn custom-btn notify-btn">Notify Me</a>
                            </div>
                        </div>
                        <div class="img-content">
                            <img src="../../images/Seminar-img/${item.photo}"
                                    alt="front-end development" />
                        </div>
                        <div class="label">Upcoming</div>
                    </div>
                </div>
            </div>`;
    });
    seminarItem.innerHTML = storeData;

    let notifyBtn = document.querySelectorAll('.notify-btn');
    notifyBtn.forEach(item => {
        item.addEventListener("click", () => {
            if (userAuthorized) {
                Swal.fire("You will be notified through your email");
            }
            else {
                Swal.fire("Please Sign in first in order to be notified...");
            }
        })
    })
}
loadSeminar();

//load trainer
let loadTrainer = async () => {
    let p = await fetch("/api/Trainer");
    let data = await p.json();
    let trainerItem = document.querySelector('#trainer-item');
    let storeData = "";
    data.forEach((item, index) => {
        storeData +=
            `<div class="card">
                <div class="img-content overlay-radius">
                    <div class="border-circle">
                        <img src="../../images/TrainerProfile-img/${item.photo}"
                                alt="David" />
                    </div>
                </div>
                <div class="text-content text-center">
                    <h4 class="name mt-3">${item.fName} ${item.lName}</h4>
                    <p class="position small mb-3">${item.position}</p>
                    <p class="details mb-3">
                        ${item.about}
                    </p>
                    <a href="Home/Trainer?id=${item.id}" class="btn custom-btn mb-4">Read More</a>
                </div>
            </div>`;
    });
    trainerItem.innerHTML = storeData;
}
loadTrainer();