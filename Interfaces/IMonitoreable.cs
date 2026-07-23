using System;
using System.Collections.Generic;
using System.Text;
using LogiTrack.Enums;

namespace LogiTrack.Interfaces
{
    public interface IMonitoreable
    {
        public void actualizarEstado(EstadoEnvio nuevoEstado);
        public string obtenerResumenEstado();

    }
}
