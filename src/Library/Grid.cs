using System;

namespace Ucu.Poo.GameOfLife
{

    // Crea la clase grid encargada como puente entre game y print, que encapsula el tablero y permite consultarlo y actualizarlo
    public class Grid
    {
        // Matriz booleana que representa el tablero (células vivas/muertas)
        private bool[,] cells;
        // Propiedad que devuelve el ancho del tablero (cantidad de columnas)
        public int Width => cells.GetLength(0);
        // Propiedad que devuelve el alto del tablero (cantidad de filas)
        public int Height => cells.GetLength(1);
        // Constructor: inicializa el tablero con una matriz ya cargada
        public Grid(bool[,] initial)
        {
            cells = initial;
        }
        // Método que indica si una célula en (x,y) está viva
        public bool IsAlive(int x, int y)
        {
            return cells[x, y];
        }
        // Método que actualiza el tablero aplicando las reglas del Juego de la Vida
        public void Update()
        {
            cells = Game.GameLogic(cells);
        }
    }
}
