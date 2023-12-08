
//get url  id
let getUrlVars = () => {
    let vars = [], hash;
    let hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (let i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}

//post data
let postData = async (data, url, refresh) => {
    let p = await fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
    });

    let response = await p.json();

    if (response > 0) {
        console.log("Save Successful");
        refresh();
    }
    else {
        console.log("Save faild");
    }
}

//update data
let updateData = async (data, url, refresh) => {
    let p = await fetch(url, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
    });
    let response = await p.json();

    if (response > 0) {
        console.log("Update Successful");
        refresh();
    }
    else {
        console.log("Update Failed");
    }
}