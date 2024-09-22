
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
        toastr.success("Form Submited Successfully", "Success!!!");
        refresh();
    }
    else {
        toastr.warning("Form Submission Failed", "Warning!!!");
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
        toastr.success("Updated Successfully", "Success!!!");
        refresh();
    }
    else {
        toastr.warning("Failed to Upadate", "Warning!!!");
    }
}