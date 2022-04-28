let cardealerships = [];
let connection = null;
let cardealershipidupdate = -1;
getdata();
setupSignalR();
document.getElementById('updateformdiv').style.display = 'none';


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5822/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CardealershipCreated", (user, message) => {
        getdata();
    });

    connection.on("CardealershipDeleted", (user, message) => {
        getdata();
    });
    connection.on("CardealershipUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}
async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:5822/cardealership')
        .then(x => x.json())
        .then(y => {
            cardealerships = y;
            console.log(cardealerships);
            display();
        });
}





function display() {
    document.getElementById('resultarea').innerHTML = "";
    cardealerships.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
        + t.name + "</td><td>" + t.taxnumber + "</td><td>" + t.country + "</td><td>" +
        `<button type="button" onclick="Remove(${t.id})">Delete</button>` +
        `<button type="button" onclick="showupdate(${t.id})">Update</button>`
            + "</td></tr>";
    });
}

function Remove(id) {
    fetch('http://localhost:5822/cardealership/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}
function showupdate(id) {
    document.getElementById('nameinputupdate').value = cardealerships.find(t => t[`id`] == id)['name'];
    document.getElementById('taxnumberinputupdate').value = cardealerships.find(t => t[`id`] == id)['taxnumber'];
    document.getElementById('countryinputupdate').value = cardealerships.find(t => t[`id`] == id)['country'];
    document.getElementById('updateformdiv').style.display = 'flex';
    cardealershipidupdate = id;
}
    function update() {
        document.getElementById('updateformdiv').style.display = 'none';
        let name = document.getElementById('nameinputupdate').value;
        let taxnumber = document.getElementById('taxnumberinputupdate').value;
        let country = document.getElementById('countryinputupdate').value;
        fetch('http://localhost:5822/cardealership', {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json', },
            body: JSON.stringify(
                {
                    name: name,
                    country: country,
                    taxnumber: taxnumber,
                    id: cardealershipidupdate
                    
                })
        })
            .then(response => response)
            .then(data => {
                console.log('Success:', data);
                getdata();
            })
            .catch((error) => { console.error('Error', error); });

    }
function create() {
    let name = document.getElementById('nameinput').value;
    let taxnumber = document.getElementById('taxnumberinput').value;
    let country = document.getElementById('countryinput').value;
    fetch('http://localhost:5822/cardealership', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                name: name,
                taxnumber: taxnumber,
                country: country
            })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error', error); });

}