//------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System; // Importa funcionalidades básicas de C# (consola, etc.)
using System.IO; // Permite trabajar con archivos y directorios (lectura, escritura, rutas)
using System.Reflection; // Da acceso a información sobre el ensamblado en ejecución (ubicación, metadatos)
using System.Text; // Proporciona clases para manipular texto, como StringBuilder
using System.Threading; // Permite manejar hilos y pausas (Thread.Sleep)

namespace Ucu.Poo.GameOfLife // Define el espacio de nombres del proyecto, agrupa las clases relacionadas
{
    // Clase Programa es el main desde donde arranca el codigo implementando el resto de las clases 
    class Program
    {
        // Arranca el metodo estatico desde donde corre el main
        static void Main(string[] args)
        {   
            // Obtiene la carpeta donde se está ejecutando el programa
            string folder = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location);
            // Construye la ruta completa al archivo board.txt dentro de esa carpeta
            string boardPath = Path.Combine(folder, "board.txt");
            // Reemplaza 👇 esta línea con tu código

            // Lee el tablero inicial desde el archivo board.txt
            bool[,] b = FileReader.ReadFile(boardPath);
            // Obtiene el ancho del tablero
            int width = b.GetLength(0);
            // Obtiene el alto del tablero
            int height = b.GetLength(1);
            // Bucle infinito que mantiene el juego corriendo generación tras generación
            while (true)
            {   
                // Limpia la consola antes de imprimir la nueva generación
                Console.Clear();
                // StringBuilder para armar el texto del tablero
                StringBuilder s = new StringBuilder();
                // Recorre todas las filas del tablero
                for (int y = 0; y < height; y++)
                {
                    // Recorre todas las columnas de la fila actual
                    for (int x = 0; x < width; x++)
                    {
                        // Si la célula está viva imprime "|X|"
                        if (b[x, y])
                            s.Append("|X|");
                        // Si la célula está muerta imprime "___"
                        else
                            s.Append("___");
                    }
                    // Al terminar la fila agrega un salto de línea
                    s.Append("\n");
                }
                // Muestra en consola todo el tablero armado
                Console.WriteLine(s.ToString());
                // Calcula la siguiente generación aplicando las reglas del Juego de la Vida
                b = Game.GameLogic(b);
                // Pausa de 300 milisegundos para que la animación sea visible
                Thread.Sleep(300);
            }

        }
    }
}
