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

        protected int y;
        protected int x;

        protected Movimiento direccion;
        protected bool vida;

        protected int[,] escenario;

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


        public Serpiente(int[,] escenario, int x, int y)
        {
            vida = true;
            direccion = Movimiento.Parada;
            this.x = x;
            this.y = y;
            this.escenario = escenario;
        }


        public bool IsDead()
        {
            return !vida;
        }
        public void Avanzar()
        {
            //escenario[x, y] = 0;
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
            }/*
            if (escenario[x, y] == 1)
            {
                vida = false;
                return;
            }
            escenario[x, y] = 1;*/
        }
        public void Actualizar(Movimiento direccion, int x, int y)
        {
            this.direccion = direccion;
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
