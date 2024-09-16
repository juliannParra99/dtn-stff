"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message,sentAt) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.

    var sentAtDate = new Date(sentAt);

    // Format the date as dd/mm/yyyy
    var formattedDate = sentAtDate.toLocaleDateString([], { day: '2-digit', month: '2-digit', year: 'numeric' });

    // Format the time as hh:mm in 24-hour format
    var formattedTime = sentAtDate.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });

    // Set the content with a more professional format
    li.textContent = `${user} - ${formattedDate} at ${formattedTime}: ${message}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});