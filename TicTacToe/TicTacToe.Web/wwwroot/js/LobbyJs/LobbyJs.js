"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/LobbyHub").build();



connection.start().then(function () {
}).catch(function (err) {
    return console.error(err.toString());
});

window.onload = function () {
    document.getElementsByClassName('gameTable')[0].addEventListener('click', MakeMove);
    document.getElementsByClassName('readySection')[0].addEventListener('click', SetPlayerReady);
}


function MakeMove(ev) {
    if (ev.target.tagName == 'BUTTON') {

        //    ev.target.classList.add('FirstPl')
    }

}
connection.on("ConnectPlayer", function (buttonToShow) {
    var button = document.getElementsByClassName(buttonToShow)[0].attributes.removeNamedItem('disabled');
    console.log(button);
    var ul = document.getElementById('chatUl');
    var message = "Player Connected to the game";
    AppendMessage(ul, message);

});

function AppendMessage(ul, stringMessage) {
    var li = document.createElement('li');
    li.textContent = stringMessage;
    ul.appendChild(li);
}

function SetPlayerReady(ev) {
    if(ev.target.tagName=='BUTTON') {
        console.log('TODO Player 2 ready')
    }
}