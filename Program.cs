using LogiTrack.GestorConductoress;
using LogiTrack.GestorEnvioss;
using LogiTrack.Paquetes;
using LogiTrack.Conductors;
using LogiTrack.Vehiculos;

namespace LogiTrack { 
    class Program {
        static GestorEnvios gestorEnvios = new GestorEnvios();
        static GestorConductores gestorConductores = new GestorConductores();
        static void Main (){
            Camion veh1 = new Camion("C3823090");
            Furgoneta veh2 = new Furgoneta("F0943549");
            Motocicleta veh3 = new Motocicleta("M3029389");

            Conductor cond1 = new Conductor("Francisco","L2399397", veh1);
            Conductor cond2 = new Conductor("Hernan", "L5738849", veh2);
            Conductor cond3 = new Conductor("Manuel", "L3845751", veh3);

            gestorConductores.Agregar(cond1);
            gestorConductores.Agregar(cond2);
            gestorConductores.Agregar(cond3);
        }
    }
}