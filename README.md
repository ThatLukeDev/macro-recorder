# Macro Recorder
### This is a macro recorder designed to help accomplish repetative tasks with ease.
---
![Macro_recorder program](https://github.com/ThatLukeDev/macro-recorder/assets/76230394/b5454dd2-be9b-4f38-ba48-a1064644f5df)

---

- To install this app, download the [installer](https://github.com/ThatLukeDev/macro-recorder/raw/main/Macro%20Recorder%20Setup/Release/Macro%20Recorder%20Setup.msi) and run it.
- Once opened, click the drop down box next to `Type`
    - `Keyboard` and `SmoothType` both use text input in the `Type text here` box. Any special characters can be added using the [SendKeys API](https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.sendkeys?view=windowsdesktop-8.0), typically not working in games.
    - `KeyUp` and `KeyDown` both use character input in the `Insert Character here` box, typically working in games.
    - `LeftClick` and `RightClick` take no input.
    - `Move` and `SmoothMove` take input in the form `{X=\d+,Y=\d+}`, after selecting these, the window will become transparent for 3 seconds before automatically inputting your cursor's position.
    - `Wait` uses a number input in milliseconds as a delay in the `Type milliseconds here` box.
- Pressing `Submit` will input the 'raw' data into the main textbox on the right, this can be edited.
- The `Delay` box takes a delay between each repetition in milliseconds.
- The `Repeat` box takes an integer, which is the amount of times the program will execute. `inf` is a special case, that will execute forever.
- For easy use, just press `CTRL + F5` to start/stop recording (use the hotkey to avoid an infinite loop).
- Finally, pressing `Start / Stop` or pressing `CTRL + F6` will toggle the program on or off.
- In case of emergency, moving your mouse to the top left of the screen will close the program between repetitions (thank me later)
