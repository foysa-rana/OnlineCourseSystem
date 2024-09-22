let loadUserProfile = async () => {
    let selectNested = document.querySelector('#selectNested');

    let p = await fetch("/api/User/Specific/" + userIdentity);
    let data = await p.json();
    let storeData = "";
    let arrCount = 0;
    data[0].forEach(value => {
        storeData +=
            `<li class="nav-item">
                <a href="/CourseView/Course?id=${value}" class="nav-link">${data[1][arrCount]}</a>
            </li>`;
        arrCount++;
    })
    selectNested.innerHTML = storeData;
}
loadUserProfile();