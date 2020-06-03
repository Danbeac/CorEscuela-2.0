
using static System.Console;
namespace CorEscuela.Util
{
    public static class Printer
    {
        public static void DibujarLinea(int tam = 10)
        {
            WriteLine("".PadLeft(tam, '='));
        }

        public static void PrintTitle(string title)
        {

            int largoLinea = (title.Length * 4);

            if (largoLinea > 80)
            {
                largoLinea = 80;
            }

            int margen = title.Length;
            WriteLine("".PadLeft(largoLinea, '='));
            WriteLine($"                     {title}                                   ");
            WriteLine("".PadLeft(largoLinea, '='));
        }

        public static void Beep(int hz = 2000, int tiempo = 500, int cantidad = 1)
        {
            while (cantidad-- > 0)
            {
                System.Console.Beep(hz, tiempo);
            }
        }
    }
}