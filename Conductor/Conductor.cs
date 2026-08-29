using System;
using System.Collections.Generic;
using System.Text;
using LogiTrack.Vehiculos;

namespace LogiTrack.Conductors
{
    public class Conductor
    {
        public string Nombre { get; private set; }
        public string Licencia { get; private set; }
        public Vehiculo? VehiculoAsignado { get; private set; } = null;

        public Conductor(string Nombre, string Licencia, Vehiculo VehiculoAsignado)
        {
            this.Nombre = Nombre;
            this.Licencia = Licencia;
            this.VehiculoAsignado = VehiculoAsignado;
        }

        public void AsignarVehiculo(Vehiculo? vehiculo) 
        {
            VehiculoAsignado = vehiculo;
        }

        public  void MostrarInfo()
        {
            Console.WriteLine($"El nombre del conductor es {Nombre} y su licencia es {Licencia}");
            if (VehiculoAsignado != null)
                VehiculoAsignado.MostrarInfo();
            else
                Console.WriteLine("Sin vehiculo asignado");
        }
    }
}
