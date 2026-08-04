using System;
using System.Collections.Generic;
using System.Text;
using LogiTrack.Enums;
using LogiTrack.Interfaces;

namespace LogiTrack.Paquetes
{
     public abstract class Paquete : IMonitoreable
    {
        public string codigo;
        public string remitente;
        public string destinatario;
        public double pesoKg;
        protected EstadoEnvio estado;
        
        public Paquete(string codigo, string remitente, string destinatario, double pesoKg,EstadoEnvio estado){
            this.codigo = codigo;
            this.remitente = remitente;
            this.destinatario = destinatario;
            this.pesoKg = pesoKg;
            this.estado = EstadoEnvio.enEspera;
        }

        public abstract double CalcularCosto();

        public virtual void MostrarInfo()
        {
            
            Console.WriteLine($"Codigo -> {codigo}");
            Console.WriteLine($"Remitente -> {remitente}");
            Console.WriteLine($"Destinatario -> {destinatario}");
            Console.WriteLine($"PosoKg -> {pesoKg}");
            Console.WriteLine($"Estado -> {estado}");
            Console.WriteLine($"Costo -> {CalcularCosto()}");
        }

        public  void actualizarEstado(EstadoEnvio nuevoEstado) 
        {
            Console.WriteLine( $"Estado del envio -> {estado}");
        }
        public string obtenerResumenEstado()
        {
            return $"Codigo: {codigo} - Estado actual: {estado}";
        }

  }  
}
