using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace GirlScreen
{
    public partial class Form1 : Form
    {
        private byte[] password;

        //Declare MouseHookProcedure as a HookProc type.
        WinAPI.HookProc MouseHookProcedure;
        WinAPI.HookProc KeyboardHookProcedure;
        private static int hMouseHook, hKeyboardHook;

        public Form1()
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey("Software\\GirlScreen");
            password = (byte[])reg.GetValue("test", new byte[] {0xd4, 0x1d, 0x8c, 0xd9, 0x8f, 0x00, 0xb2, 0x04, 0xe9, 0x80, 0x09, 0x98, 0xec, 0xf8, 0x42, 0x7e});
            InitializeComponent();
        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (contextMenuStrip1.Enabled == false)
                e.Cancel = true;
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (contextMenuStrip1.Enabled == false)
                LockMouse();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (contextMenuStrip1.Enabled == false)
                LockMouse();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt == true && e.KeyCode == Keys.Enter)
                ToogleFullScreen();
        }

        private void menuItemFullScreen_Click(object sender, EventArgs e)
        {
            ToogleFullScreen();
        }

        private void menuItemChangePicture_Click(object sender, EventArgs e)
        {
            LoadPicture();
        }

        private void menuItemSetPassword_Click(object sender, EventArgs e)
        {
            labelStatus.Visible = true;
            textBoxPassword.Visible = true;
        }

        private void menuItemLockScreen_Click(object sender, EventArgs e)
        {
            menuItemLockScreen.Checked = !menuItemLockScreen.Checked;
            if (menuItemLockScreen.Checked)
                LockComputer();
            else
                UnLockComputer();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (contextMenuStrip1.Enabled)
                LoadPicture();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                MD5 md5 = MD5.Create();
                md5.ComputeHash(Encoding.UTF8.GetBytes(textBoxPassword.Text));

                if (contextMenuStrip1.Enabled)
                {
                    labelStatus.Visible = false;
                    textBoxPassword.Visible = false;
                    password = md5.Hash;
                    RegistryKey reg = Registry.CurrentUser.CreateSubKey("Software\\GirlScreen");
                    reg.SetValue("test", md5.Hash, RegistryValueKind.Binary);
                }
                else if (System.Collections.StructuralComparisons.StructuralEqualityComparer.Equals(md5.Hash, password))
                {
                    textBoxPassword.Clear();
                    UnLockComputer();
                    menuItemLockScreen.Checked = false;
                }
            }
        }
        
        private void ToogleFullScreen()
        {
            menuItemFullScreen.Checked = !menuItemFullScreen.Checked;
            if (menuItemFullScreen.Checked)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void LoadPicture()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                this.ClientSize = pictureBox1.Image.Size;
            }
        }

        private void DisablePolicies(bool disabled)
        {
            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            reg.SetValue("DisableTaskMgr", disabled, RegistryValueKind.DWord);
            reg.SetValue("DisableLockWorkstation", disabled, RegistryValueKind.DWord);
            reg.SetValue("DisableChangePassword", disabled, RegistryValueKind.DWord);
            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
            reg.SetValue("NoLogoff", disabled, RegistryValueKind.DWord);
            reg.SetValue("NoClose", disabled, RegistryValueKind.DWord);
            reg = Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            reg.SetValue("HideFastUserSwitching", disabled, RegistryValueKind.DWord);
        }
      
        private void LockMouse()
        {
            Rectangle controlRectangle = textBoxPassword.RectangleToScreen(textBoxPassword.ClientRectangle);
            WinAPI.RECT rect;
            rect.Left = controlRectangle.Left;
            rect.Top = controlRectangle.Top;
            rect.Right = controlRectangle.Right;
            rect.Bottom = controlRectangle.Bottom;
            WinAPI.ClipCursor(ref rect);
            WinAPI.SetActiveWindow(Handle);
            WinAPI.SetForegroundWindow(this.Handle);
        }

        public static int KeyboardHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
            {
                return WinAPI.CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
            }
            else
            {
                switch ((int)wParam)
                {

                    case WinAPI.WM_KEYDOWN:
                    case WinAPI.WM_KEYUP:
                        switch (Marshal.ReadInt32(lParam))
                        {
                            case (int)WinAPI.VK.LWIN:
                            case (int)WinAPI.VK.RWIN:
                            case (int)WinAPI.VK.ESCAPE:
                            case (int)WinAPI.VK.TAB:
                                return 1;
                            default:
                                break;
                        }
                        break;
                    case 0x104:
                    case 0x105:
                    case 0x106:
                    case 0x107:
                        return 1;
                    default:
                        break;
                }
            }
            return WinAPI.CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
        }

        private void ToogleHook()
        {
            if (hKeyboardHook == 0)
            {
                // Create an instance of HookProc.
                KeyboardHookProcedure = new WinAPI.HookProc(KeyboardHookProc);

                hKeyboardHook = WinAPI.SetWindowsHookEx(WinAPI.WH_KEYBOARD_LL,
                            KeyboardHookProcedure,
                            (IntPtr)0,
                            0);
                if (hKeyboardHook == 0)
                {
                    MessageBox.Show("SetWindowsHookEx Failed");
                    return;
                }
            }
            else
            {
                bool ret = WinAPI.UnhookWindowsHookEx(hKeyboardHook);
                if (ret == false)
                {
                    MessageBox.Show("UnhookWindowsHookEx Failed");
                    return;
                }
                hKeyboardHook = 0;
            }
        }

        private void LockComputer()
        {
            Process[] p = Process.GetProcesses();
            foreach (Process p1 in p)
            {
                try
                {
                    if (p1.ProcessName.ToLower().Trim() == "taskmgr")
                    {
                        p1.Kill();
                    }
                }
                catch
                {
                }
            }

            LockMouse();
            ToogleHook();
            DisablePolicies(true);
            contextMenuStrip1.Enabled = false;
            labelStatus.Visible = true;
            textBoxPassword.Visible = true;
        }

        private void UnLockComputer()
        {
            WinAPI.ClipCursor(IntPtr.Zero);
            ToogleHook();
            DisablePolicies(false);
            contextMenuStrip1.Enabled = true;
            labelStatus.Visible = false;
            textBoxPassword.Visible = false;
        }
        
    }
}
