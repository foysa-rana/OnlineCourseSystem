//load course
let loadCourse = async () => {
    let queryValue = getUrlVars();
    let queryId = queryValue.id;
    let p = await fetch("/api/Course/" + queryId);
    let data = await p.json();
    let loadContent = document.querySelector('#load-content');
    let sidebarTitle = document.querySelector('.sidebar-title');
    loadContent.innerHTML = 
        `<div class="img-content">
            <img src="../../images/Course-img/${data.photo}" alt="" />
        </div>
        <div class="text-content px-3 text-center">
            <div class="header-title mt-3">
                <h3>${data.name}t</h3>
            </div>
            <h5 class="fee">$${data.fee}</h5>
            <p class="trainer">
                Trainer :
                <a href="#" class="nav-link d-inline-block">${data.trainer.fName} ${data.trainer.lName}</a>
            </p>
            <p class="duration">Duration : ${data.duration}</p>
            <a  class="btn custom-btn join-button" data-id="${data.id}">Join Now</a>
            <div class="text-start">
                <p class="description">
                    ${data.description}
                </p>
            </div>
        </div>`;
    sidebarTitle.innerHTML = data.name;
    let joinButton = document.querySelector('.join-button');
    if (userAuthorized) {
        let id = joinButton.getAttribute("data-id");
        joinButton.setAttribute("href", "/Payment/Checkout?id=" + id);
    }
    if (!joinButton.getAttribute("href")) {
        joinButton.addEventListener("click", () => {
            Swal.fire("Please Sign in first in order to join this course...");
        });
    }
}
loadCourse();

