//get all data list
let getListData = async () => {
    let p = await fetch("/api/Course");
    let data = await p.json();
    let dataListTable = document.querySelector('#data-list-table');
    let storeData = "";
    data.forEach((item, index) => {
        storeData +=
            `<tr>
                <td>${item.trainerId}</td>
                <td>${item.name}</td>
                <td>${item.duration}</td>
                <td class="d-flex">
                    <span class="bullet-active" id="status-bullet"></span>
                    <span class="status">Active</span>
                </td>
                <td class="action-icon">
                    <i class="fa-solid fa-ellipsis-vertical action-btn"></i>
                    <span class="action">
                        <a class="edit-btn" href="CreateTrainers?id=${item.id}"><i class="fa-solid fa-pen"></i></a>
                        <a class="delete-btn" data-id="${item.id}"><i class="fa-solid fa-trash"></i></a>
                        <a class="details-btn" href="#"><i class="fa-solid fa-circle-info"></i></a>
                    </span>
                </td>
            </tr>`;
    });
    dataListTable.innerHTML = storeData;
    //data list action button
    let dataListAction = async () => {
        let dataListBtn = await document.querySelectorAll('.action-btn');
        let action = await document.querySelectorAll('.action');
        dataListBtn.forEach((item, index) => {
            item.addEventListener('click', () => {
                action.forEach(element => {
                    element.classList.remove('action-show')
                });
                action[index].classList.add('action-show')

            });
        })
    }
    dataListAction();

    //delete data

}

getListData();

$(document.body).on("click", ".delete-btn", function () {
    let id = $(this).attr("data-id");
    $.ajax({
        url: "/api/Course/" + id,
        type: "DELETE",
        success: () => {
            getListData();
        },
        error: function (request, status, error) {
            let response = jQuery.parseJSON(request.responseText);
            console.log(response.message, "Error");
        }
    })
})