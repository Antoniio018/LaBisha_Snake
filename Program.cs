using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LaBishaClases
{
    internal class Program
    {
        private static int gameDelay = 100;
        private static int Width = Console.BufferWidth;
        private static int Suelo = 25;
        private static int limiteStartX;
        private static int limiteEndX;
        private static int limiteStartY;
        private static int limiteEndY;
        static void Main(string[] args)
        {
            int[,] escenario = new int[Suelo, Width];
            int frutas = 0;


            //Crea un objeto para lectura de teclado
            ConsoleKeyInfo tecla = new ConsoleKeyInfo();
            Boolean game = true;

            //Oculta el cursor
            Console.CursorVisible = false;

            //Cambiamos el titulo de la consola
            Console.Title = "La Bisha";

            //Dibujamos el marcador
            PintarMarcador(frutas);

            //Dibujamos la escena
            PintarEscena(Suelo);

            //Declaramos la serpiente
            List<Serpiente>serpiente = new List<Serpiente>();
            
            //Inicialzamos la cabeza de la serpiente en el centro del tablero 
            Serpiente labisha = new Serpiente(escenario, (Width / 2) - 1, Suelo/2);
            SetLimits(Width, Suelo);
            serpiente.Add(labisha);
            serpiente.Add(new Serpiente(escenario, labisha.X - 1, labisha.Y));
            serpiente.Add(new Serpiente(escenario, labisha.X - 2, labisha.Y));


            while (game)
            {
                if (Console.KeyAvailable)
                {
                    //Hay una tecla que leer
                    tecla = Console.ReadKey();

                    //Comprobaciones (¿Son mis teclas?)
                    if (tecla.Key == ConsoleKey.Escape)
                        game = false;
                    else if (tecla.Key == ConsoleKey.LeftArrow)
                    {
                        //Mueve a la izquierda
                        //Actualiza variables
                        if (serpiente[0].Direccion != Serpiente.Movimiento.Derecha)
                            serpiente[0].Izquierda();
                    }
                    else if (tecla.Key == ConsoleKey.RightArrow)
                    {
                        //Mueve a la derecha
                        //Actualiza variables
                        if (serpiente[0].Direccion != Serpiente.Movimiento.Izquierda)
                            serpiente[0].Derecha();
                    }
                    else if (tecla.Key == ConsoleKey.DownArrow)
                    {
                        //Mueve hacia abajo
                        //Actualiza variables
                        if (serpiente[0].Direccion != Serpiente.Movimiento.Arriba)
                            serpiente[0].Abajo();
                    }
                    else if (tecla.Key == ConsoleKey.UpArrow)
                    {
                        //Mueve hacia arriba
                        //Actualiza variables
                        if (serpiente[0].Direccion != Serpiente.Movimiento.Abajo)
                            serpiente[0].Arriba();
                    }
                }
                ActualizarSerpiente(serpiente);
                //Movemos la bisha en funcion a la última dirección seleccionada
                serpiente[0].Avanzar();

                //Pinta la serpiente actualizada
                foreach (Serpiente s in serpiente)
                {
                    
                    Console.SetCursorPosition(s.X, s.Y);
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(" ");
                }

                //Tiempo de juego
                Thread.Sleep(gameDelay);

                //Borra la serpiente actualizada
                foreach (Serpiente s in serpiente)
                {
                    Console.SetCursorPosition(s.X, s.Y);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }

                if (Colision(labisha.X, labisha.Y))
                    game = false;
            }
        }

        //Método para actualizar las variables de la serpiente
        public static void ActualizarSerpiente(List<Serpiente> serpiente)
        {
            for (int i = serpiente.Count - 1; i > 0; i--)
            {
                serpiente[i].Direccion = serpiente[i - 1].Direccion;
                serpiente[i].X = serpiente[i - 1].X;
                serpiente[i].Y = serpiente[i - 1].Y;
            }
        }

        //Método para comprobar si la serpiente colisiona
        public static bool Colision(int x, int y)
        {
            return (y == limiteEndY || y == limiteStartY || x <= limiteStartX || x >= limiteEndX);
        }

        //Método para establecer los limites del tablero
        public static void SetLimits(int Width, int Suelo)
        {
            limiteStartX = 1;
            limiteEndX = Width - 1;
            limiteStartY = 1;
            limiteEndY = Suelo;
        }

        //Método para pintar el marcador de frutas comidas
        private static void PintarMarcador(int frutas)
        {
            Console.SetCursorPosition((Width / 2) - 5, 0);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write($"SCORE -> {frutas}");
        }

        //Método para pintar la escena
        private static void PintarEscena(int suelo)
        {
            //Pintar el suelo
            for (int i = 0; i < Width; i++)
            {
                Console.SetCursorPosition(i, suelo);
                Console.Write("-");
            }

            //Pintar techo
            for (int i = 0; i < Width; i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("-");
            }

            //Pintar pared izquierda
            for (int i = 2; i <= suelo; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("|");
            }
            //Pintar pared derecha
            for (int i = 2; i <= suelo; i++)
            {
                Console.SetCursorPosition(Width - 1, i);
                Console.Write("|");
            }
        }
    }
}
