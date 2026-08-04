using System;
using System.Collections.Generic;
using System.Text;
using LogiTrack.Enums;
using LogiTrack.Interfaces;

namespace LogiTrack.Paquetes
{
    public class PaqueteRefrigerado : Paquete, IAsegurable
    {
        private double temperatuRequerida;
        private double valorDeclarado;

         PaqueteRefrigerado(string codigo, string remitente, string destinatario, double pesoKg, EstadoEnvio estado, double temperaturaRequerida, double valorDeclarado) : base(codigo, remitente, destinatario, pesoKg, estado) 
        {
        }

        public override double CalcularCosto()
        {
            return (pesoKg * 2.5) * 2.5;
        }

        public double CalcularSeguro()
        {
            return valorDeclarado * 0.035;
        }

        public string ObtenerPoliza()
        {
            return "POL-FRIO" + codigo;
        }

        public override void MostrarInfo()
        {
            Console.WriteLine(" Paquete Refrigerado");
            base.MostrarInfo();
        }




    }
}
