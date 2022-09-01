using System;

namespace Juego
{
    class JuegoSnake
    {
        static bool gameOver;
        static Celda[,] tablero;
        static Snake sierpe;
        static char direccion;
        static Random random;
        const int baseSize = 1;
        static void Main(string[] args)
        {
            random = new Random();
            CrearTablero(24);
            ImpTablero();
            GamePlay();            
        }

        static void CrearTablero(int size)
        {
            tablero = new Celda[size, size];
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    tablero[y, x] = new Celda('.', '.');
                }
            }
            CrearFruta();
            tablero[tablero.GetLength(0) / 2, tablero.GetLength(1) / 2] = new Celda('O', '.');
            sierpe = new Snake(tablero.GetLength(0) / 2, tablero.GetLength(1) / 2, baseSize);
        }

        static void ImpTablero()
        {
            for (int x = 0; x < tablero.GetLength(0); x++)
            {
                for (int y = 0; y < tablero.GetLength(0); y++)
                {
                    Console.Write(tablero[y, x].Valor);
                    Console.Write("  ");

                }
                Console.WriteLine(" ");
            }
            Console.WriteLine("Puntuacion: " + (sierpe.Size - 1));
        }

        static void GamePlay()
        {
            do
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        direccion = 'u';
                        break;
                    case ConsoleKey.DownArrow:
                        direccion = 'd';
                        break;
                    case ConsoleKey.RightArrow:
                        direccion = 'r';
                        break;
                    case ConsoleKey.LeftArrow:
                        direccion = 'l';
                        break;
                    default:                       
                        break;
                }
                //update
                Update();

                //limpiar
                Console.Clear();
                //mostrar
                ImpTablero();                
            }
            while (!gameOver);
            Console.WriteLine('F');
            Console.ReadLine();

        }

        private static void Update()
        {
            tablero[sierpe.CabezaX, sierpe.CabezaY].Orden = direccion;
            sierpe.MoveSet(direccion);
            // detectar si se sale por los bordes y lo metemos otra vez
            DetectarBordesCabeza();
            Celda aux = tablero[sierpe.CabezaX, sierpe.CabezaY];
            ValidarMover(aux);           
            BorrarCola();            
        }

        private static void ValidarMover(Celda c)
        {
            if (c.Valor == 'O') gameOver = true;
            else if (c.Valor == 'X') gameOver = true;
            else if (c.Valor == '#')
            {
                sierpe.Crecimiento++;
                sierpe.Size++;
                CrearFruta();
                //cambias los datos de la celda
                tablero[sierpe.CabezaX, sierpe.CabezaY] = new Celda('O', direccion);
            }
            else tablero[sierpe.CabezaX, sierpe.CabezaY] = new Celda('O', direccion);
        }

        private static void DetectarBordesCabeza()
        {
            switch (direccion)
            {
                case 'u':
                    if (sierpe.CabezaY < 0)
                        sierpe.CabezaY = tablero.GetLength(0) - 1;
                    break;
                case 'd':
                    if (sierpe.CabezaY >= tablero.GetLength(0))
                        sierpe.CabezaY = 0;
                    break;
                case 'l':
                    if (sierpe.CabezaX < 0)
                        sierpe.CabezaX = tablero.GetLength(0) - 1;
                    break;
                case 'r':
                    if (sierpe.CabezaX >= tablero.GetLength(0))
                        sierpe.CabezaX = 0;
                    break;
            }
        }
        private static void DetectarBordesCola(char direccion)
        {
            switch (direccion)
            {
                case 'u':
                    if (sierpe.ColaY < 0)
                        sierpe.ColaY = tablero.GetLength(0) - 1;
                    break;
                case 'd':
                    if (sierpe.ColaY >= tablero.GetLength(0))
                        sierpe.ColaY = 0;
                    break;
                case 'l':
                    if (sierpe.ColaX < 0)
                        sierpe.ColaX = tablero.GetLength(0) - 1;
                    break;
                case 'r':
                    if (sierpe.ColaX >= tablero.GetLength(0))
                        sierpe.ColaX = 0;
                    break;
            }
        }
        private static void BorrarCola()
        {
            if (sierpe.Crecimiento > 0)
            {
                sierpe.Crecimiento--;
            }      
            else
            {   
                int x = sierpe.ColaX;
                int y = sierpe.ColaY;
                sierpe.MoveCola(tablero[x, y].Orden);
                DetectarBordesCola(tablero[x, y].Orden);
                tablero[x, y] = new Celda('.','.');                
            }
        }
        private static void CrearFruta()
        {
            int x = random.Next(tablero.GetLength(0));
            int y = random.Next(tablero.GetLength(0));
            if (tablero[x, y].Valor == '.')
            {
                tablero[x, y] = new Celda('#', '.');
            }
            else CrearFruta();
        }
    }
}
