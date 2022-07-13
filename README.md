Raft Mod Menu - C# DLL Source [Base]

This is a basic mod menu created in C#. It is a base which you can add your own items to it or modifications. Currently it has the following.

- ESP (Players, Shark, Raft) (This works but is not the best code)
- Kill Shark
- Damage Shark
- Revive Players (Untested)
- Restore Stats (Health, Hunger, Thirst, Oxygen)
- Anchor Raft (Doesn't use anchor, just stops the drift of the water. Reclick to continue)
- Teleport To Raft (Works well when people take off with the raft :/ )
- God Mode
- Fly Raft (Numpad + to go up, Numpad - to go down)
- Fly LocalPlayer (Buggy)
- Area Magnet (Will teleport all items in the area to you)
- Basic Shark Aimbot (Can be changed for other entities in the code)

Insert Key - Show/Hide Menu
End Key - Unload DLL File safely

Other hotkeys and updates will be added in time.

To compile..
- Download & Open Sln file for Visual Studio
- Compile in Debug or Release (Doesn't matter)

To Inject..
- Use a Mono injector (Possibly MonoSharpInjector)
- Select Process and browse to the assembly to inject (RaftHax.dll)
- Use the following settings..
 -- Namespace: RaftHax
 -- Class name: Loader
 -- Method name: init
- Press inject


![image](https://user-images.githubusercontent.com/38970826/178721053-77619367-459b-4dcb-87db-509e17303c2a.png)
