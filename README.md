# External Crosshair Overlay
Adds an overlay over your chosen game and places a **crosshair** in the middle of the screen.

## How do I choose the game?
1. Open the **Program.cs** file
2. Locate 
```c#
Application.Run(new Hack(new Process("REDACTED: Nightly [2014-06-25] - #OFFLINE MODE#")));
```
3. Change **"REDACTED: Nightly [2014-06-25] - #OFFLINE MODE#"** to whatever the __**window of your game says**__.
REMEMBER TO PLACE THE NAME BETWEEN THE **QUOTES!**

## How do change the color of the crosshair?
1. Open the **ExternalCrosshair.cs** file
2. Locate
```c#
CrosshairColour = Color.Blue;
```
3.Change **Blue** to whatever color you want. (e.g. Red)

## How do I run the app?
1. Compile with Visual Studio (with release options) or another compiler.
2. Navigate to the bin/Release directory
3. Run the file **External Crosshair.exe** file.
