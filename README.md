# Macro Recorder
### This is a macro recorder designed to help accomplish repetative tasks with ease.
---
![Macro_recorder program](https://github.com/ThatLukeDev/macro-recorder/assets/76230394/b5454dd2-be9b-4f38-ba48-a1064644f5df)

---

- To install this app, download the [installer](https://github.com/ThatLukeDev/macro-recorder/releases/download/1.0.2/Macro.Recorder.Setup.msi) and run it.
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

---

For inquiries on why the program is flagged as a virus by Windows, the [virustotal](https://www.virustotal.com/gui/file/5bf71436a50bee20ab678081421a8667233c05c294acdf4f42ad16ef807f4a58) scan is available, showing safe, and you can [whitelist](https://support.microsoft.com/en-us/windows/add-an-exclusion-to-windows-security-811816c0-4dfd-af4a-47e4-c301afe13b26) the program:

`Windows Defender` > `Protection History` > `Threat Blocked` > `Actions` > `Allow`

---

For any issues or feature requests, raise them in the *[github issues](https://github.com/ThatLukeDev/macro-recorder/issues)* tab.
