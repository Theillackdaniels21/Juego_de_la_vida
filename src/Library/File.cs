using System;
using System.IO;

namespace Ucu.Poo.GameOfLife
{
    // Crea la clase FileReader encargada de leer el archivo de board.txt
    public class FileReader
    {
        // Crea un metodo estatico de tipo bool matriz que se llama ReadFile y recibe como parametros la ruta del archivo
        public static bool[,] ReadFile(string path)
        {
            // Lee todo el contenido del archivo board.txt
            string contenido = File.ReadAllText(path);
            // Separa el contenido en líneas (cada línea es una fila del tablero)
            string [] lineas = contenido.Split('\n');
            // Crea la matriz: columnas = largo de la primera línea, filas = cantidad de líneas
            bool[,] tablero = new bool[lineas[0].Trim().Length, lineas.Length];
            // Recorre cada fila del archivo
            for (int y = 0; y < lineas.Length; y++)
            {
                // Elimina espacios en blanco al inicio/fin de la línea
                string lineaActual = lineas[y].Trim();
                // Recorre cada carácter de la fila
                for (int x = 0; x < lineaActual.Length; x++)
                {
                    // Si el carácter es '1' marca la celda como viva en la matriz
                    if (lineaActual[x] == '1')
                    {
                        tablero[x,y] = true;
                    }
                }
            }
            // Devuelve la matriz con el tablero cargado desde el archivo
            return tablero;
        }
    }
}
