using System;
using System.Text;
using System.Threading;

namespace Ucu.Poo.GameOfLife
{
    // Crea la clase print encargada de imprimir el tablero
    public class Print
    {
        // Crea metodo estatico tipo void que no retorna nada llamado PrintBoard que imprime el tablero en la consola
        public static void PrintBoard(Grid gameBoard)
        {
            Console.Clear(); // Limpia la pantalla antes de mostrar la nueva generación
                StringBuilder text = new StringBuilder();// Objeto para armar el texto de salida
                // Recorre todas las filas del tablero
                for (int y = 0; y < gameBoard.Height; y++)
                {   
                    // Recorre todas las columnas de la fila actual
                    for (int x = 0; x < gameBoard.Width; x++)
                    {
                        // Si la célula está viva, agrega "|X|" al texto
                        if (gameBoard.IsAlive(x, y))
                            text.Append("|X|");
                        // Si la célula está muerta, agrega "___" al texto
                        else
                            text.Append("___");
                    }
                    // Al terminar la fila, agrega un salto de línea
                    text.Append('\n');
                }
                // Muestra en consola todo el tablero armado
                Console.WriteLine(text.ToString());       
        }
    }
}
