using System;
using System.Collections.Generic;
using System.Text;
using LogiTrack.Paquetes;

namespace LogiTrack.Vehiculos
{
    public class Camion : Vehiculo
    {
        public Camion (string placa) :base(placa, 5000)
        {
            this.placa = placa;
            
        }

        public override bool puedeCargar(Paquete paquete)
        {
            if (pesoCargado() + paquete.pesoKg <= capacidadMaximaKg)
            return true;
            else return false;
        }
    

    public override void MostrarInfo()
        {
            Console.WriteLine("~Camion~");
            base.MostrarInfo();
        }
     }
}
