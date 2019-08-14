using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WindowsInput;
using WindowsInput.Native;

namespace Chrysothrix
{
    internal static class Program
    {
        private static void Main()
        {
            Process[] procs = Process.GetProcessesByName("firefox");
            foreach(Process p in procs){
                string title = p.MainWindowTitle;
                if (p.MainWindowHandle != IntPtr.Zero)
                {
                    SetForegroundWindow(p.MainWindowHandle);
                    InputSimulator i = new InputSimulator();
                    i.Keyboard.KeyDown(VirtualKeyCode.CONTROL);
                    i.Keyboard.KeyDown(VirtualKeyCode.VK_T);
                    i.Keyboard.KeyUp(VirtualKeyCode.CONTROL);
                }
            }
        }

        [DllImport("user32")]
        private static extern bool SetForegroundWindow(IntPtr hwnd);
    }
}

