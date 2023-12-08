//data list action button
let dataListAction = () => {
    let dataListBtn = document.querySelectorAll('.action-btn');
    let action = document.querySelectorAll('.action');
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
