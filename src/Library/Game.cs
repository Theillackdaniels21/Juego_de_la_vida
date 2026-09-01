
namespace Ucu.Poo.GameOfLife
{
    // Crea la clase llamada game encargada de la logica del juego
    public class Game
    {
        // Crea el metodo estatico de tipo bool como matriz llamado GameLogic que recibe la matriz de board
        public static bool[,] GameLogic(bool[,] gameBoard)
        {
            // Obtiene el ancho del tablero
            int boardWidth = gameBoard.GetLength(0);
            // Obtiene el alto del tablero
            int boardHeight = gameBoard.GetLength(1);

            // Crea una nueva matriz para guardar la siguiente generación
            bool[,] cloneboard = new bool[boardWidth, boardHeight];
            // Recorre cada celda del tablero
            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {   
                    // Contador de vecinos vivos alrededor de la celda actual
                    int aliveNeighbors = 0;
                    // Recorre las posiciones vecinas (3x3 alrededor de la celda)
                    for (int i = x-1; i<=x+1;i++)
                    {
                        for (int j = y-1;j<=y+1;j++)
                        {   
                            // Verifica que la posición esté dentro del tablero y suma si hay célula viva
                            if(i>=0 && i<boardWidth && j>=0 && j < boardHeight && gameBoard[i,j])
                            {
                                aliveNeighbors++;
                            }
                        }
                    }
                    // Resta la celda actual si estaba viva (porque se contó en el bucle anterior)
                    if(gameBoard[x,y])
                    {
                        aliveNeighbors--;
                    }
                    // Reglas del Juego de la Vida 
                    if (gameBoard[x,y] && aliveNeighbors < 2)
                    {
                        // Célula muere por baja población
                        cloneboard[x,y] = false;
                    }
                    else if (gameBoard[x,y] && aliveNeighbors > 3)
                    {
                        // Célula muere por sobrepoblación
                        cloneboard[x,y] = false;
                    }
                    else if (!gameBoard[x,y] && aliveNeighbors == 3)
                    {
                        // Célula nace por reproducción
                        cloneboard[x,y] = true;
                    }
                    else
                    {
                        // Célula mantiene el estado que tenía
                        cloneboard[x,y] = gameBoard[x,y];
                    }
                }
            }
            // Devuelve el tablero actualizado con la nueva generación
            return cloneboard;
        }

    }
}