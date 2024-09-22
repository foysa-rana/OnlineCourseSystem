//load videos
let loadVideos = async () => {
    let queryValue = getUrlVars();
    let queryId = queryValue.id;
    let p = await fetch("/api/AllVideos/" + queryId);
    let data = await p.json();
    let authoeizedPerson = document.querySelector('#authoeizedPerson');
    let unAuthoeizedPerson = document.querySelector('#unAuthoeizedPerson');
    let storeAuthorizedData = "";
    let storeUnAuthorizedData = "";
    let sl = 0;
    data.forEach((item, index) => {
        sl++
        storeAuthorizedData +=
            `<li>
                <a class="nav-link video-link authoeizedPersonVideo" data-id="${item.id}">
                    <div class="icon"><i class="ri-video-line"></i></div>
                    <div class="text">
                        <span>${sl}</span>
                        <span>${item.name}</span>
                    </div>
                </a>
             </li>`;
        storeUnAuthorizedData +=
            `<li>
                <a class="nav-link video-link unAuthoeizedPersonVideo" data-id="${item.id}">
                    <div class="icon"><i class="ri-video-line"></i></div>
                    <div class="text">
                        <span>${sl}</span>
                        <span>${item.name}</span>
                    </div>
                </a>
             </li>`;
    });

    if (unAuthoeizedPerson) {
        unAuthoeizedPerson.innerHTML = storeUnAuthorizedData;
        let unAuthoeizedPersonVideo = document.querySelectorAll('.unAuthoeizedPersonVideo');
        unAuthoeizedPersonVideo.forEach(element => {
            element.addEventListener("click", () => {
                Swal.fire("Please Join the course first.");
            })
        })
    }
    if (authoeizedPerson) {
        authoeizedPerson.innerHTML = storeAuthorizedData;
        let authoeizedPersonVideo = document.querySelectorAll('.authoeizedPersonVideo');
        authoeizedPersonVideo.forEach(element => {
            element.addEventListener("click", async () => {
                let loadContentVideo = document.querySelector('#load-content');
                let videoId = element.getAttribute("data-id");
                let videoApi = await fetch("/api/Videos/" + videoId);
                let videoData = await videoApi.json();

                loadContentVideo.innerHTML =
                    `<div class="text-content px-3 text-center">
                    <div class="header-title mt-3">
                        <h3 class="mt-5">${videoData.name}</h3>
                    </div>
                    <div class="video-content">
                        <video class="course-video" autoplay controls>
                            <source src="../../Content Media/Videos/${videoData.course.name}/${videoData.video}" />
                            Your browser does not support video.
                        </video>
                    </div>
                    <div class="text-start">
                        <p class="description">
                            Lorem ipsum dolor, sit amet consectetur adipisicing elit.
                            Voluptatem quaerat iure ex alias modi reiciendis delectus sequi
                            debitis voluptas doloremque saepe eius magnam esse, nobis facere
                            soluta laborum consequuntur quia ipsum dolorum et nesciunt.
                            Ipsam repudiandae fugiat amet pariatur soluta molestiae
                            incidunt, consequuntur minima, dolore mollitia nesciunt
                            explicabo ex maxime fuga nam. Consectetur beatae ducimus alias
                            molestias rerum, praesentium delectus.
                        </p>
                    </div>
                </div>`;
            })
        })
    }
    
}
loadVideos();