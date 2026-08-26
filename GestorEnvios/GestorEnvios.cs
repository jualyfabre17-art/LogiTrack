using System;
using System.Collections.Generic;
using System.Text;
using LogiTrack.Envios;
using LogiTrack.Paquetes;
using LogiTrack.Conductors;

namespace LogiTrack.GestorEnvios
{
    public class GestorEnvios
    {
        private List<Envio> envios;
        private int ContadorCodigo = 1;
        public GestorEnvios() 
        {
           envios = new List<Envio>();
        }

        public Envio RegistrarEnvio (Paquete paquete, Conductor conductor, string destino) 
        {
            string CodigoGenerado = $"ENV-{ContadorCodigo++:D4}";
            Envio Env1 = new Envio(CodigoGenerado, paquete, conductor, destino);
            envios.Add(Env1);
            return Env1;
        }
        
    }
}
