using System;
using System.Collections.Generic;
using System.Text;
using LogiTrack.Paquetes;

namespace LogiTrack.Vehiculos
{
    public class Furgoneta : Vehiculo
    {
        public Furgoneta (string placa) : base(placa, 500)
        {
            this.placa = placa;
            
        }

        public override bool puedeCargar(Paquete paquete)
        {
            if (paquete is PaqueteRefrigerado && pesoCargado() + paquete.pesoKg < capacidadMaximaKg)
                return false;
            else return true;
        }

        public override void MostrarInfo()
        {
            Console.WriteLine("~Furgoneta~");
            base.MostrarInfo();
        }
    }
}
