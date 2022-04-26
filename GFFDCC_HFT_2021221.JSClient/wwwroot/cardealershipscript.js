let cardealerships = [];
let connection = null;
getdata();
setupSignalR();


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
            //console.log(cars);
            display();
        });
}





function display() {
    document.getElementById('resultarea').innerHTML = "";
    cardealerships.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
        + t.name + "</td><td>" + t.taxnumber + "</td><td>" + t.country + "</td><td>" +
            `<button type="button" onclick="Remove(${t.id})">Delete</button>`
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