using System.Timers;

namespace competenciaaaaa
{
    public class Manejoarchivo
    {
        public static DateTime fechaHoraActual = DateTime.Now;
        public static string path = $"C:/Users/grego/OneDrive/Escritorio/Competencia1.0/Historial-Dia{fechaHoraActual.ToString("dd")}.txt";
        public static void agregar(string dato1, string dato2)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(dato1);
                writer.WriteLine(dato2);
            }
        }

        public static void Leer()
        {
            if (File.Exists(path))
            {

                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    int anchoConsola = Console.WindowWidth;

                    while ((line = reader.ReadLine()!) != null)
                    {
                        int espacios = (anchoConsola - line.Length) / 2;

                        if (espacios > 0)
                        {
                            string textoCentrado = new string(' ', espacios) + line;
                            Console.WriteLine(textoCentrado);
                        }
                        else
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
            }
            else
            {
                System.Console.WriteLine("                                                                                          El historial no existe");
            }
        }

        public static void eliminar()
        {
        
            if (File.Exists(path))
            {
                File.Delete(path);
                System.Console.WriteLine("");
                Console.WriteLine("                                                                                            Historial eliminado.");
            }
            else
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("                                                                                      No existe historial para borrar.");
            }

        }
    }
}