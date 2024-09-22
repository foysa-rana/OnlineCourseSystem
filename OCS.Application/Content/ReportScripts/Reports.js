$(document.body).on("click",
    "#trainer-report",
    async () => {
        let radioValue = $("input[name='trainer-report']:checked").val();

        //All Employee
        if(radioValue === "all trainer") {
            let getData = await fetch("/Reports/AllTrainer");
            let data = getData.json();

            let postData = await fetch("/Reports/GetAllTrainer", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(data),
            });
            let response = await postData.json();

            if(response != "" && response != null) {
                $("#pdf").attr("href", response);
                let reportBox = $("#pdf").fancybox({
                    'frameWidth': 85,
                    'frameHeight': 495,
                    'overlayShow': true,
                    'hideOnContentClick': false,
                    'type': 'iframe',
                    helpers: {
                        // prevents closing when clicking OUTSIDE fancybox
                        overlay: { closeClick: false }
                    }
                }).trigger('click');
            }
        }

        //Individual 
        if (radioValue === "individual trainer") {
            let reportModal = document.querySelector("#report-modal");
            reportModal.classList.add('d-block');
            if (reportModal.classList.contains('d-block')) {
                let reportModalClose = document.querySelector("#report-modal-close");
                reportModalClose.addEventListener('click', () => {
                    reportModal.classList.remove('d-block');
                });
            }

            //method call
            loadTrainerInfo();

            let individualTrainerReport = document.querySelector('#individual-trainer-report');

            individualTrainerReport.addEventListener('click', async () => {
                let trainerId = document.querySelector('#TrainerId').value;
                let getData = await fetch("/Reports/IndividualTrainer/" + trainerId);
                let data = getData.json();

                let postData = await fetch("/Reports/GetIndividualTrainer/" + trainerId, {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json",
                    },
                    body: JSON.stringify(data),
                });
                let response = await postData.json();

                if (response != "" && response != null) {
                    $("#pdf").attr("href", response);
                    let reportBox = $("#pdf").fancybox({
                        'frameWidth': 85,
                        'frameHeight': 495,
                        'overlayShow': true,
                        'hideOnContentClick': false,
                        'type': 'iframe',
                        helpers: {
                            // prevents closing when clicking OUTSIDE fancybox
                            overlay: { closeClick: false }
                        }
                    }).trigger('click');
                }
            })
        }
    });

//load all trainer
let loadTrainerInfo = async () => {
    let trainerId = document.querySelector('#TrainerId');
    let p = await fetch("/api/Trainer");

    let data = await p.json();

    data.forEach((val) => {
        let option = document.createElement('option');
        trainerId.append(option);
        option.append(`${val.fName} ${val.lName} (Trainer ID : ${val.trainerId}`);
        option.setAttribute('value', val.id);
    })
}