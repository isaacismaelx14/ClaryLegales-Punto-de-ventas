using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ClaryLegales_Ventas.Ejecutar
{
    public class AbrirWebAyuda
    {
        Process process = new Process();
        private void Iniciar()
        {
            process.Start();
        }
        public void E001()
        {
            process.StartInfo.FileName = @"C:\Users\isaac\source\repos\ClaryLegales Ventas\ClaryLegales Ventas\Soluciones\solucion\error-e001.html";
            Iniciar();
        }

        public void E002()
        {
            process.StartInfo.FileName = @"C:\Users\isaac\source\repos\ClaryLegales Ventas\ClaryLegales Ventas\Soluciones\solucion\error-e002.html";
            Iniciar();
        }

        public void Eror_Page()
        {
            process.StartInfo.FileName = @"C:\Users\isaac\source\repos\ClaryLegales Ventas\ClaryLegales Ventas\Soluciones\servicios.html";
            Iniciar();
        }

        public void Web()
        {
            process.StartInfo.FileName = @"C:\Users\isaac\source\repos\ClaryLegales Ventas\ClaryLegales Ventas\Soluciones\index.html";
            Iniciar();
        }
    }
}
