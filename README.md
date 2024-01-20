# Macro Recorder
### This is a macro recorder designed to help accomplish repetative tasks with ease.
---
![Macro_recorder program](https://github.com/ThatLukeDev/macro-recorder/assets/76230394/b5454dd2-be9b-4f38-ba48-a1064644f5df)

---

- To install this app, download the [installer](https://github.com/ThatLukeDev/macro-recorder/raw/main/Macro%20Recorder%20Setup/Release/Macro%20Recorder%20Setup.msi) and run it.
- Once opened, click the drop down box next to `Type`
    - `Keyboard` and `SmoothType` both use text input in the `Type text here` box. Any special characters can be added using the [SendKeys API](https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.sendkeys?view=windowsdesktop-8.0), typically not working in games.
    - `KeyUp` and `KeyDown` both use character input in the `Insert Character here` box. Any special characters can be added using the [Forms Keys Enum](https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.keys?view=windowsdesktop-8.0) (with support for more keys), typically working in games.
    - `LeftClick` and `RightClick` take no input.
    - `Move` and `SmoothMove` take input in the form `{X=\d+,Y=\d+}`, after selecting these, the window will become transparent for 3 seconds before automatically inputting your cursor's position.
    - `Wait` uses a number input in milliseconds as a delay in the `Type milliseconds here` box.
- Pressing `Submit` will input the 'raw' data into the main textbox on the right, this can be edited.
- The `Delay` box takes a delay between each repetition in milliseconds.
- The `Repeat` box takes an integer, which is the amount of times the program will execute. `inf` is a special case, that will execute forever.
- The `Export` button exports the current macro (exporting as exe creates a standalone exe that executes the macro, for sharing with non-users of this program).
- The `Import` button (or dragging and dropping into the window) imports the macro (exe files not supported for import).
- For easy use, just press `CTRL + F5` to start/stop recording (use the hotkey to avoid an infinite loop).
- Finally, pressing `Start / Stop` or pressing `CTRL + F6` will toggle the program on or off.
- In case of emergency, moving your mouse to the top left of the screen will close the program between repetitions (thank me later).
---
### Configuration
![settings window](https://github.com/ThatLukeDev/macro-recorder/assets/76230394/9d1691b5-ca7e-401b-8ed1-8def76d2b772)

*Configuration is accessed through the cog icon on the main window.*
- Playback speed can be changed with the `Speed` box.
- Mouse boundries can be changed with the `Mouse offset` boxes.
