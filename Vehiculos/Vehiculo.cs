using System;
using System.Collections.Generic;
using System.Text;

namespace LogiTrack.Vehiculos
{
    abstract class Vehiculo
    {
        public string placa { get; protected set; }
        public double capacidadMaximaKg { get; protected set;  }
    }
}
