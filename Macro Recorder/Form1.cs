using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using Macro_Recorder.Properties;
using WindowsInput;
using WindowsInput.Native;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.IO.Compression;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Resources;

namespace Macro_Recorder
{
    public partial class Form1 : Form
    {
        public string lastKeyDown = "";

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);
        
        Form config = new Form2();
        bool active = false;
        bool recording = false;
        KeyboardHook hookStart = new KeyboardHook();
        KeyboardHook hookRecord = new KeyboardHook();
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        static string processName = Process.GetCurrentProcess().MainModule.ModuleName;
        //
        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookCallbackDelegate lpfn, IntPtr wParam, uint lParam);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        private static int WH_KEYBOARD_LL = 13;
        private static int WH_MOUSE_LL = 14;
        private static int WM_KEYDOWN = 0x0100;
        private static int WM_KEYUP = 0x0101;
        private static int WM_ALTKEYDOWN = 0x0104;
        private static int WM_ALTKEYUP = 0x0105;
        private static int WM_MOUSEMOVE = 0x0200;
        private static int WM_LBUTTONDOWN = 0x0201;
        private static int WM_LBUTTONUP = 0x0202;
        private static int WM_MOUSEWHEEL = 0x020A;
        private static int WM_RBUTTONDOWN = 0x0204;
        private static int WM_RBUTTONUP = 0x0205;
        private static int WM_LBUTTONDBLCLK = 0x0203;
        private static int WM_MBUTTONDOWN = 0x0207;
        private static int WM_MBUTTONUP = 0x020;

        public delegate IntPtr HookCallbackDelegate(int nCode, IntPtr wParam, IntPtr lParam);

        public class Keyboard
        {
            [DllImport("user32.dll", SetLastError = true)]
            static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

            const int KEY_DOWN_EVENT = 0x0001;
            const int KEY_UP_EVENT = 0x0002;

            public static void KeyDown(Keys key)
            {
                InputSimulator keycord = new InputSimulator();
                keycord.Keyboard.KeyDown((VirtualKeyCode)key);
            }
            public static void KeyUp(Keys key)
            {
                InputSimulator keycord = new InputSimulator();
                keycord.Keyboard.KeyUp((VirtualKeyCode)key);
            }
        }
        public struct Vector2
        {
            public int x;
            public int y;
        }

        public struct MOUSEINFO
        {
            public Vector2 pos;
            public uint data;
            public uint flags;
            public uint time;
            public IntPtr extra;
        }

        public class LoggerC
        {
            HookCallbackDelegate hcDelegate;
            HookCallbackDelegate mhcDelegate;
            IntPtr whllkeyboardhook;
            IntPtr whllmousehook;
            string macroLogged = "";

            Stopwatch elapsed = new Stopwatch();
            Stopwatch mtimer = new Stopwatch();

            IntPtr handler(int nCode, IntPtr wParam, IntPtr lParam)
            {
                if (nCode >= 0)
                {
                    macroLogged += $"Wait:{elapsed.ElapsedMilliseconds};";
                    elapsed.Restart();

                    Keys key = (Keys)Marshal.ReadInt32(lParam);
                    if (key != Keys.F5)
                    {
                        if (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_ALTKEYDOWN)
                            macroLogged += $"KeyDown:{key};";
                        if (wParam == (IntPtr)WM_KEYUP || wParam == (IntPtr)WM_ALTKEYUP)
                            macroLogged += $"KeyUp:{key};";
                    }
                }
                return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
            }
            IntPtr mhandler(int nCode, IntPtr wParam, IntPtr lParam)
            {
                if (nCode >= 0 && mtimer.ElapsedMilliseconds > 10)
                {
                    macroLogged += $"Wait:{elapsed.ElapsedMilliseconds};";
                    elapsed.Restart();

                    MOUSEINFO info = (MOUSEINFO)Marshal.PtrToStructure(lParam, typeof(MOUSEINFO));
                    if (wParam == (IntPtr)WM_MOUSEMOVE)
                    {
                        if (mtimer.ElapsedMilliseconds < 50)
                        {
                            macroLogged += $"Move:{{X={info.pos.x},Y={info.pos.y}}};";
                        }
                        else
                        {
                            macroLogged += $"SmoothMove:{{X={info.pos.x},Y={info.pos.y}}};";
                        }
                    }
                    mtimer.Restart();
                    if (wParam == (IntPtr)WM_LBUTTONUP)
                        macroLogged += "LeftClick:;";
                    if (wParam == (IntPtr)WM_RBUTTONUP)
                        macroLogged += "RightClick:;";
                }
                return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
            }

            public void start()
            {
                mtimer.Start();
                elapsed.Start();

                macroLogged = "";
                hcDelegate = handler;
                mhcDelegate = mhandler;

                string mainModuleName = Process.GetCurrentProcess().MainModule.ModuleName;
                whllkeyboardhook = SetWindowsHookEx(WH_KEYBOARD_LL, hcDelegate, GetModuleHandle(mainModuleName), 0);
                whllmousehook = SetWindowsHookEx(WH_MOUSE_LL, mhcDelegate, GetModuleHandle(mainModuleName), 0);
            }
            public string end()
            {
                UnhookWindowsHookEx(whllkeyboardhook);
                UnhookWindowsHookEx(whllmousehook);
                hcDelegate = null;
                mhcDelegate = null;
                elapsed.Stop();
                return macroLogged;
            }
        }
        LoggerC Logger = new LoggerC();

        public Form1()
        {
            InitializeComponent();
            hookStart.KeyPressed += new EventHandler<KeyPressedEventArgs>(start_hotkey);
            hookStart.RegisterHotKey(Macro_Recorder.ModifierKeys.Control, Keys.F6);
            hookRecord.KeyPressed += new EventHandler<KeyPressedEventArgs>(record_hotkey);
            hookRecord.RegisterHotKey(Macro_Recorder.ModifierKeys.Control, Keys.F5);
        }

        double getSpeed()
        {
            return config.Controls["speedLabel"].Text == "" ? 1.0d : double.Parse(config.Controls["speed"].Text);
        }

        int adjustSpeed(int ms)
        {
            return Convert.ToInt32(Convert.ToDouble(ms) / getSpeed());
        }

        void start_hotkey(object sender, KeyPressedEventArgs e)
        {
            if (active)
            {
                active = false;
                return;
            }
            btnStart_Click(btnStart, null);
        }
        void record_hotkey(object sender, KeyPressedEventArgs e)
        {
            button1_ClickAsync(button1, null);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            Color bg = ColorTranslator.FromHtml("#2b2d31");
            Color back = ColorTranslator.FromHtml("#3B3D43");
            this.BackColor = bg;
            lblMacroInfo.BackColor = back;
            txtTypeInfo.BackColor = back;
            cboType.BackColor = back;
            btnSubmit.BackColor = back;
            btnImport.BackColor = back;
            btnExport.BackColor = back;
            panel1.BackColor = back;
            btnStart.BackColor = back;
            btnUndo.BackColor = back;
            button1.BackColor = back;
            txtRepeat.BackColor = back;
            txtDelayBTW.BackColor = back;
            label1.BackColor = back;
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            if (recording)
            {
                lblMacroInfo.Text += Logger.end() + "KeyUp:LControlKey;";
                button1.Text = "Start Recording\r\n(CTRL + F5)";
            }
            else
            {
                Logger.start();
                button1.Text = "Stop Recording\r\n(CTRL + F5)";
            }
            recording = !recording;
        }

        async void MClick()
        {
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 0, 0);
            Random rnd = new Random();
            int rndint = rnd.Next(0, 11);
            await Task.Delay(adjustSpeed(20 + rndint));
            mouse_event(MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        async void MClickR()
        {
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_RIGHTDOWN, X, Y, 0, 0);
            Random rnd = new Random();
            int rndint = rnd.Next(0, 11);
            await Task.Delay(adjustSpeed(20 + rndint));
            mouse_event(MOUSEEVENTF_RIGHTUP, X, Y, 0, 0);
        }

        private async void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboType.Text == "Keyboard" || cboType.Text == "SmoothType")
            {
                txtTypeInfo.Text = "Type text here";
            }
            else
            if (cboType.Text == "Wait")
            {
                txtTypeInfo.Text = "Type milliseconds here";
            }
            else
            if (cboType.Text == "LeftClick" || cboType.Text == "RightClick")
            {
                txtTypeInfo.Text = "";
            }
            else
            if (cboType.Text == "Move" || cboType.Text == "SmoothMove")
            {
                this.Opacity = 0.5;

                txtTypeInfo.Text = "Getting position in 3";
                await Task.Delay(1000);
                txtTypeInfo.Text = "Getting position in 2";
                await Task.Delay(1000);
                txtTypeInfo.Text = "Getting position in 1";
                await Task.Delay(1000);

                var pos = Cursor.Position;
                txtTypeInfo.Text = Convert.ToString(pos);

                this.Opacity = 1.0;
            }
            else
            if (cboType.Text == "KeyDown")
            {
                txtTypeInfo.Text = "Insert Character here";
            }
            else
            if (cboType.Text == "KeyUp")
            {
                if (lastKeyDown != "")
                {
                    txtTypeInfo.Text = lastKeyDown.ToString();
                    lastKeyDown = "";
                }
                else
                {
                    txtTypeInfo.Text = "Insert Character here";
                }
            }
            txtTypeInfo.Focus();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string tblInfo = lblMacroInfo.Text + cboType.Text + ":" + txtTypeInfo.Text + ";\n";
            lblMacroInfo.Text = tblInfo;
            if (cboType.Text == "KeyDown")
            {
                lastKeyDown = txtTypeInfo.Text;
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            lblMacroInfo.Text = "";
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            bool start = true;
            if (active == true)
            {
                active = false;
                start = false;
            }

            bool safe221 = true;
            if (Int32.Parse(txtDelayBTW.Text) < 100 && checkBox1.Checked) //safety
            {
                MessageBox.Show("The delay is under 100 milliseconds", "Safeguard");
                safe221 = false;
            }

            if (safe221 && start)
            {
                int ceil;
                active = true;
                if (txtRepeat.Text == "inf")
                {
                    ceil = Int32.MaxValue;
                }
                else
                {
                    ceil = Convert.ToInt32(txtRepeat.Text);
                }
                for (int repeatvar = 0; repeatvar < ceil; repeatvar++)
                {
                    if (active || true)
                    {
                        await Task.Delay(adjustSpeed(Int32.Parse(txtDelayBTW.Text))); //pause
                        var cs420 = Regex.Replace("{X=0,Y=0}", @"[\{\}a-zA-Z=]", "").Split(',');
                        Point ccs420 = new Point(int.Parse(cs420[0]), int.Parse(cs420[1]));
                        if (Cursor.Position == ccs420)
                            Close();
                        string[] tblSplitInfo = lblMacroInfo.Text.Split(';'); //newline

                        //Loop
                        foreach (var tempvar in tblSplitInfo)
                        {
                            if (Cursor.Position == ccs420)
                                Close();
                            if (active == false)
                            {
                                return;
                            }
                            //setup
                            string varInstruction = tempvar.Substring(tempvar.IndexOf(':') + 1);
                            string varInstructionType = tempvar.Substring(0, tempvar.IndexOf(':') + 1).Replace(":", "");
                            //Key
                            if (varInstructionType.Contains("Keyboard"))
                            {
                                SendKeys.Send(varInstruction);
                            }
                            //LClick
                            if (varInstructionType.Contains("LeftClick"))
                            {
                                MClick();
                            }
                            // RClick
                            if (varInstructionType.Contains("RightClick"))
                            {
                                MClickR();
                            }
                            // Move
                            if (varInstructionType.Contains("Move") && !varInstructionType.Contains("SmoothMove"))
                            {
                                var clicktype = Regex.Replace(varInstruction, @"[\{\}a-zA-Z=]", "").Split(',');
                                Point pointr = new Point(int.Parse(clicktype[0]), int.Parse(clicktype[1]));

                                Cursor.Position = pointr;
                            }
                            // SmoothMove
                            if (varInstructionType.Contains("SmoothMove"))
                            {
                                int currentx = Cursor.Position.X;
                                int currenty = Cursor.Position.Y;
                                var tempxy = Regex.Replace(varInstruction, @"[\{\}a-zA-Z=]", "").Split(',');
                                int destinationx = int.Parse(tempxy[0]);
                                int destinationy = int.Parse(tempxy[1]);
                                int distancex = currentx - destinationx;
                                int distancey = currenty - destinationy;
                                double distancedouble = Math.Sqrt(Math.Pow(Math.Abs(distancex), 2) + Math.Pow(Math.Abs(distancey), 2));
                                int distance = adjustSpeed(Convert.ToInt32(distancedouble));
                                for (int i = 0; i < (distance * 0.1); i++)
                                {
                                    if (Cursor.Position == ccs420)
                                        Close();
                                    if (active == false)
                                    {
                                        return;
                                    }
                                    await Task.Delay(1);
                                    int tvx = Convert.ToInt32(currentx - (distancex * (Convert.ToDouble(i) / (distance * 0.1))));
                                    int tvy = Convert.ToInt32(currenty - (distancey * (Convert.ToDouble(i) / (distance * 0.1))));
                                    Cursor.Position = new Point(tvx, tvy);
                                }
                            }
                            // SmoothType
                            if (varInstructionType.Contains("SmoothType"))
                            {
                                string tempst = "";
                                bool tempstb = true;
                                foreach (char v in varInstruction.ToCharArray())
                                {
                                    if (active == false)
                                    {
                                        return;
                                    }
                                    Random rnd = new Random();
                                    int rndint = rnd.Next(0, 51);
                                    await Task.Delay(adjustSpeed(50 + rndint));
                                    if (v != '{' && tempstb)
                                    {
                                        SendKeys.Send(v.ToString());
                                    }
                                    else
                                    {
                                        tempstb = false;
                                        if (v == '{')
                                        {
                                            tempst = "";
                                        }
                                        tempst += v.ToString();
                                        if (v == '}')
                                        {
                                            tempstb = true;
                                            SendKeys.Send(tempst);
                                        }
                                    }
                                }
                            }
                            // Wait
                            if (varInstructionType.Contains("Wait"))
                            {
                                await Task.Delay(adjustSpeed(Convert.ToInt32(varInstruction)));
                            }
                            // KeyDown
                            if (varInstructionType.Contains("KeyDown"))
                            {
                                Keyboard.KeyDown((Keys)Enum.Parse(typeof(Keys), varInstruction, true));
                            }
                            // KeyUp
                            if (varInstructionType.Contains("KeyUp"))
                            {
                                Keyboard.KeyUp((Keys)Enum.Parse(typeof(Keys), varInstruction, true));
                            }
                        }
                    }
                }
            }
            active = false;
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            //import
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName.Length == 0)
                return;
            switch (openFileDialog1.FileName.Substring(openFileDialog1.FileName.Length - 4))
            {
                case ".mac":
                    MemoryStream output = new MemoryStream();
                    FileStream input = new FileStream(openFileDialog1.FileName, FileMode.Open);
                    GZipStream compressor = new GZipStream(input, CompressionMode.Decompress);
                    {
                        compressor.CopyTo(output);
                        compressor.Close();
                    }
                    input.Close();
                    lblMacroInfo.Text = new string(output.ToArray().Select((x) => (char)x).ToArray());
                    break;
                default:
                    lblMacroInfo.Text = File.ReadAllText(openFileDialog1.FileName);
                    break;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //export
            saveFileDialog1.ShowDialog();
            switch (saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.Length - 4))
            {
                case ".exe":
                    {
                        string csSource = Resources.standalone_executor.ToString();
                        string csRep = lblMacroInfo.Text;
                        csRep = csRep.Replace("\r", "");
                        csRep = csRep.Replace("\n", "");
                        csSource = csSource.Replace("_REPLACEVAR-MACROCONTENT_", csRep);
                        File.WriteAllText(saveFileDialog1.FileName.Substring(0, saveFileDialog1.FileName.Length - 4) + ".cs", csSource);

                        CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
                        CompilerParameters param = new CompilerParameters();

                        param.ReferencedAssemblies.Add("System.dll");
                        param.ReferencedAssemblies.Add("System.Windows.dll");
                        param.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                        param.ReferencedAssemblies.Add("System.Drawing.dll");
                        param.ReferencedAssemblies.Add("System.Text.RegularExpressions.dll");

                        param.GenerateExecutable = true;
                        param.OutputAssembly = saveFileDialog1.FileName;
                        param.GenerateInMemory = false;
                        param.TreatWarningsAsErrors = false;

                        CompilerResults result = provider.CompileAssemblyFromFile(param, saveFileDialog1.FileName.Substring(0, saveFileDialog1.FileName.Length - 4) + ".cs");

                        if (result.Errors.Count > 0)
                        {
                            foreach (CompilerError error in result.Errors)
                            {
                                MessageBox.Show(error.ErrorText, $"Error during exe compilation: line {error.Line}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            File.Delete(saveFileDialog1.FileName.Substring(0, saveFileDialog1.FileName.Length - 4) + ".cs");
                        }
                    }
                    break;
                case ".mac":
                    FileStream compressed = File.Create(saveFileDialog1.FileName);
                    GZipStream compressor = new GZipStream(compressed, CompressionMode.Compress);
                    {
                        compressor.Write(lblMacroInfo.Text.ToCharArray().Select(c => (byte)c).ToArray(), 0, lblMacroInfo.Text.Length);
                        compressor.Close();
                    }
                    compressed.Close();
                    break;
                default:
                    File.WriteAllText(saveFileDialog1.FileName, lblMacroInfo.Text);
                    break;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                // safeguard warning
                MessageBox.Show("Safeguard checks if the delay in the application is a safe value", "Safeguard");
            }
        }

        public void settingsPic_Click(object sender, EventArgs e)
        {
            if (config.Visible)
            {
                config.Hide();
            }
            else
            {
                config.Show();
            }
        }

        private void txtTpeInfo_Click(object sender, EventArgs e)
        {
            txtTypeInfo.SelectAll();
        }

        private void txtTypeInfo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSubmit_Click(this, e);
                cboType.Focus();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string filename = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
                if (filename.Length == 0)
                    return;
                switch (filename.Substring(filename.Length - 4))
                {
                    case ".mac":
                        MemoryStream output = new MemoryStream();
                        FileStream input = new FileStream(filename, FileMode.Open);
                        GZipStream compressor = new GZipStream(input, CompressionMode.Decompress);
                        {
                            compressor.CopyTo(output);
                            compressor.Close();
                        }
                        input.Close();
                        lblMacroInfo.Text = new string(output.ToArray().Select((x) => (char)x).ToArray());
                        break;
                    default:
                        lblMacroInfo.Text = File.ReadAllText(filename);
                        break;
                }
            }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
    }

    public sealed class KeyboardHook : IDisposable
    {
        // Registers a hot key with Windows.
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        // Unregisters the hot key with Windows.
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /// <summary>
        /// Represents the window that is used internally to get the messages.
        /// </summary>
        private class Window : NativeWindow, IDisposable
        {
            private static int WM_HOTKEY = 0x0312;

            public Window()
            {
                // create the handle for the window.
                this.CreateHandle(new CreateParams());
            }

            /// <summary>
            /// Overridden to get the notifications.
            /// </summary>
            /// <param name="m"></param>
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);

                // check if we got a hot key pressed.
                if (m.Msg == WM_HOTKEY)
                {
                    // get the keys.
                    Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                    ModifierKeys modifier = (ModifierKeys)((int)m.LParam & 0xFFFF);

                    // invoke the event to notify the parent.
                    if (KeyPressed != null)
                        KeyPressed(this, new KeyPressedEventArgs(modifier, key));
                }
            }

            public event EventHandler<KeyPressedEventArgs> KeyPressed;

            #region IDisposable Members

            public void Dispose()
            {
                this.DestroyHandle();
            }

            #endregion
        }

        private Window _window = new Window();
        private int _currentId;

        public KeyboardHook()
        {
            // register the event of the inner native window.
            _window.KeyPressed += delegate (object sender, KeyPressedEventArgs args)
            {
                if (KeyPressed != null)
                    KeyPressed(this, args);
            };
        }

        /// <summary>
        /// Registers a hot key in the system.
        /// </summary>
        /// <param name="modifier">The modifiers that are associated with the hot key.</param>
        /// <param name="key">The key itself that is associated with the hot key.</param>
        public void RegisterHotKey(ModifierKeys modifier, Keys key)
        {
            // increment the counter.
            _currentId = _currentId + 1;

            // register the hot key.
            if (!RegisterHotKey(_window.Handle, _currentId, (uint)modifier, (uint)key))
                throw new InvalidOperationException("Couldn’t register the hot key.");
        }

        /// <summary>
        /// A hot key has been pressed.
        /// </summary>
        public event EventHandler<KeyPressedEventArgs> KeyPressed;

        #region IDisposable Members

        public void Dispose()
        {
            // unregister all the registered hot keys.
            for (int i = _currentId; i > 0; i--)
            {
                UnregisterHotKey(_window.Handle, i);
            }

            // dispose the inner native window.
            _window.Dispose();
        }

        #endregion
    }

    /// <summary>
    /// Event Args for the event that is fired after the hot key has been pressed.
    /// </summary>
    public class KeyPressedEventArgs : EventArgs
    {
        private ModifierKeys _modifier;
        private Keys _key;

        internal KeyPressedEventArgs(ModifierKeys modifier, Keys key)
        {
            _modifier = modifier;
            _key = key;
        }

        public ModifierKeys Modifier
        {
            get { return _modifier; }
        }

        public Keys Key
        {
            get { return _key; }
        }
    }

    /// <summary>
    /// The enumeration of possible modifiers.
    /// </summary>
    [Flags]
    public enum ModifierKeys : uint
    {
        Alt = 1,
        Control = 2,
        Shift = 4,
        Win = 8
    }
}