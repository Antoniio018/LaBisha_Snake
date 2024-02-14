using System;
using System.Threading;

namespace LaBishaClases
{
    internal class Fruta
    {
        public const int Yellow = 1;
        public const int Red = -1;
        public const int Blue = 4;
        public const int Green = 2;

        private bool eated;
        private int x;
        private int y;
        private int[,] escenario;
        private Random random;
        private ConsoleColor colorFruta;

        //Array de colores para elegir uno aleatoriamente
        private ConsoleColor[] colores = {
            ConsoleColor.Yellow,
            ConsoleColor.Red,
            ConsoleColor.Blue,
            ConsoleColor.Green
        };

        public bool Eated
        {
            get => eated;
        }

        public int X
        {
            get => x;
        }

        public int Y
        {
            get => y;
        }

        public Fruta(int[,] escenario)
        {
            eated = false;
            this.escenario = escenario;
            random = new Random();
            GenerarFruta();

        }

        //Al ser comida devuelve el efecto que tiene dicha fruta en la serpiente
        public int Comida()
        {
            eated = true;
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

        //Método para generar coordenadas aleatorias dentro del tablero
        private void GenerarFruta()
        {   
            x = random.Next(1, escenario.GetLength(0) - 3);
            y = random.Next(2, escenario.GetLength(1) - 3);
            escenario[x, y] = 2;
            colorFruta = colores[random.Next(colores.Length)];
            MostrarFruta();
        }

        //Método para mostrar la fruta en la posición actual si no ha sido comida
        private void MostrarFruta()
        {
            if (!eated)
            {
                Console.SetCursorPosition(x, y);
                Console.BackgroundColor = colorFruta;
                Console.Write(" ");
            }
        }

        //Método para generar una fruta 4 segundos tras ser comida, en caso negativo no se genera
        public void ReaparecerFruta()
        {
            //Thread current = Thread.CurrentThread;
            //Thread.Sleep(4000);
            escenario[x, y] = 0;
            eated = false;
            GenerarFruta();
        }
    }
}
