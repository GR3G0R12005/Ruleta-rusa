using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.IO;
using System.Threading;
using OfficeOpenXml;
using OfficeOpenXml.Packaging.Ionic.Zip;
using NAudio.Wave;


namespace competenciaaaaa
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            int indice_desarrollador = 0, indice_facilitador = 0;
            int seleccion;
            Random random = new Random();
            string nombre_seleccionado = "";
            int indice_aleatorio = 0;
            string titulo_historial = @"








            

                                                                            
                                                                 ██░ ██  ██▓  ██████ ▄▄▄█████▓ ▒█████   ██▀███   ██▓ ▄▄▄       ██▓    
                                                                ▓██░ ██▒▓██▒▒██    ▒ ▓  ██▒ ▓▒▒██▒  ██▒▓██ ▒ ██▒▓██▒▒████▄    ▓██▒    
                                                                ▒██▀▀██░▒██▒░ ▓██▄   ▒ ▓██░ ▒░▒██░  ██▒▓██ ░▄█ ▒▒██▒▒██  ▀█▄  ▒██░    
                                                                ░▓█ ░██ ░██░  ▒   ██▒░ ▓██▓ ░ ▒██   ██░▒██▀▀█▄  ░██░░██▄▄▄▄██ ▒██░    
                                                                ░▓█▒░██▓░██░▒██████▒▒  ▒██▒ ░ ░ ████▓▒░░██▓ ▒██▒░██░ ▓█   ▓██▒░██████▒
                                                                 ▒ ░░▒░▒░▓  ▒ ▒▓▒ ▒ ░  ▒ ░░   ░ ▒░▒░▒░ ░ ▒▓ ░▒▓░░▓   ▒▒   ▓▒█░░ ▒░▓  ░
                                                                 ▒ ░▒░ ░ ▒ ░░ ░▒  ░ ░    ░      ░ ▒ ▒░   ░▒ ░ ▒░ ▒ ░  ▒   ▒▒ ░░ ░ ▒  ░
                                                                 ░  ░░ ░ ▒ ░░  ░  ░    ░      ░ ░ ░ ▒    ░░   ░  ▒ ░  ░   ▒     ░ ░   
                                                                 ░  ░  ░ ░        ░               ░ ░     ░      ░        ░  ░    ░  ░
                                                                                                                                      
                                                                ";

            string desing = @"
                                                            ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
                                                               ";
            string titulo_seleccion = @"









             ██████ ▓█████  ██▓    ▓█████  ▄████▄   ▄████▄   ██▓ ▒█████   ███▄    █  ▄▄▄       ███▄    █ ▓█████▄  ▒█████      ██▒   █▓ ██▓ ▄████▄  ▄▄▄█████▓ ██▓ ███▄ ▄███▓ ▄▄▄        ██████ 
           ▒██    ▒ ▓█   ▀ ▓██▒    ▓█   ▀ ▒██▀ ▀█  ▒██▀ ▀█  ▓██▒▒██▒  ██▒ ██ ▀█   █ ▒████▄     ██ ▀█   █ ▒██▀ ██▌▒██▒  ██▒   ▓██░   █▒▓██▒▒██▀ ▀█  ▓  ██▒ ▓▒▓██▒▓██▒▀█▀ ██▒▒████▄    ▒██    ▒ 
           ░ ▓██▄   ▒███   ▒██░    ▒███   ▒▓█    ▄ ▒▓█    ▄ ▒██▒▒██░  ██▒▓██  ▀█ ██▒▒██  ▀█▄  ▓██  ▀█ ██▒░██   █▌▒██░  ██▒    ▓██  █▒░▒██▒▒▓█    ▄ ▒ ▓██░ ▒░▒██▒▓██    ▓██░▒██  ▀█▄  ░ ▓██▄   
             ▒   ██▒▒▓█  ▄ ▒██░    ▒▓█  ▄ ▒▓▓▄ ▄██▒▒▓▓▄ ▄██▒░██░▒██   ██░▓██▒  ▐▌██▒░██▄▄▄▄██ ▓██▒  ▐▌██▒░▓█▄   ▌▒██   ██░     ▒██ █░░░██░▒▓▓▄ ▄██▒░ ▓██▓ ░ ░██░▒██    ▒██ ░██▄▄▄▄██   ▒   ██▒
           ▒██████▒▒░▒████▒░██████▒░▒████▒▒ ▓███▀ ░▒ ▓███▀ ░░██░░ ████▓▒░▒██░   ▓██░ ▓█   ▓██▒▒██░   ▓██░░▒████▓ ░ ████▓▒░      ▒▀█░  ░██░▒ ▓███▀ ░  ▒██▒ ░ ░██░▒██▒   ░██▒ ▓█   ▓██▒▒██████▒▒
           ▒ ▒▓▒ ▒ ░░░ ▒░ ░░ ▒░▓  ░░░ ▒░ ░░ ░▒ ▒  ░░ ░▒ ▒  ░░▓  ░ ▒░▒░▒░ ░ ▒░   ▒ ▒  ▒▒   ▓▒█░░ ▒░   ▒ ▒  ▒▒▓  ▒ ░ ▒░▒░▒░       ░ ▐░  ░▓  ░ ░▒ ▒  ░  ▒ ░░   ░▓  ░ ▒░   ░  ░ ▒▒   ▓▒█░▒ ▒▓▒ ▒ ░
           ░ ░▒  ░ ░ ░ ░  ░░ ░ ▒  ░ ░ ░  ░  ░  ▒     ░  ▒    ▒ ░  ░ ▒ ▒░ ░ ░░   ░ ▒░  ▒   ▒▒ ░░ ░░   ░ ▒░ ░ ▒  ▒   ░ ▒ ▒░       ░ ░░   ▒ ░  ░  ▒       ░     ▒ ░░  ░      ░  ▒   ▒▒ ░░ ░▒  ░ ░
           ░  ░  ░     ░     ░ ░      ░   ░        ░         ▒ ░░ ░ ░ ▒     ░   ░ ░   ░   ▒      ░   ░ ░  ░ ░  ░ ░ ░ ░ ▒          ░░   ▒ ░░          ░       ▒ ░░      ░     ░   ▒   ░  ░  ░  
                 ░     ░  ░    ░  ░   ░  ░░ ░      ░ ░       ░      ░ ░           ░       ░  ░         ░    ░        ░ ░           ░   ░  ░ ░                ░         ░         ░  ░      ░  
                                          ░        ░                                                      ░                       ░       ░                                                   
           ";
            string titulo_victimas_seleccionadas = @"








            

            ██▒   █▓ ██▓ ▄████▄  ▄▄▄█████▓ ██▓ ███▄ ▄███▓ ▄▄▄        ██████         ██████ ▓█████  ██▓    ▓█████  ▄████▄   ▄████▄   ██▓ ▒█████   ███▄    █  ▄▄▄      ▓█████▄  ▄▄▄        ██████ 
           ▓██░   █▒▓██▒▒██▀ ▀█  ▓  ██▒ ▓▒▓██▒▓██▒▀█▀ ██▒▒████▄    ▒██    ▒       ▒██    ▒ ▓█   ▀ ▓██▒    ▓█   ▀ ▒██▀ ▀█  ▒██▀ ▀█  ▓██▒▒██▒  ██▒ ██ ▀█   █ ▒████▄    ▒██▀ ██▌▒████▄    ▒██    ▒ 
            ▓██  █▒░▒██▒▒▓█    ▄ ▒ ▓██░ ▒░▒██▒▓██    ▓██░▒██  ▀█▄  ░ ▓██▄         ░ ▓██▄   ▒███   ▒██░    ▒███   ▒▓█    ▄ ▒▓█    ▄ ▒██▒▒██░  ██▒▓██  ▀█ ██▒▒██  ▀█▄  ░██   █▌▒██  ▀█▄  ░ ▓██▄   
             ▒██ █░░░██░▒▓▓▄ ▄██▒░ ▓██▓ ░ ░██░▒██    ▒██ ░██▄▄▄▄██   ▒   ██▒        ▒   ██▒▒▓█  ▄ ▒██░    ▒▓█  ▄ ▒▓▓▄ ▄██▒▒▓▓▄ ▄██▒░██░▒██   ██░▓██▒  ▐▌██▒░██▄▄▄▄██ ░▓█▄   ▌░██▄▄▄▄██   ▒   ██▒
              ▒▀█░  ░██░▒ ▓███▀ ░  ▒██▒ ░ ░██░▒██▒   ░██▒ ▓█   ▓██▒▒██████▒▒      ▒██████▒▒░▒████▒░██████▒░▒████▒▒ ▓███▀ ░▒ ▓███▀ ░░██░░ ████▓▒░▒██░   ▓██░ ▓█   ▓██▒░▒████▓  ▓█   ▓██▒▒██████▒▒
              ░ ▐░  ░▓  ░ ░▒ ▒  ░  ▒ ░░   ░▓  ░ ▒░   ░  ░ ▒▒   ▓▒█░▒ ▒▓▒ ▒ ░      ▒ ▒▓▒ ▒ ░░░ ▒░ ░░ ▒░▓  ░░░ ▒░ ░░ ░▒ ▒  ░░ ░▒ ▒  ░░▓  ░ ▒░▒░▒░ ░ ▒░   ▒ ▒  ▒▒   ▓▒█░ ▒▒▓  ▒  ▒▒   ▓▒█░▒ ▒▓▒ ▒ ░
              ░ ░░   ▒ ░  ░  ▒       ░     ▒ ░░  ░      ░  ▒   ▒▒ ░░ ░▒  ░ ░      ░ ░▒  ░ ░ ░ ░  ░░ ░ ▒  ░ ░ ░  ░  ░  ▒     ░  ▒    ▒ ░  ░ ▒ ▒░ ░ ░░   ░ ▒░  ▒   ▒▒ ░ ░ ▒  ▒   ▒   ▒▒ ░░ ░▒  ░ ░
                ░░   ▒ ░░          ░       ▒ ░░      ░     ░   ▒   ░  ░  ░        ░  ░  ░     ░     ░ ░      ░   ░        ░         ▒ ░░ ░ ░ ▒     ░   ░ ░   ░   ▒    ░ ░  ░   ░   ▒   ░  ░  ░  
                 ░   ░  ░ ░                ░         ░         ░  ░      ░              ░     ░  ░    ░  ░   ░  ░░ ░      ░ ░       ░      ░ ░           ░       ░  ░   ░          ░  ░      ░  
                ░       ░                                                                                        ░        ░                                           ░                         
";

            string titulo_ruleta = @"
                                                          ██▀███   █    ██  ██▓    ▓█████▄▄▄█████▓ ▄▄▄          ██▀███   █    ██   ██████  ▄▄▄      
                                                          ▓██ ▒ ██▒ ██  ▓██▒▓██▒    ▓█   ▀▓  ██▒ ▓▒▒████▄       ▓██ ▒ ██▒ ██  ▓██▒▒██    ▒ ▒████▄    
                                                          ▓██ ░▄█ ▒▓██  ▒██░▒██░    ▒███  ▒ ▓██░ ▒░▒██  ▀█▄     ▓██ ░▄█ ▒▓██  ▒██░░ ▓██▄   ▒██  ▀█▄  
                                                          ▒██▀▀█▄  ▓▓█  ░██░▒██░    ▒▓█  ▄░ ▓██▓ ░ ░██▄▄▄▄██    ▒██▀▀█▄  ▓▓█  ░██░  ▒   ██▒░██▄▄▄▄██ 
                                                          ░██▓ ▒██▒▒▒█████▓ ░██████▒░▒████▒ ▒██▒ ░  ▓█   ▓██▒   ░██▓ ▒██▒▒▒█████▓ ▒██████▒▒ ▓█   ▓██▒             
                                                          ░ ▒▓ ░▒▓░░▒▓▒ ▒ ▒ ░ ▒░▓  ░░░ ▒░ ░ ▒ ░░    ▒▒   ▓▒█░   ░ ▒▓ ░▒▓░░▒▓▒ ▒ ▒ ▒ ▒▓▒ ▒ ░ ▒▒   ▓▒█░
                                                          ░▒ ░ ▒░░░▒░ ░ ░ ░ ░ ▒  ░ ░ ░  ░   ░      ▒   ▒▒ ░     ░▒ ░ ▒░░░▒░ ░ ░ ░ ░▒  ░ ░  ▒   ▒▒ ░
                                                          ░░   ░  ░░░ ░ ░   ░ ░      ░    ░        ░   ▒        ░░   ░  ░░░ ░ ░ ░  ░  ░    ░   ▒   
                                                          ░        ░         ░  ░   ░  ░              ░  ░      ░        ░           ░        ░  ░

";

            string rutaExcel = "C:\\Users\\grego\\OneDrive\\Escritorio\\estudiantes competencia.xlsx";
            string[] nombres_desarrolladores;
            string[] nombres_facilitadores;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var paquete = new ExcelPackage(new FileInfo(rutaExcel)))
            {
                ExcelWorksheet hoja = paquete.Workbook.Worksheets[0];
                int filas = hoja.Dimension.Rows;
                nombres_desarrolladores = new string[filas];
                for (int i = 1; i <= filas; i++)
                {
                    nombres_desarrolladores[i - 1] = hoja.Cells[i, 1].Text;
                }
            }
            nombres_facilitadores = new string[nombres_desarrolladores.Length];
            for (int i = 0; i < nombres_desarrolladores.Length; i++)
            {
                nombres_facilitadores[i] = nombres_desarrolladores[i];
            }

            do
            {
                var audioFile = "c:/Users/grego/Downloads/horror-background-tension-8-259233.wav";
                using (var audioPlayer = new AudioFileReader(audioFile))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioPlayer);
                    outputDevice.Play();
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    System.Console.WriteLine(titulo_ruleta);
                    Console.WriteLine(@"
                                
                                                             ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
                                                                                                                                                                    
                                                                                                                                                                            
                                                                                     💀  BIENVENIDO A LA RULETA RUSA  💀                     
                                                                                                                                                                            
                                                                                                                                                                            
                                                                                         1. 🔫 Iniciar Juego                                   
                                                                                         2. 📜 Ver Historial de Partidas                       
                                                                                         3. 🗑️ Eliminar Historial                              
                                                                                         4. 🚪 Salir                                             
                                                                                                                                                                            
                                                                                                                                                                            
                                                                                     *    Juega bajo tu propio riesgo    *                   
                                                                                                                                                                        
                                                                                                                                                                        
                                                             ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
                    ");


                    System.Console.WriteLine("");
                    Console.Write("                                                                                         Seleccione una opción: ");

                    if (!int.TryParse(Console.ReadLine(), out seleccion) || seleccion < 1 || seleccion > 4)
                    {
                        System.Console.WriteLine("");
                        Console.WriteLine("                                                                    Opción no válida. Presiona cualquier tecla para intentar de nuevo.");
                        Console.ReadKey();
                        continue;
                    }
                }
                switch (seleccion)
                {
                    case 1:
                        var audioFile1 = @"C:/Users/grego/Downloads/creepy-suspense-horror-background-music-251989.wav";
                        using (var audioPlayer = new AudioFileReader(audioFile1))
                        using (var outputDevice = new WaveOutEvent())
                        {
                            outputDevice.Init(audioPlayer);
                            outputDevice.Play();

                            if (conteo_estudiantes(nombres_desarrolladores) == 0 || conteo_estudiantes(nombres_desarrolladores) == 1)
                            {
                                System.Console.WriteLine("");
                                System.Console.WriteLine("                                                                                      No hay estudiantes disponibles");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                do
                                {
                                    do
                                    {
                                        indice_desarrollador = seleccionar_participante(ref nombres_desarrolladores);
                                        Thread.Sleep(500);
                                        System.Console.WriteLine("");
                                        indice_facilitador = seleccionar_participante(ref nombres_facilitadores);

                                    } while (indice_desarrollador == indice_facilitador);

                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    System.Console.WriteLine(titulo_victimas_seleccionadas);
                                    System.Console.WriteLine(desing);
                                    System.Console.WriteLine($"                                                                          El desarrollador en vivo es: {nombres_desarrolladores[indice_desarrollador]}");
                                    System.Console.WriteLine($"                                                                          El facilitador es: {nombres_facilitadores[indice_facilitador]}");
                                    Manejoarchivo.agregar($"Desarrollador en vivo - {nombres_desarrolladores[indice_desarrollador]}", $"Facilitador - {nombres_facilitadores[indice_facilitador]}");
                                    System.Console.WriteLine(desing);
                                    System.Console.WriteLine("");
                                    nombres_desarrolladores[indice_desarrollador] = "";
                                    nombres_facilitadores[indice_facilitador] = "";
                                    var key = Console.ReadKey();
                                    if (key.Key == ConsoleKey.Enter)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        if (conteo_estudiantes(nombres_desarrolladores) == 0)
                                        {
                                            System.Console.WriteLine("                                                                                         No hay estudiantes disponibles");
                                            Console.ReadKey();
                                            break;
                                        }

                                        if (conteo_estudiantes(nombres_desarrolladores) == 1 && conteo_estudiantes(nombres_facilitadores) == 1)
                                        {
                                            string estudiante_restante = nombres_desarrolladores.FirstOrDefault(nombre => nombre != "")!;
                                            if (estudiante_restante == nombres_facilitadores.FirstOrDefault(nombre => nombre != ""))
                                            {
                                                System.Console.WriteLine($"{estudiante_restante} eres el ultimo superviviente pero no te saldras con la tuya, Orison elige tu ejercicio ");
                                                Console.ReadKey();
                                                break;
                                            }
                                        }
                                    }

                                } while (true);
                            }
                            break;
                        }


                    case 2:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        System.Console.WriteLine(titulo_historial);
                        System.Console.WriteLine(desing);
                        Manejoarchivo.Leer();
                        System.Console.WriteLine(desing);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 3:
                        Manejoarchivo.eliminar();
                        Console.ReadKey();
                        
                        break;
                    case 4:
                        System.Console.WriteLine("");
                        puntos_espera();
                        break;

                }
                Console.Clear();
            }
            while (seleccion != 4);

            void puntos_espera()
            {
                string puntos = "...";
                Console.ForegroundColor = ConsoleColor.DarkRed;
                System.Console.Write("                                                                                                Saliendo: ");
                foreach (var punto in puntos)
                {
                    Console.Write(punto);
                    Thread.Sleep(1000);
                }
                System.Console.WriteLine();
                return;
            }

            int seleccionar_participante(ref string[] nombres_participantes)
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    System.Console.WriteLine(titulo_seleccion);
                    do
                    {
                        indice_aleatorio = random.Next(0, nombres_participantes.Length);
                        nombre_seleccionado = nombres_participantes[indice_aleatorio];
                        if (nombre_seleccionado != "")
                        {
                            System.Console.WriteLine(desing);
                            Console.WriteLine($"                                                                             El seleccionado es: {nombre_seleccionado}");
                            System.Console.WriteLine(desing);
                            Thread.Sleep(500);
                        }
                    } while (nombre_seleccionado == "");
                }
                return indice_aleatorio;
            }

            int conteo_estudiantes(string[] nombres_estudiantes)
            {
                int contador = 0;
                for (int i = 0; i < nombres_estudiantes.Length; i++)
                {
                    if (nombres_estudiantes[i] != "")
                    {
                        contador++;
                    }

                }
                return contador;
            }
        }
    }
}