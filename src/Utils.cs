using System;

namespace Maze {
    class Utils
    {
        public string[][] ReadFile(string filename) {
            // Menerima dan membaca file .txt yang akan menjadi input peta maze treasure hunt.
            string [][] list =
            File.ReadAllLines(filename)
            .Select(l => l.Split(' ').ToArray()).ToArray();
            return list;
        }

        public bool isSymbolValid(string[][] jag) {
            // Mengecek apakah sebuah string berupa “K”, “R”, “T”, atau “X”.
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
            // Mem-print Matrix, hanya untuk ProgramTest
            for (int x = 0; x < jag.Length; x++) {
                    for (int y = 0; y < jag[x].Length; y++) {
                        Console.Write(jag[x][y] + " ");
                    }
                    Console.WriteLine(); 
                }
        }

        public bool isLineHaveEqualElement(string[][] jag) {
            // Mengecek apakah tiap baris dari sebuah array 2D memiliki jumlah elemen yang sama
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
            // Menginisialisasi matriks peta dengan simbol sesuai input file dan numberOfVisits = 0
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

        public bool[,] InitBoolMatrix(string[][] jag) {
            // Menginisialisasi array 2D boolean sesuai dimensi pada matriks peta dengan nilai semua elemen = false
            bool [,] isVisited = new bool[jag.Length, jag[0].Length];
            for (int i=0; i < jag.Length; i++) {
                for (int j = 0; j < jag[i].Length; j++) {
                    isVisited[i, j] = false;
                }
            }
            return isVisited;
        }

        public int ElementCount(string[][] jag, string elmt) {
            // Menghitung jumlah sebuah elemen tertentu dalam sebuah matriks
            int count = 0;
            for (int i=0; i < jag.Length; i++) {
                for (int j=0; j < jag[i].Length; j++) {
                    if (jag[i][j] == elmt) {
                        count += 1;
                    }
                }
            }
            return count;
        } 

        public bool canMoveRight(MatrixElement[][] mainMatrix, int x, int y) {
            // Mengecek apakah program bisa berpindah ke kanan
            // (syarat: indeks ke kanan tidak out of bounds dan titik sebelah kanan bukan “X”)
            if (y == mainMatrix[0].Length - 1) {
                return false;
            } else if (mainMatrix[x][y+1].symbol == "X") {
                return false;
            } else {
                return true;
            }
        }
        public bool canMoveLeft(MatrixElement[][] mainMatrix, int x, int y) {
            // Mengecek apakah program bisa berpindah ke kiri
            // (syarat: indeks ke kiri tidak out of bounds dan titik sebelah kiri bukan “X”)
            if (y == 0) {
                return false;
            } else if (mainMatrix[x][y-1].symbol == "X") {
                return false;
            } else {
                return true;
            }
        }
        public bool canMoveUp(MatrixElement[][] mainMatrix, int x, int y) {
            // Mengecek apakah program bisa berpindah ke atas
            // (syarat: indeks ke atas tidak out of bounds dan titik sebelah atas bukan “X”)
            if (x == 0) {
                return false;
            } else if (mainMatrix[x-1][y].symbol == "X") {
                return false;
            } else {
                return true;
            }
        }
        public bool canMoveDown(MatrixElement[][] mainMatrix, int x, int y) {
            // Mengecek apakah program bisa berpindah ke bawah
            // (syarat: indeks ke bawah tidak out of bounds dan titik sebelah bawah bukan “X”)
            if (x == mainMatrix.Length - 1) {
                return false;
            } else if (mainMatrix[x+1][y].symbol == "X") {
                return false;
            } else {
                return true;
            }
        }

        public void ResetMatrix(MatrixElement[][] mainMatrix, bool[,] isVisited) {
            // Membuat nilai numberOfVisits pada seluruh titik di peta menjadi nol dan membuat nilai elemen pada matriks boolean menjadi false
            for (int i = 0; i < mainMatrix.Length; i++) {
                for (int j = 0; j < mainMatrix[0].Length; j++) {
                    mainMatrix[i][j].numberOfVisits = 0;
                    isVisited[i, j] = false;
                }
            }
        }

        public void resetMainMatrix(MatrixElement[][] mainMatrix) {
            // Membuat nilai numberOfVisits pada seluruh titik di peta menjadi nol
            for (int i = 0; i < mainMatrix.Length; i++) {
                for (int j = 0; j < mainMatrix[0].Length; j++) {
                    mainMatrix[i][j].numberOfVisits = 0;
                }
            }
        }

        public void ResetBoolMatrix(bool[,] isVisited) {
            // Membuat nilai elemen pada matriks boolean menjadi false
            for (int i = 0; i < isVisited.GetLength(0); i++) {
                for (int j = 0; j < isVisited.GetLength(1); j++) {
                    isVisited[i, j] = false;
                }
            }
        }
        public List<Tuple<int, int>> findPath(List<Tuple<int, int, int, int>> Process, int startX, int startY, int x, int y) {
            /* Fungsi untuk mencari path berdasarkan list process BFS dan DFS. 
               Menghasilkan list path dari titik (startX, startY) sampai ke titik (x, y) */
            List<Tuple<int, int>> path = new List<Tuple<int, int>>();
            int i = Process.Count - 1;

            while (!(Process[i].Item1 == startX && Process[i].Item2 == startY && Process[i].Item3 == startX && Process[i].Item4 == startY)) {
                if ((Process[i].Item1 == x && Process[i].Item2 == y) && !(Process[i].Item1 == Process[i].Item3 && Process[i].Item2 == Process[i].Item4)) {
                    path.Add(new Tuple<int, int>(Process[i].Item1, Process[i].Item2));
                    x = Process[i].Item3;
                    y = Process[i].Item4;
                }
                i--;
            }
            path.Add(new Tuple<int, int>(startX, startY));
            path.Reverse();
            return path;
        }
    }
}