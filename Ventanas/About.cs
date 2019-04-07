﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClaryLegales_Ventas.Ventanas
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        /*******************************************
    *                                          *
    *           Movimiento del Form            *   
    *^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^*                 
    *******************************************/
        #region Movimiento del form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        #endregion
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_Leave(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
        }
    }
}
