using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ShellDll;
using Tao.OpenGl;
using Mawenzy.Plugins;
using System.Reflection;
using System.Diagnostics;
using Mawenzy.Properties;
using Mawenzy.UI;

namespace Mawenzy
{
    #region TreeView

    /// <summary>
    /// This is the TreeView used in the Browser control
    /// </summary>
    internal class BrowserTreeView : TreeView
    {
        private BrowserTreeSorter sorter;

        public BrowserTreeView()
        {
            HandleCreated += new EventHandler(BrowserTreeView_HandleCreated);

            sorter = new BrowserTreeSorter();
        }

        #region Override

        #endregion

        #region Events

        /// <summary>
        /// Once the handle is created we can assign the image list to the TreeView
        /// </summary>
        void BrowserTreeView_HandleCreated(object sender, EventArgs e)
        {
            ShellImageList.SetSmallImageList(this);
        }

        #endregion

        #region Public

        public bool GetTreeNode(ShellItem shellItem, out TreeNode treeNode)
        {
            ArrayList pathList = new ArrayList();
            
            while (shellItem.ParentItem != null)
            {
                pathList.Add(shellItem);
                shellItem = shellItem.ParentItem;
            }
            pathList.Add(shellItem);

            pathList.Reverse();

            treeNode = Nodes[0];
            for (int i = 1; i < pathList.Count; i++)
            {
                bool found = false;
                foreach (TreeNode node in treeNode.Nodes)
                {
                    if (node.Tag != null && node.Tag.Equals(pathList[i]))
                    {
                        treeNode = node;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    treeNode = null;
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// This method will check whether a TreeNode is a parent of another TreeNode
        /// </summary>
        /// <param name="parent">The parent TreeNode</param>
        /// <param name="child">The child TreeNode</param>
        /// <returns>true if the parent is a parent of the child, false otherwise</returns>
        public bool IsParentNode(TreeNode parent, TreeNode child)
        {
            TreeNode current = child;
            while (current.Parent != null)
            {
                if (current.Parent.Equals(parent))
                    return true;

                current = current.Parent;
            }
            return false;
        }

        /// <summary>
        /// This method will check whether a TreeNode is a parent of another TreeNode
        /// </summary>
        /// <param name="parent">The parent TreeNode</param>
        /// <param name="child">The child TreeNode</param>
        /// <param name="path">If the parent is indeed a parent of the child, this will be a path of
        /// TreeNodes from the parent to the child including both parent and child</param>
        /// <returns>true if the parent is a parent of the child, false otherwise</returns>
        public bool IsParentNode(TreeNode parent, TreeNode child, out TreeNode[] path)
        {
            ArrayList pathList = new ArrayList();

            TreeNode current = child;
            while (current.Parent != null)
            {
                pathList.Add(current);
                if (current.Parent.Equals(parent))
                {
                    pathList.Add(parent);
                    pathList.Reverse();
                    path = (TreeNode[])pathList.ToArray(typeof(TreeNode));
                    return true;
                }

                current = current.Parent;
            }

            path = null;
            return false;
        }

        public void SetSorting(bool sorting)
        {
            if (sorting)
                this.TreeViewNodeSorter = sorter;
            else
                this.TreeViewNodeSorter = null;
        }

        #endregion
    }

    /// <summary>
    /// This class is used to sort the TreeNodes in the BrowserTreeView
    /// </summary>
    internal class BrowserTreeSorter : IComparer
    {
        #region IComparer Members

        /// <summary>
        /// This method will compare the ShellItems of the TreeNodes to determine the return value for
        /// comparing the TreeNodes.
        /// </summary>
        public int Compare(object x, object y)
        {
            TreeNode nodeX = x as TreeNode;
            TreeNode nodeY = y as TreeNode;

            if (nodeX.Tag != null && nodeY.Tag != null)
                return ((ShellItem)nodeX.Tag).CompareTo(nodeY.Tag);
            else if (nodeX.Tag != null)
                return 1;
            else if (nodeY.Tag != null)
                return -1;
            else
                return 0;
        }

        #endregion
    }

    #endregion

    #region ListView
    /// <summary>
    /// This is the ListView used in the Browser control
    /// </summary>
    internal class BrowserListView : Mawenzy.BoeroViewShell
    {
        // The arraylist to store the order by which ListViewItems has been selected
        private List<ListViewItem> selectedOrder;

        private bool suspendHeaderContextMenu;

        public BrowserListView() : base()
        {
            //Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.BelowNormal;
            selectedOrder = new List<ListViewItem>();
            AfterInitRC += new PostInit(BrowserListView_AfterInitRC);
            RenderBackground += new DrawBackground(BrowserListView_RenderBackground);
        }

        private void BrowserListView_AfterInitRC()
        {
            ShellImageList.SetSmallImageList(this);
            ShellImageList.SetLargeImageList(this);
            HighlightAlpha = 0x90;
            Options.OptsInst.LoadPlugins();
        }

        private void BrowserListView_RenderBackground(long frame)
        {
            foreach (PluginBase bgPlugin in Options.ActivePlugins.Values)
                bgPlugin.Draw();
        }

        protected override Image GetIconImage(ImageList list, int icon)
        {
            IntPtr hic = ImageList_GetIcon(ShellImageList.LargeImageList, icon, 0x0);

            // hic can be null, GDI can decide to error, etc. ugh...
            try
            {
                Icon ic = Icon.FromHandle(hic);
                return ic.ToBitmap();
            }
            catch (Exception)
            {
                return Mawenzy.Properties.Resources.dn;
            }
        }

        protected override void OnItemSelectionChanged(ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
                selectedOrder.Insert(0, e.Item);
            else
                selectedOrder.Remove(e.Item);

            base.OnItemSelectionChanged(e);

            foreach (PluginBase selectionPlugin in Options.ActivePlugins.Values)
                selectionPlugin.HandleSelectionChanged(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            try
            {
                // Descend order of layers.  Return at topmost layer that handles and returns true.
                // Note: layer may handle and still pass click to lower layers by returning false.
                for (int i = Options.ActivePlugins.Count - 1; i >= 0; --i)
                {
                    if (Options.ActivePlugins.Values[i].HandleMouseClick(e))
                    {
                        dragSelectStatus = null;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrForm.Show(new ApplicationException(
                    Resources.ERR_MouseClick, ex));
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            dragSelectStatus = null;
            base.OnMouseUp(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            
            // Descend order of layers.  Return at topmost layer that handles and returns true.
            // Note: layer may handle and still pass click to lower layers by returning false.
            try
            {
                for (int i = Options.ActivePlugins.Count - 1; i > 0; --i)
                    if (Options.ActivePlugins.Values[i].HandleMouseWheel(e))
                        return;
            }
            catch (Exception ex)
            {
                ErrForm.Show(new ApplicationException(
                    Resources.ERR_MouseWheel, ex));
            }
        }

        [Browsable(false)]
        public List<ListViewItem> SelectedOrder
        {
            get { return selectedOrder; }
        }

        [Browsable(false)]
        public bool SuspendHeaderContextMenu
        {
            get { return suspendHeaderContextMenu; }
            set { suspendHeaderContextMenu = value; }
        }

        public void SetSorting(bool sorting)
        {
            ListViewItemSorter = null;
        }

        public void ClearSelections()
        {
            foreach (PluginBase selChPlugin in Options.ActivePlugins.Values)
                foreach (ListViewItem unselIt in selectedOrder)
                    selChPlugin.HandleSelectionChanged(new ListViewItemSelectionChangedEventArgs(unselIt, unselIt.Index, false));

            selectedOrder.Clear();
        }

        public bool GetListItem(ShellItem shellItem, out ListViewItem listItem)
        {
            listItem = null;

            foreach (ListViewItem item in Items)
            {
                if (shellItem == item.Tag)
                {
                    listItem = item;
                    return true;
                }
            }

            return false;
        }
    }
    #endregion

    #region ComboBox

    /// <summary>
    /// This is the ComboBox used in the navigationbar. It is extended to show the icons that go with the
    /// ShellItems.
    /// </summary>
    internal class BrowserComboBox : ToolStripComboBox
    {
        #region Fields

        // The width of the indent of the ComboItems
        private int indentWidth = 10;

        // The item for the browser's current selected directory
        private BrowserComboItem currentItem;

        // The class to draw the icon in the textbox area of the ComboBox
        private ComboEditWindow editWindow;

        #endregion

        public BrowserComboBox()
        {
            ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            ComboBox.DrawItem += new DrawItemEventHandler(ComboBox_DrawItem);
            ComboBox.HandleCreated += new EventHandler(ComboBox_HandleCreated);

            ComboBox.MouseDown += new MouseEventHandler(ComboBox_MouseDown);
            ComboBox.MouseMove += new MouseEventHandler(ComboBox_MouseMove);
            ComboBox.MouseClick += new MouseEventHandler(ComboBox_MouseClick);

            ComboBox.DropDown += new EventHandler(ComboBox_DropDown);
        }

        #region Events

        /// <summary>
        /// This method will change the currentItem field once a new item is selected
        /// </summary>
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);

            if (ComboBox.SelectedIndex > -1)
                currentItem = ComboBox.SelectedItem as BrowserComboItem;         
        }

        /// <summary>
        /// Once the handle has been created a new instance of ComboEditWindow is made to make sure
        /// the icons are drawn in the TextBox part of the ComboBox
        /// </summary>
        void ComboBox_HandleCreated(object sender, EventArgs e)
        {
            editWindow = new ComboEditWindow(this);
        }

        /// <summary>
        /// This method will draw the items of the DropDownList. It will draw the Icon and the text and
        /// with the indent that goes with the item
        /// </summary>
        void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
                return;
            else
            {
                BrowserComboItem item = (BrowserComboItem)Items[e.Index];

                e.DrawBackground();
                e.DrawFocusRectangle();

                int indentOffset = indentWidth * item.Indent;

                int imageYOffset = (e.Bounds.Height - item.Image.Height) / 2;
                Point imagePoint = new Point(
                    e.Bounds.Left + indentOffset + 2, 
                    e.Bounds.Top + imageYOffset);

                Size textSize = e.Graphics.MeasureString(item.Text, Font).ToSize();
                int textYOffset = (e.Bounds.Height - textSize.Height) / 2;
                Point textPoint = new Point(
                    e.Bounds.Left + item.Image.Width + indentOffset + 2, 
                    e.Bounds.Top + textYOffset);

                e.Graphics.DrawIcon(item.Image, imagePoint.X, imagePoint.Y);
                e.Graphics.DrawString(item.Text, e.Font, new SolidBrush(e.ForeColor), textPoint);
            }
        }

        /// <summary>
        /// If the mouse is moved over the icon of the ComboBox this method will change the cursor
        /// into an hand to indicate that the icon can be clicked
        /// </summary>
        void ComboBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (editWindow.ImageRect.Contains(e.Location))
            {
                Cursor.Current = Cursors.Hand;
            }
            else if (Cursor.Current == Cursors.Hand)
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// If the mouse is moved over the icon of the ComboBox this method will change the cursor
        /// into an hand to indicate that the icon can be clicked
        /// </summary>
        void ComboBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (editWindow.ImageRect.Contains(e.Location))
                Cursor.Current = Cursors.Hand;
        }  

        /// <summary>
        /// If the icon of the ComboBox is clicked this method will select all text in the ComboBox
        /// </summary>
        void ComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (editWindow.ImageRect.Contains(e.Location))
                SelectAll();
        }

        /// <summary>
        /// This method will make sure that when the ComboBox is dropped down, the width of the DropDownList
        /// will be sufficient to fit all items
        /// </summary>
        void ComboBox_DropDown(object sender, EventArgs e)
        {
            int width = 0;
            Graphics gfx = ComboBox.CreateGraphics();
            foreach (BrowserComboItem item in Items)
            {
                int itemWidth =
                    gfx.MeasureString(item.Text, Font).ToSize().Width +
                    item.Image.Width +
                    indentWidth * item.Indent +
                    (Items.Count > MaxDropDownItems ? SystemInformation.VerticalScrollBarWidth : 0);

                if (itemWidth > width)
                    width = itemWidth;
            }

            if (width > this.Width)
                ComboBox.DropDownWidth = width;
            else
                ComboBox.DropDownWidth = this.Width;
        } 

        #endregion

        #region Public

        [Browsable(false)]
        public BrowserComboItem CurrentItem 
        { 
            get { return currentItem; }
            set { currentItem = value; }
        }

        #endregion

        #region ComboEditWindow

        class ComboEditWindow : NativeWindow
        {
            private const int LEFTMARGIN = 0x1;
            private BrowserComboBox owner;
            private Rectangle imageRect;
            private int margin = 0;

            /// <summary>
            /// The native window's original handle is released 
            /// and the handle of the TextBox is assigned to it.
            /// </summary>
            public ComboEditWindow(BrowserComboBox owner)
            {
                this.owner = owner;

                ShellAPI.COMBOBOXINFO info = new ShellAPI.COMBOBOXINFO();
                info.cbSize = Marshal.SizeOf(typeof(ShellAPI.COMBOBOXINFO));
                ShellAPI.GetComboBoxInfo(owner.ComboBox.Handle, ref info);

                if (!this.Handle.Equals(IntPtr.Zero))
                {
                    this.ReleaseHandle();
                }
                this.AssignHandle(info.hwndEdit);
            }

            public Rectangle ImageRect { get { return imageRect; } }

            /// <summary>
            /// Set the margin of the TextBox to make room for the icon
            /// </summary>
            /// <param name="margin">The margin to set</param>
            private void SetMargin(int margin)
            {
                if (this.margin != margin)
                {
                    this.margin = margin;

                    if (owner == null)
                        return;

                    ShellAPI.SendMessage(
                        this.Handle, ShellAPI.WM.SETMARGINS, LEFTMARGIN,
                        new IntPtr(margin));
                }
            }

            /// <summary>
            /// Whenever the textbox is repainted, this method will draw the icon.
            /// </summary>
            private void DrawImage()
            {
                if (owner.CurrentItem != null)
                {
                    SetMargin(owner.CurrentItem.Image.Width + 3);

                    Icon icon = owner.CurrentItem.Image;
                    Bitmap image = new Bitmap(icon.Width, icon.Height);
                    
                    Graphics imageGfx = Graphics.FromImage(image);
                    imageRect = new Rectangle(new Point(0, 0), image.Size);
                    imageGfx.FillRectangle(Brushes.White, imageRect);
                    imageGfx.DrawIcon(icon, 0, 0);
                    imageGfx.Flush();

                    // Gets a GDI drawing surface from the textbox.
                    Graphics gfx = Graphics.FromHwnd(this.Handle);

                    if (owner.RightToLeft == RightToLeft.Yes)
                    {
                        gfx.DrawImage(image, (int)gfx.VisibleClipBounds.Width - icon.Width, 0);
                    }
                    else if (owner.RightToLeft == RightToLeft.No)
                    {
                        gfx.DrawImage(image, 0, 0);
                    }

                    gfx.Flush();
                    gfx.Dispose();
                }
            }

            // Override the WndProc method so that we can redraw the TextBox when the textbox is repainted.
            protected override void WndProc(ref Message m)
            {
                switch (m.Msg)
                {
                    case (int)ShellAPI.WM.PAINT:
                        base.WndProc(ref m);
                        DrawImage();
                        break;
                    case (int)ShellAPI.WM.LBUTTONDOWN:
                        base.WndProc(ref m);
                        DrawImage();
                        break;
                    case (int)ShellAPI.WM.KEYDOWN:
                        base.WndProc(ref m);
                        DrawImage();
                        break;
                    case (int)ShellAPI.WM.KEYUP:
                        base.WndProc(ref m);
                        DrawImage();
                        break;
                    case (int)ShellAPI.WM.CHAR:
                        base.WndProc(ref m);
                        DrawImage();
                        break;
                    case (int)ShellAPI.WM.GETTEXTLENGTH:
                        base.WndProc(ref m);
                        DrawImage();
                        break;
                    case (int)ShellAPI.WM.GETTEXT:
                        base.WndProc(ref m);
                        DrawImage();
                        break;
                    default:
                        base.WndProc(ref m);
                        break;
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// This class represents the items that can be used for the BrowserComboBox
    /// </summary>
    internal class BrowserComboItem
    {
        // The ShellItem that goes with the ComboItem
        private ShellItem shellItem;

        // The indent that goes with the ComboItem
        private int indent;

        // The Icon that has to be drawn for this ComboItem
        private Icon image;

        public BrowserComboItem(ShellItem shellItem, int indent)
        {
            this.shellItem = shellItem;
            this.indent = indent;
            this.image = ShellImageList.GetIcon(shellItem.ImageIndex, true);
        }

        #region Properties

        public ShellItem ShellItem { get { return shellItem; } }
        public int Indent { get { return indent; } }
        public Icon Image { get { return image; } }
        public string Text { get { return ShellItem.Text; } }

        #endregion

        public override string ToString()
        {
            return ShellItem.Path;
        }
    }

    #endregion
}
