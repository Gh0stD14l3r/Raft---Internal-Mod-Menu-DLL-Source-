Raft Mod Menu v2.0 - C# DLL Source [Base]

This is a basic mod menu created in C#. It is a base which you can add your own items to it or modifications. Currently it has the following.

[ESP Menu]
 - Raft (Label/Lines)
 - Players (Skeleton, Boxs, Labels)
 - Entitys (Boxs, Lines)
 - PickupItems (Labels, Fade with distance)
 - Modify ESP Distance

[Control Menu]
- Kill Shark      [Host Only]
- Damage Shark    [Host Only]
- Revive Players  [Host Only]
- Restore Stats
- Anchor Raft     [Host Only]
- Teleport To Raft
- God Mode
- Flying Raft     [Host Only]
- Localplayer Fly

[Spawn Menu]
- Item Spawn Buttons
- Custom Spawn by Unique Name

[Speed Hack Menu]
- Walking, Sprinting, Swimming Speed Hack
- Jump Height Increaser
- Multiplyer 
NOTE: Multiplier max is set to 100f you can change higher if needed

[Player Menu]
- Display all players connected
- Display Health, Thirst, Oxygen, Hunger, IsLocal, Position (sometimes inaccurate if used as client)
- Teleport To Player
- Teleport Player To Me [Host Only]
- Revive                [Host Only]


Insert Key - Show/Hide Menu
End Key - Unload DLL File safely


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


![image](https://user-images.githubusercontent.com/38970826/181207121-61159fe2-9aa4-4c5a-b902-5d59041f562e.png)
