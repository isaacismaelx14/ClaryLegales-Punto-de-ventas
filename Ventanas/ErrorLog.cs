using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClaryLegales_Ventas.Ventanas
{
    public partial class ErrorLog : Form
    {
        int time;
        public ErrorLog()
        {
            InitializeComponent();
            MessageLog("#", 10);
        }

        private void ErrorLog_Load(object sender, EventArgs e)
        {
            MessageLog("#", 10);
        }

        public void MessageLog(string MenssageError, int getTime)
        {
            timer1.Enabled = true ;
            label2.Text = MenssageError;
            time = getTime;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time -= 1;
            if(time <= 0)
            {
                this.Hide();
                timer1.Enabled = false;
            }
        }
    }
}
