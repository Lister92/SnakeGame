using System;
using System.Collections.Generic;
using System.Text;

namespace Juego
{
    class Celda    
    {
        private char valor;
        private char orden;

        public Celda(char valor, char posicion)
        {
            this.valor = valor;
            this.orden = posicion;
        }

        public char Valor { get => valor; set => valor = value; }
        public char Orden { get => orden; set => orden = value; }
    }
}
