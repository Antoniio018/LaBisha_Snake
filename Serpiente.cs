using System.Collections.Generic;

namespace LaBishaClases
{
    internal class Serpiente
    {
        public enum Movimiento
        {
            Arriba,
            Abajo,
            Derecha,
            Izquierda,
            Parada
        }

        private int y;
        private int x;
        private Movimiento direccion;
        private int[,] escenario;

        public int X
        {
            set => x = value; 
            get => x;
        }
        public int Y
        {
            set => y = value;
            get => y;
        }

        public Movimiento Direccion
        {
            get => direccion;
            set => direccion = value;
        }

        //Constructor
        public Serpiente(int[,] escenario, int x, int y)
        {
            direccion = Movimiento.Parada;
            this.x = x;
            this.y = y;
            this.escenario = escenario;
        }

        //Método para avanzar la serpiente en función a su dirección
        public void Avanzar()
        {
            switch (direccion)
            {
                case Movimiento.Arriba:
                    y--;
                    break;
                case Movimiento.Abajo:
                    y++;
                    break;
                case Movimiento.Derecha:
                    x++;
                    break;
                case Movimiento.Izquierda:
                    x--;
                    break;
                case Movimiento.Parada:
                    break;
            }
        }

        public void Izquierda()
        {
            direccion = Movimiento.Izquierda;
        }
        public void Derecha()
        {
            direccion = Movimiento.Derecha;
        }
        public void Arriba()
        {
            direccion = Movimiento.Arriba;
        }
        public void Abajo()
        {
            direccion = Movimiento.Abajo;
        }
    }
}
