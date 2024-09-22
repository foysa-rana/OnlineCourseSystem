//get url id
//let getUrlVars = () => {
//    let vars = [], hash;
//    let hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
//    for (let i = 0; i < hashes.length; i++) {
//        hash = hashes[i].split('=');
//        vars.push(hash[0]);
//        vars[hash[0]] = hash[1];
//    }
//    return vars;
//}

//load course data
let loadCourseData = async () => {
    let query = getUrlVars();
    let id = query.id;
    let p = await fetch("/api/course/" + id);
    let data = await p.json();

    let courseInfo = document.querySelector('#course-info');
    let payBtn = document.querySelector('.pay-btn');
    let subTotal = document.querySelector('#subtotal');
    let discount = document.querySelector('#discount');
    let total = document.querySelector('#total');

    courseInfo.innerHTML =
        `<div id="my" class="img-details">
            <img src="../../images/Course-img/${data.photo}" class="d-block w-100">
        </div>
        <h4 class="text-center mt-3">${data.name}</h4>
        <p class="text-center mt-3">Trainer : ${data.trainer.fName} ${data.trainer.lName}</p>
        <p class="dis my-3 info">${data.description}</p>
        <div>
            <p class="dis footer my-3"><span class="fw-bold">Attention : </span><span style="color: #ff4949;">For testing purposes there is no payment gateway right now. Just click on the pay option you will be able to view this course videos</span></p>
        </div>`;
    payBtn.innerHTML = "Pay $" + (data.fee - 5);
    subTotal.innerHTML = "$" + data.fee;
    discount.innerHTML = "$5";
    total.innerHTML = "$" + (data.fee - 5);
}
loadCourseData();

//load user data
let loadUserData = () => {
    window.addEventListener("load", async () => {
        let p = await fetch("/api/User/" + userIdentity);
        let data = await p.json();
        let userFullName = document.querySelector('#user-full-name').value = data.fName + data.lName;
        let email = document.querySelector('#email').value = data.email;
    })
}
loadUserData();

// authorization
let authorization = () => {
    let payBtn = document.querySelector('.pay-btn');
    if (userAuthorized) {
        payBtn.addEventListener("click", async () => {
            let vm = {};
            let query = getUrlVars();
            vm.CourseId = query.id;
            let p = await fetch("/api/User/Patch/" + userIdentity, {
                method: "PATCH",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(vm),
            })
            let data = await p.json();
            if (data > 0) {
                //coursePatch Invoke
                coursePatch();
                Swal.fire({
                    title: "Course purchased successfully...",
                    icon: "success",
                    confirmButtonColor: "#3085d6",
                    confirmButtonText: "Ok"
                }).then((result) => {
                    if (result.isConfirmed) {
                        window.location.href = "/CourseView/Course?id=" + data;
                    }
                });
            }
            else if (data == 0) {
                Swal.fire("There was a error please fill out the information carefully...");
            }
            else if (data[0] == "exist") {
                Swal.fire({
                    title: "You have already purchased this course....",
                    confirmButtonColor: "#3085d6",
                    confirmButtonText: "Ok"
                }).then((result) => {
                    if (result.isConfirmed) {
                        window.location.href = "/CourseView/Course?id=" + data[1];
                    }
                });
            }
        })
    }
    else {
        payBtn.addEventListener("click", () => {
            Swal.fire("Please Sign in first in order to join this course...");
        })
    }
}
authorization();

let coursePatch = async () => {
    let query = getUrlVars();
    let id = query.id;
    let vm = {};
    vm.PurchaseCount = 1;
    let p = await fetch("/api/Course/Patch/" + id, {
        method: "PATCH",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(vm),
    });
    let data = await p.json();
}
