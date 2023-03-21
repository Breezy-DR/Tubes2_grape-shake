using System;
using System.Collections.Generic;

namespace Maze {
    class Program {
        static void Main(string[] args) {
            try {
                string filename;
                Console.Write("Masukkan nama file: ");
                filename = Console.ReadLine();
                Utils ut = new Utils();
                string[][] jag = ut.ReadFile(filename);
                ut.printMatrix(jag);
                if (!ut.isLineHaveEqualElement(jag)) {
                    Console.WriteLine("All lines have to have the same number of elements");
                } else if (!ut.isSymbolValid(jag)) {
                    Console.WriteLine("File symbols can only be X, R, K, and T");
                } else if (ut.ElementCount(jag, "K") != 1
                            || ut.ElementCount(jag, "R") == 0
                            || ut.ElementCount(jag, "T") == 0
                            || ut.ElementCount(jag, "X") == 0) {
                    Console.WriteLine("File has to have exactly one symbol of K, and at least one symbol of R, T, and X.");
                } else {
                    Console.WriteLine("File is valid.");
                    MatrixElement[][] mainMatrix = ut.InitMatrix(jag);
                    // the rest of the BFS, DFS code
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}

