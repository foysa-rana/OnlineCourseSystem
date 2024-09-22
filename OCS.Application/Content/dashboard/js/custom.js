// count courses 
let countCourses = async () => {
    let p = await fetch("/api/Course");
    let data = await p.json();

    let count = Object.keys(data).length;

    document.querySelector("#total-course").innerHTML = count;
}
countCourses();

// count trainers
let countTrainers = async () => {
    let p = await fetch("/api/Trainer");
    let data = await p.json();

    let count = Object.keys(data).length;

    document.querySelector("#total-trainer").innerHTML = count;
}
countTrainers();

// count seminars
let countSeminars = async () => {
    let p = await fetch("/api/Seminar");
    let data = await p.json();

    let count = Object.keys(data).length;

    document.querySelector("#total-seminar").innerHTML = count;
}
countSeminars();
