using ClaryLegales_Ventas.Conexion;
using ClaryLegales_Ventas.Ejecutar;
using ClaryLegales_Ventas.Ventanas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClaryLegales_Ventas
{
    public partial class CL_Ventas : Form
    {
        bool ConnectionState;
        string error;
        int time = 35;
       
        //cargando
        private void CL_Ventas_Load(object sender, EventArgs e)
        {
            tituloSet("Test");
            verificarCombo();
       
        }

        public CL_Ventas()
        {
            InitializeComponent();
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

        private void Top_Panel_MouseMove(object sender, MouseEventArgs e)
        {
          //  ReleaseCapture();
          //  SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void TextPrincipal_MouseMove(object sender, MouseEventArgs e)
        {
          //  ReleaseCapture();
          //  SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        private void dbStatus()
        {
            Connection conexion = new Connection();
            mostrarError(conexion.ConnectionMysql().State.ToString());
            try
            {
                conexion.ConnectionMysql().Open();
                ConnectionState = true;
            }
            catch (Exception ex)
            {
                time = 1000;
                mostrarError(ex.Message);
                error = ex.Message;
                ConnectionState = false;

            }

        }
        private void tituloSet(string titulo)
        {       
            TextPrincipal.Text = "ClaryLegales " + "("+titulo+")";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Cerrar();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Cerrar()
        {
            if (MessageBox.Show("¿seguro que quiere cerrar el programa?", "el programa se cerrara", MessageBoxButtons.YesNo , MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();

            }
        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cerrar();
        }

        private void Ventas_Selected(object sender, TabControlEventArgs e)
        {
           // tituloSet("Ventas");
        }

        private void tabVentas_Click(object sender, EventArgs e)
        {
            tituloSet("Ventas");
        }

        private void Productos_Click(object sender, EventArgs e)
        {
            tituloSet("Productos");

        }

        private void minimizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
                this.WindowState = FormWindowState.Minimized;
        }

        private void maximizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal) {
            
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabs.SelectedIndex = 0;
        }

        private void acercaDeClarylegalesPuntoDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }


        private void verificarCombo()
        {
            if (checkBox1.Checked == false)
            {
                cl_inventario.Text = "Ilimitado";
                cl_inventario.ForeColor = Color.Red;
                cl_inventario.Enabled = false;
            }
            else
            {
                cl_inventario.Text = "";
                cl_inventario.ForeColor = Color.Black;
                cl_inventario.Enabled = true;
            }

            if(checkBox2.Checked == false)
            {
                textBox5.Text = "No aplica";
                textBox5.ForeColor = Color.Red;
                textBox5.Enabled = false;
            }
            else
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
                textBox5.Enabled = true;
            }
        }
        
        /***************
         * ^^^^^^^^^^^^^^^^^^^^^
         * Fecha y Hora
         * 
         * 03:25
         * 14 de marzo del 2019
         *^^^^^^^^^^^^^^^^^^^^^^
         * *************/

        private void obtenerHoraActual()
        {
            string Hora;
            Hora = DateTime.Now.ToShortTimeString();
            Hora_actual.Text = Hora;
        }

        private void obtenerFechaActual()
        {
            string Fecha;
            Fecha = DateTime.Now.ToShortDateString();
            Fecha_actual.Text = Fecha;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            verificarCombo();
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            verificarCombo();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            obtenerFechaActual();
            obtenerHoraActual();
        }

        private void mostrarError(string Text_Error)
        {
            
            timer2.Enabled = true;
            Error_Label.Text = Text_Error;
         //   ErrorLog errolog = new ErrorLog();
           
            //errolog.Show();
           // errolog.MessageLog(Text_Error, time);

            
        }

        private void errorSolutions()
        {
          
        }


        private void Obtengo()
        {
            dbStatus();
            Connection2 connection2 = new Connection2();
            if(ConnectionState == true)
            {
                try
                {
                    cb_articulo.Text = connection2.CN_3(Convert.ToInt32(cb_Id.Text))[0];
                    cl_precio.Text = connection2.CN_3(Convert.ToInt32(cb_Id.Text))[1];
                    cl_inventario.Text = connection2.CN_3(Convert.ToInt32(cb_Id.Text))[2];
                }
                catch
                {
                    mostrarError("El valor incertado no es valido");
                }

                if (cl_inventario.Text == "#")
                {

                    cb_articulo.Text = null;
                    cl_inventario.Text = "";
                    cl_precio.Text = "";
                    mostrarError("El código no existe");
                }
            }
            else
            {
                mostrarError(error);
                cl_inventario.Text = error;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Obtengo();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            time -= 1;
            panel_info.BackColor = Color.OrangeRed;
            Error_Labels.Visible = false;
            Error_Label.Visible = true;
            if (time <= 0)
            {
                timer2.Enabled = false;
                time = 35;
                panel_info.BackColor = Color.DimGray;
                Error_Labels.Visible = true;
                Error_Label.Visible = false;
                Error_Labels.Text = "ClaryLegales Punto de ventas";
            }
            label28.Text = time.ToString();
        }

        private void Error_Label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Error_Label.Text == "Unable to connect to any of the specified MySQL hosts.")
            {
                AbrirWebAyuda abrirWeb = new AbrirWebAyuda();
                abrirWeb.E001();
            }
        }
    }
}
