using System;
using System.Collections.Generic;
using System.IO;

namespace Ubícame
{
    public class Operación
    {
        public List<string> ObtenerLineas(string path) 
        {
            List<string> personas = new List<string>();
            if (File.Exists(path))
            {
                string[] datos = File.ReadAllLines(path);
                foreach (var item in datos) 
                {
                    personas.Add(item);
                }
            }
            else
            {
                Console.WriteLine("El archivo no existe");
                return null;
            }

            return personas;
        }
        public List<Persona> ObtenerPersona()
        {
            Persona p = new Persona();
            var lineas = ObtenerLineas("Datos.txt");
            List<Persona> razita = new List<Persona>();
            foreach (var item in lineas)
            {
                string[] info = item.Split(',');
                razita.Add(new Persona { ID = int.Parse(info[0]), Nombre = info[1], Profesion = info[2], Edad = int.Parse(info[3]) });
            }
            return razita;
        }
        public void DesplegarPersona() 
        {
            bool repeat = true;
            while (repeat == true) 
            {
                try
                {
                    Console.WriteLine("Ingrese el ID de la persona: ");
                    int busqueda = int.Parse(Console.ReadLine());
                    var gente = ObtenerPersona();
                    Persona p = new Persona();
                    foreach (var item in gente)
                    {
                        if (busqueda == item.ID)
                        {
                            p = item;
                        }
                    }
                    Console.WriteLine("Nombre:    {0}\nProfesion: {1}\nEdad:      {2}", p.Nombre, p.Profesion, p.Edad);
                    Console.WriteLine("Si quieres capturar otra persona, presiona 1, de lo contrario presiona 2");
                    int option = int.Parse(Console.ReadLine());
                    if (option != 1)
                    {
                        Console.WriteLine("Presione cualquier tecla para salir");
                        repeat = false;
                        Console.ReadKey();
                    }
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Busqueda no disponible, detalles aqui: {0}\nPresiona cualquier tecla para Continuar", ex.Message);
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}