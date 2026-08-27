using System;
using System.Collections.Generic;
using System.Text;
using LogiTrack.Envios;
using LogiTrack.Paquetes;
using LogiTrack.Conductors;
using LogiTrack.Enums;

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

        public Envio BuscarPorCodigo(string codigo)
        {
            
            foreach(var envio in envios) 
            { 
                if(envio.CodigoEnvio.ToLower() == codigo.ToLower())
                {
                    return envio;
                } 
            }
            return null;
        }

        public void ActualizarEstado(string codigo, EstadoEnvio nuevoEstado)
        {
            var devuelta = BuscarPorCodigo(codigo);
            if(devuelta != null)
            {
                devuelta.Paquete.actualizarEstado(nuevoEstado);
            }
        }

        public void MostrarTodos()
        {
            if(envios == null)
            {
                Console.WriteLine("La lista esta completamente vacia");
            }
            else
            {
                foreach( var envio in envios)
                {
                    envio.MostrarResumen();
                }
            }
        }

        public double CalcularIngresoTotal()
        {
            double total = 0;
            foreach(var envis in envios)
            {
                total += envis.CalcularCostoTotal();
                
            }
            return total;
        }
        
    }
}
