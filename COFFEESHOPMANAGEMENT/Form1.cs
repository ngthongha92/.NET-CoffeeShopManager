﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace COFFEESHOPMANAGEMENT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void manualUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            banDAO banDAO = new banDAO();
            DataTable a= banDAO.getallban();
            DataRow r = a.Rows[0];
            MessageBox.Show(r["maban"].ToString() + "-" + r["tenban"].ToString() + "-" + r["khuvuc"].ToString());
        }
    }
}
