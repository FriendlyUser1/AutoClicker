using System.Runtime.InteropServices;
using System.Text;

namespace AutoClicker
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        private const uint MOD_ALT = 0x0001;
        private const uint MOD_CONTROL = 0x0002;
        private const uint MOD_SHIFT = 0x0004;
        private const uint MOD_WIN = 0x0008;
        private const int WM_HOTKEY = 0x0312;

        private int hotkeyId = 1;
        private Keys Keybind = Keys.F6;
        private uint KeybindModifiers = 0;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int ToUnicode(
        uint virtualKeyCode,
        uint scanCode,
        byte[] keyboardState,
        StringBuilder receivingBuffer,
        int bufferSize,
        uint flags);

        private int ClickSpeed = 100;
        private int ClickJitter = 10;
        private bool Clicking = false;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);
        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load the settings
            ClickSpeed = Properties.Settings.Default.ClickSpeed;
            ClickJitter = Properties.Settings.Default.ClickJitter;
            Keybind = (Keys)Properties.Settings.Default.Keybind;
            KeybindModifiers = Properties.Settings.Default.KeybindModifiers;

            // Update your controls if needed
            speedControl.Value = ClickSpeed;
            jitterControl.Value = ClickJitter;
            textKeybind.Text = KeyCodeToString(Keybind);
            AutoClickButtonsText_Handler(textKeybind.Text);

            RegisterHotKey();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == hotkeyId)
            {
                if (!Clicking) AutoClick_Start();
                else AutoClick_Stop();
            }
        }

        private void RegisterHotKey()
        {


            uint vk = (uint)Keybind;

            UnregisterHotKey(this.Handle, hotkeyId);

            RegisterHotKey(this.Handle, hotkeyId, KeybindModifiers, vk);
        }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
            else if (e.Button == MouseButtons.Right)
            {
                trayContextMenu.Show(Cursor.Position);
            }
        }

        // Mimimise window
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        // Open window
        private void TrayOpen_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        // Exit form
        private void Exit_Handler(object sender, EventArgs e)
        {
            if (Clicking) AutoClick_Stop();
            SaveSettings();
            UnregisterHotKey(this.Handle, hotkeyId);
            this.FormClosing -= Form1_FormClosing; this.Close();
        }

        // Save settings
        private void SaveSettings()
        {
            Properties.Settings.Default.ClickSpeed = ClickSpeed;
            Properties.Settings.Default.ClickJitter = ClickJitter;
            Properties.Settings.Default.Keybind = (int)Keybind;
            Properties.Settings.Default.KeybindModifiers = KeybindModifiers;

            Properties.Settings.Default.Save();
        }

        // Reset values to defaults
        private void Reset_Click(object sender, EventArgs e)
        {
            UnregisterHotKey(Handle, hotkeyId);
            Keybind = Keys.F6;
            speedControl.Value = 100;
            jitterControl.Value = 10;

            textKeybind.Text = Keybind.ToString();
            RegisterHotKey();
        }

        // Change/Set hotkey btn
        private void ChangeKeybind_Click(object sender, EventArgs e)
        {
            if (changeKeybind.Text == "Change")
            {
                textKeybind.Enabled = true;
                changeKeybind.Text = "Save";
                KeybindModifiers = 0;
                UnregisterHotKey(this.Handle, hotkeyId);
            }
            else if (changeKeybind.Text == "Save")
            {
                textKeybind.Enabled = false; changeKeybind.Text = "Change";

                RegisterHotKey();
            }
        }

        // Change hotkey key
        private static string KeyCodeToString(Keys keyCode)
        {

            // Convert special keys to their unicode characters
            if (keyCode.ToString().Contains("Oem"))
            {
                StringBuilder charPressed = new(256);
                int _ = ToUnicode((uint)keyCode, 0, new byte[256], charPressed, charPressed.Capacity, 0);
                return charPressed.ToString();
            }
            // Normal conversion for normal keys
            else
            {
                KeysConverter converter = new();
                string? keyString = converter.ConvertToString(keyCode);
                if (keyString != null) return keyString;
                else return keyCode.ToString();
            }

        }

        private void textKeybind_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void TextKeybind_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            List<string> pressedKeys = [];

            // Add modifiers
            if (e.Control) { pressedKeys.Add("Ctrl"); KeybindModifiers |= MOD_CONTROL; }
            if (e.Alt) { pressedKeys.Add("Alt"); KeybindModifiers |= MOD_ALT; }
            if (e.Shift) { pressedKeys.Add("Shift"); KeybindModifiers |= MOD_SHIFT; }

            // Add main key
            if (e.KeyCode != Keys.ControlKey && e.KeyCode != Keys.Menu && e.KeyCode != Keys.ShiftKey) pressedKeys.Add(KeyCodeToString(e.KeyCode));

            textKeybind.Text = String.Join(" + ", pressedKeys);

            Keybind = e.KeyCode;
        }

        // Autoclicker
        private void AutoClick_Start()
        {
            startButton.Enabled = false; stopButton.Enabled = true; changeKeybind.Enabled = false;
            Clicking = true;
            StartClickingLoop();
        }

        private async void StartClickingLoop()
        {
            while (Clicking)
            {
                var pos = Cursor.Position;
                mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)pos.X, (uint)pos.Y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, (uint)pos.X, (uint)pos.Y, 0, 0);

                int delay = ClickSpeed + random.Next(-ClickJitter, ClickJitter);
                await Task.Delay(delay);
            }
        }

        private void AutoClick_Stop()
        {
            startButton.Enabled = true; stopButton.Enabled = false; changeKeybind.Enabled = true;
            Clicking = false;
        }

        private void StartButton_Click(object sender, EventArgs e) { AutoClick_Start(); }
        private void StopButton_Click(object sender, EventArgs e) { AutoClick_Stop(); }


        private void AutoClickButtonsText_Handler(string hotkey)
        {
            if (hotkey == string.Empty)
            {
                startButton.Text = "Start";
                stopButton.Text = "Stop";
            }
            else
            {
                startButton.Text = String.Format("Start ({0})", hotkey);
                stopButton.Text = String.Format("Stop ({0})", hotkey);
            }
        }

        private void TextKeybind_TextChanged(object sender, EventArgs e)
        { AutoClickButtonsText_Handler(textKeybind.Text); }


        private void SpeedControl_ValueChanged(object sender, EventArgs? e)
        { ClickSpeed = (int)speedControl.Value; jitterControl.Maximum = ClickSpeed; }

        private void SpeedControl_KeyDown(object sender, KeyEventArgs e)
        { if (e.KeyCode == Keys.Enter) { speedControl.Validate(); e.SuppressKeyPress = true; } }


        private void JitterControl_ValueChanged(object sender, EventArgs? e)
        { ClickJitter = (int)jitterControl.Value; }

        private void JitterControl_KeyDown(object sender, KeyEventArgs e)
        { if (e.KeyCode == Keys.Enter) { speedControl.Validate(); e.SuppressKeyPress = true; } }


    }
}
