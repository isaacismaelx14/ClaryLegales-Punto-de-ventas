using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ClaryLegales_Ventas.ModelsClass
{
    public class TexboxComp
    {
        /***************
         *^Solo Letras^*
         ***************/
        #region textKeyPress
        public void textKeyPress(KeyPressEventArgs e)
        {
            //Solo permite letra
            if (char.IsLetter(e.KeyChar)) { e.Handled = false; }
            //esta nos permitira tambien borrar (backspace)
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; }
            //nos permite usar la tecla espacio (barra espaciadora)
            else if (char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            else { e.Handled = true; }
        }
        #endregion

        /***************
       *^Solo Numeros^*
       ***************/
        #region numberKeyPress
        public void numberKeyPress(KeyPressEventArgs e)
        {
            //Solo permite datos numericos
            if (char.IsDigit(e.KeyChar)) { e.Handled = false; }
            if (char.IsLetter(e.KeyChar)) { e.Handled = true; }
        }
        #endregion

        public void numberDecimalKeyPress(TextBox textBox, KeyPressEventArgs e)
        {
            //Solo permite datos numericos
            if (char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if ((e.KeyChar == '.') && (!textBox.Text.Contains("."))) { e.Handled = false; }
            else { e.Handled = true; }
        }

        public void onlyNumber(TextBox textBox, KeyPressEventArgs e)
        {
                //Solo permite datos numericos
                if (char.IsDigit(e.KeyChar)) { e.Handled = false; }
                else if (char.IsControl(e.KeyChar)) { e.Handled = false; }
                else if ((e.KeyChar == '.') && (!textBox.Text.Contains("."))) { e.Handled = true; }
                else { e.Handled = true; }
            
        }
    }
}
