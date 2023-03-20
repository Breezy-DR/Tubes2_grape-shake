using System;

namespace Maze {
    class Utils
    {
        public string[][] ReadFile(string filename) {
            string [][] list =
            File.ReadAllLines("../test/" + filename)
            .Select(l => l.Split(' ').ToArray()).ToArray();
            return list;
        }

        public bool isSymbolValid(string[][] jag) {
            for (int x = 0; x < jag.Length; x++) {
                    for (int y = 0; y < jag[x].Length; y++) {
                        if (jag[x][y] != "K" && jag[x][y] != "R" && jag[x][y] != "X" && jag[x][y] != "T") {
                            return false;
                        }
                    }
            }
            return true;
        }

        public void printMatrix(string[][] jag) {
            for (int x = 0; x < jag.Length; x++) {
                    for (int y = 0; y < jag[x].Length; y++) {
                        Console.Write(jag[x][y] + " ");
                    }
                    Console.WriteLine(); 
                }
        }

        public bool isLineHaveEqualElement(string[][] jag) {
            List<int> LineElementCount = new List<int>();
            for (int x = 0; x < jag.Length; x++) {
                    int countelement = 0;
                    for (int y = 0; y < jag[x].Length; y++) {
                        countelement += 1;
                    }
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
                    return false;
            } else {
                return true;
            }
        }

        public MatrixElement[][] InitMatrix(string[][] jag) {
            MatrixElement[][] init = new MatrixElement[jag.Length][];
            for (int i = 0; i < jag.Length; i++) {
                init[i] = new MatrixElement[jag[0].Length];
            }
            for (int i=0; i < init.Length; i++) {
                for (int j=0; j < init[i].Length; j++) {
                    init[i][j] = new MatrixElement(jag[i][j], 0);
                }
            }
            return init;
        }
    }
}