using System;
using System.Collections.Generic;
using System.Text;
using LogiTrack.Enums;
using LogiTrack.Interfaces;

namespace LogiTrack.Paquetes
{
    public class PaqueteFragil: Paquete, IAsegurable
    {
        private double valorDeclarado;

        public PaqueteFragil( string codigo, string remitente, string destinatario, double pesoKg, EstadoEnvio estado, double valorDeclarado) : base( codigo, remitente, destinatario, pesoKg, estado) 
        { 
        }
    
        public override double CalcularCosto() 
        {
           return (pesoKg * 2.5) * 1.8;
        }
    
        public double CalcularSeguro()
        {
            return valorDeclarado * 0.02;
        }
    
        public string ObtenerPoliza() 
        {
            return "POL-FRAGIL-" + codigo;
        }

        public override void MostrarInfo()
        {
            Console.WriteLine("~Paquete Standard~");
            base.MostrarInfo();
        }
    
    }
}
