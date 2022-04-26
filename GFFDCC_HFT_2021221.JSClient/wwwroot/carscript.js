let cars = [];
let connection = null;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5822/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CarCreated", (user, message) => {
        getdata();
    });

    connection.on("CarDeleted", (user, message) => {
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
    await fetch('http://localhost:5822/car')
        .then(x => x.json())
        .then(y => {
            cars = y;
            //console.log(cars);
            display();
        });
}





function display() {
    document.getElementById('resultarea').innerHTML = "";
    cars.forEach(t => {
        console.log(t);
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
        + t.model + "</td><td>" + t.basePrice + "</td><td>" + t.brandId + "</td><td>"
        + t.carDealershipID + "</td><td>" +
            `<button type="button" onclick="Remove(${t.id})">Delete</button>`
            + "</td></tr>";
    });
}

function Remove(id) {
    fetch('http://localhost:5822/car/' + id, {
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
    let model = document.getElementById('nameinput').value;
    let baseprice = parseInt(document.getElementById('priceinput').value);
    let brandid = parseInt(document.getElementById('brandidinput').value);
    let cardealershipid = parseInt(document.getElementById('cardealershipidinput').value);
    fetch('http://localhost:5822/car', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                model: model,
                basePrice: baseprice,
                brandId: brandid,
                carDealershipID: cardealershipid
            })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error', error); });

}