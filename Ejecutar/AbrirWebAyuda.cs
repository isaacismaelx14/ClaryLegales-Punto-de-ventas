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
        public void E001()
        {
            Process process = new Process();
            process.StartInfo.FileName = @"C:\Users\isaac\source\repos\ClaryLegales Ventas\ClaryLegales Ventas\Soluciones\solucion\error-e001.html";
            process.Start();
        }

        public void E002()
        {
            Process process = new Process();
            process.StartInfo.FileName = @"C:\Users\isaac\source\repos\ClaryLegales Ventas\ClaryLegales Ventas\Soluciones\solucion\error-e002.html";
            process.Start();
        }
    }
}
