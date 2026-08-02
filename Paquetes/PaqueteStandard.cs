using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using LogiTrack.Enums;

namespace LogiTrack.Paquetes
{

    public class PaqueteStandard : Paquete
    {
        PaqueteStandard(string codigo, string remitente, string destinatario, double pesoKg, EstadoEnvio estado ) : base(codigo, remitente, destinatario, pesoKg, estado)
        {
            
        }
            public override double CalcularCosto() { return pesoKg * 2.5; }

        public override void MostrarInfo()
        {
            Console.WriteLine("Paquete Standard");
            base.MostrarInfo();
        }


    }
}