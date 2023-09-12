using System.Runtime.InteropServices;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Mawenzy.Util
{
    /// JLB <summary>
    /// A class to get the desktop icon positions.
    /// Internal since the app may maintain different positions after loading.
    /// Adapted from http://social.msdn.microsoft.com/Forums/en-US/winforms/thread/d7df8a4d-fc0f-4b62-80c9-7768756456e6/
    /// </summary>
    internal class DesktopIcs
    {
        public const uint LVM_FIRST = 0x1000;
        public const uint LVM_GETITEMCOUNT = LVM_FIRST + 4;
        public const uint LVM_GETITEMW = LVM_FIRST + 75;
        public const uint LVM_GETITEMPOSITION = LVM_FIRST + 16;
        public const uint PROCESS_VM_OPERATION = 0x0008;
        public const uint PROCESS_VM_READ = 0x0010;
        public const uint PROCESS_VM_WRITE = 0x0020;
        public const uint MEM_COMMIT = 0x1000;
        public const uint MEM_RELEASE = 0x8000;
        public const uint MEM_RESERVE = 0x2000;
        public const uint PAGE_READWRITE = 4;
        public const int LVIF_TEXT = 0x0001;

        [DllImport("kernel32.dll")]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress,
            uint dwSize, uint flAllocationType, uint flProtect);
        [DllImport("kernel32.dll")]
        public static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress,
           uint dwSize, uint dwFreeType);
        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr handle);
        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,
           IntPtr lpBuffer, int nSize, ref uint vNumberOfBytesRead);
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,
           IntPtr lpBuffer, int nSize, ref uint vNumberOfBytesRead);
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(uint dwDesiredAccess,
            bool bInheritHandle, uint dwProcessId);
        [DllImport("user32.DLL")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        [DllImport("user32.DLL")]
        public static extern IntPtr FindWindow(string lpszClass, string lpszWindow);
        [DllImport("user32.DLL")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent,
            IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint dwProcessId);

        [StructLayout(LayoutKind.Sequential)]
        public struct LVITEM
        {
            public int mask;
            public int iItem;
            public int iSubItem;
            public int state;
            public int stateMask;
            public IntPtr pszText; // string
            public int cchTextMax;
            public int iImage;
            public IntPtr lParam;
            public int iIndent;
            public int iGroupId;
            public int cColumns;
            public IntPtr puColumns;
        }

        /// <summary>
        /// Gets the desktop icons by file name.
        /// </summary>
        /// <returns>A dictionary of file names to icon location points.</returns>
        static internal Dictionary<string,Point> GetDesktop()
        {
            Dictionary<string, Point> locs = new Dictionary<string,Point>();
            
            // get the handle of the desktop listview
            IntPtr hDesk = FindWindow("Progman", "Program Manager");
            hDesk = FindWindowEx(hDesk, IntPtr.Zero, "SHELLDLL_DefView", null);
            hDesk = FindWindowEx(hDesk, IntPtr.Zero, "SysListView32", "FolderView");
 
            //Get total count of the icons on the desktop
            int vItemCount = SendMessage(hDesk, LVM_GETITEMCOUNT, 0, 0);
            //this.label1.Text = vItemCount.ToString();
           
            uint vProcessId;
            GetWindowThreadProcessId(hDesk, out vProcessId);
 
            IntPtr vProcess = OpenProcess(PROCESS_VM_OPERATION | PROCESS_VM_READ |
                PROCESS_VM_WRITE, false, vProcessId);
            IntPtr vPointer = VirtualAllocEx(vProcess, IntPtr.Zero, 4096,
                MEM_RESERVE | MEM_COMMIT, PAGE_READWRITE);
            try
            {
                for (int j = 0; j < vItemCount; j++)
                {
                    byte[] vBuffer = new byte[256];
                    LVITEM[] vItem = new LVITEM[1];
                    vItem[0].mask = LVIF_TEXT;
                    vItem[0].iItem = j;
                    vItem[0].iSubItem = 0;
                    vItem[0].cchTextMax = vBuffer.Length;

                    vItem[0].pszText = (IntPtr)((int)vPointer + Marshal.SizeOf(typeof(LVITEM)));
                    uint vNumberOfBytesRead = 0;
 
                    WriteProcessMemory(vProcess, vPointer,
                        Marshal.UnsafeAddrOfPinnedArrayElement(vItem, 0),
                        Marshal.SizeOf(typeof(LVITEM)), ref vNumberOfBytesRead);
                    SendMessage(hDesk, LVM_GETITEMW, j, vPointer.ToInt32());
                    ReadProcessMemory(vProcess, (IntPtr)((int)vPointer + Marshal.SizeOf(typeof(LVITEM))),
                        Marshal.UnsafeAddrOfPinnedArrayElement(vBuffer, 0), vBuffer.Length, ref vNumberOfBytesRead);
                    
                    string vText = Encoding.Unicode.GetString(vBuffer);
                    string IconName = vText;
                    //Get icon location
                    SendMessage(hDesk, LVM_GETITEMPOSITION, j, vPointer.ToInt32());
                    Point[] vPoint = new Point[1];
                    ReadProcessMemory(vProcess, vPointer,
                        Marshal.UnsafeAddrOfPinnedArrayElement(vPoint, 0),
                        Marshal.SizeOf(typeof(Point)), ref vNumberOfBytesRead);
                    string IconLocation = vPoint[0].ToString();

                    // Trim off pesky null chars.  Don't use Trim() or some will be missed.
                    if (IconName.Contains("\0"))
                        IconName = IconName.Substring(0, IconName.IndexOf('\0'));

                    locs.Add(IconName, vPoint[0]);
                }
            }
            finally
            {
                VirtualFreeEx(vProcess, vPointer, 0, MEM_RELEASE);
                CloseHandle(vProcess);
            }
 
            return locs;
        }

        static internal void SnapItemToGrid(ListViewItem lit, Point newLoc, Rectangle bounds)
        {
            SnapItemToGrid(lit, newLoc, bounds, 0);
        }

        /// <summary>
        /// Set an item position
        /// </summary>
        /// <param name="lit">Item to set Position of.</param>
        /// <param name="newX">Approximate X location.</param>
        /// <param name="newY">Approximate Y location.</param>
        static private void SnapItemToGrid(ListViewItem lit, Point newLoc, Rectangle bounds, int recurDepth)
        {
            // Don't beat the dead horse.
            if (recurDepth > 20)
                return;

            Rectangle scrBounds = Screen.FromPoint(newLoc).WorkingArea;
            int gridX = 75; 
            int gridY = 100; // Grid for 48x48 icons
            int offsetX = scrBounds.X;
            int offsetY = scrBounds.Y;
            int x = Math.Max(0, newLoc.X - offsetX);
            int y = Math.Max(0, newLoc.Y - offsetY);
            Point adjLoc = new Point(
                x - (x % gridX) + offsetX + 14,
                y - (y % gridY) + offsetY + 2);

            // Are we about to jump on top of another item?
            while (lit.ListView.GetItemAt(adjLoc.X, adjLoc.Y) != null)
                adjLoc.Y += gridY;

            lit.Position = adjLoc;

            // Are we offscreen?
            if (!bounds.Contains(lit.Position))
            {
                // Off bottom.
                if (lit.Position.Y >= bounds.Bottom)
                {
                    adjLoc.X += gridX;
                    adjLoc.Y = gridY;
                } // Off top.
                else if (lit.Position.Y <= bounds.Top)
                {
                    adjLoc.Y = gridY;
                } // Off left.
                else if (lit.Position.X <= bounds.Left)
                {
                    adjLoc.X += gridX;
                } // Off right.
                else if (lit.Position.X >= bounds.Right)
                {
                    adjLoc.X = gridX;
                }

                // Recurse and try again.
                SnapItemToGrid(lit, adjLoc, bounds, recurDepth + 1);
            }
        }
    }
}