using System;
using System.Threading;

namespace LaBishaClases
{
    internal class Fruta
    {
        //Constantes
        public const int Yellow = 1;
        public const int Red = -1;
        public const int Blue = 4;
        public const int Green = 2;
        private const int duracionPantalla = 10000;

        //Atributos
        private int x;
        private int y;
        private int[,] escenario;
        private Random random;
        private ConsoleColor colorFruta;
        private Timer timer;

        public int X
        {
            get => x;
        }
        public int Y
        {
            get => y;
        }
        //Array de colores para elegir uno aleatoriamente
        private ConsoleColor[] colores = {
            ConsoleColor.Yellow,
            ConsoleColor.Red,
            ConsoleColor.Blue,
            ConsoleColor.Green
        };

        //Constructor
        public Fruta(int[,] escenario)
        {
            this.escenario = escenario;
            random = new Random();
            x = (escenario.GetLength(0) / 2) - 5;
            y = (escenario.GetLength(1) / 2) - 5;
            InicializarTemporizador();
        }

        //Método que devuelve el efecto de la fruta que tiene sobre la serpiente
        public int Comida()
        {
            switch (colorFruta)
            {
                case ConsoleColor.Yellow:
                    return Yellow;
                case ConsoleColor.Red:
                    return Red;
                case ConsoleColor.Blue:
                    return Blue;
                default:
                    return Green;
            }       
        }

        //Método para generar la fruta y en caso de que no se haya comido se vuelve a generar 
        //cuando pasen los 10 segundos establecidos en duracionPantalla
        private void GenerarFruta(object state)
        {
            BorrarFruta();
            do
            {
                x = random.Next(1, escenario.GetLength(0) - 3);
                y = random.Next(2, escenario.GetLength(1) - 3);
            } while (escenario[x, y] != 0);
            
            escenario[x, y] = 2;
            colorFruta = colores[random.Next(colores.Length)];
            colorFruta = colores[2];

            MostrarFruta();

            //Proxima generacion de fruta
            timer.Change(duracionPantalla, Timeout.Infinite); 
        }

        //Método para mostrar la fruta
        private void MostrarFruta()
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = colorFruta;
            Console.Write(" ");
        }

        //Método para borrar la fruta
        private void BorrarFruta()
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
        }

        //Método para inicar el temporizador
        private void InicializarTemporizador()
        {
            timer = new Timer(GenerarFruta, null, 0, Timeout.Infinite);
        }

        //Método para interrumpir el temporizador ha sido comida
        //llamando a inicializartemporizador de nuevo para generar una nueva fruta
        public void InterrumpirTemporizador()
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
            InicializarTemporizador();
        }
    }
}
