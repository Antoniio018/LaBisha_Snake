using System;
using System.Threading;

namespace LaBishaClases
{
    internal class Fruta
    {
        private bool eated;
        private int x;
        private int y;
        private int[,] escenario;
        private Random random;

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

        public void Comida()
        {
            eated = true;
        }

        //Método para generar coordenadas aleatorias dentro del tablero
        private void GenerarFruta()
        {   
            x = random.Next(1, escenario.GetLength(0) - 3);
            y = random.Next(2, escenario.GetLength(1) - 3);
            escenario[x, y] = 2;
        }

        //Método para mostrar la fruta en la posición actual si no ha sido comida
        public void MostrarFruta()
        {
            if (!eated)
            {
                Console.SetCursorPosition(x, y);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(" ");
            }
        }

        //Método para generar una fruta 4 segundos tras ser comida, en caso negativo no se genera
        public void ReaparecerFruta()
        {
            //Thread.Sleep(4000);
            escenario[x, y] = 0;
            eated = false;
            GenerarFruta();
        }
    }
}
