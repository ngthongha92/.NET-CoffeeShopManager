using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace COFFEESHOPMANAGEMENT
{
    public partial class mainform : Form
    {
        private bool _dragging = false;
        private Point _offset;
        private Point _start_point = new Point(0, 0);

        public mainform()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Then Add the items to the Listview & also assign the image index to that item...
            myListView.Items.Add("Item 1", 0);
            myListView.Items.Add("Item 2", 1);
            myListView.Items.Add("Item 3", 0);
            myListView.Items.Add("Item 4", 1);
            myListView.Items.Add("Item 5", 0);
            myListView.Items.Add("Item 6", 1);
            myListView.Items.Add("Item 7", 0);
            myListView.Items.Add("Item 8", 1);
            myListView.Items.Add("Item 9", 0);
            myListView.Items.Add("Item 10", 1);
            //In the below code i have created two ListViewGroup with it's name & it's alignment in ListView...
            ListViewGroup myLVGroup1 = new ListViewGroup("First Five Group", HorizontalAlignment.Left);
            ListViewGroup myLVGroup2 = new ListViewGroup("Last Five Group", HorizontalAlignment.Left);
            //after creating the ListViewGroup as you want add that group to the ListView...
            myListView.Groups.AddRange(new ListViewGroup[] { myLVGroup1, myLVGroup2 });
            //In below code first five items will be in the First group..
            myListView.Items[0].Group = myListView.Groups[0];
            myListView.Items[1].Group = myListView.Groups[0];
            myListView.Items[2].Group = myListView.Groups[0];
            myListView.Items[3].Group = myListView.Groups[0];
            myListView.Items[4].Group = myListView.Groups[0];
            //Last Five items will be in the Second Group...
            myListView.Items[5].Group = myListView.Groups[1];
            myListView.Items[6].Group = myListView.Groups[1];
            myListView.Items[7].Group = myListView.Groups[1];
            myListView.Items[8].Group = myListView.Groups[1];
            myListView.Items[9].Group = myListView.Groups[1];
        }
        //begin move form
        private void CaptionBar_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;  // _dragging is your variable flag
            _start_point = new Point(e.X, e.Y);
        }

        private void CaptionBar_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void CaptionBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }
        //control boder
        private void closebox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void maxbox_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void minibox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
