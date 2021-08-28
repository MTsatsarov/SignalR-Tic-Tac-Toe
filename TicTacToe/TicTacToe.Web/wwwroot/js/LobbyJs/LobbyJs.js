"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/LobbyHub").build();

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    var p = document.createElement('p');
    var messageP = document.createElement('p');
    messageP.textContent = `${message}`;
p.textContent=`${user}`;
    document.querySelector("main>section>ul").appendChild(li);
   li.appendChild(p);
   li.appendChild(messageP);
});

connection.start().then(function () {
}).catch(function (err) {
    return console.error(err.toString());
});
