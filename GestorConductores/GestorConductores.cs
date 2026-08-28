using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using LogiTrack.Conductors;

namespace LogiTrack.GestorConductores
{
    public class GestorConductores
    {
        private  List<Conductor> conductores;

        public GestorConductores()
        {
            conductores = new List<Conductor>();
        }

        public void Agregar(Conductor conductor)
        {
            conductores.Add(conductor);
        } 

        public void MostrarTodos()
        {
            if(!conductores.Any())
            {
                Console.WriteLine("No hay conductores enlistados");
            }
            else
            {
                foreach(var conductor in conductores)
                {
                    conductor.MostrarInfo();
                }
            }
        }

        public List<Conductor> ObtenerTodos()
        {
            return conductores;
        }
    }
}
