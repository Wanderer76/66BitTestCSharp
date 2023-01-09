"use strict";


const connection = new signalR.HubConnectionBuilder()
    .withUrl("/footballerHub")
    .configureLogging(signalR.LogLevel.Information)
    .withAutomaticReconnect()
    .build();


connection.on("show_data", function (players) {
    console.log(players)
    var item = document.getElementById("footballersTable");

    var playersJson = JSON.parse(players);
    buildTable(playersJson, item)
});


function buildTable(data, table) {
    table.innerHTML = '';
    var head = document.createElement('tr');
    head.innerHTML =
          '<th>Имя</th>             '
        + '<th>Фамилия</th>         '
        + '<th>Пол</th>             '
        + '<th>Дата рождения</th>   '
        + '<th>Название команды</th>'
        + '<th>Страна</th>          '
        + '<th></th>                '
        + '<th></th>                ';
    table.appendChild(head);
    for (var i = 0; i < data.length; i++) {
        let output = document.createElement('tr');

        var name = document.createElement('td');
        name.textContent = data[i].name;

        var surname = document.createElement('td');
        surname.textContent = data[i].surname;
        var birthdate = document.createElement('td');
        birthdate.textContent = data[i].birthdate;

        var gender = document.createElement('td');
        gender.textContent = data[i].gender;

        var team = document.createElement('td');
        team.textContent = data[i].team;

        var country = document.createElement('td');
        country.textContent = data[i].country;

        var edit = document.createElement('td');
        var editLink = document.createElement('a');
        editLink.href = '/Footballer/UpdateFootballer/' + data[i].id;
        editLink.textContent = 'Редактирование';
        edit.appendChild(editLink);

        var remove = document.createElement('td');
        var removeLink = document.createElement('a');
        removeLink.href = '/Footballer/DeleteFootballer/' + data[i].id;
        removeLink.textContent = 'Удалить';
        remove.appendChild(removeLink);


        output.appendChild(name);
        output.appendChild(surname);
        output.appendChild(gender);
        output.appendChild(birthdate);
        output.appendChild(team);
        output.appendChild(country);
        output.appendChild(edit);
        output.appendChild(remove);

        table.appendChild(output);
    }

}


async function start() {
    try {
        console.assert(connection.state === signalR.HubConnectionState.Connected);
        await connection.start();
        console.log("SignalR Connected.");
        await connection.invoke("SendFootballers")
    } catch (err) {
        console.assert(connection.state === signalR.HubConnectionState.Disconnected);
        console.log(err);
        setTimeout(() => start(), 5000);
    }
}

connection.onclose(async () => {
    await start();
});
start();
