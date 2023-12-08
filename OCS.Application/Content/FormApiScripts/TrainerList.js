//get all data list
let getListData = async () => {
    let p = await fetch("/api/Trainer");
    let data = await p.json();
    console.log(data);
    let dataListTable = document.querySelector('#data-list-table');
    let storeData = "";
    data.forEach((item, index) => {
        storeData += 
            `<tr>
                <td>${item.fName} ${item.lName}</td>
                <td>${item.position}</td>
                <td>${item.email}</td>
                <td>${item.phone}</td>
                <td class="d-flex">
                    <span class="bullet-active" id="status-bullet"></span>
                    <span class="status">Active</span>
                </td>
                <td class="action-icon">
                    <i class="fa-solid fa-ellipsis-vertical action-btn"></i>
                    <span class="action">
                        <i class="fa-solid fa-pen"></i>
                        <i class="fa-solid fa-trash"></i>
                        <i class="fa-solid fa-circle-info"></i>
                    </span>
                </td>
            </tr>`;  
    });
    dataListTable.innerHTML = storeData;
}
    
getListData();