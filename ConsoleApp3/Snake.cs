using System;
using System.Collections.Generic;
using System.Text;

namespace Juego
{
    class Snake
    {
        //atributos
        private int cabezaX;
        private int cabezaY;
        private int colaX;
        private int colaY;
        private int size;
        private int crecimiento;

        //constructor
        public Snake(int cabezaX, int cabezaY, int size)
        {
            this.cabezaX = cabezaX;
            this.cabezaY = cabezaY;
            this.size = size;
            colaX = cabezaX;
            colaY = cabezaY;
            crecimiento = size -1;
        }
        //actualizar valores (getter setter)
        public int CabezaX { get => cabezaX; set => cabezaX = value; }
        public int CabezaY { get => cabezaY; set => cabezaY = value; }
        public int ColaX { get => colaX; set => colaX = value; }
        public int ColaY { get => colaY; set => colaY = value; }
        public int Size { get => size; set => size = value; }
        public int Crecimiento { get => crecimiento; set => crecimiento = value; }

        //metodos
        public void MoveSet (char direccion)
        {
            switch (direccion)
            {
                case 'u':
                    cabezaY--;
                    break;
                case 'r':
                    cabezaX++;
                    break;
                case 'd':
                    cabezaY++;
                    break;
                case 'l':
                    cabezaX--;
                    break;                              
            }           
        }
        public void MoveCola(char direccion)
        {
            switch (direccion)
            {
                case 'u':
                    colaY--;
                    break;
                case 'r':
                    colaX++;
                    break;
                case 'd':
                    colaY++;
                    break;
                case 'l':
                    colaX--;
                    break;
            }
        }
    }
}
