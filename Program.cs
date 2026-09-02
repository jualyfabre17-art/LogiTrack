using LogiTrack.Conductors;
using LogiTrack.Enums;
using LogiTrack.GestorConductoress;
using LogiTrack.GestorEnvioss;
using LogiTrack.Paquetes;
using LogiTrack.Vehiculos;

namespace LogiTrack {
    class Program {
        static GestorEnvios gestorEnvios = new GestorEnvios();
        static GestorConductores gestorConductores = new GestorConductores();
        static int contadorPaquete = 1;

        static void Main() { 
            Camion veh1 = new Camion("C3823090");
            Furgoneta veh2 = new Furgoneta("F0943549");
            Motocicleta veh3 = new Motocicleta("M3029389");

            Conductor cond1 = new Conductor("Francisco", "L2399397", veh1);
            Conductor cond2 = new Conductor("Hernan", "L5738849", veh2);
            Conductor cond3 = new Conductor("Manuel", "L3845751", veh3);

            gestorConductores.Agregar(cond1);
            gestorConductores.Agregar(cond2);
            gestorConductores.Agregar(cond3);

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   LogiTrack  ");
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("1.Registrar envio");
                Console.WriteLine("2.Ver todos");
                Console.WriteLine("3.Rastrear por codigo");
                Console.WriteLine("4.Actualizar estado");
                Console.WriteLine("5.Ver polizas");
                Console.WriteLine("6.Ver conductores");
                Console.WriteLine("7.Reporte de ingresos");
                Console.WriteLine("8.Salir");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("    Opcion:");
                Console.ResetColor();
                string op = Console.ReadLine();
                switch (op)
                {
                    case "1":
                        RegistrarEnvio();
                        break;
                    case "2":
                        gestorEnvios.MostrarTodos();
                        break;
                    case "3":
                        RastrearEnvio();
                        break;
                    case "4":
                        ActualizarEstado();
                        break;
                    case "5":
                        gestorEnvios.MostrarPolizasActivas();
                        break;
                    case "6":
                        gestorConductores.MostrarTodos();
                        break;
                    case "7":
                        Console.WriteLine($"\n Ingresos totales: ${gestorEnvios.CalcularIngresoTotal():F2}");
                        break;
                    case "8":
                        Console.WriteLine(" Cerrando LogiTrack."); break;
                    default:
                        Console.WriteLine(" Elige entre 1 y 8.");
                        break;
                }
            }
        }
        private static void RegistrarEnvio()
        {
            Console.WriteLine("Ingrese el Remitente ->"); string remitente = Console.ReadLine();
            Console.WriteLine("Ingrese el Destinatario ->"); string destinatario = Console.ReadLine();
            Console.WriteLine("Ingrese el Destino ->"); string destino = Console.ReadLine();
            Console.WriteLine("Ingrese el peso en KG ->"); double pesoKg;
            double.TryParse(Console.ReadLine(), out pesoKg);

            Console.WriteLine("Tipo de paquete: 1-Estandar  2-Fragil  3-Refrigerado");
            Console.Write("Tipo -> ");
            int tipo; int.TryParse(Console.ReadLine(), out tipo);

            string cod = $"ENV-{contadorPaquete++:D4}";
            Paquete paquete;

            if (tipo == 1)
            {
                paquete = new PaqueteStandard(cod, remitente, destinatario, pesoKg, Enums.EstadoEnvio.enTransito);
            }
            else if (tipo == 2)
            {
                Console.Write("Valor declarado ($) -> ");
                double val; double.TryParse(Console.ReadLine(), out val);
                paquete = new PaqueteFragil(cod, remitente, destinatario, pesoKg, Enums.EstadoEnvio.enEspera, val);
            }
            else if (tipo == 3)
            {
                Console.Write("Temperatura requerida (°C) -> ");
                double temp; double.TryParse(Console.ReadLine(), out temp);
                Console.Write("Valor declarado ($): ");
                double val; double.TryParse(Console.ReadLine(), out val);
                paquete = new PaqueteRefrigerado(cod, remitente, destinatario, pesoKg, Enums.EstadoEnvio.enEspera, temp, val);
            }
            else { Console.WriteLine(" Tipo invalido."); return; }

            var conductores = gestorConductores.ObtenerTodos();
            Console.WriteLine("\nConductores disponibles:");
            for (int i = 0; i < conductores.Count; i++)
                Console.WriteLine($"  {i + 1}. {conductores[i].Nombre} ({conductores[i].Licencia})");

            Console.Write("Elige conductor (numero): ");
            int num; int.TryParse(Console.ReadLine(), out num);

            if (num < 1 || num > conductores.Count)
            {
                Console.WriteLine(" Número de conductor invalido."); return;
            }

            Conductor conductor = conductores[num - 1];

            if (conductor.VehiculoAsignado == null)
            {
                Console.WriteLine(" El conductor no tiene vehiculo asignado."); return;
            }

            if (!conductor.VehiculoAsignado.puedeCargar(paquete))
            {
                Console.WriteLine($" El vehiculo de {conductor.Nombre} no puede transportar ese tipo de paquete o esta al limite de capacidad.");
                return;
            }

            var envio = gestorEnvios.RegistrarEnvio(paquete, conductor, destino);
            Console.WriteLine($"\n Envío registrado: {envio.CodigoEnvio}");
            Console.WriteLine($"   Costo total: ${envio.CalcularCostoTotal():F2}");
        }

        static void RastrearEnvio()
        {
            Console.Write("Codigo de envio (ej. ENV-0001): ");
            var envio = gestorEnvios.BuscarPorCodigo(Console.ReadLine());
            if (envio == null) { Console.WriteLine(" Envio no encontrado."); return; }
            Console.WriteLine(envio.Paquete.obtenerResumenEstado());
            envio.MostrarResumen();
        }

        static void ActualizarEstado()
        {
            Console.Write("Codigo de envio: ");
            string codigo = Console.ReadLine();

            Console.WriteLine("Nuevo estado: 0-EnEspera  1-EnTransito  2-Entregado  3-Devuelto");
            Console.Write("Estado: ");
            int e; int.TryParse(Console.ReadLine(), out e);

            if (e < 0 || e > 3) { Console.WriteLine(" Estado invalido."); return; }

            gestorEnvios.ActualizarEstado(codigo, (EstadoEnvio)e);
            Console.WriteLine(" Estado actualizado correctamente.");
        }
    
    }
}


