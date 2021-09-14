"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/LobbyHub").build();



connection.start().then(function () {
}).catch(function (err) {
    return console.error(err.toString());
});

window.onload = function () {
    document.getElementsByClassName('gameTable')[0].addEventListener('click', MakeMove);
    document.getElementById('StartGame').addEventListener('click', SetGameReady)
}


function MakeMove(ev) {
    if (ev.target.tagName == 'BUTTON') {

        //    ev.target.classList.add('FirstPl')
    }

}
connection.on("ConnectPlayer", function () {

    var ul = document.getElementById('chatUl');
    var message = "Player Connected to the game";
    AppendMessage(ul, message);

});

function AppendMessage(ul, stringMessage) {
    var li = document.createElement('li');
    li.textContent = stringMessage;
    ul.appendChild(li);
}
connection.on('StartTheGame', function (message) {
    var ul = document.getElementById('chatUl');
    AppendMessage(ul, message);
});
function SetGameReady() {
    connection.invoke('StartGame')
}

connection.on('GameAvailable', function () {
    document.getElementById('StartGame').attributes.removeNamedItem('disabled');
})

connection.on('GameReady', function () {
    document.querySelectorAll('.gameTable>tbody>tr>td>button').forEach(x => x.attributes.removeNamedItem('disabled'));
});