using System;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Resolve.HotKeys;
using AutoIt;
using System.Drawing;
using System.Runtime.InteropServices;
using ARK_Tools;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
        InitializeComponent();
            comboBox1.SelectedIndex = 0;
            numericUpDown1.Value = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            textBox1.Text = "Ten Turret";
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            numericUpDown2.Value = 0;
            comboBox8.SelectedIndex = 0;
            comboBox9.SelectedIndex = 0;
            comboBox10.SelectedIndex = 0;
            comboBox11.SelectedIndex = 0;
        }

        //public void Resolution_Checking()
        //{
            //Resolution
        //    var screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
        //    var screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
        //    if (screenWidth != "1920")
        //    {
        //        float new_width = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width.ToString());
        //        float new_height = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height.ToString());
        //        float auto_width = new_width / 1920;
        //        float auto_height = new_height / 1080;
        //    }
        //}

        //AutoItX3 au3 = new AutoItX3();
        HotKey xHotKey;
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);

        private void Form1_Load(object sender, EventArgs e)
        {
            
            timer1.Enabled = true;
            //F11 Hotkey - Auto-Click
            xHotKey = new HotKey(Keys.F11);
            xHotKey.Pressed += Auto_Click;
            xHotKey.Register();

            //Alt E Hotkey - Auto-E
            xHotKey = new HotKey(Keys.E, ModifierKey.Alt);
            xHotKey.Pressed += Auto_E;
            xHotKey.Register();

            //Alt U Hotkey - Auto-U
            xHotKey = new HotKey(Keys.U, ModifierKey.Alt);
            xHotKey.Pressed += Auto_U;
            xHotKey.Register();

            //Alt W Hotkey - Đi Bộ
            xHotKey = new HotKey(Keys.W, ModifierKey.Alt);
            xHotKey.Pressed += Walk;
            xHotKey.Register();

            //Alt Shift W Hotkey - Chạy nhanh
            xHotKey = new HotKey(Keys.Q, ModifierKey.Alt);
            xHotKey.Pressed += Sprint;
            xHotKey.Register();

            //F10 Hotkey - Ăn & Uống & Máu
            xHotKey = new HotKey(Keys.F10);
            xHotKey.Pressed += Eat_Drink;
            xHotKey.Register();

            //F9 Hotkey - Pin-code
            xHotKey = new HotKey(Keys.F9);
            xHotKey.Pressed += Pin_Code;
            xHotKey.Register();

            //F8 Hotkey - Set Turret
            xHotKey = new HotKey(Keys.F8);
            xHotKey.Pressed += Set_Turret;
            xHotKey.Register();

            //Alt S Hotkey - Crosshair
            xHotKey = new HotKey(Keys.S, ModifierKey.Alt);
            xHotKey.Pressed += Crosshair;
            xHotKey.Register();

            //Alt C Hotkey - Auto-C
            xHotKey = new HotKey(Keys.C, ModifierKey.Alt);
            xHotKey.Pressed += Auto_C;
            xHotKey.Register();

            //F7 Hotkey - Ban Holo
            xHotKey = new HotKey(Keys.F7);
            xHotKey.Pressed += Holo_Trigger;
            xHotKey.Register();

            //Alt ` Hotkey - Harvest
            xHotKey = new HotKey(Keys.Oemtilde);
            xHotKey.Pressed += Harvest;
            xHotKey.Register();

            //F6 Hotkey - Fishing
            xHotKey = new HotKey(Keys.F6);
            xHotKey.Pressed += Fishing;
            xHotKey.Register();

            //Alt C Hotkey - Auto-T
            xHotKey = new HotKey(Keys.T, ModifierKey.Alt);
            xHotKey.Pressed += Auto_T;
            xHotKey.Register();

            //F5 Hotkey - Split
            xHotKey = new HotKey(Keys.F5);
            xHotKey.Pressed += Auto_Split;
            xHotKey.Register();

            //Alt Esc Hotkey - Auto-Setting
            xHotKey = new HotKey(Keys.Escape, ModifierKey.Alt);
            xHotKey.Pressed += Auto_Setting;
            xHotKey.Register();

            //Alt J Hotkey - Auto-Join Server
            xHotKey = new HotKey(Keys.J, ModifierKey.Alt);
            xHotKey.Pressed += Auto_JoinServer;
            xHotKey.Register();

            //F4 Hotkey - Log-Reporter
            xHotKey = new HotKey(Keys.F4);
            xHotKey.Pressed += Log_Reporter;
            xHotKey.Register();

            //F3 Hotkey - Respawn
            xHotKey = new HotKey(Keys.F3);
            xHotKey.Pressed += Respawn;
            xHotKey.Register();

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //pictureBox1.Image.Save(@"Pic.bmp", System.Drawing.Imaging.ImageFormat.Bmp);

            //Resolution
            var screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            var screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
        }

        //Status 
        private void timer1_Tick(object sender, EventArgs e)
        {
            var screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            var screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            System.Diagnostics.Process[] myprocess = System.Diagnostics.Process.GetProcessesByName("ShooterGame");
            label18.Text = "DEACTIVATED";
            label18.ForeColor = System.Drawing.Color.Red;
            timer1.Interval = 1000;
            if (myprocess.Length != 0)
            {
                label18.Text = "ACTIVATED";
                label18.ForeColor = System.Drawing.Color.Lime;
                label20.Text = screenWidth + "x" + screenHeight;
                this.Update();

                //Hide ARK Game Window
                if (checkBox16.Checked == true)
                {
                    AutoItX.WinSetState("ARK: Survival Evolved", "", AutoItX.SW_HIDE);
                    label43.Text = "- Hidden";
                }
                else if (checkBox16.Checked == false)
                {
                    AutoItX.WinSetState("ARK: Survival Evolved", "", AutoItX.SW_SHOW);
                    label43.Text = "- Visible";
                }
            }
            else
            {
                notifyIcon1.Dispose();
                Application.Exit();
            }
        }

        //Auto-Click Logic
        private void Auto_Click(object sender, EventArgs e)
        {
            timer2.Enabled = !timer2.Enabled;
            if (timer2.Enabled)
            {
                checkBox1.Checked = true;
                notifyIcon1.ShowBalloonTip(1000, "Auto-Click | ON", "Auto-Click | ON", ToolTipIcon.Info);
            }
            else
            {
                checkBox1.Checked = false;
                notifyIcon1.ShowBalloonTip(1000, "Auto-Click | OFF", "Auto-Click | OFF", ToolTipIcon.Info);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int click_choice = comboBox1.SelectedIndex;
            int click_delay = Convert.ToInt32((numericUpDown2.Value) * 1000);
            var screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            var screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            if (click_choice == 0)
            {
                if (click_delay == 0)
                {
                    AutoItX.ControlClick("ARK: Survival Evolved", "", "", "LEFT");
                }
                else if (click_delay != 0)
                {
                    AutoItX.ControlClick("ARK: Survival Evolved", "", "", "LEFT");
                    Thread.Sleep(click_delay);
                }
            }
            else if (click_choice == 1)
            {
                if (click_delay == 0)
                {
                    AutoItX.ControlClick("ARK: Survival Evolved", "", "", "RIGHT");
                }
                else if (click_delay != 0)
                {
                    AutoItX.ControlClick("ARK: Survival Evolved", "", "", "RIGHT");
                    Thread.Sleep(click_delay);
                }
            }
            else if (click_choice == 2)
            {
                if (click_delay == 0)
                {
                    AutoItX.MouseDown("LEFT");
                    AutoItX.MouseDown("RIGHT");
                    Thread.Sleep(1);
                    AutoItX.MouseUp("LEFT");
                    AutoItX.MouseUp("RIGHT");

                }
                else if (click_delay != 0)
                {
                    AutoItX.MouseDown("LEFT");
                    AutoItX.MouseDown("RIGHT");
                    Thread.Sleep(1);
                    AutoItX.MouseUp("LEFT");
                    AutoItX.MouseUp("RIGHT");
                    Thread.Sleep(click_delay);
                }
            }

            //Ankylo Stamina
            else if (click_choice == 3)
            {
                for (int i = 0; i <= 100; i++)
                {
                    AutoItX.ControlClick("ARK: Survival Evolved", "", "", "LEFT");
                    Thread.Sleep(10);
                }
                Thread.Sleep(3000);
            }

            //Mammoth Stamina
            else if (click_choice == 4)
            {
                for (int i = 0; i <= 100; i++)
                {
                    AutoItX.ControlClick("ARK: Survival Evolved", "", "", "RIGHT");
                    Thread.Sleep(10);
                }
                Thread.Sleep(4000);
            }

            //Theri | Drop Thatch + Mushroom
            else if (click_choice == 5)
            {
                timer18.Start();
                for (int i = 0; i <= 200; i++)
                {
                    AutoItX.ControlClick("ARK: Survival Evolved", "", "", "LEFT");
                    Thread.Sleep(1);
                }
            }

            //Anky | Drop Thatch + Wood
            else if (click_choice == 6)
            {
                timer18.Start();
                for (int i = 0; i <= 200; i++)
                {
                    AutoItX.ControlClick("ARK: Survival Evolved", "", "", "LEFT");
                    Thread.Sleep(1);
                }
            }

            //Roll Rat | Wood Only
            else if (click_choice == 7)
            {
                timer18.Start();
                for (int i = 0; i <= 200; i++)
                {
                    AutoItX.ControlClick("ARK: Survival Evolved", "", "", "LEFT");
                    Thread.Sleep(1);
                }
            }

            else if (click_choice == 8)
            {
                AutoItX.AutoItSetOption("PixelCoordMode", 2);
                Console.WriteLine(AutoItX.PixelGetColor(1673, 276));

            }
        }

        //Drop & Wait Logic
        private void timer18_Tick(object sender, EventArgs e)
        {
            int click_choice = comboBox1.SelectedIndex;
            var screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            var screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            decimal Width_Converted = Convert.ToInt32(screenWidth);
            decimal Height_Converted = Convert.ToInt32(screenHeight);
            decimal First_Width = 1338 * (Width_Converted / 1920);
            decimal First_Height = 181 * (Height_Converted / 1080);
            decimal Second_Width = 1529 * (Width_Converted / 1920);
            decimal Second_Height = 187 * (Height_Converted / 1080);
            if (timer2.Enabled)
            {
                if (click_choice == 5)
                {
                    timer18.Interval = 5000;
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(300);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(First_Width), Convert.ToInt32(First_Height), 1, 1);
                    Thread.Sleep(300);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "h");
                    Thread.Sleep(300);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(Second_Width), Convert.ToInt32(Second_Height), 1, 1);
                    Thread.Sleep(300);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                    Thread.Sleep(1000);
                }
                else if (click_choice == 6)
                {
                    timer18.Interval = 30000;
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(300);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(First_Width), Convert.ToInt32(First_Height), 1, 1);
                    Thread.Sleep(300);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "h");
                    Thread.Sleep(300);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(Second_Width), Convert.ToInt32(Second_Height), 1, 1);
                    Thread.Sleep(300);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(First_Width), Convert.ToInt32(First_Height), 1, 1);
                    Thread.Sleep(300);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "o");
                    Thread.Sleep(300);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(Second_Width), Convert.ToInt32(Second_Height), 1, 1);
                    Thread.Sleep(300);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(First_Width), Convert.ToInt32(First_Height), 1, 1);
                    Thread.Sleep(300);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(300);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(Second_Width), Convert.ToInt32(Second_Height), 1, 1);
                    Thread.Sleep(300);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(First_Width), Convert.ToInt32(First_Height), 1, 1);
                    Thread.Sleep(300);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "r");
                    Thread.Sleep(300);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(Second_Width), Convert.ToInt32(Second_Height), 1, 1);
                    Thread.Sleep(300);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                    Thread.Sleep(300);
                }
                else if (click_choice == 7)
                {
                    timer18.Interval = 30000;
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(300);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(First_Width), Convert.ToInt32(First_Height), 1, 1);
                    Thread.Sleep(300);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "h");
                    Thread.Sleep(300);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(Second_Width), Convert.ToInt32(Second_Height), 1, 1);
                    Thread.Sleep(300);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(First_Width), Convert.ToInt32(First_Height), 1, 1);
                    Thread.Sleep(300);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "y");
                    Thread.Sleep(300);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(Second_Width), Convert.ToInt32(Second_Height), 1, 1);
                    Thread.Sleep(300);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                    Thread.Sleep(4000);
                }
            }
        }

        //Auto-E Logic
        private void Auto_E(object sender, EventArgs e)
        {
            timer3.Enabled = !timer3.Enabled;
            if (timer3.Enabled)
            {
                checkBox2.Checked = true;
                notifyIcon1.ShowBalloonTip(1000, "Auto-E | ON", "Auto-E | ON", ToolTipIcon.Info);
            }
            else
            {
                checkBox2.Checked = false;
                notifyIcon1.ShowBalloonTip(1000, "Auto-E | OFF", "Auto-E | OFF", ToolTipIcon.Info);
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Interval = 1;
            int e_choice = Convert.ToInt32((numericUpDown1.Value) * 1000);
            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "e");
            Thread.Sleep(e_choice);
        }

        //Auto-U Logic
        private void Auto_U(object sender, EventArgs e)
        {
            timer4.Enabled = !timer4.Enabled;
            if (timer4.Enabled)
            {
                checkBox3.Checked = true;
                notifyIcon1.ShowBalloonTip(1000, "Auto-U | ON", "Auto-U | ON", ToolTipIcon.Info);
            }
            else
            {
                checkBox3.Checked = false;
                notifyIcon1.ShowBalloonTip(1000, "Auto-U | OFF", "Auto-U | OFF", ToolTipIcon.Info);
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "u");
            timer4.Interval = 500;
        }

        //Đi Bộ
        private void Walk(object sender, EventArgs e)
        {
            timer5.Enabled = !timer5.Enabled;
            if (timer5.Enabled)
            {
                checkBox4.Checked = true;
                notifyIcon1.ShowBalloonTip(1000, "Auto Đi Bộ | ON", "Auto Đi Bộ | ON", ToolTipIcon.Info);
            }
            else
            {
                checkBox4.Checked = false;
                notifyIcon1.ShowBalloonTip(1000, "Auto Đi Bộ | OFF", "Auto Đi Bộ | OFF", ToolTipIcon.Info);
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{w down}");
            Thread.Sleep(2500);
            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{w up}");
        }

        //Chạy Nhanh
        private void Sprint(object sender, EventArgs e)
        {
            timer6.Enabled = !timer6.Enabled;
            if (timer6.Enabled)
            {
                checkBox5.Checked = true;
                notifyIcon1.ShowBalloonTip(1000, "Auto Chạy Nhanh | ON", "Auto Chạy Nhanh | ON", ToolTipIcon.Info);
            }
            else
            {
                checkBox5.Checked = false;
                notifyIcon1.ShowBalloonTip(1000, "Auto Chạy Nhanh | OFF", "Auto Chạy Nhanh | OFF", ToolTipIcon.Info);
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{LSHIFT down}");
            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{w down}");
            Thread.Sleep(2500);
            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{LSHIFT up}");
            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{w up}");
        }

        //An-Uong Logic
        private void Eat_Drink(object sender, EventArgs e)
        {
            timer7.Enabled = !timer7.Enabled;
            if (timer7.Enabled)
            {
                checkBox6.Checked = true;
                notifyIcon1.ShowBalloonTip(1000, "Auto Ăn-Uống-Máu | ON", "Auto Ăn-Uống-Máu | ON", ToolTipIcon.Info);
            }
            else
            {
                checkBox6.Checked = false;
                notifyIcon1.ShowBalloonTip(1000, "Auto Ăn-Uống-Máu | OFF", "Auto Ăn-Uống-Máu | OFF", ToolTipIcon.Info);
            }
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            timer7.Interval = 3600000;
            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "9");
            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "8");
        }

        //Pin-Code Logic
        private void Pin_Code(object sender, EventArgs e)
        {
            var screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            var screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            int pin_choice = comboBox2.SelectedIndex;
            int check = comboBox7.SelectedIndex;
            if (screenWidth == "1920" && screenHeight == "1080")
            {
                if (check == 1)
                {
                    if (pin_choice == 0)
                    {
                        for (int i = 0; i <= 999; i++)
                        {
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "e");
                            Thread.Sleep(1000);
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", i.ToString("0000"));
                            if (AutoItX.PixelGetColor(1101, 100) == 8447999)
                            {
                                MessageBox.Show("Pin-Code: " + i.ToString("0000"));
                                Thread.Sleep(5000);
                                break;
                            }
                            Thread.Sleep(19500);
                        }
                    }
                    else if (pin_choice == 1)
                    {
                        for (int i = 1000; i <= 1999; i++)
                        {
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "e");
                            Thread.Sleep(1000);
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", i.ToString("0000"));
                            if (AutoItX.PixelGetColor(1101, 100) == 8447999)
                            {
                                MessageBox.Show("Pin-Code: " + i.ToString("0000"));
                                Thread.Sleep(5000);
                                break;
                            }
                            Thread.Sleep(19500);
                        }
                    }
                    else if (pin_choice == 2)
                    {
                        for (int i = 2000; i <= 2999; i++)
                        {
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "e");
                            Thread.Sleep(1000);
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", i.ToString("0000"));
                            if (AutoItX.PixelGetColor(1101, 100) == 8447999)
                            {
                                MessageBox.Show("Pin-Code: " + i.ToString("0000"));
                                Thread.Sleep(5000);
                                break;
                            }
                            Thread.Sleep(19500);
                        }
                    }
                    else if (pin_choice == 3)
                    {
                        for (int i = 3000; i <= 3999; i++)
                        {
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "e");
                            Thread.Sleep(1000);
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", i.ToString("0000"));
                            if (AutoItX.PixelGetColor(1101, 100) == 8447999)
                            {
                                MessageBox.Show("Pin-Code: " + i.ToString("0000"));
                                Thread.Sleep(5000);
                                break;
                            }
                            Thread.Sleep(19500);
                        }
                    }
                    else if (pin_choice == 4)
                    {
                        for (int i = 4000; i <= 4999; i++)
                        {
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "e");
                            Thread.Sleep(1000);
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", i.ToString("0000"));
                            if (AutoItX.PixelGetColor(1101, 100) == 8447999)
                            {
                                MessageBox.Show("Pin-Code: " + i.ToString("0000"));
                                Thread.Sleep(5000);
                                break;
                            }
                            Thread.Sleep(19500);
                        }
                    }
                    else if (pin_choice == 5)
                    {
                        for (int i = 5000; i <= 5999; i++)
                        {
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "e");
                            Thread.Sleep(1000);
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", i.ToString("0000"));
                            if (AutoItX.PixelGetColor(1101, 100) == 8447999)
                            {
                                MessageBox.Show("Pin-Code: " + i.ToString("0000"));
                                Thread.Sleep(5000);
                                break;
                            }
                            Thread.Sleep(19500);
                        }
                    }
                    else if (pin_choice == 6)
                    {
                        for (int i = 6000; i <= 6999; i++)
                        {
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "e");
                            Thread.Sleep(1000);
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", i.ToString("0000"));
                            if (AutoItX.PixelGetColor(1101, 100) == 8447999)
                            {
                                MessageBox.Show("Pin-Code: " + i.ToString("0000"));
                                Thread.Sleep(5000);
                                break;
                            }
                            Thread.Sleep(19500);
                        }
                    }
                    else if (pin_choice == 7)
                    {
                        for (int i = 7000; i <= 7999; i++)
                        {
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "e");
                            Thread.Sleep(1000);
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", i.ToString("0000"));
                            if (AutoItX.PixelGetColor(1101, 100) == 8447999)
                            {
                                MessageBox.Show("Pin-Code: " + i.ToString("0000"));
                                Thread.Sleep(5000);
                                break;
                            }
                            Thread.Sleep(19500);
                        }
                    }
                    else if (pin_choice == 8)
                    {
                        for (int i = 8000; i <= 8999; i++)
                        {
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "e");
                            Thread.Sleep(1000);
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", i.ToString("0000"));
                            if (AutoItX.PixelGetColor(1101, 100) == 8447999)
                            {
                                MessageBox.Show("Pin-Code: " + i.ToString("0000"));
                                Thread.Sleep(5000);
                                break;
                            }
                            Thread.Sleep(19500);
                        }
                    }
                    else if (pin_choice == 9)
                    {
                        for (int i = 9000; i <= 9999; i++)
                        {
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "e");
                            Thread.Sleep(1000);
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", i.ToString("0000"));
                            if (AutoItX.PixelGetColor(1101, 100) == 8447999)
                            {
                                MessageBox.Show("Pin-Code: " + i.ToString("0000"));
                                Thread.Sleep(5000);
                                break;
                            }
                            Thread.Sleep(19500);
                        }
                    }
                }
            }
            else if (screenWidth == "1366" && screenHeight == "768")
            {
                if (check == 1)
                {
                    if (pin_choice == 0)
                    {
                        for (int i = 0; i <= 999; i++)
                        {
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "e");
                            Thread.Sleep(1000);
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", i.ToString("0000"));
                            if (AutoItX.PixelGetColor(783, 69) == 8447999)
                            {
                                MessageBox.Show("Pin-Code: " + i.ToString("0000"));
                                Thread.Sleep(5000);
                                break;
                            }
                            Thread.Sleep(19500);
                        }
                    }
                    else if (pin_choice == 1)
                    {
                        for (int i = 1000; i <= 1999; i++)
                        {
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "e");
                            Thread.Sleep(1000);
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", i.ToString("0000"));
                            if (AutoItX.PixelGetColor(783, 69) == 8447999)
                            {
                                MessageBox.Show("Pin-Code: " + i.ToString("0000"));
                                Thread.Sleep(5000);
                                break;
                            }
                            Thread.Sleep(19500);
                        }
                    }
                    else if (pin_choice == 2)
                    {
                        for (int i = 2000; i <= 2999; i++)
                        {
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "e");
                            Thread.Sleep(1000);
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", i.ToString("0000"));
                            if (AutoItX.PixelGetColor(783, 69) == 8447999)
                            {
                                MessageBox.Show("Pin-Code: " + i.ToString("0000"));
                                Thread.Sleep(5000);
                                break;
                            }
                            Thread.Sleep(19500);
                        }
                    }
                    else if (pin_choice == 3)
                    {
                        for (int i = 3000; i <= 3999; i++)
                        {
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "e");
                            Thread.Sleep(1000);
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", i.ToString("0000"));
                            if (AutoItX.PixelGetColor(783, 69) == 8447999)
                            {
                                MessageBox.Show("Pin-Code: " + i.ToString("0000"));
                                Thread.Sleep(5000);
                                break;
                            }
                            Thread.Sleep(19500);
                        }
                    }
                    else if (pin_choice == 4)
                    {
                        for (int i = 4000; i <= 4999; i++)
                        {
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "e");
                            Thread.Sleep(1000);
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", i.ToString("0000"));
                            if (AutoItX.PixelGetColor(783, 69) == 8447999)
                            {
                                MessageBox.Show("Pin-Code: " + i.ToString("0000"));
                                Thread.Sleep(5000);
                                break;
                            }
                            Thread.Sleep(19500);
                        }
                    }
                    else if (pin_choice == 5)
                    {
                        for (int i = 5000; i <= 5999; i++)
                        {
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "e");
                            Thread.Sleep(1000);
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", i.ToString("0000"));
                            if (AutoItX.PixelGetColor(783, 69) == 8447999)
                            {
                                MessageBox.Show("Pin-Code: " + i.ToString("0000"));
                                Thread.Sleep(5000);
                                break;
                            }
                            Thread.Sleep(19500);
                        }
                    }
                    else if (pin_choice == 6)
                    {
                        for (int i = 6000; i <= 6999; i++)
                        {
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "e");
                            Thread.Sleep(1000);
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", i.ToString("0000"));
                            if (AutoItX.PixelGetColor(783, 69) == 8447999)
                            {
                                MessageBox.Show("Pin-Code: " + i.ToString("0000"));
                                Thread.Sleep(5000);
                                break;
                            }
                            Thread.Sleep(19500);
                        }
                    }
                    else if (pin_choice == 7)
                    {
                        for (int i = 7000; i <= 7999; i++)
                        {
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "e");
                            Thread.Sleep(1000);
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", i.ToString("0000"));
                            if (AutoItX.PixelGetColor(783, 69) == 8447999)
                            {
                                MessageBox.Show("Pin-Code: " + i.ToString("0000"));
                                Thread.Sleep(5000);
                                break;
                            }
                            Thread.Sleep(19500);
                        }
                    }
                    else if (pin_choice == 8)
                    {
                        for (int i = 8000; i <= 8999; i++)
                        {
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "e");
                            Thread.Sleep(1000);
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", i.ToString("0000"));
                            if (AutoItX.PixelGetColor(783, 69) == 8447999)
                            {
                                MessageBox.Show("Pin-Code: " + i.ToString("0000"));
                                Thread.Sleep(5000);
                                break;
                            }
                            Thread.Sleep(19500);
                        }
                    }
                    else if (pin_choice == 9)
                    {
                        for (int i = 9000; i <= 9999; i++)
                        {
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "e");
                            Thread.Sleep(1000);
                            AutoItX.ControlSend("ARK: Survival Evolved", "", "", i.ToString("0000"));
                            if (AutoItX.PixelGetColor(783, 69) == 8447999)
                            {
                                MessageBox.Show("Pin-Code: " + i.ToString("0000"));
                                Thread.Sleep(5000);
                                break;
                            }
                            Thread.Sleep(19500);
                        }
                    }
                }
            }
        }

        private void Set_Turret(object sender, EventArgs e)
        {
            var screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            var screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            int bullet_amount = comboBox3.SelectedIndex;
            string turret_name = textBox1.Text;
            if (screenWidth == "1920" && screenHeight == "1080")
            {
                Thread.Sleep(1000);
                AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{e down}");
                Thread.Sleep(600);
                AutoItX.MouseClick("LEFT", 1249, 482, 1, 2);
                AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{e up}");
                Thread.Sleep(1000);
                AutoItX.ControlSend("ARK: Survival Evolved", "", "", "3749");
                Thread.Sleep(600);
                AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{e down}");
                Thread.Sleep(600);
                AutoItX.MouseClick("LEFT", 728, 754, 1, 2);
                AutoItX.MouseClick("LEFT", 1253, 550, 1, 2);
                AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{e up}");
                Thread.Sleep(600);
                AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{e down}");
                Thread.Sleep(600);
                AutoItX.MouseClick("LEFT", 648, 435, 1, 2);
                AutoItX.MouseClick("LEFT", 1234, 611, 1, 2);
                AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{e up}");
                Thread.Sleep(600);
                AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{e down}");
                Thread.Sleep(600);
                AutoItX.MouseClick("LEFT", 1150, 802, 1, 2);
                Thread.Sleep(1000);
                AutoItX.Send(turret_name);
                Thread.Sleep(600);
                AutoItX.MouseClick("LEFT", 957, 676, 1, 1);
                AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{e up}");
                Thread.Sleep(600);
                if (bullet_amount == 1)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", 208, 181, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "bullet");
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 164, 280, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (bullet_amount == 2)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", 208, 181, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "bullet");
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 164, 280, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (bullet_amount == 3)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", 208, 181, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "bullet");
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 164, 280, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (bullet_amount == 4)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", 208, 181, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "bullet");
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 164, 280, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (bullet_amount == 5)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", 208, 181, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "bullet");
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 164, 280, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (bullet_amount == 6)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", 208, 181, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "bullet");
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 164, 280, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (bullet_amount == 7)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", 208, 181, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "bullet");
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 164, 280, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (bullet_amount == 8)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", 208, 181, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "bullet");
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 164, 280, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (bullet_amount == 9)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", 208, 181, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "bullet");
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 164, 280, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (bullet_amount == 10)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", 208, 181, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "bullet");
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 164, 280, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (bullet_amount == 11)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", 208, 181, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "bullet");
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 164, 280, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (bullet_amount == 12)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", 208, 181, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "bullet");
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 353, 186, 1, 2);
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 803, 595, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
            }
            if (screenWidth == "1366" && screenHeight == "768")
            {
                Thread.Sleep(1000);
                AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{e down}");
                Thread.Sleep(600);
                AutoItX.MouseClick("LEFT", 889, 343, 1, 2);
                AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{e up}");
                Thread.Sleep(1000);
                AutoItX.ControlSend("ARK: Survival Evolved", "", "", "3749");
                Thread.Sleep(600);
                AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{e down}");
                Thread.Sleep(600);
                AutoItX.MouseClick("LEFT", 518, 536, 1, 2);
                AutoItX.MouseClick("LEFT", 891, 391, 1, 2);
                AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{e up}");
                Thread.Sleep(600);
                AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{e down}");
                Thread.Sleep(600);
                AutoItX.MouseClick("LEFT", 461, 309, 1, 2);
                AutoItX.MouseClick("LEFT", 878, 434, 1, 2);
                AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{e up}");
                Thread.Sleep(600);
                AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{e down}");
                Thread.Sleep(600);
                AutoItX.MouseClick("LEFT", 818, 570, 1, 2);
                Thread.Sleep(1000);
                AutoItX.Send(turret_name);
                Thread.Sleep(600);
                AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{enter}");
                AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{e up}");
                Thread.Sleep(600);
                if (bullet_amount == 1)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", 148, 129, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "bullet");
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 117, 199, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (bullet_amount == 2)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", 148, 129, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "bullet");
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 117, 199, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (bullet_amount == 3)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", 148, 129, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "bullet");
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 117, 199, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (bullet_amount == 4)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", 148, 129, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "bullet");
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 117, 199, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (bullet_amount == 5)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", 148, 129, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "bullet");
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 117, 199, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (bullet_amount == 6)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", 148, 129, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "bullet");
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 117, 199, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (bullet_amount == 7)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", 148, 129, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "bullet");
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 117, 199, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (bullet_amount == 8)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", 148, 129, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "bullet");
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 117, 199, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (bullet_amount == 9)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", 148, 129, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "bullet");
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 117, 199, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (bullet_amount == 10)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", 148, 129, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "bullet");
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 117, 199, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (bullet_amount == 11)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", 148, 129, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "bullet");
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 117, 199, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(600);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (bullet_amount == 12)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", 148, 129, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "bullet");
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 251, 132, 1, 2);
                    Thread.Sleep(600);
                    AutoItX.MouseClick("LEFT", 571, 423, 1, 2);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
            }
        }

        private void Crosshair(object sender, EventArgs e)
        {
            timer8.Enabled = !timer8.Enabled;
            if (timer8.Enabled)
            {
                checkBox7.Checked = true;
                notifyIcon1.ShowBalloonTip(1000, "Tâm Ngắm | ON", "Tâm Ngắm | ON", ToolTipIcon.Info);
            }
            else
            {
                checkBox7.Checked = false;
                notifyIcon1.ShowBalloonTip(1000, "Tâm Ngắm | OFF", "Tâm Ngắm | OFF", ToolTipIcon.Info);
            }
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            var screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            var screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            int Crosshair_Choice = comboBox4.SelectedIndex + 1;
            Brush aBrush = (Brush)Brushes.Red;
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            g.FillRectangle(aBrush, (Screen.PrimaryScreen.Bounds.Width - Crosshair_Choice) / 2, (Screen.PrimaryScreen.Bounds.Height - Crosshair_Choice) / 2, Crosshair_Choice, Crosshair_Choice);
            timer8.Interval = 1;
        }

        private void Auto_C(object sender, EventArgs e)
        {
            timer9.Enabled = !timer9.Enabled;
            if (timer9.Enabled)
            {
                checkBox9.Checked = true;
                notifyIcon1.ShowBalloonTip(1000, "Auto-C | ON", "Auto-C | ON", ToolTipIcon.Info);
            }
            else
            {
                checkBox9.Checked = false;
                notifyIcon1.ShowBalloonTip(1000, "Auto-C | OFF", "Auto-C | OFF", ToolTipIcon.Info);
            }
        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "c");
        }

        private void Auto_T(object sender, EventArgs e)
        {
            timer12.Enabled = !timer12.Enabled;
            if (timer12.Enabled)
            {
                checkBox8.Checked = true;
                notifyIcon1.ShowBalloonTip(1000, "Auto-T | ON", "Auto-T | ON", ToolTipIcon.Info);
            }
            else
            {
                checkBox8.Checked = false;
                notifyIcon1.ShowBalloonTip(1000, "Auto-T | OFF", "Auto-T | OFF", ToolTipIcon.Info);
            }
        }

        private void timer12_Tick(object sender, EventArgs e)
        {
            var screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            var screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            decimal Width_Converted = Convert.ToInt32(screenWidth);
            decimal Height_Converted = Convert.ToInt32(screenHeight);
            decimal New_Width = 163 * (Width_Converted / 1920);
            decimal New_Height = 279 * (Height_Converted / 1080);
            AutoItX.MouseMove(Convert.ToInt32(New_Width), Convert.ToInt32(New_Height), 1);
            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
        }

        private void Holo_Trigger(object sender, EventArgs e)
        {
            timer10.Enabled = !timer10.Enabled;
            if (timer10.Enabled)
            {
                checkBox10.Checked = true;
                notifyIcon1.ShowBalloonTip(1000, "Auto Bắn Holoscope | ON", "Auto Bắn Holoscope | ON", ToolTipIcon.Info);
            }
            else
            {
                checkBox10.Checked = false;
                notifyIcon1.ShowBalloonTip(1000, "Auto Bắn Holoscope | OFF", "Auto Bắn Holoscope | OFF", ToolTipIcon.Info);
            }
        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            var screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            var screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            decimal Width_Converted = Convert.ToInt32(screenWidth);
            decimal Height_Converted = Convert.ToInt32(screenHeight);
            int Trigger_Choice = comboBox5.SelectedIndex;
            timer10.Interval = 1;
            decimal New_Width = 933 * (Width_Converted / 1920);
            decimal New_Height = 514 * (Height_Converted / 1080);
            if (Trigger_Choice == 0)
            {
                if (AutoItX.PixelGetColor(Convert.ToInt32(New_Width), Convert.ToInt32(New_Height)) == 16711680)
                {
                    AutoItX.ControlClick("ARK: Survival Evolved", "", "", "LEFT");
                }
            }
            else if (Trigger_Choice == 1)
            {
                if (AutoItX.PixelGetColor(Convert.ToInt32(New_Width), Convert.ToInt32(New_Height)) == 16776960)
                {
                    AutoItX.ControlClick("ARK: Survival Evolved", "", "", "LEFT");
                }
            }
        }

        private void Harvest(object sender, EventArgs e)
        {
            var screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            var screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            decimal Width_Converted = Convert.ToInt32(screenWidth);
            decimal Height_Converted = Convert.ToInt32(screenHeight);
            int Harvest_Choice = comboBox6.SelectedIndex;
            int Harvest_Toggle = comboBox8.SelectedIndex;
            decimal First_New_Width = 1338 * (Width_Converted / 1920);
            decimal First_New_Height = 181 * (Height_Converted / 1080);
            decimal Second_New_Width = 1479 * (Width_Converted / 1920);
            decimal Second_New_Height = 186 * (Height_Converted / 1080);
            decimal Third_New_Width = 353 * (Width_Converted / 1920);
            decimal Third_New_Height = 186 * (Height_Converted / 1080);

            if (Harvest_Toggle == 1)
            {
                if (Harvest_Choice == 0)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(900);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(First_New_Width), Convert.ToInt32(First_New_Height), 1, 1);
                    Thread.Sleep(50);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "b");
                    Thread.Sleep(50);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(Second_New_Width), Convert.ToInt32(Second_New_Height), 1, 1);
                    Thread.Sleep(50);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (Harvest_Choice == 1)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(900);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(First_New_Width), Convert.ToInt32(First_New_Height), 1, 1);
                    Thread.Sleep(50);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "a");
                    Thread.Sleep(50);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(Second_New_Width), Convert.ToInt32(Second_New_Height), 1, 1);
                    Thread.Sleep(50);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (Harvest_Choice == 2)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(900);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(First_New_Width), Convert.ToInt32(First_New_Height), 1, 1);
                    Thread.Sleep(50);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "s");
                    Thread.Sleep(50);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(Second_New_Width), Convert.ToInt32(Second_New_Height), 1, 1);
                    Thread.Sleep(50);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (Harvest_Choice == 3)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(900);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(First_New_Width), Convert.ToInt32(First_New_Height), 1, 1);
                    Thread.Sleep(50);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "w");
                    Thread.Sleep(50);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(Second_New_Width), Convert.ToInt32(Second_New_Height), 1, 1);
                    Thread.Sleep(50);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (Harvest_Choice == 4)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(900);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(First_New_Width), Convert.ToInt32(First_New_Height), 1, 1);
                    Thread.Sleep(50);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(50);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(Second_New_Width), Convert.ToInt32(Second_New_Height), 1, 1);
                    Thread.Sleep(50);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (Harvest_Choice == 5)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(900);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(First_New_Width), Convert.ToInt32(First_New_Height), 1, 1);
                    Thread.Sleep(50);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "t");
                    Thread.Sleep(50);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(Second_New_Width), Convert.ToInt32(Second_New_Height), 1, 1);
                    Thread.Sleep(50);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
                else if (Harvest_Choice == 6)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "f");
                    Thread.Sleep(900);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(Second_New_Width), Convert.ToInt32(Second_New_Height), 1, 1);
                    Thread.Sleep(50);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(Third_New_Width), Convert.ToInt32(Third_New_Height), 1, 1);
                    Thread.Sleep(50);
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
                }
            }
        }

        private void Fishing(object sender, EventArgs e)
        {
            timer11.Enabled = !timer11.Enabled;
            if (timer11.Enabled)
            {
                checkBox11.Checked = true;
                notifyIcon1.ShowBalloonTip(1000, "Auto Câu Cá | ON", "Auto Câu Cá | ON", ToolTipIcon.Info);
            }
            else
            {
                checkBox11.Checked = false;
                notifyIcon1.ShowBalloonTip(1000, "Auto Câu Cá | OFF", "Auto Câu Cá | OFF", ToolTipIcon.Info);
            }
        }

        private void timer11_Tick(object sender, EventArgs e)
        {
            var screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            var screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            decimal Width_Converted = Convert.ToInt32(screenWidth);
            decimal Height_Converted = Convert.ToInt32(screenHeight);
            decimal First_Width = 1163 * (Width_Converted / 1920);
            decimal First_Height = 867 * (Height_Converted / 1080);
            decimal Second_Height = 961 * (Height_Converted / 1080);
            decimal Second_Width = 1143 * (Width_Converted / 1920);
            decimal Third_Height = 993 * (Height_Converted / 1080);
            decimal Third_Width = 1182 * (Width_Converted / 1920);
            decimal Fourth_Height = 929 * (Height_Converted / 1080);
            decimal Fourth_Width = 1164 * (Width_Converted / 1920);
            decimal Fifth_Width = 1179 * (Width_Converted / 1920);
            decimal Fifth_Height = 1016 * (Height_Converted / 1080);
            decimal Sixth_Height = 928 * (Height_Converted / 1080);
            decimal Sixth_Width = 1156 * (Width_Converted / 1920);
            decimal Seventh_Height = 947 * (Height_Converted / 1080);
            decimal Seventh_Width = 1212 * (Width_Converted / 1920);
            decimal Eighth_Height = 868 * (Height_Converted / 1080);
            decimal Eighth_Width = 1138 * (Width_Converted / 1920);
            if (screenWidth == "1920" && screenHeight == "1080")
            {
                if (AutoItX.PixelGetColor(1163, 867) == 16777215 && AutoItX.PixelGetColor(1163, 961) == 16777215)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "a");
                    Thread.Sleep(10);
                }
                if (AutoItX.PixelGetColor(1163, 867) == 16777215 && AutoItX.PixelGetColor(1143, 928) == 16777215 && AutoItX.PixelGetColor(1163, 993) == 16777215 && AutoItX.PixelGetColor(1182, 929) != 16777215)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "c");
                    Thread.Sleep(10);
                }
                if (AutoItX.PixelGetColor(1163, 867) == 16777215 && AutoItX.PixelGetColor(1143, 928) == 16777215 && AutoItX.PixelGetColor(1163, 993) == 16777215 && AutoItX.PixelGetColor(1182, 929) == 16777215 && AutoItX.PixelGetColor(1164, 929) != 16777215 && AutoItX.PixelGetColor(1179, 1016) != 16777215)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "d");
                    Thread.Sleep(10);
                }
                if (AutoItX.PixelGetColor(1163, 867) == 16777215 && AutoItX.PixelGetColor(1143, 928) == 16777215 && AutoItX.PixelGetColor(1163, 993) == 16777215 && AutoItX.PixelGetColor(1182, 929) == 16777215 && AutoItX.PixelGetColor(1164, 929) == 16777215)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "e");
                    Thread.Sleep(10);
                }
                if (AutoItX.PixelGetColor(1163, 867) == 16777215 && AutoItX.PixelGetColor(1143, 928) == 16777215 && AutoItX.PixelGetColor(1163, 993) == 16777215 && AutoItX.PixelGetColor(1179, 1016) == 16777215)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "q");
                    Thread.Sleep(10);
                }
                if (AutoItX.PixelGetColor(1163, 867) == 16777215 && AutoItX.PixelGetColor(1163, 993) == 16777215 && AutoItX.PixelGetColor(1143, 928) != 16777215 && AutoItX.PixelGetColor(1156, 947) != 16777215)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "s");
                    Thread.Sleep(10);
                }
                if (AutoItX.PixelGetColor(1163, 867) == 16777215 && AutoItX.PixelGetColor(1212, 868) == 16777215)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "w");
                    Thread.Sleep(10);
                }
                if (AutoItX.PixelGetColor(1163, 867) != 16777215 && AutoItX.PixelGetColor(1163, 961) == 16777215 && AutoItX.PixelGetColor(1138, 867) == 16777215)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "x");
                    Thread.Sleep(10);
                }
                if (AutoItX.PixelGetColor(1163, 867) == 16777215 && AutoItX.PixelGetColor(1163, 993) == 16777215 && AutoItX.PixelGetColor(1143, 928) != 16777215 && AutoItX.PixelGetColor(1156, 947) == 16777215)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "z");
                    Thread.Sleep(10);
                }
            }
            if (screenWidth != "1920" && screenHeight != "1080")
            {
                if (AutoItX.PixelGetColor(Convert.ToInt32(First_Width), Convert.ToInt32(First_Height)) == 16777215 && AutoItX.PixelGetColor(Convert.ToInt32(First_Width), Convert.ToInt32(Second_Height)) == 16777215)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "a");
                    Thread.Sleep(10);
                }
                if (AutoItX.PixelGetColor(Convert.ToInt32(First_Width), Convert.ToInt32(First_Height)) == 16777215 && AutoItX.PixelGetColor(Convert.ToInt32(Second_Width), Convert.ToInt32(Sixth_Height)) == 16777215 && AutoItX.PixelGetColor(Convert.ToInt32(First_Width), Convert.ToInt32(Third_Height)) == 16777215 && AutoItX.PixelGetColor(Convert.ToInt32(Third_Width), Convert.ToInt32(Fourth_Height)) != 16777215)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "c");
                    Thread.Sleep(10);
                }
                if (AutoItX.PixelGetColor(Convert.ToInt32(First_Width), Convert.ToInt32(First_Height)) == 16777215 && AutoItX.PixelGetColor(Convert.ToInt32(Second_Width), Convert.ToInt32(Sixth_Height)) == 16777215 && AutoItX.PixelGetColor(Convert.ToInt32(First_Width), Convert.ToInt32(Third_Height)) == 16777215 && AutoItX.PixelGetColor(Convert.ToInt32(Third_Width), Convert.ToInt32(Fourth_Height)) == 16777215 && AutoItX.PixelGetColor(Convert.ToInt32(Fourth_Width), Convert.ToInt32(Fourth_Height)) != 16777215 && AutoItX.PixelGetColor(Convert.ToInt32(Fifth_Width), Convert.ToInt32(Fifth_Height)) != 16777215)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "d");
                    Thread.Sleep(10);
                }
                if (AutoItX.PixelGetColor(Convert.ToInt32(First_Width), Convert.ToInt32(First_Height)) == 16777215 && AutoItX.PixelGetColor(Convert.ToInt32(Second_Width), Convert.ToInt32(Sixth_Height)) == 16777215 && AutoItX.PixelGetColor(Convert.ToInt32(First_Width), Convert.ToInt32(Third_Height)) == 16777215 && AutoItX.PixelGetColor(Convert.ToInt32(Third_Width), Convert.ToInt32(Fourth_Height)) == 16777215 && AutoItX.PixelGetColor(Convert.ToInt32(Fourth_Width), Convert.ToInt32(Fourth_Height)) == 16777215)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "e");
                    Thread.Sleep(10);
                }
                if (AutoItX.PixelGetColor(Convert.ToInt32(First_Width), Convert.ToInt32(First_Height)) == 16777215 && AutoItX.PixelGetColor(Convert.ToInt32(Second_Width), Convert.ToInt32(Sixth_Height)) == 16777215 && AutoItX.PixelGetColor(Convert.ToInt32(First_Width), Convert.ToInt32(Third_Height)) == 16777215 && AutoItX.PixelGetColor(Convert.ToInt32(Fifth_Width), Convert.ToInt32(Fifth_Height)) == 16777215)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "q");
                    Thread.Sleep(10);
                }
                if (AutoItX.PixelGetColor(Convert.ToInt32(First_Width), Convert.ToInt32(First_Height)) == 16777215 && AutoItX.PixelGetColor(Convert.ToInt32(First_Width), Convert.ToInt32(Third_Height)) == 16777215 && AutoItX.PixelGetColor(Convert.ToInt32(Second_Width), Convert.ToInt32(Sixth_Height)) != 16777215 && AutoItX.PixelGetColor(Convert.ToInt32(Sixth_Width), Convert.ToInt32(Seventh_Height)) != 16777215)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "s");
                    Thread.Sleep(10);
                }
                if (AutoItX.PixelGetColor(Convert.ToInt32(First_Width), Convert.ToInt32(First_Height)) == 16777215 && AutoItX.PixelGetColor(Convert.ToInt32(Seventh_Width), Convert.ToInt32(Eighth_Height)) == 16777215)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "w");
                    Thread.Sleep(10);
                }
                if (AutoItX.PixelGetColor(Convert.ToInt32(First_Width), Convert.ToInt32(First_Height)) != 16777215 && AutoItX.PixelGetColor(Convert.ToInt32(First_Width), Convert.ToInt32(Second_Height)) == 16777215 && AutoItX.PixelGetColor(Convert.ToInt32(Eighth_Width), Convert.ToInt32(First_Height)) == 16777215)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "x");
                    Thread.Sleep(10);
                }
                if (AutoItX.PixelGetColor(Convert.ToInt32(First_Width), Convert.ToInt32(First_Height)) == 16777215 && AutoItX.PixelGetColor(Convert.ToInt32(First_Width), Convert.ToInt32(Third_Height)) == 16777215 && AutoItX.PixelGetColor(Convert.ToInt32(Second_Width), Convert.ToInt32(Sixth_Height)) != 16777215 && AutoItX.PixelGetColor(Convert.ToInt32(Sixth_Width), Convert.ToInt32(Seventh_Height)) == 16777215)
                {
                    AutoItX.ControlSend("ARK: Survival Evolved", "", "", "z");
                    Thread.Sleep(10);
                }
            }
        }

        private void Auto_Split(object sender, EventArgs e)
        {
            int split_toggle = comboBox9.SelectedIndex;
            if (split_toggle == 1)
            {
                timer13.Enabled = !timer13.Enabled;
                if (timer13.Enabled)
                {
                    var screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
                    var screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
                    decimal Width_Converted = Convert.ToInt32(screenWidth);
                    decimal Height_Converted = Convert.ToInt32(screenHeight);
                    decimal First_Width = 460 * (Width_Converted / 1920);
                    decimal First_Height = 185 * (Height_Converted / 1080);
                    decimal Second_Width = 505 * (Width_Converted / 1920);
                    decimal Second_Height = 222 * (Height_Converted / 1080);
                    checkBox12.Checked = true;
                    notifyIcon1.ShowBalloonTip(1000, "Auto Tách | ON", "Auto Tách | ON", ToolTipIcon.Info);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(First_Width), Convert.ToInt32(First_Height), 1, 0);
                    Thread.Sleep(50);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(Second_Width), Convert.ToInt32(Second_Height), 1, 0);
                    Thread.Sleep(50);
                }
                else
                {
                    checkBox12.Checked = false;
                    notifyIcon1.ShowBalloonTip(1000, "Auto Tách | OFF", "Auto Tách | OFF", ToolTipIcon.Info);
                }
            }
        }

        private void timer13_Tick(object sender, EventArgs e)
        {
            var screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            var screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            decimal Width_Converted = Convert.ToInt32(screenWidth);
            decimal Height_Converted = Convert.ToInt32(screenHeight);
            int Split_Toggle = comboBox9.SelectedIndex;
            int Split_Choice = comboBox10.SelectedIndex;
            if (Split_Toggle == 1)
            {
                if (Split_Choice == 0)
                {
                    decimal First_Width = 258 * (Width_Converted / 1920);
                    decimal First_Height = 281 * (Height_Converted / 1080);
                    decimal Second_Width = 259 * (Width_Converted / 1920);
                    decimal Second_Height = 472 * (Height_Converted / 1080);
                    decimal Third_Width = 374 * (Width_Converted / 1920);
                    decimal Third_Height = 522 * (Height_Converted / 1080);
                    AutoItX.MouseClick("RIGHT", Convert.ToInt32(First_Width), Convert.ToInt32(First_Height), 1, 0);
                    Thread.Sleep(50);
                    AutoItX.MouseMove(Convert.ToInt32(Second_Width), Convert.ToInt32(Second_Height), 0);
                    Thread.Sleep(50);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(Third_Width), Convert.ToInt32(Third_Height), 1, 0);
                    Thread.Sleep(50);
                }
                else if (Split_Choice == 1)
                {
                    AutoItX.AutoItSetOption("MouseClickDragDelay", 50);
                    decimal First_Width = 351 * (Width_Converted / 1920);
                    decimal First_Height = 280 * (Height_Converted / 1080);
                    decimal Second_Width = 258 * (Width_Converted / 1920);
                    decimal Second_Height = 281 * (Height_Converted / 1080);
                    AutoItX.MouseClickDrag("LEFT", Convert.ToInt32(First_Width), Convert.ToInt32(First_Height), Convert.ToInt32(Second_Width), Convert.ToInt32(Second_Height), 0);
                    Thread.Sleep(50);
                }
            }
        }

        private void Auto_Setting(object sender, EventArgs e)
        {
            var screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            var screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            decimal Width_Converted = Convert.ToInt32(screenWidth);
            decimal Height_Converted = Convert.ToInt32(screenHeight);
            decimal First_Width = 961 * (Width_Converted / 1920);
            decimal First_Height = 315 * (Height_Converted / 1080);
            decimal Second_Width = 989 * (Width_Converted / 1920);
            decimal Second_Height = 67 * (Height_Converted / 1080);
            decimal Third_Width = 1689 * (Width_Converted / 1920);
            decimal Third_Height = 406 * (Height_Converted / 1080);
            decimal Fourth_Width = 1686 * (Width_Converted / 1920);
            decimal Fourth_Height = 439 * (Height_Converted / 1080);
            decimal Fifth_Width = 1687 * (Width_Converted / 1920);
            decimal Fifth_Height = 471 * (Height_Converted / 1080);
            decimal Sixth_Width = 1683 * (Width_Converted / 1920);
            decimal Sixth_Height = 599 * (Height_Converted / 1080);
            decimal Seventh_Width = 1684 * (Width_Converted / 1920);
            decimal Seventh_Height = 629 * (Height_Converted / 1080);
            decimal Eigth_Width = 1689 * (Width_Converted / 1920);
            decimal Eigth_Height = 406 * (Height_Converted / 1080);
            decimal Ninth_Width = 1687 * (Width_Converted / 1920);
            decimal Ninth_Height = 695 * (Height_Converted / 1080);
            decimal Tenth_Width = 501 * (Width_Converted / 1920);
            decimal Tenth_Height = 630 * (Height_Converted / 1080);
            decimal Eleventh_Width = 1623 * (Width_Converted / 1920);
            decimal Eleventh_Height = 148 * (Height_Converted / 1080);
            AutoItX.ControlSend("ARK: Survival Evolved", "", "", "{esc}");
            Thread.Sleep(200);
            AutoItX.MouseClick("LEFT", Convert.ToInt32(First_Width), Convert.ToInt32(First_Height), 1, 1);
            Thread.Sleep(100);
            AutoItX.MouseClick("LEFT", Convert.ToInt32(Second_Width), Convert.ToInt32(Second_Height), 1, 1);
            Thread.Sleep(100);
            AutoItX.MouseClick("LEFT", Convert.ToInt32(Third_Width), Convert.ToInt32(Third_Height), 3, 1);
            Thread.Sleep(100);
            AutoItX.MouseClick("LEFT", Convert.ToInt32(Fourth_Width), Convert.ToInt32(Fourth_Height), 3, 1);
            Thread.Sleep(100);
            AutoItX.MouseClick("LEFT", Convert.ToInt32(Fifth_Width), Convert.ToInt32(Fifth_Height), 3, 1);
            Thread.Sleep(100);
            AutoItX.MouseClick("LEFT", Convert.ToInt32(Sixth_Width), Convert.ToInt32(Sixth_Height), 3, 1);
            Thread.Sleep(100);
            AutoItX.MouseClick("LEFT", Convert.ToInt32(Seventh_Width), Convert.ToInt32(Seventh_Height), 3, 1);
            Thread.Sleep(100);
            AutoItX.MouseClick("LEFT", Convert.ToInt32(Eigth_Width), Convert.ToInt32(Eigth_Height), 3, 1);
            Thread.Sleep(100);
            AutoItX.MouseClick("LEFT", Convert.ToInt32(Ninth_Width), Convert.ToInt32(Ninth_Height), 3, 1);
            Thread.Sleep(100);
            AutoItX.MouseClick("LEFT", Convert.ToInt32(Tenth_Width), Convert.ToInt32(Tenth_Height), 3, 1);
            Thread.Sleep(100);
            AutoItX.MouseClick("LEFT", Convert.ToInt32(Eleventh_Width), Convert.ToInt32(Eleventh_Height), 1, 1);
            Thread.Sleep(100);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 Kibble_Form = new Form2();
            Kibble_Form.ShowDialog();
        }

        private void Auto_JoinServer(object sender, EventArgs e)
        {
            timer14.Enabled = !timer14.Enabled;
            if (timer14.Enabled)
            {
                checkBox13.Checked = true;
                notifyIcon1.ShowBalloonTip(1000, "Auto Join Server | ON", "Auto Join Server | ON", ToolTipIcon.Info);
            }
            else
            {
                checkBox13.Checked = false;
                notifyIcon1.ShowBalloonTip(1000, "Auto Join Server | OFF", "Auto Join Server | OFF", ToolTipIcon.Info);
            }
        }

        private void timer14_Tick(object sender, EventArgs e)
        {
            var screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            var screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            decimal Width_Converted = Convert.ToInt32(screenWidth);
            decimal Height_Converted = Convert.ToInt32(screenHeight);
            decimal First_Width = 961 * (Width_Converted / 1920);
            decimal First_Height = 617 * (Height_Converted / 1080);
            decimal Second_Width = 991 * (Width_Converted / 1920);
            decimal Second_Height = 941 * (Height_Converted / 1080);
            decimal Third_Width = 1229 * (Width_Converted / 1920);
            decimal Third_Height = 940 * (Height_Converted / 1080);
            decimal Fourth_Width = 473 * (Width_Converted / 1920);
            decimal Fourth_Height = 242 * (Height_Converted / 1080);
            AutoItX.MouseClick("LEFT", Convert.ToInt32(First_Width), Convert.ToInt32(First_Height), 1, 1);
            Thread.Sleep(100);
            AutoItX.MouseClick("LEFT", Convert.ToInt32(Second_Width), Convert.ToInt32(Second_Height), 1, 1);
            Thread.Sleep(100);
            AutoItX.MouseClick("LEFT", Convert.ToInt32(First_Width), Convert.ToInt32(First_Height), 1, 1);
            Thread.Sleep(100);
            AutoItX.MouseClick("LEFT", Convert.ToInt32(Third_Width), Convert.ToInt32(Third_Height), 1, 1);
            Thread.Sleep(100);
            AutoItX.MouseClick("LEFT", Convert.ToInt32(Fourth_Width), Convert.ToInt32(Fourth_Height), 1, 1);
            Thread.Sleep(100);
            AutoItX.MouseClick("LEFT", Convert.ToInt32(First_Width), Convert.ToInt32(First_Height), 1, 1);
            Thread.Sleep(5000);
        }
        private void Log_Reporter(object sender, EventArgs e)
        {
            timer15.Enabled = !timer15.Enabled;
            if (timer15.Enabled)
            {
                checkBox14.Checked = true;
                notifyIcon1.ShowBalloonTip(1000, "Auto Report Tribe-Log | ON", "Auto Report Tribe-Log | ON", ToolTipIcon.Info);
            }
            else
            {
                checkBox14.Checked = false;
                notifyIcon1.ShowBalloonTip(1000, "Auto Report Tribe-Log | OFF", "Auto Report Tribe-Log | OFF", ToolTipIcon.Info);
            }
        }
        private void timer15_Tick(object sender, EventArgs e)
        {
            timer15.Interval = 300000;
            AutoItX.Send("!{PRINTSCREEN}");
            Thread.Sleep(500);
            AutoItX.Send("!{TAB}");
            Thread.Sleep(500);
            AutoItX.Send("^v");
            Thread.Sleep(500);
            AutoItX.Send("{ENTER}");
            Thread.Sleep(500);
            AutoItX.Send("!{TAB}");
            Thread.Sleep(500);
        }

        private void Respawn(object sender, EventArgs e)
        {
            timer16.Enabled = !timer16.Enabled;
            if (timer16.Enabled)
            {
                checkBox15.Checked = true;
                notifyIcon1.ShowBalloonTip(1000, "Auto Respawn | ON", "Auto Respawn | ON", ToolTipIcon.Info);
            }
            else
            {
                checkBox15.Checked = false;
                notifyIcon1.ShowBalloonTip(1000, "Auto Respawn | OFF", "Auto Respawn | OFF", ToolTipIcon.Info);
            }
        }

        private void timer16_Tick(object sender, EventArgs e)
        {
            int Spawn_Choice = comboBox11.SelectedIndex;
            var screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            var screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            decimal Width_Converted = Convert.ToInt32(screenWidth);
            decimal Height_Converted = Convert.ToInt32(screenHeight);
            decimal First_Width = 506 * (Width_Converted / 1920);
            decimal First_Height = 429 * (Height_Converted / 1080);
            decimal Second_Width = 848 * (Width_Converted / 1920);
            decimal Second_Height = 977 * (Height_Converted / 1080);
            decimal Third_Width = 506 * (Width_Converted / 1920);
            decimal Third_Height = 429 * (Height_Converted / 1080);
            decimal Fourth_Width = 848 * (Width_Converted / 1920);
            decimal Fourth_Height = 977 * (Height_Converted / 1080);
            if (screenWidth == "800" && screenHeight == "600")
            {
                if (Spawn_Choice == 0)
                {
                    if (AutoItX.PixelGetColor(435, 365) != 65535)
                    {
                        AutoItX.MouseClick("LEFT", 310, 358, 1, 1);
                        Thread.Sleep(300);
                        AutoItX.MouseClick("LEFT", 376, 369, 1, 1);
                        Thread.Sleep(300);
                        AutoItX.MouseMove(435, 365, 1);
                        Thread.Sleep(500);
                        if (AutoItX.PixelGetColor(435, 365) == 65535)
                        {
                            Thread.Sleep(2000);
                            AutoItX.MouseClick("LEFT", 260, 483, 1, 1);
                        }
                        else Thread.Sleep(1000);
                    }
                }
            }

            else if (screenWidth != "800" && screenHeight != "600")
            {
                if (Spawn_Choice == 0)
                {
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(First_Width), Convert.ToInt32(First_Height), 1, 1);
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", Convert.ToInt32(Second_Width), Convert.ToInt32(Second_Height), 1, 1);
                    Thread.Sleep(15000);
                }
                else if (Spawn_Choice == 2)
                {
                    AutoItX.MouseClick("LEFT", 375, 180, 1, 1);
                    Thread.Sleep(1000);
                    AutoItX.MouseClick("LEFT", 605, 695, 1, 1);
                    Thread.Sleep(15000);
                }
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            xHotKey.Pressed -= Auto_Click;
            xHotKey.Pressed -= Auto_E;
            xHotKey.Pressed -= Auto_U;
            xHotKey.Pressed -= Walk;
            xHotKey.Pressed -= Sprint;
            xHotKey.Pressed -= Eat_Drink;
            xHotKey.Pressed -= Pin_Code;
            xHotKey.Pressed -= Set_Turret;
            xHotKey.Pressed -= Crosshair;
            xHotKey.Pressed -= Auto_C;
            xHotKey.Pressed -= Holo_Trigger;
            xHotKey.Pressed -= Harvest;
            xHotKey.Pressed -= Fishing;
            xHotKey.Pressed -= Auto_T;
            xHotKey.Pressed -= Auto_Split;
            xHotKey.Pressed -= Auto_Setting;
            xHotKey.Pressed -= Auto_JoinServer;
            xHotKey.Pressed -= Log_Reporter;
            xHotKey.Pressed -= Respawn;
            notifyIcon1.Dispose();
            xHotKey.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "English")
            {
                button1.Text = "Tiếng Việt";
                comboBox1.Items[0] = "Left";
                comboBox1.Items[1] = "Right";
                comboBox1.Items[2] = "Left + Right";
                label6.Text = "Food - Drink";
                label8.Text = "Set Turret";
                textBox1.Text = "Turret Name";
                label25.Text = "Shoot";
                comboBox5.Items[0] = "Red Holo";
                comboBox5.Items[1] = "Yellow Holo";
                label27.Text = "Harvest";
                comboBox6.Items[1] = "Advanced Crops / Sap";
                comboBox6.Items[2] = "Snail / Stone";
                comboBox6.Items[3] = "Wood";
                label4.Text = "Walk";
                label5.Text = "Sprint";
                label21.Text = "Crosshair";
                label29.Text = "Fishing";
                label39.Text = "Respawn";
            }
            else if (button1.Text == "Tiếng Việt")
            {
                button1.Text = "English";
                comboBox1.Items[0] = "Trái";
                comboBox1.Items[1] = "Phải";
                comboBox1.Items[2] = "Trái + Phải";
                label6.Text = "Ăn - Uống";
                label8.Text = "Đặt Turret";
                textBox1.Text = "Ten Turret";
                label25.Text = "Bắn";
                comboBox5.Items[0] = "Holo Đỏ";
                comboBox5.Items[1] = "Holo Vàng";
                label27.Text = "Thu";
                comboBox6.Items[1] = "Quả Hịn / Sap";
                comboBox6.Items[2] = "Ốc Sên / Stone";
                comboBox6.Items[3] = "Gỗ";
                label4.Text = "Đi Bộ";
                label5.Text = "Chạy Nhanh";
                label21.Text = "Tâm Ngắm";
                label29.Text = "Câu Cá";
                label39.Text = "Hồi Sinh";
            }
        }
    }
}