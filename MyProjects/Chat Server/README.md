# Chat Server
Date README updated on: January 11th, 2016

## Overview
As a side project during my winter break, I decided to get a headstart on learning some networking basics before I took the class in the fall of 2016.  What originally started as just trying to get a basic chat/server client to work in command prompt, evolved into me diving head-first into windows forms and making a functioning chat client to handle multiple users.

It took me about a weeks worth of work (some days heavy hours, couple days off).  The code itself was probably destroyed and rewritten from the ground up about 20 times before I was finally understanding exactly what I was doing.  By the time I figured out what I was doing, I would keep having a new idea I would want to implement which would require me to rebuild the code in a cleaner way.  It was an excellent project for me to learn with.

## Future Potential Features To Add
- Give User ability to manually modify port number with a console prompt
- Give user ability to restrict number of total clients
- Give user ability to kick clients
- Handle client usernames
- Configure server to allow user to view certain things
  - View clients connected
  - View conversations between clients
- Graceful server shutdowns
- Message of the day to connected users
- Display when a user connects to all the other clients
- Add ability to password the server

## Known Bugs
- If user connects/disconnects too fast, server can get confused and not remove the user from the list? (Not certain, but bug does occur)
- If user spams chat, username will bunch up two or three times (Likely a client-side problem)
