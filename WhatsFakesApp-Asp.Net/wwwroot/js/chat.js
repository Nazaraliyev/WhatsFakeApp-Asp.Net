"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chat").build();

//Disable send button until connection is established
//document.getElementById("sendButton").disabled = /*true*/;

connection.on("ReceiveMessage", function (message, sender) {

    var receiverId = document.getElementById("receiverId").value;

    if (receiverId == sender) {
        var ul = document.createElement("ul");
        ul.classList = "receiver msg";

        var li = document.createElement("li");

        var p = document.createElement("p");
        p.innerHTML = message;

        var span = document.createElement("span");
        span.innerHTML = "12:02";

        li.appendChild(p);
        li.appendChild(span);
        ul.appendChild(li);

        console.log(ul);

        document.getElementById("chat-messages-container").appendChild(ul);
    }

});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("send-message-btn").addEventListener("click", function (event) {
    var message = document.getElementById("message-input").value;
    var receiverId = document.getElementById("receiverId").value;
    var senderId = document.getElementById("senderId").value;
    if (message != "") {
        connection.invoke("SendMessage", message, receiverId, senderId).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();


        var ul = document.createElement("ul");
        ul.classList = "sender msg";

        var li = document.createElement("li");

        var p = document.createElement("p");
        p.innerHTML = message;

        var span = document.createElement("span");
        var date = new Date();
        var dateNow = date.getHours().toString().padStart(2, "0") + ":" + date.getMinutes().toString().padStart(2, "0");
        span.innerHTML = dateNow;

        li.appendChild(p);
        li.appendChild(span);
        ul.appendChild(li);

        document.getElementById("message-input").value = "";

        document.getElementById("chat-messages-container").appendChild(ul);
    }
});