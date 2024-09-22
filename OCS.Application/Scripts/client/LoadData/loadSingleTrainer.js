//load trainer
let loadCourse = async () => {
    let queryValue = getUrlVars();
    let queryId = queryValue.id;
    let p = await fetch("/api/Trainer/" + queryId);
    let data = await p.json();
    let loadContent = document.querySelector('.custom-card');
    loadContent.innerHTML =
        `<div class="text-center">
            <img src="../../images/TrainerProfile-img/${data.photo}" class="rounded" alt="${data.fName} ${data.lName}"/>
         </div>

         <div class="text-center mt-3">
            <h5 class="mt-2 mb-0">${data.fName} ${data.lName}</h5>
            <span class="d-block" style="font-size: 11px;">(${data.position})</span>
            <span>${data.jobTitle}</span>

            <div class="px-4 mt-1">
                <p class="fonts">
                    ${data.about}
                </p>
            </div>
         </div>`;
}
loadCourse();