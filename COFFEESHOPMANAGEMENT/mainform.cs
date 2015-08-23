using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        private ListViewGroup myLVGroup1;
        private string a, b = null;
        public int butt_update = -2;

        BUSban bban = new BUSban();

        public mainform()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            showlistview();
            showthucdon();
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

        private void myListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //===========================================================================================
        public void showlistview() {

            DataTable dt = new DataTable();
            DataTable dta = new DataTable();
            myListView.Clear();
            dta = bban.allkv();
            for (int i = 0; i < dta.Rows.Count; i++) {
                myListView.Groups.Add(new ListViewGroup(dta.Rows[i][1].ToString().Trim(), HorizontalAlignment.Left));
                dt = bban.getallfilterkv(dta.Rows[i][0].ToString().Trim());
                for (int j = 0; j < dt.Rows.Count; j++){
                    ListViewItem item = new ListViewItem { Text = dt.Rows[j][1].ToString().Trim() };
                    ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem(item, dt.Rows[j][0].ToString());
                    item.SubItems.Add(subitem);
                    if (dt.Rows[j][2].ToString() == "0")item.ImageIndex = 1;
                    if (dt.Rows[j][2].ToString() == "-1") item.ImageIndex = 2;
                    if (dt.Rows[j][2].ToString() == "1") item.ImageIndex = 0;
                    item.Group = myListView.Groups[i];
                    myListView.Items.Add(item);
                }
            }
        }

        public void showthucdon() {
            DataTable dt = new DataTable();
            thucdonBUS td = new thucdonBUS();
            dt = td.getallthucdon();
            dataGridView1.DataSource = dt;
        }
        public void showhoadon(string maban, string tinhtrang)
        {
            hoadonBUS hd = new hoadonBUS();
            DataTable dt = new DataTable();
            dt = hd.getallhoadon(maban, tinhtrang);
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = dt;
        }
        private void myListView_Click(object sender, EventArgs e)
        {

            a = myListView.SelectedItems[0].Text ;
            b = myListView.SelectedItems[0].SubItems[1].Text;
            
            if(a.Length > 13){
                labelTable.Text = a.ToString().Substring(0, 12) + "...";
            }
            else labelTable.Text = a.ToString();
            if (bban.check_ban(b.ToString())==0)
            {
                dataGridView2.DataSource = null;
                buttonUpdate.Text = "phục vụ";
                buttonUpdate.Enabled = true;
                buttonCancel.Enabled = false;
                buttonPay.Enabled = false;
                buttonPrintBill.Enabled = false;
                buttonChangerTable.Enabled = false;
                labeltbhoadon.Visible = true;
                labelIDBill.Text = "-----";
                butt_update = 0;
            }
            else if (bban.check_ban(b.ToString()) == 1)
            {
                buttonUpdate.Text = "Đang phục vụ";
                buttonUpdate.Enabled = false;
                buttonCancel.Enabled = true;
                buttonPay.Enabled = true;
                buttonPrintBill.Enabled = true;
                labeltbhoadon.Visible = false;
                butt_update = 1;
                showhoadon(b.ToString(), bban.check_ban(b.ToString()).ToString());
                hoadonBUS hd = new hoadonBUS();
                labelIDBill.Text = hd.getsmahoadon(b.ToString(), "1");             
            }
            else { 
                buttonUpdate.Text = "Được Đặt trước";
                buttonUpdate.Enabled = false;
                buttonCancel.Enabled = true;
                buttonPay.Enabled = true;
                buttonPrintBill.Enabled = true;
                labeltbhoadon.Visible = false;
                butt_update = -1;
            } 
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (butt_update == 0) {
                hoadonBUS hd = new hoadonBUS();
                hd.laphoadon(DateTime.Now.ToString("yyyyMMddThhmmss").Trim(), myListView.SelectedItems[0].SubItems[1].Text);
                labelIDBill.Text = DateTime.Now.ToString("yyyyMMddThhmmss").Trim();
                labeltbhoadon.Visible = false;
                buttonUpdate.Text = b.ToString();
                bban.capnhattinhtrangban("1", b.ToString());

                showhoadon(b.ToString(), bban.check_ban(b.ToString()).ToString());
                showlistview();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null){
                int vt = dataGridView1.CurrentCell.RowIndex;
                try{
                    textService.Text = " " + dataGridView1.Rows[vt].Cells[1].Value.ToString().Trim();
                    textPrice.Text = dataGridView1.Rows[vt].Cells[2].Value.ToString().Trim() + " ";
                    textDV.Text = dataGridView1.Rows[vt].Cells[4].Value.ToString().Trim();
                }
                catch (Exception ex){
                }
            }
        }
        //===========================================================================================
    }
}
