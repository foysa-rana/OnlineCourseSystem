//searchbar 
let loadSearchBar = () => {
    let searchBar = document.querySelector("#search-bar");
    searchBar.innerHTML = `<form class="d-none d-sm-inline-block form-inline mr-auto ml-md-3 my-2 my-md-0 mw-100 navbar-search">
                                <div class="input-group">
                                    <input type="text" id="searcharea"
                                            class="form-control bg-light border-0 small"
                                            placeholder="Search for..."
                                            aria-label="Search"
                                            aria-describedby="basic-addon2" />
                                    <div class="input-group-append">
                                        <button class="btn btn-primary" type="button">
                                            <i class="fas fa-search fa-sm"></i>
                                        </button>
                                    </div>
                                </div>
                            </form>`;

    let searchArea = document.querySelector("#searcharea");
    searchArea.addEventListener("keyup", async () => {
        let que = searchArea.value;
        if (que) {
            let p = await fetch("/api/Course/Search/" + que);
            let data = await p.json();
            let dataListTable = document.querySelector('#data-list-table');
            let storeData = "";
            data.forEach((item, index) => {
                storeData +=
                    `<tr>
                <td>${item.trainer.fName} ${item.trainer.lName}</td>
                <td>${item.name}</td>
                <td>${item.duration}</td>
                <td class="d-flex">
                    <span class="bullet-active" id="status-bullet"></span>
                    <span class="status">Active</span>
                </td>
                <td class="action-icon">
                    <i class="fa-solid fa-ellipsis-vertical action-btn"></i>
                    <span class="action">
                        <a class="edit-btn" href="CreateCourse?id=${item.id}"><i class="fa-solid fa-pen"></i></a>
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
        }
        else {
            getListData();
        }
    })
}
loadSearchBar();

//get all data list
let getListData = async () => {
    let p = await fetch("/api/Course");
    let data = await p.json();
    let dataListTable = document.querySelector('#data-list-table');
    let storeData = "";
    data.forEach((item, index) => {
        storeData +=
            `<tr>
                <td>${item.trainer.fName} ${item.trainer.lName}</td>
                <td>${item.name}</td>
                <td>${item.duration}</td>
                <td class="d-flex">
                    <span class="bullet-active" id="status-bullet"></span>
                    <span class="status">Active</span>
                </td>
                <td class="action-icon">
                    <i class="fa-solid fa-ellipsis-vertical action-btn"></i>
                    <span class="action">
                        <a class="edit-btn" href="CreateCourse?id=${item.id}"><i class="fa-solid fa-pen"></i></a>
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
    bootbox.confirm("Are You Sure Want to Delete This Data?",
        function (result) {
            if (result) {
                $.ajax({
                    url: "/api/Course/" + id,
                    method: "DELETE",
                    success: function () {
                        toastr.success("Data has been deleted successfully");
                        getListData();
                    },
                    error: function (request, status, error) {
                        var response = jQuery.parseJSON(request.responseText);
                        toastr.error(response.message, "Error");
                    }
                });
            }
        });
})