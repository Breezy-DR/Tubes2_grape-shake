using System;
using System.Collections;

namespace Maze {
    class DFS {
        // Down, up, right, left (prioritas akan berlaku sebaliknya)
        static int[] vertical = {1, -1, 0, 0}; 
        static int[] horizontal = {0, 0, 1, -1};
        Utils ut = new Utils();
        public bool isPathValid(MatrixElement[][] mainMatrix, bool[,] isVisited, int x, int y) {
            // Memvalidasi bahwa mainMatrix[x][y] dapat dikunjungi lagi
            if (x < 0 || y < 0 || x >= mainMatrix.Length || y >= mainMatrix[0].Length) {
                // x dan y tidak boleh out ouf bounds dari mainMatrix
                return false;
            }
            if (isVisited[x, y]) {
                // Dihindari mainMatrix[x][y] yang sudah dikunjungi sebelumnya
                return false;
            }
            return true;
        }

        // public List<Tuple<int, int>> findDFSSolution(MatrixElement[][] mainMatrix, bool[,] isVisited, string[][] jag, int x, int y) {
        //     // Mencari solusi DFS
        //     List<Tuple<int, int>> dfslist = new List<Tuple<int, int>>();
        //     dfslist.Add(new Tuple<int, int>(x, y));
        //     isVisited[x, y] = true;
        //     bool found = false;
        //     Utils ut = new Utils();
            
        // }
        
        public List<Tuple<int, int>> findDFSPath(MatrixElement[][] mainMatrix, bool[,] isVisited, string[][] jag, int x, int y, string destSymbol) {
            // Mencari proses DFS
            List<Tuple<int, int>> dfslist = new List<Tuple<int, int>>();
            Stack<Tuple<int, int>> s = new Stack<Tuple<int, int>>();
            int countTreasure = 0;
            Tuple<int, int> init = new Tuple<int, int>(x, y);
            s.Push(init);
            while (true) {
                Tuple<int, int> temp = s.Peek();
                s.Pop();
                x = temp.Item1;
                y = temp.Item2;
                if (!isPathValid(mainMatrix, isVisited, x, y)) {
                    if (s.Count == 0) {
                        break;
                    } else {
                        continue;
                    }
                }
                if (jag[x][y] == destSymbol && !isVisited[x, y]) {
                    countTreasure += 1;
                }
                isVisited[x, y] = true;
                mainMatrix[x][y].numberOfVisits += 1;
                dfslist.Add(temp);
                for (int i=0; i < 4; i++) {
                    if (i == 0 && !(ut.canMoveDown(mainMatrix, x, y))) {
                        continue;
                    }
                    if (i == 1 && !(ut.canMoveUp(mainMatrix, x, y))) {
                        continue;
                    }
                    if (i == 2 && !(ut.canMoveRight(mainMatrix, x, y))) {
                        continue;
                    }
                    if (i == 3 && !(ut.canMoveLeft(mainMatrix, x, y))) {
                        continue;
                    }
                    s.Push(new Tuple<int, int>(x + vertical[i], y + horizontal[i]));
                }
                if (countTreasure == ut.ElementCount(jag, destSymbol)) {
                    break;
                }
                else {
                    if (ut.stuck(mainMatrix, isVisited, x, y) || ut.surroundedByVisited(mainMatrix, isVisited, x, y)) {
                        // foreach (var a in dfslist) {
                        //     Console.WriteLine(a);
                        // }
                        List<Tuple<int, int>> reverse = Enumerable.Reverse(dfslist).ToList();
                        // foreach (var b in reverse) {
                        //     Console.WriteLine(b);
                        // }
                        int i = 0;
                        do {
                            if (ut.stuck(mainMatrix, isVisited, reverse[i+1].Item1, reverse[i+1].Item2)) {
                                i++;
                            } else {
                                dfslist.Add(reverse[i+1]);
                                mainMatrix[x][y].numberOfVisits += 1;
                            }
                            i++;
                        } while (!ut.isAdjacentToUnvisited(mainMatrix, isVisited, reverse[i].Item1, reverse[i].Item2));
                    }
                }
            }
            ut.ResetMatrix(mainMatrix, isVisited);
            return dfslist;
        }

        public List<Tuple<int, int>> findDFSTSP(MatrixElement[][] mainMatrix, bool[,] isVisited, string[][] jag, List<Tuple<int, int>> dfslist) {
            List<Tuple<int, int>> tsplist = findDFSPath(mainMatrix, isVisited, jag, dfslist.Last().Item1, dfslist.Last().Item2, "K");
            return tsplist;
        }

        
    }
}