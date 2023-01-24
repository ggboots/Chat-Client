# Chat Client App

<img src="https://github.com/ggboots/Chat-Client/blob/main/src/cSharp_logo.png" alt="CSharpLogo" style="width:100px;"/>
<img src="https://github.com/ggboots/Chat-Client/blob/main/src/netcore_logo.png" alt="netcore" style="width:100px;"/>
Simple Chat Application for Users to message each other, the program is server so the server establishes a Socket for each Client to connect to its port, data is passed around using TCP protocol, 
the chat features user command which can be used to create and save usernames to a database or establish users as Moderator, so that they can kick users from chat

Was written in C#, built ontop of the .Net Core 3.1 Framework,
Windows Forms was used for the UI and TCP class were inheritied when creating a new user windows, SQlite was used as backend database when saving new users and for retrieving existing user data

|                                                 |                                                  |
| :---------------------------------------------: | :----------------------------------------------: |
| ![ChatPreview1](/src/ChatMessageAppPreview.png) | ![ChatPreview2](/src/ChatMessageAppPreview2.png) |

### Built using

- .Net Core 3.1 Framework
- NuGut Package Manager
- SQLite Database
- WinForms (UI)
- Visual Studio Solution (.sln)

<p align="center">
  <img src="https://github.com/ggboots/Chat-Client/blob/main/src/ChatClientApp.gif" alt="ChatClient GIF" style="width: 640px;"/>
</p>

---

Command Cheatsheet
| | <font size="1">_list of available commands that can be used_ </font> |
|-----------|------------------------------------------------------------------------------------------|
| **!login** | <font size="2">_login to existing user in database_</font>|
| **!username** | <font size="2">_Creates new user and save to database once !password is set_</font> |
| **!user** | <font size="2">_Change Users name, this will update db, so when changing, this will also be new username_</font> |
| **!who** | <font size="2">_List of user in chat_</font> |
| **!whisper** | <font size="2">_message is directly send to user only, not seen by other users_</font> |
| **!mod** | <font size="2">_Grant user Mod privileges, can also be used to demote mod_</font> |
| **!kick** | <font size="2">_kick users from chat_</font> |
