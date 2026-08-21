using System;
using System.Collections.Generic;
using System.Text;
using LogiTrack.Paquetes;

namespace LogiTrack.Vehiculos
{
    public abstract class Vehiculo
    {
        public string placa { get; protected set; }
        public double capacidadMaximaKg { get; protected set;  }
        protected List<Paquete> paquetesCargados { get; set; }

        public Vehiculo(string placa, double capacidadMaximaKg)
        {
            new List<Paquete>();
            this.placa = placa;
            this.capacidadMaximaKg = capacidadMaximaKg;

            paquetesCargados = new List<Paquete>();
        }

        public abstract bool puedeCargar(Paquete paquete);

        public  bool cargarPaquete(Paquete paquete)
        {
            if (puedeCargar(paquete) == false) {
                return false;
            } else
            {
                Console.WriteLine("Paquete agregado con exito...");
                paquetesCargados.Add(paquete);
                return true;
            }
        }

        public double pesoCargado() 
        {
            double total = 0;

            foreach(Paquete p in paquetesCargados){
                total += p.pesoKg;
            }
            return total;
        }

        public virtual void MostrarInfo()
        {
            Console.WriteLine($"La placa del vehiculo es {placa}"); 
            Console.WriteLine($"La capacidad maxima es {capacidadMaximaKg} KG");
            Console.WriteLine($"El peso que lleva actualmente es de {pesoCargado()} KG");
        }

    }
}
