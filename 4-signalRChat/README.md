# SignalR Chat Application
This project is a simple chat application built using ASP.NET Core 8.0 MVC and SignalR. The app enables real-time communication between multiple users by leveraging the SignalR library for handling server-client communication over WebSockets. Users can enter their name and send messages, which are broadcast to everyone currently connected to the chat.

## Key Features

- Real-time messaging: Users can send and receive messages in real-time without reloading the page.
- User identification: Each message is associated with the user who sent it, and all connected users can see both the message and the sender.
- Multiple users support: The app allows multiple users to join the chat, with each user seeing all messages sent by others in real-time.
- Razor Pages & JavaScript integration: The front-end uses Razor Pages for rendering and JavaScript to manage SignalR communication.
 
## Technologies Used
- ASP.NET Core 8.0 
- SignalR: Used for enabling real-time communication between the server and clients.
- Razor Pages 
- JavaScript/HTML/CSS 



## SignalR Overview

SignalR is a library that simplifies adding real-time web functionality to applications. It enables server-side code to push content to clients immediately, making it perfect for use cases like chat apps, notifications, or live dashboards. This project demonstrates the use of SignalR to send and receive messages between a server and multiple clients over WebSockets.
