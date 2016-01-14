# Chat Client
Date README updated on: January 14th, 2016

## Overview
As a side project during my winter break, I decided to get a headstart on learning some networking basics before I took the class in the fall of 2016. What originally started as just trying to get a basic chat/server client to work in command prompt, evolved into me diving head-first into windows forms and making a functioning chat client to handle multiple users.

The chat client originally ran in the command prompt, but I quickly realized that if I was going to make multiple users connected to the server, a terminal-based chat would not be logical.  Handling incoming data while trying to write outgoing data simply would not work well for the way I was coding it.  Instead, I decided to familarize myself with forms and put together something that would suit my needs.

For reference, this program was built after my Intro to C# class was finished at Manchester Community College.

## Future Potential Features To Add
- Sound notification for incoming messages
- Randomly colored usernames for easy distinction
- Prompt user to enter a username when program is started
- ~~Restrict user from resizing the window~~  (Added 1/11/2016)
- ~~Allow user to select server IP and Port~~  (Added 1/11/2016)

## Known Bugs
- Spamming connect/disconnect can break the server
- Spamming send button can send multiple lines in one byte stream
- Modifying the settings page while connected to server brings unfortunate circumstances
