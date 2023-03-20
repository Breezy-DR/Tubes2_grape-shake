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
    }
}