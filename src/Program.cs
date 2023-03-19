using System;
using System.Collections.Generic;

namespace Maze {
    class Program {
        static void Main(string[] args) {
            try {
                Utils ut = new Utils();
                string[][] jag = ut.ReadFile("test1.txt");
                List<int> LineElementCount = new List<int>();
                for (int x = 0; x < jag.Length; x++) {
                    int countelement = 0;
                    for (int y = 0; y < jag[x].Length; y++) {
                        Console.Write(jag[x][y] + " ");
                        countelement += 1;
                    }
                    Console.WriteLine();
                    LineElementCount.Add(countelement);
                }
                int i;
                for (i = 1; i < LineElementCount.Count; i++) {
                    if (LineElementCount[0] == LineElementCount[i]) {
                        continue;
                    } else {
                        break;
                    }
                }
                if (i != LineElementCount.Count) {
                    throw new ArgumentOutOfRangeException("All lines have to have the same number of elements");
                }
                for (int x = 0; x < jag.Length; x++) {
                    for (int y = 0; y < jag[x].Length; y++) {
                        if (jag[x][y] != "K" && jag[x][y] != "R" && jag[x][y] != "X" && jag[x][y] != "T") {
                            throw new ArgumentOutOfRangeException("File symbols can only be X, R, K, and T");
                        }
                    }
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}

