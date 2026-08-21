using System;
using System.Collections.Generic;
using System.Text;
using LogiTrack.Paquetes;

namespace LogiTrack.Vehiculos
{
    public class Motocicleta : Vehiculo
    {
        public Motocicleta(string placa) : base (placa, 30) 
        {
            this.placa = placa;
            
        }

        public override bool puedeCargar(Paquete paquete)
        {
            if (paquete is PaqueteStandard && pesoCargado() + paquete.pesoKg < capacidadMaximaKg)
                return true;
            else return false;
        }

        public override void MostrarInfo()
        {
            Console.WriteLine("~Motocicleta~");
            base.MostrarInfo();
        }

    }
}
