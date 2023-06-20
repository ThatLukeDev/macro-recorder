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

namespace Macro_Recorder
{
    public partial class Form1 : Form
    {
        public static void lightMode(bool eventArgs)
        {
            if (eventArgs)
            {
                MessageBox.Show("failure");
            }
        }

        Form Form2 = new Form2();
        bool active = false;
        KeyboardHook hook = new KeyboardHook();
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        public class Keyboard
        {
            [DllImport("user32.dll", SetLastError = true)]
            static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

            const int KEY_DOWN_EVENT = 0x0001;
            const int KEY_UP_EVENT = 0x0002;

            public static void KeyDown(byte key)
            {
                InputSimulator keycord = new InputSimulator();
                keycord.Keyboard.KeyDown((VirtualKeyCode)key);
            }
            public static void KeyUp(byte key)
            {
                InputSimulator keycord = new InputSimulator();
                keycord.Keyboard.KeyUp((VirtualKeyCode)key);
            }
        }

        public Form1()
        {
            InitializeComponent();
            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(start_hotkey);
            hook.RegisterHotKey(Macro_Recorder.ModifierKeys.Control, Keys.F6);
        }
        void start_hotkey(object sender, KeyPressedEventArgs e)
        {
            btnStart_Click(btnStart, null);
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
            button1.Text = "5";
            await Task.Delay(1000);
            button1.Text = "4";
            await Task.Delay(1000);
            button1.Text = "3";
            await Task.Delay(1000);
            button1.Text = "2";
            await Task.Delay(1000);
            button1.Text = "1";
            await Task.Delay(1000);

            var pos = Cursor.Position;
            button1.Text = Convert.ToString(pos);
            txtTypeInfo.Text = Convert.ToString(pos);
            await Task.Delay(1000);
            button1.Text = "Get Cursor Position";

        }

        void MClick()
        {
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 0, 0);
            Random rnd = new Random();
            int rndint = rnd.Next(0, 11);
            Thread.Sleep(20 + rndint);
            mouse_event(MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        void MClickR()
        {
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, X, Y, 0, 0);
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboType.Text == "Keyboard")
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
            if (cboType.Text == "Move")
            {
                txtTypeInfo.Text = "Insert Position Here";
            }
            else
            if (cboType.Text == "SmoothMove")
            {
                txtTypeInfo.Text = "Insert position here";
            }
            else
            if (cboType.Text == "SmoothMove")
            {
                txtTypeInfo.Text = "Type text here";
            }
            else
            if (cboType.Text == "KeyDown")
            {
                txtTypeInfo.Text = "Insert Character here";
            }
            else
            if (cboType.Text == "KeyUp")
            {
                txtTypeInfo.Text = "Insert Character here";
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string tblInfo = lblMacroInfo.Text + cboType.Text + ":" + txtTypeInfo.Text + ";\n";
            lblMacroInfo.Text = tblInfo;
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
                    if (active)
                    {
                        await Task.Delay(Int32.Parse(txtDelayBTW.Text)); //pause
                        var cs420 = Regex.Replace("{X=0,Y=0}", @"[\{\}a-zA-Z=]", "").Split(',');
                        Point ccs420 = new Point(int.Parse(cs420[0]), int.Parse(cs420[1]));
                        if (Cursor.Position == ccs420)
                            Close();
                        string[] tblSplitInfo = lblMacroInfo.Text.Split(';'); //newline

                        //Loop
                        foreach (var tempvar in tblSplitInfo)
                        {
                            if (active == false)
                            {
                                break;
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
                                int distance = Convert.ToInt32(distancedouble);
                                for (int i = 0; i < (distance / 5); i++)
                                {
                                    if (active == false)
                                    {
                                        break;
                                    }
                                    Thread.Sleep(1);
                                    int tvx = Convert.ToInt32(currentx - (distancex * (Convert.ToDouble(i) / (distance / 5))));
                                    int tvy = Convert.ToInt32(currenty - (distancey * (Convert.ToDouble(i) / (distance / 5))));
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
                                        break;
                                    }
                                    Random rnd = new Random();
                                    int rndint = rnd.Next(0, 51);
                                    Thread.Sleep(50 + rndint);
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
                                await Task.Delay(Convert.ToInt32(varInstruction));
                            }
                            // KeyDown
                            if (varInstructionType.Contains("KeyDown"))
                            {
                                Keyboard.KeyDown((byte)(Keys)Enum.Parse(typeof(Keys), varInstruction, true));
                            }
                            // KeyUp
                            if (varInstructionType.Contains("KeyUp"))
                            {
                                Keyboard.KeyUp((byte)(Keys)Enum.Parse(typeof(Keys), varInstruction, true));
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
            lblMacroInfo.Text = File.ReadAllText(openFileDialog1.FileName);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //export
            folderBrowserDialog1.ShowDialog();
            File.WriteAllText(folderBrowserDialog1.SelectedPath + @"\New Macro.macro", lblMacroInfo.Text);
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
            if (Form2.Visible)
            {
                Form2.Hide();
            }
            else
            {
                Form2.Show();
            }
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