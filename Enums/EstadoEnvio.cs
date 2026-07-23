using System;
using System.Collections.Generic;
using System.Text;

namespace LogiTrack.Enums
{
    public class EstadoEnvio
    {
        enum estadoEnvio 
        { 
         enEspera = 1,
         enTransito = 2,
         entregado = 3,
         devuelto = 4,
        }

    }
}
