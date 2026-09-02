using System;
using System.Collections.Generic;
using System.Text;
using LogiTrack.Paquetes;
using LogiTrack.Conductors;
using LogiTrack.Interfaces;

namespace LogiTrack.Envios
{
    public class Envio
    {
        public string CodigoEnvio { get; private set; }
        public Paquete Paquete { get; private set; }
        public Conductor Conductor { get; private set; }
        public string DireccionDestino { get; private set; }
        public DateTime FechaRegistro { get; private set; }

        public Envio(string CodigoEnvio, Paquete Paquete, Conductor Conductor, string DireccionDestino)
        {
            this.CodigoEnvio = CodigoEnvio;
            this.Paquete = Paquete;
            this.Conductor = Conductor;
            this.DireccionDestino = DireccionDestino;
            this.FechaRegistro = DateTime.Now;
        }

        public double CalcularCostoTotal()
        {
            double Costo = Paquete.CalcularCosto();

            if(Paquete is IAsegurable asegurable)
                return Costo = asegurable.CalcularSeguro() + Paquete.CalcularCosto();
            return Costo;
        
        }

        public void MostrarResumen()
        {
            Console.WriteLine($"Codigo de envio -> {CodigoEnvio}");
            Console.WriteLine($"Fecha de registro -> {FechaRegistro}");
            Console.WriteLine($"Direccion de destino -> {DireccionDestino}");
            Console.WriteLine($"Paquete -> {Paquete.MostrarInfo}");
            Console.WriteLine($"Nombre del conductor {Conductor}");
            Console.WriteLine($"Costo total{CalcularCostoTotal}");
        }

    }
}
